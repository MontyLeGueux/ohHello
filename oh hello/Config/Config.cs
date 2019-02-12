using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oh_hello.config
{
    public class Config
    {
        
        public Config()
        {
            Hotkeys = new List<Hotkey>();
            Properties = new List<Property>();
        }
        
        public void Init()
        {
            HotkeyItem[] hotkeysItems = (HotkeyItem[])Enum.GetValues(typeof(HotkeyItem));
            PropertyItem[] propertyItems = (PropertyItem[])Enum.GetValues(typeof(PropertyItem));
            foreach (HotkeyItem hotkeysItem in hotkeysItems)
            {
                Hotkeys.Add(new Hotkey() { Item = hotkeysItem, Key = Keys.None });

            }
            foreach (PropertyItem propertyItem in propertyItems)
            {
                Properties.Add(new Property() { Item = propertyItem, Value = false });
            }
            tabIndex = 1;
            commandIndex = 1;
        }

        private List<Hotkey> hotkeys;
        private List<Property> properties;

        private int commandIndex;
        private int tabIndex;

        public int CommandIndex { get => commandIndex; set => commandIndex = value; }
        public int TabIndex { get => tabIndex; set => tabIndex = value; }
        public List<Hotkey> Hotkeys { get => hotkeys; set => hotkeys = value; }
        public List<Property> Properties { get => properties; set => properties = value; }

        public Keys Get(HotkeyItem item)
        {
            return Hotkeys.Find(x => x.Item == item).Key;
        }

        public bool Get(PropertyItem item)
        {
            return Properties.Find(x => x.Item == item).Value;
        }

        public void Set(HotkeyItem item, Keys value)
        {
            Hotkeys.Find(x => x.Item == item).Key = value;
        }

        public void Set(PropertyItem item, bool value)
        {
            Properties.Find(x => x.Item == item).Value = value;
        }

        public Hotkey IdentifyKey(Keys key)
        {
            return Hotkeys.Find(x => x.Key== key);
        }

        public List<Hotkey> GetAllHotkeys()
        {
            return Hotkeys;
        }

        public List<Property> GetAllHProperties()
        {
            return Properties;
        }
    }
}
