using System;
using CalcTrainer;
using CalcTrainer.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalcTrainerTest.Tasks
{
    [TestClass]
    public class DivisionTest
    {
        private Division _task;
        private Mock<INumberGenerator> _numberGenerator;
        private Mock<IOutput> _output;
        private Mock<IInput> _input;

        [TestInitialize]
        public void SetUp()
        {
            _numberGenerator = new Mock<INumberGenerator>();
            _output = new Mock<IOutput>();
            _input = new Mock<IInput>();
            _numberGenerator.Setup(x => x.Generate(1, 1)).Returns(2);
            _numberGenerator.Setup(x => x.Generate(1, 0)).Returns(3);
            _task = new Division(_numberGenerator.Object, _input.Object, _output.Object, 1);
        }

        [TestMethod]
        public void Constructor_Empty_CorrectValues()
        {
            Assert.AreEqual(2, _task.Quotient);
            Assert.AreEqual(3, _task.Divisor);
            Assert.AreEqual(6, _task.Dividend);
        }

        [TestMethod]
        public void Execute_CorrectInput_True()
        {
            _input.Setup(x => x.ReadNumber()).Returns(2);

            Assert.IsTrue(_task.Execute());
        }

        [TestMethod]
        public void Execute_WrongInput_False()
        {
            _input.Setup(x => x.ReadNumber()).Returns(8);

            Assert.IsFalse(_task.Execute());
        }
    }
}
