using System;

namespace CalcTrainer.Tasks
{
    public class Division : Task
    {
        public Division(INumberGenerator numberGenerator, IInput input, IOutput output, int divisorPlaces) : base(numberGenerator, input, output)
        {
            do
            {
                Quotient = NumberGenerator.Generate(1, 1);
            } while (Quotient == 0 || Quotient == 1);

            do
            {
                Divisor = NumberGenerator.Generate(divisorPlaces, 0);
            } while (Divisor == 0 || Quotient == 1);

            Dividend = Quotient*Divisor;
        }

        public override bool Execute()
        {
            Output.WriteLine("What is the result of " + Dividend + ":" + Divisor + " ?");
            var attempt = Input.ReadNumber();
            return Math.Abs((attempt - Quotient)/Quotient) < 1e-10;
        }

        public double Quotient { get; private set; }
        public double Divisor { get; private set; }
        public double Dividend { get; private set; }
    }
}
