using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.WPF.Logic
{
    internal class Enemy
    {
        Random random;
        Size area;
        int Skill;
        public Point PEnemy { get; set; }
        public Vector Speed { get; set; }
        public Enemy(Point penemy, Vector speed, int skill)
        {
            PEnemy = penemy;
            Speed = speed;
            Skill = skill;
            random = new Random();
        }

        public void SetupSizes(Size area)
        {
            this.area = area;
        }

        /*private int SpawnRandomizer(int skill)
        {

        }*/

        public bool Move(Size area)
        {
            Point newPEnemy =
        new Point(newPEnemy.X, newPEnemy.Y + (int)Speed.Y);
            if (newPEnemy.X >= 0 &&
                newPEnemy.X <= area.Width &&
                newPEnemy.Y >= 0 &&
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
