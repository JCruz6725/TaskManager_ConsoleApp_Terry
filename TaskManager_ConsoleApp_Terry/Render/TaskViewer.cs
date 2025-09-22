using TaskManager_ConsoleApp_Terry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace TaskManager_ConsoleApp_Terry.Render
{
    public class TaskViewer
    {
        public void DisplayShortItem(TodoItem todoitem)
        {
            Console.WriteLine($"{todoitem.Id} {todoitem.Title}");
        }
        public void DisplayDetailedItem(TodoItem todoitem)
        {

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
                Welcome too your ToDo List
                --------------------------
                """;


            string PostFix = """
                ---------------------------
                To Exit Program Enter:'Exit'
                ----------------------------
                """;
            



            Console.WriteLine(PreFix);
            DisplayAllItems(todoitems);
            Console.WriteLine(PostFix);


        }

        public void CreateEnterTitle()
        {

        }
        public void CreateEnterDueDate()
        {

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
