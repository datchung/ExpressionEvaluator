using System;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluator
    {
        public static object Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return null;

            // Inspired by https://stackoverflow.com/a/25313985/4856020
            var table = new System.Data.DataTable();
            return table.Compute(expression, string.Empty);
        }
    }
}
