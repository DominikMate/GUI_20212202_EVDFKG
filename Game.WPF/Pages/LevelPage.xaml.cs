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
        /* private bool level1;

         public bool Level1
         {
             get { return level1; }
             set { level1 = value; }
         }
         private bool level2;

         public bool Level2
         {
             get { return level2; }
             set { level2 = value; }
         }

         private bool level3;

         public bool Level3
         {
             get { return level3; }
             set { level3 = value; }
         }

         private bool level4;

         public bool Level4
         {
             get { return level4; }
             set { level4 = value; }
         }

         private bool level5;

         public bool Level5
         {
             get { return level5; }
             set { level5 = value; }
         }

         private bool level6;

         public bool Level6
         {
             get { return level6; }
             set { level6 = value; }
         }

         private bool level7;

         public bool Level7
         {
             get { return level7; }
             set { level7 = value; }
         }

         private bool level8;

         public bool Level8
         {
             get { return level8; }
             set { level8 = value; }
         }

         private bool level9;

         public bool Level9
         {
             get { return level9; }
             set { level9 = value; }
         }

         private bool level10;

         public bool Level10
         {
             get { return level10; }
             set { level10 = value; }
         }

        public bool level1 { get; set; }
        public bool level2 { get; set; }
        public bool level3 { get; set; }
        public bool level4 { get; set; }
        public bool level5 { get; set; }
        public bool level6 { get; set; }
        public bool level7 { get; set; }
        public bool level8 { get; set; }
        public bool level9 { get; set; }
        public bool level10 { get; set; }*/

        public LevelPage()
        {

            InitializeComponent();
            CompletedLevels(Directory.GetFiles(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Levels"), "complevels.lvlc").First());
            switch (maps)
            {
                    case 1:
                    level1.IsEnabled=true;
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
        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Level1_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void GameWindow_Closed(object? sender, EventArgs e)
        {
            Application.Current.MainWindow.Show();
        }

        private void Level2_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(2);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
        }

        private void Level3_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(3);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
        }

        private void Level4_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(4);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
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
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
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
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
        }

        private void Level9_Click(object sender, RoutedEventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\loadedlevel.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            outputFile.WriteLine(9);
            outputFile.Close();
            MainWindow n = new MainWindow();
            n.Show();
            Application.Current.MainWindow.Hide();
            n.Closed += GameWindow_Closed;
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
        }
    }
}
