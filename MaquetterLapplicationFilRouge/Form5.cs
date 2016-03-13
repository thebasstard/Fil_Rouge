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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
