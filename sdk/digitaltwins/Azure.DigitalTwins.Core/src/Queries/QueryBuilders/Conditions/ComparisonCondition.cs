// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            var conditionString = new StringBuilder();
            conditionString.Append($"{Field} {QueryConstants.ComparisonOperators[Operator]} ");

            // check to see if the input is numeric value -- if not, we need single quotes around Value
            bool isNumeric = int.TryParse(Value, out int numericValue);

            if (!isNumeric)
            {
                // surround with single quotes
                Value = "'" + Value + "'";
            }

            conditionString.Append(Value);

            return conditionString.ToString();
        }

        /// <summary>
        /// The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked.
        /// </summary>
        public QueryComparisonOperator Operator { private get; set; }
    }
}
