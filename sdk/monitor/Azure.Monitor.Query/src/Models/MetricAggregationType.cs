// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Monitor.Query.Models
{
    /// <summary> The aggregation type of the metric. </summary>
    [CodeGenModel("AggregationType")]
    public enum MetricAggregationType
    {
        /// <summary> None. </summary>
        None,
        /// <summary> Average. </summary>
        Average,
        /// <summary> Count. </summary>
        Count,
        /// <summary> Minimum. </summary>
        Minimum,
        /// <summary> Maximum. </summary>
        Maximum,
        /// <summary> Total. </summary>
        Total
    }
}
