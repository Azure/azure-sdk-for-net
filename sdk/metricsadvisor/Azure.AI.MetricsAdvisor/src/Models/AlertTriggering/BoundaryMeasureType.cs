// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Used as part of a <see cref="MetricBoundaryCondition"/>. Specifies which measure should be
    /// used when checking boundaries. Defaults to <see cref="Value"/>.
    /// </summary>
    [CodeGenModel("ValueType")]
    public readonly partial struct BoundaryMeasureType
    {
        /// <summary>
        /// The value of the metric is used as it is.
        /// </summary>
        public static BoundaryMeasureType Value { get; } = new BoundaryMeasureType(ValueValue);

        /// <summary>
        /// The mean of the latest metric values in the time series is used.
        /// </summary>
        public static BoundaryMeasureType Mean { get; } = new BoundaryMeasureType(MeanValue);
    }
}
