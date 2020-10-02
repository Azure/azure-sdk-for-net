// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    [CodeGenModel("AnomalyAlertingConfiguration")]
    [CodeGenSuppress(nameof(AnomalyAlertConfiguration), typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<MetricAnomalyAlertConfiguration>))]
    public partial class AnomalyAlertConfiguration
    {
        /// <summary>
        /// </summary>
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
        /// </summary>
        [CodeGenMember("AnomalyAlertingConfigurationId")]
        public string Id { get; internal set; }

        /// <summary>
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("HookIds")]
        public IList<string> IdsOfHooksToAlert { get; }

        /// <summary>
        /// </summary>
        [CodeGenMember("MetricAlertingConfigurations")]
        public IList<MetricAnomalyAlertConfiguration> MetricAlertConfigurations { get; }
    }
}
