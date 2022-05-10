using Game.WPF.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game.WPF.Renderer
{
    internal class Display : FrameworkElement
    {
        Size area;
        Size PlayerSize;
        MediaPlayer background;
        IGameModel model;
        IPlayer player;
        ITimerLogic timerLogic;

        public void SetupModel(IGameModel model, IPlayer player, ITimerLogic timerLogic)
        {
            this.model = model;
            this.player = player;
            this.timerLogic = timerLogic;
            this.timerLogic.Timmer_Game_Win += TimerLogic_Timmer_Game_Win;
            this.player.Changed += (sender, eventargs) => this.InvalidateVisual();
        }

        public void TimerLogic_Timmer_Game_Win(object? sender, EventArgs e)
        {
            MessageBox.Show("Játék Vége");
        }

        public void SetupSizes(Size area)
        {
            this.area = area;
            this.PlayerSize.Width = area.Width/6;
            this.PlayerSize.Height = area.Height / 6;
            this.model.SetupSizes(this.area);
            this.model.SetupPlayer(this.player);
            this.InvalidateVisual();
        }
        public Brush ShipBrush
        {
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "player1.bmp"),UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush EnemyBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "enemy1.bmp"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush minibossBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "enemyminiboss.bmp"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Brush bossBrush
        {
            get
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "enemyboss.bmp"), UriKind.RelativeOrAbsolute)));
            }
        }
        public Display()
        {
            background = new MediaPlayer();
            background.Open(new Uri(Path.Combine("Images", "ingamebackground.mp4"), UriKind.RelativeOrAbsolute));
            background.MediaEnded += Player_MediaEnded;
            background.Play();
        }

        private void Player_MediaEnded(object? sender, EventArgs e)
        {
            background.Position=TimeSpan.Zero;
            background.Play();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (area.Width>0 && area.Height>0 && model!=null)
            {
                drawingContext.DrawVideo(background, new Rect(0, 0, area.Width, area.Height));
                drawingContext.DrawRectangle(ShipBrush, null, new Rect((area.Width /2)-(PlayerSize.Width / 2)+ player.PlayerPos, (area.Height * 0.9) -(PlayerSize.Height / 2), PlayerSize.Width, PlayerSize.Height));
                drawingContext.DrawRectangle(Brushes.Gray, new Pen(Brushes.Black, 3), new Rect((area.Width / 2) - (PlayerSize.Width / 2) + player.PlayerPos, (area.Height * 0.98), (area.Width * 0.7 / 4), area.Height / 64));
                drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 3), new Rect((area.Width / 2) - (PlayerSize.Width / 2) + player.PlayerPos, (area.Height * 0.98), Math.Abs(((area.Width*0.7 / 4) / 3) * player.HP), area.Height / 64));
                // drawingContext.DrawRectangle(null, new Pen(Brushes.Red, 1), new Rect((area.Width / 2) - ((area.Width / 6) / 2) + player.PlayerPos+(PlayerSize.Width / 4), (area.Height * 0.9) - ((area.Height / 6) / 2), PlayerSize.Width/2, PlayerSize.Height)); hitbox player
                foreach (var item in player.Lasers)
                {
                    drawingContext.DrawRectangle(new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "laser1.bmp"), UriKind.RelativeOrAbsolute))), null, new Rect(item.LaserPoint.X,item.LaserPoint.Y, (area.Width / 96), (area.Height / 16)));
                }
                foreach (var item in model.Enemys)
                {
                    drawingContext.DrawRectangle(EnemyBrush, null, new Rect(item.PEnemy.X, item.PEnemy.Y, PlayerSize.Width, PlayerSize.Height));
                    //drawingContext.DrawRectangle(null, new Pen(Brushes.Red, 1), new Rect(item.PEnemy.X + (PlayerSize.Width / 4), item.PEnemy.Y, (PlayerSize.Width/2), PlayerSize.Height)); hitbox ellenség
                }
                foreach (var item in model.miniEnemys)
                {
                    drawingContext.DrawRectangle(minibossBrush, null, new Rect(item.PEnemy.X, item.PEnemy.Y, PlayerSize.Width, PlayerSize.Height));
                }
                foreach (var item in model.bossEnemys)
                {
                    drawingContext.DrawRectangle(bossBrush, null, new Rect(item.PEnemy.X, item.PEnemy.Y, PlayerSize.Width, PlayerSize.Height));
                }
                drawingContext.DrawRectangle(Brushes.Gray, new Pen(Brushes.Black, 3), new Rect(0, 0, area.Width / 4, area.Height / 32));
                drawingContext.DrawRectangle(Brushes.Red, new Pen(Brushes.Black, 3), new Rect(0, 0, ((area.Width / 4)/120)*timerLogic.TimerPos, area.Height / 32));

            }
        }
    }
}
