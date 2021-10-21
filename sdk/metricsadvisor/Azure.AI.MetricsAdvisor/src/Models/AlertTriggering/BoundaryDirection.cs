// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets the boundaries that delimit the expected value range of a <see cref="MetricBoundaryCondition"/>. Data points out
    /// of this range can be included in an alert.
    /// </summary>
    [CodeGenModel("Direction")]
    public readonly partial struct BoundaryDirection
    {
        /// <summary>
        /// Any values outside of the expected value range can be included in an alert.
        /// </summary>
        public static BoundaryDirection Both { get; } = new BoundaryDirection(BothValue);

        /// <summary>
        /// Only values below the expected value range can be included in an alert.
        /// </summary>
        public static BoundaryDirection Down { get; } = new BoundaryDirection(DownValue);

        /// <summary>
        /// Only values above the expected value range can be included in an alert.
        /// </summary>
        public static BoundaryDirection Up { get; } = new BoundaryDirection(UpValue);
    }
}
