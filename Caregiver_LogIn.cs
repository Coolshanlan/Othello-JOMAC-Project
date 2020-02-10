using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 失智預警系統
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sqlclass sqlc = new sqlclass();
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = sqlc.CheckCaregiver(textBox1.Text, textBox2.Text);
            if (dt.Rows.Count != 0)
            {
                //MessageBox.Show("登入成功！");
                this.Hide();
                (new 失智徵兆分析(dt.Rows[0]["ID"].ToString())).Show();
            }
            else
            {
                MessageBox.Show("查無此用戶！");
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }
    }
}
