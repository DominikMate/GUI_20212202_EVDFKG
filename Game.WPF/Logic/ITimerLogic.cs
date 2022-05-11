using System;
using System.Timers;

namespace Game.WPF.Logic
{
    public interface ITimerLogic
    {
        //event EventHandler Timer_Game_Lose;
        event EventHandler Timmer_Game_Win;
        int TimerPos { get; set; }
        Timer MyTimer { get; set; }
        int time { get; set; }
        //void StartTimer();
    }
}