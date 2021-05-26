// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The properties of a detected <see cref="DataPointAnomaly"/>. A <see cref="DataPointAnomaly"/> is detected according to
    /// the rules set by a <see cref="AnomalyDetectionConfiguration"/>.
    /// </summary>
    [CodeGenModel("AnomalyResult")]
    [CodeGenSuppress(nameof(DataPointAnomaly), typeof(DateTimeOffset), typeof(IReadOnlyDictionary<string, string>), typeof(AnomalyProperty))]
    [CodeGenSuppress("Property")]
    [CodeGenSuppress("Dimension")]
    public partial class DataPointAnomaly
    {
        internal DataPointAnomaly(Guid? dataFeedId, string metricId, string anomalyDetectionConfigurationId, DateTimeOffset timestamp, DateTimeOffset? createdTime, DateTimeOffset? modifiedTime, IReadOnlyDictionary<string, string> dimension, AnomalyProperty property)
        {
            DataFeedId = dataFeedId;
            MetricId = metricId;
            AnomalyDetectionConfigurationId = anomalyDetectionConfigurationId;
            Timestamp = timestamp;
            CreatedTime = createdTime;
            ModifiedTime = modifiedTime;
            SeriesKey = new DimensionKey(dimension);
            Severity = property.AnomalySeverity;
            Status = property.AnomalyStatus;
            Value = property.Value;
            ExpectedValue = property.ExpectedValue;
        }

        /// <summary>
        /// The unique identifier of the <see cref="AnomalyDetectionConfiguration"/> that detected
        /// this anomaly. This property is only populated when calling <see cref="MetricsAdvisorClient.GetAnomalies(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>
        /// or <see cref="MetricsAdvisorClient.GetAnomaliesAsync(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>.
        /// </summary>
        public string AnomalyDetectionConfigurationId { get; }

        /// <summary>
        /// The unique identifier of the <see cref="DataFeedMetric"/> of the time series in which this
        /// anomaly has been detected. This property is only populated when calling
        /// <see cref="MetricsAdvisorClient.GetAnomalies(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/> or
        /// <see cref="MetricsAdvisorClient.GetAnomaliesAsync(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// The key that, within a metric, uniquely identifies the time series in which this anomaly has
        /// been detected. Every dimension contained in the associated <see cref="DataFeed"/> has been
        /// assigned a value.
        /// </summary>
        public DimensionKey SeriesKey { get; }

        /// <summary>
        /// The severity of the detected anomaly, as evaluated by the service.
        /// </summary>
        public AnomalySeverity Severity { get; }

        /// <summary>
        /// The status of the issue that caused this <see cref="DataPointAnomaly"/>. This property is only populated
        /// when calling <see cref="MetricsAdvisorClient.GetAnomalies(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/> or
        /// <see cref="MetricsAdvisorClient.GetAnomaliesAsync(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>.
        /// </summary>
        [CodeGenMember("AnomalyStatus")]
        public AnomalyStatus? Status { get; }

        /// <summary>
        /// The timestamp, in UTC, of the data point that generated this anomaly, as described by the
        /// <see cref="DataFeed"/>.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The date and time, in UTC, in which this anomaly entry has been created. This property is only
        /// populated when calling <see cref="MetricsAdvisorClient.GetAnomalies(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/> or
        /// <see cref="MetricsAdvisorClient.GetAnomaliesAsync(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>.
        /// </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary>
        /// The date and time, in UTC, in which this anomaly entry has been modified for the last time. This
        /// property is only populated when calling <see cref="MetricsAdvisorClient.GetAnomalies(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>
        /// or <see cref="MetricsAdvisorClient.GetAnomaliesAsync(string, string, GetAnomaliesForAlertOptions, CancellationToken)"/>.
        /// </summary>
        public DateTimeOffset? ModifiedTime { get; }

        /// <summary>
        /// The value of the data point that generated this anomaly.
        /// </summary>
        public double Value { get; }

        /// <summary>
        /// The expected value of the data point that generated this anomaly, according to the service's
        /// smart detector. <c>null</c> if the quantity of historical points is not enough to make a prediction,
        /// or if this anomaly was not detected by a <see cref="SmartDetectionCondition"/>.
        /// </summary>
        public double? ExpectedValue { get; }

        internal Guid? DataFeedId { get; }
    }
}
