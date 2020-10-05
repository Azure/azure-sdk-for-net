// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines which data points of a metric should be considered an anomaly. A <see cref="MetricAnomalyDetectionConfiguration"/>
    /// can only be applied to a single metric within a data feed, but it can have multiple conditions applied to different time
    /// series within the same metric.
    /// </summary>
    [CodeGenModel("AnomalyDetectionConfiguration")]
    public partial class MetricAnomalyDetectionConfiguration
    {
        private string _name;

        private MetricAnomalyDetectionConditions _wholeSeriesDetectionConditions;

        private IList<MetricSingleSeriesAnomalyDetectionConditions> _seriesDetectionConditions;

        private IList<MetricSeriesGroupAnomalyDetectionConditions> _seriesGroupDetectionConditions;

        /// <summary>
        /// Creates a new instance of the <see cref="MetricAnomalyDetectionConfiguration"/> class.
        /// </summary>
        /// <param name="metricId">The identifier of the metric to which this configuration applies.</param>
        /// <param name="name">A custom name for this <see cref="MetricAnomalyDetectionConfiguration"/> to be displayed on the web portal.</param>
        /// <param name="wholeSeriesDetectionConditions">The default anomaly detection conditions to be applied to all series associated with this configuration's <paramref name="metricId"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/>, <paramref name="name"/>, or <paramref name="wholeSeriesDetectionConditions"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="name"/> is empty.</exception>
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
        /// The unique identifier of this <see cref="MetricAnomalyDetectionConfiguration"/>. Set by the service.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string Id { get; internal set; }

        /// <summary>
        /// The identifier of the metric to which this configuration applies.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// A custom name for this <see cref="MetricAnomalyDetectionConfiguration"/> to be displayed on the web portal.
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
        /// The default anomaly detection conditions to be applied to all series associated with this configuration's
        /// <see cref="MetricId"/>.
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
        /// The anomaly detection conditions to be applied to the time series associated with this configuration's
        /// <see cref="MetricId"/>. These conditions overwrite the ones specified by <see cref="WholeSeriesDetectionConditions"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="SeriesGroupDetectionConditions"/> is null.</exception>
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

        /// <summary>
        /// The anomaly detection conditions to be applied to the time series associated with this configuration's
        /// <see cref="MetricId"/>. These conditions overwrite the ones specified by <see cref="WholeSeriesDetectionConditions"/>
        /// and <see cref="SeriesGroupDetectionConditions"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="SeriesDetectionConditions"/> is null.</exception>
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
        /// A description about the <see cref="MetricAnomalyDetectionConfiguration"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Creates a <see cref="AnomalyDetectionConfigurationPatch"/> model from an existing <see cref="MetricAnomalyDetectionConfiguration"/> instance.
        /// </summary>
        /// <returns></returns>
        internal AnomalyDetectionConfigurationPatch GetPatchModel()
        {
            return new AnomalyDetectionConfigurationPatch()
            {
                Description = Description,
                DimensionGroupOverrideConfigurations = SeriesGroupDetectionConditions,
                Name = Name,
                SeriesOverrideConfigurations = SeriesDetectionConditions,
                WholeMetricConfiguration = WholeSeriesDetectionConditions
            };
        }
    }
}
