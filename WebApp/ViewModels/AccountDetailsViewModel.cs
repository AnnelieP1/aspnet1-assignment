namespace WebApp.ViewModels;

public class AccountDetailsViewModel
{
    public AccountBasicInfoViewModel BasicInfo { get; set; } = null!;
    public AccountAddressInfoViewModel AddressInfo { get; set; } = null!;
}
