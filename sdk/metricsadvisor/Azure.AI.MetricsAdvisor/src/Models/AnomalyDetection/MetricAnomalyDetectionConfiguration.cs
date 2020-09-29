// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("AnomalyDetectionConfiguration")]
    public partial class MetricAnomalyDetectionConfiguration
    {
        private string _name;

        private MetricAnomalyDetectionConditions _wholeSeriesDetectionConditions;

        private IList<MetricSingleSeriesAnomalyDetectionConditions> _seriesDetectionConditions;

        private IList<MetricSeriesGroupAnomalyDetectionConditions> _seriesGroupDetectionConditions;

        /// <summary>
        /// </summary>
        public MetricAnomalyDetectionConfiguration(string metricId, string name, MetricAnomalyDetectionConditions wholeSeriesDetectionConditions)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(wholeSeriesDetectionConditions, nameof(wholeSeriesDetectionConditions));

            MetricId = metricId;
            Name = name;
            WholeSeriesDetectionConditions = wholeSeriesDetectionConditions;
            SeriesDetectionConditions = new ChangeTrackingList<MetricSingleSeriesAnomalyDetectionConditions>();
            SeriesGroupDetectionConditions = new ChangeTrackingList<MetricSeriesGroupAnomalyDetectionConditions>();
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string Id { get; internal set; }

        /// <summary>
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                Argument.AssertNotNullOrEmpty(value, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("WholeMetricConfiguration")]
        public MetricAnomalyDetectionConditions WholeSeriesDetectionConditions
        {
            get => _wholeSeriesDetectionConditions;
            private set
            {
                Argument.AssertNotNull(value, nameof(WholeSeriesDetectionConditions));
                _wholeSeriesDetectionConditions = value;
            }
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("SeriesOverrideConfigurations")]
        public IList<MetricSingleSeriesAnomalyDetectionConditions> SeriesDetectionConditions
        {
            get => _seriesDetectionConditions;
            set
            {
                Argument.AssertNotNull(value, nameof(SeriesDetectionConditions));
                _seriesDetectionConditions = value;
            }
        }

        /// <summary>
        /// </summary>
        [CodeGenMember("DimensionGroupOverrideConfigurations")]
        public IList<MetricSeriesGroupAnomalyDetectionConditions> SeriesGroupDetectionConditions
        {
            get => _seriesGroupDetectionConditions;
            set
            {
                Argument.AssertNotNull(value, nameof(SeriesGroupDetectionConditions));
                _seriesGroupDetectionConditions = value;
            }
        }
    }
}
