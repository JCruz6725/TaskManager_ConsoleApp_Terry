using Microsoft.VisualBasic.FileIO;
using TaskManager_ConsoleApp_Terry.Models;
using TaskManager_ConsoleApp_Terry.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace TaskManager_ConsoleApp_Terry
{
    public class TodoManager
    {
        private List<TodoItem> TodoCollection = [];
        private int IdCouter = 0;

        public void CreateTodo(string title,DateTimeOffset? dueAt =null )
        {

            TodoItem Item = new TodoItem()
            {
                Id = IdCouter++,
                Title = title,
                CreatedDate = DateTimeOffset.Now,
                DueAt = dueAt,
                LastModified = null,
                DateCompleted = null, 
                Status = Status.Open()
            };

            TodoCollection.Add(Item);

        }

        /// Test Environment 
        //public void CreateTodo(TodoItem t)
        //{
        //    TodoCollection.Add(t);
        //}


        public void BulkCreateTodo(string[] Titles)
        {
            throw new NotImplementedException();
        }
        public TodoItem? TryDeleteTodo(int Id)
        {
            foreach (var rawdelete in TodoCollection.ToList())
            {
                if (rawdelete.Id == Id)
                {
                    TodoCollection.Remove(rawdelete);
                    return rawdelete;
                }
            }
            return null; 
        }
            public TodoItem? DeleteTodo(int Id)
        {
            throw new NotImplementedException();

        }
        public bool UpdateStatus(int Id, Status status)
        {
            TodoItem? item = GetByld(Id);   // t represents each item in collection // checks for the ID to exit if not is null  //Looks inside your in-memory TodoCollection (a list of all tasks).

            if (item == null)
            {
                return false;
            }
            
            item.Status = status;                                   // assigning value of Instance Status --> status
            item.LastModified = DateTimeOffset.Now;

            if (status.Value == "Complete")     // When the user updates the task to Completed the following occurs
            { 
                item.DateCompleted = DateTimeOffset.Now;
            }

            return true;
            }
        public bool ContainsId(int id) {
            foreach (TodoItem item in TodoCollection)
            {
                if (item.Id == id) 
                {
                    return true;
                }       
            }
            return false;
        }

        public bool ContainsDuplicates(int id) {
            Dictionary<int, int> idsWithCounts = new Dictionary<int, int>();

            foreach (TodoItem item in TodoCollection) {
                bool isAdded = idsWithCounts.TryAdd(item.Id, 1);
                if (!isAdded) 
                {
                    idsWithCounts[item.Id] = idsWithCounts[item.Id] + 1;
                }
            }
            if (idsWithCounts[id] > 1) 
            { 
                return true;
            }
            return false;
        }
        public TodoItem? GetByld(int Id)       // pulls singler task by ID 
        {
           return TodoCollection.FirstOrDefault(t => t.Id == Id);

        }
        public void EditItem (EditTodoItemInstruction edittodoiteminstruction) 
        {
            throw new NotImplementedException();

        }

        public List<TodoItem> GetAllTodoItems()                                //[this.TodoCollection]
        {
            return TodoCollection.ToList();
           
        }

       
    }
}




        


