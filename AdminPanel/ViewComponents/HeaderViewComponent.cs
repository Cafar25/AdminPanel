using AdminPanel.DAL;
using AdminPanel.Entities;
using AdminPanel.Entities.ProductsSection;
using AdminPanel.Services;
using AdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace AdminPanel.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AdminPanelDbContext _context;
        private readonly IBasket _basketService;

        public HeaderViewComponent(AdminPanelDbContext context, IBasket basketService)
        {
            _context = context;
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            ViewBag.Count = _basketService.GetBasketCount();
            

            var bio = _context.Bios.FirstOrDefault();

            return View(await Task.FromResult(bio));
        }



    }
}
