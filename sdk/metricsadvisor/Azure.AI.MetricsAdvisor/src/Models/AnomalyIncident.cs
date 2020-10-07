﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Detected anomalies within the same time series can be grouped into <see cref="AnomalyIncident"/>s. The service
    /// looks for patterns across anomalies to decide which ones should be grouped together.
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
        /// The unique identifier of this <see cref="AnomalyIncident"/>.
        /// </summary>
        [CodeGenMember("IncidentId")]
        public string Id { get; }

        /// <summary>
        /// The unique identifier of the <see cref="MetricAnomalyDetectionConfiguration"/> that detected
        /// this <see cref="AnomalyIncident"/>. This property is only populated when calling
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlert"/> or
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlertAsync"/>.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; }

        /// <summary>
        /// The unique identifier of the <see cref="DataFeedMetric"/> of the time series in which this
        /// <see cref="AnomalyIncident"/> has been detected. This property is only populated when calling
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlert"/> or
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlertAsync"/>.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// The key that, within a metric, uniquely identifies the time series in which this
        /// <see cref="AnomalyIncident"/> has been detected. Every dimension contained in the associated
        /// <see cref="DataFeed"/> has been assigned a value.
        /// </summary>
        public DimensionKey DimensionKey { get; }

        /// <summary>
        /// The date and time, in UTC, in which this <see cref="AnomalyIncident"/> started. Corresponds to
        /// the time when the first associated <see cref="DataAnomaly"/> occurred.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// The date and time, in UTC, in which this <see cref="AnomalyIncident"/> ended. Corresponds to the
        /// time when the last associated <see cref="DataAnomaly"/> occurred.
        /// </summary>
        [CodeGenMember("LastTime")]
        public DateTimeOffset EndTime { get; }

        /// <summary>
        /// The severity of the detected <see cref="AnomalyIncident"/>, as evaluated by the service.
        /// </summary>
        public AnomalySeverity Severity { get; }

        /// <summary>
        /// The current status of this <see cref="AnomalyIncident"/>.
        /// </summary>
        public IncidentStatus? IncidentStatus { get; }
    }
}
