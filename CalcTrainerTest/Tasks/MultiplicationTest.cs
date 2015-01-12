using CalcTrainer;
using CalcTrainer.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalcTrainerTest.Tasks
{
    [TestClass]
    public class MultiplicationTest
    {
        private Multiplication _task;
        private Mock<INumberGenerator> _numberGenerator;
        private Mock<IOutput> _output;
        private Mock<IInput> _input;

        [TestInitialize]
        public void SetUp()
        {
            _numberGenerator = new Mock<INumberGenerator>();
            _output = new Mock<IOutput>();
            _input = new Mock<IInput>();
            _numberGenerator.Setup(x => x.Generate(2, 0)).Returns(2);
            _numberGenerator.Setup(x => x.Generate(1, 0)).Returns(3);
            _task = new Multiplication(_numberGenerator.Object, _input.Object, _output.Object);
        }

        [TestMethod]
        public void Constructor_ZeroForValueOne_ValueOneNotZero()
        {
            var counter = -1;
            _numberGenerator.Setup(x => x.Generate(1, 0)).Returns(3);
            _numberGenerator.Setup(x => x.Generate(2, 0)).Returns(() => counter += 1);

            _task = new Multiplication(_numberGenerator.Object, _input.Object, _output.Object);

            Assert.IsTrue(_task.ValueOne != 0);
        }

        [TestMethod]
        public void Constructor_OneForValueOne_ValueOneNotOne()
        {
            var counter = 0;
            _numberGenerator.Setup(x => x.Generate(1, 0)).Returns(3);
            _numberGenerator.Setup(x => x.Generate(2, 0)).Returns(() => counter += 1);

            _task = new Multiplication(_numberGenerator.Object, _input.Object, _output.Object);

            Assert.IsTrue(_task.ValueOne != 1);
        }

        [TestMethod]
        public void Constructor_ZeroForValueTwo_ValueTwoNotZero()
        {
            var counter = -1;
            _numberGenerator.Setup(x => x.Generate(2, 0)).Returns(3);
            _numberGenerator.Setup(x => x.Generate(1, 0)).Returns(() => counter += 1);

            _task = new Multiplication(_numberGenerator.Object, _input.Object, _output.Object);

            Assert.IsTrue(_task.ValueTwo != 0);
        }

        [TestMethod]
        public void Constructor_OneForValueTwo_ValueTwoNotOne()
        {
            var counter = 0;
            _numberGenerator.Setup(x => x.Generate(2, 0)).Returns(3);
            _numberGenerator.Setup(x => x.Generate(1, 0)).Returns(() => counter += 1);

            _task = new Multiplication(_numberGenerator.Object, _input.Object, _output.Object);

            Assert.IsTrue(_task.ValueTwo != 1);
        }
    }
}
