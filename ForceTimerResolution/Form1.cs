using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ForceTimerResolution
{
    public partial class Form1 : Form
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint NtSetTimerResolution(uint nanoseconds, bool shouldSet, ref uint result);

        public Form1()
        {
            uint result = 0;
            NtSetTimerResolution(0, true, ref result);
            InitializeComponent();
            notifyIcon.Text = "ForceTimerResolution\nTimer: " + (result * 0.0001) + "ms";
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
