using System.Text;

namespace ExpressionEvaluator
{
    public static class StringBuilderExtensions
    {
        public static bool StartsWith(this StringBuilder stringBuilder, string search)
        {
            if (string.IsNullOrWhiteSpace(search)) return false;
            if (search.Length > stringBuilder.Length) return false;

            for (var i = 0; i < search.Length; ++i)
            {
                if (stringBuilder[i] != search[i]) return false;
            }

            return true;
        }

        public static bool EndsWith(this StringBuilder stringBuilder, string search)
        {
            if (string.IsNullOrWhiteSpace(search)) return false;
            if (search.Length > stringBuilder.Length) return false;

            for (int i = stringBuilder.Length - 1, j = 0; j < search.Length; --i, ++j)
            {
                if (stringBuilder[i] != search[search.Length - j - 1]) return false;
            }

            return true;
        }
    }
}
