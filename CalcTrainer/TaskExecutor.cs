using System;

namespace CalcTrainer
{
    public class TaskExecutor
    {
        private readonly ITaskGenerator _taskGenerator;
        private readonly IOutput _output;
        private readonly IStopWatch _stopWatch;
        private int _correctGuesses;
        private int _wrongGuesses;

        public TaskExecutor(ITaskGenerator taskGenerator, IOutput output, IStopWatch stopWatch)
        {

            _taskGenerator = taskGenerator;
            _output = output;
            _stopWatch = stopWatch;
        }

        public double Accuracy
        {
            get
            {
                return ((double)_correctGuesses) / (_correctGuesses + _wrongGuesses);
            }
        }

        public int TaskCount { get; private set; }

        public void Run()
        {
            _stopWatch.Restart();
            TaskCount = 0;
            _correctGuesses = 0;
            _wrongGuesses = 0;

            do
            {
                RunTask();
                TaskCount++;
            } while (!_stopWatch.TimeUp);
        }

        private void RunTask()
        {
            var task = _taskGenerator.Generate();
            bool solved;

            do
            {
                solved = task.Execute();

                if (solved)
                {
                    _correctGuesses++;
                    _output.WriteLine("Correct!");
                }
                else
                {
                    _wrongGuesses++;
                    _output.WriteLine("Wrong!");
                }
            } while (!solved);
        }
    }
}
