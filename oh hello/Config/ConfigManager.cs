using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace oh_hello.config
{
    public class ConfigManager
    {

        private Config config;
        private const string autoSavePath = "Config";

        public ConfigManager()
        {
            config = LoadConfig();
            if (config == null)
            {
                config = new Config();
                config.Init();
            }
        }

        public void SetTabIndex(int tabIndex)
        {
            if (tabIndex >= 1 && tabIndex <= 3)
            {
                config.TabIndex = tabIndex;
            }
        }

        public void SetCommandIndex(int commandIndex)
        {
            if (commandIndex >= 1 && commandIndex <= 5)
            {
                config.CommandIndex = commandIndex;
            }
        }

        public int GetTabIndex()
        {
            return config.TabIndex;
        }

        public int GetCommandIndex()
        {
            return config.CommandIndex;
        }

        public static HotkeyItem[] GetAllConfigItems()
        {
            return (HotkeyItem[])Enum.GetValues(typeof(HotkeyItem));
        }

        public Keys GetHotkey(HotkeyItem item)
        {
            return config.Get(item);
        }

        public bool GetProperty(PropertyItem item)
        {
            return config.Get(item);
        }

        public void SetProperty(PropertyItem item, bool value)
        {
            config.Set(item, value);
        }

        public void SetHotKey(HotkeyItem item, Keys value)
        {
            config.Set(item, value);
        }

        public List<Hotkey> GetAll()
        {
            return config.GetAllHotkeys();
        }

        public Keys GetCommandKey()
        {
            return config.Get(((HotkeyItem[])Enum.GetValues(typeof(HotkeyItem)))[config.CommandIndex - 1]);
        }

        public void SaveConfig()
        {
            SaveNoDialog<Config>(config, "configuration");
        }

        private Config LoadConfig()
        {
            return LoadNoDialog<Config>("configuration");
        }

        public HotkeyItem IdentifyKey(Keys key)
        {
            return config.IdentifyKey(key).Item;
        }

        private static void SaveNoDialog<T>(T target, string fileName)
        {
            if (fileName != null)
            {
                fileName = fileName + ".xml";
                Directory.CreateDirectory(autoSavePath);
                using (var stream = File.Create(autoSavePath + @"\" + fileName))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(stream, target);
                }
            }
        }

        private static T LoadNoDialog<T>(string fileName)
        {
            T result = default(T);
            if (fileName != null)
            {
                fileName = fileName + ".xml";
                if (File.Exists(autoSavePath+@"\"+fileName))
                {
                    using (var stream = File.Open(autoSavePath + @"\" + fileName, FileMode.OpenOrCreate))
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        try
                        {
                            result = (T)serializer.Deserialize(stream);
                        }
                        catch (InvalidCastException)
                        {
                            MessageBox.Show("Wrong File type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            return result;
        }
    }
}
