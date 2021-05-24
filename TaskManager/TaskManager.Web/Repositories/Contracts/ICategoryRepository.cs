using TaskManager.Web.Models;

namespace TaskManager.Web.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        int CreateCategory(Category category);
    }
}
