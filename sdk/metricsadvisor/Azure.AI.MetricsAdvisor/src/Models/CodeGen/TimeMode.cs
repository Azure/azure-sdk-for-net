// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Specifies which time property of an <see cref="AlertResult"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetAlerts"/> and the <see cref="MetricsAdvisorClient.GetAlertsAsync"/>
    /// operations.
    /// </summary>
    public readonly partial struct TimeMode
    {
        /// <summary>
        /// Filters alerts by <see cref="AlertResult.Timestamp"/>.
        /// </summary>
        public static TimeMode AnomalyTime { get; } = new TimeMode(AnomalyTimeValue);

        /// <summary>
        /// Filters alerts by <see cref="AlertResult.CreatedTime"/>.
        /// </summary>
        public static TimeMode CreatedTime { get; } = new TimeMode(CreatedTimeValue);

        /// <summary>
        /// Filters alerts by <see cref="AlertResult.ModifiedTime"/>.
        /// </summary>
        public static TimeMode ModifiedTime { get; } = new TimeMode(ModifiedTimeValue);
    }
}
