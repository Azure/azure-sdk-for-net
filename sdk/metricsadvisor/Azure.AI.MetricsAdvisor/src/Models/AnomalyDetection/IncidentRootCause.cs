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
        /// The key that, within a metric, uniquely identifies the time series that has been detected as an
        /// <see cref="IncidentRootCause"/>. In this key, a value is assigned to every possible dimension.
        /// </summary>
        [CodeGenMember("RootCause")]
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// The drill down path from query anomaly to root cause.
        /// </summary>
        [CodeGenMember("Path")]
        public IReadOnlyList<string> Paths { get; }

        /// <summary>
        /// The score assigned to the root cause suggestion.
        /// </summary>
        [CodeGenMember("Score")]
        public double ContributionScore { get; }

        /// <summary>
        /// The description of the root cause suggestion.
        /// </summary>
        public string Description { get; }
    }
}
