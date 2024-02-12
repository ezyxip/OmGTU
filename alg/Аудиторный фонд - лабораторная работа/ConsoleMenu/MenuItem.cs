using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    public class MenuItem
    {
        public delegate void ExecuteDelegate();

        public string Key;
        public ExecuteDelegate Execute;
        public string Info;

        public MenuItem(string key, ExecuteDelegate exec, string info)
        {
            Key = key;
            Execute = exec;
            Info = info;
        }

        public MenuItem(string key, string info)
            : this(key, () => { }, info) { }
    }
}
