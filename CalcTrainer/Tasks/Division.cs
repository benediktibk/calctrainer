using System;

namespace CalcTrainer.Tasks
{
    public class Division : Task
    {
        private readonly double _quotient;
        private readonly double _divisor;
        private readonly double _dividend;

        public Division(INumberGenerator numberGenerator, IInput input, IOutput output, int divisorPlaces) : base(numberGenerator, input, output)
        {
            do
            {
                _quotient = NumberGenerator.Generate(1, 1);
            } while (_quotient == 0);

            do
            {
                _divisor = NumberGenerator.Generate(divisorPlaces, 0);
            } while (_divisor == 0);

            _dividend = _quotient*_divisor;
        }

        public override bool Execute()
        {
            Output.WriteLine("What is the result of " + _dividend + ":" + _divisor + " ?");
            var attempt = Input.ReadNumber();
            return Math.Abs((attempt - _quotient)/_quotient) < 1e-10;
        }
    }
}
