using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game.WPF.Logic
{
    internal class Player : IPlayer
    {
        public List<Laser> Lasers { get; set; }
        public bool NextShoot { get; set; }
        Size PlayerSize;
        bool leftright;
        public Player()
        {
            Lasers = new List<Laser>();
            Speed = new Vector(35,0);
            NextShoot = true;
        }

        public event EventHandler Changed;
        public double PlayerPos { get; set; }
        public Vector Speed { get; set; }
        public void OutOfBoundsCheck(Size size)
        {
            if (PlayerPos > size.Width / 2)
            {
                while (PlayerPos > size.Width / 2)
                {
                    PlayerPos -= Speed.X;
                }
            }
            else if (PlayerPos < -(size.Width / 2))
            {
                while (PlayerPos < -(size.Width / 2))
                {
                    PlayerPos += Speed.X;
                }
            }
        }

        public void Control(Controls control, Size size)
        {
            switch (control)
            {
                case Controls.Left:
                    PlayerPos -= Speed.X;
                    break;
                case Controls.Right:
                    PlayerPos += Speed.X;
                    break;
                case Controls.Shoot:
                    NewShoot(size);
                    break;
            }
            if (PlayerPos > size.Width / 2)
            {
                while (PlayerPos > size.Width / 2)
                {
                    PlayerPos -= Speed.X;
                }
            }
            else if (PlayerPos < -(size.Width / 2))
            {
                while (PlayerPos < -(size.Width / 2))
                {
                    PlayerPos += Speed.X;
                }
            }
            Changed?.Invoke(this, null);
        }

        private void NewShoot(Size area)
        {
            if (NextShoot)
            {
                this.PlayerSize.Width = area.Width / 6;
                this.PlayerSize.Height = area.Height / 6;
                switch (leftright)
                {
                    case true:
                        Lasers.Add(new Laser(new Vector(0, -15), new Point((area.Width / 2) - (PlayerSize.Width / 3.9) + PlayerPos, (area.Height * 0.9) - (PlayerSize.Height / 2))));
                        leftright = false;
                        break;
                    case false:
                        Lasers.Add(new Laser(new Vector(0, -15), new Point((area.Width / 2) + (PlayerSize.Width / 5.1) + PlayerPos, (area.Height * 0.9) - (PlayerSize.Height / 2))));
                        leftright = true;
                        break;
                }
                NextShoot = false;
            }
        }

        public void TimeStep(Size area)
        {
            for (int i = 0; i < Lasers.Count; i++)
            {
                bool inside=Lasers[i].Move(area);
                if (!inside)
                {
                    Lasers.RemoveAt(i);
                }
            }
            Changed?.Invoke(this,null);
        }

        public enum Controls
        {
            Left, Right, Shoot
        }
    }
}
