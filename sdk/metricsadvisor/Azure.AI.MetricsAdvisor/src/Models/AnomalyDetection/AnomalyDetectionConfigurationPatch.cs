// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class AnomalyDetectionConfigurationPatch
    {
        /// <summary> detection configuration for series group. </summary>
        public IList<MetricSeriesGroupAnomalyDetectionConditions> DimensionGroupOverrideConfigurations { get; internal set; }

        /// <summary> detection configuration for specific series. </summary>
        public IList<MetricSingleSeriesAnomalyDetectionConditions> SeriesOverrideConfigurations { get; internal set; }
    }
}
