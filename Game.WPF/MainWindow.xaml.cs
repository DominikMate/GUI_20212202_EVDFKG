using Game.WPF.Logic; //kivetel
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Game.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool fix;
        SoundPlayer splayer;
        GameLogic logic;
        Player player;
        TimerLogic timerLogic;

        public MainWindow()
        {
            fix = true;
            InitializeComponent();
            logic = new GameLogic();
            logic.OneDamage += Logic_OneDamage;
            logic.TwoDamage += Logic_TwoDamage;
            logic.ThreeDamage += Logic_ThreeDamage;

            player = new Player();
            timerLogic= new TimerLogic();
            display.SetupModel(logic,player, timerLogic);
            logic.SetupTimer(timerLogic);
            timerLogic.Timmer_Game_Win += TimerLogic_Timmer_Game_Win;
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(50);

            dt.Tick += Dt_Tick;
            dt.Start();

        }

        private void TimerLogic_Timmer_Game_Win(object? sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory() + "\\Levels\\complevels.lvlc";
            StreamWriter outputFile = File.CreateText(path);
            if (logic.Maps < 10)
            {
                outputFile.WriteLine(logic.Maps++);
            }
            outputFile.Close();
            gameDone();
        }
        private void Logic_ThreeDamage(object? sender, EventArgs e)
        {
            if (fix)
            {
                (sender as GameLogic).Player.HP -= 3;
                if ((sender as GameLogic).Player.HP <= 0)
                {
                    gameDone();
                }
           }
        }

        private void Logic_TwoDamage(object? sender, EventArgs e)
        {
            if (fix)
            {
                (sender as GameLogic).Player.HP -= 2;
                if ((sender as GameLogic).Player.HP <= 0)
                {
                    gameDone();
                }
            }
        }

        private void Logic_OneDamage(object? sender, EventArgs e)
        {
            if (fix)
            {
                (sender as GameLogic).Player.HP--;
                if ((sender as GameLogic).Player.HP <= 0)
                {
                    gameDone();
                }
            }

        }
        private void gameDone()
        {
             var result = MessageBox.Show("tie fighter: "+logic.EnemyKillCounter+ "| tie fighter miniboss: "+logic.miniEnemyKillCounter+ "| tie fighter boss: "+logic.bossEnemyKillCounter, "Játék eredmények", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                fix = false;
                this.Close();
            }
        }

        private void Dt_Tick(object? sender, EventArgs e)
        {
            player.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            splayer = new SoundPlayer();
            splayer.SoundLocation = "gameplaysong.wav";
            splayer.PlayLooping();
            timerLogic.StartTimer();
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            this.Closed += MainWindow_Closed;
            Application.Current.MainWindow.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            splayer.Stop();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
            player.OutOfBoundsCheck(new Size(grid.ActualWidth, grid.ActualHeight));
            player.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.IsRepeat) return;
            switch (e.Key)
            {
                case Key.Left:
                    player.Control(Player.Controls.Left, new Size(grid.ActualWidth, grid.ActualHeight));
                    break;
                case Key.Right:
                    player.Control(Player.Controls.Right, new Size(grid.ActualWidth, grid.ActualHeight));
                    break;
                case Key.Space:
                    player.Control(Player.Controls.Shoot, new Size(grid.ActualWidth, grid.ActualHeight));
                    player.NextShoot = false;
                    break;
                default:
                    break;
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    player.NextShoot = true;
                    break;
                default:
                    break;
            }
        }
    }
}
