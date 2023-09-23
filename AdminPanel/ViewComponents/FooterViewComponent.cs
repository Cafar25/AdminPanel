using AdminPanel.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Fiorello.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AdminPanelDbContext _context;

        public FooterViewComponent(AdminPanelDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bio = _context.Bios.FirstOrDefault();

            return View(await Task.FromResult(bio));
        }
    }
}
