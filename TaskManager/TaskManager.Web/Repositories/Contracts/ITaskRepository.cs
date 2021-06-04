using System.Collections.Generic;
using TaskManager.Web.Models;

namespace TaskManager.Web.Repositories.Contracts
{
    public interface ITaskRepository
    {
        bool CreateTask(Task task);
        ICollection<Task> ListAllTasks();
        Task GetById(int id);
        bool UpdateTask(Task task);
    }
}
