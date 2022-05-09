using Game.WPF.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Game.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private NavigationWindow navWindow;

        public NavigationWindow NavWindow
        {
            get { return this.navWindow; }
            set { this.navWindow = value; }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.navWindow = new NavigationWindow();
            this.navWindow.Height = 1080;
            this.navWindow.Width = 1920;

            this.navWindow.ResizeMode = ResizeMode.CanMinimize;
            this.navWindow.ShowsNavigationUI = false;
            this.navWindow.Height = 1080;
            this.navWindow.Width = 1920;

            var page = new MenuPage();
            this.navWindow.Navigate(page);
            this.navWindow.Show();

        }
    }
}
