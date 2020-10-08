// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using Azure.Core.TestFramework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [RecordedTest]
        public async Task CreateAnomalyAlertConfiguration()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string hookId = HookId;
            string anomalyDetectionConfigurationId = DetectionConfigurationId;

            #region Snippet:CreateAnomalyAlertConfiguration
            //@@ string hookId = "<hookId>";
            //@@ string anomalyDetectionConfigurationId = "<anomalyDetectionConfigurationId>";

            string configurationName = "Sample anomaly alert configuration";
            var idsOfHooksToAlert = new List<string>() { hookId };

            var scope = MetricAnomalyAlertScope.GetScopeForWholeSeries();
            var metricAlertConfigurations = new List<MetricAnomalyAlertConfiguration>()
            {
                new MetricAnomalyAlertConfiguration(anomalyDetectionConfigurationId, scope)
            };

            AnomalyAlertConfiguration alertConfiguration = new AnomalyAlertConfiguration(configurationName, idsOfHooksToAlert, metricAlertConfigurations);

            Response<AnomalyAlertConfiguration> response = await adminClient.CreateAnomalyAlertConfigurationAsync(alertConfiguration);

            alertConfiguration = response.Value;

            Console.WriteLine($"Alert configuration ID: {alertConfiguration.Id}");
            #endregion

            // Delete the anomaly alert configuration to clean up the Metrics Advisor resource. Do not
            // perform this step if you intend to keep using the configuration.

            await adminClient.DeleteMetricAnomalyDetectionConfigurationAsync(alertConfiguration.Id);
        }
    }
}
