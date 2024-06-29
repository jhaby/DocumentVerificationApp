using BlockVerify.Models;
using BlockVerify.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace BlockVerify.ViewModels;
[QueryProperty(nameof(Code), "Code")]
public partial class ResultsViewModel(VerificationService verificationService) : BaseViewModel
{
    [ObservableProperty]
    string code = string.Empty;

    [ObservableProperty]
    bool isFailed = false;

    [ObservableProperty]
    bool isSuccess = false;

    [ObservableProperty]
    VerificationResult? docResult = null;

    [ObservableProperty]
    double height = DeviceDisplay.Current.MainDisplayInfo.Height;

    [RelayCommand]
    public async Task ViewOriginal()
    {
        await Browser.Default.OpenAsync($"{AppConstants.GatewayUrl}{DocResult?.Hash}");
    }

    public async void OnAppearing()
    {
        await Task.Delay(1000);
        if(Connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No internet connection", "Please connect to the internet and try again", "Ok");
            WeakReferenceMessenger.Default.Send(new ResultCompletedMessage(Code));
            await Shell.Current.GoToAsync("..");
        }

        VerificationResult? result = await verificationService.Verify(Code);
        if(result is null)
        {
            IsFailed = true;
            IsBusy = false;
            return;
        }

        IsBusy = false;
        IsSuccess = true;
        DocResult = result;
    }
}
