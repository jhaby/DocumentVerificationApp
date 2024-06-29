namespace BlockVerify
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ScannerPage), typeof(ScannerPage));
            Routing.RegisterRoute(nameof(ResultsPage), typeof(ResultsPage));
        }
    }
}
