using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Game.WPF.Logic
{
    public class TimerLogic : ITimerLogic
    {
        public int time { get; set; }
        public int TimerPos { get; set; }
        public event EventHandler Timmer_Game_Win;
        //public event EventHandler Timer_Game_Lose;
        public Timer MyTimer { get; set; }

        public TimerLogic()
        {
            time = 2;
            TimerPos = 0;
        }
        public void StartTimer()
        {
            MyTimer = new Timer();
            MyTimer.Interval = 1000;
            MyTimer.Enabled = true;
            MyTimer.Elapsed += MyTimer_Elapsed;
        }

        private void MyTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (TimerPos == time)
            {
                MyTimer.Enabled = false;
                Timmer_Game_Win?.Invoke(this, null);
            }
            else
            {
                TimerPos++;
            }
        }

        /*public void ATimer_Win(object sender, ElapsedEventArgs e)
        {
            Timmer_Game_Win?.Invoke(this, null);
        }*/
        /*private void ATimer_Lose(object sender, ElapsedEventArgs e)
        {
            Timer_Game_Lose?.Invoke(this, null);
        }*/
    }
}
