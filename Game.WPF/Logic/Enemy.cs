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
        bool miniboss;
        bool boss;
        Random random;
        Size area;
        int Skill;
        public Point PEnemy { get; set; }
        public Vector Speed { get; set; }
        public Enemy(Size area, int skill=1, bool miniboss=false, bool boss=false)
        {
            random = new Random();
            this.area = area;
            this.Skill = skill;
            this.miniboss = miniboss;
            this.boss = boss;
            if (miniboss)
            {
                SpawnRandomizerminiboss();
            }
            if (boss)
            {
                SpawnRandomizerboss();
            }
            SpawnRandomizer();
        }
        public void SpawnRandomizer()
        {
            PEnemy = new Point(random.Next(1, (int)area.Width- 200), random.Next(-200, -100));
            Speed = new Vector(0, random.Next(3, 6));
        }
        public void SpawnRandomizerminiboss()
        {
            PEnemy = new Point(random.Next(1, (int)area.Width - 200), random.Next(-200, -100));
            Speed = new Vector(0, random.Next(2, 3));
        }
        public void SpawnRandomizerboss()
        {
            PEnemy = new Point(random.Next(1, (int)area.Width - 200), random.Next(-200, -100));
            Speed = new Vector(0, random.Next(1, 3));
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
