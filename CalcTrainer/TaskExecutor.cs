using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcTrainer
{
    public class TaskExecutor
    {
        private readonly int _duration;
        private readonly TaskGenerator _taskGenerator;
        private int _correctGuesses;
        private int _wrongGuesses;

        public TaskExecutor(TaskGenerator taskGenerator, int duration)
        {
            if (duration <= 0)
                throw new ArgumentOutOfRangeException("duration", "must be positive");

            _duration = duration;
            _taskGenerator = taskGenerator;
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
            var startTime = DateTime.Now;
            TaskCount = 0;
            _correctGuesses = 0;
            _wrongGuesses = 0;
            double elapsed;

            do
            {
                RunTask();
                TaskCount++;
                elapsed = (DateTime.Now - startTime).TotalSeconds;
            } while (elapsed < _duration);
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
                    Console.WriteLine("Correct!");
                }
                else
                {
                    _wrongGuesses++;
                    Console.WriteLine("Wrong!");
                }
            } while (!solved);
        }
    }
}
