using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ExpressionEvaluator
{
    public static class ExpressionEvaluator
    {
        /// <summary>
        /// Key = default operator
        /// Value = replaced operator
        /// 
        /// Example: Key = "And", Value = "&&"
        /// </summary>
        private static Dictionary<string, string> OperatorMap = new Dictionary<string, string>();

        public static object Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return null;

            expression = ReplaceOperators(expression);

            // https://stackoverflow.com/a/25313985/4856020
            var table = new System.Data.DataTable();
            return table.Compute(expression, string.Empty);
        }

        public static T Evaluate<T>(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression)) return default;

            // https://stackoverflow.com/a/6884667/4856020
            return (T)Convert.ChangeType(Evaluate(expression), typeof(T));
        }

        public static void SetOperatorMap(Dictionary<string, string> operatorMap)
        {
            OperatorMap = operatorMap;
        }

        private static string ReplaceOperators(string expression)
        {
            if (OperatorMap == null || OperatorMap.Count == 0) return expression;

            var replacedExpression = new StringBuilder(expression);
            foreach(var operatorPair in OperatorMap)
            {
                replacedExpression.Replace($" {operatorPair.Value} ", $" {operatorPair.Key} ");

                // Handle first operator
                //if (replacedExpression.($"{operatorPair.Value} "))
                //    replacedExpression.ReplaceFirst($"{operatorPair.Value} ", $"{operatorPair.Key} ");

                //// Handle last operator
                //if (replacedExpression.EndsWith($" {operatorPair.Value}"))
                //    replacedExpression = replacedExpression.ReplaceLast($" {operatorPair.Value}", $" {operatorPair.Key}");

                //replacedExpression = Regex.Replace(replacedExpression,
                //     "\\b" + Regex.Escape(operatorPair.Value) + "\\b", operatorPair.Key, RegexOptions.IgnoreCase);
            }

            return replacedExpression.ToString();
        }
    }
}
