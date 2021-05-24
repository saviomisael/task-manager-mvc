using TaskManager.Web.Models;

namespace TaskManager.Web.Repositories.Contracts
{
    public interface ITaskRepository
    {
        bool CreateTask(Task task);
    }
}
