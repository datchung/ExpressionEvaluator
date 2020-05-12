using NUnit.Framework;
using System.Text;

namespace ExpressionEvaluator.Test
{
    [TestFixture]
    public class StringBuilderExtensionsTest
    {
        [TestCase("test string", "a", false)]
        [TestCase("test string", "test", true)]
        [TestCase("test", "tests", false)]
        [TestCase("test", "", false)]
        [TestCase("test", null, false)]
        public void StartsWith(string stringBuider, string search, bool expectedResult)
        {
            var sb = new StringBuilder(stringBuider);
            Assert.AreEqual(expectedResult, sb.StartsWith(search));
        }
    }
}
