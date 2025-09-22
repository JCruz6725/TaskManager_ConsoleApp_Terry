using Microsoft.VisualBasic.FileIO;
using TaskManager_ConsoleApp_Terry.Models;
using TaskManager_ConsoleApp_Terry.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ConsoleApp_Terry.TodoManager
{
    public class TodoList
    {
        private List<TodoItem> TodoCollection;
        private int IdCouter = 0;
        
        public void CreateTodo(string Title)
        {
            throw new NotImplementedException();

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
        public void UpdateStatus(int Id,Status Status)
        {
            throw new NotImplementedException();

        }

        public List<TodoItem> GetAllTodoItems() //[this.TodoCollection]
        {
            throw new NotImplementedException();

        }

        public TodoItem GetByld(int Id)
        {
            throw new NotImplementedException();

        }
        public void EditItem (EditTodoItemInstruction edittodoiteminstruction) // is void needed ? 
        {
            throw new NotImplementedException();

        }


    }
}




        


