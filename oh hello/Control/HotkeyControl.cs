using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oh_hello.config;
using System.Windows.Forms;

namespace oh_hello.control
{
    public class HotkeyControl
    {
        public readonly HotkeyItem[] eventKeys = { HotkeyItem.Start };
        private Dictionary<Keys, EventHandler> events;
        private ConfigManager configManager;

        public HotkeyControl(ConfigManager configManager)
        {
            this.configManager = configManager;
            InitEvents();
        }

        private void InitEvents()
        {
            events = new Dictionary<Keys, EventHandler>();
            foreach (HotkeyItem hotkey in eventKeys)
            {
                events.Add(configManager.GetHotkey(hotkey), null);
            }
        }

        public void SetEvent(HotkeyItem item, EventHandler handler)
        {
            events.Remove(configManager.GetHotkey(item));
            events.Add(configManager.GetHotkey(item), handler);
        }

        public void HotkeyPressed(Keys key)
        {
            if (events.TryGetValue(key, out EventHandler handler) && handler != null)
            {
                handler?.Invoke(this, null);
            }
        }
    }
}
