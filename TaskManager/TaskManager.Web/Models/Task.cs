using System;

namespace TaskManager.Web.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public int CategoryFK { get; set; }
        public string NameTask { get; set; }
        public int PriorityTask { get; set; }
        public string DescriptionTask { get; set; }
        public DateTime DateTask { get; set; }

        public Category Category { get; set; }
    }
}
