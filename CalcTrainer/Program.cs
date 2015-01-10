using System;

namespace CalcTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberGenerator = new NumberGenerator(5);
            var consoleInput = new ConsoleInput();
            var taskGenerator = new TaskGenerator(numberGenerator, consoleInput);
            var taskExecutor = new TaskExecutor(taskGenerator, 60*10);

            taskExecutor.Run();

            Console.WriteLine("\nTime is up!");
            Console.WriteLine("You have solved " + taskExecutor.TaskCount + " tasks with an accuracy of " + taskExecutor.Accuracy * 100 + "%");
            Console.WriteLine("\npress any key to exit");
            Console.ReadKey();
        }
    }
}
