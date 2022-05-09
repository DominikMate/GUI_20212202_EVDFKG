using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WPF.Model
{
    interface IGameModel
    {
        double GameHeight { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        double GameWidth { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        List<Enemy> Enemies { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        List<Bullet> Bullets { get; set; }

        /// <summary>
        /// Gets or sets .
        /// </summary>
        int PointNumber { get; set; }
    }
}
