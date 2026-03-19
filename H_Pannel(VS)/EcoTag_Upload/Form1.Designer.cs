namespace EcoTag_Upload
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rJ_TextBox_裝置IP = new MyUI.RJ_TextBox();
            this.rJ_Lable1 = new MyUI.RJ_Lable();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rJ_ComboBox_面板種類 = new MyUI.RJ_ComboBox();
            this.rJ_Lable2 = new MyUI.RJ_Lable();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.rJ_Button_步驟1_確認 = new MyUI.RJ_Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rJ_Pannel_面板調整 = new MyUI.RJ_Pannel();
            this.rJ_Pannel_藥品搜尋 = new MyUI.RJ_Pannel();
            this.rJ_Button_藥品資料_搜尋 = new MyUI.RJ_Button();
            this.sqL_DataGridView_藥品資料 = new SQLUI.SQL_DataGridView();
            this.rJ_TextBox_藥品資料_搜尋內容 = new MyUI.RJ_TextBox();
            this.comboBox_藥品資料_搜尋方式 = new System.Windows.Forms.ComboBox();
            this.rJ_Button_藥品資料_填入 = new MyUI.RJ_Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rJ_Button_儲存格式 = new MyUI.RJ_Button();
            this.storagePanel = new H_Pannel_lib.StoragePanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rJ_Button_上傳 = new MyUI.RJ_Button();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel4.SuspendLayout();
            this.rJ_Pannel_面板調整.SuspendLayout();
            this.rJ_Pannel_藥品搜尋.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel18);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.panel14);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(1578, 78);
            this.panel3.TabIndex = 141;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rJ_TextBox_裝置IP);
            this.panel1.Controls.Add(this.rJ_Lable1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(10, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 78);
            this.panel1.TabIndex = 28;
            // 
            // rJ_TextBox_裝置IP
            // 
            this.rJ_TextBox_裝置IP.BackColor = System.Drawing.SystemColors.Window;
            this.rJ_TextBox_裝置IP.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.rJ_TextBox_裝置IP.BorderFocusColor = System.Drawing.Color.RoyalBlue;
            this.rJ_TextBox_裝置IP.BorderRadius = 5;
            this.rJ_TextBox_裝置IP.BorderSize = 1;
            this.rJ_TextBox_裝置IP.Dock = System.Windows.Forms.DockStyle.Top;
            this.rJ_TextBox_裝置IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.rJ_TextBox_裝置IP.ForeColor = System.Drawing.Color.DimGray;
            this.rJ_TextBox_裝置IP.GUID = "";
            this.rJ_TextBox_裝置IP.Location = new System.Drawing.Point(0, 21);
            this.rJ_TextBox_裝置IP.Multiline = false;
            this.rJ_TextBox_裝置IP.Name = "rJ_TextBox_裝置IP";
            this.rJ_TextBox_裝置IP.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rJ_TextBox_裝置IP.PassWordChar = false;
            this.rJ_TextBox_裝置IP.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rJ_TextBox_裝置IP.PlaceholderText = "192.168.XXX.XXX";
            this.rJ_TextBox_裝置IP.ShowTouchPannel = false;
            this.rJ_TextBox_裝置IP.Size = new System.Drawing.Size(360, 41);
            this.rJ_TextBox_裝置IP.TabIndex = 30;
            this.rJ_TextBox_裝置IP.TextAlgin = System.Windows.Forms.HorizontalAlignment.Left;
            this.rJ_TextBox_裝置IP.Texts = "";
            this.rJ_TextBox_裝置IP.UnderlineStyle = false;
            // 
            // rJ_Lable1
            // 
            this.rJ_Lable1.BackColor = System.Drawing.Color.White;
            this.rJ_Lable1.BackgroundColor = System.Drawing.Color.White;
            this.rJ_Lable1.BorderColor = System.Drawing.Color.White;
            this.rJ_Lable1.BorderRadius = 10;
            this.rJ_Lable1.BorderSize = 10;
            this.rJ_Lable1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rJ_Lable1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rJ_Lable1.ForeColor = System.Drawing.Color.Transparent;
            this.rJ_Lable1.GUID = "";
            this.rJ_Lable1.Location = new System.Drawing.Point(0, 0);
            this.rJ_Lable1.Name = "rJ_Lable1";
            this.rJ_Lable1.ShadowColor = System.Drawing.Color.DimGray;
            this.rJ_Lable1.ShadowSize = 0;
            this.rJ_Lable1.Size = new System.Drawing.Size(360, 21);
            this.rJ_Lable1.TabIndex = 29;
            this.rJ_Lable1.Text = "裝置IP";
            this.rJ_Lable1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rJ_Lable1.TextColor = System.Drawing.Color.Black;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(370, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(11, 78);
            this.panel14.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rJ_ComboBox_面板種類);
            this.panel2.Controls.Add(this.rJ_Lable2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(381, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(360, 78);
            this.panel2.TabIndex = 143;
            // 
            // rJ_ComboBox_面板種類
            // 
            this.rJ_ComboBox_面板種類.BackColor = System.Drawing.SystemColors.Window;
            this.rJ_ComboBox_面板種類.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.rJ_ComboBox_面板種類.BorderSize = 1;
            this.rJ_ComboBox_面板種類.Dock = System.Windows.Forms.DockStyle.Top;
            this.rJ_ComboBox_面板種類.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.rJ_ComboBox_面板種類.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rJ_ComboBox_面板種類.ForeColor = System.Drawing.Color.DimGray;
            this.rJ_ComboBox_面板種類.GUID = "";
            this.rJ_ComboBox_面板種類.IconColor = System.Drawing.Color.RoyalBlue;
            this.rJ_ComboBox_面板種類.Items.AddRange(new object[] {
            "2.9-4Color",
            "7.3-6Color"});
            this.rJ_ComboBox_面板種類.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.rJ_ComboBox_面板種類.ListTextColor = System.Drawing.Color.DimGray;
            this.rJ_ComboBox_面板種類.Location = new System.Drawing.Point(0, 21);
            this.rJ_ComboBox_面板種類.MinimumSize = new System.Drawing.Size(50, 30);
            this.rJ_ComboBox_面板種類.Name = "rJ_ComboBox_面板種類";
            this.rJ_ComboBox_面板種類.Padding = new System.Windows.Forms.Padding(1);
            this.rJ_ComboBox_面板種類.Size = new System.Drawing.Size(360, 43);
            this.rJ_ComboBox_面板種類.TabIndex = 2;
            this.rJ_ComboBox_面板種類.Texts = "";
            // 
            // rJ_Lable2
            // 
            this.rJ_Lable2.BackColor = System.Drawing.Color.White;
            this.rJ_Lable2.BackgroundColor = System.Drawing.Color.White;
            this.rJ_Lable2.BorderColor = System.Drawing.Color.White;
            this.rJ_Lable2.BorderRadius = 10;
            this.rJ_Lable2.BorderSize = 10;
            this.rJ_Lable2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rJ_Lable2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Lable2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rJ_Lable2.ForeColor = System.Drawing.Color.Transparent;
            this.rJ_Lable2.GUID = "";
            this.rJ_Lable2.Location = new System.Drawing.Point(0, 0);
            this.rJ_Lable2.Name = "rJ_Lable2";
            this.rJ_Lable2.ShadowColor = System.Drawing.Color.DimGray;
            this.rJ_Lable2.ShadowSize = 0;
            this.rJ_Lable2.Size = new System.Drawing.Size(360, 21);
            this.rJ_Lable2.TabIndex = 29;
            this.rJ_Lable2.Text = "面板種類";
            this.rJ_Lable2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rJ_Lable2.TextColor = System.Drawing.Color.Black;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(741, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(11, 78);
            this.panel10.TabIndex = 144;
            // 
            // panel18
            // 
            this.panel18.BackColor = System.Drawing.Color.White;
            this.panel18.Controls.Add(this.rJ_Button_步驟1_確認);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(752, 0);
            this.panel18.Name = "panel18";
            this.panel18.Padding = new System.Windows.Forms.Padding(5);
            this.panel18.Size = new System.Drawing.Size(137, 78);
            this.panel18.TabIndex = 145;
            // 
            // rJ_Button_步驟1_確認
            // 
            this.rJ_Button_步驟1_確認.AutoResetState = false;
            this.rJ_Button_步驟1_確認.BackColor = System.Drawing.Color.Transparent;
            this.rJ_Button_步驟1_確認.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rJ_Button_步驟1_確認.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJ_Button_步驟1_確認.BorderRadius = 20;
            this.rJ_Button_步驟1_確認.BorderSize = 0;
            this.rJ_Button_步驟1_確認.buttonType = MyUI.RJ_Button.ButtonType.Push;
            this.rJ_Button_步驟1_確認.DisenableColor = System.Drawing.Color.Gray;
            this.rJ_Button_步驟1_確認.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rJ_Button_步驟1_確認.FlatAppearance.BorderSize = 0;
            this.rJ_Button_步驟1_確認.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Button_步驟1_確認.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJ_Button_步驟1_確認.ForeColor = System.Drawing.Color.White;
            this.rJ_Button_步驟1_確認.GUID = "";
            this.rJ_Button_步驟1_確認.Image_padding = new System.Windows.Forms.Padding(0);
            this.rJ_Button_步驟1_確認.Location = new System.Drawing.Point(5, 5);
            this.rJ_Button_步驟1_確認.Name = "rJ_Button_步驟1_確認";
            this.rJ_Button_步驟1_確認.ProhibitionBorderLineWidth = 1;
            this.rJ_Button_步驟1_確認.ProhibitionLineWidth = 4;
            this.rJ_Button_步驟1_確認.ProhibitionSymbolSize = 30;
            this.rJ_Button_步驟1_確認.ShadowColor = System.Drawing.Color.LightGray;
            this.rJ_Button_步驟1_確認.ShadowSize = 3;
            this.rJ_Button_步驟1_確認.ShowLoadingForm = false;
            this.rJ_Button_步驟1_確認.Size = new System.Drawing.Size(127, 68);
            this.rJ_Button_步驟1_確認.State = false;
            this.rJ_Button_步驟1_確認.TabIndex = 0;
            this.rJ_Button_步驟1_確認.Text = "確認";
            this.rJ_Button_步驟1_確認.TextColor = System.Drawing.Color.White;
            this.rJ_Button_步驟1_確認.TextHeight = 0;
            this.rJ_Button_步驟1_確認.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rJ_Pannel_藥品搜尋);
            this.panel4.Controls.Add(this.rJ_Pannel_面板調整);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 81);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1578, 624);
            this.panel4.TabIndex = 177;
            // 
            // rJ_Pannel_面板調整
            // 
            this.rJ_Pannel_面板調整.BackColor = System.Drawing.Color.White;
            this.rJ_Pannel_面板調整.BackgroundColor = System.Drawing.Color.White;
            this.rJ_Pannel_面板調整.BorderColor = System.Drawing.Color.Gainsboro;
            this.rJ_Pannel_面板調整.BorderRadius = 30;
            this.rJ_Pannel_面板調整.BorderSize = 1;
            this.rJ_Pannel_面板調整.Controls.Add(this.storagePanel);
            this.rJ_Pannel_面板調整.Dock = System.Windows.Forms.DockStyle.Left;
            this.rJ_Pannel_面板調整.Enabled = false;
            this.rJ_Pannel_面板調整.ForeColor = System.Drawing.Color.Black;
            this.rJ_Pannel_面板調整.IsSelected = false;
            this.rJ_Pannel_面板調整.Location = new System.Drawing.Point(0, 0);
            this.rJ_Pannel_面板調整.Name = "rJ_Pannel_面板調整";
            this.rJ_Pannel_面板調整.Padding = new System.Windows.Forms.Padding(25, 20, 30, 20);
            this.rJ_Pannel_面板調整.ShadowColor = System.Drawing.Color.Gainsboro;
            this.rJ_Pannel_面板調整.ShadowSize = 5;
            this.rJ_Pannel_面板調整.Size = new System.Drawing.Size(841, 624);
            this.rJ_Pannel_面板調整.TabIndex = 140;
            // 
            // rJ_Pannel_藥品搜尋
            // 
            this.rJ_Pannel_藥品搜尋.BackColor = System.Drawing.Color.White;
            this.rJ_Pannel_藥品搜尋.BackgroundColor = System.Drawing.Color.White;
            this.rJ_Pannel_藥品搜尋.BorderColor = System.Drawing.Color.Gainsboro;
            this.rJ_Pannel_藥品搜尋.BorderRadius = 30;
            this.rJ_Pannel_藥品搜尋.BorderSize = 1;
            this.rJ_Pannel_藥品搜尋.Controls.Add(this.rJ_Button_藥品資料_填入);
            this.rJ_Pannel_藥品搜尋.Controls.Add(this.rJ_Button_藥品資料_搜尋);
            this.rJ_Pannel_藥品搜尋.Controls.Add(this.sqL_DataGridView_藥品資料);
            this.rJ_Pannel_藥品搜尋.Controls.Add(this.rJ_TextBox_藥品資料_搜尋內容);
            this.rJ_Pannel_藥品搜尋.Controls.Add(this.comboBox_藥品資料_搜尋方式);
            this.rJ_Pannel_藥品搜尋.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rJ_Pannel_藥品搜尋.Enabled = false;
            this.rJ_Pannel_藥品搜尋.ForeColor = System.Drawing.Color.Black;
            this.rJ_Pannel_藥品搜尋.IsSelected = false;
            this.rJ_Pannel_藥品搜尋.Location = new System.Drawing.Point(841, 0);
            this.rJ_Pannel_藥品搜尋.Name = "rJ_Pannel_藥品搜尋";
            this.rJ_Pannel_藥品搜尋.Padding = new System.Windows.Forms.Padding(25, 20, 30, 20);
            this.rJ_Pannel_藥品搜尋.ShadowColor = System.Drawing.Color.Gainsboro;
            this.rJ_Pannel_藥品搜尋.ShadowSize = 5;
            this.rJ_Pannel_藥品搜尋.Size = new System.Drawing.Size(737, 624);
            this.rJ_Pannel_藥品搜尋.TabIndex = 168;
            // 
            // rJ_Button_藥品資料_搜尋
            // 
            this.rJ_Button_藥品資料_搜尋.AutoResetState = false;
            this.rJ_Button_藥品資料_搜尋.BackColor = System.Drawing.Color.White;
            this.rJ_Button_藥品資料_搜尋.BackgroundColor = System.Drawing.Color.DimGray;
            this.rJ_Button_藥品資料_搜尋.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJ_Button_藥品資料_搜尋.BorderRadius = 22;
            this.rJ_Button_藥品資料_搜尋.BorderSize = 0;
            this.rJ_Button_藥品資料_搜尋.buttonType = MyUI.RJ_Button.ButtonType.Push;
            this.rJ_Button_藥品資料_搜尋.DisenableColor = System.Drawing.Color.Gray;
            this.rJ_Button_藥品資料_搜尋.FlatAppearance.BorderSize = 0;
            this.rJ_Button_藥品資料_搜尋.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Button_藥品資料_搜尋.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rJ_Button_藥品資料_搜尋.ForeColor = System.Drawing.Color.White;
            this.rJ_Button_藥品資料_搜尋.GUID = "";
            this.rJ_Button_藥品資料_搜尋.Image_padding = new System.Windows.Forms.Padding(0);
            this.rJ_Button_藥品資料_搜尋.Location = new System.Drawing.Point(393, 561);
            this.rJ_Button_藥品資料_搜尋.Name = "rJ_Button_藥品資料_搜尋";
            this.rJ_Button_藥品資料_搜尋.ProhibitionBorderLineWidth = 1;
            this.rJ_Button_藥品資料_搜尋.ProhibitionLineWidth = 4;
            this.rJ_Button_藥品資料_搜尋.ProhibitionSymbolSize = 30;
            this.rJ_Button_藥品資料_搜尋.ShadowColor = System.Drawing.Color.DimGray;
            this.rJ_Button_藥品資料_搜尋.ShadowSize = 0;
            this.rJ_Button_藥品資料_搜尋.ShowLoadingForm = false;
            this.rJ_Button_藥品資料_搜尋.Size = new System.Drawing.Size(97, 48);
            this.rJ_Button_藥品資料_搜尋.State = false;
            this.rJ_Button_藥品資料_搜尋.TabIndex = 175;
            this.rJ_Button_藥品資料_搜尋.Text = "搜尋";
            this.rJ_Button_藥品資料_搜尋.TextColor = System.Drawing.Color.White;
            this.rJ_Button_藥品資料_搜尋.TextHeight = 0;
            this.rJ_Button_藥品資料_搜尋.UseVisualStyleBackColor = false;
            // 
            // sqL_DataGridView_藥品資料
            // 
            this.sqL_DataGridView_藥品資料.AutoSelectToDeep = false;
            this.sqL_DataGridView_藥品資料.backColor = System.Drawing.Color.Gainsboro;
            this.sqL_DataGridView_藥品資料.BorderColor = System.Drawing.Color.Transparent;
            this.sqL_DataGridView_藥品資料.BorderRadius = 0;
            this.sqL_DataGridView_藥品資料.BorderSize = 0;
            this.sqL_DataGridView_藥品資料.CellBorderColor = System.Drawing.Color.Gainsboro;
            this.sqL_DataGridView_藥品資料.cellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sqL_DataGridView_藥品資料.cellStylBackColor = System.Drawing.Color.LightBlue;
            this.sqL_DataGridView_藥品資料.cellStyleFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.sqL_DataGridView_藥品資料.cellStylForeColor = System.Drawing.Color.Black;
            this.sqL_DataGridView_藥品資料.checkedRowBackColor = System.Drawing.Color.YellowGreen;
            this.sqL_DataGridView_藥品資料.columnHeaderBackColor = System.Drawing.Color.DarkGray;
            this.sqL_DataGridView_藥品資料.columnHeaderBorderColor = System.Drawing.Color.DimGray;
            this.sqL_DataGridView_藥品資料.columnHeaderFont = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.sqL_DataGridView_藥品資料.columnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sqL_DataGridView_藥品資料.columnHeadersHeight = 40;
            this.sqL_DataGridView_藥品資料.columnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.sqL_DataGridView_藥品資料.DataGridViewAutoSizeColumnMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sqL_DataGridView_藥品資料.DataKeyEnable = false;
            this.sqL_DataGridView_藥品資料.Dock = System.Windows.Forms.DockStyle.Top;
            this.sqL_DataGridView_藥品資料.Font = new System.Drawing.Font("新細明體", 9F);
            this.sqL_DataGridView_藥品資料.ImageBox = false;
            this.sqL_DataGridView_藥品資料.Location = new System.Drawing.Point(25, 20);
            this.sqL_DataGridView_藥品資料.Margin = new System.Windows.Forms.Padding(4);
            this.sqL_DataGridView_藥品資料.Name = "sqL_DataGridView_藥品資料";
            this.sqL_DataGridView_藥品資料.OnlineState = SQLUI.SQL_DataGridView.OnlineEnum.Online;
            this.sqL_DataGridView_藥品資料.Password = "user82822040";
            this.sqL_DataGridView_藥品資料.Port = ((uint)(3306u));
            this.sqL_DataGridView_藥品資料.rowBorderStyleOption = SQLUI.SQL_DataGridView.RowBorderStyleOption.All;
            this.sqL_DataGridView_藥品資料.rowHeaderBackColor = System.Drawing.Color.Gray;
            this.sqL_DataGridView_藥品資料.rowHeaderBorderStyleOption = SQLUI.SQL_DataGridView.RowBorderStyleOption.All;
            this.sqL_DataGridView_藥品資料.rowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sqL_DataGridView_藥品資料.RowsColor = System.Drawing.SystemColors.Window;
            this.sqL_DataGridView_藥品資料.RowsHeight = 40;
            this.sqL_DataGridView_藥品資料.SaveFileName = "SQL_DataGridView";
            this.sqL_DataGridView_藥品資料.selectedBorderSize = 2;
            this.sqL_DataGridView_藥品資料.selectedRowBackColor = System.Drawing.Color.Blue;
            this.sqL_DataGridView_藥品資料.selectedRowBorderColor = System.Drawing.Color.Blue;
            this.sqL_DataGridView_藥品資料.selectedRowForeColor = System.Drawing.Color.White;
            this.sqL_DataGridView_藥品資料.Server = "127.0.0.0";
            this.sqL_DataGridView_藥品資料.Size = new System.Drawing.Size(682, 522);
            this.sqL_DataGridView_藥品資料.SSLMode = MySql.Data.MySqlClient.MySqlSslMode.None;
            this.sqL_DataGridView_藥品資料.TabIndex = 172;
            this.sqL_DataGridView_藥品資料.UserName = "root";
            this.sqL_DataGridView_藥品資料.可拖曳欄位寬度 = false;
            this.sqL_DataGridView_藥品資料.可選擇多列 = false;
            this.sqL_DataGridView_藥品資料.單格樣式 = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.sqL_DataGridView_藥品資料.自動換行 = true;
            this.sqL_DataGridView_藥品資料.表單字體 = new System.Drawing.Font("新細明體", 9F);
            this.sqL_DataGridView_藥品資料.邊框樣式 = System.Windows.Forms.BorderStyle.None;
            this.sqL_DataGridView_藥品資料.顯示CheckBox = false;
            this.sqL_DataGridView_藥品資料.顯示首列 = true;
            this.sqL_DataGridView_藥品資料.顯示首行 = true;
            this.sqL_DataGridView_藥品資料.首列樣式 = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sqL_DataGridView_藥品資料.首行樣式 = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            // 
            // rJ_TextBox_藥品資料_搜尋內容
            // 
            this.rJ_TextBox_藥品資料_搜尋內容.BackColor = System.Drawing.SystemColors.Window;
            this.rJ_TextBox_藥品資料_搜尋內容.BorderColor = System.Drawing.Color.Black;
            this.rJ_TextBox_藥品資料_搜尋內容.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rJ_TextBox_藥品資料_搜尋內容.BorderRadius = 0;
            this.rJ_TextBox_藥品資料_搜尋內容.BorderSize = 0;
            this.rJ_TextBox_藥品資料_搜尋內容.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rJ_TextBox_藥品資料_搜尋內容.ForeColor = System.Drawing.Color.DimGray;
            this.rJ_TextBox_藥品資料_搜尋內容.GUID = "";
            this.rJ_TextBox_藥品資料_搜尋內容.Location = new System.Drawing.Point(163, 569);
            this.rJ_TextBox_藥品資料_搜尋內容.Margin = new System.Windows.Forms.Padding(2);
            this.rJ_TextBox_藥品資料_搜尋內容.Multiline = false;
            this.rJ_TextBox_藥品資料_搜尋內容.Name = "rJ_TextBox_藥品資料_搜尋內容";
            this.rJ_TextBox_藥品資料_搜尋內容.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.rJ_TextBox_藥品資料_搜尋內容.PassWordChar = false;
            this.rJ_TextBox_藥品資料_搜尋內容.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rJ_TextBox_藥品資料_搜尋內容.PlaceholderText = "";
            this.rJ_TextBox_藥品資料_搜尋內容.ShowTouchPannel = false;
            this.rJ_TextBox_藥品資料_搜尋內容.Size = new System.Drawing.Size(225, 32);
            this.rJ_TextBox_藥品資料_搜尋內容.TabIndex = 173;
            this.rJ_TextBox_藥品資料_搜尋內容.TextAlgin = System.Windows.Forms.HorizontalAlignment.Left;
            this.rJ_TextBox_藥品資料_搜尋內容.Texts = "";
            this.rJ_TextBox_藥品資料_搜尋內容.UnderlineStyle = false;
            // 
            // comboBox_藥品資料_搜尋方式
            // 
            this.comboBox_藥品資料_搜尋方式.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_藥品資料_搜尋方式.FormattingEnabled = true;
            this.comboBox_藥品資料_搜尋方式.Items.AddRange(new object[] {
            "藥碼",
            "藥名",
            "全部顯示"});
            this.comboBox_藥品資料_搜尋方式.Location = new System.Drawing.Point(28, 570);
            this.comboBox_藥品資料_搜尋方式.Name = "comboBox_藥品資料_搜尋方式";
            this.comboBox_藥品資料_搜尋方式.Size = new System.Drawing.Size(121, 28);
            this.comboBox_藥品資料_搜尋方式.TabIndex = 172;
            // 
            // rJ_Button_藥品資料_填入
            // 
            this.rJ_Button_藥品資料_填入.AutoResetState = false;
            this.rJ_Button_藥品資料_填入.BackColor = System.Drawing.Color.White;
            this.rJ_Button_藥品資料_填入.BackgroundColor = System.Drawing.Color.DimGray;
            this.rJ_Button_藥品資料_填入.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJ_Button_藥品資料_填入.BorderRadius = 22;
            this.rJ_Button_藥品資料_填入.BorderSize = 0;
            this.rJ_Button_藥品資料_填入.buttonType = MyUI.RJ_Button.ButtonType.Push;
            this.rJ_Button_藥品資料_填入.DisenableColor = System.Drawing.Color.Gray;
            this.rJ_Button_藥品資料_填入.FlatAppearance.BorderSize = 0;
            this.rJ_Button_藥品資料_填入.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Button_藥品資料_填入.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.rJ_Button_藥品資料_填入.ForeColor = System.Drawing.Color.White;
            this.rJ_Button_藥品資料_填入.GUID = "";
            this.rJ_Button_藥品資料_填入.Image_padding = new System.Windows.Forms.Padding(0);
            this.rJ_Button_藥品資料_填入.Location = new System.Drawing.Point(607, 559);
            this.rJ_Button_藥品資料_填入.Name = "rJ_Button_藥品資料_填入";
            this.rJ_Button_藥品資料_填入.ProhibitionBorderLineWidth = 1;
            this.rJ_Button_藥品資料_填入.ProhibitionLineWidth = 4;
            this.rJ_Button_藥品資料_填入.ProhibitionSymbolSize = 30;
            this.rJ_Button_藥品資料_填入.ShadowColor = System.Drawing.Color.DimGray;
            this.rJ_Button_藥品資料_填入.ShadowSize = 0;
            this.rJ_Button_藥品資料_填入.ShowLoadingForm = false;
            this.rJ_Button_藥品資料_填入.Size = new System.Drawing.Size(97, 48);
            this.rJ_Button_藥品資料_填入.State = false;
            this.rJ_Button_藥品資料_填入.TabIndex = 176;
            this.rJ_Button_藥品資料_填入.Text = "填入";
            this.rJ_Button_藥品資料_填入.TextColor = System.Drawing.Color.White;
            this.rJ_Button_藥品資料_填入.TextHeight = 0;
            this.rJ_Button_藥品資料_填入.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.rJ_Button_儲存格式);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(3, 705);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(5);
            this.panel5.Size = new System.Drawing.Size(170, 103);
            this.panel5.TabIndex = 178;
            // 
            // rJ_Button_儲存格式
            // 
            this.rJ_Button_儲存格式.AutoResetState = false;
            this.rJ_Button_儲存格式.BackColor = System.Drawing.Color.Transparent;
            this.rJ_Button_儲存格式.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rJ_Button_儲存格式.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJ_Button_儲存格式.BorderRadius = 20;
            this.rJ_Button_儲存格式.BorderSize = 0;
            this.rJ_Button_儲存格式.buttonType = MyUI.RJ_Button.ButtonType.Push;
            this.rJ_Button_儲存格式.DisenableColor = System.Drawing.Color.Gray;
            this.rJ_Button_儲存格式.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rJ_Button_儲存格式.Enabled = false;
            this.rJ_Button_儲存格式.FlatAppearance.BorderSize = 0;
            this.rJ_Button_儲存格式.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Button_儲存格式.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJ_Button_儲存格式.ForeColor = System.Drawing.Color.White;
            this.rJ_Button_儲存格式.GUID = "";
            this.rJ_Button_儲存格式.Image_padding = new System.Windows.Forms.Padding(0);
            this.rJ_Button_儲存格式.Location = new System.Drawing.Point(5, 5);
            this.rJ_Button_儲存格式.Name = "rJ_Button_儲存格式";
            this.rJ_Button_儲存格式.ProhibitionBorderLineWidth = 1;
            this.rJ_Button_儲存格式.ProhibitionLineWidth = 4;
            this.rJ_Button_儲存格式.ProhibitionSymbolSize = 30;
            this.rJ_Button_儲存格式.ShadowColor = System.Drawing.Color.LightGray;
            this.rJ_Button_儲存格式.ShadowSize = 3;
            this.rJ_Button_儲存格式.ShowLoadingForm = false;
            this.rJ_Button_儲存格式.Size = new System.Drawing.Size(160, 93);
            this.rJ_Button_儲存格式.State = false;
            this.rJ_Button_儲存格式.TabIndex = 0;
            this.rJ_Button_儲存格式.Text = "儲存格式";
            this.rJ_Button_儲存格式.TextColor = System.Drawing.Color.White;
            this.rJ_Button_儲存格式.TextHeight = 0;
            this.rJ_Button_儲存格式.UseVisualStyleBackColor = false;
            // 
            // storagePanel
            // 
            this.storagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storagePanel.CurrentStorage = null;
            this.storagePanel.Location = new System.Drawing.Point(56, 63);
            this.storagePanel.Name = "storagePanel";
            this.storagePanel.Size = new System.Drawing.Size(696, 404);
            this.storagePanel.TabIndex = 2;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.rJ_Button_上傳);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(173, 705);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(5);
            this.panel6.Size = new System.Drawing.Size(170, 103);
            this.panel6.TabIndex = 179;
            // 
            // rJ_Button_上傳
            // 
            this.rJ_Button_上傳.AutoResetState = false;
            this.rJ_Button_上傳.BackColor = System.Drawing.Color.Transparent;
            this.rJ_Button_上傳.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rJ_Button_上傳.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rJ_Button_上傳.BorderRadius = 20;
            this.rJ_Button_上傳.BorderSize = 0;
            this.rJ_Button_上傳.buttonType = MyUI.RJ_Button.ButtonType.Push;
            this.rJ_Button_上傳.DisenableColor = System.Drawing.Color.Gray;
            this.rJ_Button_上傳.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rJ_Button_上傳.Enabled = false;
            this.rJ_Button_上傳.FlatAppearance.BorderSize = 0;
            this.rJ_Button_上傳.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rJ_Button_上傳.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJ_Button_上傳.ForeColor = System.Drawing.Color.White;
            this.rJ_Button_上傳.GUID = "";
            this.rJ_Button_上傳.Image_padding = new System.Windows.Forms.Padding(0);
            this.rJ_Button_上傳.Location = new System.Drawing.Point(5, 5);
            this.rJ_Button_上傳.Name = "rJ_Button_上傳";
            this.rJ_Button_上傳.ProhibitionBorderLineWidth = 1;
            this.rJ_Button_上傳.ProhibitionLineWidth = 4;
            this.rJ_Button_上傳.ProhibitionSymbolSize = 30;
            this.rJ_Button_上傳.ShadowColor = System.Drawing.Color.LightGray;
            this.rJ_Button_上傳.ShadowSize = 3;
            this.rJ_Button_上傳.ShowLoadingForm = false;
            this.rJ_Button_上傳.Size = new System.Drawing.Size(160, 93);
            this.rJ_Button_上傳.State = false;
            this.rJ_Button_上傳.TabIndex = 0;
            this.rJ_Button_上傳.Text = "上傳";
            this.rJ_Button_上傳.TextColor = System.Drawing.Color.White;
            this.rJ_Button_上傳.TextHeight = 0;
            this.rJ_Button_上傳.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1584, 811);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EchoTag 更新程式";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.rJ_Pannel_面板調整.ResumeLayout(false);
            this.rJ_Pannel_藥品搜尋.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel18;
        private MyUI.RJ_Button rJ_Button_步驟1_確認;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel2;
        private MyUI.RJ_ComboBox rJ_ComboBox_面板種類;
        private MyUI.RJ_Lable rJ_Lable2;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel1;
        private MyUI.RJ_TextBox rJ_TextBox_裝置IP;
        private MyUI.RJ_Lable rJ_Lable1;
        private System.Windows.Forms.Panel panel4;
        private MyUI.RJ_Pannel rJ_Pannel_藥品搜尋;
        private MyUI.RJ_Button rJ_Button_藥品資料_搜尋;
        private SQLUI.SQL_DataGridView sqL_DataGridView_藥品資料;
        private MyUI.RJ_TextBox rJ_TextBox_藥品資料_搜尋內容;
        private System.Windows.Forms.ComboBox comboBox_藥品資料_搜尋方式;
        private MyUI.RJ_Pannel rJ_Pannel_面板調整;
        private MyUI.RJ_Button rJ_Button_藥品資料_填入;
        private H_Pannel_lib.StoragePanel storagePanel;
        private System.Windows.Forms.Panel panel5;
        private MyUI.RJ_Button rJ_Button_儲存格式;
        private System.Windows.Forms.Panel panel6;
        private MyUI.RJ_Button rJ_Button_上傳;
    }
}

