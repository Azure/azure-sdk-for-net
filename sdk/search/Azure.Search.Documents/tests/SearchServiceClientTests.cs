// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
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
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));
            Assert.NotNull(service);
            Assert.AreEqual(endpoint, service.Endpoint);
            Assert.AreEqual(serviceName, service.ServiceName);

            Assert.Throws<ArgumentNullException>(() => new SearchServiceClient(null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchServiceClient(endpoint, null));
            Assert.Throws<ArgumentException>(() => new SearchServiceClient(new Uri("http://bing.com"), null));
        }

        [Test]
        public void GetSearchIndexClient()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));

            var indexName = "my-index-name";
            var index = service.GetSearchIndexClient(indexName);
            Assert.NotNull(index);
            Assert.AreEqual(endpoint, index.Endpoint);
            Assert.AreEqual(serviceName, index.ServiceName);
            Assert.AreEqual(indexName, index.IndexName);

            Assert.Throws<ArgumentNullException>(() => service.GetSearchIndexClient(null));
            Assert.Throws<ArgumentException>(() => service.GetSearchIndexClient(string.Empty));
        }

        private class TestPipelinePolicy : HttpPipelineSynchronousPolicy
        {
            public int RequestCount { get; private set; }
            public override void OnSendingRequest(HttpMessage message) => RequestCount++;
        }

        [Test]
        public async Task IndexSharesPipeline()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            TestPipelinePolicy custom = new TestPipelinePolicy();
            Assert.AreEqual(0, custom.RequestCount);

            SearchClientOptions options = new SearchClientOptions(ServiceVersion);
            options.AddPolicy(custom, HttpPipelinePosition.PerCall);
            SearchServiceClient client = resources.GetServiceClient(options);

            SearchIndexClient index = client.GetSearchIndexClient(resources.IndexName);
            _ = await index.GetDocumentCountAsync();

            Assert.AreEqual(1, custom.RequestCount);
        }

        [Test]
        public async Task ClientRequestIdRountrips()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);
            SearchServiceClient client = resources.GetServiceClient();
            Guid id = Recording.Random.NewGuid();
            Response<SearchServiceStatistics> response =
                await client.GetServiceStatisticsAsync(
                    new SearchRequestOptions { ClientRequestId = id });

            // TODO: #10604 - C# generator doesn't properly support ClientRequestId yet
            // (Assertion is here to remind us to fix this when we do - just
            // change to AreEqual and re-record)
            Assert.AreNotEqual(id.ToString(), response.GetRawResponse().ClientRequestId);
        }

        [Test]
        public void DiagnosticsAreUnique()
        {
            // Make sure we're not repeating Header/Query names already defined
            // in the base ClientOptions
            SearchClientOptions options = new SearchClientOptions();
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedHeaderNames));
            Assert.IsEmpty(GetDuplicates(options.Diagnostics.LoggedQueryParameters));

            // CollectionAssert.Unique doesn't give you the duplicate values
            // which is less helpful than it could be
            static string GetDuplicates(IEnumerable<string> values)
            {
                List<string> duplicates = new List<string>();
                HashSet<string> unique = new HashSet<string>();
                foreach (string value in values)
                {
                    if (!unique.Add(value))
                    {
                        duplicates.Add(value);
                    }
                }
                return string.Join(", ", duplicates);
            }
        }

        [Test]
        public async Task GetServiceStatistics()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchServiceClient client = resources.GetServiceClient();
            Response<SearchServiceStatistics> response = await client.GetServiceStatisticsAsync();
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

            Assert.NotZero(response.Value.Counters.IndexCounter.Quota ?? 0L);
            Assert.AreEqual(1, response.Value.Counters.IndexCounter.Usage);
        }

        [Test]
        public void CreateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateIndex(null));
            Assert.AreEqual("index", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateIndexAsync(null));
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        public async Task CreateIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithNoIndexesAsync(this);

            string indexName = Recording.Random.GetName(8);
            SearchIndex expectedIndex = SearchResources.GetHotelIndex(indexName);

            SearchServiceClient client = resources.GetServiceClient();
            SearchIndex actualIndex = await client.CreateIndexAsync(expectedIndex);

            Assert.AreEqual(expectedIndex.Name, actualIndex.Name);
            Assert.That(actualIndex.Fields, Is.EqualTo(expectedIndex.Fields).Using(SearchFieldComparer.Shared));
            Assert.AreEqual(expectedIndex.Suggesters.Count, actualIndex.Suggesters.Count);
            Assert.AreEqual(expectedIndex.Suggesters[0].Name, actualIndex.Suggesters[0].Name);
            Assert.AreEqual(expectedIndex.ScoringProfiles.Count, actualIndex.ScoringProfiles.Count);
            Assert.AreEqual(expectedIndex.ScoringProfiles[0].Name, actualIndex.ScoringProfiles[0].Name);
        }

        [Test]
        public async Task UpdateIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithNoIndexesAsync(this);

            string indexName = Recording.Random.GetName();
            SearchIndex initialIndex = SearchResources.GetHotelIndex(indexName);

            SearchServiceClient client = resources.GetServiceClient();
            SearchIndex createdIndex = await client.CreateIndexAsync(initialIndex);

            string analyzerName = "asciiTags";

            createdIndex.Analyzers.Add(
                new PatternAnalyzer(analyzerName)
                {
                    Pattern = @"[0-9a-z]+",
                    Flags =
                    {
                        RegexFlags.CaseInsensitive,
                        RegexFlags.Multiline,
                    },
                    Stopwords =
                    {
                        "a",
                        "and",
                        "the",
                    },
                });

            createdIndex.Fields.Add(
                new SearchableField("asciiTags", collection: true)
                {
                    Analyzer = analyzerName,
                    IsFacetable = true,
                    IsFilterable = true,
                });

            SearchIndex updatedIndex = await client.CreateOrUpdateIndexAsync(
                createdIndex,
                allowIndexDowntime: true,
                accessConditions: new MatchConditions { IfMatch = new ETag(createdIndex.ETag) });

            Assert.AreEqual(createdIndex.Name, updatedIndex.Name);
            Assert.That(updatedIndex.Fields, Is.EqualTo(updatedIndex.Fields).Using(SearchFieldComparer.Shared));
            Assert.AreEqual(createdIndex.Suggesters.Count, updatedIndex.Suggesters.Count);
            Assert.AreEqual(createdIndex.Suggesters[0].Name, updatedIndex.Suggesters[0].Name);
            Assert.AreEqual(createdIndex.ScoringProfiles.Count, updatedIndex.ScoringProfiles.Count);
            Assert.AreEqual(createdIndex.ScoringProfiles[0].Name, updatedIndex.ScoringProfiles[0].Name);
            Assert.AreEqual(createdIndex.Analyzers.Count, updatedIndex.Analyzers.Count);
            Assert.AreEqual(createdIndex.Analyzers[0].Name, updatedIndex.Analyzers[0].Name);
        }

        [Test]
        public void GetIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchServiceClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetIndex(null));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetIndexAsync(null));
            Assert.AreEqual("indexName", ex.ParamName);
        }

        [Test]
        public async Task GetIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchServiceClient client = resources.GetServiceClient();
            SearchIndex index = await client.GetIndexAsync(resources.IndexName);

            // TODO: Replace with comparison of actual SearchIndex once test framework uses Azure.Search.Documents instead.
            Assert.AreEqual(resources.IndexName, index.Name);
            Assert.AreEqual(13, index.Fields.Count);
        }

        [Test]
        public async Task GetIndexes()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchServiceClient client = resources.GetServiceClient();

            bool found = false;
            await foreach (SearchIndex index in client.GetIndexesAsync())
            {
                found |= string.Equals(resources.IndexName, index.Name, StringComparison.InvariantCultureIgnoreCase);
            }

            Assert.IsTrue(found, "Shared index not found");
        }

        [Test]
        [AsyncOnly]
        public async Task GetIndexesNextPageThrows()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchServiceClient client = resources.GetServiceClient();
            AsyncPageable<SearchIndex> pageable = client.GetIndexesAsync();

            string continuationToken = Recording.GenerateId();
            IAsyncEnumerator<Page<SearchIndex>> e = pageable.AsPages(continuationToken).GetAsyncEnumerator();

            // Given a continuationToken above, this actually starts with the second page.
            Assert.ThrowsAsync<NotSupportedException>(async () => await e.MoveNextAsync());
        }

        [Test]
        public async Task CreateAzureBlobIndexer()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this);

            SearchServiceClient serviceClient = resources.GetServiceClient();

            // Create the Azure Blob data source and indexer.
            DataSource dataSource = new DataSource(
                resources.StorageAccountName,
                DataSourceType.AzureBlob,
                new DataSourceCredentials(resources.StorageAccountConnectionString),
                new DataContainer(resources.BlobContainerName));

            DataSource actualSource = await serviceClient.CreateDataSourceAsync(
                dataSource,
                GetOptions());

            SearchIndexer indexer = new SearchIndexer(
                Recording.Random.GetName(8),
                dataSource.Name,
                resources.IndexName);

            SearchIndexer actualIndexer = await serviceClient.CreateIndexerAsync(
                indexer,
                GetOptions());

            // Update the indexer.
            actualIndexer.Description = "Updated description";
            await serviceClient.CreateOrUpdateIndexerAsync(
                actualIndexer,
                new MatchConditions
                {
                    IfMatch = new ETag(actualIndexer.ETag),
                },
                GetOptions());

            await WaitForIndexingAsync(serviceClient, actualIndexer.Name);

            // Run the indexer.
            await serviceClient.RunIndexerAsync(
                indexer.Name,
                GetOptions());

            await WaitForIndexingAsync(serviceClient, actualIndexer.Name);

            // Query the index.
            SearchIndexClient indexClient = serviceClient.GetSearchIndexClient(
                resources.IndexName);

            long count = await indexClient.GetDocumentCountAsync(
                GetOptions());

            Assert.AreEqual(SearchResources.TestDocuments.Length, count);
        }

        [Test]
        public async Task CrudSynonymMaps()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            string synonymMapName = Recording.Random.GetName();

            SearchServiceClient client = resources.GetServiceClient();

            SynonymMap map = await client.CreateSynonymMapAsync(new SynonymMap(synonymMapName, "msft=>Microsoft"));
            Assert.AreEqual(synonymMapName, map.Name);
            Assert.AreEqual("solr", map.Format);
            Assert.AreEqual("msft=>Microsoft", map.Synonyms);

            map = await client.CreateOrUpdateSynonymMapAsync(new SynonymMap(synonymMapName, "ms,msft=>Microsoft"), new MatchConditions { IfMatch = new ETag(map.ETag) });
            Assert.AreEqual(synonymMapName, map.Name);
            Assert.AreEqual("solr", map.Format);
            Assert.AreEqual("ms,msft=>Microsoft", map.Synonyms);

            Response<IReadOnlyList<SynonymMap>> mapsResponse = await client.GetSynonymMapsAsync(new[] { nameof(SynonymMap.Name) });
            foreach (SynonymMap namedMap in mapsResponse.Value)
            {
                if (string.Equals(map.Name, namedMap.Name, StringComparison.OrdinalIgnoreCase))
                {
                    SynonymMap fetchedMap = await client.GetSynonymMapAsync(namedMap.Name);
                    Assert.AreEqual(map.Synonyms, fetchedMap.Synonyms);
                }
            }

            await client.DeleteSynonymMapAsync(map.Name, new MatchConditions { IfMatch = new ETag(map.ETag) });
        }

        /// <summary>
        /// Gets a new <see cref="SearchRequestOptions"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="SearchRequestOptions"/> with a new <see cref="SearchRequestOptions.ClientRequestId"/>.
        /// </returns>
        private SearchRequestOptions GetOptions() => new SearchRequestOptions
        {
            ClientRequestId = Recording.Random.NewGuid(),
        };

        /// <summary>
        /// Waits for an indexer to complete up to the given <paramref name="timeout"/>.
        /// </summary>
        /// <param name="client">The <see cref="SearchServiceClient"/> to use for requests.</param>
        /// <param name="indexerName">The name of the <see cref="SearchIndexer"/> to check.</param>
        /// <param name="timeout">The amount of time before being canceled. The default is 1 minute.</param>
        /// <returns>A <see cref="Task"/> to await.</returns>
        private async Task WaitForIndexingAsync(
            SearchServiceClient client,
            string indexerName,
            TimeSpan? timeout = null)
        {
            TimeSpan delay = TimeSpan.FromSeconds(10);
            timeout ??= TimeSpan.FromMinutes(1);

            using CancellationTokenSource cts = new CancellationTokenSource(timeout.Value);

            while (true)
            {
                await DelayAsync(delay, cancellationToken: cts.Token);

                IndexerExecutionInfo status = await client.GetIndexerStatusAsync(
                    indexerName,
                    GetOptions(),
                    cts.Token);

                if (status.Status == IndexerStatus.Running &&
                    status.LastResult?.Status == IndexerExecutionStatus.Success)
                {
                    return;
                }
            }
        }
    }
}
