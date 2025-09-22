using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TaskManager_ConsoleApp_Terry.Models;
using TaskManager_ConsoleApp_Terry.Render;

namespace TaskManager_ConsoleApp_Terry
{
    public class App
    {

        public void Intialize()
        {
            TodoManager todoManager = new TodoManager();
            TaskViewer taskViewer = new TaskViewer();




            

            for (int i = 0; i < 3 ; i++)
            {



                string? rawInput = Console.ReadLine();


                if (rawInput == null)
                    throw new Exception("aslkdja;lsdkj");


                if (rawInput == "stop")
                    break;


                todoManager.CreateTodo(rawInput);
            }


            List<TodoItem> TodoItems = todoManager.GetAllTodoItems();
            taskViewer.MainMenu(TodoItems);
        }
        public void Main()
        {
            TodoManager todoManager = new();

            while (true)
            { 
                todoManager.CreateTodo("go to work");


                List<TodoItem> todoArray = todoManager.GetAllTodoItems();

                foreach (var todoItem in todoArray)
                {
                    Console.WriteLine( todoItem.Title );
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
