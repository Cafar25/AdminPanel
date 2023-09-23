using AdminPanel.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdminPanel.Controllers
{
    public class ProductController : Controller
    {
        private readonly AdminPanelDbContext _Appcontext;

        public ProductController(AdminPanelDbContext context)
        {
            _Appcontext = context;
        }

        public IActionResult Index()
        {
            ViewBag.ProductCount = _Appcontext.Products.Count();
            var product = _Appcontext.Products
                .Include(p => p.Category)
                .Include(p=>p.ProductImages)
                .Take(4)
                .ToList();
            return View(product);
        }

        public IActionResult More(int skip)
        {
            var products = _Appcontext.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Skip(skip)
                .Take(4)
                .ToList();
            return PartialView("_MorePartial", products);
        }

        public IActionResult Search(string search)
        {
            var products = _Appcontext.Products 
                .Include(p => p.Category)
                .Include(p=> p.ProductImages)
                .Where(p=>p.Name.ToLower().Contains(search.ToLower()))
                .OrderBy(p => p.Id)
                .Take(12)
                .ToList();

            return PartialView("_SearchPartial", products);
        }
    }
}
