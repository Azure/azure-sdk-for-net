// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The severity of a detected <see cref="AnomalyIncident"/>, as evaluated by the service. Factors
    /// such as the proportion of anomalies in a metric, the confidence of anomalies, and specified
    /// favorite settings are taken into account.
    /// </summary>
    [CodeGenModel("Severity")]
    public readonly partial struct AnomalySeverity
    {
        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> has a low severity.
        /// </summary>
        public static AnomalySeverity Low { get; } = new AnomalySeverity(LowValue);

        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> has a medium severity.
        /// </summary>
        public static AnomalySeverity Medium { get; } = new AnomalySeverity(MediumValue);

        /// <summary>
        /// The detected <see cref="AnomalyIncident"/> has a high severity.
        /// </summary>
        public static AnomalySeverity High { get; } = new AnomalySeverity(HighValue);
    }
}
