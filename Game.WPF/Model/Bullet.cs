using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game.WPF.Model
{
    class Bullet : IGameItem
    {
        public Bullet(int x, int y, int dir)
        {
            this.Position = new Point(x, y);
            this.Direction = dir;
            this.Damage = 1;
            this.BulletGeometry = null;
        }

        public int Direction { get; set; } 

        public int Damage { get; }
        public Point Position { get; set; }

        public Geometry BulletGeometry { get; set; }
    }

}
