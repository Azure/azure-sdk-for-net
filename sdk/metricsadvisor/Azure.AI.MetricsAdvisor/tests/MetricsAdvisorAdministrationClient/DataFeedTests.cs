// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class DataFeedTests : ClientTestBase
    {
        public DataFeedTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateDataFeedValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var name = "dataFeedName";
            var dataSource = new AzureTableDataFeedSource("connectionString", "table", "query");
            var granularity = new DataFeedGranularity(DataFeedGranularityType.Daily);
            var schema = new DataFeedSchema() { MetricColumns = { new("metricName") } };
            var ingestionSettings = new DataFeedIngestionSettings() { IngestionStartTime = DateTimeOffset.UtcNow };

            var dataFeed = new DataFeed()
            {
                Name = null,
                DataSource = dataSource,
                Granularity = granularity,
                Schema = schema,
                IngestionSettings = ingestionSettings
            };

            Assert.That(() => adminClient.CreateDataFeedAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentNullException>());

            dataFeed.Name = "";
            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentException>());

            dataFeed.Name = name;
            dataFeed.DataSource = null;
            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentNullException>());

            dataFeed.DataSource = dataSource;
            dataFeed.Granularity = null;
            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentNullException>());

            dataFeed.Granularity = granularity;
            dataFeed.Schema = null;
            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentNullException>());

            dataFeed.Schema = schema;
            dataFeed.IngestionSettings = null;
            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentNullException>());

            dataFeed.IngestionSettings = new DataFeedIngestionSettings() { IngestionStartTime = null };
            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateDataFeedRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeed = new DataFeed()
            {
                Name = "dataFeedName",
                DataSource = new AzureTableDataFeedSource("connectionString", "table", "query"),
                Granularity = new DataFeedGranularity(DataFeedGranularityType.Daily),
                Schema = new DataFeedSchema() { MetricColumns = { new("metricName") } },
                IngestionSettings = new DataFeedIngestionSettings() { IngestionStartTime = DateTimeOffset.UtcNow }
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateDataFeedAsync(dataFeed, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateDataFeed(dataFeed, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void UpdateDataFeedValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeed = new DataFeed();

            Assert.That(() => adminClient.UpdateDataFeedAsync(null, dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDataFeedAsync("", dataFeed), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateDataFeedAsync("dataFeedId", dataFeed), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateDataFeedAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.UpdateDataFeed(null, dataFeed), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDataFeed("", dataFeed), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateDataFeed("dataFeedId", dataFeed), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateDataFeed(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateDataFeedRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var dataFeed = new DataFeed();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.UpdateDataFeedAsync(FakeGuid, dataFeed, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.UpdateDataFeed(FakeGuid, dataFeed, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDataFeedValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetDataFeedAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataFeedAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataFeedAsync("dataFeedId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetDataFeed(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataFeed(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataFeed("dataFeedId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetDataFeedRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetDataFeedAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetDataFeed(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDataFeedsRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataFeed> asyncEnumerator = adminClient.GetDataFeedsAsync(cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataFeed> enumerator = adminClient.GetDataFeeds(cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteDataFeedValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteDataFeedAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDataFeedAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDataFeedAsync("dataFeedId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteDataFeed(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDataFeed(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDataFeed("dataFeedId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteDataFeedRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteDataFeedAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteDataFeed(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
