using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game.WPF.Model
{
    internal class Player 
    {
        public Point Position { get; set; }

        /// <summary>
        /// gets or sets.
        /// </summary>
        public int Direction { get; set; } //1-360fok milyen irányba néz

        /// <summary>
        /// gets or sets.
        /// </summary>
        public Geometry PlayerGeometry { get; set; }

        /// <summary>
        /// gets or sets.
        /// </summary>
        public int Health { get; set; }

        public Player(int x, int y, int dir)
        {
            this.Position = new Point(x, y);
            this.Direction = dir;
            this.PlayerGeometry = null;
            this.Health = 5;
        }
    }
}
