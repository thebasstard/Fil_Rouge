using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaquetterLapplicationFilRouge
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            Hide();
            f.ShowDialog();
            Show();
        }
    }
}
