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
    public partial class tickets : Form
    {
        ticketsManagment controller;
        public tickets()
        {
            InitializeComponent();
            controller = new ticketsManagment(ConnectionString.ConnStr);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateTickets();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.AddTicket(int.Parse(textBox1.Text), int.Parse(textBox2.Text), textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Remove(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }
    }
}
