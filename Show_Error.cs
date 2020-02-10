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
    public partial class Show_Error : Form
    {
        string error_message2;
        string user_playbook2;
        string ans_playbook2;
        List<Point> tip_point2;
        List<Point> erro_point2;
        public Show_Error(string error_message,string user_playbook,string ans_playbook,List<Point> tip_point, List<Point> erro_point)
        {
            InitializeComponent();
            label1.Text = error_message;
            error_message2 = error_message;
            user_playbook2 = user_playbook;
            ans_playbook2 = ans_playbook;
            tip_point2 =tip_point;
            erro_point2 = erro_point;
        }

        private void Show_Error_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((this.Size.Width - label1.Size.Width)/2 ,label1.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Show_confidence_playbook(error_message2, user_playbook2, ans_playbook2, tip_point2, erro_point2).ShowDialog() ;
            this.Close();
        }
    }
}
