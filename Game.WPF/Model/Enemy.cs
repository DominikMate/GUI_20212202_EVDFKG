using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Game.WPF.Model
{
    class Enemy
    {
        public Point Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets .
        /// </summary>
        public bool Finished { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        public Geometry EnemyGeometry { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Enemy"/> class.
        /// Enemy constructor.
        /// </summary>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        /// <param name="health">life point.</param>
        public Enemy(int x, int y, int health)
        {
            this.Position = new Point(x, y);
            this.Finished = false;
            this.Health = health;
            this.EnemyGeometry = null;
        }
    }
}
