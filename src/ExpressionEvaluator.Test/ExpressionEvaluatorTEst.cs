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
    }
}
