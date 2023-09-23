using AdminPanel.DAL;
using AdminPanel.Entities.BlogSection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Controllers
{
    public class BlogController : Controller
    {
        private readonly AdminPanelDbContext _context;

        public BlogController(AdminPanelDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.Include(b=>b.Category).ToList();
            return View(blogs);
        }

        public IActionResult Detail(int id)
        {
            if (id == 0) return NotFound();

            Blog blog = _context.Blogs
                .Include(b=>b.Category)
                .Include(b=>b.BlogTags).ThenInclude(bt=>bt.Tag)
                .FirstOrDefault(b=>b.Id==id);

            return View(blog);
            
        }
    }
}
