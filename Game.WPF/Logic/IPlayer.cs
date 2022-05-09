using System;
using System.Collections.Generic;

namespace Game.WPF.Logic
{
    public interface IPlayer
    {
        double PlayerPos { get; set; }

        event EventHandler Changed;
        List<Laser> Lasers { get; set; }

        int HP { get; set; }
    }
}