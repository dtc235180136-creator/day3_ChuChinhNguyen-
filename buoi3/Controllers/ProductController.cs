using b3_chuchinhnguyen.Models;
using Microsoft.AspNetCore.Mvc;

namespace b3_chuchinhnguyen.Controllers
{
    public class ProductController : Controller
    {
        private static readonly List<Product> _products = new()
        {
            new Product
            {
                ID = 1,
                Name = "Product 1",
                Price = 100000,
                Description = "Mô tả sản phẩm 1",
                CategoryID = 1
            },
            new Product
            {
                ID = 2,
                Name = "Product 2",
                Price = 200000,
                Description = "Mô tả sản phẩm 2",
                CategoryID = 2
            }
        };

        public IActionResult Index()
        {
            return View(_products);
        }

        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            return product == null ? NotFound() : View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            product.ID = _products.Any() ? _products.Max(p => p.ID) + 1 : 1;
            _products.Add(product);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ID)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var existingProduct = _products.FirstOrDefault(p => p.ID == id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CategoryID = product.CategoryID;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            return product == null ? NotFound() : View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            _products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
