using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        Window oldwin;
        public LevelPage()
        {
            InitializeComponent();
        }
        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
            oldwin = Application.Current.MainWindow;
        }
        private void Level1_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(1);
            outputFile.Close();
            oldwin = Application.Current.MainWindow;
            var win = new MainWindow();
            Application.Current.MainWindow = win;
            oldwin.Hide();
            Application.Current.MainWindow.Show();

            Application.Current.MainWindow.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            oldwin.Show();
        }

        private void Level2_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(2);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level3_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(3);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level4_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(4);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level5_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(5);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level6_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(6);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level7_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(7);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level8_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(8);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level9_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(9);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }

        private void Level10_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(10);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
        }
    }
}
