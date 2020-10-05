// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The severity of a detected anomaly, as evaluated by the service.
    /// </summary>
    [CodeGenModel("Severity")]
    public readonly partial struct AnomalySeverity
    {
        /// <summary>
        /// The detected anomaly has a low severity.
        /// </summary>
        public static AnomalySeverity Low { get; } = new AnomalySeverity(LowValue);

        /// <summary>
        /// The detected anomaly has a medium severity.
        /// </summary>
        public static AnomalySeverity Medium { get; } = new AnomalySeverity(MediumValue);

        /// <summary>
        /// The detected anomaly has a high severity.
        /// </summary>
        public static AnomalySeverity High { get; } = new AnomalySeverity(HighValue);
    }
}
