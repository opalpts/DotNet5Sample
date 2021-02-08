using DotNet5Sample.Core.Context;
using DotNet5Sample.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet5Sample.Core.Repositories
{
    public class HomeRepository : IHome
    {
        private readonly StoreDbContext _context;
        public HomeRepository(StoreDbContext context)
        {
            _context = context;
        }

        public List<DetailViewModels.OfferViewModel> GetTable()
        {
            return _context.Offer.Select(c => new DetailViewModels.OfferViewModel()
            {
                id = c.id,
                name = c.name,
                version = c.version,
                approve = c.approve
            }).ToList();
        }
    }
}
