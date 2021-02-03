// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    [CodeGenSuppress(nameof(AnomalyDetectionConfiguration), typeof(string), typeof(string), typeof(MetricWholeSeriesDetectionCondition))]
    public partial class AnomalyDetectionConfiguration
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AnomalyDetectionConfiguration"/> class.
        /// </summary>
        public AnomalyDetectionConfiguration()
        {
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
        public string MetricId { get; set; }

        /// <summary>
        /// A custom name for this <see cref="AnomalyDetectionConfiguration"/> to be displayed on the web portal.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The default anomaly detection conditions to be applied to all series associated with this configuration's
        /// <see cref="MetricId"/>.
        /// </summary>
        [CodeGenMember("WholeMetricConfiguration")]
        public MetricWholeSeriesDetectionCondition WholeSeriesDetectionConditions { get; set; }

        /// <summary>
        /// The anomaly detection conditions to be applied to the time series associated with this configuration's
        /// <see cref="MetricId"/>. These conditions overwrite the ones specified by <see cref="WholeSeriesDetectionConditions"/>.
        /// </summary>
        [CodeGenMember("DimensionGroupOverrideConfigurations")]
        public IList<MetricSeriesGroupDetectionCondition> SeriesGroupDetectionConditions { get; }

        /// <summary>
        /// The anomaly detection conditions to be applied to the time series associated with this configuration's
        /// <see cref="MetricId"/>. These conditions overwrite the ones specified by <see cref="WholeSeriesDetectionConditions"/>
        /// and <see cref="SeriesGroupDetectionConditions"/>.
        /// </summary>
        [CodeGenMember("SeriesOverrideConfigurations")]
        public IList<MetricSingleSeriesDetectionCondition> SeriesDetectionConditions { get; }

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
