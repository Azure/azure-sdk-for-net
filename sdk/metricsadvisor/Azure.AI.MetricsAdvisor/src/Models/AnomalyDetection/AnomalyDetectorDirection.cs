// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets the boundaries that delimit the expected value range of an anomaly detection condition. Data points out
    /// of this range are considered anomalous.
    /// </summary>
    public readonly partial struct AnomalyDetectorDirection
    {
        /// <summary>
        /// Any values out of the expected value range will be considered anomalies.
        /// </summary>
        public static AnomalyDetectorDirection Both { get; } = new AnomalyDetectorDirection(BothValue);

        /// <summary>
        /// Only values below the expected value range will be considered anomalies.
        /// </summary>
        public static AnomalyDetectorDirection Down { get; } = new AnomalyDetectorDirection(DownValue);

        /// <summary>
        /// Only values above the expected value range will be considered anomalies.
        /// </summary>
        public static AnomalyDetectorDirection Up { get; } = new AnomalyDetectorDirection(UpValue);
    }
}
