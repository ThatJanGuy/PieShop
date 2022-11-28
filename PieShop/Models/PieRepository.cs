using Microsoft.EntityFrameworkCore;

namespace PieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly PieShopDbContext pieShopContext;

        public PieRepository(PieShopDbContext dbContext)
        {
            this.pieShopContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IEnumerable<Pie> AllPies
        {
            get 
            {
                return pieShopContext.Pies.Include(c => c.Category); 
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return pieShopContext.Pies.Include(c => c.Category)
                                          .Where(p => p.IsPieOfTheWeek); 
            }
        }

        public Pie? GetPieById(int pieId)
        {
            throw new NotImplementedException();
        }
    }
}
