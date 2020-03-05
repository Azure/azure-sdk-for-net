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
    public class SearchIndexClientTests : SearchTestBase
    {
        public SearchIndexClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var indexName = "my-index-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var index = new SearchIndexClient(endpoint, indexName, new SearchApiKeyCredential("fake"));
            Assert.NotNull(index);
            Assert.AreEqual(endpoint, index.Endpoint);
            Assert.AreEqual(serviceName, index.ServiceName);
            Assert.AreEqual(indexName, index.IndexName);
        }

        [Test]
        public async Task GetCount()
        {
            await using SearchResources search = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchIndexClient client = search.GetIndexClient();
            Response<long> response = await client.GetCountAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(SearchResources.TestDocuments.Length, response.Value);
        }
    }
}
