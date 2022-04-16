using System;
using System.Windows;

namespace WebFrame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public string[] CommandLineArgs { get; private set; } = Array.Empty<string>();

        private App()
        {
            Startup += App_Startup;
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            CommandLineArgs = e.Args;
        }
    }
}
