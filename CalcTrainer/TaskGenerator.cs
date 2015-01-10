using System;
using CalcTrainer.Tasks;

namespace CalcTrainer
{
    public class TaskGenerator : ITaskGenerator
    {
        private readonly INumberGenerator _numberGenerator;
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly Random _random;

        public TaskGenerator(INumberGenerator numberGenerator, IInput input, IOutput output)
        {
            _numberGenerator = numberGenerator;
            _input = input;
            _output = output;
            _random = new Random();
        }

        public ITask Generate()
        {
            var selection = _random.Next(0, 2);
            ITask task;

            switch (selection)
            {
                case 0: 
                    task = new Division(_numberGenerator, _input, _output, 1);
                    break;
                case 1:
                    task = new Multiplication(_numberGenerator, _input, _output);
                    break;
                default:
                    throw new Exception("invalid value");
            }

            return task;
        }
    }
}
