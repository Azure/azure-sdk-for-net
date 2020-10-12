// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The current status of a detected <see cref="AnomalyIncident"/>.
    /// </summary>
    [CodeGenModel("IncidentPropertyIncidentStatus")]
    public readonly partial struct IncidentStatus
    {
        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> is still active.
        /// </summary>
        public static IncidentStatus Active { get; } = new IncidentStatus(ActiveValue);

        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> has been resolved.
        /// </summary>
        public static IncidentStatus Resolved { get; } = new IncidentStatus(ResolvedValue);
    }
}
