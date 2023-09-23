using AdminPanel.Entities;
using AdminPanel.Entities.AboutSection;
using AdminPanel.Entities.BlogSection;
using AdminPanel.Entities.ExpertsSection;
using AdminPanel.Entities.ProductsSection;
using AdminPanel.Entities.SaySection;
using AdminPanel.Entities.SliderSection;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.DAL
{
    public class AdminPanelDbContext: DbContext
    {
        public AdminPanelDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderContent> SliderContents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<ExpertContent> ExpertContents { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BCategory> BCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Bio> Bios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
            base.OnModelCreating(modelBuilder);
        }





    }
}
