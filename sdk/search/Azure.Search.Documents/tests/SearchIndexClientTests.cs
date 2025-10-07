// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    public class SearchIndexClientTests : SearchTestBase
    {
        public SearchIndexClientTests(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            SanitizersToRemove.Add("AZSDK3431"); // $..token
        }

        [Test]
        public void Constructor()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));
            Assert.NotNull(service);
            Assert.AreEqual(endpoint, service.Endpoint);
            Assert.AreEqual(serviceName, service.ServiceName);

            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(null, new AzureKeyCredential("fake")));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(endpoint, credential: null));
            Assert.Throws<ArgumentNullException>(() => new SearchIndexClient(endpoint, tokenCredential: null));
            Assert.Throws<ArgumentException>(() => new SearchIndexClient(new Uri("http://bing.com"), credential: null));
        }

        [Test]
        public void GetSearchClient()
        {
            var serviceName = "my-svc-name";
            var endpoint = new Uri($"https://{serviceName}.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            var indexName = "my-index-name";
            var client = service.GetSearchClient(indexName);
            Assert.NotNull(client);
            Assert.AreEqual(endpoint, client.Endpoint);
            Assert.AreEqual(serviceName, client.ServiceName);
            Assert.AreEqual(indexName, client.IndexName);

            Assert.Throws<ArgumentNullException>(() => service.GetSearchClient(null));
            Assert.Throws<ArgumentException>(() => service.GetSearchClient(string.Empty));
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
            SearchIndexClient serviceClient = resources.GetIndexClient(options);

            SearchClient client = serviceClient.GetSearchClient(resources.IndexName);
            _ = await client.GetDocumentCountAsync();

            Assert.AreEqual(1, custom.RequestCount);
        }

        [Test]
        public void DiagnosticsAreUnique()
        {
            // Make sure we're not repeating Header/Query names already defined
            // in the base ClientOptions
            SearchClientOptions options = new SearchClientOptions(ServiceVersion);
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

            SearchIndexClient client = resources.GetIndexClient();
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
            Assert.NotZero(response.Value.Counters.IndexCounter.Usage);
        }

        [Test]
        [SyncOnly]
        public void CreateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateIndex(null));
            Assert.AreEqual("index", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateIndexAsync(null));
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_09_01)]
        public async Task CreateIndex()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            resources.IndexName = Recording.Random.GetName(8);
            SearchIndex expectedIndex = SearchResources.GetHotelIndex(resources.IndexName);
            ((ISearchFieldAttribute)new SearchableFieldAttribute()).SetField(expectedIndex.Fields.Where(f => f.Name.Equals("descriptionVector")).FirstOrDefault());

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex actualIndex = await client.CreateIndexAsync(expectedIndex);

            Assert.AreEqual(expectedIndex.Name, actualIndex.Name);
            Assert.That(actualIndex.Fields, Is.EqualTo(expectedIndex.Fields).Using(SearchFieldComparer.Shared));
            Assert.AreEqual(expectedIndex.Suggesters.Count, actualIndex.Suggesters.Count);
            Assert.AreEqual(expectedIndex.Suggesters[0].Name, actualIndex.Suggesters[0].Name);
            Assert.AreEqual(expectedIndex.ScoringProfiles.Count, actualIndex.ScoringProfiles.Count);
            Assert.AreEqual(expectedIndex.ScoringProfiles[0].Name, actualIndex.ScoringProfiles[0].Name);
        }

        [Test]
        [SyncOnly]
        public void UpdateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateIndex(null));
            Assert.AreEqual("index", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateIndexAsync(null));
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_09_01)]
        public async Task UpdateIndex()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            resources.IndexName = Recording.Random.GetName();
            SearchIndex initialIndex = SearchResources.GetHotelIndex(resources.IndexName);

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex createdIndex = await client.CreateIndexAsync(initialIndex);

            string analyzerName = "asciiTags";

            createdIndex.Analyzers.Add(
                new PatternAnalyzer(analyzerName)
                {
                    Pattern = @"[0-9a-z]+",
                    Flags =
                    {
                        RegexFlag.CaseInsensitive,
                        RegexFlag.Multiline,
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
                    AnalyzerName = analyzerName,
                    IsFacetable = true,
                    IsFilterable = true,
                });

            SearchIndex updatedIndex = await client.CreateOrUpdateIndexAsync(
                createdIndex,
                allowIndexDowntime: true,
                onlyIfUnchanged: true);

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
        [SyncOnly]
        public void GetIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetIndex(null));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetIndexAsync(null));
            Assert.AreEqual("indexName", ex.ParamName);
        }

        [Test]
        public async Task GetIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex index = await client.GetIndexAsync(resources.IndexName);

            // TODO: Replace with comparison of actual SearchIndex once test framework uses Azure.Search.Documents instead.
            Assert.AreEqual(resources.IndexName, index.Name);
            Assert.AreEqual(15, index.Fields.Count);
        }

        [Test]
        public async Task GetIndexes()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

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

            SearchIndexClient client = resources.GetIndexClient();
            AsyncPageable<SearchIndex> pageable = client.GetIndexesAsync();

            string continuationToken = Recording.GenerateId();
            IAsyncEnumerator<Page<SearchIndex>> e = pageable.AsPages(continuationToken).GetAsyncEnumerator();

            // Given a continuationToken above, this actually starts with the second page.
            Assert.ThrowsAsync<NotSupportedException>(async () => await e.MoveNextAsync());
        }

        [Test]
        public async Task GetIndexNames()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            bool found = false;
            await foreach (string name in client.GetIndexNamesAsync())
            {
                found |= string.Equals(resources.IndexName, name, StringComparison.InvariantCultureIgnoreCase);
            }

            Assert.IsTrue(found, "Shared index name not found");
        }

        [Test]
        [SyncOnly]
        public void DeleteIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteIndex((string)null));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteIndex((SearchIndex)null));
            Assert.AreEqual("index", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteIndexAsync((string)null));
            Assert.AreEqual("indexName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteIndexAsync((SearchIndex)null));
            Assert.AreEqual("index", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void CreateSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateSynonymMap(null));
            Assert.AreEqual("synonymMap", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateSynonymMapAsync(null));
            Assert.AreEqual("synonymMap", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void UpdateSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateSynonymMap(null));
            Assert.AreEqual("synonymMap", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateSynonymMapAsync(null));
            Assert.AreEqual("synonymMap", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void GetSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetSynonymMap(null));
            Assert.AreEqual("synonymMapName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetSynonymMapAsync(null));
            Assert.AreEqual("synonymMapName", ex.ParamName);
        }

        [Test]
        [SyncOnly]
        public void DeleteSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteSynonymMap((string)null));
            Assert.AreEqual("synonymMapName", ex.ParamName);

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteSynonymMap((SynonymMap)null));
            Assert.AreEqual("synonymMap", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteSynonymMapAsync((string)null));
            Assert.AreEqual("synonymMapName", ex.ParamName);

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteSynonymMapAsync((SynonymMap)null));
            Assert.AreEqual("synonymMap", ex.ParamName);
        }

        [Test]
        public async Task CrudSynonymMaps()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            string synonymMapName = Recording.Random.GetName();

            SearchIndexClient client = resources.GetIndexClient();

            SynonymMap createdMap = await client.CreateSynonymMapAsync(new SynonymMap(synonymMapName, "msft=>Microsoft"));
            Assert.AreEqual(synonymMapName, createdMap.Name);
            Assert.AreEqual("solr", createdMap.Format);
            Assert.AreEqual("msft=>Microsoft", createdMap.Synonyms);

            SynonymMap updatedMap = await client.CreateOrUpdateSynonymMapAsync(
                new SynonymMap(synonymMapName, "ms,msft=>Microsoft")
                {
                    ETag = createdMap.ETag,
                },
                onlyIfUnchanged: true);
            Assert.AreEqual(synonymMapName, updatedMap.Name);
            Assert.AreEqual("solr", updatedMap.Format);
            Assert.AreEqual("ms,msft=>Microsoft", updatedMap.Synonyms);

            RequestFailedException ex = await CatchAsync<RequestFailedException>(async () =>
                await client.CreateOrUpdateSynonymMapAsync(
                    new SynonymMap(synonymMapName, "ms,msft=>Microsoft")
                    {
                        ETag = createdMap.ETag,
                    },
                    onlyIfUnchanged: true));
            Assert.AreEqual((int)HttpStatusCode.PreconditionFailed, ex.Status);

            Response<IReadOnlyList<string>> names = await client.GetSynonymMapNamesAsync();
            foreach (string name in names.Value)
            {
                if (string.Equals(updatedMap.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    SynonymMap fetchedMap = await client.GetSynonymMapAsync(name);
                    Assert.AreEqual(updatedMap.Synonyms, fetchedMap.Synonyms);
                }
            }

            await client.DeleteSynonymMapAsync(updatedMap, onlyIfUnchanged: true);
        }

        [Test]
        public async Task AnalyzeText()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            AnalyzeTextOptions request = new AnalyzeTextOptions("The quick brown fox jumped over the lazy dog.", LexicalTokenizerName.Whitespace);

            Response<IReadOnlyList<AnalyzedTokenInfo>> result = await client.AnalyzeTextAsync(resources.IndexName, request);
            IReadOnlyList<AnalyzedTokenInfo> tokens = result.Value;

            Assert.AreEqual(new[] { "The", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog." }, tokens.Select(t => t.Token));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_09_01)]
        public async Task AnalyzeTextWithNormalizer()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            AnalyzeTextOptions request = new("I dARe YoU tO reAd It IN A nORmAl vOiCE.", LexicalNormalizerName.Lowercase);

            Response<IReadOnlyList<AnalyzedTokenInfo>> result = await client.AnalyzeTextAsync(resources.IndexName, request);
            IReadOnlyList<AnalyzedTokenInfo> tokens = result.Value;

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual("i dare you to read it in a normal voice.", tokens[0].Token);

            request = new("Item ① in my ⑽ point rant is that 75⁰F is uncomfortably warm.", LexicalNormalizerName.AsciiFolding);

            result = await client.AnalyzeTextAsync(resources.IndexName, request);
            tokens = result.Value;

            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual("Item 1 in my (10) point rant is that 750F is uncomfortably warm.", tokens[0].Token);
        }

        [Test]
        public async Task SetScoringProfile()
        {
            // Testing: https://github.com/Azure/azure-sdk-for-net/issues/16570

            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            string indexName = Recording.Random.GetName();
            string scoringProfileName = Recording.Random.GetName();

            // Make sure the index, if created, is cleaned up.
            resources.IndexName = indexName;

            SearchIndex index = new SearchIndex(indexName)
            {
                Fields =
                {
                    new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
                    new SearchableField("title") { IsFilterable = true, IsSortable = false },
                },
                DefaultScoringProfile = scoringProfileName,
                ScoringProfiles =
                {
                    new ScoringProfile(scoringProfileName)
                    {
                        TextWeights = new TextWeights(new Dictionary<string, double>
                        {
                            { "title", 2 },
                        }),
                    },
                },
            };

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex createdIndex = await client.CreateIndexAsync(index);

            Assert.AreEqual(1, createdIndex.ScoringProfiles.Count);
            Assert.AreEqual(scoringProfileName, createdIndex.ScoringProfiles[0].Name);
        }
    }
}
