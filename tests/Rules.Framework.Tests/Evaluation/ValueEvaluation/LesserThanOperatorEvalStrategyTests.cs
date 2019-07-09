namespace Rules.Framework.Tests.Evaluation.ValueEvaluation
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rules.Framework.Evaluation.ValueEvaluation;

    [TestClass]
    public class LesserThanOperatorEvalStrategyTests
    {
        [TestMethod]
        public void LesserThanOperatorEvalStrategy_Eval_GivenAsIntegers0And1_ReturnsTrue()
        {
            // Assert
            int expectedLeftOperand = 0;
            int expectedRightOperand = 1;

            LesserThanOperatorEvalStrategy sut = new LesserThanOperatorEvalStrategy();

            // Act
            bool actual = sut.Eval(expectedLeftOperand, expectedRightOperand);

            // Arrange
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void LesserThanOperatorEvalStrategy_Eval_GivenAsIntegers1And1_ReturnsFalse()
        {
            // Assert
            int expectedLeftOperand = 1;
            int expectedRightOperand = 1;

            LesserThanOperatorEvalStrategy sut = new LesserThanOperatorEvalStrategy();

            // Act
            bool actual = sut.Eval(expectedLeftOperand, expectedRightOperand);

            // Arrange
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void LesserThanOperatorEvalStrategy_Eval_GivenAsIntegers2And1_ReturnsFalse()
        {
            // Assert
            int expectedLeftOperand = 2;
            int expectedRightOperand = 1;

            LesserThanOperatorEvalStrategy sut = new LesserThanOperatorEvalStrategy();

            // Act
            bool actual = sut.Eval(expectedLeftOperand, expectedRightOperand);

            // Arrange
            Assert.IsFalse(actual);
        }
    }
}