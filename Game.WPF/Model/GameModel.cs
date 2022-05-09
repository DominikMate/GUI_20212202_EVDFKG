using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.WPF.Model
{
    class GameModel : IGameModel
    {
        public GameModel(double w, double h)
        {
            this.GameWidth = w;
            this.GameHeight = h;
            this.PointNumber = 0;
        }
        public double GameHeight { get; set; }
        public double GameWidth { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Bullet> Bullets { get; set; }
        public int PointNumber { get; set; }
    }
}
