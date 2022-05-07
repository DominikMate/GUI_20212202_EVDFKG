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
    /// Interaction logic for LevelPage.xaml
    /// </summary>
    public partial class LevelPage : Page
    {
        public LevelPage()
        {
            InitializeComponent();
        }

        private void Level1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Level2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Level3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Level4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
