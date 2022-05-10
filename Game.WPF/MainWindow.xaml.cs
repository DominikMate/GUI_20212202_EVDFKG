using Game.WPF.Logic; //kivetel
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;

namespace Game.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic logic;
        Player player;
        public MainWindow()
        {
            InitializeComponent();
            logic = new GameLogic();
            logic.OneDamage += Logic_OneDamage;   
            player = new Player();
            display.SetupModel(logic,player);

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(50);

            dt.Tick += Dt_Tick;
            dt.Start();
        }

        private void Logic_OneDamage(object? sender, EventArgs e)
        {
            (sender as GameLogic).Player.HP--;
            if ((sender as GameLogic).Player.HP <= 0)
            {
                MessageBox.Show("Vége");
            }
        }

        private void Dt_Tick(object? sender, EventArgs e)
        {
            player.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
            logic.TimeStep(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SoundPlayer splayer = new SoundPlayer();
            splayer.SoundLocation = "gameplaysong.wav";
            splayer.PlayLooping();
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
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
