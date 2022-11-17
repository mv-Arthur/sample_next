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
    public partial class onBoardmechanic : Form
        
    {
        mechanics controller;
        public onBoardmechanic()
        {
            InitializeComponent();
            controller = new mechanics(ConnectionString.ConnStr);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdateMechanics();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.AddMechanic(textBox1.Text, textBox2.Text, textBox3.Text, int.Parse(textBox4.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Remove(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }
    }
}
