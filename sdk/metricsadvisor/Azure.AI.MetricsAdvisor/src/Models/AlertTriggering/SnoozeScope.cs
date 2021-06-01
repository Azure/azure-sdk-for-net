// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines the set of time series to which a <see cref="MetricAnomalyAlertSnoozeCondition"/>
    /// applies.
    /// </summary>
    public readonly partial struct SnoozeScope
    {
        /// <summary>
        /// The snooze will apply to all time series within the metric that generated the
        /// current alert.
        /// </summary>
        public static SnoozeScope Metric { get; } = new SnoozeScope(MetricValue);

        /// <summary>
        /// The snooze will only apply to the time series that generated the current alert.
        /// </summary>
        public static SnoozeScope Series { get; } = new SnoozeScope(SeriesValue);
    }
}
