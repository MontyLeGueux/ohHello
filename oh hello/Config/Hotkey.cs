using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oh_hello.config
{
    public class Hotkey
    {
        private HotkeyItem item;
        private Keys key;

        public HotkeyItem Item { get => item; set => item = value; }
        public Keys Key { get => key; set => key = value; }
    }
}
