using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WPF.Model
{
    class Bullet
    {
        public Bullet (int x, int y, int dir)
        {

        }

        //public Point Position { get; set; }

        public int Direction { get; set; } 

        public int Damage { get; }

        //public Geometry BulletGeometry { get; set; }
    }
}
