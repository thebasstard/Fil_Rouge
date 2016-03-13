using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace MaquetterLapplicationFilRouge
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}