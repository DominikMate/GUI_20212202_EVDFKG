using Game.WPF.Logic;
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
        GameLogic logic;
        private int maps;
        Window mwindow;

        public LevelPage()
        {
            InitializeComponent();

            clevel();
        }
        private void CompletedLevels(string path)
        {
            int lvl = 1;
            if (int.TryParse(File.ReadAllText(path), out lvl) && lvl >= 1 && lvl <= 10)
            {
                maps = lvl;
            }
            else
            {
                maps = 1;
            }
        }
        public void clevel()
        {
            CompletedLevels(Directory.GetFiles(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "complevels.lvlc").First());
            switch (maps)
            {
                case 1:
                    level1.IsEnabled = true;
                    level2.IsEnabled = false;
                    level3.IsEnabled = false;
                    level4.IsEnabled = false;
                    level5.IsEnabled = false;
                    level6.IsEnabled = false;
                    level7.IsEnabled = false;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 2:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = false;
                    level4.IsEnabled = false;
                    level5.IsEnabled = false;
                    level6.IsEnabled = false;
                    level7.IsEnabled = false;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 3:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = false;
                    level5.IsEnabled = false;
                    level6.IsEnabled = false;
                    level7.IsEnabled = false;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 4:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = false;
                    level6.IsEnabled = false;
                    level7.IsEnabled = false;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 5:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = true;
                    level6.IsEnabled = false;
                    level7.IsEnabled = false;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 6:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = true;
                    level6.IsEnabled = true;
                    level7.IsEnabled = false;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 7:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = true;
                    level6.IsEnabled = true;
                    level7.IsEnabled = true;
                    level8.IsEnabled = false;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 8:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = true;
                    level6.IsEnabled = true;
                    level7.IsEnabled = true;
                    level8.IsEnabled = true;
                    level9.IsEnabled = false;
                    level10.IsEnabled = false;
                    break;
                case 9:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = true;
                    level6.IsEnabled = true;
                    level7.IsEnabled = true;
                    level8.IsEnabled = true;
                    level9.IsEnabled = true;
                    level10.IsEnabled = false;
                    break;
                case 10:
                    level1.IsEnabled = true;
                    level2.IsEnabled = true;
                    level3.IsEnabled = true;
                    level4.IsEnabled = true;
                    level5.IsEnabled = true;
                    level6.IsEnabled = true;
                    level7.IsEnabled = true;
                    level8.IsEnabled = true;
                    level9.IsEnabled = true;
                    level10.IsEnabled = true;
                    break;
                default:
                    break;
            }
        }
        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            clevel();
            this.NavigationService.GoBack();
            clevel();
        }
        private void Level1_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(1);
            outputFile.Close();
            /*oldwin = Application.Current.MainWindow;
            var win = new MainWindow();
            Application.Current.MainWindow = win;
            oldwin.Hide();
            Application.Current.MainWindow.Show();

            Application.Current.MainWindow.Closed += MainWindow_Closed;*/
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed+= GameWindow_Closed;
            clevel();
        }

        private void GameWindow_Closed(object? sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
            clevel();
        }

        private void Level2_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(2);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }

        private void Level3_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(3);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }

        private void Level4_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(4);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }

        private void Level5_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(5);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
            clevel();
        }

        private void Level6_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(6);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }

        private void Level7_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(7);
            outputFile.Close();
            var appWindow = new MainWindow();
            appWindow.Show();
            clevel();
        }

        private void Level8_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(8);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }

        private void Level9_Click(object sender, RoutedEventArgs e)
        {
            clevel();
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(9);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }

        private void Level10_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(10);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
            clevel();
        }
    }
}
