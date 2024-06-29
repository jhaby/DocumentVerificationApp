using CommunityToolkit.Mvvm.ComponentModel;

namespace BlockVerify.ViewModels;

public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    bool isBusy = true;
}
