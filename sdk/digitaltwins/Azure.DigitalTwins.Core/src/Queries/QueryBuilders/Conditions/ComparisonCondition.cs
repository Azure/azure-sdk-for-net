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
        /// The value we're checking against a Field.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructor for a comparison condition.
        /// </summary>
        /// <param name="field"> The field being checked against a certain value. </param>
        /// <param name="comparisonOperator"> The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked. </param>
        /// <param name="value"> The value being checked against a Field. </param>
        public ComparisonCondition(string field, QueryComparisonOperator comparisonOperator, string value)
        {
            Field = field;
            Operator = comparisonOperator;
            Value = value;
        }

        public override string Stringify()
        {
            return $"{Field} {QueryConstants.ComparisonOperators[Operator.ToString()]} {Value}";
        }

        /// <summary>
        /// The ADT <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">comparison operator</see> being invoked.
        /// </summary>
        public QueryComparisonOperator Operator { private get; set; }
    }
}
