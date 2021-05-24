using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
                                                        NameTask, 
                                                        PriorityTask, 
                                                        DescriptionTask, 
                                                        DateTask) 
                                                        VALUES(
                                                        @CategoryFK, 
                                                        @NameTask, 
                                                        @PriorityTask, 
                                                        @DescriptionTask, 
                                                        @DateTask)",
                                                    new
                                                    {
                                                        task.CategoryFK,
                                                        task.NameTask,
                                                        task.PriorityTask,
                                                        task.DescriptionTask,
                                                        task.DateTask
                                                    });

                if (affectedRows > 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
