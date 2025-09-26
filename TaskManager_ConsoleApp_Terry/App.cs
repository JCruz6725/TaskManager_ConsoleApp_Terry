using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private TaskViewer taskViewer = new();         
        public void Intialize()
        {

            taskViewer.CreateEnterTitle();

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
                        Console.Clear();
                        Console.WriteLine("Enter Your Task At Hand:");
                        string? rawInput = Console.ReadLine();
                        Console.WriteLine("Enter your Due Date(mm / dd / yyyy or Enter to Skip:");
                        string? dueDateInput = Console.ReadLine();

                        DateTimeOffset? dueAt = null;

                        if (!string.IsNullOrWhiteSpace(dueDateInput) && DateTimeOffset.TryParse(dueDateInput, out var parsedDate))
                        {
                            dueAt = parsedDate;
                        }
                        Console.Clear();
                        todoManager.CreateTodo(rawInput, dueAt);

                        break;
                        
                        case Selection.Delete:                // When Selecting Delete 
                        Console.WriteLine("Delete");          //Checker to ensure the selection works 
                        break;

                    case Selection.Exit:                               // figure out to have seperate screen from the main 
                        Console.Clear();
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
            Console.WriteLine("SHUTDOWN");
        }
    }
}
