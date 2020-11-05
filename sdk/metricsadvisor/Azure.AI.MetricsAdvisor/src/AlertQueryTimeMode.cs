// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Models;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Specifies which time property of an <see cref="AnomalyAlert"/> will be used to filter results
    /// in the <see cref="MetricsAdvisorClient.GetAlerts"/> and the <see cref="MetricsAdvisorClient.GetAlertsAsync"/>
    /// operations.
    /// </summary>
    [CodeGenModel("TimeMode")]
    public readonly partial struct AlertQueryTimeMode
    {
        /// <summary>
        /// Filters alerts by <see cref="AnomalyAlert.Timestamp"/>.
        /// </summary>
        public static AlertQueryTimeMode AnomalyTime { get; } = new AlertQueryTimeMode(AnomalyTimeValue);

        /// <summary>
        /// Filters alerts by <see cref="AnomalyAlert.CreatedTime"/>.
        /// </summary>
        public static AlertQueryTimeMode CreatedTime { get; } = new AlertQueryTimeMode(CreatedTimeValue);

        /// <summary>
        /// Filters alerts by <see cref="AnomalyAlert.ModifiedTime"/>.
        /// </summary>
        public static AlertQueryTimeMode ModifiedTime { get; } = new AlertQueryTimeMode(ModifiedTimeValue);
    }
}
