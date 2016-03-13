using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MaquetterLapplicationFilRouge
{
    public partial class Form4 : Form
    {
        public Form4()
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
            Form3 f = new Form3();
            Hide();
            f.ShowDialog();
            Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (label20.Text == "OK")
            {
                MessageBox.Show("Saisie corrrecte");
            }
            else
            {
                MessageBox.Show("Saisie incorrrecte");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                textBox1.BackColor = Color.White;
                label19.Visible = false;
            }
            else
            {

                try
                {

                    Regex ReNom = new Regex(@"^[a-zA-Z -]+$");

                    if (ReNom.IsMatch(textBox1.Text))
                    {
                        textBox1.BackColor = Color.White;
                        label19.ForeColor = Color.Green;
                        label19.Visible = true;
                        label19.Text = "OK";
                    }
                    else
                    {
                        textBox1.BackColor = Color.Red;                       
                        label19.Visible = true;
                        label19.Text = "Saisie...";
                    }
                }
                catch (Exception ErreurNom)
                {
                    MessageBox.Show(ErreurNom.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox12;
            textBox12.Focus();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

            if (textBox14.Text == "")
            {
                textBox14.BackColor = Color.White;
                label20.Visible = false;
            }
            else
            {

                try
                {

                    Regex ReMail = new Regex(@"^[a-zA-Z]{2,}@[a-zA-Z]{2,}\.[a-zA-Z]{2,}$");

                    if (ReMail.IsMatch(textBox14.Text))
                    {
                        textBox14.BackColor = Color.White;
                        label20.ForeColor = Color.Green;
                        label20.Visible = true;
                        label20.Text = "OK";
                    }
                    else
                    {
                        textBox14.BackColor = Color.White;
                        label20.Visible = true;
                        label20.Text = "Saisie...";
                    }
                }
                catch (Exception ErreurMail)
                {
                    MessageBox.Show(ErreurMail.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
