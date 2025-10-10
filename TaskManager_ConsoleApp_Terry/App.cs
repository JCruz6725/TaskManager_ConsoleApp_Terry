using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TaskManager_ConsoleApp_Terry.Models;
using TaskManager_ConsoleApp_Terry.Render;

namespace TaskManager_ConsoleApp_Terry
{
    public class App
    {
        private TaskViewer taskViewer = new (); 
        private TodoManager todoManager = new();        
        public void Intialize()
        {

            taskViewer.CreateEnterTitle();

        }
        public void Main()
        {
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

                    case Selection.Update:
                        Console.Clear();                                     //Clears the console screen
                        Console.WriteLine("Enter the ID of the task to mark as completed:");
                        string? idInput = Console.ReadLine();              // String? --> can hold null as well!
                        if (int.TryParse(idInput, out int idToUpdate))    // Converts a string (idInput) into an INT (idToUpdate)
                        {
                            if (todoManager.CheckDuplicte(idToUpdate))
                            {

                                todoManager.UpdateStatus(idToUpdate, Status.Complete());      //Calls earlier method, updating that specific task’s status to "Complete".

                                Console.WriteLine("Task Updated");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("ID Entered Not Found, Try Again");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID Format, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;

                    case Selection.Detail:
                        Console.Clear();
                        Console.WriteLine("Enter your ToDo ID. To View Detail");      
                        string? idDetail= Console.ReadLine();
                        if (int.TryParse(idDetail, out int viewDetail))
                        {
                            
                            if (todoManager.CheckDuplicte(viewDetail))
                            {
                                TodoItem? detail = todoManager.GetByld(viewDetail);
                                taskViewer.DisplayDetailedItem(detail);
                                Console.ReadLine();
                                Console.Clear(); 
                            }
                            else
                            {
                                Console.WriteLine("ID Entered Not Found, Try Again");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID Format, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;  
                    
                    case Selection.Delete:                
                        Console.WriteLine("Delete");          //Test Case  
                        break;

                    case Selection.Edit:
                        Console.WriteLine("EDIT TESTING");     //Test Case  
                        break;  

                    case Selection.Exit:                              
                        Console.Clear();                     
                        run = false;                                  // Allows an "Exit" without the List Showing
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
            Console.WriteLine("Exiting....");
        }
    }
}
