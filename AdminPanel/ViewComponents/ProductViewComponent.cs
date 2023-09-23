using AdminPanel.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdminPanel.ViewComponents
{
    public class ProductViewComponent: ViewComponent
    {
        private readonly AdminPanelDbContext _context;

        public ProductViewComponent(AdminPanelDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .ToList();

            return View(await Task.FromResult(products));

        }
    }
}
