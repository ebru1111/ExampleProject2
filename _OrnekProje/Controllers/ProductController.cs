using _OrnekProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _OrnekProje.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        Context db = new Context();

        public ActionResult ProductList()
        {
            return View(db.Products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {

            List<SelectListItem> degerler = (from i in db.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Name,
                                                 Value = i.CategoryId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            var category = db.Categories.Where(m => m.CategoryId == product.Category.CategoryId).FirstOrDefault();
            product.Category= category;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductList", "Product");
        }
        public ActionResult Update(Product c)
        {
            var product = db.Products.Find(c.ProductId);
            product.Name = c.Name;
            product.Description = c.Description;
            product.ShortDescription = c.ShortDescription;

            db.SaveChanges();
            return RedirectToAction("ProductList");

        }
        public ActionResult GetProducts(int id)
        {
            var product = db.Products.Find(id);
            return View("GetProducts", product);
        }
    }
}