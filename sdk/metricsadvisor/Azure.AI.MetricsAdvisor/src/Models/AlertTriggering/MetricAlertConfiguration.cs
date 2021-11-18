// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Specifies a set of rules a detected anomaly must satisfy to be included in an alert.
    /// </summary>
    [CodeGenModel("MetricAlertingConfiguration")]
    [CodeGenSuppress(nameof(MetricAlertConfiguration), typeof(string), typeof(MetricAnomalyAlertScopeType))]
    public partial class MetricAlertConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricAlertConfiguration"/> class.
        /// </summary>
        /// <param name="detectionConfigurationId">
        /// The identifier of the <see cref="AnomalyDetectionConfiguration"/> to which this configuration applies. An anomaly
        /// can only be included in an alert if it was detected by this configuration.
        /// </param>
        /// <param name="alertScope">Selects the scope of time series in which an anomaly must be to be included in an alert.</param>
        /// <exception cref="ArgumentNullException"><paramref name="detectionConfigurationId"/> or <paramref name="alertScope"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="detectionConfigurationId"/> is empty.</exception>
        public MetricAlertConfiguration(string detectionConfigurationId, MetricAnomalyAlertScope alertScope)
        {
            Argument.AssertNotNullOrEmpty(detectionConfigurationId, nameof(detectionConfigurationId));
            Argument.AssertNotNull(alertScope, nameof(alertScope));

            DetectionConfigurationId = detectionConfigurationId;
            AlertScope = alertScope;
        }

        internal MetricAlertConfiguration(string detectionConfigurationId, MetricAnomalyAlertScopeType anomalyScopeType, bool? useDetectionResultToFilterAnomalies, DimensionKey dimensionAnomalyScope, TopNGroupScope topNAnomalyScope, SeverityCondition severityFilter, MetricAnomalyAlertSnoozeCondition alertSnoozeCondition, MetricBoundaryCondition valueFilter)
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
        /// The identifier of the <see cref="AnomalyDetectionConfiguration"/> to which this configuration applies.
        /// An anomaly can only be included in an alert if it was detected by this configuration.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; set; }

        /// <summary>
        /// Selects the scope of time series in which an anomaly must be to be included in an alert.
        /// </summary>
        public MetricAnomalyAlertScope AlertScope { get; set; }

        /// <summary>
        /// If set to <c>true</c>, this <see cref="MetricAlertConfiguration"/> cannot be used to add anomalies
        /// to an alert directly. Instead, it will only be used as a filter to its containing
        /// <see cref="AnomalyAlertConfiguration"/>, filtering out anomalies that shouldn't be added to the alert.
        /// If an anomaly does not satisfy the conditions set by this configuration, it can't be added to the
        /// alert. Defaults to <c>false</c>.
        /// </summary>
        /// <remarks>
        /// Be aware that, if you set this property to <c>true</c> and have no other configurations in
        /// <see cref="AnomalyAlertConfiguration.MetricAlertConfigurations"/>, alerts will never be triggered.
        /// </remarks>
        [CodeGenMember("NegationOperation")]
        public bool? UseDetectionResultToFilterAnomalies { get; set; }

        /// <summary>
        /// Sets extra conditions that an anomaly must satisfy to be included in an alert.
        /// </summary>
        public MetricAnomalyAlertConditions AlertConditions { get; set; }

        /// <summary>
        /// Used to avoid alert spamming. After an anomaly is added to an alert, temporarily prevents new anomalies to
        /// be alerted for a specified period.
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
