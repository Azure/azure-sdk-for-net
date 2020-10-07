﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The properties of a detected <see cref="DataAnomaly"/>. A <see cref="DataAnomaly"/> is detected according to
    /// the rules set by a <see cref="MetricAnomalyDetectionConfiguration"/>.
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
        /// The unique identifier of the <see cref="MetricAnomalyDetectionConfiguration"/> that detected
        /// this anomaly. This property is only populated when calling <see cref="MetricsAdvisorClient.GetAnomaliesForAlert"/>
        /// or <see cref="MetricsAdvisorClient.GetAnomaliesForAlertAsync"/>.
        /// </summary>
        public string AnomalyDetectionConfigurationId { get; }

        /// <summary>
        /// The unique identifier of the <see cref="DataFeedMetric"/> of the time series in which this
        /// anomaly has been detected. This property is only populated when calling
        /// <see cref="MetricsAdvisorClient.GetAnomaliesForAlert"/> or <see cref="MetricsAdvisorClient.GetAnomaliesForAlertAsync"/>.
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

        // TODO: how can the service tell when an anomaly has been resolved? What criteria is used?
        /// <summary>
        /// The status of the issue that caused this <see cref="DataAnomaly"/>. This property is only populated
        /// when calling <see cref="MetricsAdvisorClient.GetAnomaliesForAlert"/> or
        /// <see cref="MetricsAdvisorClient.GetAnomaliesForAlertAsync"/>.
        /// </summary>
        public AnomalyStatus? AnomalyStatus { get; }

        /// <summary>
        /// The timestamp, in UTC, of the data point that generated this anomaly, as described by the
        /// <see cref="DataFeed"/>.
        /// </summary>
        public DateTimeOffset Timestamp { get; }

        /// <summary>
        /// The date and time, in UTC, in which this anomaly entry has been created. This property is only
        /// populated when calling <see cref="MetricsAdvisorClient.GetAnomaliesForAlert"/> or
        /// <see cref="MetricsAdvisorClient.GetAnomaliesForAlertAsync"/>.
        /// </summary>
        public DateTimeOffset? CreatedTime { get; }

        /// <summary>
        /// The date and time, in UTC, in which this anomaly entry has been modified for the last time. This
        /// property is only populated when calling <see cref="MetricsAdvisorClient.GetAnomaliesForAlert"/>
        /// or <see cref="MetricsAdvisorClient.GetAnomaliesForAlertAsync"/>.
        /// </summary>
        public DateTimeOffset? ModifiedTime { get; }
    }
}
