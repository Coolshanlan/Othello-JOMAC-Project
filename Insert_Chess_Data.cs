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
    public partial class Insert_Chess_Data : Form
    {
        DataTable Player_Data = new DataTable();
        public Insert_Chess_Data(DataTable dt)
        {
            InitializeComponent();
            Player_Data = dt;
        }

        private void Insert_Chess_Data_Load(object sender, EventArgs e)
        {

        }
        string chess_date = "";
        int time = 0;
        int wrong =0;
        int AI_Mode=0 ;
        int Win=0 ;
        int Done = 0;
        string Next_Date = "";
        int Period = 0;
        sqlclass sqlc = new sqlclass();
        double[] wro = new double[8+1];
        double AW = 0.0;//下棋錯誤
        double BW = 0.0;//錯誤後再錯誤
        double CW = 0.0;//翻棋錯誤
        double DW = 0.0;//提早棄局
        double EW = 0.0;//時間過長
        double FW = 0.0;//時間過短
        double GW = 0.0;//不知道誰贏
        double HW = 0.0;//算不出棋子
        int click_times = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            click_times++;
            Random rd = new Random();
            double num = 4;
            double num2 = 0.25;
            data_update();
            Done = rd.Next(0, 8);
            Win = rd.Next(0,2);
            int remember = 0;
            //if (Player_Data.Rows[0][7].ToString() == "")
            //{
            //    remember = 1;
            //}
            //else
            //{
            //    if (int.Parse(Player_Data.Rows[0][7].ToString()) > int.Parse(chess_date))
            //    {
            //        remember = 1;
            //    }
            //    else if (int.Parse(Player_Data.Rows[0][7].ToString()) == int.Parse(chess_date) && Period == int.Parse(Player_Data.Rows[0][8].ToString()))
            //    {
            //        remember = 1;
            //    }
            //    else
            //    {
            //        remember = 0;
            //    }
            //}
            remember = 0;
            if (Done > 1) Done = 1;
            Next_Date = textBox7.Text;
            wrong = rd.Next(Convert.ToInt16(wrong-num*(double)wrong*3), Convert.ToInt16(wrong+num * (double)wrong+3 ));
            if (wrong < 0) wrong = 0;
            time = rd.Next(Convert.ToInt16(time - num2 * (double)time), Convert.ToInt16(time + num2 * (double)time) + 1);
            if (time < 30) Done = 0;
            sqlc.Done_Game(Player_Data.Rows[0]["ID"].ToString(), Win, time, wrong, chess_date, AI_Mode, Done, remember);
            sqlc.Next_Game(int.Parse(Player_Data.Rows[0]["ID"].ToString()),chess_date,Period.ToString());
            textBox8.Text = chess_date + "   " + time + "    " + wrong + "   " + AI_Mode + "   " + Win + "   " + Done + "   " + Next_Date;

            wro[1] = 0.2;
            wro[2] = 0.27;
            wro[3] = 1;

            List<int> wrong_list = new List<int>(); 
            if(wrong != 0)
            for(int i = 0; i < wrong; i++)
            {
                    double rdn = rd.NextDouble();
                    for(int j = 1; j < wro.Count(); j++)
                    {
                        if (rdn < wro[j])
                        {
                            wrong_list.Add(j);
                            break;
                        }
                    }
            }
            //if(Done == 1)
            //{
            //    if (rd.NextDouble() > 0.5)
            //}
            string Game_ID = sqlc.ToTable("select chess.ID from lar_lan.chess order by chess.ID DESC LIMIT 1").Rows[0][0].ToString();
            foreach(var a in wrong_list)
            {
                sqlc.Wrong_Insert(Game_ID,a.ToString());
            }


           // for(int i=0;i<)

        }

        public void data_update()
        {
            DateTime dt = DateTime.Now.AddDays(click_times);
            dt.AddDays(click_times);
            //chess_date = DateTime.Now.AddDays(click_times);

            chess_date = (dt.Year-1) + "" + dt.Month.ToString("00") + "" + dt.Day.ToString("00") + "";
            textBox1.Text = chess_date;
            Done = int.Parse(textBox6.Text);
            Win = int.Parse(textBox5.Text);
            AI_Mode = int.Parse(textBox4.Text);
            time = int.Parse(textBox2.Text);
            wrong = int.Parse(textBox3.Text);
            Period = int.Parse(textBox9.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            click_times++;
            Random rd = new Random();
            double num = 15;
            double num2 = 0.92;
            data_update();
            Done = rd.Next(0,2);
            int remember = 0;
            //if (Player_Data.Rows[0][7].ToString() == "")
            //{
            //    remember = 1;
            //}
            //else
            //{
            //    if (int.Parse(Player_Data.Rows[0][7].ToString()) > int.Parse(chess_date))
            //    {
            //        remember = 1;
            //    }
            //    else if (int.Parse(Player_Data.Rows[0][7].ToString()) == int.Parse(chess_date) && Period == int.Parse(Player_Data.Rows[0][8].ToString()))
            //    {
            //        remember = 1;
            //    }
            //    else
            //    {
            //        remember = 0;
            //    }
            //}
            remember = 0;
            Next_Date = textBox7.Text;
            wrong = rd.Next(Convert.ToInt16(num * (double)wrong - num * (double)wrong * 0.65), Convert.ToInt16(wrong + num * (double)wrong + 3));
            if (wrong < 0) wrong = 0;
            time = rd.Next(Convert.ToInt16(time - num2 * (double)time), Convert.ToInt16(time + num2 * (double)time) + 1);
            if (time < 30) Done = 0;
            sqlc.Done_Game(Player_Data.Rows[0]["ID"].ToString(), Win, time, wrong, chess_date, AI_Mode, Done, remember);
            sqlc.Next_Game(int.Parse(Player_Data.Rows[0]["ID"].ToString()), chess_date, Period.ToString());
            textBox8.Text = chess_date + "   " + time + "    " + wrong + "   " + AI_Mode + "   " + Win + "   " + Done + "   " + Next_Date;

            wro[1] = 0.3;
            wro[2] = 0.5;
            wro[3] = 1;
            List<int> wrong_list = new List<int>();
            if (wrong != 0)
                for (int i = 0; i < wrong; i++)
                {
                    double rdn = rd.NextDouble();
                    for (int j = 1; j < wro.Count(); j++)
                    {
                        if (rdn < wro[j])
                        {
                            wrong_list.Add(j);
                            break;
                        }
                    }
                }

            if(Done == 1)
            {
                //double rdn = rd.NextDouble();

                if (time > 70) wrong_list.Add(5);
                if (time < 25) wrong_list.Add(6);
                if (rd.NextDouble() > 0.6) wrong_list.Add(7);
                if (rd.NextDouble() > 0.7) wrong_list.Add(8);

            }
            else
            {
                wrong_list.Add(4);
            }
            string Game_ID = sqlc.ToTable("select chess.ID from lar_lan.chess order by chess.ID DESC LIMIT 1").Rows[0][0].ToString();

            foreach (var a in wrong_list)
            {
                sqlc.Wrong_Insert(Game_ID, a.ToString());
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            click_times++;
            Random rd = new Random();
            double num = 5;
            double num2 = 0.92;
            data_update();

            int remember = 0;
            //if (Player_Data.Rows[0][7].ToString() == "")
            //{
            //    remember = 1;
            //}
            //else
            //{
            //    if (int.Parse(Player_Data.Rows[0][7].ToString()) > int.Parse(chess_date))
            //    {
            //        remember = 1;
            //    }
            //    else if (int.Parse(Player_Data.Rows[0][7].ToString()) == int.Parse(chess_date) && Period == int.Parse(Player_Data.Rows[0][8].ToString()))
            //    {
            //        remember = 1;
            //    }
            //    else
            //    {
            //        remember = 0;
            //    }
            //}
            remember = 0;
            Next_Date = textBox7.Text;
            wrong = rd.Next((0), Convert.ToInt16(wrong + num * (double)wrong + 1));
            if (wrong < 0) wrong = 0;
            time = rd.Next(Convert.ToInt16(time - num2 * (double)time), 20);
            if (time < 30) Done = 0;
            sqlc.Done_Game(Player_Data.Rows[0]["ID"].ToString(), Win, time, wrong, chess_date, AI_Mode, Done, remember);
            sqlc.Next_Game(int.Parse(Player_Data.Rows[0]["ID"].ToString()), chess_date, Period.ToString());
            textBox8.Text = chess_date + "   " + time + "    " + wrong + "   " + AI_Mode + "   " + Win + "   " + Done + "   " + Next_Date;


            wro[1] = 0.5;
            wro[2] = 0.7;
            wro[3] = 1;
            List<int> wrong_list = new List<int>();
            if (wrong != 0)
                for (int i = 0; i < wrong; i++)
                {
                    double rdn = rd.NextDouble();
                    for (int j = 1; j < wro.Count(); j++)
                    {
                        if (rdn < wro[j])
                        {
                            wrong_list.Add(j);
                            break;
                        }
                    }
                }

            if (Done == 1)
            {
                //double rdn = rd.NextDouble();

                if (time > 70) wrong_list.Add(5);
                if (time < 25) wrong_list.Add(6);
                if (rd.NextDouble() > 0.6) wrong_list.Add(7);
                if (rd.NextDouble() > 0.7) wrong_list.Add(8);

            }
            else
            {
                wrong_list.Add(4);
            }
            string Game_ID = sqlc.ToTable("select chess.ID from lar_lan.chess order by chess.ID DESC LIMIT 1").Rows[0][0].ToString();

            foreach (var a in wrong_list)
            {
                sqlc.Wrong_Insert(Game_ID, a.ToString());
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            click_times++;
            Random rd = new Random();
            double num = 35;
            double num2 = 0.75;
            data_update();
            Win = rd.Next(0, 2);
            int remember = 0;
            //if (Player_Data.Rows[0][7].ToString() == "")
            //{
            //    remember = 1;
            //}
            //else
            //{
            //    if (int.Parse(Player_Data.Rows[0][7].ToString()) > int.Parse(chess_date))
            //    {
            //        remember = 1;
            //    }
            //    else if (int.Parse(Player_Data.Rows[0][7].ToString()) == int.Parse(chess_date) && Period == int.Parse(Player_Data.Rows[0][8].ToString()))
            //    {
            //        remember = 1;
            //    }
            //    else
            //    {
            //        remember = 0;
            //    }
            //}
            remember = 0;
            Next_Date = textBox7.Text;
            wrong = rd.Next(Convert.ToInt16(num * (double)wrong - num * (double)wrong * 0.3), Convert.ToInt16(wrong + num * (double)wrong + 1));
            if (wrong < 0) wrong = 0;
            time = rd.Next(time, Convert.ToInt16(time + num2 * (double)time) + 1);
            if (time < 30) Done = 0;
            sqlc.Done_Game(Player_Data.Rows[0]["ID"].ToString(), Win, time, wrong, chess_date, AI_Mode, Done, remember);
            sqlc.Next_Game(int.Parse(Player_Data.Rows[0]["ID"].ToString()), chess_date, Period.ToString());
            textBox8.Text = chess_date + "   " + time + "    " + wrong + "   " + AI_Mode + "   " + Win + "   " + Done + "   " + Next_Date;




            wro[1] = 0.5;
            wro[2] = 0.85;
            wro[3] = 1;
            List<int> wrong_list = new List<int>();
            if (wrong != 0)
                for (int i = 0; i < wrong; i++)
                {
                    double rdn = rd.NextDouble();
                    for (int j = 1; j < wro.Count(); j++)
                    {
                        if (rdn < wro[j])
                        {
                            wrong_list.Add(j);
                            break;
                        }
                    }
                }

            if (Done == 1)
            {
                //double rdn = rd.NextDouble();

                if (time > 65) wrong_list.Add(5);
                if (time < 25) wrong_list.Add(6);
                if (rd.NextDouble() > 0.6) wrong_list.Add(7);
                if (rd.NextDouble() > 0.7) wrong_list.Add(8);

            }
            else
            {
                wrong_list.Add(4);
            }
            string Game_ID = sqlc.ToTable("select chess.ID from lar_lan.chess order by chess.ID DESC LIMIT 1").Rows[0][0].ToString();

            foreach (var a in wrong_list)
            {
                sqlc.Wrong_Insert(Game_ID, a.ToString());
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            click_times++;
            Random rd = new Random();
            double num = 25;
            double num2 = 0.8;
            data_update();
            Win = rd.Next(0, 2);
            Done = 0;
            int remember = 0;
            //if (Player_Data.Rows[0][7].ToString() == "")
            //{
            //    remember = 1;
            //}
            //else
            //{
            //    if (int.Parse(Player_Data.Rows[0][7].ToString()) > int.Parse(chess_date))
            //    {
            //        remember = 1;
            //    }
            //    else if (int.Parse(Player_Data.Rows[0][7].ToString()) == int.Parse(chess_date) && Period == int.Parse(Player_Data.Rows[0][8].ToString()))
            //    {
            //        remember = 1;
            //    }
            //    else
            //    {
            //        remember = 0;
            //    }
            //}
            remember = 0;
            Next_Date = textBox7.Text;
            wrong = rd.Next(Convert.ToInt16( num * (double)wrong  - num * (double)wrong * 0.3), Convert.ToInt16(wrong + num * (double)wrong + 1));
            if (wrong < 0) wrong = 0;
            time = rd.Next(Convert.ToInt16(time - num2 * (double)time), 30);
            if (time < 30) Done = 0;
            sqlc.Done_Game(Player_Data.Rows[0]["ID"].ToString(), Win, time, wrong, chess_date, AI_Mode, Done, remember);
            sqlc.Next_Game(int.Parse(Player_Data.Rows[0]["ID"].ToString()), chess_date, Period.ToString());
            textBox8.Text = chess_date + "   " + time + "    " + wrong + "   " + AI_Mode + "   " + Win + "   " + Done + "   " + Next_Date;



            wro[1] = 0.4;
            wro[2] = 0.75;
            wro[3] = 1;
            List<int> wrong_list = new List<int>();
            if (wrong != 0)
                for (int i = 0; i < wrong; i++)
                {
                    double rdn = rd.NextDouble();
                    for (int j = 1; j < wro.Count(); j++)
                    {
                        if (rdn < wro[j])
                        {
                            wrong_list.Add(j);
                            break;
                        }
                    }
                }

            if (Done == 1)
            {
                //double rdn = rd.NextDouble();

                if (time > 70) wrong_list.Add(5);
                if (time < 25) wrong_list.Add(6);
                if (rd.NextDouble() > 0.6) wrong_list.Add(7);
                if (rd.NextDouble() > 0.7) wrong_list.Add(8);

            }
            else
            {
                wrong_list.Add(4);
            }
            string Game_ID = sqlc.ToTable("select chess.ID from lar_lan.chess order by chess.ID DESC LIMIT 1").Rows[0][0].ToString();

            foreach (var a in wrong_list)
            {
                sqlc.Wrong_Insert(Game_ID, a.ToString());
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            click_times++;
            Random rd = new Random();
            double num = 7;
            double num2 = 0.67;
            data_update();
            Done = rd.Next(0,4);
            Win = rd.Next(0, 2);
            int remember = 0;
            //if (Player_Data.Rows[0][7].ToString() == "")
            //{
            //    remember = 1;
            //}
            //else
            //{
            //    if (int.Parse(Player_Data.Rows[0][7].ToString()) > int.Parse(chess_date))
            //    {
            //        remember = 1;
            //    }
            //    else if (int.Parse(Player_Data.Rows[0][7].ToString()) == int.Parse(chess_date) && Period == int.Parse(Player_Data.Rows[0][8].ToString()))
            //    {
            //        remember = 1;
            //    }
            //    else
            //    {
            //        remember = 0;
            //    }
            //}
            remember = 0;
            if (Done > 1) Done = 1;
            Next_Date = textBox7.Text;
            wrong = rd.Next(Convert.ToInt16(0)-2, Convert.ToInt16(wrong + num * (double)wrong + 1));
            if (wrong < 0) wrong = 0;
            time = rd.Next(Convert.ToInt16(time - num2 * (double)time), Convert.ToInt16(time + num2 * (double)time) + 1);
            if (time < 30) Done = 0;
            sqlc.Done_Game(Player_Data.Rows[0]["ID"].ToString(), Win, time, wrong, chess_date, AI_Mode, Done, remember);
            sqlc.Next_Game(int.Parse(Player_Data.Rows[0]["ID"].ToString()), chess_date, Period.ToString());
            textBox8.Text = chess_date + "   " + time + "    " + wrong + "   " + AI_Mode + "   " + Win + "   " + Done + "   " + Next_Date;




            wro[1] = 0.35;
            wro[2] = 0.5;
            wro[3] = 1;
            List<int> wrong_list = new List<int>();
            if (wrong != 0)
                for (int i = 0; i < wrong; i++)
                {
                    double rdn = rd.NextDouble();
                    for (int j = 1; j < wro.Count(); j++)
                    {
                        if (rdn < wro[j])
                        {
                            wrong_list.Add(j);
                            break;
                        }
                    }
                }

            if (Done == 1)
            {
                //double rdn = rd.NextDouble();

                if (time > 70) wrong_list.Add(5);
                if (time < 25) wrong_list.Add(6);
                if (rd.NextDouble() > 0.75) wrong_list.Add(7);
                if (rd.NextDouble() > 0.85) wrong_list.Add(8);

            }
            else
            {
                wrong_list.Add(4);
            }
            string Game_ID = sqlc.ToTable("select chess.ID from lar_lan.chess order by chess.ID DESC LIMIT 1").Rows[0][0].ToString();

            foreach (var a in wrong_list)
            {
                sqlc.Wrong_Insert(Game_ID, a.ToString());
            }


        }
    }
}
