// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Condition specifically for comparisons using the SQL-like comparison operators.
    /// </summary>
    internal class ComparisonCondition : ConditionBase
    {
        /// <summary>
        /// The field that we're checking against a certain value.
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// The value we're checking against a field.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructor for a comparison condition.
        /// </summary>
        /// <param name="field"> The field being checked against a certain value. </param>
        /// <param name="comparisonOperator"> The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked. </param>
        /// <param name="value"> The value being checked against a field. </param>
        public ComparisonCondition(string field, QueryComparisonOperator comparisonOperator, string value)
        {
            Field = field;
            Operator = comparisonOperator;
            Value = value;
        }

        public override string Stringify()
        {
            // TODO -- generic type on this class to handle different inputs
            var conditionString = new StringBuilder();
            conditionString.Append($"{Field} {QueryConstants.ComparisonOperators[Operator]} ");

            // check to see if the input is numeric value -- if not, we need single quotes around Value
            bool isNumeric;
            bool quoteSurrounded = (Value[0] == '\'' && Value[Value.Length - 1] == '\'');

            // check to see if the user has entered single quotes around the Value
            if (quoteSurrounded)
            {
                isNumeric = int.TryParse(Value.Substring(1, Value.Length - 2), out _);
            }
            else
            {
                isNumeric = int.TryParse(Value, out _);
            }

            if (!isNumeric)
            {
                if (!quoteSurrounded)
                {
                    // surround with single quotes
                    Value = "'" + Value + "'";
                }

                conditionString.Append(Value);
            }
            // if not numeric but surrounded by quotes, it must be a number surrounded by quotes (which must be removed)
            else if (quoteSurrounded)
            {
                conditionString.Append(Value.Substring(1, Value.Length - 2));
            }
            // if numeric and not surround by quotes, we can add as is
            else
            {
                conditionString.Append(Value);
            }

            return conditionString.ToString();
        }

        /// <summary>
        /// The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked.
        /// </summary>
        public QueryComparisonOperator Operator { private get; set; }
    }
}
