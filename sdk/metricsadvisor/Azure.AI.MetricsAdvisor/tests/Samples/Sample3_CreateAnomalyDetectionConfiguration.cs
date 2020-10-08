// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task CreateAnomalyDetectionConfiguration()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string metricId = MetricId;

            #region Snippet:CreateAnomalyDetectionConfiguration
            //@@ string metricId = "<metricId>";
            string configurationName = "Sample anomaly detection configuration";

            var hardThresholdSuppressCondition = new SuppressCondition(1, 100);
            var hardThresholdCondition = new HardThresholdCondition(AnomalyDetectorDirection.Down, hardThresholdSuppressCondition)
            {
                LowerBound = 5.0
            };

            var smartDetectionSuppressCondition = new SuppressCondition(4, 50);
            var smartDetectionCondition = new SmartDetectionCondition(10.0, AnomalyDetectorDirection.Up, smartDetectionSuppressCondition);

            var detectionCondition = new MetricWholeSeriesDetectionCondition()
            {
                HardThresholdCondition = hardThresholdCondition,
                SmartDetectionCondition = smartDetectionCondition,
                CrossConditionsOperator = DetectionConditionsOperator.Or
            };

            var detectionConfiguration = new AnomalyDetectionConfiguration(metricId, configurationName, detectionCondition);

            Response<AnomalyDetectionConfiguration> response = await adminClient.CreateMetricAnomalyDetectionConfigurationAsync(detectionConfiguration);

            detectionConfiguration = response.Value;

            Console.WriteLine($"Anomaly detection configuration ID: {detectionConfiguration.Id}");
            #endregion

            // Delete the created anomaly detection configuration to clean up the Metrics Advisor resource.
            // Do not perform this step if you intend to keep using the configuration.

            await adminClient.DeleteMetricAnomalyDetectionConfigurationAsync(detectionConfiguration.Id);
        }
    }
}
