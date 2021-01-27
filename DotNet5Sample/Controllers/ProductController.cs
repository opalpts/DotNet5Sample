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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Product_Name,Qnt,Price")] DetailViewModels.ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var data = _product.Create(product);
                if (data == 1)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.Delete(id);
            var sucess = "sucess";
            return View(product);
        }
    }
}
