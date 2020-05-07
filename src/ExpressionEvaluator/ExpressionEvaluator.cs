﻿using System;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluator
    {
        public static object Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return null;

            // https://stackoverflow.com/a/25313985/4856020
            var table = new System.Data.DataTable();
            return table.Compute(expression, string.Empty);
        }

        public static T Evaluate<T>(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return default(T);

            // https://stackoverflow.com/a/6884667/4856020
            return (T)Convert.ChangeType(Evaluate(expression), typeof(T));
        }
    }
}
