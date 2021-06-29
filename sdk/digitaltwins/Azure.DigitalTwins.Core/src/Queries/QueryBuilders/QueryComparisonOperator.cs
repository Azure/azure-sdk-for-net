// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/reference-query-operators#comparison-operators">Comparison operators</see> in the ADT Query language.
    /// </summary>
    public enum QueryComparisonOperator
    {
        /// <summary>
        /// Equality operator.
        /// </summary>
        Equal,

        /// <summary>
        /// Inequality operator.
        /// </summary>
        NotEqual,

        /// <summary>
        /// Greater than operator.
        /// </summary>
        GreaterThan,

        /// <summary>
        /// Less than operator.
        /// </summary>
        LessThan,

        /// <summary>
        /// Geater than or equal to operator.
        /// </summary>
        GreaterOrEqual,

        /// <summary>
        /// Less than or equal to operator.
        /// </summary>
        LessOrEqual,
    }
}
