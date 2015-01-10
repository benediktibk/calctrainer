using CalcTrainer.Tasks;

namespace CalcTrainer
{
    public interface ITaskGenerator
    {
        ITask Generate();
    }
}