using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oh_hello.config
{
    public class Property
    {
        private PropertyItem item;
        private bool value;

        public PropertyItem Item { get => item; set => item = value; }
        public bool Value { get => value; set => this.value = value; }
    }
}
