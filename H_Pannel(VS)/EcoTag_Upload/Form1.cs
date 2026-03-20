using Basic;
using H_Pannel_lib;
using HIS_DB_Lib;
using MySqlX.XDevAPI.Relational;
using MyUI;
using SQLUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcoTag_Upload
{
    public partial class Form1 : Form
    {
        public static string currentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static string API_Server = "";


        #region MyConfigClass
        private static string MyConfigFileName = $@"{currentDirectory}\MyConfig.txt";
        static public MyConfigClass myConfigClass = new MyConfigClass();
        public class MyConfigClass
        {

            private string _裝置IP;
            private string _面板種類;
            private string _json_storages;


            public string 裝置IP { get => _裝置IP; set => _裝置IP = value; }
            public string 面板種類 { get => _面板種類; set => _面板種類 = value; }
            public string Json_storages { get => _json_storages; set => _json_storages = value; }
        }
        private void LoadMyConfig()
        {
            string jsonstr = MyFileStream.LoadFileAllText($"{MyConfigFileName}");
            if (jsonstr.StringIsEmpty())
            {
                jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(new MyConfigClass(), true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($"{MyConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
                }
                MyMessageBox.ShowDialog($"未建立參數文件!請至子目錄設定{MyConfigFileName}");
                Application.Exit();
            }
            else
            {
                myConfigClass = Basic.Net.JsonDeserializet<MyConfigClass>(jsonstr);

                jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(myConfigClass, true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($"{MyConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
                }

            }

        }
        private void SaveMyConfig()
        {
            string jsonstr = Basic.Net.JsonSerializationt<MyConfigClass>(myConfigClass, true);
            List<string> list_jsonstring = new List<string>();
            list_jsonstring.Add(jsonstr);
            if (!MyFileStream.SaveFile($"{MyConfigFileName}", list_jsonstring))
            {
                MyMessageBox.ShowDialog($"建立{MyConfigFileName}檔案失敗!");
            }

        }
        #endregion
        #region DBConfigClass
        private static string DBConfigFileName = $@"{currentDirectory}\DBConfig.txt";
        static public DBConfigClass dBConfigClass = new DBConfigClass();
        public class DBConfigClass
        {

            public string Api_Server { get => api_Server; set => api_Server = value; }

      
            private string api_Server = "";

       
        }

        private void LoadDBConfig()
        {

            string jsonstr = MyFileStream.LoadFileAllText($"{DBConfigFileName}");
            if (jsonstr.StringIsEmpty())
            {

                jsonstr = Basic.Net.JsonSerializationt<DBConfigClass>(new DBConfigClass(), true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($"{DBConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{DBConfigFileName}檔案失敗!");
                }
                MyMessageBox.ShowDialog($"未建立參數文件!請至子目錄設定{DBConfigFileName}");
                Application.Exit();
            }
            else
            {
                dBConfigClass = Basic.Net.JsonDeserializet<DBConfigClass>(jsonstr);

                jsonstr = Basic.Net.JsonSerializationt<DBConfigClass>(dBConfigClass, true);
                List<string> list_jsonstring = new List<string>();
                list_jsonstring.Add(jsonstr);
                if (!MyFileStream.SaveFile($"{DBConfigFileName}", list_jsonstring))
                {
                    MyMessageBox.ShowDialog($"建立{DBConfigFileName}檔案失敗!");
                }

            }
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.FormClosing += Form1_FormClosing;

            rJ_Button_步驟1_確認.MouseDownEvent += RJ_Button_步驟1_確認_MouseDownEvent;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MyMessageBox.form = this.FindForm();
            MyMessageBox.音效 = false;
            LoadingForm.form = this.FindForm();

            LoadMyConfig();
            storagePanel.SizeChanged += StoragePanel_SizeChanged;
            storagePanel.SureClick += StoragePanel_SureClick;
            this.storagePanel.Location = new Point((this.storagePanel.Parent.Width - this.storagePanel.Width) / 2, (this.storagePanel.Parent.Height - this.storagePanel.Height) / 2);

            rJ_TextBox_裝置IP.Text = myConfigClass.裝置IP;
            rJ_ComboBox_面板種類.Text = myConfigClass.面板種類;
            if(rJ_ComboBox_面板種類.Text.StringIsEmpty()) rJ_ComboBox_面板種類.SelectedIndex = 0;
            LoadDBConfig();
            API_Server = dBConfigClass.Api_Server;
            sqL_DataGridView_藥品資料.RowDoubleClickEvent += SqL_DataGridView_藥品資料_RowDoubleClickEvent;
            comboBox_藥品資料_搜尋方式.SelectedIndex = 0;
            rJ_Button_藥品資料_搜尋.MouseDownEvent += RJ_Button_藥品資料_搜尋_MouseDownEvent;
            rJ_Button_藥品資料_填入.MouseDownEvent += RJ_Button_藥品資料_填入_MouseDownEvent;
            rJ_Button_儲存格式.MouseDownEvent += RJ_Button_儲存格式_MouseDownEvent;

            rJ_TextBox_藥品資料_搜尋內容.KeyPress += RJ_TextBox_藥品資料_搜尋內容_KeyPress;
            rJ_Button_上傳.MouseDownEvent += RJ_Button_上傳_MouseDownEvent;
            SQLUI.Table table = medClass.init(API_Server);
            if (table != null)
            {
                sqL_DataGridView_藥品資料.Init(table);
                this.sqL_DataGridView_藥品資料.Set_ColumnVisible(false, new enum_雲端藥檔().GetEnumNames());
                this.sqL_DataGridView_藥品資料.Set_ColumnWidth(100, DataGridViewContentAlignment.MiddleCenter, enum_雲端藥檔.藥品碼);
                this.sqL_DataGridView_藥品資料.Set_ColumnWidth(400, DataGridViewContentAlignment.MiddleLeft, enum_雲端藥檔.藥品名稱);
                this.sqL_DataGridView_藥品資料.Set_ColumnText("藥碼", enum_雲端藥檔.藥品碼);
                this.sqL_DataGridView_藥品資料.Set_ColumnText("藥名", enum_雲端藥檔.藥品名稱);
            }
        }

 

        private void RJ_TextBox_藥品資料_搜尋內容_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((char)Keys.Enter == e.KeyChar)
            {
                RJ_Button_藥品資料_搜尋_MouseDownEvent(null);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rJ_TextBox_裝置IP.Text.Check_IP_Adress()) myConfigClass.裝置IP = rJ_TextBox_裝置IP.Text;
            if(rJ_ComboBox_面板種類.Text.StringIsEmpty() == false) myConfigClass.面板種類 = rJ_ComboBox_面板種類.Text;

            SaveMyConfig();
        }

        private void StoragePanel_SizeChanged(object sender, EventArgs e)
        {
            this.storagePanel.Location = new Point((this.storagePanel.Parent.Width - this.storagePanel.Width) / 2, (this.storagePanel.Parent.Height - this.storagePanel.Height) / 2);

        }
        private void StoragePanel_SureClick(Storage storage)
        {
            this.storagePanel.DrawToPictureBox(storage);
        }
        private void SqL_DataGridView_藥品資料_RowDoubleClickEvent(object[] RowValue)
        {
            RJ_Button_藥品資料_填入_MouseDownEvent(null);
        }
        private void RJ_Button_步驟1_確認_MouseDownEvent(MouseEventArgs mevent)
        {
            if(rJ_Button_步驟1_確認.Text == "確認")
            {
                if (Basic.Net.Ping(rJ_TextBox_裝置IP.Text, 3, 500) == false)
                {
                    MyMessageBox.ShowDialog("裝置無法連接,請檢查裝置是否上線");
                    return;
                }

          
          

                this.Invoke(new Action(delegate
                {
                    rJ_TextBox_裝置IP.Enabled = false;
                    rJ_ComboBox_面板種類.Enabled = false;

                    rJ_Pannel_藥品搜尋.Enabled = true;
                    rJ_Pannel_面板調整.Enabled = true;

               
                    rJ_Button_步驟1_確認.Text = "返回";
                    rJ_Button_步驟1_確認.ForeColor = Color.RoyalBlue;
                    rJ_Button_步驟1_確認.BackgroundColor = Color.White;
                    rJ_Button_步驟1_確認.BorderColor = Color.RoyalBlue;
                    rJ_Button_步驟1_確認.BorderSize = 1;
                }));
            }
            else if (rJ_Button_步驟1_確認.Text == "返回")
            {
                this.Invoke(new Action(delegate
                {
                    rJ_TextBox_裝置IP.Enabled = true;
                    rJ_ComboBox_面板種類.Enabled = true;

                    rJ_Pannel_藥品搜尋.Enabled = false;
                    rJ_Pannel_面板調整.Enabled = false;
                    rJ_Button_步驟1_確認.Text = "確認";
                    rJ_Button_步驟1_確認.ForeColor = Color.White;
                    rJ_Button_步驟1_確認.BackgroundColor = Color.RoyalBlue;
                    rJ_Button_步驟1_確認.BorderColor = Color.RoyalBlue;
                    rJ_Button_步驟1_確認.BorderSize = 0;
                    storagePanel.DrawToPictureBox(new Storage());
                    rJ_Button_儲存格式.Enabled = false;
                    rJ_Button_上傳.Enabled = false;
                }));

      
            }

        }
        private void RJ_Button_藥品資料_搜尋_MouseDownEvent(MouseEventArgs mevent)
        {
            string cmb_text = comboBox_藥品資料_搜尋方式.GetComboBoxText();
            string search_text = rJ_TextBox_藥品資料_搜尋內容.Text;
            List<medClass> medClasses = new List<medClass>();
            if (search_text.StringIsEmpty() && cmb_text != "全部顯示")
            {
                MyMessageBox.ShowDialog("請輸入搜尋內容!");
                return;
            }
            if (cmb_text == "藥碼")
            {
                medClass _medClass = medClass.get_med_clouds_by_code(API_Server, search_text);
                if (_medClass == null)
                {
                    MyMessageBox.ShowDialog("查無資料!");
                    return;
                }
                medClasses.Add(_medClass);
            }
            else if (cmb_text == "藥名")
            {
                List<medClass> medClasses_temp = medClass.get_med_clouds_by_name(API_Server, search_text);
                medClasses.LockAdd(medClasses_temp);
            }
            else if (cmb_text == "全部顯示")
            {
                List<medClass> medClasses_temp = medClass.get_med_cloud(API_Server);
                medClasses.LockAdd(medClasses_temp);
            }
            else
            {
                MyMessageBox.ShowDialog("請選擇搜尋方式!");
            }

            if (medClasses.Count == 0)
            {
                MyMessageBox.ShowDialog("查無資料!");
                return;
            }
            List<object[]> list_value = medClasses.ClassToSQL<medClass, enum_雲端藥檔>();
            this.sqL_DataGridView_藥品資料.RefreshGrid(list_value);
        }
        private void RJ_Button_藥品資料_填入_MouseDownEvent(MouseEventArgs mevent)
        {
            List<object[]> objects = this.sqL_DataGridView_藥品資料.Get_All_Select_RowsValues();
            if(objects.Count == 0)
            {
                MyMessageBox.ShowDialog("請選擇要填入的藥品資料!");
                return;
            }
            medClass medClass = objects[0].SQLToClass<medClass, enum_雲端藥檔>();
            if (rJ_ComboBox_面板種類.Text == "2.9-4Color")
            {
                List<Storage> storages = Basic.Net.JsonDeserializet<List<Storage>>(myConfigClass.Json_storages);
                Storage storage = storages.Where(x => x.DeviceType == DeviceType.EPD290G).FirstOrDefault();
                if(storage == null) storage = new Storage();

                storage.SetDeviceType(DeviceType.EPD290G);
                storage.SetMedClass(medClass);
                storagePanel.DrawToPictureBox(storage);
                rJ_Button_儲存格式.Enabled = true;
                rJ_Button_上傳.Enabled = true;
            }
            if (rJ_ComboBox_面板種類.Text == "7.3-6Color")
            {
                List<Storage> storages = Basic.Net.JsonDeserializet<List<Storage>>(myConfigClass.Json_storages);
                Storage storage = storages.Where(x => x.DeviceType == DeviceType.EPD730E).FirstOrDefault();
                if (storage == null) storage = new Storage();
                storage.SetDeviceType(DeviceType.EPD730E);
                storage.SetMedClass(medClass);
                storagePanel.DrawToPictureBox(storage);
                rJ_Button_儲存格式.Enabled = true;
                rJ_Button_上傳.Enabled = true;
            }
        }
        private void RJ_Button_儲存格式_MouseDownEvent(MouseEventArgs mevent)
        {
            string json = myConfigClass.Json_storages;

            List<Storage> storages = Basic.Net.JsonDeserializet<List<Storage>>(json);
            if (storages == null) storages = new List<Storage>();
            if (rJ_ComboBox_面板種類.Text == "2.9-4Color")
            {
                Storage storage = storages.Where(x => x.DeviceType == DeviceType.EPD290G).FirstOrDefault();
                if (storage == null)
                {
                    storages.Add(storagePanel.CurrentStorage);
                }
                else
                {
                    storages.Remove(storage);
                    storages.Add(storagePanel.CurrentStorage);
                }
            }
            if (rJ_ComboBox_面板種類.Text == "7.3-6Color")
            {
                Storage storage = storages.Where(x => x.DeviceType == DeviceType.EPD730E).FirstOrDefault();
                if (storage == null)
                {
                    storages.Add(storagePanel.CurrentStorage);
                }
                else
                {
                    storages.Remove(storage);
                    storages.Add(storagePanel.CurrentStorage);
                }
            }
            myConfigClass.Json_storages = storages.JsonSerializationt();
            SaveMyConfig();
            MyMessageBox.ShowDialog("儲存成功");
        }
        private void RJ_Button_上傳_MouseDownEvent(MouseEventArgs mevent)
        {
            LoadingForm.ShowLoadingForm();
            Communication.ConsoleWrite = true;
            UDP_Class uDP_Class = new UDP_Class(rJ_TextBox_裝置IP.Text, 29000, false);
            storagePanel.CurrentStorage.IP = rJ_TextBox_裝置IP.Text;
            storagePanel.CurrentStorage.Code = storagePanel.CurrentStorage.SKDIACODE;
            storagePanel.CurrentStorage.BarCode = storagePanel.CurrentStorage.SKDIACODE;
            storagePanel.CurrentStorage.QRCode = storagePanel.CurrentStorage.SKDIACODE;
            StorageUI_EPD_266.DrawToEpd_UDP(uDP_Class, storagePanel.CurrentStorage);
            uDP_Class.Dispose();
            LoadingForm.CloseLoadingForm();


        }
    }
}
