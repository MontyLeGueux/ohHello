using oh_hello.config;
using oh_hello.control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oh_hello.ui
{
    public partial class OhHelloForm : Form
    {
        static private ConfigManager configManager;
        static private MordhauControl mordhauControl;
        static private HotkeyControl hotkeyControl;

        private string currentKey;
        private readonly string keyChangeString = "[input a key or ESC to cancel]";

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        private KeyHandler ghk;

        public OhHelloForm()
        {
            InitializeComponent();
            configManager = new ConfigManager();
            mordhauControl = new MordhauControl(configManager);
            hotkeyControl = new HotkeyControl(configManager);
            hotkeyControl.SetEvent(HotkeyItem.Start, StartKeyPressedHandler);
            InitPropertiesList();
            loopCheckBox.Checked = configManager.GetProperty(PropertyItem.Loop);
            numericTabIndex.Value = configManager.GetTabIndex();
            numericCommandIndex.Value = configManager.GetCommandIndex();
            ghk = new KeyHandler(configManager.GetHotkey(hotkeyControl.eventKeys[0]), this);
            ghk.Register();
        }

        private void StartKeyPressedHandler(object sender, EventArgs e)
        {
            mordhauControl.Play();
        }

        private void InitPropertiesList()
        {
            HotkeyList.Items.Clear();
            List<Hotkey> hotkeys = configManager.GetAll();

            String[] row = new String[2];
            foreach (Hotkey hotkey in hotkeys)
            {
                row[0] = hotkey.Item.ToString();
                row[1] = hotkey.Key.ToString();
                HotkeyList.Items.Add(new ListViewItem(row));
            }
        }

        private void FormKeyHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (HotkeyList.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = HotkeyList.SelectedItems[0];
                    selectedItem.SubItems[1].Text = currentKey;
                }
            }
            else
            {
                if (HotkeyList.SelectedItems.Count > 0)
                {
                    ListViewItem selectedItem = HotkeyList.SelectedItems[0];
                    Enum.TryParse<Keys>(e.KeyCode.ToString(), out Keys tempKey);
                    Enum.TryParse<HotkeyItem>(selectedItem.SubItems[0].Text, out HotkeyItem hotkey);
                    selectedItem.SubItems[1].Text = tempKey.ToString();
                    configManager.SetHotKey(hotkey, tempKey);
                    ghk = new KeyHandler(configManager.GetHotkey(hotkeyControl.eventKeys[0]), this);
                    ghk.Register();
                }
            }
            ToggleEnableLists(true);
        }

        private void ToggleEnableLists(bool enabled)
        {
            HotkeyList.Enabled = enabled;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            configManager.SetProperty(PropertyItem.Loop, loopCheckBox.Checked);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            mordhauControl.Play();
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HotkeyList.SelectedItems.Count > 0)
            {
                ToggleEnableLists(false);
                ListViewItem selectedItem = HotkeyList.SelectedItems[0];
                currentKey = selectedItem.SubItems[1].Text;
                selectedItem.SubItems[1].Text = keyChangeString;
            }
        }

        private void NumericCommandIndex_ValueChanged(object sender, EventArgs e)
        {
            configManager.SetCommandIndex((int)numericCommandIndex.Value);
        }

        private void NumericTabIndex_ValueChanged(object sender, EventArgs e)
        {
            configManager.SetTabIndex((int)numericTabIndex.Value);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            configManager.SaveConfig();
        }

        private void HandleHotkey()
        {
            hotkeyControl.HotkeyPressed(configManager.GetHotkey(hotkeyControl.eventKeys[0]));
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
    }
}

