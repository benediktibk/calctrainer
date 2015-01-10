using System;

namespace CalcTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var seed = Guid.NewGuid().GetHashCode();
            var numberGenerator = new NumberGenerator(seed);
            var consoleInput = new ConsoleInput();
            var consoleOutput = new ConsoleOutput();
            var taskGenerator = new TaskGenerator(numberGenerator, consoleInput, consoleOutput);
            var stopWatch = new StopWatch(60*10);
            var taskExecutor = new TaskExecutor(taskGenerator, consoleOutput, stopWatch);

            taskExecutor.Run();

            consoleOutput.WriteLine("\nTime is up!");
            consoleOutput.WriteLine("You have solved " + taskExecutor.TaskCount + " tasks with an accuracy of " + taskExecutor.Accuracy * 100 + "%");
            consoleOutput.WriteLine("\npress any key to exit");
            Console.ReadKey();
        }
    }
}
