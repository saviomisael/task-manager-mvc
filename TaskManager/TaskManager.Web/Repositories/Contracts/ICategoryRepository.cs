using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Web.Models;

namespace TaskManager.Web.Repositories.Contracts
{
    interface ICategoryRepository
    {
        int CreateCategory(Category category);
    }
}
