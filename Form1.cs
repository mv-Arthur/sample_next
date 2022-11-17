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
    public partial class Form1 : Form
    {
        Query controller; 
        public Form1()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.UpdatePerson();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.Add(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Delete(int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["ID"].Value.ToString()));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu frm2 = new menu();
            frm2.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
