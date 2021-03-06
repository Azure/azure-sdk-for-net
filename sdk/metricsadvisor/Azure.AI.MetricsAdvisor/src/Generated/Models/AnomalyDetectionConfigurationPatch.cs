// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The AnomalyDetectionConfigurationPatch. </summary>
    internal partial class AnomalyDetectionConfigurationPatch
    {
        /// <summary> Initializes a new instance of AnomalyDetectionConfigurationPatch. </summary>
        public AnomalyDetectionConfigurationPatch()
        {
            DimensionGroupOverrideConfigurations = new ChangeTrackingList<MetricSeriesGroupDetectionCondition>();
            SeriesOverrideConfigurations = new ChangeTrackingList<MetricSingleSeriesDetectionCondition>();
        }

        /// <summary> anomaly detection configuration name. </summary>
        public string Name { get; set; }
        /// <summary> anomaly detection configuration description. </summary>
        public string Description { get; set; }
        public WholeMetricConfigurationPatch WholeMetricConfiguration { get; set; }
    }
}
