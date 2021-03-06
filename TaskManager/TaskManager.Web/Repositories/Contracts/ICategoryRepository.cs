using TaskManager.Web.Models;

namespace TaskManager.Web.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        int CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryID);
    }
}
