using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TaskManager.Web.Models;
using TaskManager.Web.Repositories.Contracts;

namespace TaskManager.Web.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;

        public CategoryRepository(IConfiguration configuration)
        {
            _connectionString = configuration["TaskManager:ConnectionString"];
        }

        public int CreateCategory(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.ExecuteScalar<int>(@"INSERT INTO Category(CategoryName) 
                                                        VALUES(@NameCategory);
                                                        SELECT SCOPE_IDENTITY() as 'lastCategory'",
                    new { NameCategory = category.CategoryName });
            }
        }

        public bool DeleteCategory(int categoryID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var affectedRows = connection.Execute("DELETE FROM Category WHERE CategoryID = @CategoryID", new { @CategoryID = categoryID });

                return affectedRows > 0;
            }
        }

        public bool UpdateCategory(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var affectedRows = connection.Execute("UPDATE Category SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID", category);

                return affectedRows > 0;
            }
        }
    }
}
