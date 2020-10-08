// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        private async Task<DataFeed> CreateSampleDataFeed(MetricsAdvisorAdministrationClient adminClient)
        {
            string mySqlConnectionString = "";
            string mySqlQuery = "";

            Response<DataFeed> response = await adminClient.CreateDataFeedAsync
            (
                "Sample data feed",
                new MySqlDataFeedSource(mySqlConnectionString, mySqlQuery),
                new DataFeedGranularity(DataFeedGranularityType.Daily),
                new DataFeedSchema
                (
                    new List<DataFeedMetric>()
                    {
                        new DataFeedMetric("cost"),
                        new DataFeedMetric("revenue")
                    }
                )
                {
                    DimensionColumns = new List<MetricDimension>()
                    {
                        new MetricDimension("category"),
                        new MetricDimension("city")
                    }
                },
                new DataFeedIngestionSettings(DateTimeOffset.Parse("2020-01-01T00:00:00Z"))
            );

            string dimensionId = response.Value.Id;

            response = await adminClient.GetDataFeedAsync(dimensionId);

            return response.Value;
        }

        private async Task<AnomalyDetectionConfiguration> CreateSampleAnomalyDetectionConfiguration(MetricsAdvisorAdministrationClient adminClient, string metricId)
        {
            Response<AnomalyDetectionConfiguration> response = await adminClient.CreateMetricAnomalyDetectionConfigurationAsync
            (
                new AnomalyDetectionConfiguration
                (
                    metricId,
                    "Sample anomaly detection configuration",
                    new MetricWholeSeriesDetectionCondition()
                    {
                        SmartDetectionCondition = new SmartDetectionCondition
                        (
                            10.0,
                            AnomalyDetectorDirection.Both,
                            new SuppressCondition(1, 100)
                        )
                    }
                )
            );

            return response.Value;
        }

        private async Task<AlertingHook> CreateSampleHook(MetricsAdvisorAdministrationClient adminClient)
        {
            Response<AlertingHook> response = await adminClient.CreateHookAsync
            (
                new EmailHook
                (
                    "Sample hook",
                    new List<string>()
                    {
                        "email@sample.com"
                    }
                )
            );

            return response.Value;
        }

        private async Task<AnomalyAlertConfiguration> CreateSampleAnomalyAlertConfiguration(MetricsAdvisorAdministrationClient adminClient, string hookId, string detectionConfigurationId)
        {
            Response<AnomalyAlertConfiguration> response = await adminClient.CreateAnomalyAlertConfigurationAsync
            (
                new AnomalyAlertConfiguration
                (
                    "Sample anomaly alert configuration",
                    new List<string>()
                    {
                        hookId
                    },
                    new List<MetricAnomalyAlertConfiguration>()
                    {
                        new MetricAnomalyAlertConfiguration
                        (
                            detectionConfigurationId,
                            MetricAnomalyAlertScope.GetScopeForWholeSeries()
                        )
                    }
                )
            );

            return response.Value;
        }
    }
}
