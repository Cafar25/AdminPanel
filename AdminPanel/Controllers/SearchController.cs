using AdminPanel.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdminPanel.Controllers
{
    public class SearchController : Controller
    {
        private readonly AdminPanelDbContext _context;

        public SearchController(AdminPanelDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(string search, string controllerName)
        {

            switch (controllerName = ControllerContext.ActionDescriptor.ControllerName)
            {
                case "Product":
                    var products = _context.Products
                        .Include(p => p.Category)
                        .Include(p => p.ProductImages)
                        .Where(p => p.Name.ToLower().Contains(search.ToLower()))
                        .OrderBy(p => p.Id)
                        .Take(12)
                        .ToList();

                    return PartialView("_SearchPartial", products);

                case "Blog":
                    var blogs = _context.Blogs
                        .Include(b => b.Category)
                        .Where(b => b.Title.ToLower().Contains(search.ToLower()))
                        .OrderBy(b => b.Id)
                        .ToList();

                    return PartialView("_SearchPartial", blogs);


                default:
                    return PartialView("_SearchPartial", null);
            }
        }

    }
}
