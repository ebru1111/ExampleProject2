using _OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _OrnekProje.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context db = new Context();  
        [Authorize]
        public ActionResult CategoryList()
        {
            return View(db.Categories);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList", "Category");
        }
        public ActionResult Delete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("CategoryList", "Category");
        }      
        public ActionResult KategoriGetir(int id)
        {
            var category = db.Categories.Find(id);
            return View("KategoriGetir",category);
        }
        public ActionResult Update(Category c)
        {
            var category = db.Categories.Find(c.CategoryId);
            category.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("CategoryList");

        }
    }
}