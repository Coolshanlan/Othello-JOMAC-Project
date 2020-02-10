using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 黑白棋
{
    public partial class Show_confidence_playbook : Form
    {
        Button[,] user_bu = new Button[8,8];
        Button[,] ans_bu = new Button[8, 8];
        public Show_confidence_playbook(string error_message, string user_playbook, string ans_playbook, List<Point> tipe_point, List<Point> erro_point)
        {
            InitializeComponent();
            label3.Text += error_message;
            user_bu = new Button[8, 8];
            ans_bu = new Button[8,8];
            for (int j = 7; j >= 0; j--)
                for (int i = 0; i < 8; i++)
                {
                    user_bu[i,7-j] = new Button();
                    user_bu[i,7-j].Name = i.ToString();
                    user_bu[i,7-j].Size = new Size(45, 45);
                    user_bu[i,7-j].Location = new Point(4 + i * 45, 10 + j * 45);
                    user_bu[i,7-j].Tag = j.ToString();
                    user_bu[i,7-j].Font = new Font("微軟正黑體", 23);
                    //user_bu[i,7-j].Enabled = false;
                    user_bu[i,7-j].FlatStyle = FlatStyle.Flat;
                    user_bu[i, 7 - j].BackColor = Color.FromArgb(255, 181, 111, 0);
                    groupBox1.Controls.Add(user_bu[i,7-j]);
                }
            for (int j = 7; j >=0 ; j--)
                for (int i = 0; i < 8; i++)
                {
                    ans_bu[i,7-j] = new Button();
                    ans_bu[i,7-j].Name = i.ToString();
                    ans_bu[i,7-j].Size = new Size(45, 45);
                    ans_bu[i,7-j].Location = new Point(4 + i * 45, 10 + j * 45);
                    ans_bu[i,7-j].Tag = j.ToString();
                    ans_bu[i,7-j].Font = new Font("微軟正黑體", 23);
                    //ans_bu[i,7-j].Enabled = false;
                    ans_bu[i,7-j].FlatStyle = FlatStyle.Flat;
                    // ans_bu[i, 7 - j].BackColor = Color.FromArgb(255, 173, 216, 230)
                    ans_bu[i, 7 - j].BackColor = Color.FromArgb(255, 181, 111, 0); 
                    groupBox2.Controls.Add(ans_bu[i, 7-j]);
                }
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    string user_chess_color = user_playbook[i * 8 + j].ToString();
                    string ans_chess_color = ans_playbook[i * 8 + j].ToString();
                    //user_bu[i, j].Text = user_chess_color == "0" ? "" : user_chess_color == "1" ? "●" : "○";
                    //ans_bu[i, j].Text = ans_chess_color == "0" ? "" : ans_chess_color == "1" ? "●" : "○";
                    user_bu[i, j].Text = user_chess_color == "0" ? "" : "●";
                    ans_bu[i, j].Text = ans_chess_color == "0" ? "" :  "●"  ;
                    user_bu[i, j].ForeColor = user_chess_color == "0" ? Color.Black : user_chess_color == "1" ? Color.Black : Color.White;
                    ans_bu[i, j].ForeColor = ans_chess_color == "0" ? Color.Black : ans_chess_color == "1" ? Color.Black : Color.White;
                    ans_bu[i, j].FlatAppearance.BorderColor = Color.Black;
                    user_bu[i, j].FlatAppearance.BorderColor = Color.Black;
                }
            }
            if(tipe_point!=null)
                foreach (var a in tipe_point)
                {
                    ans_bu[a.X, a.Y].BackColor = Color.FromArgb(255,0,230,0) ;
                }
            if (erro_point!=null)
                foreach (var a in erro_point)
                {
                    user_bu[a.X, a.Y].BackColor = Color.Red;
                }
        }

        private void Show_confidence_playbook_Load(object sender, EventArgs e)
        {
            label3.Location = new Point((this.Size.Width-label3.Size.Width)/2 , label3.Location.Y);
        }
    }
}
