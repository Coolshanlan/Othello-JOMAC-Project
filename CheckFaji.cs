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
    public partial class CheckFaji : Form
    {
        public CheckFaji()
        {
            InitializeComponent();
        }

        private void CheckFaji_Load(object sender, EventArgs e)
        {
           // timer1.Start();
        }
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "校正中";
            for (int i = 0; i < count; i++)
                label1.Text += ".";
            if (count == 5)
                count = -1;
            count++;
            int w = (this.Width - label1.Width)/2;
            int h = (this.Height - label1.Height)/2;
            label1.Location = new Point(w, h);
        }
    }
}
