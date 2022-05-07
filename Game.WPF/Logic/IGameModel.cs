using System;
using System.Collections.Generic;

namespace Game.WPF.Logic
{
    public interface IGameModel
    {
        List<GameLogic.MapData> MapDatas { get; set; }
        int Maps { get; set; }
        double PlayerPos { get; set; }
        event EventHandler Changed;
    }
}