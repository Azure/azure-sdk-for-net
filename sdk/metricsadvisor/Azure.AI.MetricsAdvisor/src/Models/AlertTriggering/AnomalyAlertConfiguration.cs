// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Detected anomalies won't trigger alerts by default, so an <see cref="AnomalyAlertConfiguration"/> must be
    /// created if you want to be notified when an anomaly is detected. This configuration is applied to every set
    /// of anomalies detected after a <see cref="DataFeed"/> ingestion, applying rules that select which of them
    /// to include in the final alert.
    /// </summary>
    /// <remarks>
    /// In order to create an anomaly alert configuration, you must set up the property <see cref="Name"/> and
    /// have at least one element in <see cref="MetricAlertConfigurations"/>, and pass this instance to the method
    /// <see cref="MetricsAdvisorAdministrationClient.CreateAlertConfigurationAsync"/>. Note that, even if alerts are
    /// triggered, you won't be notified about them unless you create a <see cref="NotificationHook"/> and pass its ID
    /// to <see cref="IdsOfHooksToAlert"/>.
    /// </remarks>
    [CodeGenModel("AnomalyAlertingConfiguration")]
    [CodeGenSuppress(nameof(AnomalyAlertConfiguration), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<MetricAlertConfiguration>))]
    public partial class AnomalyAlertConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyAlertConfiguration"/> class.
        /// </summary>
        public AnomalyAlertConfiguration()
        {
            IdsOfHooksToAlert = new ChangeTrackingList<string>();
            MetricAlertConfigurations = new ChangeTrackingList<MetricAlertConfiguration>();
            DimensionsToSplitAlert = new ChangeTrackingList<string>();
        }

        /// <summary>
        /// The unique identifier of this <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        /// <remarks>
        /// If <c>null</c>, it means this instance has not been sent to the service to be created yet. This property
        /// will be set by the service after creation.
        /// </remarks>
        [CodeGenMember("AnomalyAlertingConfigurationId")]
        public string Id { get; }

        /// <summary>
        /// A custom name for this <see cref="AnomalyAlertConfiguration"/> to be displayed on fired alerts.
        /// Alert configuration names must be unique for the same data feed.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The unique identifiers of the <see cref="NotificationHook"/>s to be notified when an alert is
        /// fired by this configuration.
        /// </summary>
        [CodeGenMember("HookIds")]
        public IList<string> IdsOfHooksToAlert { get; }

        /// <summary>
        /// The configurations that specify a set of rules a detected anomaly must satisfy to be included in
        /// an alert.
        /// </summary>
        /// <remarks>
        /// If you're using at least two metric alert configurations, you need to set the property
        /// <see cref="CrossMetricsOperator"/>.
        /// </remarks>
        [CodeGenMember("MetricAlertingConfigurations")]
        public IList<MetricAlertConfiguration> MetricAlertConfigurations { get; }

        /// <summary>
        /// The operator to be applied between <see cref="MetricAlertConfiguration"/>s in this instance.
        /// This property must be set if at least two configurations are defined in <see cref="MetricAlertConfigurations"/>.
        /// </summary>
        public MetricAlertConfigurationsOperator? CrossMetricsOperator { get; set; }

        /// <summary>
        /// A description of this <see cref="AnomalyAlertConfiguration"/>. Defaults to an empty string.
        /// </summary>
        /// <remarks>
        /// If set to null during an update operation, this property is set to its default value.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// By default, a set of ingested data points can only trigger a single alert, regardless of
        /// how many anomalies it contains. This property allows this alert to be split into multiple ones.
        /// Each element in this list must hold a dimension name, and a separate alert is fired for every
        /// specified dimension. The dimensions not specified in this list will be grouped in a single alert.
        /// </summary>
        [CodeGenMember("SplitAlertByDimensions")]
        public IList<string> DimensionsToSplitAlert { get; }

        /// <summary>
        /// Create a patch model from the current <see cref="AnomalyAlertConfiguration"/>
        /// </summary>
        /// <returns>An <see cref="AnomalyAlertConfiguration"/> instance.</returns>
        internal AnomalyAlertingConfigurationPatch GetPatchModel()
        {
            return new AnomalyAlertingConfigurationPatch()
            {
                CrossMetricsOperator = CrossMetricsOperator,
                Description = Description,
                Name = Name,
                HookIds = IdsOfHooksToAlert.Select(h => new Guid(h)).ToList(),
                MetricAlertingConfigurations = MetricAlertConfigurations,
                SplitAlertByDimensions = DimensionsToSplitAlert
            };
        }
    }
}
