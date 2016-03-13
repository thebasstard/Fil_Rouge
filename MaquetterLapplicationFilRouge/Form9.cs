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
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace MaquetterLapplicationFilRouge
{
    public partial class Form9 : Form
    {
        string action = "";

        public Form9()
        {
            InitializeComponent();

            comboBox1.Items.Add("Professionnel");
            comboBox1.Items.Add("Particulier");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            Hide();
            f.ShowDialog();
            Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            action = "ajouter";

        }

        private void button2_Click(object sender, EventArgs e)
        {

            action = "modifier";

            int ID = (int)listBox1.SelectedValue;

            CommandeDAO Data = new CommandeDAO();

            Commande Com = Data.FindCommande(ID);

            textBox4.Text = Com.DateCommande;
            textBox5.Text = Com.EtatCommande;
            textBox6.Text = Com.DatePaiement;
            textBox7.Text = Com.InfoPaiement;
            textBox8.Text = Com.ReducSup;
            textBox9.Text = Com.PTHT;
            textBox10.Text = Com.PTTC;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            action = "supprimer";

            int ID = (int)listBox1.SelectedValue;

            CommandeDAO Data = new CommandeDAO();

            Commande Com = Data.FindCommande(ID);

            textBox4.Text = Com.DateCommande;
            textBox5.Text = Com.EtatCommande;
            textBox6.Text = Com.DatePaiement;
            textBox7.Text = Com.InfoPaiement;
            textBox8.Text = Com.ReducSup;
            textBox9.Text = Com.PTHT;
            textBox10.Text = Com.PTTC;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (action == "ajouter")
            {

                Commande Com = new Commande();

                Com.DateCommande = textBox4.Text;
                Com.EtatCommande = textBox5.Text;
                Com.DatePaiement = textBox6.Text;
                Com.InfoPaiement = textBox7.Text;
                Com.ReducSup = textBox8.Text;
                Com.PTHT = textBox9.Text;
                Com.PTTC = textBox10.Text;

                CommandeDAO Data = new CommandeDAO();

                Data.Insert(Com);

                listBox1.DataSource = Data.List();

                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();

            }

            if (action == "modifier")
            {
                Commande Com = new Commande();

                Com.IDCommande = (int)listBox1.SelectedValue;
                Com.DateCommande = textBox4.Text;
                Com.EtatCommande = textBox5.Text;
                Com.DatePaiement = textBox6.Text;
                Com.InfoPaiement = textBox7.Text;
                Com.ReducSup = textBox8.Text;
                Com.PTHT = textBox9.Text;
                Com.PTTC = textBox10.Text;

                CommandeDAO Data = new CommandeDAO();

                Data.Update(Com);

                listBox1.DataSource = Data.List();

            }

            if (action == "supprimer")
            {

                Commande Com = new Commande();

                Com.IDCommande = (int)listBox1.SelectedValue;
                Com.DateCommande = textBox4.Text;
                Com.EtatCommande = textBox5.Text;
                Com.DatePaiement = textBox6.Text;
                Com.InfoPaiement = textBox7.Text;
                Com.ReducSup = textBox8.Text;
                Com.PTHT = textBox9.Text;
                Com.PTTC = textBox10.Text;

                CommandeDAO Data = new CommandeDAO();

                Data.Delete(Com);

                listBox1.DataSource = Data.List();
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

            this.ActiveControl = textBox9;

            textBox9.Focus();

            comboBox1.SelectedItem = "Professionnel";

            CommandeDAO DataCommande = new CommandeDAO();

            listBox1.DisplayMember = "TotalInfoCommande";
            listBox1.ValueMember = "IDCommande";
            listBox1.DataSource = DataCommande.List();

            Commande com = new Commande();



            string SQL_String = "server = .; database = village_green; integrated security = true";
            SqlConnection Connect = new SqlConnection(SQL_String);
            Connect.Open();

            SqlCommand CalculChiffreAffaireTotal = new SqlCommand("select SUM(PTHT) from gratte.Commande", Connect);

            var Resultat = CalculChiffreAffaireTotal.ExecuteScalar();
            textBox2.Text = Convert.ToString(Resultat);

            Connect.Close();

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.BackColor = Color.White;
                label18.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReHT = new Regex(@"^[0-9]{1,}(\,)?[0-9]{0,2}$");

                    if (ReHT.IsMatch(textBox9.Text))
                    {
                        textBox9.BackColor = Color.White;
                        label18.ForeColor = Color.Green;
                        label18.Visible = true;
                        label18.Text = "OK";
                    }
                    else
                    {
                        textBox9.BackColor = Color.Red;
                        label18.Visible = false;
                    }
                }
                catch (Exception ErrorHT)
                {
                    MessageBox.Show(ErrorHT.Message);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {



        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            CommandeDAO DataCommande = new CommandeDAO();

            listBox2.DisplayMember = "TotalInfoClient";
            listBox2.ValueMember = "IDClient";
           
                if (textBox3.Text == "")
                {

                    listBox2.DataSource = DataCommande.List();

                }

                else
                {

                    try
                    {

                        int NumeroClient = Convert.ToInt32(textBox3.Text);

                        listBox2.DataSource = DataCommande.ListByClient(NumeroClient);

                    }

                    catch (Exception erreur)
                    {

                        MessageBox.Show(erreur.Message);

                    }
                }

            if (listBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Le numéro de client n'existe pas");
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.BackColor = Color.White;
                label19.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReTTC = new Regex(@"^[0-9]{1,}(\,)?[0-9]{0,2}$");

                    if (ReTTC.IsMatch(textBox10.Text))
                    {
                        textBox10.BackColor = Color.White;
                        label19.ForeColor = Color.Green;
                        label19.Visible = true;
                        label19.Text = "OK";
                    }
                    else
                    {
                        textBox10.BackColor = Color.Red;
                        label19.Visible = false;
                    }

                }
                catch (Exception ErrorTTC)
                {
                    MessageBox.Show(ErrorTTC.Message);
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.BackColor = Color.White;
                label20.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReReduc = new Regex(@"^[0-9]{1,}(\,)?[0-9]{0,2}$");

                    if (ReReduc.IsMatch(textBox8.Text))
                    {
                        textBox8.BackColor = Color.White;
                        label20.ForeColor = Color.Green;
                        label20.Visible = true;
                        label20.Text = "OK";
                    }
                    else
                    {
                        textBox8.BackColor = Color.Red;
                        label20.Visible = false;
                    }
                }
                catch (Exception ErrorReduc)
                {
                    MessageBox.Show(ErrorReduc.Message);
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.BackColor = Color.White;
                label21.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReDateCommande = new Regex(@"^[0-9][0-9]\/[0-9][0-9]\/[0-9][0-9][0-9][0-9]$");

                    if (ReDateCommande.IsMatch(textBox4.Text))
                    {
                        textBox4.BackColor = Color.White;
                        label21.ForeColor = Color.Green;
                        label21.Visible = true;
                        label21.Text = "OK";
                    }
                    else
                    {
                        textBox4.BackColor = Color.Red;
                        label21.Visible = false;
                    }
                }
                catch (Exception ErrorDateCommande)
                {
                    MessageBox.Show(ErrorDateCommande.Message);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.BackColor = Color.White;
                label23.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReDatePaiement = new Regex(@"^[0-9][0-9]\/[0-9][0-9]\/[0-9][0-9][0-9][0-9]$");

                    if (ReDatePaiement.IsMatch(textBox6.Text))
                    {
                        textBox6.BackColor = Color.White;
                        label23.ForeColor = Color.Green;
                        label23.Visible = true;
                        label23.Text = "OK";
                    }
                    else
                    {
                        textBox6.BackColor = Color.Red;
                        label23.Visible = false;
                    }
                }
                catch (Exception ErrorDatePaiement)
                {
                    MessageBox.Show(ErrorDatePaiement.Message);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.BackColor = Color.White;
                label22.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReEtatCommande = new Regex(@"^[a-zA-Z -]+$");

                    if (ReEtatCommande.IsMatch(textBox5.Text))
                    {
                        textBox5.BackColor = Color.White;
                        label22.ForeColor = Color.Green;
                        label22.Visible = true;
                        label22.Text = "OK";
                    }
                    else
                    {
                        textBox5.BackColor = Color.Red;
                        label22.Visible = false;

                    }
                }
                catch (Exception ErrorDatePaiement)
                {
                    MessageBox.Show(ErrorDatePaiement.Message);
                }

            }
        }


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.BackColor = Color.White;
                label24.Visible = false;
            }
            else
            {
                try
                {
                    Regex ReInfoPaiement = new Regex(@"^[a-zA-Z -é']+$");

                    if (ReInfoPaiement.IsMatch(textBox7.Text))
                    {
                        textBox7.BackColor = Color.White;
                        label24.ForeColor = Color.Green;
                        label24.Visible = true;
                        label24.Text = "OK";
                    }
                    else
                    {
                        textBox7.BackColor = Color.Red;
                        label24.Visible = false;

                    }
                }
                catch (Exception ErrorDatePaiement)
                {
                    MessageBox.Show(ErrorDatePaiement.Message);
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SQL_String = "server = .; database = village_green; integrated security = true";
            SqlConnection Connect = new SqlConnection(SQL_String);
            Connect.Open();
       

            if (comboBox1.SelectedItem == "Professionnel")
            {

                SqlCommand CalculChiffreAffairePro = new SqlCommand(@"select SUM(PTHT) from gratte.Commande join gratte.Client 
                                                                    on gratte.Commande.ID_Client = gratte.Client.ID_Client
                                                                    where Categorie = 1", Connect);

                var Resultat1 = CalculChiffreAffairePro.ExecuteScalar();
                textBox1.Text = Convert.ToString(Resultat1);

            }

            else
            {

                SqlCommand CalculChiffreAffaireParticulier = new SqlCommand(@"select SUM(PTHT) from gratte.Commande join gratte.Client 
                                                                            on gratte.Commande.ID_Client = gratte.Client.ID_Client
                                                                            where Categorie = 0", Connect);

                var Resultat2 = CalculChiffreAffaireParticulier.ExecuteScalar();
                textBox1.Text = Convert.ToString(Resultat2);

            }

            Connect.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.BackColor = Color.White;                
            }
            else
            {
                try
                {
                    Regex ReInfoPaiement = new Regex(@"^[0-9][0-9][0-9][0-9]$");

                    if (ReInfoPaiement.IsMatch(textBox3.Text))
                    {

                        textBox3.BackColor = Color.White;
                        
                    }

                    else
                    {

                        textBox3.BackColor = Color.Red;
                        
                    }
                }

                catch (Exception ErrorDatePaiement)
                {

                    MessageBox.Show(ErrorDatePaiement.Message);

                }

            }
        }
    }
}
