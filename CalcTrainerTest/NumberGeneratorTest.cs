using CalcTrainer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTrainerTest
{
    [TestClass]
    public class NumberGeneratorTest
    {
        private NumberGenerator _numberGenerator;

        [TestInitialize]
        public void SetUp()
        {
            _numberGenerator = new NumberGenerator(5);
        }

        [TestMethod]
        public void Generate_ValidRange()
        {
            var result = _numberGenerator.Generate(3, 2);

            Assert.IsTrue(result < 1e3);
            Assert.IsTrue(result >= 0);
        }

        [TestMethod]
        public void Generate_3And0()
        {
            var result = _numberGenerator.Generate(3, 0);

            Assert.AreEqual(223, result, 1e-10);
        }

        [TestMethod]
        public void Generate_0And1()
        {
            var result = _numberGenerator.Generate(0, 1);

            Assert.AreEqual(0.3, result, 1e-10);
        }
    }
}
