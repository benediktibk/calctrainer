using CalcTrainer.Tasks;

namespace CalcTrainer
{
    public class TaskGenerator
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IInput _input;
        private readonly IOutput _output;

        public TaskGenerator(INumberGenerator numberGenerator, IInput input, IOutput output)
        {
            _numberGenerator = numberGenerator;
            _input = input;
            _output = output;
        }

        public Task Generate()
        {
            return new Division(_numberGenerator, _input, _output, 1);
        }
    }
}
