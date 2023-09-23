using AdminPanel.DAL;
using AdminPanel.Entities.ProductsSection;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Areas.FiorelloArea.Controllers
{
    [Area("FiorelloArea")]
    public class CategoryController : Controller
    {
        private readonly AdminPanelDbContext _context;

        public CategoryController(AdminPanelDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Categories.ToList());
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var existCategory = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (existCategory == null) return NotFound();
            return View(existCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Create(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "You cannot duplicate category name");
                return View();
            }
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0) return NotFound();
            Category category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if(category is null) return NotFound();
            return View(category);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public IActionResult Edit(int id, Category edited)
        {
            if (id != edited.Id) return BadRequest();
            Category category = _context.Categories.FirstOrDefault(c =>c.Id == id);
            if (category is null) return NotFound();
            bool duplicate = _context.Categories.Any(c => c.Name == edited.Name);
            if (duplicate)
            {
                ModelState.AddModelError("","You cannot duplicate category name");
                return View();
            }
            category.Name = edited.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
            

        }

    }
}
