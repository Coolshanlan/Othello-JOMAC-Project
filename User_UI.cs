using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Threading;
using Microsoft.VisualBasic; 


namespace 黑白棋
{
    public partial class learntimetxt : Form
    {
        public class Mmse_Status
        {

            public Mmse_Status()
            {
                Judgment_Error_Count = 0;
                Orientation_input_date = "";
                Memory_input_thing = "";
                Abstract_time = 0;
                Abstract_timeTick = false;
                Calculus_SuccessCount = 0;
            }

           public int Judgment_Error_Count
            {
                get;
                set;
            }
            public string Orientation_input_date
            {
                get;
                set;
            }
            public bool Orientation_check_suc
            {
                get;
                set;
            }
            //public
            public string Memory_input_thing
            {
                get;
                set;
            }
            public int Abstract_time
            {
                get;
                set;
            }
            public bool Abstract_timeTick
            {
                get;
                set;
            }
            public int Calculus_SuccessCount
            {
                get;
                set;
            }

            //總計遊玩時間的計數器
            public void A_time_Start()
            {
                if (!Abstract_timeTick)
                {
                    Abstract_timeTick = true;
                    Task.Run(() =>
                    {
                        while (Abstract_timeTick)
                        {
                            Abstract_time++;
                            Thread.Sleep(1000);
                        }
                    });
                }
            }
            public void A_time_Stop()
            {
                Abstract_timeTick = false;
            }
            public void A_time_Reset()
            {
                if(!Abstract_timeTick)
                Abstract_time = 0;
            }

            public void O_LetInput()
            {
                string input = "";
                while (true)
                {
                input =    Interaction.InputBox("請輸入今天的年月日?(西元年/月/日)");
                    if (Interaction.InputBox("確定以輸入好了?(輸入Y)") == "Y")
                        break;  
                }
                Orientation_input_date = input;
            }

        }

        public learntimetxt()
        {
            InitializeComponent();
        }
        int[] bx = new int[4];
        int[] by = new int[4];
        int[,] check_point_x = new int[8, 8];
        int[,] check_point_y = new int[8, 8];
        int[,] res = new int[8, 8];

        int d_click_count = 0;
        string t_type = "";
        public static SerialPort sp_d = new SerialPort();
        string link_ip = "http://192.168.43.1:8080/shot.jpg";
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Text = "ㄏㄏ";
        }
        Image<Bgr, byte> inp;
        public static double[,] ttx = new double[8, 8];
        double[] bbx = new double[4];
        double[] bby = new double[4];
        public static double[,] real_point_x = new double[8, 8];
        public static double[,] real_point_y = new double[8, 8];
        public static double[] ccy = new double[] { 0.7, 0.63, 0.6, 0.53, 0.55, 0.53, 1, 1 };
        public static double[] aay = new double[] { 4.3, 4.8, 4.8, 4.8, 4.8, 4.8, 5.0, 5.0 };
        string Date = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Date = System.DateTime.Now.Month + Convert.ToInt32(System.DateTime.Now.Day).ToString("00");
            //inputlearningtxt.Text = Date+"_Learn.txt";
            inputlearningtxt.Text =  "Othello_Learn_good.txt";
            // MessageBox.Show(axWindowsMediaPlayer1.settings.getMode("loop").ToString());
            axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            axWindowsMediaPlayer1.CreateControl();
            //axWindowsMediaPlayer1.settings.setMode("loop", true);
            //axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 15;
            //axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 40;
            //link_ip = Interaction.InputBox("請輸入IP");
            //sp_d.PortName = comboBox2.Text;
            pictureBox1.Image = Properties.Resources.logo_png;
            textBox3.Text = link_ip;
            groupbox0.Hide();

            foreach (Control cc in groupBox4.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = false;
                }
            }
            foreach (Control cc in this.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = false;
                }
            }
            foreach (Control cc in groupBox3.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = false;
                }
            }
            foreach (Control cc in groupBox2.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = false;
                }
            }
            foreach (Control cc in groupBox5.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = false;
                }
            }
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        if (ToDownChess.change == true)
            //        {
            //            while (!button11.Enabled)
            //            {
            //                Thread.Sleep(10);
            //            }
            //                //while (!button11.Enabled)
            //                //{
            //                //    Thread.Sleep(10);
            //                //}
            //                //ToDownChess.change = false;
            //            button8.PerformClick();
            //        }
            //        Thread.Sleep(10);
            //    }

            //});
            comboBox1.Items.Add("CountChess");
            comboBox1.Items.Add("Integral");
            comboBox1.Items.Add("Tree_One");
            comboBox1.Items.Add("Tree_Two");
            comboBox1.Items.Add("Tree_Three");
            comboBox1.Items.Add("Tree_Four");
            //   comboBox1.Items.Add("UCT_Linked List");
            //comboBox1.Items.Add("Tree_Five");
            //comboBox1.Items.Add("UCT");
            //comboBox1.Items.Add("UCT_Linked List");
            comboBox3.Items.Add("Black");
            comboBox3.Items.Add("White");
            //sp_d.BaudRate = 115200;
            //sp_d.Open();
            CheckForIllegalCrossThreadCalls = false;
            //Thread th = new Thread(capch);
            //th.IsBackground = true;
            //th.Start();
            bbx[0] = 7; bby[0] = 23.5;
            bbx[1] = 6.6; bby[1] = 7.4;
            bbx[2] = -8.5; bby[2] = 23.5;
            bbx[3] = -7.3; bby[3] = 7.5;
            for (int j = 0; j < 8; j++)
            {
                real_point_x[0, j] = bbx[0] + ((bbx[1] - bbx[0]) / 7.0 * j);
                real_point_y[0, j] = bby[0] + ((bby[1] - bby[0]) / 7.0 * j);
                real_point_x[7, j] = bbx[2] + ((bbx[3] - bbx[2]) / 7.0 * j);
                real_point_y[7, j] = bby[2] + ((bby[3] - bby[2]) / 7.0 * j);
                real_point_x[j, 0] = bbx[0] + ((bbx[2] - bbx[0]) / 7.0 * j);
                real_point_y[j, 0] = bby[0] + ((bby[2] - bby[0]) / 7.0 * j);
                real_point_x[j, 7] = bbx[1] + ((bbx[3] - bbx[1]) / 7.0 * j);
                real_point_y[j, 7] = bby[1] + ((bby[3] - bby[1]) / 7.0 * j);
            }
            double[,] res_point_x = new double[8, 8];
            double[,] res_point_y = new double[8, 8];
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    //check_point_x[j, i] = (bx[0] + (bx[1] - bx[0]) / 7 * i) + ((bx[3]+(bx[3] - bx[2]) / 7 * i) - (bx[0] + (bx[1] - bx[0]) / 7 * i)) / 7 * j;
                    //check_point_y[j, i] = (by[0]+(by[2]-by[0])/7*j)+((by[3]+(by[3]-by[1])/7*j)- (by[0] + (by[2] - by[0]) / 7 * j))/7*i;
                    res_point_x[j, i] = real_point_y[j, 0] + (real_point_y[j, 7] - real_point_y[j, 0]) / 7 * i - 0.8;
                    res_point_y[i, j] = real_point_x[j, 0] + (real_point_x[j, 7] - real_point_x[j, 0]) / 7 * i + 0.3;
                    // res_point_y[i, j] -= i != 0 && j != 0 ? 2.44 : 0;
                }
            }
            real_point_x = res_point_y;
            real_point_y = res_point_x;
            // real_point_x[7, 0] = 1.8;
            // real_point_x[7, 1] = 1.1;
            // real_point_x[7, 2] = 0.5;
            // real_point_x[7, 3] = 0.1;
            // real_point_x[7, 4] = -0.1;
            // real_point_x[7, 5] = -0.4;
            // real_point_x[7, 6] = -1;
            // real_point_x[7, 7] = -1.8;
            // real_point_y[0, 7] = 4.2;
            // real_point_y[1, 7] = 3.3;
            // real_point_y[2, 7] = 2.2;
            // real_point_y[3, 7] = 1.4;
            // real_point_y[4, 7] = 1.5;
            // real_point_y[5, 7] = 1.7;
            // real_point_y[6, 7] = 2.9;
            // real_point_y[7, 7] = 3.9;

            // double[] aax = new double[] { 0.9,0.9,0.8,0.75,0.75,0.8,0.9,1};
            // double[] ccx = new double[] { 0, 0, 0, 0, 0, 0, 0, 0 };

            // double[,] ddx = new double[8,8];

            // //double[] ccx =
            // //double[] ccx = {};
            // for (int i = 0; i < 8; i++)
            // {
            //     ttx[i, 0] = real_point_x[i, 0];
            //     ttx[i, 7] = real_point_x[i, 7]+1.2;
            //     ttx[0, i] = real_point_x[0, i]-1.2;
            //     ttx[7, i] = real_point_x[7, i];
            // }
            // ttx[0, 0] = 3.7;
            // ttx[0, 1] = 2.5;
            // ttx[0, 2] = 1.3000000000000003;
            // ttx[0, 3] = 0.30000000000000053;
            // ttx[0, 4] = -0.79999999999999964;
            // ttx[0, 5] = -1.5599999999999998;
            // ttx[0, 6] = -2.7499999999999991;
            // ttx[0, 7] = -3.7;
            // ttx[1, 0] = 3.4714285714285715;
            // ttx[1, 1] = 2.5714285714285716;
            // ttx[1, 2] = 1.3685714285714287;
            // ttx[1, 3] = 0.56571428571428617;
            // ttx[1, 4] = -0.43714285714285683;
            // ttx[1, 5] = -1.44;
            // ttx[1, 6] = -2.6428571428571422;
            // ttx[1, 7] = -3.728571428571429;
            //  ttx[2, 0] = 3.3428571428571429;
            // ttx[2, 1] = 2.3714285714285716;
            // ttx[2, 2] = 1.3685714285714287;
            // ttx[2, 3] = 0.36571428571428617;
            // ttx[2, 4] = -0.43714285714285683;
            // ttx[2, 5] = -1.44;
            // ttx[2, 6] = -2.4428571428571422;
            //ttx[2, 7] = -3.4571428571428573;
            // ttx[3, 0] = 3.0142857142857142;
            // ttx[3, 1] = 2.0714285714285716;
            // ttx[3, 2] = 1.1685714285714287;
            // ttx[3, 3] = 0.36571428571428617;
            // ttx[3, 4] = -0.43714285714285683;
            // ttx[3, 5] = -1.24;
            // ttx[3, 6] = -2.2428571428571422;
            // ttx[3, 7] = -3.2857142857142859;
            // ttx[4, 0] = 2.7857142857142856;
            // ttx[4, 1] = 1.8714285714285716;
            // ttx[4, 2] = 1.0685714285714287;
            // ttx[4, 3] = 0.26571428571428617;
            // ttx[4, 4] = -0.43714285714285683;
            // ttx[4, 5] = -1.14;
            // ttx[4, 6] = -1.8928571428571422;
            // ttx[4, 7] = -2.8142857142857144;
            // ttx[5, 0] = 2.4571428571428569;
            // ttx[5, 1] = 1.6714285714285716;
            // ttx[5, 2] = 1.0685714285714287;
            // ttx[5, 3] = 0.256571428571428617;
            // ttx[5, 4] = -0.43714285714285683;
            // ttx[5, 5] = -1.04;
            // ttx[5, 6] = -1.7428571428571422;
            // ttx[5, 7] = -2.342857142857143;
            // ttx[6, 0] = 2.3285714285714287;
            // ttx[6, 1] = 1.5714285714285716;
            // ttx[6, 2] = 0.825714285714287;
            // ttx[6, 3] = 0.16571428571428617;
            // ttx[6, 4] = -0.20714285714285683;
            // ttx[6, 5] = -0.74;
            // ttx[6, 6] = -1.2428571428571422;
            // ttx[6, 7] = -2.0714285714285715;
            // ttx[7, 0] = 2.6;
            // ttx[7, 1] = 2.0;
            // ttx[7, 2] = 1.4000000000000001;
            // ttx[7, 3] = 0.80000000000000027;
            // ttx[7, 4] = 0.20000000000000018;
            // ttx[7, 5] = -0.39999999999999991;
            // ttx[7, 6] = -0.99999999999999956;
            //// ttx[7, 7] = -1.6;
            // sp_d.Open();
            // for (int j = 0; j < 8; j++)
            // {
            //     for (int i = 0; i < 8; i++)
            //     {
            //         string st = "x" + (double)(real_point_x[j, i]) + ";y" + (double)(real_point_y[i, j]) + ";z3;k;";
            //         sp_d.Write(st);
            //         Thread.Sleep(1500);
            //         st = "x" + (double)(real_point_x[j, i]) + ";y" + (double)(real_point_y[i, j]) + ";z" + ((j == 7) ? -2.5 : (j == 0) ? -3 : -2).ToString() + ";k;";
            //         sp_d.Write(st);
            //         Thread.Sleep(1500);
            //         sp_d.Write("g80;");
            //         Thread.Sleep(1500);
            //         st = "x" + (double)(real_point_x[j, i]) + ";y" + (double)(real_point_y[i, j]) + ";z3;k;";
            //         sp_d.Write(st);
            //         Thread.Sleep(1500);
            //         st = "x" + (double)(real_point_x[j, i]) + ";y" + (double)(real_point_y[i, j]) + ";z" + ((j == 7) ? -2.5 : (j == 0) ? -3 : -2).ToString() + ";k;";
            //         sp_d.Write(st);
            //         Thread.Sleep(1500);
            //         sp_d.Write("g125;");
            //         Thread.Sleep(1500);
            //         st = "x" + (double)(real_point_x[j, i]) + ";y" + (double)(real_point_y[i, j]) + ";z3;k;";
            //         sp_d.Write(st);
            //         Thread.Sleep(1500);
            //         sp_d.Write("0;");
            //         Thread.Sleep(1500);
            //     }
            // }
            // //int write_type = 1;
            // //for (int i = 4; i < 8; i++)
            // //{
            // //    for (int j = 0; j < 8; j++)
            // //    {
            //        Thread.Sleep(100);
            //        string sp_dd = "";
            //        if (j != 7 && i !=7 )
            //            if (write_type == 1)
            //            {
            //                write_type = 2;
            //                sp_dd = "x" + User_UI.ttx[i, j] + ";y" + (double)(User_UI.real_point_y[j, i] + Math.Abs(User_UI.real_point_x[i, j]) * User_UI.ccy[i] - User_UI.aay[i]) + ";p;";
            //            }
            //            else
            //                sp_dd = "x" + User_UI.ttx[i, j] + ";y" + (double)(User_UI.real_point_y[j, i] + Math.Abs(User_UI.real_point_x[i, j]) * User_UI.ccy[i] - User_UI.aay[i]) + ";c;";
            //        else if (i == 7)
            //            if (write_type == 1)
            //            {
            //                write_type = 2;
            //                sp_dd = "x" + User_UI.real_point_x[i, j] + ";y" + (double)(User_UI.real_point_y[j, i]) + ";p;";
            //            }
            //            else
            //                sp_dd = "x" + User_UI.real_point_x[i, j] + ";y" + (double)(User_UI.real_point_y[j, i]) + ";c;";
            //        else
            //            if (write_type == 1)
            //            {
            //                write_type = 2;
            //                sp_dd = "x" + User_UI.real_point_x[i, j] + ";y" + (double)(User_UI.real_point_y[j, i] + Math.Abs(User_UI.real_point_x[i, j]) * User_UI.ccy[i] - User_UI.aay[i]) + ";p;";
            //            }
            //            else
            //                sp_dd = "x" + User_UI.real_point_x[i, j] + ";y" + (double)(User_UI.real_point_y[j, i] + Math.Abs(User_UI.real_point_x[i, j]) * User_UI.ccy[i] - User_UI.aay[i]) + ";c;";
            //        User_UI.sp_d.WriteLine(sp_dd);
            //    }
            //}
            //User_UI.sp_d.WriteLine("l;");
            //User_UI.sp_d.Close();
            //System.Net.WebClient WC = new System.Net.WebClient();
            //WC.Credentials = new NetworkCredential("admin", "password");
            //System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData("http://"+link_ip+"/shot.jpg"));
            //Image img = Image.FromStream(Ms);
            ////Image img = Image.FromFile(Path.GetFullPath("4.PNG"));
            //inp = new Image<Bgr, byte>((Bitmap)img);
            //double a = ((double)imageBox1.Width / (double)inp.Width);
            //inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            ////white_balence();
            //white_balence();
            //imageBox1.Image = inp;
            NN_valuetxt_update();
            learningdatatxt.Text = Date + ".txt" ;
            outputlearningtxt.Text = Date + "_Learn.txt";
        }
        List<int> x_res = new List<int>();
        List<int> y_res = new List<int>();
        private void button2_Click(object sender, EventArgs e)
        {
            Image<Bgr, byte> res = new Image<Bgr, byte>(inp.Bitmap);
            imageBox1.Image = res;
            res.Erode(2);
            res.ROI = new Rectangle(new Point(120, 0), new Size(roi_p[1].X - roi_p[0].X, roi_p[1].Y - roi_p[0].Y));
            int min_Threshold = 0;
            int max_Threshold = 255;
            int line_count;
            int morning_time = 0;
            int res_Threshold = 256;
            while (true)
            {
                if (res_Threshold < 0)
                {
                    res_Threshold = 255;
                    ex_captch();
                }
                res_Threshold--;
                // imageBox1.Image = res.Clone();
                x_res = new List<int>();
                y_res = new List<int>();
                res = new Image<Bgr, byte>(inp.Bitmap);
                res.Erode(2);
                res.ROI = new Rectangle(roi_p[0], new Size(roi_p[1].X - roi_p[0].X, roi_p[1].Y - roi_p[0].Y));

                LineSegment2D[][] res_line = res.HoughLines(
     res_Threshold,  //Canny algorithm low threshold
     250,  //Canny algorithm high threshold
     1,              //rho parameter
     Math.PI / 180.0,  //theta parameter 
     50,            //threshold
    120,             //min length for a line
    200         //max allowed gap along the line
 );
                List<int> x = new List<int>(), y = new List<int>();
                List<double> line_lon = new List<double>();
                line_count = res_line[0].Length;
                try
                {
                    foreach (var line in res_line[0])
                    {
                        int[] px = { line.P1.X, line.P2.X };
                        int[] py = { line.P1.Y, line.P2.Y };
                        foreach (var gx in px)
                        {
                            x.Add(gx);
                        }
                        foreach (var gy in py)
                        {
                            y.Add(gy);

                        }
                        line_lon.Add(line.Length);
                        res.Draw(line, new Bgr(0, 0, 0), 1);
                    }
                    line_lon.Sort();
                    x.Sort();
                    y.Sort();
                    int x_count = 0;
                    int y_count = 0;
                    for (int i = 1; i < x.Count; i++)
                        if (x[i] - x[i - 1] < 100)
                            x_res.Add(x[i - 1]);
                        else
                        {
                            for (int j = 1; j < x_res.Count; j++)
                                x_res[x_count] += x_res[j];
                            x_res[x_count] /= x_res.Count;
                            x_count++;
                            x_res.RemoveRange(x_count, x_res.Count - x_count);

                        }
                    for (int j = 1; j < x_res.Count; j++)
                        x_res[x_count] += x_res[j];
                    x_res[x_count] /= x_res.Count;
                    x_count++;
                    x_res.RemoveRange(x_count, x_res.Count - x_count);
                    for (int i = 1; i < y.Count; i++)
                        if (y[i] - y[i - 1] < 100)
                            y_res.Add(y[i - 1]);
                        else
                        {
                            for (int j = 1; j < y_res.Count; j++)
                                y_res[y_count] += y_res[j];
                            y_res[y_count] /= y_res.Count;
                            y_count++;
                            y_res.RemoveRange(y_count, y_res.Count - y_count);

                        }
                    for (int j = 1; j < y_res.Count; j++)
                        y_res[y_count] += y_res[j];
                    y_res[y_count] /= y_res.Count;
                    y_count++;
                    y_res.RemoveRange(y_count, y_res.Count - y_count);
                    if (Math.Abs((x_res[1] - x_res[0]) - (y_res[1] - y_res[0])) < 20 && (x_res[1] - x_res[0]) > 120)
                    {
                        res.Draw(new Rectangle(x_res[0], y_res[0], x_res[1] - x_res[0], y_res[1] - y_res[0]), new Bgr(100, 100, 200), 3);
                        break;
                    }
                    if (line_count > 50)
                        min_Threshold = res_Threshold;
                    else
                        max_Threshold = res_Threshold;
                    morning_time++;
                }
                catch
                {
                    if (line_count > 30)
                        min_Threshold = res_Threshold;
                    else
                        max_Threshold = res_Threshold;
                    morning_time++;
                    if (morning_time > 200 || min_Threshold == max_Threshold)
                    {
                        morning_time = 0;
                        min_Threshold = 0;
                        max_Threshold = 255;
                    }
                }
                line_lon.Clear();
                x.Clear();
                y.Clear();

                x_res.Clear();
                y_res.Clear();
                res.Dispose();
                GC.Collect();
            }
            res.ROI = new Rectangle(new Point(0, 0), inp.Size);
            imageBox1.Image = res.Clone();
            res.Dispose();
            GC.Collect();
            Thread.Sleep(10);

        }
        Point[] roi_p = new Point[2];
        int roi_c = 0;
        private void imageBox1_MouseClick(object sender, MouseEventArgs e)
        {
            roi_p[roi_c] = e.Location;
            roi_c++;
            roi_c = (roi_c == 2) ? 0 : 1;

        }

        void res_4point_draw()
        {
            for (int j = 0; j < 8; j++)
            {
                check_point_x[0, j] = Convert.ToInt16(bx[0] + ((bx[1] - bx[0]) / 7 * j));
                check_point_y[0, j] = Convert.ToInt16(by[0] + ((by[1] - by[0]) / 7 * j));
                check_point_x[7, j] = Convert.ToInt16(bx[2] + ((bx[3] - bx[2]) / 7 * j));
                check_point_y[7, j] = Convert.ToInt16(by[2] + ((by[3] - by[2]) / 7 * j));
                check_point_x[j, 0] = Convert.ToInt16(bx[0] + ((bx[2] - bx[0]) / 7 * j));
                check_point_y[j, 0] = Convert.ToInt16(by[0] + (by[2] - by[0]) / 7 * j);
                check_point_x[j, 7] = Convert.ToInt16((bx[1]) + ((bx[3] - bx[1]) / 7 * j));
                check_point_y[j, 7] = Convert.ToInt16(by[1] + (by[3] - by[1]) / 7 * j);
            }
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {

                    //check_point_x[j, i] = (bx[0] + (bx[1] - bx[0]) / 7 * i) + ((bx[3]+(bx[3] - bx[2]) / 7 * i) - (bx[0] + (bx[1] - bx[0]) / 7 * i)) / 7 * j;
                    // check_point_y[j, i] = (by[0]+(by[2]-by[0])/7*j)+((by[3]+(by[3]-by[1])/7*j)- (by[0] + (by[2] - by[0]) / 7 * j))/7*i;
                    check_point_y[j, i] = check_point_y[j, 0] + (check_point_y[j, 7] - check_point_y[j, 0]) / 7 * i;
                    check_point_x[j, i] = check_point_x[j, 0] + (check_point_x[j, 7] - check_point_x[j, 0]) / 7 * i;
                }
            }
            Image<Bgr, byte> res = new Image<Bgr, byte>(imageBox1.Image.Bitmap);
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Point p = new Point(check_point_x[i, j], check_point_y[i, j]);
                    res.Draw(new CircleF(p, 5), new Bgr(0, 0, 255), 1);
                }
            }
            for (int i = 0; i <= 7; i++)
            {
                Point p1 = new Point(check_point_x[0, i], check_point_y[0, i]);
                Point p2 = new Point(check_point_x[7, i], check_point_y[7, i]);
                res.Draw(new LineSegment2D(p1, p2), new Bgr(0, 0, 255), 1);
                p1 = new Point(check_point_x[i, 0], check_point_y[i, 0]);
                p2 = new Point(check_point_x[i, 7], check_point_y[i, 7]);
                res.Draw(new LineSegment2D(p1, p2), new Bgr(0, 0, 255), 1);
            }
            textBox1.Text = "";
            t_type = "4_point";
            text_res("4_point");
            imageBox1.Image = res;
        }

        void white_balence()
        {
            Image<Bgr, byte> frame = inp.Clone();
            frame = frame.SmoothMedian(3);
            int avgR = 0, avgG = 0, avgB = 0;
            int sumR = 0, sumG = 0, sumB = 0;
            for (int h = 0; h < frame.Height; ++h)
            {
                for (int w = 0; w < frame.Width; ++w)
                {
                    sumB += frame.Data[h, w, 0];
                    sumG += frame.Data[h, w, 1];
                    sumR += frame.Data[h, w, 2];
                }
            }
            int size = frame.Height * frame.Width;
            avgB = (int)(sumB * 1);
            avgG = (int)(sumG * 1);
            avgR = (int)(sumR * 1);
            //double k = (avgB + avgG + avgR) / 3;
            double k = 0.299 * avgR + 0.587 * avgG + 0.114 * avgB;
            all_light_pin = k/(size);
            double kr = k / avgR;
            double kg = k / avgG;
            double kb = k / avgB;
            double newB, newG, newR;
            all_s_pin = Math.Atan(Math.Sqrt(3) * (kg - kb) / (2 * kr - kg - kb))/Math.PI*255;
            

            for (int h = 0; h < frame.Height; ++h)
            {
                for (int w = 0; w < frame.Width; ++w)
                {
                    newB = frame.Data[h, w, 0] * kb * 0.8;
                    newG = frame.Data[h, w, 1] * kg * 0.8;
                    newR = frame.Data[h, w, 2] * kr * 0.8;

                    frame.Data[h, w, 0] = (byte)(newB > 255 ? 255 : newB);
                    frame.Data[h, w, 1] = (byte)(newG > 255 ? 255 : newG);
                    frame.Data[h, w, 2] = (byte)(newR > 255 ? 255 : newR);
                }
            }
            int[] max_color = new int[3];
            int[] min_color = new int[3];
            min_color[0] = 999;
            min_color[1] = 999;
            min_color[2] = 999;
            for (int h = 0; h < frame.Height; ++h)
            {
                for (int w = 0; w < frame.Width; ++w)
                {
                    max_color[0] = (max_color[0] < frame.Data[h, w, 0]) ? frame.Data[h, w, 0] : max_color[0];
                    max_color[1] = (max_color[1] < frame.Data[h, w, 1]) ? frame.Data[h, w, 1] : max_color[1];
                    max_color[2] = (max_color[2] < frame.Data[h, w, 2]) ? frame.Data[h, w, 2] : max_color[2];
                    min_color[0] = (min_color[0] > frame.Data[h, w, 0]) ? frame.Data[h, w, 0] : min_color[0];
                    min_color[1] = (min_color[1] > frame.Data[h, w, 1]) ? frame.Data[h, w, 1] : min_color[1];
                    min_color[2] = (min_color[2] > frame.Data[h, w, 2]) ? frame.Data[h, w, 2] : min_color[2];
                }
            }
            int[] chifan = new int[256];
            double chifan_cha = 0;
            for (int h = 0; h < frame.Height; ++h)
            {
                for (int w = 0; w < frame.Width; ++w)
                {
                    frame.Data[h, w, 0] = (byte)((double)(frame.Data[h, w, 0] - min_color[0]) / (double)(max_color[0] - min_color[0]) * 255);
                    frame.Data[h, w, 1] = (byte)((double)(frame.Data[h, w, 1] - min_color[1]) / (double)(max_color[1] - min_color[1]) * 255);
                    frame.Data[h, w, 2] = (byte)((double)(frame.Data[h, w, 2] - min_color[2]) / (double)(max_color[2] - min_color[2]) * 255);
                    chifan[(int)(0.114*(double)frame.Data[h, w, 2] + 0.299*(double)frame.Data[h, w, 0] + 0.587*(double)frame.Data[h, w, 1])]++;
                }
            }
            for(int i=1; i<256;i++)
            {
                chifan_cha += Math.Abs(chifan[i] - chifan[i - 1]);
            }
            chifan_cha /= 255;
            light_pin_cha = chifan_cha;
            inp = frame;
            imageBox1.Image = frame;
        }

        void res_draw()
        {
            Image<Bgr, byte> res = new Image<Bgr, byte>(inp.Bitmap);
            imageBox1.Image = res;
            res.Erode(2);
            res.ROI = new Rectangle(roi_p[0], new Size(roi_p[1].X - roi_p[0].X, roi_p[1].Y - roi_p[0].Y));
            res.Draw(new Rectangle(x_res[0], y_res[0], x_res[1] - x_res[0], y_res[1] - y_res[0]), new Bgr(100, 100, 200), 3);
            res.ROI = new Rectangle(new Point(0, 0), inp.Size);
            imageBox1.Image = res;
            for (int j = 0; j < 8; j++)
            {
                check_point_x[0, j] = Convert.ToInt16(x_res[0] + ((x_res[1] - x_res[0]) / 7 * j));
                check_point_x[7, j] = Convert.ToInt16(x_res[0] + ((x_res[1] - x_res[0]) / 7 * j));
                check_point_y[j, 0] = Convert.ToInt16(y_res[0] + (y_res[1] - y_res[0]) / 7 * j);
                check_point_y[j, 7] = Convert.ToInt16(y_res[0] + (y_res[1] - y_res[0]) / 7 * j);

            }
            int[,] res_point_x = new int[8, 8];
            int[,] res_point_y = new int[8, 8];
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {

                    //check_point_x[j, i] = (bx[0] + (bx[1] - bx[0]) / 7 * i) + ((bx[3]+(bx[3] - bx[2]) / 7 * i) - (bx[0] + (bx[1] - bx[0]) / 7 * i)) / 7 * j;
                    //check_point_y[j, i] = (by[0]+(by[2]-by[0])/7*j)+((by[3]+(by[3]-by[1])/7*j)- (by[0] + (by[2] - by[0]) / 7 * j))/7*i;
                    res_point_x[j, i] = (int)((check_point_x[0, 0] + (check_point_x[0, 7] - check_point_x[0, 0]) * 0.111) + (check_point_x[0, 7] - check_point_x[0, 0]) * 0.778 / 7 * i);
                    res_point_y[i, j] = (int)((check_point_y[0, 0] + (check_point_y[7, 0] - check_point_y[0, 0]) * 0.111) + (check_point_y[7, 0] - check_point_y[0, 0]) * 0.778 / 7 * i);
                }
            }
            check_point_x = res_point_x;
            check_point_y = res_point_y;
            res = new Image<Bgr, byte>(inp.Bitmap);
            imageBox1.Image = res;
            res.Erode(2);
            res.ROI = new Rectangle(roi_p[0], new Size(roi_p[1].X - roi_p[0].X, roi_p[1].Y - roi_p[0].Y));
            for (int i = 0; i <= 7; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    Point p = new Point(check_point_x[i, j], check_point_y[i, j]);
                    res.Draw(new CircleF(p, 5), new Bgr(0, 0, 255), 1);
                }
            }
            for (int i = 0; i <= 7; i++)
            {
                Point p1 = new Point(check_point_x[0, i], check_point_y[0, i]);
                Point p2 = new Point(check_point_x[7, i], check_point_y[7, i]);
                res.Draw(new LineSegment2D(p1, p2), new Bgr(0, 0, 255), 1);
                p1 = new Point(check_point_x[i, 0], check_point_y[i, 0]);
                p2 = new Point(check_point_x[i, 7], check_point_y[i, 7]);
                res.Draw(new LineSegment2D(p1, p2), new Bgr(0, 0, 255), 1);
            }
            textBox1.Text = "";
            t_type = "hh";
            text_res("hh");
            res.ROI = new Rectangle(new Point(0, 0), inp.Size);
            imageBox1.Image = res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            y_res[0]--;
            y_res[1]--;
            res_draw();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            y_res[0]++;
            y_res[1]++;
            res_draw();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            x_res[0]--;
            x_res[1]--;
            res_draw();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            x_res[0]++;
            x_res[1]++;
            res_draw();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            res_draw();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            x_res[0]++;
            x_res[1]--;
            y_res[0]--;
            y_res[1]++;
            res_draw();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            x_res[0]--;
            x_res[1]++;
            y_res[0]++;
            y_res[1]--;
            res_draw();

        }

        void text_res(string res_type)
        {
            int s = trackBar1.Value;
            int a = trackBar2.Value;
            white_balence();
            textBox1.Text = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (checkBox1.Checked)
                    {
                        string res_string = "";

                        res_string = get_s(check_point_x[i, j], check_point_y[i,j], res_type) + "," +geta(check_point_x[i, j], check_point_y[i, j], res_type) + "," +geth(check_point_x[i, j], check_point_y[i, j], res_type) + "," + all_light_pin + "," + all_s_pin + "," + light_pin_cha;
                        List<double> ans = bn.Recall(res_string,369);
                        int index = ans.IndexOf(ans.Max());
                        textBox1.Text += ","+index;
                        res[i, j] = index;
                    }
                    else
                    {
                        if (get_s(check_point_x[i, j], check_point_y[i, j], res_type) < s)
                        {
                            textBox1.Text += ",0";
                            res[i, j] = 0;
                        }
                        else
                        {
                            if (geta(check_point_x[i, j], check_point_y[i, j], res_type) >= a)
                            {
                                textBox1.Text += ",2";
                                res[i, j] = 2;
                            }
                            else if (geta(check_point_x[i, j], check_point_y[i, j], res_type) <= a)
                            {
                                textBox1.Text += ",1";
                                res[i, j] = 1;
                            }
                        }
                    }
                }
                textBox1.Text += "\r\n";
            }
        }

        private double get_s(int x, int y, string res_type)
        {
            Image<Hsv, byte> res = new Image<Hsv, byte>(inp.Bitmap);
            //imageBox1.Image = res;
            try
            {
                double total = 0;
                int count = 0;
                for (int i = -4; i < 5; i++)
                {
                    for (int j = -4; j < 5; j++)
                    {
                        if (res_type == "4_point")
                        {
                            total += res.Data[y + i, x + j, 0];
                            count++;
                        }
                        else
                        {
                            total += res.Data[y + i + roi_p[0].Y, x + j + roi_p[0].X, 0];
                            count++;
                        }
                    }
                }
                res.Dispose();
                return (int)total / count;
            }
            catch { return 0; }
        }
        private int geth(int x, int y, string res_type)
        {
            Image<Hsv, byte> res = new Image<Hsv, byte>(inp.Bitmap);
            //  imageBox1.Image = res;
            // res.Erode(2);
            // res.ROI = new Rectangle(roi_p[0], new Size(roi_p[1].X - roi_p[0].X, roi_p[1].Y - roi_p[0].Y));

            int total = 0;
            int count = 0;
            try
            {
                for (int i = -4; i < 5; i++)
                {
                    for (int j = -4; j < 5; j++)
                    {
                        if (res_type == "4_point")
                        {
                            total += res.Data[y + j, x + i, 1];
                            count++;
                        }
                    }
                }
                res.Dispose();
                return (int)total / count;
            }
            catch
            {
                return 0;
            }
        }
        private int geta(int x, int y, string res_type)
        {
            Image<Hsv, byte> res = new Image<Hsv, byte>(inp.Bitmap);
            //  imageBox1.Image = res;
            // res.Erode(2);
            // res.ROI = new Rectangle(roi_p[0], new Size(roi_p[1].X - roi_p[0].X, roi_p[1].Y - roi_p[0].Y));

            int total = 0;
            int count = 0;
            try
            {
                for (int i = -4; i < 5; i++)
                {
                    for (int j = -4; j < 5; j++)
                    {
                        if (res_type == "4_point")
                        {
                            total += res.Data[y + j, x + i, 2];
                            count++;
                        }
                    }
                }
                res.Dispose();
                return (int)total / count;
            }
            catch
            {
                return 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = "彩度:" + trackBar1.Value;
            text_res(t_type);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

            label3.Text = "明度:" + trackBar2.Value;
            text_res(t_type);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Net.WebClient WC = new System.Net.WebClient();
            WC.Credentials = new NetworkCredential("admin", "password");
            System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData(link_ip));
            Image img = Image.FromStream(Ms);
            //Image img = Image.FromFile(Path.GetFullPath("4.PNG"));
            inp = new Image<Bgr, byte>((Bitmap)img);
            double a = (double)imageBox1.Width / (double)inp.Width;
            //inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            // inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            //inp = inp.Rotate(90,new Bgr(255,255,255));
            imageBox1.Image = inp.Clone();
            //white_balence();
            white_balence();
            res_4point_draw();
        }
        CountChess_Othello co;
        integral_Othello io;
        GameTree1_Othello t1;
        GameTree2_Othello t2;
        GameTree3_Othello t3;
        GameTree4_Othello t4;
        GameTree5_Othello t5;
        MCTS_Othello.MCTS mc;
        UCT_Othello uct;
        int user_color = 0;
        int turn_count = 0;
        private bool if_chess_candown()
        {
            return false;
        }
        string error_chessbook = "";
        string pandun;
        List<Point> error_pt = new List<Point>();
        int down_count = 0;
        string error_message = "";
        string user_chessplaybook;
        string ans_chessplaybook = "";
        List<Point> lp = new List<Point>();
        double alpha = 0.2, eta = 0.6, num = 1;
        private void button11_Click(object sender, EventArgs e)
        {
            #region  New Form
            button11.Enabled = false;
            if (comboBox1.Enabled)
            {
                switch (comboBox1.Text)
                {
                    case "CountChess":
                        co = new CountChess_Othello();
                        break;
                    case "Integral":
                        io = new integral_Othello();
                        break;
                    case "Tree_One":
                        t1 = new GameTree1_Othello();
                        break;
                    case "Tree_Two":
                        t2 = new GameTree2_Othello();
                        break;
                    case "Tree_Three":
                        t3 = new GameTree3_Othello();
                        break;
                    case "Tree_Four":
                        t4 = new GameTree4_Othello(false);
                        break;
                    case "Tree_Five":
                        t4 = new GameTree4_Othello(false);
                        break;
                    case "UCT":
                        uct = new UCT_Othello(false);
                        break;
                }
            }
            #endregion#
            if (se != null)
                se.Close();
            //link_ip = textBox3.Text; 
            button8.PerformClick();
            bool chess_ari = false;
            error_chessbook = "";
            pandun = to_panduanduan();
            error_pt = new List<Point>();
            down_count = 0;
            error_message = "";
            user_chessplaybook = pandun;
            MCTS_Othello.MCTS_Chess[,] ms = new MCTS_Othello.MCTS_Chess[8, 8];
            Point down = new Point();
            ans_chessplaybook = "";
            //bool change = false;
            //turn_count = 2;
            if (turn_count != 0)
            {
                if (ToDownChess.change)
                {
                    chess_ari = true;
                    if(pandun == ToDownChess.information_now.chess_playbook)
                        goto godown;
                    else
                    {
                        error_message = "下子錯誤，你以為你還可以下嗎";
                        button11.Enabled = true;
                        if (ans_chessplaybook == "")
                            ans_chessplaybook = ToDownChess.information_now.chess_playbook;
                        if (error_pt.Count == 0)
                        {
                            char[] a = pandun.ToCharArray();
                            char[] b = ToDownChess.information_now.chess_playbook.ToCharArray();
                            for (int i = 0; i < 8; i++)
                                for (int j = 0; j < 8; j++)
                                    if (b[i * 8 + j] != a[i * 8 + j])
                                        error_pt.Add(new Point(i, j));
                        }
                        lp = new List<Point>();                        
                            foreach (Point cp in ToDownChess.information_now.All_candown)
                                lp.Add(new Point(cp.X, cp.Y));
                            axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\你下錯瞜.3gpp");
                        Task.Run(() =>
                        {
                            se = new Show_confidence_playbook(error_message, user_chessplaybook, ans_chessplaybook, null, error_pt);
                            se.ShowDialog();
                        });
                        return;
                        //  MessageBox.Show("不好意思，您下的地方有錯誤，請在三確認是否有下錯");
                    }
                }

                //for (int i = 0; i < 64; i++)
                //{
                //    ms[i / 8, i % 8] = new MCTS_Othello.MCTS_Chess();
                //    ms[i / 8, i % 8].color = int.Parse(user_chessplaybook[i].ToString()) - 1;
                //}

                //int change_count = mc.Chess_Count_Update(ms, user_color).Count;
                //if (change_count == 0)
                //{
                //    //change = true;
                //    chess_ari = true;
                //    if (user_chessplaybook != ToDownChess.information_now.chess_playbook)
                //    {
                //        ans_chessplaybook = ToDownChess.information_now.chess_playbook;
                //        lp = new List<Point>();
                //        error_message = "無子可落，請還原棋譜！";
                //        char[] kk = pandun.ToCharArray();
                //        char[] gg = ToDownChess.information_now.chess_playbook.ToCharArray();
                //        for (int i = 0; i < 8; i++)
                //            for (int j = 0; j < 8; j++)
                //                if (kk[i * 8 + j] != gg[i * 8 + j])
                //                    error_pt.Add(new Point(i, j));
                //        Task.Run(() =>
                //        {
                //            se = new Show_confidence_playbook(error_message, user_chessplaybook, ans_chessplaybook, lp, error_pt);
                //            se.ShowDialog();
                //        });
                //        button11.Enabled = true;
                //        return;
                //    }
                //    goto godown;
                //}
               // int player_color = 0;
                char[] k = pandun.ToCharArray();
                char[] g = ToDownChess.information_now.chess_playbook.ToCharArray();
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if ((k[i * 8 + j] != '0' && g[i * 8 + j] == '0'))
                        {
                            down_count++;
                            down.X = i;
                            down.Y = j;
                        }
                /*if (k[i * 8 + j] != g[i * 8 + j] && (k[i * 8 + j] == '0' || g[i * 8 + j] == '0'))
                {
                    down_count++;
                    down.X = i;
                    down.Y = j;
                }*/


                if (down_count != 1)
                {
                    error_message = "下子錯誤，您或許可以下這些綠色地方";
                }
                Point ans = new Point(-1, -1);
                if (ToDownChess.information_now.All_candown != null && error_message == "")
                {
                    if (k[down.X * 8 + down.Y] + "" == (user_color + 1).ToString())
                    {
                        foreach (Point cp in ToDownChess.information_now.All_candown)
                        {
                            if (res[cp.X, cp.Y] != 0)
                                ans = cp;
                            if (ans.X != -1)
                            {
                                string playbook = ToDownChess.Chess_Down_nochange(ToDownChess.information_now.Chess, ans.X, ans.Y, res[cp.X, cp.Y] - 1, ToDownChess.information_now.black, ToDownChess.information_now.white);
                                ans_chessplaybook = playbook;
                                if (playbook == pandun)
                                {
                                    chess_ari = true;
                                    break;
                                }
                                else
                                {
                                    k = pandun.ToCharArray();
                                    g = playbook.ToCharArray();
                                    for (int i = 0; i < 8; i++)
                                        for (int j = 0; j < 8; j++)
                                            if (k[i * 8 + j] != g[i * 8 + j] && !(k[i * 8 + j] == '0' || g[i * 8 + j] == '0'))
                                                error_pt.Add(new Point(i, j));
                                    error_chessbook = playbook;

                                    error_message = "翻棋錯誤，請在自行翻至正確棋譜";

                                    break;
                                }
                            }
                        }
                        if (ToDownChess.information_now.All_candown.Count == 0 || error_message != "" || ans.X != -1)
                            chess_ari = true;
                        else
                            error_message = "位置錯誤，您或許可以下這些地方";
                    }
                    else
                    {
                        error_message = "下棋錯誤，您下錯顏色了";
                        for (int i = 0; i < 8; i++)
                            for (int j = 0; j < 8; j++)
                                if (k[i * 8 + j] != g[i * 8 + j] )
                                    error_pt.Add(new Point(i, j));
                        //error_chessbook = pandun;
                    }
                }
                else
                    chess_ari = true;
            }
            else
                chess_ari = true;
            godown:
            if (chess_ari && error_message == "")
            {
            //    if (change)
            //    {
            //        ToDownChess.chess_playbook_Go = pandun;
            //        ToDownChess.information_now.chess_playbook = pandun;
            //    }
                //StreamWriter sw = new StreamWriter(@"C:\Users\皇宇\Desktop\faji.txt", true);
                //sw.Write(trackBar1.Value + " " + trackBar2.Value);
                //sw.WriteLine();
                //sw.Close();
                turn_count++;
                user_color = comboBox3.Text == "Black" ? 0 : 1;
                switch (comboBox1.Text)
                {
                    case "CountChess":
                        co.GetDown(res, user_color);
                        if (co.endgame)
                        {
                            ToDownChess.white = co.white;
                            ToDownChess.black = co.black;
                            button15.PerformClick();
                        }
                        if (co.change)
                        {
                            textBox2.Text = "";
                            button11.Enabled = true;
                            changedataupdate();
                        }
                        break;
                    case "Integral":
                        io.GetDown(res, user_color);
                        if (io.endgame)
                        {
                            ToDownChess.white = io.white;
                            ToDownChess.black = io.black;
                            button15.PerformClick();
                        }
                        if (io.changeuser)
                        {
                            textBox2.Text = "";
                            button11.Enabled = true;
                            changedataupdate();
                        }
                        break;
                    case "Tree_One":
                        t1.GetDown(res, user_color);
                        if (t1.endgame)
                        {
                            ToDownChess.white = t1.white;
                            ToDownChess.black = t1.black;
                            button15.PerformClick();
                        }
                        if (t1.changeuser)
                        {
                            textBox2.Text = "";
                            button11.Enabled = true;
                            changedataupdate();
                        }
                        break;
                    case "Tree_Two":
                        t2.GetDown(res, user_color);
                        if (t2.endgame)
                        {
                            ToDownChess.white = t2.white;
                            ToDownChess.black = t2.black;
                            button15.PerformClick();
                        }
                        if (t2.changeuser)
                        {
                            textBox2.Text = "";
                            button11.Enabled = true;
                            changedataupdate();
                        }
                        break;
                    case "Tree_Three":
                        t3.GetDown(res, user_color);
                        if (t3.endgame)
                        {
                            ToDownChess.white = t3.white;
                            ToDownChess.black = t3.black;
                            button15.PerformClick();
                        }
                        if (t3.changeuser)
                        {
                            textBox2.Text = "";
                            button11.Enabled = true;
                            changedataupdate();
                        }
                        break;
                    case "Tree_Four":
                        t4.GetDown(res, user_color);
                        if (t4.changeuser)
                        {
                            textBox2.Text = "";
                            button11.Enabled = true;
                            changedataupdate();
                        }
                        if (t4.endgame)
                        {
                            ToDownChess.white = t4.white;
                            ToDownChess.black = t4.black;
                            button15.PerformClick();
                        }
                        break;
                    case "Tree_Five":
                        t4.GetDown(res, user_color);
                        break;
                    case "UCT":
                        uct.GetDown(res, user_color, 3, 5);
                        break;
                    case "UCT_Linked List":
                        mc.GetDown(res, user_color + 1);

                        break;
                }
                button11.Enabled = true;
                //comboBox1.Enabled = false;
                //button8.PerformClick();
            }
            else
            {

                button11.Enabled = true;
                if (ans_chessplaybook == "")
                    ans_chessplaybook = ToDownChess.information_now.chess_playbook;
                if (error_pt.Count == 0)
                {
                    char[] k = pandun.ToCharArray();
                    char[] g = ToDownChess.information_now.chess_playbook.ToCharArray();
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                            if (k[i * 8 + j] != g[i * 8 + j])
                                error_pt.Add(new Point(i, j));
                }
                lp = new List<Point>();
                if (error_message == "翻棋錯誤，請在自行翻至正確棋譜")
                {
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\不好意思你翻錯瞜.3gpp");
                    lp = error_pt;
                }
                else
                {
                    foreach (Point cp in ToDownChess.information_now.All_candown)
                        lp.Add(new Point(cp.X, cp.Y));
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\你下錯瞜.3gpp");
                }

                Task.Run(() =>
                {
                    se = new Show_confidence_playbook(error_message, user_chessplaybook, ans_chessplaybook, lp, error_pt);
                    se.ShowDialog();
                });
                //  MessageBox.Show("不好意思，您下的地方有錯誤，請在三確認是否有下錯");
            }
        }
        Show_confidence_playbook se;
        string Chess_Process = "";

        public static String ChessPlay(int color, string AI_mode, string Chess_Playbook)
        {
            // IP: Port / Mode / color(AI) / AI_mode / Chess_Process / Chess_Playbook(Mode = play)
            string ip = "";
            string mode = "";


            string url = "";
            url = string.Format("");
            try
            {

                WebClient client = new WebClient();

                // Add a user agent header in case the 
                // requested URI contains a query.

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                Stream data = client.OpenRead(url);

                StreamReader reader = new StreamReader(data);
                string s = reader.ReadToEnd();


                data.Close();
                reader.Close();

                return s;

            }
            catch
            {

                return "err";
            }
        }

        void capch()
        {
            while (true)
            {
                string s = sp_d.ReadLine();
                if (s.Length != 0)
                {
                    System.Net.WebClient WC = new System.Net.WebClient();
                    WC.Credentials = new NetworkCredential("admin", "password");
                    System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData(link_ip));
                    Image img = Image.FromStream(Ms);
                    //Image img = Image.FromFile(Path.GetFullPath("4.PNG"));
                    inp = new Image<Bgr, byte>((Bitmap)img);
                    double a = ((double)imageBox1.Width / (double)inp.Width);

                    inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                    //inp = inp.Resize(inp.Height, inp.Width, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                    //inp = inp.Rotate(90, new Bgr(255, 255, 255));
                    imageBox1.Image = inp.Clone();
                    // white_balence();
                    white_balence();
                    res_4point_draw();
                }
            }

        }

        private void imageBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bx[d_click_count] = e.X;
            by[d_click_count] = e.Y;
            d_click_count++;
            if (d_click_count == 4)
            {
                d_click_count = 0;


                res_4point_draw();

            }
        }

        void ex_captch()
        {
            System.Net.WebClient WC = new System.Net.WebClient();
            WC.Credentials = new NetworkCredential("admin", "password");
            System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData(link_ip));
            Image img = Image.FromStream(Ms);
            //Image img = Image.FromFile(Path.GetFullPath("4.PNG"));
            inp = new Image<Bgr, byte>((Bitmap)img);
            double a = ((double)imageBox1.Width / (double)inp.Width);
            inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            //  inp = inp.Resize(inp.Height, inp.Width, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            //inp = inp.Rotate(90, new Bgr(255, 255, 255));
        }
        bool AInotdown = false;
        public void changedataupdate()
        {
            AInotdown = true;
            List<Chess_Towplayer> Chess = new List<Chess_Towplayer>();
            foreach (var a in user_chessplaybook)
            {
                Chess.Add(new Chess_Towplayer() { chess_color = Convert.ToInt32(a.ToString()) + 1 });
            }
            Chess = ToDownChess.Chess;
            ToDownChess.auto_check_point = new List<Check_Point>();
            ToDownChess.All_candown = new List<Point>();
            ToDownChess.chess_playbook_Go = "";
            int white_c = 0;
            int black_c = 0;
            ToDownChess.auto_check_point = new List<Check_Point>();
            ToDownChess.All_candown = new List<Point>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Chess[i * 8 + j].chess_color == 1)
                        black_c++;
                    else if (Chess[i * 8 + j].chess_color == 2)
                        white_c++;
                    ToDownChess.chess_playbook_Go += Chess[i * 8 + j].chess_color.ToString();
                    if (Chess[i * 8 + j].chess_color != 0) ToDownChess.auto_check_point.Add(new Check_Point { x = i, y = j, color = Chess[i * 8 + j].chess_color });
                    if (Chess[i * 8 + j].chess_change != 0)ToDownChess.All_candown.Add(new Point() { X = i, Y = j });
                }
            }
            ToDownChess.information_now.black = black_c;
            ToDownChess.information_now.Chess = ((Chess_Towplayer[])(Chess.ToArray().Clone())).ToList();
            ToDownChess.information_now.white = white_c;
            ToDownChess.information_now.auto_check_point = ToDownChess.auto_check_point;
            ToDownChess.information_now.All_candown = ToDownChess.All_candown;
            ToDownChess.information_now.chess_playbook = ToDownChess.chess_playbook_Go;
            axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 40;
            axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\AI無子可落.3gpp");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            (new Choice_Type_Othell()).Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sp_d = new SerialPort();
            try
            {
                sp_d.PortName = comboBox2.Text;
                sp_d.BaudRate = 115200;
                sp_d.Open();
                //serialPort1.PortName = comboBox2.Text;
                //serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arduino Connection Error!" + "\r\n\r\n" + "Please Check Your Port");
                MessageBox.Show(ex.Message);
                return;
            }
            try
            {
                link_ip = textBox3.Text;
                System.Net.WebClient WC = new System.Net.WebClient();
                WC.Credentials = new NetworkCredential("admin", "password");
                System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData(link_ip));
                //System.IO.MemoryStream Ms = new System.IO.MemoryStream(WC.DownloadData(link_ip));
                Image img = Image.FromStream(Ms);
                //Image img = Image.FromFile(Path.GetFullPath("4.PNG"));
                inp = new Image<Bgr, byte>((Bitmap)img);
                double a = ((double)imageBox1.Width / (double)inp.Width);
                inp = inp.Resize(a, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                imageBox1.Image = inp.Clone();
                // white_balence();
                white_balence();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sp_d.Close();
                MessageBox.Show("Cap Picture Error" + "\r\n\r\n" + "Please Check Your IP");
                return;
            }
            Task.Run(() =>
            {
                axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 40;
                //axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\玩家無子可络.3gpp");//我下完了換你摟
                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\遊戲開始.3gpp");

            }
            );


            MessageBox.Show("連接成功！");
            //comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            foreach (Control cc in this.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = true;
                }
            }
            foreach (Control cc in groupBox3.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = true;
                }
            }
            foreach (Control cc in groupBox2.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = true;
                }
            }
            foreach (Control cc in groupBox5.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = true;
                }
            }
            foreach (Control cc in groupBox4.Controls)
            {
                if (cc.Tag == "a")
                {
                    cc.Enabled = true;
                }
            }
            ((Button)sender).Enabled = false;
            //switch (comboBox1.Text)
            //{
            //    case "CountChess":
            //        co = new CountChess_Othello();
            //        break;
            //    case "Integral":
            //        io = new integral_Othello();
            //        break;
            //    case "Tree_One":
            //        t1 = new GameTree1_Othello();
            //        break;
            //    case "Tree_Two":
            //        t2 = new GameTree2_Othello();
            //        break;
            //    case "Tree_Three":
            //        t3 = new GameTree3_Othello();
            //        break;
            //    case "Tree_Four":
            //        t4 = new GameTree4_Othello(false);
            //        break;
            //    case "Tree_Five":
            //        t4 = new GameTree4_Othello(false);
            //        break;
            //    case "UCT":
            //        uct = new UCT_Othello(false);
            //        break;
            //    case "UCT_Linked List":
            //        mc = new MCTS_Othello.MCTS();

            //        break;
            //}
                    co = new CountChess_Othello();
                    io = new integral_Othello();
                    t1 = new GameTree1_Othello();
                    t2 = new GameTree2_Othello();
                    t3 = new GameTree3_Othello();
                    t4 = new GameTree4_Othello(false);
            
            mc = new MCTS_Othello.MCTS();
            Thread tt = new System.Threading.Thread(Computerturn);
            tt.IsBackground = true;
            tt.Start();
            button19_Click(null,null);
            //axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\你下錯了-酷炫版.3gpp");//連結成功，遊戲開始，請先四點定位後在自動校正
        }

        void Computerturn()
        {

            StringBuilder sb = new StringBuilder();
            bool can = true;
            while (true)
            {
                string ss = sp_d.ReadLine();
                if (ss.Trim() == "F")
                {
                    button11.Enabled = true;
                    Thread.Sleep(1500);
                    button8.PerformClick();
                    if (ToDownChess.endgame)
                    {
                        button15.PerformClick();
                      
                    }
                    again:
                    if (ToDownChess.endgame != true)
                        if (ToDownChess.chess_playbook_Go != to_panduanduan())
                        {
                            if(MessageBox.Show(/*"影像是否有歪斜、外物干擾或手臂誤下等狀況"*/"Please check the IP Cam is skewed", /*"小手手關愛小提示"*/"Remind", MessageBoxButtons.OKCancel)== DialogResult.OK)
                            {
                                button8.PerformClick();
                                continue;
                                //goto again;
                            }
                            else
                            Task.Run(() =>
                            {
                                every_auto_check(false);
                            //axWindowsMediaPlayer1.settings.setMode("loop", false);
                            //axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
                            res_4point_draw();
                                cf.Close();

                            });
                            cf = new CheckFaji();
                            cf.ShowDialog();
                        }
                        else
                        {
                            if (ToDownChess.change)
                            {
                                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\玩家無子可落.3gpp");//我下完了換你摟
                            }
                            else if (t4.mostwin)
                            {
                                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\必勝步.3gpp");//我下完了換你摟
                            }
                            else if (AInotdown)
                            {
                                AInotdown = false;
                                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\AI無子可落.3gpp");//我下完了換你摟
                            }
                            else
                            {
                                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\換手.3gpp");//我下完了換你摟
                            }
                            }
                    //else
                    // every_auto_check_jigen(true,trackBar1.Value,trackBar2.Value);
                }
                if (ss != null)
                {
                    sb.Append(ss[0]);
                    if (sb.ToString().Length > 2)
                        sb.Remove(0, 1);
                    // textBox2.Text = sb.ToString();
                    if (sb.ToString() == "00" && button11.Enabled && can)
                    {
                        //ss = "";
                        //sb = new StringBuilder();
                        button11.PerformClick();
                        can = false;
                    }
                    else if (sb.ToString() != "00")
                    {
                        can = true;
                    }
                }

                Thread.Sleep(10);
            };
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void User_UI_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P)
            {
                button8.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                button11.PerformClick();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        string hajime_chessbook = "";

        bool auto_check(bool check_s)
        {
            string sut = "";
            int s = trackBar1.Value;
            int a = trackBar2.Value;
            string this_playbook = "";
            string res_type = "4_point";
            if (ToDownChess.information_now.auto_check_point == null)
            {
                for (int i = 3; i < 5; i++)
                    for (int j = 3; j < 5; j++)
                    {
                        if (get_s(check_point_x[i, j], check_point_y[i, j], res_type) < s)
                        {
                            sut += "";
                        }
                        else
                        {
                            if (geta(check_point_x[i, j], check_point_y[i, j], res_type) >= a)
                            {
                                sut += "2";
                            }
                            else if (geta(check_point_x[i, j], check_point_y[i, j], res_type) <= a)
                            {
                                sut += "1";
                            }
                        }
                    }
                if (sut.Length == 4 && check_s && to_panduanduan() == hajime_chessbook)
                    return true;
                else if (sut == "1221" && to_panduanduan() == hajime_chessbook)
                    return true;
                else
                    return false;
            }
            else
            {
                foreach (Check_Point pok in ToDownChess.information_now.auto_check_point)
                {
                    int i = pok.x;
                    int j = pok.y;
                    this_playbook += pok.color;
                    if (get_s(check_point_x[i, j], check_point_y[i, j], res_type) < s)
                    {
                        sut += "0";
                    }
                    else
                    {
                        if (geta(check_point_x[i, j], check_point_y[i, j], res_type) >= a)
                        {
                            sut += "2";
                        }
                        else if (geta(check_point_x[i, j], check_point_y[i, j], res_type) <= a)
                        {
                            sut += "1";
                        }
                    }
                }
                if (sut == this_playbook)
                    return true;
                else
                    return false;
            }
        }

        string to_panduan()
        {
            string sut = "";
            int s = trackBar1.Value;
            int a = trackBar2.Value;
            string res_type = "4_point";

            white_balence();
            foreach (Check_Point cp in ToDownChess.auto_check_point)
                    if (checkBox1.Checked)
                    {
                        string res_string = "";

                        res_string = get_s(check_point_x[cp.x, cp.y], check_point_y[cp.x, cp.y], res_type) + "," + geta(check_point_x[cp.x, cp.y], check_point_y[cp.x, cp.y], res_type) + "," + geth(check_point_x[cp.x, cp.y], check_point_y[cp.x, cp.y], res_type) + "," + all_light_pin + "," + all_s_pin + "," + light_pin_cha;
                        List<double> ans = bn.Recall(res_string, 369);
                        int index = ans.IndexOf(ans.Max());
                        sut+= index;
                    }
                    else
                    if (get_s(check_point_x[cp.x, cp.y], check_point_y[cp.x, cp.y], res_type) < s)
                    {
                        sut += "0";
                        }
                     else
                    {
                    if (geta(check_point_x[cp.x, cp.y], check_point_y[cp.x, cp.y], res_type) >= a)
                    {
                        sut += "2";
                    }
                    else if (geta(check_point_x[cp.x, cp.y], check_point_y[cp.x, cp.y], res_type) <= a)
                    {
                        sut += "1";
                    }
                }
            return sut;
        }

        string to_panduanduan()
        {

            string sut = "";
            int s = trackBar1.Value;
            int a = trackBar2.Value;
            string res_type = "4_point";
       
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                        if (checkBox1.Checked) {
                            string res_string = "";

                            res_string = get_s(check_point_x[i, j], check_point_y[i, j], res_type) + "," + geta(check_point_x[i, j], check_point_y[i, j], res_type) + "," + geth(check_point_x[i, j], check_point_y[i, j], res_type) + "," + all_light_pin + "," + all_s_pin + "," + light_pin_cha;
                            List<double> ans = bn.Recall(res_string, 369);
                            int index = ans.IndexOf(ans.Max());
                           // textBox1.Text += "," + index;
                            sut += index;
                        }
                        else
                        {
                            Point cp = new Point(i, j);
                            if (get_s(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type) < s)
                            {
                                sut += "0";
                            }
                            else
                            {
                                if (geta(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type) >= a)
                                {
                                    sut += "2";
                                }
                                else if (geta(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type) <= a)
                                {
                                    sut += "1";
                                }
                            }
                        }
                }
            return sut;

        }

        public bool check_lemonade = false;

        void every_auto_check(bool Second_check)
        {
            // MessageBox.Show("跳進來囉");
            Task.Run(() =>
            {
                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\開始中途自動校正.3gpp");
                Thread.Sleep(5000);
                axWindowsMediaPlayer1.settings.setMode("loop", true);
                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\校正中請稍後....3gpp");
                
            });
            Thread.Sleep(5000);
            StreamWriter sw = new StreamWriter(System.DateTime.Now.Month + Convert.ToInt32(System.DateTime.Now.Day).ToString("00") + ".txt", true);
            sw.WriteLine();
            white_balence();
            List<double> sa = new List<double>();
            List<double> ah = new List<double>();
            List<double> li = new List<double>();
            List<int> ans = ToDownChess.information_now.chess_playbook.ToCharArray().ToList().ConvertAll((x) => x - '0');
            string res_type = "4_point";

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Point cp = new Point(i, j);
                    sa.Add(get_s(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type));//找色相
                    ah.Add(geta(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type));//找亮度
                    li.Add(geth(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type));//找彩度
                }
            for (int i = 0; i < sa.Count; i++)
            {
                string res = "";
                res = sa[i] + "," + ah[i] + "," + li[i] + "," + all_light_pin + "," + all_s_pin + "," + light_pin_cha + "/";
                res += (ans[i] == 0) ? "1,0,0" : (ans[i] == 1) ? "0,1,0" : "0,0,1";
                sw.Write(res);
                if (i != sa.Count - 1)
                    sw.Write("\r\n");
            }
            sw.Close();
            button17.PerformClick();
            /*check_lemonade = false;
            bool pan_ok = false;
            string gg = "";
            foreach (Check_Point cp in ToDownChess.auto_check_point)
                gg += cp.color;
            string sut = "";
            int count = 0;
            int start_point = trackBar2.Value;
            trackBar1.Value = 1;
            for (int i = start_point + 1; i < 255; i++)
            {
                count++;
                trackBar2.Value = i;
                sut = to_panduan();
                if (sut == gg)
                {
                    pan_ok = true;
                    break;
                }
            }
            count = 0;
            if (!pan_ok)
                for (int i = start_point - 1; i > 0; i--)
                {
                    count++;
                    trackBar2.Value = i;
                    sut = to_panduan();
                    if (sut == gg)
                    {
                        pan_ok = true;
                        break;

                    }
                }
            if (!pan_ok)
            {
                //axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
                //axWindowsMediaPlayer1.settings.setMode("loop", false);
                //axWindowsMediaPlayer1.Visible = false;
                //axWindowsMediaPlayer1.currentPlaylist.clear();

                if (!Second_check)
                {
                    button8.PerformClick();
                    every_auto_check(true);
                    //axWindowsMediaPlayer1.settings.setMode("loop", false);
                    //axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
                }
                else
                {
                    axWindowsMediaPlayer1.settings.setMode("loop", false);
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正發生錯誤.3gpp");
                    MessageBox.Show("定位錯誤，請重新定位");
                }
            }
            else
            {
                int min_faji = 0;
                int max_faji = 0;
                start_point = trackBar2.Value;
                for (int i = start_point; i < 255; i++)
                {
                    trackBar2.Value = i;
                    sut = to_panduan();
                    if (sut != gg)
                    {
                        max_faji = i - 1;
                        break;
                    }
                }
                for (int i = start_point; i > 0; i--)
                {
                    trackBar2.Value = i;
                    sut = to_panduan();
                    if (sut != gg)
                    {
                        min_faji = i + 1;
                        break;
                    }
                }
                trackBar2.Value = (max_faji + min_faji) / 2;
                // StreamWriter sw = new StreamWriter(@"C:\Users\皇宇\Desktop\faji.txt", true);
                //sw.Write(max_faji + " " + min_faji + " ");
                min_faji = 0;
                max_faji = 0;
                for (int i = 0; i < 255; i++)
                {
                    trackBar1.Value = i;
                    sut = to_panduanduan();
                    if (sut == ToDownChess.information_now.chess_playbook)
                    {
                        max_faji = i - 1;
                        break;
                    }

                }
                for (int i = 255; i > 0; i--)
                {
                    trackBar1.Value = i;
                    sut = to_panduanduan();
                    if (sut == ToDownChess.information_now.chess_playbook)
                    {
                        min_faji = i + 1;
                        break;
                    }

                }
                trackBar1.Value = (max_faji + min_faji) / 2;
                //sw.Write(max_faji + " " + min_faji + " ");
                // sw.Close();
                if (to_panduanduan() == ToDownChess.information_now.chess_playbook)
                {
                    cf.Close();
                    axWindowsMediaPlayer1.settings.setMode("loop", false);
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
                    //MessageBox.Show("自動校正完畢！");
                }
                else
                {
                    if (!Second_check)
                    {
                        button8.PerformClick();
                        every_auto_check(true);
                        //axWindowsMediaPlayer1.settings.setMode("loop", false);
                        //axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
                    }
                    else
                    {
                        axWindowsMediaPlayer1.settings.setMode("loop", false);
                        axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正發生錯誤.3gpp");
                        MessageBox.Show("定位錯誤，請重新定位");
                    }
                }
            }*/
        }

        void every_auto_check_jigen(bool Second_check, int moto_h, int moto_value)
        {
            // MessageBox.Show("跳進來囉");
            check_lemonade = false;
            bool pan_ok = false;
            string gg = "";
            foreach (Check_Point cp in ToDownChess.auto_check_point)
                gg += cp.color;
            string sut = "";
            int count = 0;
            int start_point = trackBar2.Value;
            trackBar1.Value = 1;
            int min_faji = 0;
            int max_faji = 0;
            start_point = trackBar2.Value;
            for (int i = start_point; i < 255; i++)
            {
                trackBar2.Value = i;
                sut = to_panduan();
                if (sut != gg)
                {
                    max_faji = i - 1;
                    break;
                }
            }
            for (int i = start_point; i > 0; i--)
            {
                trackBar2.Value = i;
                sut = to_panduan();
                if (sut != gg)
                {
                    min_faji = i + 1;
                    break;
                }
            }
            //  StreamWriter sw = new StreamWriter(@"C:\Users\皇宇\Desktop\faji.txt", true);
            // sw.Write(max_faji + " " + min_faji + " ");
            trackBar2.Value = (max_faji + min_faji) / 2;

            min_faji = 0;
            max_faji = 0;
            for (int i = 0; i < 255; i++)
            {
                trackBar1.Value = i;
                sut = to_panduanduan();
                if (sut == ToDownChess.information_now.chess_playbook)
                {
                    max_faji = i - 1;
                    break;
                }

            }
            for (int i = 255; i > 0; i--)
            {
                trackBar1.Value = i;
                sut = to_panduanduan();
                if (sut == ToDownChess.information_now.chess_playbook)
                {
                    min_faji = i + 1;
                    break;
                }

            }
            trackBar1.Value = (max_faji + min_faji) / 2;
            //sw.Write(max_faji + " " + min_faji + " ");
            //sw.Close();
            trackBar1.Value = moto_h;
            trackBar2.Value = moto_value;

        }
        CheckFaji cf = new CheckFaji();
        private void button14_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                button8_Click(null, null);
                if (turn_count != 0)
                {
                    every_auto_check(true);
                    return;
                }

                int min_faji = 9999;
                int max_faji = 0;
                hajime_chessbook = "";
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if ((i == 3 && j == 3) || (i == 4 && j == 4))
                            hajime_chessbook += "1";
                        else if ((i == 3 && j == 4) || (i == 4 && j == 3))
                            hajime_chessbook += "2";
                        else
                            hajime_chessbook += "0";
                    }
                if (checkBox1.Checked)
                {
                    string res_type = "4_point";
                    string kk = "";
                    for (int i = 0; i < 8; i++)
                        for (int j = 0; j < 8; j++)
                        {
                            string res_string = "";
                            res_string = get_s(check_point_x[i, j], check_point_y[i, j], res_type) + "," + geta(check_point_x[i, j], check_point_y[i, j], res_type) + "," + geth(check_point_x[i, j], check_point_y[i, j], res_type) + "," + all_light_pin + "," + all_s_pin + "," + light_pin_cha;
                            List<double> ans = bn.Recall(res_string, 369);
                            int index = ans.IndexOf(ans.Max());
                            kk += index;
                        }
                    if (kk == hajime_chessbook)
                    {
                        axWindowsMediaPlayer1.settings.setMode("loop", false);
                        axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
                        cf.Close();
                    }
                    else
                    {

                        cf.Close();
                        axWindowsMediaPlayer1.settings.setMode("loop", false);
                        axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正發生錯誤.3gpp");
                        MessageBox.Show("初始棋盤有誤");

                    }
                }
                else
                {
                    for (int i = 255; i > 0; i--)
                    {
                        trackBar1.Value = i;
                        if (auto_check(true))
                        {
                            max_faji = trackBar1.Value;
                            break;
                        }
                    }
                    for (int i = 0; i < 255; i++)
                    {
                        trackBar1.Value = i;
                        if (auto_check(true))
                        {
                            min_faji = trackBar1.Value;
                            break;
                        }
                    }
                    if ((int)((max_faji + min_faji) / 2) < 255)
                    {
                        trackBar1.Value = (int)((max_faji + min_faji) / 2);
                        min_faji = 9999;
                        max_faji = 0;
                        for (int i = 255; i > 0; i--)
                        {
                            trackBar2.Value = i;
                            if (auto_check(false))
                            {
                                max_faji = trackBar2.Value;
                                break;
                            }
                        }
                        for (int i = 0; i < 255; i++)
                        {
                            trackBar2.Value = i;
                            if (auto_check(false))
                            {
                                min_faji = trackBar2.Value;
                                break;
                            }
                        }
                        if (!(min_faji < 256))
                            MessageBox.Show("初始棋盤有誤");
                        else
                        {
                            trackBar2.Value = (int)((max_faji + min_faji) / 2);
                            axWindowsMediaPlayer1.settings.setMode("loop", false);
                            axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
                            cf.Close();
                            //MessageBox.Show("自動校正完畢");
                            // button14.Enabled = false;
                        }
                    }
                    else
                    {
                        cf.Close();
                        axWindowsMediaPlayer1.settings.setMode("loop", false);
                        axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正發生錯誤.3gpp");
                        MessageBox.Show("初始棋盤有誤");
                    }
                }
            });
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\校正中請稍後....3gpp");
            cf = new CheckFaji();
            cf.ShowDialog();
        }

        private void imageBox1_Click(object sender, EventArgs e)
        {

        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Image<Hsv, byte> hb = new Image<Hsv, byte>(inp.Bitmap);
                textBox2.Text = "" + hb.Data[e.Y, e.X, 0] + " " + hb.Data[e.Y, e.X, 1] + " " + hb.Data[e.Y, e.X, 2];
            }
            catch
            {
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        Boolean hide_flag = false;


        private void User_UI_DoubleClick(object sender, EventArgs e)
        {
            if (hide_flag)
                groupbox0.Hide();
            else
                groupbox0.Show();
            hide_flag = !hide_flag;


        }

        private void button15_Click(object sender, EventArgs e)
        {
            user_chessplaybook = to_panduanduan();
            hajime_chessbook = "";
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if ((i == 3 && j == 3) || (i == 4 && j == 4))
                        hajime_chessbook += "1";
                    else if ((i == 3 && j == 4) || (i == 4 && j == 3))
                        hajime_chessbook += "2";
                    else
                        hajime_chessbook += "0";
                }
            turn_count = 0;
            ToDownChess.information_now.auto_check_point = null;
            //MessageBox.Show("遊戲結束，請還原初始棋譜！");
            if (ToDownChess.endgame)
            {
                se = new Show_confidence_playbook((ToDownChess.end == 1 ? "黑子勝，" : ToDownChess.end == 2 ? "白子勝，" : "平手，") + "遊戲結束~請還原至右方初始棋譜", user_chessplaybook, hajime_chessbook, null, null);
                if (ToDownChess.end == user_color + 1)
                {
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\AI輸了.3gpp");//我下完了換你摟
                }
                else if (ToDownChess.end == 3)
                {
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\平手.3gpp");//我下完了換你摟
                }
                else
                {
                    axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\AI贏了2.3gpp");//我下完了換你摟
                }
            }
            else
            {
                axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\重新開始.3gpp");//我下完了換你摟
                se = new Show_confidence_playbook("重新開始，請還原棋譜", user_chessplaybook, hajime_chessbook, null, null);
            }
            se.ShowDialog();
        }
        double all_s_pin=0,all_light_pin=0,light_pin_cha=0;
        int hide_long = 1;
        int hide_count = 0;
        int learntimes = 1000;
        BackPropagationNeuralNetwork.BackPropagation_NeuralNetwork bn = new BackPropagationNeuralNetwork.BackPropagation_NeuralNetwork();

        private void button18_Click(object sender, EventArgs e)
        {
            File.Delete(Path.GetFullPath(learningdatatxt.Text));
            MessageBox.Show("我是誰?");
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (!File.Exists(inputlearningtxt.Text)) return;
            StreamReader sr = new StreamReader(inputlearningtxt.Text);
            string learning_data = sr.ReadToEnd();
            learning_data = learning_data.Replace("\r\n","。");
            List<string> s = learning_data.Split('。').ToList();
            string[] ss = s[0].Split(',');
            eta = double.Parse(ss[0]);
            alpha = double.Parse(ss[1]);
            hide_long = int.Parse(ss[2]);
            hide_count = int.Parse(ss[3]);
            num = double.Parse(ss[4]);
            s.RemoveAt(0);
            s.RemoveAt(s.Count-1);
            bn.Insert_LearnData(s);
            NN_valuetxt_update();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            bn.Output_LearnData(eta,alpha,hide_long,hide_count,num,outputlearningtxt.Text);
        }

        private void button21_Click(object sender, EventArgs e) //display_data
        {
            (new 失智預警系統.Form1()).Show();
        }

        void NN_valuetxt_update()
        {
            etatxt.Text = eta.ToString();
            alphatxt.Text = alpha.ToString();
            hidlongtxt.Text = hide_long.ToString();
            hidcounttxt.Text = hide_count.ToString();
            numtxt.Text = num.ToString();
            learntimestxt.Text = learntimes.ToString();
        }
        void NN_value_update()
        {
            eta = double.Parse(etatxt.Text);
            alpha = double.Parse(alphatxt.Text);
            hide_count = int.Parse(hidcounttxt.Text);
            hide_long = int.Parse(hidlongtxt.Text);
            num = double.Parse(numtxt.Text);
            learntimes = int.Parse(learntimestxt.Text);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            NN_value_update();
            StreamReader sr = new StreamReader(Path.GetFullPath(learningdatatxt.Text));
            string d = sr.ReadToEnd();
            d = d.Replace("\r\n","@");
            string[] data = d.Split('@');
            List<BackPropagationNeuralNetwork.In_D> in_data = new List<BackPropagationNeuralNetwork.In_D>();
            foreach(var a in data)
            {
                in_data.Add(new BackPropagationNeuralNetwork.In_D() { data = a.Split('/')[0].ToString() , ans = a.Split('/')[1].ToString()});
            }
            bn.Learn(in_data,learntimes,eta,alpha,hide_long,num,hide_count,true,0.0005);
            sr.Close();
            cf.Close();
            axWindowsMediaPlayer1.settings.setMode("loop", false);
            axWindowsMediaPlayer1.URL = Path.GetFullPath(@"sound\自動校正完畢.3gpp");
            if (bn.mse_now < 0.01)
            MessageBox.Show("Learn Done  "+bn.mse_now);
            else
                MessageBox.Show("Learn failed  "+bn.mse_now);
            //button8.PerformClick();
            //every_auto_check(true);
      }

        private void button16_Click(object sender, EventArgs e)
        {
            bool if_exists;
            if_exists = File.Exists(learningdatatxt.Text);
            StreamWriter sr = new StreamWriter(learningdatatxt.Text, true);
            string sut = "";
            white_balence();
            int s = trackBar1.Value;
            int a = trackBar2.Value;
            string res_type = "4_point";
            List<double> sa = new List<double>();
            List<double> ah = new List<double>();
            List<double> li = new List<double>();
            List<int> ans = textBox1.Text.Replace("\r\n", "").Remove(0,1).Split(',').ToList().ConvertAll(x => int.Parse(x));
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Point cp = new Point(i, j);
                    sa.Add(get_s(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type));//找色相
                    ah.Add( geta(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type));//找亮度
                    li.Add( geth(check_point_x[cp.X, cp.Y], check_point_y[cp.X, cp.Y], res_type));//找彩度
                 }
            if (if_exists)
                sr.WriteLine();
            for(int i = 0; i<sa.Count; i ++)
            {
                string res = "";
                res = sa[i] + "," + ah[i] + "," + li[i] + "," + all_light_pin + "," + all_s_pin + "," + light_pin_cha + "/";
                res += (ans[i]==0)?"1,0,0":(ans[i]==1)?"0,1,0":"0,0,1";
                sr.Write(res);
                if (i != sa.Count - 1)
                    sr.Write("\r\n");
            }
            sr.Close();
        }

    }
}
