using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;

namespace IceCreamApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Container container;

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
           this.container = Bootstrapper.RunApplication();
        } 
    }
}
