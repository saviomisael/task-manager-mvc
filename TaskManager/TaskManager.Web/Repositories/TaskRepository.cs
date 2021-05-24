using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Web.Repositories.Contracts;

namespace TaskManager.Web.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly string _connectionString;
        private readonly ICategoryRepository _categoryRepository;

        public TaskRepository(IConfiguration configuration, ICategoryRepository categoryRepository)
        {
            _connectionString = configuration["TaskManager:ConnectionString"];
            _categoryRepository = categoryRepository;
        }

        public bool CreateTask(Models.Task task)
        {
        }
    }
}
