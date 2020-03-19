// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
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
            var index = new SearchIndexClient(endpoint, indexName, new AzureKeyCredential("fake"));
            Assert.NotNull(index);
            Assert.AreEqual(endpoint, index.Endpoint);
            Assert.AreEqual(serviceName, index.ServiceName);
            Assert.AreEqual(indexName, index.IndexName);

            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(null, indexName, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(endpoint, null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentException>(() => new SearchIndexClient(endpoint, string.Empty, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(endpoint, indexName, null));
            Assert.Throws<ArgumentException>(() => new SearchIndexClient(new Uri("http://bing.com"), indexName, null));
        }

        [Test]
        public async Task ClientRequestIdRountrips()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchIndexClient client = resources.GetIndexClient();
            Guid id = Recording.Random.NewGuid();
            Response<long> response = await client.GetDocumentCountAsync(
                new SearchRequestOptions { ClientRequestId = id });

            // TODO: #10604 - C# generator doesn't properly support ClientRequestId yet
            // (Assertion is here to remind us to fix this when we do - just
            // change to AreEqual and re-record)
            Assert.AreNotEqual(id.ToString(), response.GetRawResponse().ClientRequestId);
        }

        [Test]
        public async Task GetDocumentCount()
        {
            await using SearchResources search = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = search.GetIndexClient();
            Response<long> response = await client.GetDocumentCountAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(SearchResources.TestDocuments.Length, response.Value);
        }
    }
}
