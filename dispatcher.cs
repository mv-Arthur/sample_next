using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sample.Controller;

namespace sample
{
    public partial class dispatcher : Form
    {
        dispatcherManagment controller;
        public dispatcher()
        {
            InitializeComponent();
            controller = new dispatcherManagment(ConnectionString.ConnStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.Updatedispatcher();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.AddDispatcher(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Remove(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }
    }
}
