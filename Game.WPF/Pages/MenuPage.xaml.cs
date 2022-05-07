using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Game.WPF.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        private GameControl control;
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Levels_Click(object sender, RoutedEventArgs e)
        {
            /*this.NavigationService.Navigate(new GamePage(this.control));*/
        }

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            /*this.NavigationService.Navigate(new OptionsPage());*/
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                win.Close();
            }
        }
    }
}
