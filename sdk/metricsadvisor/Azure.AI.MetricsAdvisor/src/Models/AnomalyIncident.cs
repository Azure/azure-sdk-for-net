// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("IncidentResult")]
    [CodeGenSuppress(nameof(AnomalyIncident), typeof(string), typeof(DateTimeOffset), typeof(DateTimeOffset), typeof(SeriesIdentity), typeof(IncidentProperty))]
    [CodeGenSuppress("RootNode")]
    [CodeGenSuppress("Property")]
    public partial class AnomalyIncident
    {
        internal AnomalyIncident(string metricId, string detectionConfigurationId, string id, DateTimeOffset startTime, DateTimeOffset endTime, SeriesIdentity rootNode, IncidentProperty property)
        {
            MetricId = metricId;
            DetectionConfigurationId = detectionConfigurationId;
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            DimensionKey = new DimensionKey(rootNode.Dimension);
            Severity = property.MaxSeverity;
            IncidentStatus = property.IncidentStatus;
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("IncidentId")]
        public string Id { get; }

        /// <summary>
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// </summary>
        public DimensionKey DimensionKey { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("LastTime")]
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// </summary>
        public AnomalySeverity Severity { get; }

        /// <summary>
        /// </summary>
        public IncidentStatus? IncidentStatus { get; }
    }
}
