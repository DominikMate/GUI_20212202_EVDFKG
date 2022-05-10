using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        private void SkinDark(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\playerskin.skn";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(0);
            outputFile.Close();
        }

        private void SkinWhite(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory()+ "\\playerskin.skn";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(1);
            outputFile.Close();
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
