using BlockVerify.Models;
using CommunityToolkit.Mvvm.Messaging;

namespace BlockVerify;

public partial class ScannerPage : ContentPage, IRecipient<ResultCompletedMessage>
{
	private int pageCount = 0;
	public ScannerPage()
	{
		InitializeComponent();
		WeakReferenceMessenger.Default.Register(this);

		qrCodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
		{
			Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
			AutoRotate = true,
			Multiple = true,
			TryHarder = true,
		};
	}

    public void Receive(ResultCompletedMessage message)
    {
		pageCount = 0;
    }

    private void QrCodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
		var code = e.Results?.FirstOrDefault();
		if(code is null)
		{
			Dispatcher.DispatchAsync(async () =>
			{
				await Shell.Current.DisplayAlert("Invalid QR Code", "Could not read verification code from QR code", "Try again");
				await Shell.Current.GoToAsync("..");
			});

			return;
		}
		
		Dispatcher.DispatchAsync(async () =>
		{
			if(pageCount == 0)
			{
				pageCount++;
				await Shell.Current.GoToAsync($"{nameof(ResultsPage)}?Code={code.Value}");
            }
			
		});

    }
}