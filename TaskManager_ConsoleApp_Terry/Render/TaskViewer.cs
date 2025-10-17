using TaskManager_ConsoleApp_Terry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace TaskManager_ConsoleApp_Terry.Render
{
    public class TaskViewer
    {
        public void DisplayShortItem(TodoItem todoitem)
        {
            Console.WriteLine($"ID: |{todoitem.Id}| Title: {todoitem.Title} Status: |{todoitem.Status.Value}|)");
        }
        public void DisplayDetailedItem(TodoItem todoitem)
        {
            string dueText = todoitem.DueAt.HasValue ? todoitem.DueAt.Value.ToString("MM/dd/yyyy") : "No due date";
            string lastModified = ("N/A");

            Console.WriteLine($"ID: |{todoitem.Id}| Title: {todoitem.Title} , Status: |{todoitem.Status.Value}|)");

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Created Date:{todoitem.CreatedDate}");
            Console.WriteLine($"Task Completed Date:{todoitem.DateCompleted}");
            Console.WriteLine($"Due Date: {dueText}");
            Console.WriteLine($"Last Modified Date:{lastModified}");
            Console.WriteLine("------------------------------------------------");
        }
        public void DisplayAllItems(List<TodoItem> todoitems)
        {
            foreach (var item in todoitems)
            {
                DisplayShortItem(item);
            }
        }
        public void MainMenu(List<TodoItem> todoitems)
        {

            string PreFix = """
                Welcome to your ToDo List
                --------------------------
                """;

            string PostFix = """
                ---------------------------
                To Exit Program Enter:'exit'
                ----------------------------
                """;
          
            Console.WriteLine(PreFix);
            DisplayAllItems(todoitems);
            Console.WriteLine(PostFix);
        }

        public void CreateEnterTitle(bool tutorial = false)
        {
            Console.WriteLine($"Type '{Selection.Create}' to create a task");
            Console.WriteLine($"Type '{Selection.Update}' to update a task");
            Console.WriteLine($"Type '{Selection.Delete}' to delete a task");
            Console.WriteLine($"Type '{Selection.Detail}' to view detail of a task");
            Console.WriteLine($"Type '{Selection.Edit}' to edit a task");
            Console.WriteLine($"Type '{Selection.Exit}' to exit a application");
            Console.WriteLine("-------------------------------------------");
          if (tutorial)
                Console.WriteLine("Press Enter to return and Enter your choice");
          else
                Console.WriteLine("Enter your choice to proceed");
            Console.WriteLine("-------------------------------------------");
        } 
        public void ConfirmDeletion()
        {

        }
        public void SomeActionCompleted(string action)
        {

        }
        public void SelectTaskByld(string action)
        {

        }
    }
}
