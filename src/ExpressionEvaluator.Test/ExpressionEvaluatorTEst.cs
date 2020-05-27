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

        [TestCase("1 && 0", true, " true  and false ")]
        [TestCase("1 && 0", false, "true and false")]
        [TestCase("1 && 0 || 1", true, " true  and false  or true ")]
        [TestCase("1 && 0 || 1", false, "true and false or true")]
        [TestCase("0 && !1", true, " false  and not true ")]
        [TestCase("0 && !1", false, "false and not true")]
        [TestCase("(!0 && 1) || 1", true, "( not false  and true ) or true ")]
        [TestCase("(!0 && 1) || 1", false, "( not false and true ) or true")]
        [TestCase("!0", false, "not false")]
        [TestCase(" !0", false, "not false")]
        [TestCase("!0 ", false, "not false")]
        [TestCase("(!0)", false, "( not false )")]
        public void ReplaceOperators(string expression, bool allowExtraSpaces, string expectedResult)
        {
            ExpressionEvaluator.SetOperatorMap(new Dictionary<string, string>
            {
                {"and", "&&"},
                {"or", "||"},
                {"not", "!" },
                {"<>", "!=" },
                {"true", "1" },
                {"false", "0" }
            });
            
            Assert.AreEqual(expectedResult, 
                ExpressionEvaluator.ReplaceOperators(expression, allowExtraSpaces));
        }

        [TestCase("1 && 0", false)]
        [TestCase("1 && 0 || 1", true)]
        [TestCase("0 && !1", false)]
        [TestCase("(!0 && 1) || 1", true)]
        public void SetOperatorMap_Evaluate_Bool(string expression, bool expectedResult)
        {
            ExpressionEvaluator.SetOperatorMap(new Dictionary<string, string>
            {
                {"and", "&&"},
                {"or", "||"},
                {"not", "!" },
                {"<>", "!=" },
                {"true", "1" },
                {"false", "0" }
            });

            Assert.AreEqual(expectedResult,
                ExpressionEvaluator.Evaluate<bool>(expression));
        }

        [TestCase("(1 plus 2) times 2", 6)]
        [TestCase("7 divideBy 2", 4)]
        public void SetOperatorMap_Evaluate_Int(string expression, int expectedResult)
        {
            ExpressionEvaluator.SetOperatorMap(new Dictionary<string, string>
            {
                {"+", "plus"},
                {"*", "times"},
                {"/", "divideBy"},
            });

            Assert.AreEqual(expectedResult,
                ExpressionEvaluator.Evaluate<int>(expression));
        }
    }
}
