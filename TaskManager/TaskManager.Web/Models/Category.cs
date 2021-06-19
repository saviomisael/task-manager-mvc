namespace TaskManager.Web.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public Category(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
