using NUnit.Framework;

namespace ExpressionEvaluator.Test
{
    [TestFixture]
    public class ExpressionEvaluatorTest
    {
        [Test]
        public void Evaluate_NullExpression()
        {
            Assert.IsNull(ExpressionEvaluator.Evaluate(null));
        }

        [TestCase("false", false)]
        [TestCase("true", true)]
        [TestCase("True", true)]
        [TestCase("not true", false)]
        [TestCase("false OR true", true)]
        [TestCase("false AND true", false)]
        [TestCase("1 < 2", true)]
        [TestCase("5 = 5", true)]
        [TestCase("5 <> 5", false)]
        public void Evaluate_Bool(string expression, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, ExpressionEvaluator.Evaluate(expression));
        }

        [TestCase("(1 + 2) * 2", 6)]
        public void Evaluate_Numeric(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, ExpressionEvaluator.Evaluate(expression));
        }
    }
}
