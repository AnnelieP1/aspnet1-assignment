using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class AccountBasicInfoViewModel
{
    [Display(Name = "First name", Prompt = "Enter your first name.")]
    [Required(ErrorMessage = "You must enter a first name")]
    [MinLength(2, ErrorMessage = "A valid first name is required")]
    [DataType(DataType.Text)]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last name", Prompt = "Enter your last name.")]
    [Required(ErrorMessage = "You must enter a last name")]
    [MinLength(2, ErrorMessage = "A valid last name is required")]
    [DataType(DataType.Text)]
    public string LastName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address.")]
    [Required(ErrorMessage = "You must enter an email address")]
    [MinLength(2, ErrorMessage = "A valid email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone", Prompt = "Enter your Phonenumber")]
    public string? Phonenumber { get; set; }

    [Display(Name = "Bio (Optional)", Prompt = "Add a short bio...")]
    public string? Biography { get; set; }
}
