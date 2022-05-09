using System;
using System.Collections.Generic;
using System.Windows;

namespace Game.WPF.Logic
{
    public interface IGameModel
    {
        List<GameLogic.MapData> MapDatas { get; set; }
        int Maps { get; set; }

        List<Enemy> Enemys { get; set; }

        public void SetupSizes(Size area);

        public event EventHandler Changed;

        public void SetupPlayer(IPlayer player);
    }
}