using System;

namespace CalcTrainer.Tasks
{
    public class Multiplication : Task
    {
        public Multiplication(INumberGenerator numberGenerator, IInput input, IOutput output) : base(numberGenerator, input, output)
        {
            do
            {
                ValueOne = NumberGenerator.Generate(2, 0);
            } while (ValueOne == 0 || ValueOne == 1);

            do
            {
                ValueTwo = NumberGenerator.Generate(1, 0);
            } while (ValueTwo == 0 || ValueTwo == 1);
        }

        public double ValueOne { get; private set; }
        public double ValueTwo { get; private set; }

        public override bool Execute()
        {
            Output.WriteLine("What is the result of " + ValueOne + "*" + ValueTwo + "?");
            var correctResult = ValueOne*ValueTwo;
            var guess = Input.ReadNumber();
            return Math.Abs(guess - correctResult) < 1e-10;
        }
    }
}
