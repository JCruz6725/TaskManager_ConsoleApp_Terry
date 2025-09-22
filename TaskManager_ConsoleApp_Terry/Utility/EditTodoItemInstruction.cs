using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ConsoleApp_Terry.Utility
{
    public class EditTodoItemInstruction
    {
        public string Property { get; init;} 
        public const string SEPERATOR = "="; 
        public string Value { get; init;}
    }
}
