using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Synergy.Scrambler.UI
{
    public sealed partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();

            ClientSize = BackgroundImage.Size;
            Opacity = .0;
            tUpdateTimer.Interval = TimerInterval;
            tUpdateTimer.Start();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            lblVersion.Text = GetAssemblyVersion();
        }

        private string GetAssemblyVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            if (assembly.Location == null) return string.Empty;

            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return $"v{fvi.FileVersion}";
        }

        static Splash _frmSplash;
        static Thread _thread;
        private double _dblOpacityIncrement = .05;
        private double _dblOpacityDecrement = .05;
        private const int TimerInterval = 20;

        private static void ShowForm()
        {
            _frmSplash = new Splash();
            Application.Run(_frmSplash);
        }

        public static void CloseForm()
        {
            if (_frmSplash != null)
            {
                // Make it start going away.
                _frmSplash._dblOpacityIncrement = -_frmSplash._dblOpacityDecrement;
            }
            _thread = null;  // we do not need these any more.
            _frmSplash = null;
        }

        public static void ShowSplashScreen()
        {
            // Make sure it is only launched once.
            if (_frmSplash != null)
                return;
            _thread = new Thread(ShowForm) {IsBackground = true};
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
            while (_frmSplash == null || _frmSplash.IsHandleCreated == false)
            {
                Thread.Sleep(TimerInterval);
            }
        }

        private void tUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (_dblOpacityIncrement > 0)
            {
                if (Opacity < 1)
                    Opacity += _dblOpacityIncrement;
            }
            else
            {
                if (Opacity > 0)
                    Opacity += _dblOpacityIncrement;
                else
                    Close();
            }
        }

        private void Splash_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void Splash_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                CloseForm();
        }
    }
}
