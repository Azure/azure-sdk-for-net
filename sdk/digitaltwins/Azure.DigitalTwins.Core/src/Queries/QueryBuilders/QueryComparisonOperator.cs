// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

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
        Equal = 1,

        /// <summary>
        /// Inequality operator.
        /// </summary>
        NotEqual = 2,

        /// <summary>
        /// Greater than operator.
        /// </summary>
        GreaterThan = 3,

        /// <summary>
        /// Less than operator.
        /// </summary>
        LessThan = 4,

        /// <summary>
        /// Geater than or equal to operator.
        /// </summary>
        GreaterOrEqual = 5,

        /// <summary>
        /// Less than or equal to operator.
        /// </summary>
        LessOrEqual = 6,
    }
}
