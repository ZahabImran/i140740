using System;
using System.Windows.Forms;
using Synergy.Scrambler.Common;
using Synergy.Scrambler.Model.Configuration;

namespace Synergy.Scrambler.UI
{
    public partial class Prompt : Form
    {
        ProjectConfig PC = new ProjectConfig();
        CommonFunctions Func = new CommonFunctions();
        public Prompt()
        {
            InitializeComponent();
        }
        public Prompt(ProjectConfig PC)
        {
            this.PC = PC;
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Func.SaveConfig(PC, textBox1.Text.ToString());
            this.Hide();
            var form2 = new StartUpPage();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }
    }
}
