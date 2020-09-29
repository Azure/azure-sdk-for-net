// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("MetricAlertingConfiguration")]
    [CodeGenSuppress(nameof(MetricAnomalyAlertConfiguration), typeof(string), typeof(MetricAnomalyAlertScopeType))]
    public partial class MetricAnomalyAlertConfiguration
    {
        /// <summary>
        /// </summary>
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
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string DetectionConfigurationId { get; }

        /// <summary>
        /// </summary>
        public MetricAnomalyAlertScope AlertScope { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("NegationOperation")]
        public bool? UseDetectionResultToFilterAnomalies { get; set; }

        /// <summary>
        /// </summary>
        public MetricAnomalyAlertConditions AlertConditions { get; set; }

        /// <summary>
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
