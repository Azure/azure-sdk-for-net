// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The current status of the issue that caused a <see cref="DataPointAnomaly"/>.
    /// </summary>
    [CodeGenModel("AnomalyPropertyAnomalyStatus")]
    public readonly partial struct AnomalyStatus
    {
        /// <summary>
        /// The issue that caused the anomaly is still active.
        /// </summary>
        public static AnomalyStatus Active { get; } = new AnomalyStatus(ActiveValue);

        /// <summary>
        /// The issue that caused the anomaly has been resolved.
        /// </summary>
        public static AnomalyStatus Resolved { get; } = new AnomalyStatus(ResolvedValue);
    }
}
