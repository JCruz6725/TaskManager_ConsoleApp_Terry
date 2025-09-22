using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ConsoleApp_Terry.Models
{
    public class Status
    {
        public static Status Open()
        {
            return new Status("Open");
        }
        public static Status Complete() {

            return new("Complete");
        }
        private Status(string status) { Value = status; }
        public string  Value { get; private set; }             // wasnt sure if int was appropiated to add 
    }
}
