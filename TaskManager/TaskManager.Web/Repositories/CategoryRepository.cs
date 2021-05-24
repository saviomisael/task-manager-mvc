using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Web.Models;
using TaskManager.Web.Repositories.Contracts;

namespace TaskManager.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public int CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
