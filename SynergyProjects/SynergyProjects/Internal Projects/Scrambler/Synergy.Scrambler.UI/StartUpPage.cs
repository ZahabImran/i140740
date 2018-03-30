using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Synergy.Scrambler.Engine;
using System.Data.Common;
using Synergy.Scrambler.Model.Configuration;
using Synergy.Scrambler.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Synergy.Scrambler.UI
{
    public partial class StartUpPage : Form
    {
        CommonFunctions func = new CommonFunctions();
        System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        ProjectConfig PC = new ProjectConfig();
        IScramblerEngine _ISE;
        List<String> _db = new List<String>();
        public StartUpPage()
        {
           Thread t = new Thread(new ThreadStart(SplashStart));
            t.Start();
            Thread.Sleep(2000);
            //    InitializeComponent();
            Splash.CloseForm();
            t.Abort();

            InitializeComponent();
            MaximizeBox = false;
        }
        public StartUpPage(int a)
        {

            InitializeComponent();
            MaximizeBox = false;
        }
        public void SplashStart()
        {
            Splash.ShowSplashScreen();
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
            this.Show();
            this.BringToFront();
            Focus();
            this.Activate();
            groupBox3.Hide();
        }
     
        private void groupBox1_Enter(object sender, EventArgs e)
        {



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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            builder.InitialCatalog = comboBox1.SelectedItem.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (radioButton2.Checked)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = textBox2.Text.ToString();
                builder.Password = textBox3.Text.ToString();

            }
            builder.DataSource = textBox1.Text.ToString();
            //   MessageBox.Show(builder.ConnectionString.ToString());
            _ISE = new MsSqlBusinessLogic(builder.ConnectionString.ToString());

           

            _db = _ISE.GetDatabases(builder.ConnectionString.ToString());
            
                comboBox1.DataSource = _db;

            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
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
            catch
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.SelectedItem.ToString() == "MsSQL")
                {
                    this.Hide();
                    var form2 = new Destination(builder);
                    form2.Closed += (s, args) => this.Close();
                    form2.Show();
                }
            }
            catch
            {

            }
                    
        }

            private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;

                try
                {
                    PC = func.GetConfig(file);
                    IScramblerJobDistributer ISJD;
                    if (PC.ProjectType == 0)
                    {
                        ISJD = new SqlScramblingJobs(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Copy; Integrated Security = True ;");
                        bool check = ISJD.ValidateConfig(PC);
                        if (check == true)
                        {
                            MessageBox.Show("The Configuration file is valid");
                            var form2 = new MaskingPage(PC);
                            form2.Show();

                            form2.Closed += (s, args) => this.Close();

                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Please choose another Configuration file");
                        }


                      

                    }

                }
                catch 
                {
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
