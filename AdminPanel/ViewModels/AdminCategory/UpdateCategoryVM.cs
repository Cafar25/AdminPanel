using System.ComponentModel.DataAnnotations;

namespace AdminPanel.ViewModels.AdminCategory
{
    public class UpdateCategoryVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bos Qoyma...")]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
