using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Text.Json;
using H_Pannel_lib;
using Basic;

namespace LabelRenderer
{
    class Program
    {
        public static string LabelRenderer_Url = "http://127.0.0.1:8700/";

        // ✅ 併發控制
        private static readonly int MaxConcurrentRender = 10;
        private static readonly SemaphoreSlim RenderSemaphore = new SemaphoreSlim(MaxConcurrentRender);

        // ✅ 請求 Queue
        private static readonly BlockingCollection<(HttpListenerContext ctx, string body)> RequestQueue
            = new BlockingCollection<(HttpListenerContext, string)>();

        static void Main(string[] args)
        {
            Console.Title = "LabelRenderer - GDI Queue Engine";
            Console.WriteLine($"[OK] Listening: {LabelRenderer_Url}");
            Console.WriteLine($"[INFO] Max Concurrent Render = {MaxConcurrentRender}");

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(LabelRenderer_Url);
            listener.Start();

            // ✅ Queue Worker threads
            for (int i = 0; i < MaxConcurrentRender; i++)
            {
                Thread worker = new Thread(RenderWorker) { IsBackground = true };
                worker.Start();
            }

            Console.CancelKeyPress += (s, e) =>
            {
                listener.Stop();
                RequestQueue.CompleteAdding();
                Console.WriteLine("[STOP] Renderer stopped");
            };

            while (true)
            {
                HttpListenerContext ctx = listener.GetContext();
                ThreadPool.QueueUserWorkItem(_ => EnqueueRequest(ctx));
            }
        }

        private static void EnqueueRequest(HttpListenerContext ctx)
        {
            try
            {
                var req = ctx.Request;

                string clientIp = req.RemoteEndPoint?.Address?.ToString() ?? "unknown";
                int clientPort = req.RemoteEndPoint?.Port ?? -1;

                if (req.HttpMethod == "POST" && req.Url.AbsolutePath == "/render")
                {
                    using (var sr = new StreamReader(req.InputStream, req.ContentEncoding))
                    {
                        string body = sr.ReadToEnd();
                        RequestQueue.Add((ctx, body));
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [QUEUE] +1 From {clientIp}:{clientPort} (Q={RequestQueue.Count})");
                    }
                }
                else if (req.HttpMethod == "GET" && req.Url.AbsolutePath == "/health")
                {
                    WriteJson(ctx.Response, 200, new { ok = true, queue = RequestQueue.Count });
                }
                else
                {
                    WriteJson(ctx.Response, 404, new { ok = false });
                }
            }
            catch { }
        }

        private static async void RenderWorker()
        {
            foreach (var job in RequestQueue.GetConsumingEnumerable())
            {
                var (ctx, body) = job;
                var req = ctx.Request;
                var resp = ctx.Response;

                string clientIp = req.RemoteEndPoint?.Address?.ToString() ?? "unknown";
                int clientPort = req.RemoteEndPoint?.Port ?? -1;

                await RenderSemaphore.WaitAsync(); // ✅ 控制同時 GDI 數

                try
                {
                    var doc = JsonDocument.Parse(body);
                    var valueAry = doc.RootElement.GetProperty("ValueAry")
                                    .EnumerateArray()
                                    .Select(e => e.GetString())
                                    .ToList();
                    var Value = doc.RootElement.GetProperty("Data");
                    Storage storage = Value.ObjToClass<Storage>();


                    string ip = valueAry.FirstOrDefault(s => s.StartsWith("ip="))?.Split('=')[1];
                    string deviceType = valueAry.FirstOrDefault(s => s.StartsWith("device_type="))?.Split('=')[1];

                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [RENDER] {clientIp}:{clientPort} → {ip} / {deviceType}");

                    UDP_Class uDP_Class = new UDP_Class(ip, 29000, false);


                    resp.StatusCode = 200;
                    resp.ContentType = "image/png";
                    resp.OutputStream.Write(new byte[0], 0, 0);
                    resp.Close();
                    // 🚧 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERR] {ex.Message}");
                    WriteJson(resp, 500, new { ok = false, error = ex.Message });
                }
                finally
                {
                    RenderSemaphore.Release();
                }
            }
        }

        private static void WriteJson(HttpListenerResponse resp, int code, object obj)
        {
            var json = new JavaScriptSerializer().Serialize(obj);
            var data = Encoding.UTF8.GetBytes(json);
            resp.StatusCode = code;
            resp.ContentType = "application/json";
            resp.OutputStream.Write(data, 0, data.Length);
            resp.Close();
        }
    }
}
