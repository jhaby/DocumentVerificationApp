using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BlockVerify.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    string code = string.Empty;

    [RelayCommand]
    public async Task ScanCode()
    {
        await Shell.Current.GoToAsync(nameof(ScannerPage));
    }

    [RelayCommand]
    public async Task VerifyCode()
    {
        if (string.IsNullOrEmpty(Code))
        {
            await Shell.Current.DisplayAlert("Empty field", "Please enter verification code", "ok");
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(ResultsPage)}?Code={Code}");
    }
}
