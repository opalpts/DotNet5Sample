using DotNet5Sample.Core.Context;
using DotNet5Sample.Core.Models;
using DotNet5Sample.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace DotNet5Sample.Core.Repositories
{
    public class ProductsRepository : IProducts
    {
        private readonly StoreDbContext _context;
        public ProductsRepository(StoreDbContext context)
        {
            _context = context;
        }
        public int Create(DetailViewModels.ProductViewModel product)
        {
            var query = new Product
            {
                Id = product.Id,
                Product_Name = product.Product_Name,
                Qnt = product.Qnt,
                Price = product.Price
            };
            _context.Product.Add(query);
            int row = _context.SaveChanges();
            return row;
        }

        public int Delete(int id)
        {
            var result = _context.Product.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                _context.Product.Remove(result);
                int row = _context.SaveChanges();
                return row;
            }
            return 0;
        }

        public DetailViewModels.ProductViewModel GetById(int id)
        {
            return _context.Product.Where(w => w.Id == id).Select(c => new DetailViewModels.ProductViewModel()
            {
                Id = c.Id,
                Product_Name = c.Product_Name,
                Qnt = c.Qnt,
                Price = c.Price
            }).FirstOrDefault();
        }

        public List<DetailViewModels.ProductViewModel> GetProduct()
        {
            return _context.Product.Select(c => new DetailViewModels.ProductViewModel()
            {
                Id = c.Id,
                Product_Name = c.Product_Name,
                Qnt = c.Qnt,
                Price = c.Price
            }).ToList();
        }

        public int Update(DetailViewModels.ProductViewModel product)
        {
            var query = new Product
            {
                Id = product.Id,
                Product_Name = product.Product_Name,
                Qnt = product.Qnt,
                Price = product.Price
            };
            _context.Product.Update(query);
            int row = _context.SaveChanges();
            return row;
        }
    }
}
