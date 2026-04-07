// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Every time a new data point is ingested by a <see cref="DataFeed"/>, it must go through an
    /// <see cref="AnomalyDetectionConfiguration"/>. This configuration is responsible for determining whether the new
    /// point is an anomaly or not. As soon as a data feed is created, the Metrics Advisor service creates a default
    /// configuration, named "Default", for each one of its metrics, and configures them to make use of the
    /// <see cref="SmartDetectionCondition"/>, a detection method powered by machine learning. You can always create new
    /// configurations or modify existing ones to better suit your needs.
    /// </summary>
    /// <remarks>
    /// In order to create an anomaly detection configuration, you must set up at least the properties <see cref="Name"/>,
    /// <see cref="MetricId"/>, and <see cref="WholeSeriesDetectionConditions"/>, and pass this instance to the method
    /// <see cref="MetricsAdvisorAdministrationClient.CreateDetectionConfigurationAsync"/>. Note that a detection configuration
    /// only detects anomalies, and is not responsible for triggering alerts. If you want alerts to be triggered, you need to
    /// create an <see cref="AnomalyAlertConfiguration"/>.
    /// </remarks>
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
        /// The unique identifier of this <see cref="AnomalyDetectionConfiguration"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. This property
        /// will be set by the service after creation.
        /// </remarks>
        [CodeGenMember("AnomalyDetectionConfigurationId")]
        public string Id { get; }

        /// <summary>
        /// The identifier of the <see cref="DataFeedMetric"/> to which this configuration applies.
        /// </summary>
        /// <remarks>
        /// After creating a <see cref="DataFeed"/>, you can get the IDs of all of your metrics from the property
        /// <see cref="DataFeed.MetricIds"/>.
        /// </remarks>
        public string MetricId { get; set; }

        /// <summary>
        /// A custom name for this <see cref="AnomalyDetectionConfiguration"/> to be displayed on the web portal.
        /// Detection configuration names must be unique for the same metric.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The default anomaly detection conditions to be applied to all time series. Be aware that these are only
        /// default conditions. They will only be applied to a new data point if the lists <see cref="SeriesDetectionConditions"/>
        /// and <see cref="SeriesGroupDetectionConditions"/> do not specify conditions for the point's time series.
        /// </summary>
        [CodeGenMember("WholeMetricConfiguration")]
        public MetricWholeSeriesDetectionCondition WholeSeriesDetectionConditions { get; set; }

        /// <summary>
        /// The anomaly detection conditions to be applied to groups of time series. Be aware that these are only
        /// default conditions. They will only be applied to a new data point if the list <see cref="SeriesDetectionConditions"/>
        /// does not specify conditions for the point's time series. Also, note that these conditions overwrite the ones
        /// specified by <see cref="WholeSeriesDetectionConditions"/>.
        /// </summary>
        [CodeGenMember("DimensionGroupOverrideConfigurations")]
        public IList<MetricSeriesGroupDetectionCondition> SeriesGroupDetectionConditions { get; }

        /// <summary>
        /// The anomaly detection conditions to be applied to a time series. Note that these conditions overwrite the ones
        /// specified by <see cref="WholeSeriesDetectionConditions"/> and <see cref="SeriesGroupDetectionConditions"/>.
        /// </summary>
        [CodeGenMember("SeriesOverrideConfigurations")]
        public IList<MetricSingleSeriesDetectionCondition> SeriesDetectionConditions { get; }

        /// <summary>
        /// A description of this <see cref="AnomalyDetectionConfiguration"/>. Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
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
                WholeMetricConfiguration = WholeSeriesDetectionConditions?.GetPatchModel()
            };
        }
    }
}
