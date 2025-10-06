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

                    case Selection.Detail:   // ----------------------->>>>>>>> Possible Enter of detail. 
                                              
                        break; 

                    case Selection.Exit:                               // figure out to have seperate screen from the main 
                        Console.Clear();
                        Console.WriteLine();                           // Space 
                        Console.WriteLine("Have a Good Day");
                        run = false;
                        break;//test of case // formating is horrible

                    case Selection.Update:
                        Console.Clear();                                     //Clears the console screen
                        Console.WriteLine("Enter the ID of the task to mark as completed:");
                        string? idInput = Console.ReadLine();              // String? --> can hold null as well!
                        Console.Clear();
                        if (int.TryParse(idInput, out int idToUpdate))    // Converts a string (idInput) into an INT (idToUpdate)    // Dont like that doesnt check if Values of ID if they exist or not // future implemantions on modifiying this IF STATEMENT 
                        {                                                   
                            todoManager.UpdateStatus(idToUpdate,Status.Complete()); //Calls earlier method, updating that specific task’s status to "Complete".
                        }                               // bool updated ??? 
                        //if (idInput = ! ) ;             ---->>> figure out if ID is part current collection.!!!! 
                        else
                        {
                            //Console.Clear();    ---->>> LIST STILL SHOWS  --->> another route 
                            //run = false;                                          // Dont like the format of this line when update is invalid
                            Console.WriteLine("Invalid ID Format!");
                        }
                        break;

                    case Selection.Edit:
                        Console.WriteLine("EDIT TESTING ");
                        break; 
                }
                //Console.Clear();
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
