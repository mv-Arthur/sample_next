using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tickets tick = new tickets();
            tick.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onBoardmechanic mechanic = new onBoardmechanic();
            mechanic.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dispatcher disp = new dispatcher();
            disp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order ord = new order();
            ord.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customers cust = new customers();
            cust.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pilot pil = new pilot();
            pil.Show();
        }
    }
}
