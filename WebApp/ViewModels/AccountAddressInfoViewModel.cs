using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class AccountAddressInfoViewModel
{
    [Required(ErrorMessage = "You must enter a addressline")]
    [Display(Name = "Addressline 1", Prompt = "Enter your address line")]
    public string AddressLine_1 { get; set; } = null!;

    [Display(Name = "Addressline 2 (Opional)", Prompt = "Enter your  second address line")]
    public string? AddressLine_2 { get; set; }

    [Required(ErrorMessage = "You must enter a addressline")]
    [Display(Name = "PostalCode", Prompt = "Enter your postal code")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "You must enter a city")]
    [Display(Name = "City", Prompt = "Enter your city")]
    public string City { get; set; } = null!;
}
