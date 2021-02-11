// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets extra conditions that a data point must satisfy to be able to trigger alerts.
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
        /// Sets fixed upper and/or lower bounds to specify the range in which a data point must be
        /// to be able to trigger alerts.
        /// </summary>
        public MetricBoundaryCondition MetricBoundaryCondition { get; set; }

        /// <summary>
        /// Sets a range of severity levels in which an anomaly must be to be able to trigger alerts.
        /// </summary>
        public SeverityCondition SeverityCondition { get; set; }
    }
}
