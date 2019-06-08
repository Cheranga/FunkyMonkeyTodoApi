using System;

namespace Todo.Domain.Models
{
    public class Todo
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
