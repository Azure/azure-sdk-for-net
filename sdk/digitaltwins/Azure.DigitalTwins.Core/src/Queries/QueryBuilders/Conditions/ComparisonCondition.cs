// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Condition specifically for comparisons using the SQL-like comparison operators.
    /// </summary>
    internal class ComparisonCondition<T> : ConditionBase
    {
        /// <summary>
        /// The field that we're checking against a certain value.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The value we're checking against a field.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Constructor for a comparison condition.
        /// </summary>
        /// <param name="field"> The field being checked against a certain value. </param>
        /// <param name="comparisonOperator"> The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked. </param>
        /// <param name="value"> The value being checked against a field. Valid types are string, int, long, float or double.</param>
        public ComparisonCondition(string field, QueryComparisonOperator comparisonOperator, T value)
        {
            Field = field;
            Operator = comparisonOperator;
            Value = value;
        }

        public override string Stringify()
        {
            var conditionString = new StringBuilder();
            conditionString.Append($"{Field} {QueryConstants.ComparisonOperators[Operator]} ");

            // check to see if the input is numeric value -- if not, we need single quotes around Value
            if (typeof(T) == typeof(string))
            {
                // if string, surround value with single quotes to denote string type in SQL
                conditionString.Append($"'{Value}'");
            }
            else if (typeof(T) == typeof(int) || typeof(T) == typeof(long) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
            {
                // if int, long, float, our double, insert raw value into query string (nothing needs to be done)
                conditionString.Append(Value);
            }
            else
            {
                throw new InvalidOperationException("Invalid condition: use a string, integer, long, float, or double.");
            }

            return conditionString.ToString();
        }

        /// <summary>
        /// The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked.
        /// </summary>
        public QueryComparisonOperator Operator { private get; set; }
    }
}
