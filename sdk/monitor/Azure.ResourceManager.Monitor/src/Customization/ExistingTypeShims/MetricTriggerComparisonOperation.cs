// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    // The generated comparison enum is intentionally renamed to MetricTriggerComparisonOperator.
    // Keep this legacy enum with stable numeric values because enum numeric values are binary-compatible API.
    /// <summary> The operator that is used to compare the metric data and the threshold. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MetricTriggerComparisonOperation
    {
        /// <summary> Equals. </summary>
        EqualsValue = 0,
        /// <summary> NotEquals. </summary>
        NotEquals = 1,
        /// <summary> GreaterThan. </summary>
        GreaterThan = 2,
        /// <summary> GreaterThanOrEqual. </summary>
        GreaterThanOrEqual = 3,
        /// <summary> LessThan. </summary>
        LessThan = 4,
        /// <summary> LessThanOrEqual. </summary>
        LessThanOrEqual = 5
    }
}
