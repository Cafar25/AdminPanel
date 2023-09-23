using System.ComponentModel.DataAnnotations;

namespace AdminPanel.Entities.ProductsSection
{
    public class Category
    {
        [Required(ErrorMessage = "Please field category input")]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
