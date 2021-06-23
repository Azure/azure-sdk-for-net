// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
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
        internal AnomalyIncident(string dataFeedId, string metricId, string detectionConfigurationId, string id, DateTimeOffset startTime, DateTimeOffset endTime, SeriesIdentity rootNode, IncidentProperty property)
        {
            DataFeedId = dataFeedId;
            MetricId = metricId;
            DetectionConfigurationId = detectionConfigurationId;
            Id = id;
            StartTime = startTime;
            LastTime = endTime;
            RootDimensionKey = new DimensionKey(rootNode.Dimension);
            Severity = property.MaxSeverity;
            Status = property.IncidentStatus;
            ValueOfRootNode = property.ValueOfRootNode;
            ExpectedValueOfRootNode = property.ExpectedValueOfRootNode;
        }

        /// <summary>
        /// The unique identifier of this <see cref="AnomalyIncident"/>.
        /// </summary>
        [CodeGenMember("IncidentId")]
        public string Id { get; }

        /// <summary>
        /// The unique identifier of the <see cref="DataFeed"/> in which this incident was detected. This
        /// property is only populated when calling
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlert(string, string, GetIncidentsForAlertOptions, CancellationToken)"/> or
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlertAsync(string, string, GetIncidentsForAlertOptions, CancellationToken)"/>.
        /// For other overloads, this property will be <c>null</c>.
        /// </summary>
        public string DataFeedId { get; }

        /// <summary>
        /// The unique identifier of the <see cref="AnomalyDetectionConfiguration"/> that detected
        /// this <see cref="AnomalyIncident"/>.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; internal set; }

        /// <summary>
        /// The unique identifier of the <see cref="DataFeedMetric"/> of the time series in which this
        /// <see cref="AnomalyIncident"/> has been detected. This property is only populated when calling
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlert(string, string, GetIncidentsForAlertOptions, CancellationToken)"/> or
        /// <see cref="MetricsAdvisorClient.GetIncidentsForAlertAsync(string, string, GetIncidentsForAlertOptions, CancellationToken)"/>.
        /// For other overloads, this property will be <c>null</c>.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// The key that, within a metric, uniquely identifies the time series in which the data point
        /// at the root of this <see cref="AnomalyIncident"/> has been detected. The root node is defined
        /// as the data point at the root of this incident's root-cause analysis tree. In this key, a value
        /// is assigned to every dimension column contained in the associated <see cref="DataFeed"/>.
        /// </summary>
        public DimensionKey RootDimensionKey { get; }

        /// <summary>
        /// Corresponds to the time, in UTC, when the first associated <see cref="DataPointAnomaly"/> occurred.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Corresponds to the time, in UTC, when the last associated <see cref="DataPointAnomaly"/> occurred.
        /// </summary>
        public DateTimeOffset LastTime { get; }

        /// <summary>
        /// The severity of the detected <see cref="AnomalyIncident"/>, as evaluated by the service.
        /// </summary>
        public AnomalySeverity Severity { get; }

        /// <summary>
        /// The current status of this <see cref="AnomalyIncident"/>.
        /// </summary>
        [CodeGenMember("IncidentStatus")]
        public AnomalyIncidentStatus Status { get; }

        /// <summary>
        /// The value of the data point at the root node of this incident. The root node is defined as
        /// the data point at the root of this incident's root-cause analysis tree.
        /// </summary>
        public double ValueOfRootNode { get; }

        /// <summary>
        /// The expected value of the data point at the root node of this incident, according to the
        /// service's smart detector. The root node is defined as the data point at the root of this
        /// incident's root-cause analysis tree. <c>null</c> if the quantity of historical points is not
        /// enough to make a prediction, or if the anomaly was not detected by a <see cref="SmartDetectionCondition"/>.
        /// </summary>
        public double? ExpectedValueOfRootNode { get; }
    }
}
