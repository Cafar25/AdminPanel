using AdminPanel.Entities.AboutSection;
using AdminPanel.Entities.BlogSection;
using AdminPanel.Entities.ExpertsSection;
using AdminPanel.Entities.ProductsSection;
using AdminPanel.Entities.SaySection;
using AdminPanel.Entities.SliderSection;

namespace AdminPanel.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public SliderContent SliderContent { get; set; }
        public Advertisement Advertisement { get; set; }
        public List<Benefit> Benefits { get; set; }
        public List<Expert> Experts { get; set; }
        public ExpertContent ExpertContent { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
