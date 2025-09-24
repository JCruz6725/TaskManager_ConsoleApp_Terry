using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
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
            Console.WriteLine($"Type '{Selection.Create}' to create a task");
            Console.WriteLine($"Type '{Selection.Update}' to update a task");
            Console.WriteLine($"Type '{Selection.Delete}' to delete a task");
            Console.WriteLine($"Type '{Selection.Detail}' to view detail of a task");
            Console.WriteLine($"Type '{Selection.Edit}' to edit a task");
            Console.WriteLine($"Type '{Selection.Exit}' to exit a application");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Press select your selection to get started");
            Console.WriteLine("-------------------------------------------");
            
        }
        public void Main()
        {
            TodoManager todoManager = new TodoManager();
            
            TaskViewer taskViewer = new TaskViewer();



            bool run = true;

            while (run)
            {
                string? commandInput = Console.ReadLine();
                switch (commandInput)
                {
                    case Selection.Create:

                        Console.WriteLine("Enter Your Task At Hand:");
                        string? rawInput = Console.ReadLine();
                        Console.WriteLine("Enter your Due Date(mm / dd / yyyy or Enter to Skip:");
                        string? dueDateInput = Console.ReadLine();

                        DateTimeOffset? dueAt = null;

                        if (!string.IsNullOrWhiteSpace(dueDateInput) && DateTimeOffset.TryParse(dueDateInput, out var parsedDate))
                        {
                            dueAt = parsedDate;
                        }

                        todoManager.CreateTodo(rawInput, dueAt);

                        break;



                        case Selection.Delete:                // When Selecting Delete 
                        Console.WriteLine("Delete");          //Checker to ensure the selection works 
                        break;

                    case Selection.Exit:                               // figure out to have seperate screen from the main 
                        Console.WriteLine();                           // Space 
                        Console.WriteLine("Have a Good Day");
                        run = false;
                        
                        //test of case // formating is horrible
                        break;
                }

                if (run) { 
                    List<TodoItem> TodoItems = todoManager.GetAllTodoItems();
                    taskViewer.MainMenu(TodoItems);
                }

            }

        }
        public void Shutdown()
        {
            Console.WriteLine();
            Console.WriteLine("C");
        }
    }
}
