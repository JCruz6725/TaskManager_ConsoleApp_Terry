using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager_ConsoleApp_Terry.Models
{
    public class TodoItem
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public DateTimeOffset CreatedDate { get; init; } = DateTimeOffset.Now;
        public DateTimeOffset? DueAt { get; set; }
        public DateTimeOffset? LastModified { get; set; }
        public DateTimeOffset? DateCompleted { get; set; }

        public Status Status = Status.Open();  // possible corrections 

        
    }
}
