using oh_hello.config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oh_hello.control
{
    public class MordhauControl
    {
        public const UInt32 WM_KEYDOWN = 0x0100;
        public const UInt32 WM_KEYUP = 0x0101;

        private const int sendKeyDelay = 20;

        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

        private ConfigManager configManager;
        private BackgroundWorker backgroundWorker;

        public MordhauControl(ConfigManager configManager)
        {
            this.configManager = configManager;
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            backgroundWorker.WorkerSupportsCancellation = true;
        }

        public void Play()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
            }
            else
            {
                if (configManager.GetProperty(PropertyItem.Loop))
                {
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    SendCommand();
                }
            }
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker currentWorker = (BackgroundWorker)sender;
            while (!currentWorker.CancellationPending)
            {
                SendCommand();
                Thread.Sleep(500);
            }
        }

        private void SendCommand()
        {
            Process[] processes = Process.GetProcessesByName("Mordhau-Win64-Shipping");
            for (int i = 0; i < configManager.GetTabIndex(); i++)
            {
                SendKey(processes, configManager.GetHotkey(HotkeyItem.VoiceCommandMenuKey));
            }
            SendKey(processes, configManager.GetCommandKey());
        }

        private void SendKey(Process[] processes, Keys key)
        {
            foreach (Process proc in processes)
            {
                PostMessage(proc.MainWindowHandle, WM_KEYDOWN, (int)key, 0);
            }
            Thread.Sleep(sendKeyDelay);
        }
    }
}
