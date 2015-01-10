using System;

namespace CalcTrainer
{
    public class StopWatch : IStopWatch
    {
        private DateTime _start;
        private readonly int _duration;

        public StopWatch(int duration)
        {
            if (duration <= 0)
                throw new ArgumentOutOfRangeException("duration", "must be positive");

            _duration = duration;
        }

        public bool TimeUp
        {
            get
            {
                return (DateTime.Now - _start).TotalSeconds > _duration;
            }
        }

        public void Restart()
        {
            _start = DateTime.Now;
        }
    }
}
