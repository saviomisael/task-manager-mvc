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

        public Task(string taskName, int taskPriority, string taskDescription, DateTime taskDate, Category category)
        {
            TaskName = taskName;
            TaskPriority = taskPriority;
            TaskDescription = TaskDescription;
            TaskDate = taskDate;
            Category = category;
        }

        public Task()
        { }
    }
}
