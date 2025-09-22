using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TaskManager_ConsoleApp_Terry.Models;

namespace TaskManager_ConsoleApp_Terry
{
    public class App
    {

        public void Intialize()
        {
            Console.WriteLine("A");
        }
        public void Main()
        {
            TodoManager todoManager = new();

            while (true)
            { 
                todoManager.CreateTodo("go to work");

                List<TodoItem> todoArray = todoManager.GetAllTodoItems();

                foreach (var item in todoArray)
                {
                    Console.WriteLine( item.Title );
                }
            }


            //while (true)
            //{


            //    Console.WriteLine("Welcome too your ToDo List");
            //    Console.WriteLine("--------------------------");
            //    Console.WriteLine("To Exit Program Enter:'Exit'");
            //    Console.WriteLine("----------------------------");
            //    Console.WriteLine("Enter Your Task Title:");
            //    var TitleIn = Console.ReadLine();

            //    if (TitleIn != "Exit")
            //    {
            //        Console.WriteLine("Enter your Due Date (mm/dd/yyyy or Enter to Skip):");
            //        string DueDate = Console.ReadLine();

            //        if (string.IsNullOrWhiteSpace(DueDate))
            //        {
            //            Console.WriteLine("Your Task :" + " " + TitleIn);
            //        }
            //        else
            //        {
            //            DateTime duedate = DateTime.Parse(DueDate);
            //            Console.WriteLine(TitleIn + " " + duedate);  //
            //        }

            //    }
            //    else if (TitleIn == "Exit")
            //    {
            //        break;
            //    }

            //}


        }
        
            
        
        public void Shutdown()
        {
            Console.WriteLine();
            Console.WriteLine("C");
        }
    }
}
