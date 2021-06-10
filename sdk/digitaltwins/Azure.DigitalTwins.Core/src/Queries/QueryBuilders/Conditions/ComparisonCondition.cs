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
        /// The comparison operator being invoked.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// The value we're checking against a Field. E.g., in the above example, 5 is the value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Constructor for a comparison condition.
        /// </summary>
        /// <param name="field"> The field that we're checking against a certain value. </param>
        /// <param name="operator"> The comparison operator being invoked. </param>
        /// <param name="value"> The value we're checking against a Field. e.g., in the above example, 5 is the value. </param>
        public ComparisonCondition(string field, string @operator, string value)
        {
            Field = field;
            Operator = @operator;
            Value = value;
        }
    }
}
