// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines which anomalies detected by an <see cref="AnomalyDetectionConfiguration"/> are eligible for
    /// triggering an alert.
    /// </summary>
    [CodeGenModel("MetricAlertingConfiguration")]
    [CodeGenSuppress(nameof(MetricAnomalyAlertConfiguration), typeof(string), typeof(MetricAnomalyAlertScopeType))]
    public partial class MetricAnomalyAlertConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricAnomalyAlertConfiguration"/> class.
        /// </summary>
        /// <param name="detectionConfigurationId">The identifier of the anomaly detection configuration to which this configuration applies.</param>
        /// <param name="alertScope">Selects which set of time series should trigger alerts.</param>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="alertScope"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty.</exception>
        public MetricAnomalyAlertConfiguration(string detectionConfigurationId, MetricAnomalyAlertScope alertScope)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(alertScope, nameof(alertScope));

            DetectionConfigurationId = detectionConfigurationId;
            AlertScope = alertScope;
        }

        internal MetricAnomalyAlertConfiguration(string detectionConfigurationId, MetricAnomalyAlertScopeType anomalyScopeType, bool? useDetectionResultToFilterAnomalies, DimensionKey dimensionAnomalyScope, TopNGroupScope topNAnomalyScope, SeverityCondition severityFilter, MetricAnomalyAlertSnoozeCondition alertSnoozeCondition, MetricBoundaryCondition valueFilter)
        {
            DetectionConfigurationId = detectionConfigurationId;
            AlertScope = new MetricAnomalyAlertScope(anomalyScopeType, dimensionAnomalyScope, topNAnomalyScope);
            UseDetectionResultToFilterAnomalies = useDetectionResultToFilterAnomalies;
            AlertConditions = new MetricAnomalyAlertConditions()
            {
                MetricBoundaryCondition = valueFilter,
                SeverityCondition = severityFilter
            };
            AlertSnoozeCondition = alertSnoozeCondition;
        }

        /// <summary>
        /// The identifier of the anomaly detection configuration to which this configuration applies.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; }

        /// <summary>
        /// Selects which set of time series should trigger alerts.
        /// </summary>
        public MetricAnomalyAlertScope AlertScope { get; }

        /// <summary>
        /// If defined, this <see cref="MetricAnomalyAlertConfiguration"/> won't trigger alerts by itself. It
        /// will only serve as a filter to its containing <see cref="AnomalyAlertConfiguration"/>, specifying
        /// which anomalies can trigger an alert. If <c>true</c>, anomalies need to satisfy the conditions
        /// set by this filter to trigger an alert. If <c>false</c>, anomalies must not satisfy those
        /// conditions.
        /// </summary>
        [CodeGenMember("NegationOperation")]
        public bool? UseDetectionResultToFilterAnomalies { get; set; }

        /// <summary>
        /// Sets extra conditions that a data point must satisfy to trigger alerts.
        /// </summary>
        public MetricAnomalyAlertConditions AlertConditions { get; set; }

        /// <summary>
        /// Stops alerts temporarily once an alert is triggered. Used to avoid alert spamming.
        /// </summary>
        [CodeGenMember("SnoozeFilter")]
        public MetricAnomalyAlertSnoozeCondition AlertSnoozeCondition { get; set; }

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal MetricAnomalyAlertScopeType AnomalyScopeType => AlertScope.ScopeType;

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal DimensionKey DimensionAnomalyScope => AlertScope.SeriesGroupInScope;

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal TopNGroupScope TopNAnomalyScope => AlertScope.TopNGroupInScope;

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal MetricBoundaryCondition ValueFilter => AlertConditions?.MetricBoundaryCondition;

        /// <summary>
        /// Used by CodeGen during serialization.
        /// </summary>
        internal SeverityCondition SeverityFilter => AlertConditions?.SeverityCondition;
    }
}
