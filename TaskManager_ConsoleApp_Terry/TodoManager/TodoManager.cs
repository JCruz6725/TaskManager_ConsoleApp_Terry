using Microsoft.VisualBasic.FileIO;
using TaskManager_ConsoleApp_Terry.Models;
using TaskManager_ConsoleApp_Terry.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void BulkCreateTodo(string[] Titles)
        {
            throw new NotImplementedException();
        }
        public TodoItem DeleteTodo(int Id)
        {
            throw new NotImplementedException();
        }
            public TodoItem? TryDeleteTodo(int Id)
        {
            throw new NotImplementedException();

        }
        public bool UpdateStatus(int Id,Status status)    
        {
            var item= TodoCollection.FirstOrDefault(t => t.Id == Id);   // t represents each item in collection // checks for the ID to exit if not is null  //Looks inside your in-memory TodoCollection (a list of all tasks).
            if (item != null)                                          //IF  not  Equal to null "Excecute" 
            {
                item.Status = status;                                   // assigning value of Instance Status --> status
                item.LastModified = DateTimeOffset.Now; 

                if (status.Value == "Complete")                         // When the user updates the task to Completed the following occurs
                {
                    item.DateCompleted = DateTimeOffset.Now;   
                }
                  return true;
            }
           return false;
        }
        
        public TodoItem GetByld(int Id)
        {
            throw new NotImplementedException();

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




        


