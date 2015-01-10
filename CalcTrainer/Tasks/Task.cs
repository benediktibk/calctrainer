namespace CalcTrainer.Tasks
{
    public abstract class Task
    {
        protected Task(INumberGenerator numberGenerator, IInput input, IOutput output)
        {
            NumberGenerator = numberGenerator;
            Input = input;
            Output = output;
        }

        public INumberGenerator NumberGenerator { get; private set; }
        public IInput Input { get; private set; }
        public IOutput Output { get; private set; }

        public abstract bool Execute();
    }
}
