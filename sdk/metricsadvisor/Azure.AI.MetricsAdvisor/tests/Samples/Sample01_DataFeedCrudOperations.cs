// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    [LiveOnly]
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task CreateAndDeleteDataFeedAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string sqlServerConnectionString = SqlServerConnectionString;
            string sqlServerQuery = SqlServerQuery;

            #region Snippet:CreateDataFeedAsync
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
            var dataFeedDimensions = new List<DataFeedDimension>()
            {
                new DataFeedDimension("category"),
                new DataFeedDimension("city")
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
            #endregion

            // Only the ID of the data feed is known at this point. You can perform another service
            // call to GetDataFeedAsync or GetDataFeed to get more information, such as status, created
            // time, the list of administrators, or the metric IDs.

            // Delete the created data feed to clean up the Metrics Advisor resource. Do not perform this
            // step if you intend to keep using the data feed.

            await adminClient.DeleteDataFeedAsync(dataFeed.Id);
        }

        [Test]
        public async Task GetDataFeedAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string dataFeedId = DataFeedId;

            #region Snippet:GetDataFeedAsync
            //@@ string dataFeedId = "<dataFeedId>";

            Response<DataFeed> response = await adminClient.GetDataFeedAsync(dataFeedId);

            DataFeed dataFeed = response.Value;

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

            Console.WriteLine($"Dimension columns:");
            foreach (DataFeedDimension dimension in dataFeed.Schema.DimensionColumns)
            {
                Console.WriteLine($" - {dimension.DimensionName}");
            }
        }

        [Test]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/16168")]
        public async Task UpdateDataFeedAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string dataFeedId = DataFeedId;

            Response<DataFeed> response = await adminClient.GetDataFeedAsync(dataFeedId);
            DataFeed dataFeed = response.Value;

            string originalDescription = dataFeed.Options.Description;
            dataFeed.Options.Description = "This description was generated by a sample.";

            await adminClient.UpdateDataFeedAsync(dataFeedId, dataFeed);

            // Undo the changes to leave the data feed unaltered. Skip this step if you intend to keep
            // the changes.

            dataFeed.Options.Description = originalDescription;
            await adminClient.UpdateDataFeedAsync(dataFeedId, dataFeed);
        }

        [Test]
        public async Task GetDataFeedsAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            var filter = new GetDataFeedsFilter()
            {
                Status = DataFeedStatus.Active,
                GranularityType = DataFeedGranularityType.Daily
            };
            var options = new GetDataFeedsOptions()
            {
                GetDataFeedsFilter = filter,
                TopCount = 5
            };

            int dataFeedCount = 0;

            await foreach (DataFeed dataFeed in adminClient.GetDataFeedsAsync(options))
            {
                Console.WriteLine($"Data feed ID: {dataFeed.Id}");
                Console.WriteLine($"Name: {dataFeed.Name}");
                Console.WriteLine($"Description: {dataFeed.Options.Description}");
                Console.WriteLine();

                // Print at most 5 data feeds.
                if (++dataFeedCount >= 5)
                {
                    break;
                }
            }
        }
    }
}
