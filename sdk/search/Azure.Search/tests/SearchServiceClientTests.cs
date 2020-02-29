// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Search;
using Azure.Search.Models;
using Azure.Search.Tests;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Microsoft.Azure.Template.Tests
{
    public class SearchServiceClientTests : SearchTestBase
    {
        public SearchServiceClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchServiceClient(endpoint, new SearchApiKeyCredential("fake"));
            Assert.NotNull(service);
            Assert.AreEqual(endpoint, service.Endpoint);
            Assert.AreEqual(serviceName, service.ServiceName);

            var indexName = "my-index-name";
            var index = service.GetSearchIndexClient(indexName);
            Assert.NotNull(index);
            Assert.AreEqual(endpoint, index.Endpoint);
            Assert.AreEqual(serviceName, index.ServiceName);
            Assert.AreEqual(indexName, index.IndexName);
        }

        [Test]
        public async Task GetStastistics()
        {
            await using SearchResources search = await SearchResources.CreateWithEmptyHotelsIndexAsync(this);

            SearchServiceClient client = search.GetServiceClient();
            Response<SearchServiceStatistics> response = await client.GetStatisticsAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.Counters);
            Assert.IsNotNull(response.Value.Counters.DataSourceCounter);
            Assert.IsNotNull(response.Value.Counters.DocumentCounter);
            Assert.IsNotNull(response.Value.Counters.IndexCounter);
            Assert.IsNotNull(response.Value.Counters.IndexerCounter);
            Assert.IsNotNull(response.Value.Counters.StorageSizeCounter);
            Assert.IsNotNull(response.Value.Counters.SynonymMapCounter);
            Assert.IsNotNull(response.Value.Limits);

            Assert.NotZero(response.Value.Counters.IndexCounter.Quota ?? 0);
            Assert.AreEqual(1, response.Value.Counters.IndexCounter.Usage ?? 0);
        }
    }
}
