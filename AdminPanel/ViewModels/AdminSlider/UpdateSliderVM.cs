using System.ComponentModel.DataAnnotations;

namespace AdminPanel.ViewModels.AdminSlider
{
    public class UpdateSliderVM
    {
        public int Id { get; set; }
    
        public string ImageUrl { get; set; }
        public IFormFile Photo { get; set; }
    }
}
