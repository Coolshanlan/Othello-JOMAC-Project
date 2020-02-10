using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;


namespace 黑白棋
{
    class information_todownchess
    {
        public string endstring = "";
        public bool Ai_Done = false;
        public  List<Point> downpoint {get;set;}
        public  List<Chess_Towplayer> Chess { get; set; }
        public  int white { get; set; }
        public  int black { get; set; }
        public  List<Check_Point> auto_check_point { get; set; }
        public  List<Point> All_candown { get; set; }
        public string chess_playbook { get; set; }
    }
    class ToDownChess
    {
        public static List<Check_Point> auto_check_point = new List<Check_Point>();
        public static int end = 0;
        public static int chess = 0;
        public static bool endgame = false;
        public static int chesscount = 0;
        public static int black=2, white=2;
        public static List<Point> downpoint = new List<Point>();
        public static List<Chess_Towplayer> Chess = new List<Chess_Towplayer>();
        public static DownChess dd = new DownChess();
        public static bool change_no = false;
        public static bool change = false;
        public static string chess_playbook_Go = "";
        public static List<Point> All_candown = new List<Point>();
        public static information_todownchess information_now = new information_todownchess(); 
        public static DownChess Chess_Down(List<Chess_Towplayer> Chesss,int downX,int downY,int color,int nowblack,int nowwhite)
        {
            information_now = new information_todownchess();
            chess_playbook_Go = "";
            All_candown = new List<Point>();
            auto_check_point = new List<Check_Point>();
            endgame = false;
            change = false;
            downpoint = new List<Point>();
            Chess = new List<Chess_Towplayer>();
            Chess = Chesss;
            chess = color;
            black = nowblack;
            white = nowwhite;
            end = 0;
            if(chess%2 == 0)
            {
                black++;
            }
            else
            {
                white++;
            }
            //------------------------//
            downpoint.Add(new Point(downX,downY));
            Chess[downX * 8 + downY].chess_change = 0;
            Chess[downX * 8 + downY].chess_color = chess % 2 + 1;
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, 0);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 0, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 0, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, 0);
            chess++;
            chess_Change_count();
            int[,] tt = new int[8,8];
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chess_playbook_Go += Chess[i * 8 + j].chess_color.ToString();
                    tt[i, j] = Chess[i * 8 + j].chess_color;
                    if (Chess[i * 8 + j].chess_color != 0) auto_check_point.Add(new Check_Point { x=i,y=j,color = Chess[i*8+j].chess_color});
                    if (Chess[i * 8 + j].chess_change != 0) All_candown.Add(new Point(){X =i,Y=j});
                }
            }
            information_now.black = black;
            information_now.Chess = ((Chess_Towplayer[])(Chess.ToArray().Clone())).ToList() ;
            information_now.downpoint = downpoint;
            information_now.white = white;
            information_now.auto_check_point = auto_check_point;
            information_now.All_candown = All_candown;
            information_now.chess_playbook = chess_playbook_Go;
            dd.chessarray = tt;
            dd.point = downpoint;
            ToArm(dd.point);
            return dd;
        }

        public static string Chess_Down_nochange(List<Chess_Towplayer> Chesss, int downX, int downY, int color, int nowblack, int nowwhite)
        {
            chess_playbook_Go = "";
            All_candown = new List<Point>();
            auto_check_point = new List<Check_Point>();
            endgame = false;
            change_no = false;
            downpoint = new List<Point>();
            Chess = new List<Chess_Towplayer>();



            Chess = ((Chess_Towplayer[])(Chesss.ToArray().Clone())).ToList();
            chess = color;
            black = nowblack;
            white = nowwhite;
            end = 0;
            if (chess % 2 == 0)
            {
                black++;
            }
            else
            {
                white++;
            }
            //------------------------//
            downpoint.Add(new Point(downX, downY));
            Chess[downX * 8 + downY].chess_change = 0;
            Chess[downX * 8 + downY].chess_color = chess % 2 + 1;
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, 0);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 0, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 0, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, 0);
            chess++;
            chess_Change_count();
            string chess_playbook_string = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chess_playbook_string += Chess[i * 8 + j].chess_color.ToString();
                }
            }
            change = false;
            return chess_playbook_string;
        }

        public static string Chess_Down( int downX, int downY, int color)
        {
            chess_playbook_Go = "";
            All_candown = new List<Point>();
            auto_check_point = new List<Check_Point>();
            endgame = false;
            change = false;
            change_no = false;
            downpoint = new List<Point>();
            end = 0;
            chess = color;
            if (chess % 2 == 0)
            {
                black++;
            }
            else
            {
                white++;
            }
            //------------------------//
            downpoint.Add(new Point(downX, downY));
            Chess[downX * 8 + downY].chess_change = 0;
            Chess[downX * 8 + downY].chess_color = chess % 2 + 1;
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, 0);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 1, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 0, 1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, 0, -1);
            chess_Change(Chess[downX * 8 + downY].chess_color, downX, downY, -1, 0);
            chess++;
            chess_Change_count();
            int[,] tt = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chess_playbook_Go += Chess[i * 8 + j].chess_color.ToString();
                    tt[i, j] = Chess[i * 8 + j].chess_color;
                    if (Chess[i * 8 + j].chess_color != 0) auto_check_point.Add(new Check_Point { x = i, y = j, color = Chess[i * 8 + j].chess_color });
                    if (Chess[i * 8 + j].chess_change != 0) All_candown.Add(new Point() { X = i, Y = j });
                }
            }
            return chess_playbook_Go;
        }

        static void ToArm(List<Point> downpoint)
        {
            
            int write_type = 1;
            
            //User_UI.sp_d.Open();
            foreach (Point p in downpoint)
            {
                string sp_dd = "";
                if (write_type == 1)
                {
                    write_type = 2;
                    sp_dd = "x" + (double)(learntimetxt.real_point_x[p.Y, p.X]) + ";y" + (double)(learntimetxt.real_point_y[p.X, p.Y]) + ";z" + ((p.Y == 7) ? -1.8 : (p.Y == 0) ? -2.3 : -1.6).ToString() + ";p;";
                }
                else
                    sp_dd = "x" + (double)(learntimetxt.real_point_x[p.Y, p.X]) + ";y" + (double)(learntimetxt.real_point_y[p.X, p.Y]) + ";z" + ((p.Y == 7) ? -1.8 : (p.Y == 0) ? -2.3 : -1.6).ToString() + ";c;";
                 learntimetxt.sp_d.WriteLine(sp_dd);
                Thread.Sleep(100);
            }
                learntimetxt.sp_d.WriteLine("l;");
                //User_UI.sp_d.Close();
        }
        private static bool chess_Change(int color, int x, int y, int x_c, int y_c)
        {
            int X = x + x_c;
            int Y = y + y_c;
            if (X > 7 || Y > 7 || X < 0 || Y < 0)
            {
                return false;
            }
            int chesscolor = Chess[X * 8 + Y].chess_color;
            if (chesscolor == color)
            {
                return true;
            }
            else if (chesscolor == 0)
            {
                return false;
            }
            else
            {
                if (chess_Change(color, X, Y, x_c, y_c) == true)
                {
                    Chess[X * 8 + Y].chess_color = color;
                    downpoint.Add(new Point(X,Y));
                    if (color == 1)
                    {
                        black++;
                        white--;
                    }
                    else
                    {
                        white++;
                        black--;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private static void chess_Change_count()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Chess[i*8+j].chess_color != 1 && Chess[i * 8 + j].chess_color != 2)
                    {
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, 1, 0);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, 1, 1);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, 0, 1);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, -1, -1);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, -1, 1);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, 1, -1);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, 0, -1);
                        Change_count(chess % 2 == 0 ? 1 : 2, i, j, -1, 0);
                        Chess[i * 8 + j].chess_change = chesscount;
                        if (chesscount != 0)
                        {
                        }
                        chesscount = 0;
                    }
                }
            }
            if (endgame == true) return;
            NObutton();
            if (endgame == true) return;
            Change_User();
        }

        private static void Change_User()
        {
            foreach (var a in Chess)
            {
                if (a.chess_change != 0)
                {

                    if (end == 1) 
                    {
                        //MessageBox.Show("無子可落，換邊");
                        change = true;
                        change_no = true;
                    }
                    end = 0;
                    return;
                }
            }
            end++;
            if (end >= 2)
            {
                winer();
                return;
            }
            chess++;
            chess_Change_count();
        }
          
        private static void NObutton()
        {
            foreach (var a in Chess)
            {
                if (a.chess_color > 0)
                {
                    return;
                }
            }
            winer();
        }

        private static void winer()
        {
           // MessageBox.Show("遊戲結束");
            endgame = true;
            if (white > black)
            {
                end =2;
              //  MessageBox.Show("白子勝");
            }
            else if (white < black)
            {
                end = 1;
              //  MessageBox.Show("黑子勝");
            }
            else
            {
                end = 3;
                //MessageBox.Show("平手");
            }
        }
              
        private static bool Change_count(int color, int x, int y, int x_c, int y_c)
        {
            int X = x + x_c;
            int Y = y + y_c;
            if (X > 7 || Y > 7 || X < 0 || Y < 0)
            {
                return false;
            }
            int chesscolor = Chess[X * 8 + Y].chess_color;
            if (chesscolor == color)
            {
                return true;
            }
            else if (chesscolor == 0)
            {
                return false;
            }
            else
            {
                if (Change_count(color, X, Y, x_c, y_c) == true)
                {
                    chesscount++;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


    }
    class Check_Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public int color { get; set; }
    }
}
