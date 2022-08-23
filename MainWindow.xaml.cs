using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WebFrame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Uri uri = new("https://duckduckgo.com");

        private void Window_Initialized(object sender, EventArgs e)
        {
            App app = (App)Application.Current;
            if (app.CommandLineArgs.Length >= 1)
            {
                uri = new Uri(app.CommandLineArgs[0]);
            }

            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await WebView.EnsureCoreWebView2Async(null);
            WebView.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            WebView.Source = uri;
            WebView.CoreWebView2.FaviconChanged += CoreWebView2_FaviconChanged;
        }

        private void CoreWebView2_DocumentTitleChanged(object? sender, object e)
        {
            Title = WebView.CoreWebView2.DocumentTitle;
        }

        private void CoreWebView2_FaviconChanged(object? sender, object e)
        {
            Icon = new BitmapImage(new Uri(WebView.CoreWebView2.FaviconUri));
        }
    }
}
