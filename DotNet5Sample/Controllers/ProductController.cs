using DotNet5Sample.Core.Repositories;
using DotNet5Sample.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet5Sample.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProducts _product;
        public ProductController(IProducts products)
        {
            _product = products;
        }
        public ActionResult Index()
        {
            return View();
        }
        public IEnumerable<DetailViewModels.ProductViewModel> GetProduct()
        {
            var data = _product.GetProduct();
            return data;
        }
        public ActionResult GetById(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = _product.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost,ActionName("Create")]
        public string Create([Bind("Product_Name,Qnt,Price")] DetailViewModels.ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var data = _product.Create(product);
                if (data == 1)
                {
                    return "sucess";
                }
            }
            return "false";
        }
        [HttpPost, ActionName("Delete")]
        public string DeleteConfirmed(int id)
        {
            var data = _product.Delete(id);
            if (data == 1)
            {
                return "sucess";
            }
            return "false";
        }
        [HttpPost, ActionName("Update")]
        public string Update([Bind("Id,Product_Name,Qnt,Price")] DetailViewModels.ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var data = _product.Update(product);
                if (data == 1)
                {
                    return "sucess";
                }
            }
            return "false";
        }
    }
}
