namespace CalcTrainer
{
    public interface IStopWatch
    {
        bool TimeUp { get; }
        void Restart();
    }
}