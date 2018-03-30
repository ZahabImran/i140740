using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Synergy.Scrambler.Engine;

namespace Synergy.Scrambler.UI
{
    public partial class Destination : Form
    {
        System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        System.Data.SqlClient.SqlConnectionStringBuilder Sourcebuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();

        IScramblerEngine _ISE;
        List<String> _db = new List<String>();
        public Destination()
        {
            InitializeComponent();
            MaximizeBox = false;

        }
        public Destination(System.Data.SqlClient.SqlConnectionStringBuilder build)
        {
            Sourcebuilder = build;
            InitializeComponent();
            MaximizeBox = false;
            groupBox3.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            var form2 = new Form1("1");
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form1(1);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void StartUpPage_Load(object sender, EventArgs e)
        {

            groupBox3.Hide();
        }

       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                builder.IntegratedSecurity = true;
                groupBox2.Enabled = false;

            }
            if (radioButton2.Checked)
            {
                builder.IntegratedSecurity = true;
                groupBox2.Enabled = true;
            }
        }

     
        


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            builder.InitialCatalog = comboBox1.SelectedItem.ToString();
            MessageBox.Show(builder.ConnectionString.ToString());

        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "MsSQL")
            {
                groupBox3.Show();
            }
            else
            {
                groupBox3.Hide();
            }
        }

   

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "MsSQL")
            {
                this.Hide();
                var form2 = new Form1(Sourcebuilder,builder);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = textBox2.Text.ToString();
                builder.Password = textBox3.Text.ToString();

            }
            builder.DataSource = textBox1.Text.ToString();
            comboBox1.DataSource = _db;

            //   MessageBox.Show(builder.ConnectionString.ToString());
            _ISE = new MsSqlBusinessLogic(builder.ConnectionString.ToString());
            _db = _ISE.GetDatabases(builder.ConnectionString.ToString());
            comboBox1.DataSource = _db;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

            if (radioButton2.Checked)

            {
                builder.IntegratedSecurity = false;
                builder.UserID = textBox2.Text.ToString();
                builder.Password = textBox3.Text.ToString();

            }
            builder.DataSource = textBox1.Text.ToString();
            builder.InitialCatalog = comboBox1.SelectedItem.ToString();
            _ISE = new MsSqlBusinessLogic(builder.ConnectionString.ToString());

            Boolean test = _ISE.TestCon();
            if (test == true)
            {
                MessageBox.Show("Connection was a success");
                button2.Enabled = true;

            }
            if (test == false)
            {
                MessageBox.Show("Connection was not succesful");
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedItem.ToString() == "MsSQL")
                {
                    this.Hide();
                    var form2 = new Form1(Sourcebuilder, builder);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
            catch { }

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                builder.IntegratedSecurity = true;
                groupBox2.Enabled = false;

            }
            if (radioButton2.Checked)
            {
                builder.IntegratedSecurity = true;
                groupBox2.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                builder.IntegratedSecurity = true;
                groupBox2.Enabled = false;

            }
            if (radioButton2.Checked)
            {
                builder.IntegratedSecurity = true;
                groupBox2.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            builder.InitialCatalog = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (comboBox2.SelectedItem.ToString() == "MsSQL")
            {
                groupBox3.Show();

            }
            else
            {
                button2.Enabled = false;
                groupBox3.Hide();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new StartUpPage(1);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
