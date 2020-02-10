using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace MCTS_Othello
{
    public partial class MCTS : Form
    {
        public MCTS()
        {
            InitializeComponent();
        }
        Button[,] bu;
        int endgame = -1;//0黑1白2平
        int white_now = 2;
        int black_now = 2;
        double value_C = 0.5;
        int computer_turn = 0;
        int Alltimes = 7000;
        int endgame_turm = 17;
        bool computer_win = false;
        int AI_Change = 65;
        int[] fraction = new int[]
        {
                1000,150,200,200,200,200,150,1000,
                150,-200,10,10,10,10,-200,150,
                200,10,23,20,20,23,10,200,
                200,10,20,0,0,0,10,200,
                200,10,20,0,0,0,10,200,
                200,10,23,20,20,23,10,200,
                150,-200,10,10,10,10,-200,150,
                1000,30,200,200,200,200,30,1000,
                //6000,-300,600,300,300,600,-300,6000,
                //-300,-2000,-40,-30,-30,-40,-2000,-300,
                //600,-40,3,1,0,3,-40,600,
                //300,-30,0,0,0,0,-30,300,
                //300,-30,0,0,0,0,-30,300,
                //600,-40,3,0,0,3,-30,600,
                //-300,-2000,-40,-30,-30,-40,-2000,-300,
                //6000,-600,300,300,300,600,-300,6000,
    };
        public void Godown(MCTS_Othello.MCTS_Chess[,] Chess , int downX,int downY,int color,int black ,int white)
        {
            List<黑白棋.Chess_Towplayer> list = new List<黑白棋.Chess_Towplayer>();
            foreach (var a in Chess)
            {
                list.Add(new 黑白棋.Chess_Towplayer() { chess_color = a.color +1});
            }
            黑白棋.ToDownChess.Chess_Down(list, downX, downY, color, black, white);
        }
        public void GetDown(int[,] intlist, int color)
        {
            string chess_playbook_string = "";
            foreach (var a in intlist) chess_playbook_string += a.ToString();
            Tochessdown(chess_playbook_string,color);
        }
        MCTS_Chess[,] chess_playbook_now = new MCTS_Chess[8, 8];
        int chess_color = 0;//0黑色，1白色
        List<MCTS_Tree> DataTree = new List<MCTS_Tree>();
        void Racetxt_Change()
        {
            label3.Text = "黑棋：" + black_now + "            白棋：" + white_now + "";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            comboBox1.Items.Add("黑子");
            comboBox1.Items.Add("白子");
            comboBox1.SelectedIndex = 0;
            addbutton();
        }
        void ChessPlaybookNowToBu()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    bu[i, j].Text = chess_playbook_now[i, j].color == 0 ? "●" : chess_playbook_now[i, j].color == 1 ? "○" : bu[i, j].Text;
        }
        double Chess_Change_Update(MCTS_Chess[,] chess_playbook, int X, int Y, int color, ref int black, ref int white ,  List<Point> change  )
        {
            double fraction_value=0;
            Chess_Change(chess_playbook, color, 1, 0, X, Y, ref black, ref white,ref fraction_value ,change);
            Chess_Change(chess_playbook, color, 0, 1, X, Y, ref black, ref white, ref fraction_value, change);
            Chess_Change(chess_playbook, color, 1, 1, X, Y, ref black, ref white, ref fraction_value, change);
            Chess_Change(chess_playbook, color, -1, 0, X, Y, ref black, ref white, ref fraction_value,change);
            Chess_Change(chess_playbook, color, 0, -1, X, Y, ref black, ref white, ref fraction_value,change);
            Chess_Change(chess_playbook, color, -1, -1, X, Y, ref black, ref white, ref fraction_value, change);
            Chess_Change(chess_playbook, color, 1, -1, X, Y, ref black, ref white, ref fraction_value,change);
            Chess_Change(chess_playbook, color, -1, 1, X, Y, ref black, ref white, ref fraction_value,change);
            return fraction_value;
        }
        bool Chess_Change(MCTS_Chess[,] chess_playbook, int color, int valueX, int valueY, int X, int Y, ref int black, ref int white,ref double fraction ,  List<Point> change)
        {
            int x = X + valueX;
            int y = Y + valueY;
            if (x < 0 || y < 0 || x > 7 || y > 7) return false;
            if (chess_playbook[x, y].color == -1) return false;
            if (chess_playbook[x, y].color == color % 2) return true;
            else
            {
                if (Chess_Change(chess_playbook, color, valueX, valueY, x, y, ref black, ref white,ref fraction , change))
                {
                    chess_playbook[x, y].color = color % 2;
                    change.Add(new Point() { X=x,Y=y});
                    fraction += (double)(this.fraction[x*8+y]);
                    black = color % 2 == 0 ? black + 1 : black - 1;
                    white = color % 2 == 1 ? white + 1 : white - 1;
                    return true;
                }
            }
            return false;
        }
       public   List<Point> Chess_Count_Update(MCTS_Chess[,] chess_playbook, int color)//當前顏色
        {
            List<Point> candown = new List<Point>();
            int count = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    count = 0;
                    if (chess_playbook[i, j].color == -1)
                    {
                        Chess_Count(chess_playbook, color, 1, 0, ref count, i, j);
                        Chess_Count(chess_playbook, color, 0, 1, ref count, i, j);
                        Chess_Count(chess_playbook, color, 1, 1, ref count, i, j);
                        Chess_Count(chess_playbook, color, -1, 0, ref count, i, j);
                        Chess_Count(chess_playbook, color, 0, -1, ref count, i, j);
                        Chess_Count(chess_playbook, color, -1, -1, ref count, i, j);
                        Chess_Count(chess_playbook, color, 1, -1, ref count, i, j);
                        Chess_Count(chess_playbook, color, -1, 1, ref count, i, j);
                    }
                    if (count > 0) candown.Add(new Point() { X = i, Y = j });
                    chess_playbook[i, j].count = count;
                }
            return candown;
        }
        bool Chess_Count(MCTS_Chess[,] chess_playbook, int color, int valueX, int valueY, ref int count, int X, int Y)
        {
            int x = X + valueX;
            int y = Y + valueY;
            if (x < 0 || y < 0 || x > 7 || y > 7) return false;
            if (chess_playbook[x, y].color == -1) return false;
            if (chess_playbook[x, y].color == color % 2) return true;
            else
            {
                if (Chess_Count(chess_playbook, color, valueX, valueY, ref count, x, y))
                {
                    count++;
                    return true;
                }
            }
            return false;
        }
        int Change_Player(MCTS_Chess[,] chess_playbook, bool Message)
        {
            foreach (var a in chess_playbook)
            {
                if (a.count != 0) return 0;
            }
            if (Message) MessageBox.Show("無子可落，換手");
            return 1;
        }
        int check_win(MCTS_Chess[,] chess_playbook, bool Message, int black, int white)
        {
            bool done = true;
            foreach (var a in chess_playbook)
            {
                if (a.color == -1 && a.count != 0) done = false;
            }
            if (!done) return -1;
            if (Message)
            {
                if (black > white)
                {
                    MessageBox.Show("黑子勝");
                    return 0;
                }
                else if (black < white)
                {
                    MessageBox.Show("白子勝");
                    return 1;
                }
                else
                {
                    MessageBox.Show("平手");
                    return 2;
                }
            }
            else
            {
                if (black > white) return 0;
                else if (black < white) return 1;
                else return 2;
            }
        }//0,1,2
        void ArraytoArray(MCTS_Chess[,] a1, MCTS_Chess[,] a2)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int ii = 0; ii < 8; ii++)
                {
                    a1[i, ii] = new MCTS_Chess();
                    a1[i, ii].color = a2[i, ii].color;
                    a1[i, ii].count = a2[i, ii].count;
                }
            }
        }
        void addbutton()
        {
            bu = new Button[8, 8];
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    chess_playbook_now[i, j] = new MCTS_Chess();
                    chess_playbook_now[i, j].color = -1;
                    bu[i, j] = new Button();
                    bu[i, j].Name = i.ToString();
                    bu[i, j].Size = new Size(45, 45);
                    bu[i, j].Location = new Point(4 + j * 45, 10 + i * 45);
                    bu[i, j].Tag = j.ToString();
                    bu[i, j].Font = new Font("微軟正黑體", 23);
                    bu[i, j].Click += new EventHandler(bu_Click);
                    bu[i, j].Enabled = false;
                    bu[i, j].FlatStyle = FlatStyle.Flat;
                    bu[i, j].BackColor = Color.FromArgb(255, 173, 216, 230);
                    groupBox1.Controls.Add(bu[i, j]);
                }
            chess_playbook_now[3, 4].color = 0;
            chess_playbook_now[3, 3].color = 1;
            chess_playbook_now[4, 3].color = 0;
            chess_playbook_now[4, 4].color = 1;
            chess_color = 0;
            Chess_Count_Update(chess_playbook_now, chess_color);
            ChessPlaybookNowToBu();
        }
        void bu_Clear()
        {
            foreach (var a in bu)
            {
                if (a.Text != "●" && a.Text != "○")
                {
                    a.Text = "";

                }
                else if(a.Text == "●" || a.Text == "○")
                {
                    a.Font = new Font("微軟正黑體", 23);
                }
                a.BackColor = Color.FromArgb(255, 173, 216, 230);
            }
        }
        information Chess_Down(int x, int y, MCTS_Chess[,] chess_playbook, ref int black, ref int white, ref int color, bool Message)
        {
            information re_in = new information();
            re_in.candown_point = new List<Point>();
            re_in.change = new List<Point>();
            chess_playbook[x, y].color = chess_color % 2;

            black = chess_color % 2 == 0 ? black + 1 : black;
            white = chess_color % 2 == 1 ? white + 1 : white;
            re_in.candown_fraction = Chess_Change_Update(chess_playbook, x, y, color, ref black, ref white ,   re_in.change);

            color++;
            Chess_Count_Update(chess_playbook, color);
            re_in.change_user = Change_Player(chess_playbook, Message);
            color += re_in.change_user;
            re_in.candown_point = new List<Point>();
            re_in.candown_point = Chess_Count_Update(chess_playbook, color);

            if (Message)
            {
                Racetxt_Change();
                ChessPlaybookNowToBu();
            }

            re_in.endgame = check_win(chess_playbook, Message, black, white);

            return re_in;
        }
        void bu_Click(object sender, EventArgs e)
        {
            Button c_bu = ((Button)(sender));
            int x = int.Parse(c_bu.Name);
            int y = int.Parse(c_bu.Tag.ToString());

            if (endgame != -1) return;
            if (chess_playbook_now[x, y].color != -1) return;
            if (chess_playbook_now[x, y].count == 0) return;

            information infor = new information();

            infor = Chess_Down(x, y, chess_playbook_now, ref black_now, ref white_now, ref chess_color, true);

            endgame = infor.endgame;

            int times = 0;

            foreach (var a in chess_playbook_now) if (a.color != -1) times++;

            if (endgame < 0)
            {
                if (times > AI_Change)
                {
                    if (!computer_win)
                    {
                        bool have = false;
                        foreach (var a in DataTree)
                        {
                            if (a.point == new Point() { X = x, Y = y })
                            {
                                have = true;
                                MCTS_Tree m = new MCTS_Tree();
                                m = a;
                                DataTree = new List<MCTS_Tree>();
                                DataTree = m.Next;
                                break;
                            }
                        }
                        if (!have)
                            DataTree = new List<MCTS_Tree>();
                    }
                    if (chess_color % 2 == computer_turn)
                    {
                        bu_Clear();
                        if (64 - (black_now + white_now) <= endgame_turm)
                        {
                            foreach (var a in infor.candown_point)
                            {
                                if (endgame_search(chess_playbook_now, a.X, a.Y, chess_color, black_now, white_now) == computer_turn)
                                {
                                    computer_win = true;
                                    MessageBox.Show("你為你還有機會贏??????");
                                    bu[a.X, a.Y].PerformClick();
                                    return;
                                }
                            }
                        }
                        Task.Run(() => Computer_UCT(infor.candown_point, chess_playbook_now));
                    }
                }
                else
                {
                    if (chess_color % 2 == computer_turn)
                    {
                        Computer_Tree(infor.candown_point, chess_playbook_now, chess_color, 5, black_now, white_now);
                        return;
                    }
                }
            }
            button3.PerformClick();
        }
        void Computer_UCT(List<Point> candown, MCTS_Chess[,] chess_playbook_new)
        {
            for (int i = 0; i < /*(int)((double)Alltimes * (double)(1 + (black_now + white_now) / 100.0)*/Alltimes/**(candown.Count+((chess_color/10)+1))*/; i++)
            {
                MCTS_Chess[,] chess_playbook_computer = new MCTS_Chess[8, 8];
                List<MCTS_Tree> mt_computer = DataTree;
                ArraytoArray(chess_playbook_computer, chess_playbook_new);
                int black_computer = black_now;
                int white_computer = white_now;
                int color_computer = chess_color;
                List<Point> candown_computer = new List<Point>();
                foreach (var a in candown) candown_computer.Add(a);
                List<MCTS_Tree> down_computer = new List<MCTS_Tree>();
                bool start = false;
                while (!start)
                {
                    int end = check_win(chess_playbook_computer, false, black_computer, white_computer);
                    if (end == -1)
                    {
                        if (mt_computer.Count != candown_computer.Count)
                        {
                            foreach (var a in candown_computer)
                            {
                                if (mt_computer.FindAll(z => z.point == new Point() { X = a.X, Y = a.Y }).ToList().Count == 0)
                                {
                                    MCTS_Tree mt = new MCTS_Tree();
                                    MCTS_Chess[,] mc = new MCTS_Chess[8, 8];
                                    ArraytoArray(mc, chess_playbook_computer);
                                    int check = simulation(mt, a.X, a.Y, mc, black_computer, white_computer, color_computer);
                                    foreach (var aa in down_computer)
                                    {
                                        if (check != -1)
                                        {
                                            if (check == 0)
                                            {
                                                aa.black_win++;
                                            }
                                            else if (check == 1)
                                            {
                                                aa.white_win++;
                                            }
                                            else
                                            {
                                                aa.white_win++;
                                                aa.black_win++;
                                            }
                                        }
                                    }
                                    mt_computer.Add(mt);
                                    start = true;
                                    break;
                                }
                            }
                            if (start)
                                continue;
                        }
                        Data_uct_Update(mt_computer, color_computer);
                        mt_computer.Sort((z, s) => { return -z.uct_value.CompareTo(s.uct_value); });
                        down_computer.Add(mt_computer[0]);
                        chess_playbook_computer[mt_computer[0].point.X, mt_computer[0].point.Y].color = color_computer % 2;
                        black_computer = color_computer % 2 == 0 ? black_computer + 1 : black_computer;
                        white_computer = color_computer % 2 == 1 ? white_computer + 1 : white_computer;
                        Chess_Change_Update(chess_playbook_computer, mt_computer[0].point.X, mt_computer[0].point.Y, color_computer, ref black_computer, ref white_computer,new List<Point>());
                        color_computer++;
                        Chess_Count_Update(chess_playbook_computer, color_computer);
                        color_computer += Change_Player(chess_playbook_computer, false);
                        candown_computer = Chess_Count_Update(chess_playbook_computer, color_computer);
                        mt_computer = mt_computer[0].Next;
                    }
                    else
                    {
                        foreach (var aa in down_computer)
                        {
                            if (end != -1)
                            {
                                if (end == 0)
                                {
                                    aa.black_win++;
                                }
                                else if (end == 1)
                                {
                                    aa.white_win++;
                                }
                                else
                                {
                                    aa.white_win++;
                                    aa.black_win++;
                                }
                            }
                        }
                        start = true;
                        break;
                    }

                }
            }
            DataTree.Sort((z, s) => { return -z.uct_value.CompareTo(s.uct_value); });
            //MessageBox.Show("black_win:" + DataTree[0].black_win.ToString() + "\r\n" + "white_win:" + DataTree[0].white_win.ToString() + "\r\n" + "uct_value:" + DataTree[0].uct_value.ToString());
            int x, y;
            x = DataTree[0].point.X;
            y = DataTree[0].point.Y;
            //bu[x, y].BackColor = Color.Pink;
            DataTree = DataTree[0].Next;
            Godown(chess_playbook_now, x, y, chess_color, black_now, white_now);
            //bu[x, y].PerformClick();
        }
        public int endgame_search(MCTS_Chess[,] chess_playbook, int x, int y, int color_simulation, int black_e, int white_e)
        {
            MCTS_Chess[,] chess_playbook_simulation = new MCTS_Chess[8, 8];
            List<Point> candown = new List<Point>();
            int black = black_e;
            int white = white_e;
            ArraytoArray(chess_playbook_simulation, chess_playbook);
            chess_playbook_simulation[x, y].color = color_simulation % 2;
            black = color_simulation % 2 == 0 ? black + 1 : black;
            white = color_simulation % 2 == 1 ? white + 1 : white;
            Chess_Change_Update(chess_playbook_simulation, x, y, color_simulation, ref black, ref white,new List<Point>());
            color_simulation++;
            Chess_Count_Update(chess_playbook_simulation, color_simulation);
            color_simulation += Change_Player(chess_playbook_simulation, false);
            candown = Chess_Count_Update(chess_playbook_simulation, color_simulation);
            int check = check_win(chess_playbook_simulation, false, black, white);
            if (check != -1)
            {
                return check;
            }
            else
            {
                int now_color = color_simulation - 1;
                int value = -2;
                foreach (var a in candown)
                {
                    value = endgame_search(chess_playbook_simulation, a.X, a.Y, color_simulation, black, white);
                    if (now_color % 2 == computer_turn)
                    {
                        if (value == computer_turn) continue;
                        else return value;
                    }
                    else
                    {
                        if (value == computer_turn) return value;
                        else continue;
                    }
                }
                return value;
            }
        }
        void Data_uct_Update(List<MCTS_Tree> mc, int color)
        {
            int All = 0;
            foreach (var a in mc)
            {
                All += a.black_win;
                All += a.white_win;
            }
            foreach (var a in mc)
            {
                a.uct_value = color % 2 == 0 ? ((double)a.black_win / (double)(a.black_win + a.white_win) + value_C * Math.Sqrt(Math.Log10((All) / (double)(a.black_win + a.white_win)))) : ((double)a.white_win / (double)(a.black_win + a.white_win) + value_C * Math.Sqrt(Math.Log10((All) / (double)(a.black_win + a.white_win))));
            }
        }
        void Data_Update(List<MCTS_Tree> mc, int win)
        {
            foreach (var a in mc)
            {
                if (win == 0)
                {
                    a.black_win++;
                }
                else if (win == 1)
                {
                    a.white_win++;
                }
                else
                {
                    a.white_win += 0;
                    a.black_win += 0;
                }
            }
        }
        int simulation(MCTS_Tree mt, int x, int y, MCTS_Chess[,] chess_playbook_simulation, int black, int white, int color_simulation)
        {
            Random rd = new Random();
            mt.point = new Point() { X = x, Y = y };
            chess_playbook_simulation[x, y].color = color_simulation % 2;
            black = color_simulation % 2 == 0 ? black + 1 : black;
            white = color_simulation % 2 == 1 ? white + 1 : white;
            Chess_Change_Update(chess_playbook_simulation, x, y, color_simulation, ref black, ref white,new List<Point>());
            color_simulation++;
            Chess_Count_Update(chess_playbook_simulation, color_simulation);
            color_simulation += Change_Player(chess_playbook_simulation, false);
            Chess_Count_Update(chess_playbook_simulation, color_simulation);
            int check = check_win(chess_playbook_simulation, false, black, white);
            if (check != -1)
            {
                if (check == 0)
                {
                    mt.black_win++;
                }
                else if (check == 1)
                {
                    mt.white_win++;
                }
                else
                {
                    mt.white_win++;
                    mt.black_win++;
                }
                return check;
            }
            else
            {
                List<Point> candown = Chess_Count_Update(chess_playbook_simulation, color_simulation);
                int rdn = rd.Next(0, candown.Count);
                mt.Next = new List<MCTS_Tree>();
                mt.Next.Add(new MCTS_Tree());
                int win = simulation(mt.Next[0], candown[rdn].X, candown[rdn].Y, chess_playbook_simulation, black, white, color_simulation);
                if (win == 0)
                {
                    mt.black_win++;
                }
                else if (win == 1)
                {
                    mt.white_win++;
                }
                else
                {
                    mt.white_win++;
                    mt.black_win++;
                }
                return win;
            }

        }
        private void StartGame_Click(object sender, EventArgs e)
        {
            foreach (Button b in bu) b.Enabled = true;
            label2.ForeColor = Color.Red;
            label2.Text = "玩家：" + comboBox1.Text;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            if (comboBox1.Text == "黑子")
            {
                chess_color = 0;
                computer_turn = 1;
            }
            else
            {
                chess_color = 0;
                computer_turn = 0;
                //Computer_UCT(Chess_Count_Update(chess_playbook_now, 0), chess_playbook_now);
                Computer_Tree(Chess_Count_Update(chess_playbook_now, 0),chess_playbook_now,chess_color,5,black_now,white_now);
            }
        }
        private void RestartGame_Click(object sender, EventArgs e)
        {
            bu_Clear();
            DataTree = new List<MCTS_Tree>();
            comboBox1.Enabled = true;
            button1.Enabled = true;
            endgame = -1;
            foreach (Button b in bu)
            {
                b.Text = "";
                b.Enabled = false;
            }
            for (int i = 0; i < 8; i++)
                for (int ii = 0; ii < 8; ii++)
                {
                    chess_playbook_now[i, ii] = new MCTS_Chess();
                    chess_playbook_now[i, ii].color = -1;
                }
            chess_playbook_now[3, 4].color = 0;
            chess_playbook_now[3, 3].color = 1;
            chess_playbook_now[4, 3].color = 0;
            chess_playbook_now[4, 4].color = 1;
            black_now = 2;
            white_now = 2;
            Racetxt_Change();
            Chess_Count_Update(chess_playbook_now, 0);
            ChessPlaybookNowToBu();
            chess_color = 0;
        }
        private void OutputPlaybook_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (MCTS_Chess a in chess_playbook_now) sb.Append(a.color + 1);
            textBox1.Text = sb.ToString();
        }
        private void InsertPlaybook_Click(object sender, EventArgs e)
        {
            Insert_Chess_Down(textBox1.Text);
        }
        void Insert_Chess_Down(string chess_playbook)
        {
            string s = chess_playbook;
            if (comboBox2.Text == "黑子")
            {
                computer_turn = 0;
                chess_color = 1;
            }
            else
            {
                chess_color = 0;
                computer_turn = 1;
            }
            string[] ss = Array.ConvertAll(textBox1.Text.ToArray(), Convert.ToString);
            chess_playbook_now = new MCTS_Chess[8, 8];
            DataTree = new List<MCTS_Tree>();
            endgame = -1;
            foreach (Button b in bu)
            {
                b.Text = "";
            }
            for (int i = 0; i < 8; i++)
                for (int ii = 0; ii < 8; ii++)
                {
                    chess_playbook_now[i, ii] = new MCTS_Chess();
                    chess_playbook_now[i, ii].color = int.Parse(ss[i * 8 + ii].ToString()) - 1;
                }
            black_now = 0;
            white_now = 0;
            foreach (var a in chess_playbook_now)
            {
                if (a.color == 0) black_now++;
                else if (a.color == 1) white_now++;
            }

            chess_color++;
            Chess_Count_Update(chess_playbook_now, chess_color);
            chess_color += Change_Player(chess_playbook_now, true);
            List<Point> candown = Chess_Count_Update(chess_playbook_now, chess_color);

            Racetxt_Change();
            ChessPlaybookNowToBu();

            endgame = check_win(chess_playbook_now, true, black_now, white_now);

            if (endgame < 0)
            {
                if (chess_color % 2 == computer_turn)
                {
                    bu_Clear();
                    if (64 - (black_now + white_now) <= endgame_turm)
                    {
                        foreach (var a in candown)
                        {
                            if (endgame_search(chess_playbook_now, a.X, a.Y, chess_color, black_now, white_now) == computer_turn)
                            {
                                computer_win = true;
                                MessageBox.Show("你為你還有機會贏??????");
                                bu[a.X, a.Y].PerformClick();
                                return;
                            }
                        }
                    }
                    Task.Run(() => Computer_UCT(candown, chess_playbook_now));
                }
            }
            button3.PerformClick();

        }
        void Tochessdown(string chess_playbook,int color)
        {
            string s = chess_playbook;
            if (color%2 == 0)
            {
                computer_turn = 0;
                chess_color = 1;
            }
            else
            {
                chess_color = 0;
                computer_turn = 1;
            }
            string[] ss = Array.ConvertAll(s.ToArray(), Convert.ToString);
            chess_playbook_now = new MCTS_Chess[8, 8];
            DataTree = new List<MCTS_Tree>();
            endgame = -1;
            int times_count = 0;
            for (int i = 0; i < 8; i++)
                for (int ii = 0; ii < 8; ii++)
                {
                    chess_playbook_now[i, ii] = new MCTS_Chess();
                    chess_playbook_now[i, ii].color = int.Parse(ss[i * 8 + ii].ToString()) - 1;
                }
            black_now = 0;
            white_now = 0;
            foreach (var a in chess_playbook_now)
            {
                if (a.color == 0) black_now++;
                else if (a.color == 1) white_now++;
            }
            times_count = black_now + white_now;
            chess_color++;
            Chess_Count_Update(chess_playbook_now, chess_color);
            chess_color += Change_Player(chess_playbook_now, true);
            List<Point> candown = Chess_Count_Update(chess_playbook_now, chess_color);

            endgame = check_win(chess_playbook_now, true, black_now, white_now);

            if (endgame < 0)
            {
                if (chess_color % 2 == computer_turn)
                {
                    //bu_Clear();
                    if (64 - (black_now + white_now) <= endgame_turm)
                    {
                        foreach (var a in candown)
                        {
                            if (endgame_search(chess_playbook_now, a.X, a.Y, chess_color, black_now, white_now) == computer_turn)
                            {
                                computer_win = true;
                                //MessageBox.Show("你為你還有機會贏??????");
                                Godown(chess_playbook_now, a.X, a.Y, chess_color, black_now, white_now);
                                //bu[a.X, a.Y].PerformClick();
                                return;
                            }
                        }
                    }
                    if (times_count <= 31)
                        Task.Run(() => Computer_Tree(candown, chess_playbook_now,chess_color,3,black_now,white_now));
                    else
                    Task.Run(() => Computer_UCT(candown, chess_playbook_now));
                }
            }
            //button3.PerformClick();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //if (comboBox1.Text == "黑子") computer_turn = 0;
            //else computer_turn = 1;
        }
        private void Cleartxt_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        void Computer_Tree(List<Point> candown, MCTS_Chess[,] chess_playbook_new, int color_tree, int Max_times, int black, int white)
        {
            List<Fraction_Tree> fraction_point = new List<Fraction_Tree>();
            textBox2.Text = "";
            foreach (Point a in candown)
            {
                MCTS_Chess[,] chess_playbook_computer = new MCTS_Chess[8, 8];
                ArraytoArray(chess_playbook_computer, chess_playbook_new);
                int color_computer = color_tree;
                int black_computer = black;
                int white_computer = white;
                information infor = new information();
                infor = Chess_Down(a.X, a.Y, chess_playbook_computer, ref black_computer, ref white_computer, ref color_computer, false);
                if ((infor.endgame) == (color_tree) % 2)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = 10000 });
                    continue;
                }
                else if (infor.endgame != -1)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = -10000 });
                    continue;
                }
                else if (infor.change_user == 1)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = 2000 });
                    continue;
                }
                double value = 0;
                    Fraction_Tree ft = Tree_Search(infor.candown_point, chess_playbook_computer, color_computer, Max_times, black_computer, white_computer, 1);
                    value = ft.fraction;
                    bool have_change = false;
                if (ft.change != null)
                    foreach (var aa in ft.change)
                        if (aa.X == a.X && aa.Y == a.Y) have_change = true;
                 if (have_change)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = value + infor.candown_fraction });
                    //textBox2.Text += "(" + a.X.ToString() + "," + a.Y.ToString() + ")" + "  " + "Search加權：" + (fraction_point[fraction_point.Count - 1].fraction - fraction[a.X * 8 + a.Y] - infor.candown_fraction).ToString() + "  位置加權：" + 0 + "  翻棋加權：" + infor.candown_fraction + "    true" + "\r\n" + "\r\n";
                }
                else
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = value + fraction[a.X * 8 + a.Y] + infor.candown_fraction });
                    //textBox2.Text += "(" + a.X.ToString() + "," + a.Y.ToString() + ")" + "  " + "Search加權：" + (fraction_point[fraction_point.Count - 1].fraction - fraction[a.X * 8 + a.Y] - infor.candown_fraction).ToString() + "  位置加權：" + fraction[a.X * 8 + a.Y] + "  翻棋加權：" + infor.candown_fraction + "\r\n" + "\r\n";

                }

            }
            fraction_point.Sort((x, y) => { return -x.fraction.CompareTo(y.fraction); });
            //MessageBox.Show(fraction_point[0].fraction.ToString());
            //foreach(var a in fraction_point)
            //{
            //    bu[a.p.X, a.p.Y].Text = a.fraction.ToString();
            //    bu[a.p.X, a.p.Y].Font = new Font("微軟正黑體", 10);
            //}
            Godown(chess_playbook_now,fraction_point[0].p.X, fraction_point[0].p.Y, color_tree, black_now, white_now);
           // bu[fraction_point[0].p.X, fraction_point[0].p.Y].PerformClick();
        }
        Fraction_Tree Tree_Search(List<Point> candown, MCTS_Chess[,] chess_playbook_new, int color_tree, int Max_times, int black, int white, int times_now)
        {
            List<Fraction_Tree> fraction_point = new List<Fraction_Tree>();
            foreach(var a in candown)
            {
                fraction_point.Add(new Fraction_Tree() { p =a,fraction =fraction[a.X*8+a.Y]});
            }
            fraction_point.Sort((x, y) => { return x.fraction.CompareTo(y.fraction); });
            int ii = Max_times+1 - times_now;
            if (ii < 1) ii = 1;
            for (int i=0;i< candown.Count; i++)
            {
                if (candown.Count > ii)
                    candown.Remove(fraction_point[i].p);
                else break;
            }
            fraction_point = new List<Fraction_Tree>();
            foreach (Point a in candown)
            {
                MCTS_Chess[,] chess_playbook_computer = new MCTS_Chess[8, 8];
                ArraytoArray(chess_playbook_computer, chess_playbook_new);
                int color_computer = color_tree;
                int black_computer = black;
                int white_computer = white;
                information infor = new information();
                infor = Chess_Down(a.X, a.Y, chess_playbook_computer, ref black_computer, ref white_computer, ref color_computer, false);
                if ((infor.endgame ) == (color_tree) % 2)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = 10000 });
                    continue;
                }
                else if (infor.endgame != -1)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = -10000 });
                    continue;
                }
                else if (infor.change_user == 1)
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = 2000 });
                    continue;
                }
                double value = 0;
                if (times_now < Max_times)
                {
                    Fraction_Tree ft = Tree_Search(infor.candown_point, chess_playbook_computer, color_computer, Max_times, black_computer, white_computer, times_now + 1);
                    value = ft.fraction;
                    if (times_now == 1)
                    {

                    }
                    bool have_change = false;
                    if(ft.change!=null)
                    foreach(var aa in ft.change)
                        if (aa.X == a.X && aa.Y == a.Y) have_change = true;
                    if (have_change)
                        fraction_point.Add(new Fraction_Tree() { p = a, fraction = value  + infor.candown_fraction, change = infor.change });
                    else
                        fraction_point.Add(new Fraction_Tree() { p = a, fraction = value + fraction[a.X * 8 + a.Y] + infor.candown_fraction, change = infor.change });
                }
                else
                {
                    fraction_point.Add(new Fraction_Tree() { p = a, fraction = fraction[a.X * 8 + a.Y] + infor.candown_fraction , change = infor.change });
                }
            }
            //if (color_tree % 2 == computer_turn)
            //    fraction_point.Sort((x, y) => { return x.fraction.CompareTo(y.fraction); });
            //else
            if (times_now == 1)
            {

            }
            fraction_point.Sort((x, y) => { return -x.fraction.CompareTo(y.fraction); });
           fraction_point[0].fraction = (-1*fraction_point[0].fraction);
            return fraction_point[0];
        }
    }
   public class MCTS_Chess
    {
        public int color { get; set; }
        public int count { get; set; }
    }
    class MCTS_Tree
    {
        //public MCTS_Chess chess_playbook { get; set; }
        public List<MCTS_Tree> Next { get; set; }
        public Point point { get; set; }
        public int black_win { get; set; }
        public int white_win { get; set; }
        public double uct_value { get; set; }
    }
    class Fraction_Tree
    {
        public Point p { get; set; }
        public List<Point> change {get;set;}
        public double fraction { get; set; }
    }
    class information
    {
        public int endgame { get; set; }
        public int change_user { get; set; }
        public List<Point> candown_point { get; set; }
        public List<Point> change { get; set; }
        public double candown_fraction{ get; set; }
        public MCTS[,] chess_playbook { get; set; }
    }
    class re
    {
        Point p { get; set; }
        double fraction { get; set; }
    }
}
