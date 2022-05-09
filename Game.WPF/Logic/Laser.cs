using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.WPF.Logic
{
    internal class Laser
    {
        public Laser(Vector speed, Point laserPoint)
        {
            Speed = speed;
            LaserPoint = laserPoint;
        }

        public Vector Speed { get; set; }
        public Point LaserPoint { get; set; }

        public bool Move(Size area)
        {
            Point newLaserPoint=
            new Point(LaserPoint.X, LaserPoint.Y+(int)Speed.Y);
            if (newLaserPoint.X >= 0 &&
                newLaserPoint.X <= area.Width &&
                newLaserPoint.Y >= 0 &&
                newLaserPoint.Y <= area.Height)
            {
                LaserPoint = newLaserPoint;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
