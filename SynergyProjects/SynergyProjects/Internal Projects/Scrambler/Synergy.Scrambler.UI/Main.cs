using Synergy.Scrambler.Common;
using Synergy.Scrambler.Engine;
using Synergy.Scrambler.MaskingSets;
using Synergy.Scrambler.Model;
using Synergy.Scrambler.Model.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Synergy.Scrambler.UI
{
    public partial class Form1 : Form
    {
        System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        System.Data.SqlClient.SqlConnectionStringBuilder DestBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        ToolTip buttonToolTip = new ToolTip();

        ProjectConfig PC = new ProjectConfig();
        IScramblerJobDistributer ISJD;
        TableCofig TC = null;
        ColumnConfig CC = null;
        IMappingConfig IMC;
        FirstNames FN = new FirstNames();
        List<String> FNames = new List<string>();
        List<String> Data = new List<string>();
        IScramblerEngine _scramblerEngine;
        List<String> list = new List<String>();
        List<String> list2 = new List<String>();
        List<String> list3 = new List<String>();
        List<String> list4 = new List<String>();
        List<Table> myTable = new List<Table>();
        List<String> MaskingList = new List<string>();
        int check = 0;
        String CurrentParent;
        CommonFunctions func = new CommonFunctions();
        public Form1()
        {
            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\zahab.imran\Desktop\Database1.mdb;persist security info = false; ";
            _scramblerEngine = new MsAccessBusinessLogic(connectionString);
            InitializeComponent();
        }

        public Form1(int num)
        {

            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\zahab.imran\Desktop\Database1.mdb;persist security info = false;";
            _scramblerEngine = new MsAccessBusinessLogic(connectionString);
            check = 1;
            PC.ProjectType = ProjectType.MSAccess;
            PC.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\zahab.imran\Desktop\Database1.mdb;persist security info = false;";

            InitializeComponent();

        }

        public Form1(String num)
        {


            var connectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Data; Integrated Security = True ;";
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            check = 2;
            PC.ProjectType = ProjectType.MSSqlServer;
            PC.ConnectionString = @"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Data; Integrated Security = True ;";

            InitializeComponent();

        }
        public Form1(System.Data.SqlClient.SqlConnectionStringBuilder builder, System.Data.SqlClient.SqlConnectionStringBuilder DestBuilder)

        {

            this.builder = builder;
            this.DestBuilder = DestBuilder;
            var connectionString = builder.ConnectionString.ToString();
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            check = 2;
            PC.ProjectType = ProjectType.MSSqlServer;
            PC.ConnectionString = builder.ConnectionString.ToString();

            InitializeComponent();

        }

        public Form1(ProjectConfig PC)
        {

            this.PC = PC;
            if (PC.ProjectType == 0)
            {
                ISJD = new SqlScramblingJobs(DestBuilder.ConnectionString.ToString());
            }
            InitializeComponent();



        }
        public Form1(IScramblerEngine engine)
        {
            _scramblerEngine = engine;
            InitializeComponent();
        }

        private void btnFetchTables_Click(object sender, EventArgs e)
        {
            try
            {
                list.Clear();
                listBox3.DataSource = null;
                listBox3.Items.Clear();
                myTable = _scramblerEngine.FetchSchema();
                list = func.copyNames(list, myTable);

                list3.Clear();
                listBox3.DataSource = null;
                listBox3.Items.Clear();

                foreach (var table in myTable)
                {
                    List<String> cols = new List<string>();
                    cols = func.CopyNames(cols, table.ColumnsList);
                    TreeNode[] TN = new TreeNode[cols.Count];
                    int i = 0;
                    foreach (var Col in cols)
                    {
                        TreeNode node1 = new TreeNode(Col);

                        TN[i] = node1;
                        i++;
                    }
                    TreeNode treenode = new TreeNode(table.TableName, TN);
                    treeView1.Nodes.Add(treenode);


                }
                treeView1.Sort();
            }
            catch (Exception)
            {
                MessageBox.Show("the Tables are already fetched");
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new StartUpPage(1);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (check == 2)
            {
                try
                {
                    this.Hide();
                    //  String TableName = listBox1.SelectedItem.ToString();
                    //    var form2 = new DataSet(1, TableName);
                    //   form2.Closed += (s, args) => this.Close();
                    //     form2.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please select a Table");
                    this.Show();
                }
            }
            if (check == 1)
            {
                try
                {
                    this.Hide();
                    //   String TableName = listBox1.SelectedItem.ToString();
                    //     var form2 = new DataSet("1", TableName);
                    //     form2.Closed += (s, args) => this.Close();
                    //      form2.Show();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please select a Table");
                    this.Show();
                }
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Clear();
            FNames.Clear();
            if (listBox5.SelectedIndex != -1)
            {
                if (listBox5.SelectedItem.ToString().Equals("FirstName"))
                {
                    //      Data = _scramblerEngine.FetchData(listBox1.SelectedItem.ToString(),"*");
                    FNames = FN.RandomNames(Data.Count);


                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new DataSet(1, FNames);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //  _scramblerEngine.Processing(listBox1.SelectedItem.ToString());
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox5.Hide();
            label9.Hide();
            comboBox3.Hide();
            label7.Hide();
            try
            {
                list.Clear();
                listBox3.DataSource = null;
                listBox3.Items.Clear();
                myTable = _scramblerEngine.FetchSchema();
                list = func.copyNames(list, myTable);
                func.SaveConfig(myTable, @"C:\Users\My Book\Desktop\ayesha.txt");
                list3.Clear();
                listBox3.DataSource = null;
                listBox3.Items.Clear();
                List<String> TableRules = new List<string>();
                List<String> ColumnRules = new List<string>();
                func.fetchRules(TableRules, ColumnRules);
                bool check2 = false;
                Boolean check = false;
                Boolean check3 = false;
                foreach (var table in myTable)
                {

                    List<String> cols = new List<string>();
                    cols = func.CopyNames(cols, table.ColumnsList);
                    TreeNode[] TN = new TreeNode[cols.Count];
                    int i = 0;
                    foreach (var tRule in TableRules)
                    {
                        check = func.sensitivityTest(table.TableName, tRule);

                        if (check == true)
                        {
                            break;
                        }
                    }
                    // var matchingvalues = TableRules.Where(stringToCheck => stringToCheck.Contains(table.TableName));
                    foreach (var Col in cols)
                    {

                        if (check == true)
                        {
                            foreach (var cRule in ColumnRules)
                            {
                                check2 = func.sensitivityTest(Col, cRule);
                                if (check2 == true)
                                {
                                    break;
                                }

                            }

                            if (check2 == true)
                            {
                                TreeNode node1 = new TreeNode(Col);
                                var font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
                                var color = Color.LightGray;

                                node1.NodeFont = font;

                                node1.BackColor = color;

                                TN[i] = node1;
                                i++;
                                check3 = true;

                            }
                            else
                            {
                                TreeNode node1 = new TreeNode(Col);
                                TN[i] = node1;
                                i++;

                            }
                        }
                        else
                        {
                            TreeNode node1 = new TreeNode(Col);

                            TN[i] = node1;
                            i++;
                        }
                    }
                    if (check3 == true)
                    {
                        check3 = false;
                        TreeNode treenode = new TreeNode(table.TableName, TN);
                        var font1 = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Underline, GraphicsUnit.Point);
                        treenode.NodeFont = font1;
                        treeView1.Nodes.Add(treenode);
                    }
                    else
                    {
                        TreeNode treenode = new TreeNode(table.TableName, TN);

                        treeView1.Nodes.Add(treenode);

                    }
                }
                treeView1.Sort();
                label8.Hide();
                textBox1.Hide();
                comboBox1.Hide();
                label7.Hide();
                label4.Hide();
                comboBox3.Hide();
                label6.Hide();
                comboBox4.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("the Tables are already fetched");
            }

            pictureBox2.Hide();


            toolTip1.SetToolTip(comboBox1, "Different Masking techniques are available");

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (CC != null)
            {
                PC.TableConfigs.Add(TC);

            }

            saveFileDialog1.ShowDialog();




        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {






        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Data Replacement")
            {
                CC = new ColumnConfig();
                TreeNode node = treeView1.SelectedNode;
                var font = new Font(treeView1.Font, FontStyle.Italic);
                var color = Color.LightGray;

                node.NodeFont = font;
                node.Parent.NodeFont = font;
                node.BackColor = color;
                node.Parent.BackColor = color;
                TC.TableName = node.Parent.Text.ToString();
                CC.Name = node.Text.ToString();
                CC.DataType = "";
                IMC = new ReplaceDS();

                IMC.StoreInObject("Data Replacement", comboBox5.SelectedItem.ToString());

                CC.MappingConfig = IMC;
                TC.ColumnConfigs.Add(CC);


            }
            else if (comboBox2.SelectedItem.ToString() == "Data Scramble")
            {
                CC = new ColumnConfig();
                TreeNode node = treeView1.SelectedNode;
                var font = new Font(treeView1.Font, FontStyle.Italic);
                var color = Color.LightGray;

                node.NodeFont = font;
                node.Parent.NodeFont = font;
                node.BackColor = color;
                node.Parent.BackColor = color;

                TC.TableName = node.Parent.Text.ToString();
                CC.Name = node.Text.ToString();
                CC.DataType = "";
                IMC = new Scramble();
                IMC.StoreInObject("Data Scramble", Convert.ToInt32(comboBox1.SelectedItem));
                CC.MappingConfig = IMC;
                TC.ColumnConfigs.Add(CC);



            }
            else if (comboBox2.SelectedItem.ToString() == "Data Hash")
            {
                CC = new ColumnConfig();
                TreeNode node = treeView1.SelectedNode;
                var font = new Font(treeView1.Font, FontStyle.Italic);
                var color = Color.LightGray;

                node.NodeFont = font;
                node.Parent.NodeFont = font;
                node.BackColor = color;
                node.Parent.BackColor = color;

                TC.TableName = node.Parent.Text.ToString();
                CC.Name = node.Text.ToString();
                CC.DataType = "";
                IMC = new Hashing();
                IMC.StoreInObject("Data Hash", Convert.ToInt32(comboBox1.SelectedItem), comboBox4.SelectedItem.ToString());
                CC.MappingConfig = IMC;
                TC.ColumnConfigs.Add(CC);



            }
            else if (comboBox2.SelectedItem.ToString() == "Data Mask")
            {

                CC = new ColumnConfig();
                TreeNode node = treeView1.SelectedNode;
                var font = new Font(treeView1.Font, FontStyle.Italic);
                var color = Color.LightGray;

                node.NodeFont = font;
                node.Parent.NodeFont = font;
                node.BackColor = color;
                node.Parent.BackColor = color;
                TC.TableName = node.Parent.Text.ToString();
                CC.Name = node.Text.ToString();
                CC.DataType = "";
                IMC = new DataMask();
                if (comboBox3.SelectedItem.ToString() != "")
                {
                    IMC.StoreInObject("Data Mask", 0, Convert.ToInt32(textBox1.Text), comboBox3.SelectedItem.ToString());

                    CC.MappingConfig = IMC;
                    TC.ColumnConfigs.Add(CC);
                }
                else
                {
                    IMC.StoreInObject("Data Mask", 0, Convert.ToInt32(textBox1.Text), "x");

                    CC.MappingConfig = IMC;
                    TC.ColumnConfigs.Add(CC);
                }

            }
            else if (comboBox2.SelectedItem.ToString() == "Data ParagraphMask")
            {

                CC = new ColumnConfig();
                TreeNode node = treeView1.SelectedNode;
                var font = new Font(treeView1.Font, FontStyle.Italic);
                var color = Color.LightGray;

                node.NodeFont = font;
                node.Parent.NodeFont = font;
                node.BackColor = color;
                node.Parent.BackColor = color;
                TC.TableName = node.Parent.Text.ToString();
                CC.Name = node.Text.ToString();
                CC.DataType = "";
                IMC = new ParagraphMask();

                IMC.StoreInObject("ParagraphMask", 0);

                CC.MappingConfig = IMC;
                TC.ColumnConfigs.Add(CC);



            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new GetConfig();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = @"C:\Users\zahab.imran\Desktop\200.gif";
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.Show();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                button8.Enabled = false;
            }
            else
            {
                button8.Enabled = true;
            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            /*  listBox6.Show();
              TreeNode node = treeView1.SelectedNode;
              MessageBox.Show(string.Format(node.Text   + node.Parent.Text));
      */
            TreeNode node = treeView1.SelectedNode;
            int Total;
            if (node.Parent == null)
            {
                Total = _scramblerEngine.FetchTotal(node.Text.ToString(), "*");

            }
            else
            {
                Total = _scramblerEngine.FetchTotal(node.Parent.Text.ToString(), "*");
            }
            comboBox1.Items.Clear();
            for (int i = 1; i <= Total; i++)
            {
                comboBox1.Items.Add(i);
            }
            if (node.Parent != null)
            {
                if (CurrentParent != node.Parent.Text.ToString())
                {
                    CurrentParent = node.Parent.Text.ToString();
                    if (CC != null)
                    {
                        PC.TableConfigs.Add(TC);

                    }
                    TC = new TableCofig();
                    CC = new ColumnConfig();
                }
            }

        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

            string name = saveFileDialog1.FileName;

            func.SaveConfig(PC, name);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (comboBox2.SelectedItem.ToString() == "Data Mask")
                {
                    toolTip1.SetToolTip(this.comboBox2, "Masks the Data . For example Zahab would become XXhab");
                    label6.Hide();
                    comboBox4.Hide();
                    comboBox1.Enabled = true;
                    label8.Show();
                    //   label7.Show();
                    //  comboBox1.Show();
                    textBox1.Show();
                    textBox1.Enabled = true;
                    button8.Enabled = false;


                }
                if (comboBox2.SelectedItem.ToString() == "Data ParagraphMask")
                {
                    comboBox5.Hide();
                    label9.Hide();
                    toolTip1.SetToolTip(this.comboBox2, "Masks the Data . For example Zahab would become XXhab");
                    label6.Hide();
                    comboBox4.Hide();
                    comboBox1.Enabled = true;
                    label8.Show();
                    //   label7.Show();
                    //  comboBox1.Show();
                    textBox1.Show();
                    textBox1.Enabled = true;
                    button8.Enabled = false;
                    label4.Show();
                    comboBox3.Show();


                }
                else if (comboBox2.SelectedItem.ToString() == "Data Replacement")
                {
                    comboBox5.Show();
                    label9.Show();
                    toolTip1.SetToolTip(this.comboBox2, "Masks the Data . For example Zahab would become XXhab");
                    label6.Hide();
                    comboBox4.Hide();

                    button8.Enabled = true;
                    label8.Hide();
                    //   label7.Show();
                    //  comboBox1.Show();
                    textBox1.Hide();
                    comboBox3.Hide();

                }

                else if (comboBox2.SelectedItem.ToString() == "Data Scramble")
                {
                    toolTip1.SetToolTip(this.comboBox2, "Scrambles The data . For example Zahab would become aahbz");
                    label6.Hide();
                    comboBox4.Hide();
                    comboBox1.Enabled = true;
                    button8.Enabled = true;
                    label7.Show();
                    comboBox1.Show();
                    button8.Show();

                    label8.Hide();
                    textBox1.Hide();
                    label4.Hide();
                    comboBox3.Hide();

                    textBox1.Enabled = false;
                }

                else if (comboBox2.SelectedItem.ToString() == "Data Hash")
                {
                    label6.Show();
                    comboBox4.Show();
                    toolTip1.SetToolTip(this.comboBox2, "would generate hash code for the data");

                    comboBox1.Enabled = true;
                    button8.Enabled = true;
                    // label7.Show();
                    //  comboBox1.Show();
                    button8.Show();

                    label8.Hide();
                    textBox1.Hide();
                    label4.Hide();
                    comboBox3.Hide();

                    textBox1.Enabled = false;
                }


                else if (comboBox2.SelectedItem.ToString() == "Data Hash")
                {
                    label8.Hide();
                    textBox1.Hide();
                    label4.Hide();
                    comboBox3.Hide();
                    label6.Hide();
                    comboBox4.Hide();
                }

            }
            catch
            {

            }


        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Destination(builder);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void optionsvalueComboBox_MouseHover(object sender, EventArgs e)
        {
            buttonToolTip.ToolTipTitle = "Value";
            buttonToolTip.UseFading = true;
            buttonToolTip.UseAnimation = true;
            buttonToolTip.IsBalloon = true;
            buttonToolTip.ShowAlways = true;
            buttonToolTip.AutoPopDelay = 5000;
            buttonToolTip.InitialDelay = 1000;
            buttonToolTip.ReshowDelay = 0;

            buttonToolTip.SetToolTip(comboBox2, comboBox2.Text);
        }
    }
}
