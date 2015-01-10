namespace CalcTrainer
{
    public interface INumberGenerator
    {
        double Generate(int preDecimalPlaces, int afterDecimalPlaces);
    }
}