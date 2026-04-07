// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The current status of a detected <see cref="AnomalyIncident"/>.
    /// </summary>
    [CodeGenModel("IncidentStatus")]
    public readonly partial struct AnomalyIncidentStatus
    {
        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> is still active.
        /// </summary>
        public static AnomalyIncidentStatus Active { get; } = new AnomalyIncidentStatus(ActiveValue);

        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> has been resolved.
        /// </summary>
        public static AnomalyIncidentStatus Resolved { get; } = new AnomalyIncidentStatus(ResolvedValue);
    }
}
