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
    internal class Display:FrameworkElement
    {
        Size area;
        Size PlayerSize;
        MediaPlayer background;
        public void SetupSizes(Size area)
        {
            this.area = area;
            this.PlayerSize.Width = area.Width/6;
            this.PlayerSize.Height = area.Height / 6;
            this.InvalidateVisual();
        }
        public Brush ShipBrush
        {
            get 
            {
                return new ImageBrush(new BitmapImage(new Uri(Path.Combine("Images", "player1.bmp"),UriKind.RelativeOrAbsolute)));
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
            if (area.Width>0 && area.Height>0)
            {
                drawingContext.DrawVideo(background, new Rect(0, 0, area.Width, area.Height));
                drawingContext.DrawRectangle(ShipBrush,null, new Rect((area.Width /2)-(PlayerSize.Width / 2), (area.Height * 0.9) -(PlayerSize.Height / 2), PlayerSize.Width, PlayerSize.Height));
            }
        }
    }
}
