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
            /// Test Environment 
            //todoManager.CreateTodo(new TodoItem() { Id = 0, Title = "Go to the store"});
            //todoManager.CreateTodo(new TodoItem() { Id = 1, Title = "Go to the concert." });
            //todoManager.CreateTodo(new TodoItem() { Id = 1, Title = "Go to the park." });

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
                        /// parse the input {X}
                        if (!int.TryParse(idInput, out int idToUpdate)) 
                        {
                            Console.WriteLine("Invalid ID Format, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break; 
                        }
                        /// check if it exist
                        if (!todoManager.ContainsId(idToUpdate))
                        {
                            Console.WriteLine("ID Entered Not Found, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /// check for duplicates
                        if (todoManager.ContainsDuplicates(idToUpdate)) {
                            Console.WriteLine("ID Entered belongs to multiple task,Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /// if all good then update
                        todoManager.UpdateStatus(idToUpdate, Status.Complete());
                        Console.WriteLine("Task Updated");
                        Console.ReadLine();
                        Console.Clear();
                        break; 

                    case Selection.Detail:
                        Console.Clear();
                        Console.WriteLine("Enter your ToDo ID. To View Detail");      
                        string? idDetail= Console.ReadLine();
                        /// parse the input {X}
                        if (!int.TryParse(idDetail, out int viewDetail))
                        {
                            Console.WriteLine("Invalid ID Format, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /// check if it exist
                        if (!todoManager.ContainsId(viewDetail))
                        {
                            Console.WriteLine("ID Entered Not Found, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /// check for duplicates
                        if (todoManager.ContainsDuplicates(viewDetail))
                        {
                            Console.WriteLine("ID Entered belongs to multiple task,Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        TodoItem? detail = todoManager.GetByld(viewDetail);

                        taskViewer.DisplayDetailedItem(detail);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Selection.Delete:
                        Console.Clear();
                        Console.WriteLine("Enter Your ToDO ID # : To Delete");
                        string? rawDelete = Console.ReadLine();
                        /// parse the input {X}
                        if (!int.TryParse(rawDelete, out int viewDelete))
                        {
                            Console.WriteLine("Invalid ID Format, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /// check if it exist
                        if (!todoManager.ContainsId(viewDelete))
                        {
                            Console.WriteLine("ID Entered Not Found, Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        /// check for duplicates
                        if (todoManager.ContainsDuplicates(viewDelete))
                        {
                            Console.WriteLine("ID Entered belongs to multiple task,Try Again");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                        Console.WriteLine("Are you sure you want to delete this task? [yes / no]");
                        string? inputDelete = Console.ReadLine();
                   
                        if (inputDelete == "no")
                        {
                            Console.WriteLine("No Task Deleted");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                        TodoItem? deletedItem = todoManager.TryDeleteTodo(viewDelete);
                        if (deletedItem == null)
                        {
                            Console.WriteLine($"Task ({rawDelete}),was not found , no task was deleted");
                        }
                        else
                        {
                            todoManager.TryDeleteTodo(viewDelete);
                            Console.WriteLine($"Task ({rawDelete}),has been deleted");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case Selection.Edit:
                        Console.WriteLine("EDIT TESTING");     //Test Case  
                        break;  

                    case Selection.Exit:                              
                        Console.Clear();                     
                        run = false;                                  // Allows an "Exit" without the List Showing
                        break;

                    case Selection.Help:
                        Console.Clear();
                        taskViewer.CreateEnterTitle(true);
                        Console.ReadLine();
                        Console.Clear(); 
                        break; 

                    default:
                        Console.WriteLine("Please Enter a valid Selection");
                        Console.WriteLine("------------------------");
                        Console.WriteLine("Enter 'help' to see possible selections");
                        Console.ReadLine();
                        Console.Clear(); 
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
