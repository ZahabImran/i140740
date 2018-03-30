using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Synergy.Scrambler.Common;
using Synergy.Scrambler.Engine;
using Synergy.Scrambler.MaskingSets;
using Synergy.Scrambler.Model.Configuration;
using Synergy.Scrambler.Model;
using System.IO;


namespace Synergy.Scrambler.UI
{
    public partial class MaskingPage : Form
    {
        List<String> list = new List<string>();
        List<String> Slist = new List<string>();
        List<String> Jobs = new List<string>();
        List<String> ExeJobs = new List<string>();
        List<String> list1 = new List<string>();
        List<String> Mlist = new List<string>();

        ProjectConfig PC = new ProjectConfig();
        ProjectConfig ForScrambling = new ProjectConfig();
        ScrambledData SD = new ScrambledData();
        DataMaskingList MD = new DataMaskingList();
        
        CommonFunctions Func = new CommonFunctions();
        ProjectConfig ForMasking = new ProjectConfig();
        ProjectConfig ForHashing = new ProjectConfig();
        ProjectConfig ForParagraph = new ProjectConfig();
        ProjectConfig ForReplace = new ProjectConfig();
        List<Table> myTable = new List<Table>();
        IScramblerJobDistributer ISJD;
        IScramblerEngine ISE;
        public MaskingPage()
        {
            InitializeComponent();
        }
        public MaskingPage(ProjectConfig PC)
        {
            this.PC = PC;

            if (PC.ProjectType == 0 )
            {
                ISE = new MsSqlBusinessLogic(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Copy; Integrated Security = True ;");

                ISJD = new SqlScramblingJobs(@"Data Source = (LocalDb)\MSSQLLocalDB; Initial Catalog = AdventureWorks2012_Copy; Integrated Security = True ;");

            }

            
            InitializeComponent();

            progressBar1.Hide();
        }

        private void MaskingPage_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
            myTable = Func.GetConfigs("");

            foreach (var configTable in PC.TableConfigs)
            {

                List<String> cols = new List<string>();
                cols = Func.CopyNames(cols, configTable);
                TreeNode[] TN = new TreeNode[cols.Count];
                int i = 0;
                foreach (var Cols in cols)
                {


                    TreeNode node1 = new TreeNode(Cols);

                    TN[i] = node1;
                    i++;

                }
                TreeNode treenode = new TreeNode(configTable.TableName, TN);
                treeView1.Nodes.Add(treenode);
            }
            treeView1.Sort();
            treeView1.ExpandAll();
            try
            {

                ForScrambling = ISJD.GetScrambledConfig(PC);
                ForMasking = ISJD.GetMaskingConfig(PC);
                ForParagraph = ISJD.GetParagraphConfig(PC);
                ForReplace = ISJD.GetReplaceConfig(PC);
                list = SD.MakeScrambledData(ForScrambling);
                list1 = MD.MakeMaskedData(ForMasking);
                ForHashing = ISJD.GetHashConfig(PC);
                progressBar1.Maximum = list.Count;
                progressBar1.Step = 1;
                progressBar1.Value = 0;
                Func.SaveStringData(list, Slist);
                Func.SaveStringDataMask(list1, Mlist);
                int j = 0;
                progressBar1.Show();
                foreach (var configTable in ForScrambling.TableConfigs)
                {


                    foreach (var configColumn in configTable.ColumnConfigs)
                    {
                        int i = 0;
                        
                        
                     
                            string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + " = dbo.ActualScrambling(" + configColumn.Name + ")";
                            Console.WriteLine(querystr);
                            Jobs.Add(querystr);

                            // ISE.UpdateDataBase(configTable.TableName,configColumn.Name, list[j].ToString(), Slist[j].ToString());
                            i++;
                            j++;
                            progressBar1.PerformStep();
                       
                        
                        
                       



                    }
                }
                j = 0;
                foreach (var configTable in ForMasking.TableConfigs)
                {


                    foreach (var configColumn in configTable.ColumnConfigs)
                    {
                        int i = 0;


                        string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.ActualMasking(  " + configColumn.Name + "," + configColumn.MappingConfig.ML + " ,'"+configColumn.MappingConfig.MaskChar +"') ";
                        Console.WriteLine(querystr);
                        Jobs.Add(querystr);

                        // ISE.UpdateDataBase(configTable.TableName,configColumn.Name, list[j].ToString(), Slist[j].ToString());
                        i++;
                        j++;
                        progressBar1.PerformStep();



                    }
                }
                foreach (var configTable in ForParagraph.TableConfigs)
                {


                    foreach (var configColumn in configTable.ColumnConfigs)
                    {
                        int i = 0;

                        string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.ParagraphMasking(  " + configColumn.Name + ") ";
                        Jobs.Add(querystr);
                        // ISE.UpdateDataBase(configTable.TableName,configColumn.Name, list[j].ToString(), Slist[j].ToString());
                        i++;
                        j++;
                        progressBar1.PerformStep();



                    }
                }
                j = 0;
                foreach (var configTable in ForHashing.TableConfigs)
                {


                    foreach (var configColumn in configTable.ColumnConfigs)
                    {
                        int i = 0;


                        string querystr = "UPDATE " + configTable.TableName + " SET  " + configColumn.Name + " =  HashBytes ('" + configColumn.MappingConfig.HashCriteria + "' ," + configColumn.Name +")";
                        Console.WriteLine(querystr);
                        Jobs.Add(querystr);

                        // ISE.UpdateDataBase(configTable.TableName,configColumn.Name, list[j].ToString(), Slist[j].ToString());
                        i++;
                        j++;
                        progressBar1.PerformStep();



                    }
                }
                foreach (var configTable in ForReplace.TableConfigs)
                {


                    foreach (var configColumn in configTable.ColumnConfigs)
                    {
                        int i = 0;
                        bool GenderFlag;
                        if (configColumn.Name == "Name")
                        {
                            GenderFlag = Func.CheckGender(myTable, configTable.TableName);
                            if (GenderFlag == true)
                            {
                                string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.GenderFemale(  " + configColumn.Name + ")";
                                Console.WriteLine(querystr);
                                Jobs.Add(querystr);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                                string querystr2 = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.GenderMale(  " + configColumn.Name + ") where Gender='Male'"; 
                                Console.WriteLine(querystr2);
                                Jobs.Add(querystr2);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                            }
                            else if (GenderFlag == false)
                            {
                                string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.Replacement(  " + configColumn.Name + ",'" + configColumn.MappingConfig.ReplaceWith + "') ";
                                Console.WriteLine(querystr);
                                Jobs.Add(querystr);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                            }
                        }
                       

                        else if (configColumn.Name=="Country")
                        {
                            
                            bool CodeFlag = Func.CheckCode(myTable, configTable.TableName);
                            if (CodeFlag == true)
                            {
                                string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.Replacement(  " + configColumn.Name +  ", 'countries')";
                                Console.WriteLine(querystr);
                                Jobs.Add(querystr);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                                string querystr2 = "UPDATE " + configTable.TableName + " SET Code"  + "= dbo.CountryCode(  " + configColumn.Name + ") where Country=Country";
                                Console.WriteLine(querystr2);
                                Jobs.Add(querystr2);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                            }
                            else if (CodeFlag == false)
                            {
                                string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.Replacement(  " + configColumn.Name + ",'" + configColumn.MappingConfig.ReplaceWith + "') ";
                                Console.WriteLine(querystr);
                                Jobs.Add(querystr);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                            }
                        }
                       

                        else if (configColumn.Name == "BirthDate")
                        {

                            bool HireFlag = Func.CheckHireDate(myTable, configTable.TableName);
                            if (HireFlag == true)
                            {
                                string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.Replacement(  " + configColumn.Name + ", '"+configColumn.MappingConfig.ReplaceWith +"')";
                                Console.WriteLine(querystr);
                                Jobs.Add(querystr);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                                string querystr2 = "UPDATE " + configTable.TableName + " SET HireDate" + "= dbo.HireDate(  " + configColumn.Name + ") where BirthDate=BirthDate";
                                Console.WriteLine(querystr2);
                                Jobs.Add(querystr2);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                            }
                            else if (HireFlag == false)
                            {
                                string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.HireDate(  " + configColumn.Name + ",'" + configColumn.MappingConfig.ReplaceWith + "') ";
                                Console.WriteLine(querystr);
                                Jobs.Add(querystr);
                                i++;
                                j++;
                                progressBar1.PerformStep();
                            }
                        }
                        else
                        {
                            string querystr = "UPDATE " + configTable.TableName + " SET " + configColumn.Name + "= dbo.Replacement(  " + configColumn.Name + "," + configColumn.MappingConfig.ReplaceWith + ")";
                            Console.WriteLine(querystr);
                            Jobs.Add(querystr);
                            i++;
                            j++;
                            progressBar1.PerformStep();
                        }





                    }
                }

                Func.SaveStringData(Jobs);
                //     listBox1.DataSource = list1;
                if (progressBar1.Value == progressBar1.Maximum)
                {
                    //       progressBar1.Hide();
                }
                progressBar1.Hide();
            }
            catch
            { }


        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;




        }
        private void backgroundWorker1_ProgressChanged(object sender,
     ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            progressBar1.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString();
        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Show();
            ExeJobs = Func.GetJobs("");

            var result = Func.splitList(ExeJobs, 1);
            progressBar1.Maximum = result.Count();
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            int i = 0;
            Boolean total= true;
            foreach (var job in result)
            {
                i++;
                Boolean check = ISE.UpdateDataBase(job);
                progressBar1.PerformStep();

                if (check == false)
                {
                    MessageBox.Show("SQL error occured in Job Number =>" + i);
                    total = false;
                }
              

            }
            if(total == true)
            {
                MessageBox.Show("All queries were updated successfully");
            }
            else
            {
                MessageBox.Show("Not all queries were updated successfully");
            }
            progressBar1.Hide();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new StartUpPage(1);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
