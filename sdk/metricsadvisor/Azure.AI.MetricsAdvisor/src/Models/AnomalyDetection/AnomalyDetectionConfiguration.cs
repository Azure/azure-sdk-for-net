// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines which data points of a metric should be considered an anomaly. A <see cref="AnomalyDetectionConfiguration"/>
    /// can only be applied to a single metric within a data feed, but it can have multiple conditions applied to different time
    /// series within the same metric.
    /// </summary>
    [CodeGenModel("AnomalyDetectionConfiguration")]
    public partial class AnomalyDetectionConfiguration
    {
        private string _name;

        private MetricWholeSeriesDetectionCondition _wholeSeriesDetectionConditions;

        private IList<MetricSingleSeriesDetectionCondition> _seriesDetectionConditions;

        private IList<MetricSeriesGroupDetectionCondition> _seriesGroupDetectionConditions;

        /// <summary>
        /// Creates a new instance of the <see cref="AnomalyDetectionConfiguration"/> class.
        /// </summary>
        /// <param name="metricId">The identifier of the metric to which this configuration applies.</param>
        /// <param name="name">A custom name for this <see cref="AnomalyDetectionConfiguration"/> to be displayed on the web portal.</param>
        /// <param name="wholeSeriesDetectionConditions">The default anomaly detection conditions to be applied to all series associated with this configuration's <paramref name="metricId"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metricId"/>, <paramref name="name"/>, or <paramref name="wholeSeriesDetectionConditions"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="metricId"/> or <paramref name="name"/> is empty.</exception>
        public AnomalyDetectionConfiguration(string metricId, string name, MetricWholeSeriesDetectionCondition wholeSeriesDetectionConditions)
        {
            Argument.AssertNotNullOrEmpty(metricId, nameof(metricId));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(wholeSeriesDetectionConditions, nameof(wholeSeriesDetectionConditions));

            MetricId = metricId;
            Name = name;
            WholeSeriesDetectionConditions = wholeSeriesDetectionConditions;
            SeriesDetectionConditions = new ChangeTrackingList<MetricSingleSeriesDetectionCondition>();
            SeriesGroupDetectionConditions = new ChangeTrackingList<MetricSeriesGroupDetectionCondition>();
        }

        /// <summary>
        /// The unique identifier of this <see cref="AnomalyDetectionConfiguration"/>. Set by the service.
        /// </summary>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string Id { get; }

        /// <summary>
        /// The identifier of the metric to which this configuration applies.
        /// </summary>
        public string MetricId { get; }

        /// <summary>
        /// A custom name for this <see cref="AnomalyDetectionConfiguration"/> to be displayed on the web portal.
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
        public MetricWholeSeriesDetectionCondition WholeSeriesDetectionConditions
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
#pragma warning disable CA2227 // Collection properties should be readonly
        public IList<MetricSeriesGroupDetectionCondition> SeriesGroupDetectionConditions
        {
            get => _seriesGroupDetectionConditions;
            set
            {
                Argument.AssertNotNull(value, nameof(SeriesGroupDetectionConditions));
                _seriesGroupDetectionConditions = value;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// The anomaly detection conditions to be applied to the time series associated with this configuration's
        /// <see cref="MetricId"/>. These conditions overwrite the ones specified by <see cref="WholeSeriesDetectionConditions"/>
        /// and <see cref="SeriesGroupDetectionConditions"/>.
        /// </summary>
        /// <exception cref="ArgumentNullException"><see cref="SeriesDetectionConditions"/> is null.</exception>
        [CodeGenMember("SeriesOverrideConfigurations")]
#pragma warning disable CA2227 // Collection properties should be readonly
        public IList<MetricSingleSeriesDetectionCondition> SeriesDetectionConditions
        {
            get => _seriesDetectionConditions;
            set
            {
                Argument.AssertNotNull(value, nameof(SeriesDetectionConditions));
                _seriesDetectionConditions = value;
            }
        }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// A description about the <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Creates a <see cref="AnomalyDetectionConfigurationPatch"/> model from an existing <see cref="AnomalyDetectionConfiguration"/> instance.
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
