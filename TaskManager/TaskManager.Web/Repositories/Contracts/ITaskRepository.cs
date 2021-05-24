using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Web.Models;

namespace TaskManager.Web.Repositories.Contracts
{
    interface ITaskRepository
    {
        bool CreateTask(Task task);
    }
}
