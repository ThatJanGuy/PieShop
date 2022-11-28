namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PieShopDbContext pieShopDbContext;

        public CategoryRepository(PieShopDbContext pieShopDbContext)
        {
            this.pieShopDbContext = pieShopDbContext;
        }

        public IEnumerable<Category> AllCategories => 
            pieShopDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
