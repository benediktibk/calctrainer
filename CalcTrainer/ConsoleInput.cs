using System;

namespace CalcTrainer
{
    public class ConsoleInput : IInput
    {
        public double ReadNumber()
        {
            double result;
            bool valid;

            do
            {
                var line = Console.ReadLine();
                valid = Double.TryParse(line, out result);

                if (!valid)
                    Console.WriteLine("invalid number");

            } while (!valid);

            return result;
        }
    }
}
