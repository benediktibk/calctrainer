namespace CalcTrainer.Tasks
{
    public abstract class Task
    {
        protected Task(INumberGenerator numberGenerator, IConsoleInput consoleInput)
        {
            NumberGenerator = numberGenerator;
            ConsoleInput = consoleInput;
        }

        public INumberGenerator NumberGenerator { get; private set; }
        public IConsoleInput ConsoleInput { get; private set; }

        public abstract bool Execute();
    }
}
