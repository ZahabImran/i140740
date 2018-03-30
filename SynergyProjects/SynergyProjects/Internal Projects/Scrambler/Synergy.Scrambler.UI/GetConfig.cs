using System;
using System.Windows.Forms;
using Synergy.Scrambler.Common;
using Synergy.Scrambler.Model.Configuration;

namespace Synergy.Scrambler.UI
{
    public partial class GetConfig : Form
    {
        public ProjectConfig PC = new ProjectConfig();
        CommonFunctions Func = new CommonFunctions();

        public GetConfig()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           PC= Func.GetConfig(textBox1.Text.ToString());
            this.Hide();
            var form2 = new Form1(PC);
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
