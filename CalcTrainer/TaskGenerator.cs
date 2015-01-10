using CalcTrainer.Tasks;

namespace CalcTrainer
{
    public class TaskGenerator
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IConsoleInput _consoleInput;

        public TaskGenerator(INumberGenerator numberGenerator, IConsoleInput consoleInput)
        {
            _numberGenerator = numberGenerator;
            _consoleInput = consoleInput;
        }

        public Task Generate()
        {
            return new Division(_numberGenerator, _consoleInput, 1);
        }
    }
}
