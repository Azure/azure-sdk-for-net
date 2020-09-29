// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class MetricAnomalyAlertConditions
    {
        /// <summary>
        /// </summary>
        public MetricBoundaryCondition MetricBoundaryCondition { get; set; }

        /// <summary>
        /// </summary>
        public SeverityCondition SeverityCondition { get; set; }
    }
}
