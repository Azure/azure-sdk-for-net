// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Defines the set of rules that must be satisfied by an anomaly before it can trigger an alert.
    /// </summary>
    [CodeGenModel("AnomalyAlertingConfiguration")]
    [CodeGenSuppress(nameof(AnomalyAlertConfiguration), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<MetricAnomalyAlertConfiguration>))]
    public partial class AnomalyAlertConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnomalyAlertConfiguration"/> class.
        /// </summary>
        /// <param name="name">A custom name for this <see cref="AnomalyAlertConfiguration"/> to be displayed on fired alerts.</param>
        /// <param name="idsOfHooksToAlert">The unique identifiers of the <see cref="NotificationHook"/>s that must be notified when an alert is detected by this configuration.</param>
        /// <param name="metricAlertConfigurations">The configurations that define which anomalies are eligible for triggering an alert.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/>, <paramref name="idsOfHooksToAlert"/>, or <paramref name="metricAlertConfigurations"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty.</exception>
        public AnomalyAlertConfiguration(string name, IList<string> idsOfHooksToAlert, IList<MetricAnomalyAlertConfiguration> metricAlertConfigurations)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(idsOfHooksToAlert, nameof(idsOfHooksToAlert));
            Argument.AssertNotNull(metricAlertConfigurations, nameof(metricAlertConfigurations));

            Name = name;
            IdsOfHooksToAlert = idsOfHooksToAlert;
            MetricAlertConfigurations = metricAlertConfigurations;
        }

        /// <summary>
        /// The unique identifier of this <see cref="AnomalyAlertConfiguration"/>. Set by the service.
        /// </summary>
        [CodeGenMember("AnomalyAlertingConfigurationId")]
        public string Id { get; internal set; }

        /// <summary>
        /// A custom name for this <see cref="AnomalyAlertConfiguration"/> to be displayed on fired alerts.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The unique identifiers of the <see cref="NotificationHook"/>s that must be notified when an alert is
        /// detected by this configuration.
        /// </summary>
        [CodeGenMember("HookIds")]
        public IList<string> IdsOfHooksToAlert { get; }

        /// <summary>
        /// The configurations that define which anomalies are eligible for triggering an alert.
        /// </summary>
        [CodeGenMember("MetricAlertingConfigurations")]
        public IList<MetricAnomalyAlertConfiguration> MetricAlertConfigurations { get; }

        /// <summary>
        /// The operator to be applied between <see cref="MetricAnomalyAlertConfiguration"/>s in this
        /// <see cref="AnomalyAlertConfiguration"/> instance. This property must be set if more than one
        /// configuration is defined in <see cref="MetricAlertConfigurations"/>.
        /// </summary>
        public MetricAnomalyAlertConfigurationsOperator? CrossMetricsOperator { get; set; }

        /// <summary>
        /// A description of the <see cref="AnomalyAlertConfiguration"/>.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Create a patch model from the current <see cref="AnomalyAlertConfiguration"/>
        /// </summary>
        /// <returns>An <see cref="AnomalyAlertConfiguration"/> instance.</returns>
        internal AnomalyAlertingConfigurationPatch GetPatchModel()
        {
            return new AnomalyAlertingConfigurationPatch()
            {
                CrossMetricsOperator = CrossMetricsOperator.HasValue ? new AnomalyAlertingConfigurationPatchCrossMetricsOperator(CrossMetricsOperator.Value.ToString()) : default,
                Description = Description,
                Name = Name,
                HookIds = IdsOfHooksToAlert.Select(h => new Guid(h)).ToList(),
                MetricAlertingConfigurations = MetricAlertConfigurations
            };
        }
    }
}
