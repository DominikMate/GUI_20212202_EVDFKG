using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.WPF.Logic
{
    public class Enemy
    {
        Random random;
        Size area;
        int Skill=1;
        public Point PEnemy { get; set; }
        public Vector Speed { get; set; }
        public Enemy(Size area, int skill)
        {
            random = new Random();
            this.area = area;
            this.Skill = skill;
            SpawnRandomizer();
        }
        public void SpawnRandomizer()
        {
            PEnemy = new Point(random.Next(1, (int)area.Width- 200), random.Next(-20, -1));
            Speed = new Vector(0, random.Next(Skill * 5, Skill * 10));
        }

        public bool Move(Size area)
        {
            Point newPEnemy =
        new Point(PEnemy.X, PEnemy.Y + (int)Speed.Y);
            if (newPEnemy.X >= 0 &&
                newPEnemy.X <= area.Width-200 &&
                newPEnemy.Y <= area.Height)
            {
                PEnemy = newPEnemy;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
