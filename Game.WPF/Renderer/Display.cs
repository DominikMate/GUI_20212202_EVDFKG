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
        public void SetupSizes(Size area)
        {
            this.area = area;
            this.InvalidateVisual();
        }
        MediaPlayer player;
        public Display()
        {
            player=new MediaPlayer();
            player.Open(new Uri(Path.Combine("Images", "ingamebackground.mp4"), UriKind.RelativeOrAbsolute));
            player.MediaEnded += Player_MediaEnded;
            player.Play();
        }

        private void Player_MediaEnded(object? sender, EventArgs e)
        {
            player.Position=TimeSpan.Zero;
            player.Play();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (area.Width>0 && area.Height>0)
            {
                drawingContext.DrawVideo(player, new Rect(0, 0, area.Width, area.Height));
            }
        }
    }
}
