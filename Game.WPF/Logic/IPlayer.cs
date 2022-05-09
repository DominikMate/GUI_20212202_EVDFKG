using System;
using System.Collections.Generic;

namespace Game.WPF.Logic
{
    internal interface IPlayer
    {
        double PlayerPos { get; set; }

        event EventHandler Changed;
        List<Laser> Lasers { get; set; }
    }
}