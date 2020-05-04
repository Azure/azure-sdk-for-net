// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchClientTests : SearchTestBase
    {
        public SearchClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var indexName = "my-index-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var client = new SearchClient(endpoint, indexName, new AzureKeyCredential("fake"));
            Assert.NotNull(client);
            Assert.AreEqual(endpoint, client.Endpoint);
            Assert.AreEqual(serviceName, client.ServiceName);
            Assert.AreEqual(indexName, client.IndexName);

            Assert.Throws<ArgumentNullException>(() => new SearchClient(null, indexName, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchClient(endpoint, null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentException>(() => new SearchClient(endpoint, string.Empty, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchClient(endpoint, indexName, null));
            Assert.Throws<ArgumentException>(() => new SearchClient(new Uri("http://bing.com"), indexName, null));
        }

        [Test]
        public async Task ClientRequestIdRountrips()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchClient client = resources.GetSearchClient();
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

            SearchClient client = search.GetSearchClient();
            Response<long> response = await client.GetDocumentCountAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(SearchResources.TestDocuments.Length, response.Value);
        }
    }
}
