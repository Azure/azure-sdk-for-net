// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The AnomalyAlertingConfigurationPatch. </summary>
    internal partial class AnomalyAlertingConfigurationPatch
    {
        /// <summary> hook unique ids. </summary>
        public IList<Guid> HookIds { get; internal set; }

        /// <summary> Anomaly alerting configurations. </summary>
        public IList<MetricAnomalyAlertConfiguration> MetricAlertingConfigurations { get; internal set; }
    }
}
