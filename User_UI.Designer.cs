namespace 黑白棋
{
    partial class learntimetxt
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(learntimetxt));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupbox0 = new System.Windows.Forms.GroupBox();
            this.learntimestxt = new System.Windows.Forms.TextBox();
            this.numtxt = new System.Windows.Forms.TextBox();
            this.learningdatatxt = new System.Windows.Forms.TextBox();
            this.hidcounttxt = new System.Windows.Forms.TextBox();
            this.hidlongtxt = new System.Windows.Forms.TextBox();
            this.alphatxt = new System.Windows.Forms.TextBox();
            this.etatxt = new System.Windows.Forms.TextBox();
            this.outputlearningtxt = new System.Windows.Forms.TextBox();
            this.inputlearningtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupbox0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.imageBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 522);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image of the checkerboard";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(20, 58);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(549, 450);
            this.imageBox1.TabIndex = 5;
            this.imageBox1.TabStop = false;
            this.imageBox1.Click += new System.EventHandler(this.imageBox1_Click);
            this.imageBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseClick);
            this.imageBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseDoubleClick);
            this.imageBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(134, 173);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(187, 36);
            this.button8.TabIndex = 3;
            this.button8.Text = "你拍ㄉ不夠好";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(627, 385);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "閥值";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(223, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "明度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(5, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "彩度";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(211, 60);
            this.trackBar2.Maximum = 255;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(199, 45);
            this.trackBar2.TabIndex = 0;
            this.trackBar2.Tag = "a";
            this.trackBar2.Value = 120;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(0, 60);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(214, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Tag = "a";
            this.trackBar1.Value = 20;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.Location = new System.Drawing.Point(1054, 456);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(187, 41);
            this.button14.TabIndex = 0;
            this.button14.Tag = "a";
            this.button14.Text = "Auto Adjustment";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(1137, 79);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(135, 45);
            this.button13.TabIndex = 6;
            this.button13.Text = "Connection";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.comboBox2.Location = new System.Drawing.Point(979, 86);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(114, 33);
            this.comboBox2.TabIndex = 5;
            this.comboBox2.Text = "COM9";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button12);
            this.groupBox3.Location = new System.Drawing.Point(1103, 583);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 153);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "功能鍵";
            this.groupBox3.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button4);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Controls.Add(this.button5);
            this.groupBox4.Location = new System.Drawing.Point(199, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 127);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "微調鍵";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(69, 73);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(63, 46);
            this.button6.TabIndex = 0;
            this.button6.Tag = "a";
            this.button6.Text = "Down";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(0, 21);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(63, 46);
            this.button10.TabIndex = 0;
            this.button10.Tag = "a";
            this.button10.Text = "TLeft";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(63, 46);
            this.button4.TabIndex = 0;
            this.button4.Tag = "a";
            this.button4.Text = "Left";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(69, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 46);
            this.button3.TabIndex = 0;
            this.button3.Tag = "a";
            this.button3.Text = "Up";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(138, 21);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(63, 46);
            this.button9.TabIndex = 0;
            this.button9.Tag = "a";
            this.button9.Text = "TRight";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(138, 73);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(63, 46);
            this.button5.TabIndex = 0;
            this.button5.Tag = "a";
            this.button5.Text = "Right";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(187, 46);
            this.button7.TabIndex = 0;
            this.button7.Tag = "a";
            this.button7.Text = "確立定位";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 46);
            this.button2.TabIndex = 0;
            this.button2.Tag = "a";
            this.button2.Text = "矩形定位";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(24, 90);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(238, 270);
            this.button12.TabIndex = 3;
            this.button12.Text = "自動機械學習";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(627, 55);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(337, 324);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Image process result";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(6, 39);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(309, 275);
            this.textBox1.TabIndex = 0;
            this.textBox1.Tag = "a";
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(627, 509);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(189, 54);
            this.button11.TabIndex = 4;
            this.button11.Tag = "a";
            this.button11.Text = "Play";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(979, 283);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(188, 42);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "Tree_Four";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(6, 21);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 29);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Georgia", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(979, 175);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(129, 42);
            this.comboBox3.TabIndex = 7;
            this.comboBox3.Text = "Black";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(124, 21);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(173, 29);
            this.textBox3.TabIndex = 8;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupbox0
            // 
            this.groupbox0.Controls.Add(this.learntimestxt);
            this.groupbox0.Controls.Add(this.numtxt);
            this.groupbox0.Controls.Add(this.learningdatatxt);
            this.groupbox0.Controls.Add(this.hidcounttxt);
            this.groupbox0.Controls.Add(this.hidlongtxt);
            this.groupbox0.Controls.Add(this.alphatxt);
            this.groupbox0.Controls.Add(this.etatxt);
            this.groupbox0.Controls.Add(this.outputlearningtxt);
            this.groupbox0.Controls.Add(this.inputlearningtxt);
            this.groupbox0.Controls.Add(this.textBox2);
            this.groupbox0.Controls.Add(this.textBox3);
            this.groupbox0.Location = new System.Drawing.Point(12, 583);
            this.groupbox0.Name = "groupbox0";
            this.groupbox0.Size = new System.Drawing.Size(597, 97);
            this.groupbox0.TabIndex = 6;
            this.groupbox0.TabStop = false;
            this.groupbox0.Text = "偵錯用";
            this.groupbox0.Enter += new System.EventHandler(this.groupBox6_Enter);
            // 
            // learntimestxt
            // 
            this.learntimestxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learntimestxt.Location = new System.Drawing.Point(6, 56);
            this.learntimestxt.Name = "learntimestxt";
            this.learntimestxt.Size = new System.Drawing.Size(61, 29);
            this.learntimestxt.TabIndex = 11;
            // 
            // numtxt
            // 
            this.numtxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numtxt.Location = new System.Drawing.Point(292, 56);
            this.numtxt.Name = "numtxt";
            this.numtxt.Size = new System.Drawing.Size(73, 29);
            this.numtxt.TabIndex = 10;
            // 
            // learningdatatxt
            // 
            this.learningdatatxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.learningdatatxt.Location = new System.Drawing.Point(303, 21);
            this.learningdatatxt.Name = "learningdatatxt";
            this.learningdatatxt.Size = new System.Drawing.Size(138, 29);
            this.learningdatatxt.TabIndex = 9;
            // 
            // hidcounttxt
            // 
            this.hidcounttxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hidcounttxt.Location = new System.Drawing.Point(240, 56);
            this.hidcounttxt.Name = "hidcounttxt";
            this.hidcounttxt.Size = new System.Drawing.Size(46, 29);
            this.hidcounttxt.TabIndex = 6;
            this.hidcounttxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.hidcounttxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // hidlongtxt
            // 
            this.hidlongtxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hidlongtxt.Location = new System.Drawing.Point(192, 56);
            this.hidlongtxt.Name = "hidlongtxt";
            this.hidlongtxt.Size = new System.Drawing.Size(42, 29);
            this.hidlongtxt.TabIndex = 6;
            this.hidlongtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.hidlongtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // alphatxt
            // 
            this.alphatxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alphatxt.Location = new System.Drawing.Point(134, 56);
            this.alphatxt.Name = "alphatxt";
            this.alphatxt.Size = new System.Drawing.Size(52, 29);
            this.alphatxt.TabIndex = 6;
            this.alphatxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.alphatxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // etatxt
            // 
            this.etatxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etatxt.Location = new System.Drawing.Point(73, 56);
            this.etatxt.Name = "etatxt";
            this.etatxt.Size = new System.Drawing.Size(55, 29);
            this.etatxt.TabIndex = 6;
            this.etatxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.etatxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // outputlearningtxt
            // 
            this.outputlearningtxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputlearningtxt.Location = new System.Drawing.Point(447, 21);
            this.outputlearningtxt.Name = "outputlearningtxt";
            this.outputlearningtxt.Size = new System.Drawing.Size(134, 29);
            this.outputlearningtxt.TabIndex = 6;
            this.outputlearningtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.outputlearningtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // inputlearningtxt
            // 
            this.inputlearningtxt.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputlearningtxt.Location = new System.Drawing.Point(371, 56);
            this.inputlearningtxt.Name = "inputlearningtxt";
            this.inputlearningtxt.Size = new System.Drawing.Size(210, 29);
            this.inputlearningtxt.TabIndex = 6;
            this.inputlearningtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.inputlearningtxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(975, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "Your chess color";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(561, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 21);
            this.label4.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(975, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Artificial Intelligence";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1024, 503);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(825, 509);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(185, 54);
            this.button15.TabIndex = 11;
            this.button15.Tag = "a";
            this.button15.Text = "Restart";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button16.Location = new System.Drawing.Point(825, 569);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(185, 52);
            this.button16.TabIndex = 4;
            this.button16.Tag = "a";
            this.button16.Text = "Output Data";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.Location = new System.Drawing.Point(627, 569);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(189, 52);
            this.button17.TabIndex = 12;
            this.button17.Tag = "a";
            this.button17.Text = "Learn";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox1.Location = new System.Drawing.Point(979, 348);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(329, 25);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Use Fully Connected Neural Network";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(825, 627);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(185, 54);
            this.button18.TabIndex = 0;
            this.button18.Tag = "a";
            this.button18.Text = "Delete Data";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button19.Location = new System.Drawing.Point(1054, 401);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(187, 40);
            this.button19.TabIndex = 13;
            this.button19.Tag = "a";
            this.button19.Text = "Insert Memory";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button20
            // 
            this.button20.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button20.Location = new System.Drawing.Point(627, 629);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(189, 52);
            this.button20.TabIndex = 4;
            this.button20.Tag = "a";
            this.button20.Text = "Output Memory";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.button20_Click);
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.Location = new System.Drawing.Point(1137, 151);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(135, 50);
            this.button21.TabIndex = 6;
            this.button21.Text = "Caregiver Interface";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // learntimetxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 692);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupbox0);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "learntimetxt";
            this.Text = "黑白棋對弈系統 - MBLPJ ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DoubleClick += new System.EventHandler(this.User_UI_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_UI_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupbox0.ResumeLayout(false);
            this.groupbox0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button12;
        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Timer timer1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.GroupBox groupbox0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.TextBox inputlearningtxt;
        private System.Windows.Forms.TextBox hidcounttxt;
        private System.Windows.Forms.TextBox hidlongtxt;
        private System.Windows.Forms.TextBox alphatxt;
        private System.Windows.Forms.TextBox etatxt;
        private System.Windows.Forms.TextBox numtxt;
        private System.Windows.Forms.TextBox learningdatatxt;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.TextBox outputlearningtxt;
        private System.Windows.Forms.TextBox learntimestxt;
        private System.Windows.Forms.Button button21;
    }
}

