// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets extra conditions that an anomaly must satisfy to be included in an alert.
    /// </summary>
    public class MetricAnomalyAlertConditions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricAnomalyAlertConditions"/> class.
        /// </summary>
        public MetricAnomalyAlertConditions()
        {
        }

        /// <summary>
        /// Sets fixed upper and/or lower bounds to specify the range in which the data point is allowed to be.
        /// Points out the specified range can be included in an alert.
        /// </summary>
        public MetricBoundaryCondition MetricBoundaryCondition { get; set; }

        /// <summary>
        /// Sets a range of severity levels in which the anomaly must be to be included in an alert.
        /// </summary>
        public SeverityCondition SeverityCondition { get; set; }
    }
}
