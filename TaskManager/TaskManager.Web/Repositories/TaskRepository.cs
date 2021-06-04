using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Web.Models;
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
            task.CategoryFK = _categoryRepository.CreateCategory(task.Category);

            using (var connection = new SqlConnection(_connectionString))
            {
                var affectedRows = connection.Execute(@"INSERT INTO Task(
                                                        CategoryFK, 
                                                        TaskName, 
                                                        TaskPriority, 
                                                        TaskDescription, 
                                                        TaskDate) 
                                                        VALUES(
                                                        @CategoryFK, 
                                                        @TaskName, 
                                                        @TaskPriority, 
                                                        @TaskDescription, 
                                                        @TaskDate)",
                                                    new
                                                    {
                                                        task.CategoryFK,
                                                        task.TaskName,
                                                        task.TaskPriority,
                                                        task.TaskDescription,
                                                        task.TaskDate
                                                    });

                if (affectedRows > 0)
                {
                    return true;
                }

                return false;
            }
        }

        public Task GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Task, Category, Task>("SELECT * FROM Task AS t INNER JOIN Category AS c ON t.CategoryFK = c.CategoryID WHERE t.TaskID = @TaskID",
                    (task, category) =>
                    {
                        task.Category = category;
                        return task;
                    }, 
                    new { TaskID = id }, 
                    splitOn: "CategoryID")
                    .SingleOrDefault();
            }
        }

        public ICollection<Task> ListAllTasks()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Task, Category, Task>("SELECT * FROM Task AS t INNER JOIN Category AS c ON t.CategoryFK = c.CategoryID ORDER BY t.TaskDate",
                    (task, category) =>
                {
                    task.Category = category;
                    return task;
                },
                splitOn: "CategoryID")
                    .Distinct()
                    .ToList();
            }
        }

        public bool UpdateTask(Task task)
        {
            if(_categoryRepository.UpdateCategory(task.Category))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var affectedRows = connection.Execute("UPDATE Task SET TaskName = @TaskName, TaskPriority = @TaskPriority, TaskDescription = @TaskDescription, TaskDate = @TaskDate", task);

                    return affectedRows > 0;
                }
            }

            return false;
        }
    }
}
