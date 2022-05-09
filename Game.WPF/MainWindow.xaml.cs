using Game.WPF.Logic; //kivetel
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

namespace Game.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic logic;
        public MainWindow()
        {
            InitializeComponent();
            logic = new GameLogic();
            display.SetupModel(logic);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            display.SetupSizes(new Size(grid.ActualWidth, grid.ActualHeight));
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    logic.Control(GameLogic.Controls.Left);
                    break;
                case Key.Right:
                    logic.Control(GameLogic.Controls.Right);
                    break;
                case Key.Space:
                    logic.Control(GameLogic.Controls.Shoot);
                    break;
                default:
                    break;
            }
        }
    }
}
