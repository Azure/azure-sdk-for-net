// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// A suggestion for likely cause of an incident.
    /// </summary>
    [CodeGenModel("RootCause")]
    public partial class IncidentRootCause
    {
        /// <summary>
        /// The key that, within a metric, uniquely identifies the time series in which this <see cref="IncidentRootCause"/> has been created.
        /// </summary>
        [CodeGenMember("RootCause")]
        public DimensionKey DimensionKey { get; }

        /// <summary>
        /// The drill down path from query anomaly to root cause.
        /// </summary>
        [CodeGenMember("Path")]
        public IReadOnlyList<string> Paths { get; }

        /// <summary>
        /// The score assigned to the root cause suggestion.
        /// </summary>
        public double Score { get; }

        /// <summary>
        /// The description of the root cause suggestion.
        /// </summary>
        public string Description { get; }
    }
}
