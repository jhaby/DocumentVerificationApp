using BlockVerify.Services;
using BlockVerify.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ZXing.Net.Maui.Controls;

namespace BlockVerify
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseBarcodeReader();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<ScannerPage>();
            builder.Services.AddScoped<VerificationService>();
            builder.Services.AddTransient<ResultsViewModel>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ResultsPage>();
            return builder.Build();
        }
    }
}
