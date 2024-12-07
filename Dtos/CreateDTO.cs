using System.ComponentModel.DataAnnotations;

namespace JsonBasedLocalization.ViewModels;
public class CreateDTO {
    [Required(ErrorMessage ="required")]
    public string Name{get;set;}
}