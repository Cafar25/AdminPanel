using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Areas.FiorelloArea.Controllers
{
    [Area("FiorelloArea")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
