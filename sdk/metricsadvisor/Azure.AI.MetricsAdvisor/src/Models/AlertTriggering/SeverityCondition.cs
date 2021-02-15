// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Sets a range of severity levels in which an anomaly must be to be able to trigger alerts.
    /// </summary>
    public partial class SeverityCondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeverityCondition"/> class.
        /// </summary>
        /// <param name="minimumAlertSeverity">The minimum severity an anomaly must have to trigger alerts.</param>
        /// <param name="maximumAlertSeverity">The maximum severity an anomaly must have to trigger alerts.</param>
        public SeverityCondition(AnomalySeverity minimumAlertSeverity, AnomalySeverity maximumAlertSeverity)
        {
            MinimumAlertSeverity = minimumAlertSeverity;
            MaximumAlertSeverity = maximumAlertSeverity;
        }

        /// <summary>
        /// The minimum severity an anomaly must have to be able to trigger alerts.
        /// </summary>
        [CodeGenMember("MinAlertSeverity")]
        public AnomalySeverity MinimumAlertSeverity { get; set; }

        /// <summary>
        /// The maximum severity an anomaly must have to be able to trigger alerts.
        /// </summary>
        [CodeGenMember("MaxAlertSeverity")]
        public AnomalySeverity MaximumAlertSeverity { get; set; }
    }
}
