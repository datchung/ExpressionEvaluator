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

        public static string ReplaceOperators(string expression, bool allowExtraSpaces = true)
        {
            if (OperatorMap == null || OperatorMap.Count == 0) return expression;

            var replacedExpression = expression;
            foreach (var operatorPair in OperatorMap)
            {
                var search = IsOperator(operatorPair.Key) ? 
                    GetOperatorSearch(operatorPair.Value) :
                    GetNonOperatorSearch(operatorPair.Value);

                replacedExpression = Regex.Replace(
                    replacedExpression,
                    search, $" {operatorPair.Key} ",
                    RegexOptions.IgnoreCase);
            }

            return allowExtraSpaces ? replacedExpression : Regex.Replace(replacedExpression.Trim(), "[ ]{2,}", " ", RegexOptions.None);
        }

        public static bool IsOperator(string operatorString)
        {
            if (string.IsNullOrWhiteSpace(operatorString)) return false;

            var notOperators = new[] { "not", "true", "false" };
            operatorString = operatorString.ToLower();
            foreach (var notOperator in notOperators)
            {
                if (operatorString == notOperator) return false;
            }

            return true;
        }

        /// <summary>
        /// Operators should begin with space and end with space.
        /// Eg.
        /// a and b
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetOperatorSearch(string o)
        {
            return "\\s(" + Regex.Escape(o) + ")\\s";
        }

        /// <summary>
        /// Operators may begin with space, may end with space, or both, or none.
        /// May also begin with an open bracket followed by no, one, or multiple spaces.
        /// Eg.
        ///  !a
        /// ! a
        ///  ! a
        /// !a
        /// (!a
        /// ( !a
        /// (  !a
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string GetNonOperatorSearch(string o)
        {
            var escaped = Regex.Escape(o);
            return $"\\s({escaped})|({escaped})\\s|\\s({escaped})\\s|(?<=[(])({escaped})";
        }
    }
}
