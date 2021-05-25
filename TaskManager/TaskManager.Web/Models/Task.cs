using System;

namespace TaskManager.Web.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        public int CategoryFK { get; set; }
        public string TaskName { get; set; }
        public int TaskPriority { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDate { get; set; }

        public Category Category { get; set; }
    }
}
