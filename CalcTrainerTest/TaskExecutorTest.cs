using CalcTrainer;
using CalcTrainer.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalcTrainerTest
{
    [TestClass]
    public class TaskExecutorTest
    {
        private TaskExecutor _taskExecutor;
        private Mock<ITaskGenerator> _taskGenerator;
        private Mock<IOutput> _output;
        private Mock<IStopWatch> _stopWatch;
        private Mock<ITask> _task;

        [TestInitialize]
        public void SetUp()
        {
            _taskGenerator = new Mock<ITaskGenerator>();
            _output = new Mock<IOutput>();
            _stopWatch = new Mock<IStopWatch>();
            _taskExecutor = new TaskExecutor(_taskGenerator.Object, _output.Object, _stopWatch.Object);
            _task = new Mock<ITask>();
            _taskGenerator.Setup(x => x.Generate()).Returns(_task.Object);
        }

        [TestMethod]
        public void Run_OnceCalled_StopWatchGotOneCallToRestart()
        {
            _task.Setup(x => x.Execute()).Returns(true);
            _stopWatch.Setup(x => x.TimeUp).Returns(true);
            _taskExecutor.Run();

            _stopWatch.Verify(x => x.Restart(), Times.Once);
        }
    }
}
