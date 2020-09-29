// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    public partial class SeverityCondition
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("MinAlertSeverity")]
        public AnomalySeverity MinimumAlertSeverity { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("MaxAlertSeverity")]
        public AnomalySeverity MaximumAlertSeverity { get; }
    }
}
