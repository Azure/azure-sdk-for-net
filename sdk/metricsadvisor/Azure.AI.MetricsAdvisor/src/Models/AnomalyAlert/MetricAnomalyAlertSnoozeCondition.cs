// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("AlertSnoozeCondition")]
    public partial class MetricAnomalyAlertSnoozeCondition
    {
        /// <summary>
        /// </summary>
        public SnoozeScope SnoozeScope { get; }

        /// <summary>
        /// </summary>
        public int AutoSnooze { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("OnlyForSuccessive")]
        public bool IsOnlyForSuccessive { get; }
    }
}
