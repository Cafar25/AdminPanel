using AdminPanel.DAL;
using AdminPanel.Entities.AboutSection;
using AdminPanel.Entities.ExpertsSection;
using AdminPanel.Entities.SliderSection;
using AdminPanel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class HomeController : Controller
    {
        private readonly AdminPanelDbContext _context;

        public HomeController(AdminPanelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM vm = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                SliderContent = _context.SliderContents.FirstOrDefault(),
                Categories = _context.Categories.ToList(),
                Products = _context.Products.Include(p=>p.ProductImages).ToList(),
                Advertisement = _context.Advertisements.FirstOrDefault(),
                Benefits = _context.Benefits.ToList(),
                Experts = _context.Experts.ToList(),
                ExpertContent = _context.ExpertContents.FirstOrDefault(),
                Testimonials = _context.Testimonials.ToList(),
                Blogs = _context.Blogs.Include(b => b.Category).Take(3).ToList()

            };

            #region ChangeTracker
            //var data = _context.ChangeTracker.Entries<Slider>().ToList();
            //foreach (var item in data)
            //{
            //    item.Entity.ImagePath = "test.jpg";
            //}
            //data = _context.ChangeTracker.Entries<Slider>().ToList();
            //_context.SaveChanges(); 
            #endregion


            return View(vm);
        }
    }
}
