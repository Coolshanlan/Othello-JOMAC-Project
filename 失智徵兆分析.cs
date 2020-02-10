using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 失智預警系統
{
    public partial class 失智徵兆分析 : Form
    {
        DataTable User_Data = new DataTable();
        DataTable Chess_Data = new DataTable();
        sqlclass sqlc = new sqlclass();
        string Caregiver_ID = "";
        string Player_ID = "";
        public 失智徵兆分析(string C_ID)
        {
            InitializeComponent();
            Caregiver_ID = C_ID;
        }
        List<C_D> Data_chess = new List<C_D>();
        private void 失智徵兆分析_Load(object sender, EventArgs e)
        {
            chart3.Hide();
            chart5.Hide();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            chart1.Series.Add("");
            chart4.Series[0].Name = "Player";
            chart4.Series.Add("Standard");
            chart4.Series[1].IsValueShownAsLabel = true;
            chart4.Series[0].IsValueShownAsLabel = true;
            //chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            //chart4.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            //chart4.Series[1].BorderWidth = 4;
            User_Data = sqlc.Player_search(Caregiver_ID);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.DataSource = User_Data;
            chart1.Series[0].BorderWidth = 4;
            chart2.Series[0].BorderWidth = 4;
            chart3.Series[0].BorderWidth = 4;
            chart1.Series[0].Name= "Average Chess Time";
            chart2.Series[0].Name = "Wrong Times";
            chart3.Series[0].Name = "Average Time Difference Between Chess";
            chart4.ChartAreas[0].AxisX.CustomLabels.Add(1.5,0.5,"Calculation");
            chart4.ChartAreas[0].AxisX.CustomLabels.Add(3.5, 0.5, "Attention");
            chart4.ChartAreas[0].AxisX.CustomLabels.Add(5.5, 0.5, "Memory");
            chart4.ChartAreas[0].AxisX.CustomLabels.Add(7.5, 0.5, "Judgment");
            chart4.ChartAreas[0].AxisX.CustomLabels.Add(9.5, 0.5, "Speak and Behavior");
            chart4.ChartAreas[0].AxisX.CustomLabels.Add(11.5, 0.5, "Constructed");
            chart1.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.ChartAreas[0].AxisX.Interval = 10;
            chart2.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.ChartAreas[0].AxisX.Interval = 10;
            chart3.Series[0].MarkerSize = 4;
            chart1.Series[0].MarkerSize = 4;
            chart3.Series[0].MarkerColor = Color.Black;
            chart1.Series[0].MarkerColor = Color.Black;
            chart2.Series[0].MarkerColor = Color.Black;
            chart3.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chart3.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart3.ChartAreas[0].AxisX.Interval = 10;
            //chart4.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            chart3.Series[0].Color = Color.FromArgb(150, 0, 102, 255);
            chart1.Series[0].Color = Color.FromArgb(200, 255, 102, 102);
            chart1.Series[0].Points.AddY(2);
            chart1.ChartAreas[0].AxisX.Title = "Game times / 5";
            chart1.ChartAreas[0].AxisY.Title = "Chess time / minute";
            chart5.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart5.Series[0].BorderWidth = 4;
            chart5.Series.Add("Standard");
            chart5.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart5.Series[1].BorderWidth = 4;
            chart4.ChartAreas[0].AxisY.Maximum = 45;
            chart4.ChartAreas[0].AxisY.Minimum = 0;
            //chart4.ChartAreas[0].AxisY.max
            //chart1.BackColor = Color.Black;
            //chart1.Series[1].Color = Color.FromArgb(100,100, 255);
            //chart1.Series[0].IsValueShownAsLabel = true;
            //chart2.Series[0].IsValueShownAsLabel = true;
            //chart3.Series[0].IsValueShownAsLabel = true;

            //foreach (var a in Data_chess)
            //{
            //    chart1.Series[0].Points.AddY(a.time);
            //    chart2.Series[0].Points.AddY(a.wrong);
            //    if (count != -1)
            //    {
            //        if(Math.Abs((av_value / count) - a.time)> (av_value/count) * 0.3 || a.Done == 0)
            //        {
            //            chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - a.time).ToString("0.00"));
            //            chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerColor = Color.Red;
            //            chart1.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerColor = Color.Red;
            //        }
            //        else
            //        {
            //            chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - a.time).ToString("0.00"));
            //            av_value += a.time;
            //            count++;
            //        }
            //    }
            //    //else
            //    //{
            //    //    av_value = a.time;
            //    //    count ++;
            //    //    chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - a.time).ToString("0.00"));
            //    //}
            //}
            Chess_Data = sqlc.chess_search("1");
            Data_chess = new List<C_D>();

            foreach (DataRow dr in Chess_Data.Rows)
            {
                Data_chess.Add(new C_D() { ID = dr["ID"].ToString(), Player_ID = dr["Player_ID"].ToString(), AI_Mode = int.Parse(dr["AI_Mode"].ToString()), Date = dr["Date"].ToString(), Done = int.Parse(dr["Done"].ToString()), Remember = int.Parse(dr["Remember"].ToString()), time = int.Parse(dr["Time"].ToString()), win = int.Parse(dr["Win"].ToString()), wrong = int.Parse(dr["Wrong"].ToString()) });
            }

            //Data_chess.Reverse();
            wrong_id_list = new List<List<string>>();
            foreach (var a in Data_chess)
            {
                string chess_ID = a.ID;

                DataTable dt = sqlc.wrong_search(chess_ID);
                wrong_id_list.Add(new List<string>());
                foreach (DataRow dr in dt.Rows)
                {
                    wrong_id_list[wrong_id_list.Count - 1].Add(dr["Wrong_ID"].ToString());
                }

            }
            Normal = new Wrong();
            normal_count = Data_chess.Count ;
            for (int i = 0; i < normal_count; i++)
            {
                    for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                    {
                        wrongvaluefunction(wrong_id_list[i][ww], ref Normal);
                    }
            }
            normal_count = Data_chess.Count;


            textBox1.Text = "1";
            button2.PerformClick();
        }

        private void 失智徵兆分析_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        Wrong Normal = new Wrong();
        private void button1_Click(object sender, EventArgs e)
        {
            Player_ID = textBox1.Text;
            User_Data = sqlc.CheckPlayer(Player_ID,Caregiver_ID);
            (new Insert_Chess_Data(User_Data)).Show();
        }
        List<List<string>> wrong_id_list = new List<List<string>>();
        int wrong_count = 1;
        int normal_count = 0;
        DateTime startime = new DateTime();
        DateTime endtime = new DateTime();
        private void button2_Click(object sender, EventArgs e)
        {
           






            Player_ID = textBox1.Text;
            Chess_Data = new DataTable();

            //dataGridView3.DataSource = sqlc.CheckPlayer(Player_ID,Caregiver_ID);

            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();

            Chess_Data = sqlc.chess_search(Player_ID);
            Data_chess = new List<C_D>();

            foreach (DataRow dr in Chess_Data.Rows)
            {
                Data_chess.Add(new C_D() { ID = dr["ID"].ToString(), Player_ID = dr["Player_ID"].ToString(), AI_Mode = int.Parse(dr["AI_Mode"].ToString()), Date = dr["Date"].ToString(), Done = int.Parse(dr["Done"].ToString()), Remember = int.Parse(dr["Remember"].ToString()), time = int.Parse(dr["Time"].ToString()), win = int.Parse(dr["Win"].ToString()), wrong = int.Parse(dr["Wrong"].ToString()) });
            }

            DataTable ddt = sqlc.CheckPlayer(Player_ID,Caregiver_ID);
            label6.Text = "User："+ ddt.Rows[0]["Name"].ToString();
            //Chess_Data.Columns.Remove("Date");
            dataGridView2.DataSource = Chess_Data;
            trackBar1.Maximum = Data_chess.Count / 5;
            trackBar1.Minimum = 1;
            double count = 1;
            double av_value = 50;
            double w = 0, t = 0, r = 0, d = 0;
            double data_count = 0;
            foreach (var a in Data_chess)
            {
                data_count++;
                t += a.time;
                d += a.Done;
                w += a.wrong;
                if (data_count == 5)
                {
                    chart1.Series[0].Points.AddY(t / 5);
                    chart2.Series[0].Points.AddY(w);
                    if (Math.Abs((av_value / count - t / 5.0)) > (av_value / count) * 0.3 || d < 3)
                    {
                        chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - t / 5.0).ToString("0.00"));
                        chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerSize = 10;
                        //chart1.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerSize = 10;
                        //chart1.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
                        chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
                        chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerSize = 8;
                        chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerBorderColor = Color.Black;
                         //chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerImage = "";
                         chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerColor = Color.FromArgb(255,10,10);
                        //  chart1.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerColor  = Color.FromArgb(200,120,10);
                        //av_value += t / 5.0;
                        //count++;
                    }
                    else
                    {
                        chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - t / 5.0).ToString("0.00"));
                        av_value += t / 5.0;
                        count++;
                    }
                    data_count = 0;
                    t = 0;
                    d = 0;
                    w = 0;
                }
            }

            //Data_chess.Reverse();
            //AVG
            //wrong_id_list = new List<List<string>>();
            //foreach (var a in Data_chess)
            //{
            //    string chess_ID = a.ID;

            //    DataTable dt = sqlc.wrong_search(chess_ID);
            //    wrong_id_list.Add(new List<string>());
            //    foreach(DataRow dr in dt.Rows)
            //    {
            //        wrong_id_list[wrong_id_list.Count-1].Add(dr["Wrong_ID"].ToString());
            //    }

            //}
            //Wrong wrong_value = new Wrong();
            //for(int i = 0; i < wrong_count; i++)
            //{
            //    if (wrong_count * 5 > wrong_id_list.Count) break;
            //    for(int j = i * 5; j < i * 5 + 5; j++)
            //    {
            //        for(int ww = 0; ww< wrong_id_list[j].Count; ww++)
            //        {
            //            wrongvaluefunction(wrong_id_list[j][ww], ref wrong_value);
            //        }
            //    }
            //}
            //chart4.Series[0].Points.Clear();
            //chart4.Series[0].Points.AddY((double)wrong_value.A/ (double)wrong_count*5);
            //chart4.Series[0].Points.AddY((double)wrong_value.B / (double)wrong_count*5);
            //chart4.Series[0].Points.AddY((double)wrong_value.C / (double)wrong_count*5);
            //chart4.Series[0].Points.AddY((double)wrong_value.D / (double)wrong_count*5);
            //chart4.Series[0].Points.AddY((double)wrong_value.E / (double)wrong_count*5);
            //chart4.Series[0].Points.AddY((double)wrong_value.F / (double)wrong_count*5);

            //chart4.Series[1].Points.Clear();
            //chart4.Series[1].Points.AddY((double)wrong_value.A/ (double)wrong_count*5-(double)Normal.A / normal_count);
            //chart4.Series[1].Points.AddY((double)wrong_value.B / (double)wrong_count*5-(double)Normal.B / normal_count);
            //chart4.Series[1].Points.AddY((double)wrong_value.C / (double)wrong_count*5-(double)Normal.C / normal_count);
            //chart4.Series[1].Points.AddY((double)wrong_value.D / (double)wrong_count*5-(double)Normal.D / normal_count);
            //chart4.Series[1].Points.AddY((double)wrong_value.E / (double)wrong_count*5-(double)Normal.E / normal_count);
            //chart4.Series[1].Points.AddY((double)wrong_value.F / (double)wrong_count * 5-(double)Normal.F / normal_count);


            //Only5
            wrong_id_list = new List<List<string>>();
            foreach (var a in Data_chess)
            {
                string chess_ID = a.ID;

                DataTable dt = sqlc.wrong_search(chess_ID);
                wrong_id_list.Add(new List<string>());
                foreach (DataRow dr in dt.Rows)
                {
                    wrong_id_list[wrong_id_list.Count - 1].Add(dr["Wrong_ID"].ToString());
                }

            }
            Wrong wrong_value = new Wrong();
            for (int i = wrong_count-1; i < wrong_count; i++)
            {
                if (wrong_count * 5 > wrong_id_list.Count) break;
                for (int j = i * 5; j < i * 5 + 5; j++)
                {
                    for (int ww = 0; ww < wrong_id_list[j].Count; ww++)
                    {
                        wrongvaluefunction(wrong_id_list[j][ww], ref wrong_value);
                    }
                }
            }
            trackBar1.Value = trackBar1.Maximum;
            wrong_count = trackBar1.Value;
            chart4.Series[0].Points.Clear();
            chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.A / (double)5));
            chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.B / (double)5));
            chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.C / (double)5));
            chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.D / (double)5));
            chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.E / (double)5));
            chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.F / (double)5));

            chart4.Series[1].Points.Clear();
            chart4.Series[1].Points.AddY(Math.Round((double)Normal.A / normal_count, 2));
            chart4.Series[1].Points.AddY(Math.Round((double)Normal.B / normal_count, 2));
            chart4.Series[1].Points.AddY(Math.Round((double)Normal.C / normal_count, 2));
            chart4.Series[1].Points.AddY(Math.Round((double)Normal.D / normal_count, 2));
            chart4.Series[1].Points.AddY(Math.Round((double)Normal.E / normal_count, 2));
            chart4.Series[1].Points.AddY(Math.Round((double)Normal.F / normal_count, 2));


            //chart4.Series[1].Points[0].Color = Color.Yellow;
            //chart4.Series[1].Points[1].Color = Color.Yellow;
            //chart4.Series[1].Points[2].Color = Color.Yellow;
            //chart4.Series[1].Points[3].Color = Color.Yellow;
            //chart4.Series[1].Points[4].Color = Color.Yellow;
            //chart4.Series[1].Points[5].Color = Color.Yellow;


            //if (Math.Abs((av_value / count - t / data_count)) > (av_value / count) * 0.3 || d < 3)
            //{
            //    chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - a.time).ToString("0.00"));
            //    chart3.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerColor = Color.Red;
            //    chart1.Series[0].Points[chart3.Series[0].Points.Count - 1].MarkerColor = Color.Red;
            //}
            //else
            //{
            //    chart3.Series[0].Points.AddY(Math.Abs((av_value / count) - a.time).ToString("0.00"));
            //    av_value += t;
            //    t = 0;
            //    d = 0;
            //    w = 0;
            //    count++;
            //}
            label1.Text = "Average chess time：" + (av_value / count).ToString("0.00") + " minute";
            label1.Font = new Font("微軟正黑體", 15);
            label1.BackColor = Color.White;
            chart1.Series[1]=chart3.Series[0];
            label3.Text = "第" +wrong_count + "筆資料，共" + trackBar1.Maximum + "筆";
            //-----
            if (wrong_count < 5) return;
            endtime = new DateTime(int.Parse(Data_chess[Data_chess.Count-1].Date.Substring(0,4)),int.Parse(Data_chess[Data_chess.Count - 1].Date.Substring(4, 2)),int.Parse(Data_chess[Data_chess.Count - 1].Date.Substring(6, 2)));
            startime = new DateTime(int.Parse(Data_chess[0].Date.Substring(0, 4)), int.Parse(Data_chess[0].Date.Substring(4, 2)), int.Parse(Data_chess[0].Date.Substring(6, 2)));
            DateTime mind = new DateTime();
            DateTime maxd = new DateTime();
            mind = new DateTime(2000,1,1);
            maxd = new DateTime(2020, 1, 1);
            dateTimePicker1.MinDate = mind;
            dateTimePicker1.MaxDate = maxd;
            dateTimePicker2.MinDate = mind;
            dateTimePicker2.MaxDate = maxd;
            dateTimePicker1.MinDate = startime;
            dateTimePicker1.MaxDate = endtime;
            dateTimePicker2.MinDate = startime;
            dateTimePicker2.MaxDate = endtime;
            startime = new DateTime(int.Parse(Data_chess[(wrong_count-1)*5].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(6, 2)));
            endtime = new DateTime(int.Parse(Data_chess[(wrong_count -1) * 5+4].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count -1) * 5+4].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5+4].Date.Substring(6, 2)));
            dateTimePicker1.Value = startime;
            dateTimePicker2.Value = endtime;
        }

        void wrongvaluefunction(string ID , ref Wrong wr)
        {
            switch (ID)
            {
                case "1":
                    wr.B++;
                    wr.C++;
                    wr.D += 2;
                    wr.F++;
                    break;
                case "2":
                    wr.B++;
                    wr.C++;
                    wr.D += 3;
                    wr.E++;
                    wr.F++;
                    break;
                case "3":
                    wr.A++;
                    wr.B++;
                    wr.C++;
                    wr.D++;
                    wr.F++;
                    break;
                case "4":
                    wr.B+=3;
                    break;
                case "5":
                    wr.B+=2;
                    wr.D++;
                    wr.E++;
                    wr.F++;
                    break;
                case "6":
                    wr.B += 2;
                    break;
                case "7":
                    wr.C += 2;
                    wr.D += 2;
                    break;
                case "8":
                    wr.A+=2;
                    wr.B++;
                    wr.F+=2;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            wrong_count = trackBar1.Value;
            label3.Text = "第"+wrong_count+"筆資料，共"+ trackBar1.Maximum+"筆";

            startime = new DateTime(int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(6, 2)));
            endtime = new DateTime(int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(6, 2)));
            dateTimePicker1.Value = startime;
            dateTimePicker2.Value = endtime;

            int count_start = Data_chess.FindIndex(x => x.Date.Substring(0, 4) == startime.Year.ToString() && x.Date.Substring(4, 2) == startime.Month.ToString("00") && x.Date.Substring(6, 2) == startime.Day.ToString("00"));
            int count_end = Data_chess.FindIndex(x => x.Date.Substring(0, 4) == endtime.Year.ToString() && x.Date.Substring(4, 2) == endtime.Month.ToString("00") && x.Date.Substring(6, 2) == endtime.Day.ToString("00"));
            int num = count_end - count_start + 1;

            Wrong wrong_value = new Wrong();

            if (comboBox1.Text != "All Index")
            {
                chart5.Series[0].Points.Clear();
                chart5.Series[1].Points.Clear();
                chart5.Show();
                chart4.Hide();
                if (comboBox1.Text == "Calculation")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.A / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.A / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Attention")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.B / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.B/(double)normal_count,2));
                    }
                }
                else if (comboBox1.Text == "Memory")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.C / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.C / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Judgment")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.D / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.D / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Speak and Behavior")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.E / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.E / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Constructed")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.F / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.F / (double)normal_count, 2));
                    }
                }
            }
            else
            {

                wrong_value = new Wrong();
                for (int i = wrong_count - 1; i < wrong_count; i++)
                {
                    if (wrong_count * 5 > wrong_id_list.Count) break;
                    for (int j = i * 5; j < i * 5 + 5; j++)
                    {
                        for (int ww = 0; ww < wrong_id_list[j].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[j][ww], ref wrong_value);
                        }
                    }
                }

                chart4.Series[0].Points.Clear();
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.A / (double)5));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.B / (double)5));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.C / (double)5));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.D / (double)5));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.E / (double)5));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.F / (double)5));

                chart4.Series[1].Points.Clear();
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.A / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.B / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.C / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.D / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.E / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.F / normal_count, 2));
               

                chart4.Show();
                chart5.Hide();

                startime = new DateTime(int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(6, 2)));
                endtime = new DateTime(int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(6, 2)));
                dateTimePicker1.Value = startime;
                dateTimePicker2.Value = endtime;


            }


            //wrong_id_list = new List<List<string>>();
            //foreach (var a in Data_chess)
            //{
            //    string chess_ID = a.ID;

            //    DataTable dt = sqlc.wrong_search(chess_ID);
            //    wrong_id_list.Add(new List<string>());
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        wrong_id_list[wrong_id_list.Count - 1].Add(dr["Wrong_ID"].ToString());
            //    }

            //}
            //AVG
            //Wrong wrong_value = new Wrong();
            //for (int i = 0; i < wrong_count; i++)
            //{
            //    if (wrong_count * 5 > wrong_id_list.Count) break;
            //    for (int j = i * 5; j < i * 5 + 5; j++)
            //    {
            //        for (int ww = 0; ww < wrong_id_list[j].Count; ww++)
            //        {
            //            wrongvaluefunction(wrong_id_list[j][ww], ref wrong_value);
            //        }
            //    }
            //}
            //chart4.Series[0].Points.Clear();
            //chart4.Series[0].Points.AddY((double)wrong_value.A / (double)wrong_count * 5);
            //chart4.Series[0].Points.AddY((double)wrong_value.B / (double)wrong_count * 5);
            //chart4.Series[0].Points.AddY((double)wrong_value.C / (double)wrong_count * 5);
            //chart4.Series[0].Points.AddY((double)wrong_value.D / (double)wrong_count * 5);
            //chart4.Series[0].Points.AddY((double)wrong_value.E / (double)wrong_count * 5);
            //chart4.Series[0].Points.AddY((double)wrong_value.F / (double)wrong_count * 5);

            //chart4.Series[1].Points.Clear();
            //chart4.Series[1].Points.AddY((double)wrong_value.A / (double)wrong_count * 5 - (double)Normal.A / normal_count*5);
            //chart4.Series[1].Points.AddY((double)wrong_value.B / (double)wrong_count * 5 - (double)Normal.B / normal_count*5);
            //chart4.Series[1].Points.AddY((double)wrong_value.C / (double)wrong_count * 5 - (double)Normal.C / normal_count*5);
            //chart4.Series[1].Points.AddY((double)wrong_value.D / (double)wrong_count * 5 - (double)Normal.D / normal_count*5);
            //chart4.Series[1].Points.AddY((double)wrong_value.E / (double)wrong_count * 5 - (double)Normal.E / normal_count*5);
            //chart4.Series[1].Points.AddY((double)wrong_value.F / (double)wrong_count * 5 - (double)Normal.F / normal_count*5);
            //Only5
            //Wrong wrong_value = new Wrong();
            //for (int i = wrong_count - 1; i < wrong_count; i++)
            //{
            //    if (wrong_count * 5 > wrong_id_list.Count) break;
            //    for (int j = i * 5; j < i * 5 + 5; j++)
            //    {
            //        for (int ww = 0; ww < wrong_id_list[j].Count; ww++)
            //        {
            //            wrongvaluefunction(wrong_id_list[j][ww], ref wrong_value);
            //        }
            //    }
            //}
            //chart4.Series[0].Points.Clear();
            //chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.A / (double)5));
            //chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.B / (double)5));
            //chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.C / (double)5));
            //chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.D / (double)5));
            //chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.E / (double)5));
            //chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.F / (double)5));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

            //chart4.Series[1].Points.Clear();
            //chart4.Series[1].Points.AddY(Math.Round((double)Normal.A / normal_count, 2));
            //chart4.Series[1].Points.AddY(Math.Round((double)Normal.C / normal_count, 2));
            //chart4.Series[1].Points.AddY(Math.Round((double)Normal.D / normal_count, 2));
            //chart4.Series[1].Points.AddY(Math.Round((double)Normal.E / normal_count, 2));
            //chart4.Series[1].Points.AddY(Math.Round((double)Normal.F / normal_count, 2));
            //chart4.Series[1].Points.AddY(Math.Round((double)Normal.B / normal_count, 2));



            ////chart4.Series[1].Points.Clear();
            ////chart4.Series[1].Points.AddY((double)wrong_value.A / (double)5 - (double)Normal.A / (double)normal_count);
            ////chart4.Series[1].Points.AddY((double)wrong_value.B / (double)5 - (double)Normal.B / (double)normal_count);
            ////chart4.Series[1].Points.AddY((double)wrong_value.C / (double)5 - (double)Normal.C / (double)normal_count);
            ////chart4.Series[1].Points.AddY((double)wrong_value.D / (double)5 - (double)Normal.D / (double)normal_count);
            ////chart4.Series[1].Points.AddY((double)wrong_value.E / (double)5 - (double)Normal.E / (double)normal_count);
            ////chart4.Series[1].Points.AddY((double)wrong_value.F / (double)5 - (double)Normal.F / (double)normal_count);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            button2.PerformClick();
        }

        private void chart4_Click(object sender, EventArgs e)
        {
            startime = dateTimePicker1.Value;
            endtime = dateTimePicker2.Value;
            int count_start = Data_chess.FindIndex(x => x.Date.Substring(0, 4) == startime.Year.ToString() && x.Date.Substring(4, 2) == startime.Month.ToString("00") && x.Date.Substring(6, 2) == startime.Day.ToString("00"));
            int count_end = Data_chess.FindIndex(x => x.Date.Substring(0, 4) == endtime.Year.ToString() && x.Date.Substring(4, 2) == endtime.Month.ToString("00") && x.Date.Substring(6, 2) == endtime.Day.ToString("00"));
            int num = count_end - count_start + 1;

            Wrong wrong_value = new Wrong();

            if (comboBox1.Text != "All Index")
            {
                chart5.Series[0].Points.Clear();
                chart5.Series[1].Points.Clear();
                chart5.Show();
                chart4.Hide();
                if (comboBox1.Text == "Calculation")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.A / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.A / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Attention")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.B / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.B / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Memory")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.C / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.C / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Judgment")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.D / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.D / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Speak and Behavior")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.E / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.E / (double)normal_count, 2));
                    }
                }
                else if (comboBox1.Text == "Constructed")
                {
                    wrong_value = new Wrong();
                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                        chart5.Series[0].Points.Add(Math.Round(wrong_value.F / ((i + 1) - count_start), 2));
                        chart5.Series[1].Points.Add(Math.Round(Normal.F / (double)normal_count, 2));
                    }
                }
            }
            else
            {

                for (int i = count_start; i < count_end + 1; i++)
                {
                    for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                    {
                        wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                    }
                }

                chart4.Show();
                chart5.Hide();

                chart4.Series[0].Points.Clear();
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.A / (double)num,2));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.B / (double)num,2));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.C / (double)num,2));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.D / (double)num,2));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.E / (double)num,2));
                chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.F / (double)num, 2));

                chart4.Series[1].Points.Clear();
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.A / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.B / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.C / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.D / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.E / normal_count, 2));
                chart4.Series[1].Points.AddY(Math.Round((double)Normal.F / normal_count, 2));



            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (chart4.Series[0].Points.Count == 0) return;
            startime = dateTimePicker1.Value;
            endtime = dateTimePicker2.Value;

            int count_start = Data_chess.FindIndex(x => x.Date.Substring(0, 4) == startime.Year.ToString() && x.Date.Substring(4, 2) == startime.Month.ToString("00") && x.Date.Substring(6, 2) == startime.Day.ToString("00"));
            int count_end = Data_chess.FindIndex(x => x.Date.Substring(0, 4) == endtime.Year.ToString() && x.Date.Substring(4, 2) == endtime.Month.ToString("00") && x.Date.Substring(6, 2) == endtime.Day.ToString("00"));
            int num = count_end - count_start + 1;

            Wrong wrong_value = new Wrong();

                if (comboBox1.Text != "All Index")
                {
                    chart5.Series[0].Points.Clear();
                    chart5.Series[1].Points.Clear();
                    chart5.Show();
                    chart4.Hide();
                    if (comboBox1.Text == "Calculation")
                    {
                        wrong_value = new Wrong();
                        for (int i = count_start; i < count_end + 1; i++)
                        {
                            for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                            {
                                wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                            }
                            chart5.Series[0].Points.Add(Math.Round(wrong_value.A / ((i + 1) - count_start), 2));
                            chart5.Series[1].Points.Add(Math.Round(Normal.A / (double)normal_count, 2));
                        }
                    }
                    else if (comboBox1.Text == "Attention")
                    {
                        wrong_value = new Wrong();
                        for (int i = count_start; i < count_end + 1; i++)
                        {
                            for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                            {
                                wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                            }
                            chart5.Series[0].Points.Add(Math.Round(wrong_value.B / ((i + 1) - count_start), 2));
                            chart5.Series[1].Points.Add(Math.Round(Normal.B / (double)normal_count, 2));
                        }
                    }
                    else if (comboBox1.Text == "Memory")
                    {
                        wrong_value = new Wrong();
                        for (int i = count_start; i < count_end + 1; i++)
                        {
                            for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                            {
                                wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                            }
                            chart5.Series[0].Points.Add(Math.Round(wrong_value.C / ((i + 1) - count_start), 2));
                            chart5.Series[1].Points.Add(Math.Round(Normal.C / (double)normal_count, 2));
                        }
                    }
                    else if (comboBox1.Text == "Judgment")
                    {
                        wrong_value = new Wrong();
                        for (int i = count_start; i < count_end + 1; i++)
                        {
                            for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                            {
                                wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                            }
                            chart5.Series[0].Points.Add(Math.Round(wrong_value.D / ((i + 1) - count_start), 2));
                            chart5.Series[1].Points.Add(Math.Round(Normal.D / (double)normal_count, 2));
                        }
                    }
                    else if (comboBox1.Text == "Speak and Behavior")
                    {
                        wrong_value = new Wrong();
                        for (int i = count_start; i < count_end + 1; i++)
                        {
                            for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                            {
                                wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                            }
                            chart5.Series[0].Points.Add(Math.Round(wrong_value.E / ((i + 1) - count_start), 2));
                            chart5.Series[1].Points.Add(Math.Round(Normal.E / (double)normal_count, 2));
                        }
                    }
                    else if (comboBox1.Text == "Constructed")
                    {
                        wrong_value = new Wrong();
                        for (int i = count_start; i < count_end + 1; i++)
                        {
                            for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                            {
                                wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                            }
                            chart5.Series[0].Points.Add(Math.Round(wrong_value.F / ((i + 1) - count_start), 2));
                            chart5.Series[1].Points.Add(Math.Round(Normal.F / (double)normal_count, 2));
                        }
                    }
                }
                else
                {

                    for (int i = count_start; i < count_end + 1; i++)
                    {
                        for (int ww = 0; ww < wrong_id_list[i].Count; ww++)
                        {
                            wrongvaluefunction(wrong_id_list[i][ww], ref wrong_value);
                        }
                    }

                    chart4.Show();
                    chart5.Hide();

                    chart4.Series[0].Points.Clear();
                    chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.A / (double)num));
                    chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.B / (double)num));
                    chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.C / (double)num));
                    chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.D / (double)num));
                    chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.E / (double)num));
                    chart4.Series[0].Points.AddY(Math.Round((double)wrong_value.F / (double)num));

                    chart4.Series[1].Points.Clear();
                    chart4.Series[1].Points.AddY(Math.Round((double)Normal.A / normal_count, 2));
                    chart4.Series[1].Points.AddY(Math.Round((double)Normal.B / normal_count, 2));
                    chart4.Series[1].Points.AddY(Math.Round((double)Normal.C / normal_count, 2));
                    chart4.Series[1].Points.AddY(Math.Round((double)Normal.D / normal_count, 2));
                    chart4.Series[1].Points.AddY(Math.Round((double)Normal.E / normal_count, 2));
                    chart4.Series[1].Points.AddY(Math.Round((double)Normal.F / normal_count, 2));



                    startime = new DateTime(int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5].Date.Substring(6, 2)));
                    endtime = new DateTime(int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(0, 4)), int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(4, 2)), int.Parse(Data_chess[(wrong_count - 1) * 5 + 4].Date.Substring(6, 2)));
                    dateTimePicker1.Value = startime;
                    dateTimePicker2.Value = endtime;
                }
            }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }

}
class C_D
{
    public string ID;
    public int win { get; set; }
    public int time { get; set; }
    public int wrong { get; set; }
    public string Date { get; set; }
    public int AI_Mode { get; set; }
    public int Done { get; set; }
    public int Remember { get; set; }
    public string Player_ID { get; set; }
}
class Wrong
{
    public double A;//計算力
    public double B;//Attention
    public double C;//Memory
    public double D;//Judgment
    public double E;//Speak and Behavior能力
    public double F;//Constructed
}
