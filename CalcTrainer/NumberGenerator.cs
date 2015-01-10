using System;

namespace CalcTrainer
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random _random;

        public NumberGenerator(int seed)
        {
            _random = new Random(seed);
        }

        public double Generate(int preDecimalPlaces, int afterDecimalPlaces)
        {
            var result = 0.0;

            for (var i = (-1)*afterDecimalPlaces; i < preDecimalPlaces; ++i)
            {
                var place = _random.Next(0, 9);
                result += place*Math.Pow(10, i);
            }

            return result;
        }
    }
}
