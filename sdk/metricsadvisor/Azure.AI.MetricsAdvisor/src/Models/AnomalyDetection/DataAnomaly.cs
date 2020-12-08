// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("AnomalyResult")]
    [CodeGenSuppress(nameof(DataAnomaly), typeof(DateTimeOffset), typeof(IReadOnlyDictionary<string, string>), typeof(AnomalyProperty))]
    [CodeGenSuppress("Property")]
    [CodeGenSuppress("Dimension")]
    public partial class DataAnomaly
    {
        internal DataAnomaly(string metricId, string anomalyDetectionConfigurationId, DateTimeOffset timestamp, DateTimeOffset? createdTime, DateTimeOffset? modifiedTime, IReadOnlyDictionary<string, string> dimension, AnomalyProperty property)
        {
            MetricId = metricId;
            AnomalyDetectionConfigurationId = anomalyDetectionConfigurationId;
            Timestamp = timestamp;
            CreatedTime = createdTime;
            ModifiedTime = modifiedTime;
            SeriesKey = new DimensionKey(dimension);
            Severity = property.AnomalySeverity;
            AnomalyStatus = property.AnomalyStatus;
        }

        /// <summary>
        /// </summary>
        public string AnomalyDetectionConfigurationId { get; }

        /// <summary>
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// </summary>
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// </summary>
        public AnomalySeverity Severity { get; }

        /// <summary>
        /// </summary>
        public AnomalyStatus? AnomalyStatus { get; }
    }
}
