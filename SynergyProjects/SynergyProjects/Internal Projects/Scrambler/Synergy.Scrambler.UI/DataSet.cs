using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Synergy.Scrambler.Engine;

namespace Synergy.Scrambler.UI
{
    public partial class DataSet : Form
    {
        IScramblerEngine _scramblerEngine;
        int check = 0;
        List<String> result = new List<string>();
        String TableName;
        public DataSet()
        {
            InitializeComponent();
        }
        public DataSet(int check,String TableName)
        {
            var connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Integrated Security=True";
            this.TableName = TableName;
            _scramblerEngine = new MsSqlBusinessLogic(connectionString);
            InitializeComponent();
        }
        public DataSet(int check,List<String> Fnames)
        {
            this.check = check;
            result = Fnames;
             InitializeComponent();
        }
        public DataSet(String check, String TableName)
        {
            var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\zahab.imran\Desktop\Database1.mdb;persist security info = false;";
            this.TableName = TableName;
            _scramblerEngine = new MsAccessBusinessLogic(connectionString);
            InitializeComponent();
        }


        private void DataSet_Load(object sender, EventArgs e)
        {
            if (check == 1)
            {
                listBox1.DataSource = result;
            }
            else
            {
            //    result = _scramblerEngine.FetchData(TableName,"*");
                listBox1.DataSource = result;
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
