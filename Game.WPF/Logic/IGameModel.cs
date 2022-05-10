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

        void SetupSizes(Size area);

        event EventHandler Changed;

        void SetupPlayer(IPlayer player);

        List<Enemy> miniEnemys { get; set; }
        List<Enemy> bossEnemys { get; set; }
        event EventHandler TwoDamage;
        event EventHandler ThreeDamage;
    }
}