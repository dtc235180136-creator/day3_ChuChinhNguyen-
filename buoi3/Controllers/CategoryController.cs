
using b3_chuchinhnguyen.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace b3_chuchinhnguyen.Controllers
{
    public class CategoryController : Controller
    {
        // Gia lap csdl
        private static List<category> _categories = new List<category>()
        {
            new category() { ID = 1 , Name = "Category 1"},
            new category() { ID = 2, Name = "Category 2"},
            new category() { ID = 3, Name = "Category 3"},
        };
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: CategeryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.ID == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: CategeryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategeryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            int newID = _categories.Any() ? _categories.Max(c => c.ID) + 1 : 1;
            category.ID = newID;
            _categories.Add(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: CategeryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categories.FirstOrDefault(c => c.ID == id);
            if (category == null)
            {
                return NotFound();

            }
            return View(category);
        }

        // POST: CategeryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategeryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategeryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
