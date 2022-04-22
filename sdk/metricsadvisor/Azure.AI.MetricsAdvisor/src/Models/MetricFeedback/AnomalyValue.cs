// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Used by <see cref="MetricAnomalyFeedback"/> to indicate whether or not a set of data points should
    /// have been labeled as anomalies by the service.
    /// </summary>
    public readonly partial struct AnomalyValue
    {
        /// <summary>
        /// Tells the service to disregard any previous anomaly feedback given to the set of data
        /// points affected.
        /// </summary>
        public static AnomalyValue AutoDetect { get; } = new AnomalyValue(AutoDetectValue);

        /// <summary>
        /// The data points should have been labeled as anomalies.
        /// </summary>
        public static AnomalyValue Anomaly { get; } = new AnomalyValue(AnomalyValue1);

        /// <summary>
        /// The data points should not have been labeled as anomalies.
        /// </summary>
        public static AnomalyValue NotAnomaly { get; } = new AnomalyValue(NotAnomalyValue);
    }
}
