using NUnit.Framework;
using System.Collections.Generic;

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

        [TestCase("(1 + 2) * 2", 6)]
        [TestCase("7 / 2", 4)]
        public void Evaluate_Int(string expression, int expectedResult)
        {
            Assert.AreEqual(expectedResult, ExpressionEvaluator.Evaluate<int>(expression));
        }

        [TestCase("7 / 2", 3.5)]
        public void Evaluate_Double(string expression, double expectedResult)
        {
            Assert.AreEqual(expectedResult, ExpressionEvaluator.Evaluate<double>(expression));
        }

        [TestCase("true && false", false)]
        public void ReplaceOperators_Bool(string expression, bool expectedResult)
        {
            ExpressionEvaluator.SetOperatorMap(new Dictionary<string, string>
            {
                {"and", "&&"},
                {"or", "||"},
                {"not", "!" },
                {"<>", "!=" }
            });

            Assert.AreEqual(expectedResult, 
                ExpressionEvaluator.Evaluate<bool>(expression));
        }
    }
}
