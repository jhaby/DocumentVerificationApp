using BlockVerify.Models;
using BlockVerify.ViewModels;
using CommunityToolkit.Mvvm.Messaging;

namespace BlockVerify;

public partial class ResultsPage : ContentPage
{
    private readonly ResultsViewModel viewModel;

    public ResultsPage(ResultsViewModel resultsViewModel)
	{
		InitializeComponent();
        BindingContext = viewModel = resultsViewModel;
    }
    protected override  void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();

    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WeakReferenceMessenger.Default.Send(new ResultCompletedMessage(string.Empty));
    }
}