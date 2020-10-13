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
    [LiveOnly]
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [RecordedTest]
        public async Task CreateDataFeedFromDataSource()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string sqlServerConnectionString = SqlServerConnectionString;
            string sqlServerQuery = SqlServerQuery;

            #region Snippet:CreateDataFeedFromDataSource
            //@@ string sqlServerConnectionString = "<connectionString>";
            //@@ string sqlServerQuery = "<query>";

            var dataFeedName = "Sample data feed";
            var dataFeedSource = new MySqlDataFeedSource(sqlServerConnectionString, sqlServerQuery);
            var dataFeedGranularity = new DataFeedGranularity(DataFeedGranularityType.Daily);

            var dataFeedMetrics = new List<DataFeedMetric>()
            {
                new DataFeedMetric("cost"),
                new DataFeedMetric("revenue")
            };
            var dataFeedDimensions = new List<MetricDimension>()
            {
                new MetricDimension("category"),
                new MetricDimension("city")
            };
            var dataFeedSchema = new DataFeedSchema(dataFeedMetrics)
            {
                DimensionColumns = dataFeedDimensions
            };

            var ingestionStartTime = DateTimeOffset.Parse("2020-01-01T00:00:00Z");
            var dataFeedIngestionSettings = new DataFeedIngestionSettings(ingestionStartTime);

            Response<DataFeed> response = await adminClient.CreateDataFeedAsync(dataFeedName, dataFeedSource,
                dataFeedGranularity, dataFeedSchema, dataFeedIngestionSettings);

            DataFeed dataFeed = response.Value;

            Console.WriteLine($"Data feed ID: {dataFeed.Id}");

            // Only the ID of the data feed is known at this point. You can perform another service
            // call to get more information, such as status, created time, the list of administrators,
            // or the metric IDs.

            response = await adminClient.GetDataFeedAsync(dataFeed.Id);

            dataFeed = response.Value;

            Console.WriteLine($"Data feed status: {dataFeed.Status.Value}");
            Console.WriteLine($"Data feed created time: {dataFeed.CreatedTime.Value}");

            Console.WriteLine($"Data feed administrators:");
            foreach (string admin in dataFeed.Options.Administrators)
            {
                Console.WriteLine($" - {admin}");
            }

            Console.WriteLine($"Metric IDs:");
            foreach (DataFeedMetric metric in dataFeed.Schema.MetricColumns)
            {
                Console.WriteLine($" - {metric.MetricName}: {metric.MetricId}");
            }

            #endregion

            // Delete the created data feed to clean up the Metrics Advisor resource. Do not perform this
            // step if you intend to keep using the data feed.

            await adminClient.DeleteDataFeedAsync(dataFeed.Id);
        }
    }
}
