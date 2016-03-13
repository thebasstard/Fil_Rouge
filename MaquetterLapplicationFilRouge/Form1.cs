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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1bis f = new Form1bis();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActiveControl = button1;
            button1.Focus();
        }
    }
}
