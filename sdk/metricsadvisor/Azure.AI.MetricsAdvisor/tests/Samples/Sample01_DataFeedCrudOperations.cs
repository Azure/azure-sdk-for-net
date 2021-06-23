﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            #region Snippet:CreateDataFeedAsync
#if SNIPPET
            string sqlServerConnectionString = "<connectionString>";
            string sqlServerQuery = "<query>";
#else
            string sqlServerConnectionString = SqlServerConnectionString;
            string sqlServerQuery = SqlServerQuery;
#endif

            var dataFeed = new DataFeed();

#if SNIPPET
            dataFeed.Name = "<dataFeedName>";
#else
            dataFeed.Name = GetUniqueName();
#endif
            dataFeed.DataSource = new SqlServerDataFeedSource(sqlServerConnectionString, sqlServerQuery);
            dataFeed.Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily);

            dataFeed.Schema = new DataFeedSchema();
            dataFeed.Schema.MetricColumns.Add(new DataFeedMetric("cost"));
            dataFeed.Schema.MetricColumns.Add(new DataFeedMetric("revenue"));
            dataFeed.Schema.DimensionColumns.Add(new DataFeedDimension("category"));
            dataFeed.Schema.DimensionColumns.Add(new DataFeedDimension("city"));

            dataFeed.IngestionSettings = new DataFeedIngestionSettings(DateTimeOffset.Parse("2020-01-01T00:00:00Z"));

            Response<DataFeed> response = await adminClient.CreateDataFeedAsync(dataFeed);

            DataFeed createdDataFeed = response.Value;

            Console.WriteLine($"Data feed ID: {createdDataFeed.Id}");
            Console.WriteLine($"Data feed status: {createdDataFeed.Status.Value}");
            Console.WriteLine($"Data feed created time: {createdDataFeed.CreatedTime.Value}");

            Console.WriteLine($"Data feed administrators:");
            foreach (string admin in createdDataFeed.AdministratorsEmails)
            {
                Console.WriteLine($" - {admin}");
            }

            Console.WriteLine($"Metric IDs:");
            foreach (DataFeedMetric metric in createdDataFeed.Schema.MetricColumns)
            {
                Console.WriteLine($" - {metric.Name}: {metric.Id}");
            }

            Console.WriteLine($"Dimension columns:");
            foreach (DataFeedDimension dimension in createdDataFeed.Schema.DimensionColumns)
            {
                Console.WriteLine($" - {dimension.Name}");
            }
            #endregion

            // Delete the created data feed to clean up the Metrics Advisor resource. Do not perform this
            // step if you intend to keep using the data feed.

            await adminClient.DeleteDataFeedAsync(createdDataFeed.Id);
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

            Response<DataFeed> response = await adminClient.GetDataFeedAsync(dataFeedId);

            DataFeed dataFeed = response.Value;

            Console.WriteLine($"Data feed status: {dataFeed.Status.Value}");
            Console.WriteLine($"Data feed created time: {dataFeed.CreatedTime.Value}");

            Console.WriteLine($"Data feed administrators emails:");
            foreach (string admin in dataFeed.AdministratorsEmails)
            {
                Console.WriteLine($" - {admin}");
            }

            Console.WriteLine($"Metric IDs:");
            foreach (DataFeedMetric metric in dataFeed.Schema.MetricColumns)
            {
                Console.WriteLine($" - {metric.Name}: {metric.Id}");
            }

            Console.WriteLine($"Dimension columns:");
            foreach (DataFeedDimension dimension in dataFeed.Schema.DimensionColumns)
            {
                Console.WriteLine($" - {dimension.Name}");
            }
        }

        [Test]
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

            string originalDescription = dataFeed.Description;
            dataFeed.Description = "This description was generated by a sample.";

            response = await adminClient.UpdateDataFeedAsync(dataFeed);
            DataFeed updatedDataFeed = response.Value;

            Console.WriteLine($"Updated description: {updatedDataFeed.Description}");

            // Undo the changes to leave the data feed unaltered. Skip this step if you intend to keep
            // the changes.

            dataFeed.Description = originalDescription;
            await adminClient.UpdateDataFeedAsync(dataFeed);
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
                MaxPageSize = 5
            };

            int dataFeedCount = 0;

            await foreach (DataFeed dataFeed in adminClient.GetDataFeedsAsync(options))
            {
                Console.WriteLine($"Data feed ID: {dataFeed.Id}");
                Console.WriteLine($"Name: {dataFeed.Name}");
                Console.WriteLine($"Description: {dataFeed.Description}");
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
