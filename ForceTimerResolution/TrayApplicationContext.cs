using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ForceTimerResolution.Properties;

namespace ForceTimerResolution
{
    public class TrayApplicationContext : ApplicationContext
    {
        [DllImport("ntdll.dll", SetLastError = true)]
        private static extern uint NtSetTimerResolution(uint nanoseconds, bool shouldSet, ref uint result);

        private NotifyIcon icon;

        public TrayApplicationContext()
        {
            uint result = 0;
            NtSetTimerResolution(0, true, ref result);

            icon = new NotifyIcon()
            {
                Icon = Resources.Icon,
                ContextMenu = new ContextMenu(new MenuItem[] { new MenuItem("Stop", Stop) }),
                Text = "ForceTimerResolution\nTimer: " + (result * 0.0001) + "ms",
                Visible = true
            };
        }

        private void Stop(object sender, EventArgs e)
        {
            icon.Visible = false;
            Application.Exit();
        }
    }
}
