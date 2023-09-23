using System.ComponentModel.DataAnnotations;

namespace AdminPanel.ViewModels.AdminCategory
{
    public class CreateCategoryVM
    {
        [Required(ErrorMessage ="Bos Qoyma...")]
        [MaxLength(20)]
      public string Name { get; set; }
      public string Desc { get; set; }
    }
}
