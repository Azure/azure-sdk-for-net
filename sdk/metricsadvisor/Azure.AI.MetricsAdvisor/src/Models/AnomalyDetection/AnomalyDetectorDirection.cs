// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The direction of the boundaries specified by an anomaly detection condition or a
    /// <see cref="MetricBoundaryCondition"/>.
    /// </summary>
    public readonly partial struct AnomalyDetectorDirection
    {
        /// <summary>
        /// Used when both lower and upper bounds are applied.
        /// </summary>
        public static AnomalyDetectorDirection Both { get; } = new AnomalyDetectorDirection(BothValue);

        /// <summary>
        /// Used when only a lower bound is applied.
        /// </summary>
        public static AnomalyDetectorDirection Down { get; } = new AnomalyDetectorDirection(DownValue);

        /// <summary>
        /// Used when only an upper bound is applied.
        /// </summary>
        public static AnomalyDetectorDirection Up { get; } = new AnomalyDetectorDirection(UpValue);
    }
}
