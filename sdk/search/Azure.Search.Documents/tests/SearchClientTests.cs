// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
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
            Assert.That(client, Is.Not.Null);
            Assert.That(client.Endpoint, Is.EqualTo(endpoint));
            Assert.That(client.ServiceName, Is.EqualTo(serviceName));
            Assert.That(client.IndexName, Is.EqualTo(indexName));

            Assert.Throws<ArgumentNullException>(() => new SearchClient(null, indexName, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchClient(endpoint, null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentException>(() => new SearchClient(endpoint, string.Empty, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchClient(endpoint, indexName, credential: null));
            Assert.Throws<ArgumentException>(() => new SearchClient(new Uri("http://bing.com"), indexName, credential: null));

            Assert.Throws<ArgumentNullException>(() => new SearchClient(endpoint, indexName, tokenCredential: null));
        }

        [Test]
        public void AuthenticateInChinaCloud()
        {
            var serviceName = "my-svc-name";
            var indexName = "my-index-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            SearchClientOptions options = new SearchClientOptions()
            {
                Audience = SearchAudience.AzureChina
            };
            SearchClient client = new SearchClient(endpoint, indexName,
                new DefaultAzureCredential(
                    new DefaultAzureCredentialOptions()
                    {
                        AuthorityHost = AzureAuthorityHosts.AzureChina
                    }),
                options);
            Assert.That(client, Is.Not.Null);
            Assert.That(client.Endpoint, Is.EqualTo(endpoint));
            Assert.That(client.ServiceName, Is.EqualTo(serviceName));
            Assert.That(client.IndexName, Is.EqualTo(indexName));
            Assert.That(options.Audience, Is.EqualTo(SearchAudience.AzureChina));
        }

        [Test]
        public async Task GetDocumentCount()
        {
            await using SearchResources search = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchClient client = search.GetSearchClient();
            Response<long> response = await client.GetDocumentCountAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value, Is.EqualTo(SearchResources.TestDocuments.Length));
        }
    }
}
