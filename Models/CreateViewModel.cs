using System.ComponentModel.DataAnnotations;

namespace JsonBasedLocalization.ViewModels;
public class CreateViewModel {
    [Display(Name = "name"), Required(ErrorMessage ="required")]
    public string Name{get;set;}
}