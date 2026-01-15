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
using Azure.Search.Documents.KnowledgeBases.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2024_07_01, SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
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
            Assert.That(service.Endpoint, Is.EqualTo(endpoint));
            Assert.That(service.ServiceName, Is.EqualTo(serviceName));

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
            Assert.That(client.Endpoint, Is.EqualTo(endpoint));
            Assert.That(client.ServiceName, Is.EqualTo(serviceName));
            Assert.That(client.IndexName, Is.EqualTo(indexName));

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
            Assert.That(custom.RequestCount, Is.EqualTo(0));

            SearchClientOptions options = new SearchClientOptions(ServiceVersion);
            options.AddPolicy(custom, HttpPipelinePosition.PerCall);
            SearchIndexClient serviceClient = resources.GetIndexClient(options);

            SearchClient client = serviceClient.GetSearchClient(resources.IndexName);
            _ = await client.GetDocumentCountAsync();

            Assert.That(custom.RequestCount, Is.EqualTo(1));
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
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task GetServiceStatistics()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();
            Response<SearchServiceStatistics> response = await client.GetServiceStatisticsAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
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
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task GetIndexStatsSummary()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();
            Response<ListIndexStatsSummary> response = await client.GetIndexStatsSummaryAsync();
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.IsNotNull(response.Value);
            Assert.IsNotNull(response.Value.IndexesStatistics);
            Assert.GreaterOrEqual(response.Value.IndexesStatistics.Count, 1);
            Assert.That(response.Value.IndexesStatistics.Any(summary => summary.Name == resources.IndexName), Is.True);
        }

        [Test]
        [SyncOnly]
        public void CreateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateIndex(null));
            Assert.That(ex.ParamName, Is.EqualTo("index"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateIndexAsync(null));
            Assert.That(ex.ParamName, Is.EqualTo("index"));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task CreateIndex()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            resources.IndexName = Recording.Random.GetName(8);
            SearchIndex expectedIndex = SearchResources.GetHotelIndex(resources.IndexName);
            ((ISearchFieldAttribute)new SearchableFieldAttribute()).SetField(expectedIndex.Fields.Where(f => f.Name.Equals("descriptionVector")).FirstOrDefault());

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex actualIndex = await client.CreateIndexAsync(expectedIndex);

            Assert.That(actualIndex.Name, Is.EqualTo(expectedIndex.Name));
            Assert.That(actualIndex.Fields, Is.EqualTo(expectedIndex.Fields).Using(SearchFieldComparer.Shared));
            Assert.That(actualIndex.Suggesters.Count, Is.EqualTo(expectedIndex.Suggesters.Count));
            Assert.That(actualIndex.Suggesters[0].Name, Is.EqualTo(expectedIndex.Suggesters[0].Name));
            Assert.That(actualIndex.ScoringProfiles.Count, Is.EqualTo(expectedIndex.ScoringProfiles.Count));
            Assert.That(actualIndex.ScoringProfiles[0].Name, Is.EqualTo(expectedIndex.ScoringProfiles[0].Name));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task CrudIndexWithProductScoringAggregation()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            resources.IndexName = Recording.Random.GetName(8);
            SearchIndex expectedIndex = SearchResources.GetHotelIndex(resources.IndexName);

            expectedIndex.ScoringProfiles[0].FunctionAggregation = ScoringFunctionAggregation.Product;

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex actualIndex = await client.CreateIndexAsync(expectedIndex);

            Assert.That(actualIndex.ScoringProfiles.Count, Is.EqualTo(expectedIndex.ScoringProfiles.Count));
            Assert.That(actualIndex.ScoringProfiles[0].Name, Is.EqualTo(expectedIndex.ScoringProfiles[0].Name));
            Assert.That(actualIndex.ScoringProfiles[0].FunctionAggregation, Is.EqualTo(ScoringFunctionAggregation.Product));

            SearchIndex fetchedIndex = await client.GetIndexAsync(resources.IndexName);
            Assert.That(fetchedIndex.ScoringProfiles[0].FunctionAggregation, Is.EqualTo(ScoringFunctionAggregation.Product));

            actualIndex.ScoringProfiles[0].FunctionAggregation = ScoringFunctionAggregation.Sum;
            SearchIndex updatedIndex = await client.CreateOrUpdateIndexAsync(actualIndex);
            Assert.That(updatedIndex.ScoringProfiles[0].FunctionAggregation, Is.EqualTo(ScoringFunctionAggregation.Sum));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task CrudIndexWithPurviewConfiguration()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            resources.IndexName = Recording.Random.GetName(8);
            SearchIndex expectedIndex = SearchResources.GetHotelIndex(resources.IndexName);
            expectedIndex.PurviewEnabled = true;
            var sensitivityLabelField = new SimpleField("sensitivityLabel", SearchFieldDataType.String)
            {
                IsFilterable = true,
                SensitivityLabel = true
            };
            expectedIndex.Fields.Add(sensitivityLabelField);

            SearchIndexClient client = resources.GetIndexClient();
            await client.CreateIndexAsync(expectedIndex);

            SearchIndex fetchedIndex = await client.GetIndexAsync(resources.IndexName);
            Assert.That(fetchedIndex.PurviewEnabled, Is.EqualTo(true));
            Assert.That(fetchedIndex.Fields.First(f => f.Name == "sensitivityLabel") is SearchField sf && sf.SensitivityLabel == true, Is.True);

            fetchedIndex.PurviewEnabled = false;
            var updatedIndex = await client.CreateOrUpdateIndexAsync(fetchedIndex);

            fetchedIndex = await client.GetIndexAsync(fetchedIndex.Name);
            Assert.That(fetchedIndex.PurviewEnabled, Is.EqualTo(false));
        }

        [Test]
        [SyncOnly]
        public void UpdateIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateIndex(null));
            Assert.That(ex.ParamName, Is.EqualTo("index"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateIndexAsync(null));
            Assert.That(ex.ParamName, Is.EqualTo("index"));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
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

            Assert.That(updatedIndex.Name, Is.EqualTo(createdIndex.Name));
            Assert.That(updatedIndex.Fields, Is.EqualTo(updatedIndex.Fields).Using(SearchFieldComparer.Shared));
            Assert.That(updatedIndex.Suggesters.Count, Is.EqualTo(createdIndex.Suggesters.Count));
            Assert.That(updatedIndex.Suggesters[0].Name, Is.EqualTo(createdIndex.Suggesters[0].Name));
            Assert.That(updatedIndex.ScoringProfiles.Count, Is.EqualTo(createdIndex.ScoringProfiles.Count));
            Assert.That(updatedIndex.ScoringProfiles[0].Name, Is.EqualTo(createdIndex.ScoringProfiles[0].Name));
            Assert.That(updatedIndex.Analyzers.Count, Is.EqualTo(createdIndex.Analyzers.Count));
            Assert.That(updatedIndex.Analyzers[0].Name, Is.EqualTo(createdIndex.Analyzers[0].Name));
        }

        [Test]
        [SyncOnly]
        public void GetIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetIndex(null));
            Assert.That(ex.ParamName, Is.EqualTo("indexName"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetIndexAsync(null));
            Assert.That(ex.ParamName, Is.EqualTo("indexName"));
        }

        [Test]
        public async Task GetIndex()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();
            SearchIndex index = await client.GetIndexAsync(resources.IndexName);

            // TODO: Replace with comparison of actual SearchIndex once test framework uses Azure.Search.Documents instead.
            Assert.That(index.Name, Is.EqualTo(resources.IndexName));
            Assert.That(index.Fields.Count, Is.EqualTo(15));
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

            Assert.That(found, Is.True, "Shared index not found");
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

            Assert.That(found, Is.True, "Shared index name not found");
        }

        [Test]
        [SyncOnly]
        public void DeleteIndexParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteIndex((string)null));
            Assert.That(ex.ParamName, Is.EqualTo("indexName"));

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteIndex((SearchIndex)null));
            Assert.That(ex.ParamName, Is.EqualTo("index"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteIndexAsync((string)null));
            Assert.That(ex.ParamName, Is.EqualTo("indexName"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteIndexAsync((SearchIndex)null));
            Assert.That(ex.ParamName, Is.EqualTo("index"));
        }

        [Test]
        [SyncOnly]
        public void CreateSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateSynonymMap(null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMap"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateSynonymMapAsync(null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMap"));
        }

        [Test]
        [SyncOnly]
        public void UpdateSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.CreateOrUpdateSynonymMap(null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMap"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.CreateOrUpdateSynonymMapAsync(null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMap"));
        }

        [Test]
        [SyncOnly]
        public void GetSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.GetSynonymMap(null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMapName"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.GetSynonymMapAsync(null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMapName"));
        }

        [Test]
        [SyncOnly]
        public void DeleteSynonymMapParameterValidation()
        {
            var endpoint = new Uri($"https://my-svc-name.search.windows.net");
            var service = new SearchIndexClient(endpoint, new AzureKeyCredential("fake"));

            ArgumentException ex = Assert.Throws<ArgumentNullException>(() => service.DeleteSynonymMap((string)null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMapName"));

            ex = Assert.Throws<ArgumentNullException>(() => service.DeleteSynonymMap((SynonymMap)null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMap"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteSynonymMapAsync((string)null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMapName"));

            ex = Assert.ThrowsAsync<ArgumentNullException>(() => service.DeleteSynonymMapAsync((SynonymMap)null));
            Assert.That(ex.ParamName, Is.EqualTo("synonymMap"));
        }

        [Test]
        public async Task CrudSynonymMaps()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            string synonymMapName = Recording.Random.GetName();

            SearchIndexClient client = resources.GetIndexClient();

            SynonymMap createdMap = await client.CreateSynonymMapAsync(new SynonymMap(synonymMapName, "msft=>Microsoft"));
            Assert.That(createdMap.Name, Is.EqualTo(synonymMapName));
            Assert.That(createdMap.Format, Is.EqualTo("solr"));
            Assert.That(createdMap.Synonyms, Is.EqualTo("msft=>Microsoft"));

            SynonymMap updatedMap = await client.CreateOrUpdateSynonymMapAsync(
                new SynonymMap(synonymMapName, "ms,msft=>Microsoft")
                {
                    ETag = createdMap.ETag,
                },
                onlyIfUnchanged: true);
            Assert.That(updatedMap.Name, Is.EqualTo(synonymMapName));
            Assert.That(updatedMap.Format, Is.EqualTo("solr"));
            Assert.That(updatedMap.Synonyms, Is.EqualTo("ms,msft=>Microsoft"));

            RequestFailedException ex = await CatchAsync<RequestFailedException>(async () =>
                await client.CreateOrUpdateSynonymMapAsync(
                    new SynonymMap(synonymMapName, "ms,msft=>Microsoft")
                    {
                        ETag = createdMap.ETag,
                    },
                    onlyIfUnchanged: true));
            Assert.That(ex.Status, Is.EqualTo((int)HttpStatusCode.PreconditionFailed));

            Response<IReadOnlyList<string>> names = await client.GetSynonymMapNamesAsync();
            foreach (string name in names.Value)
            {
                if (string.Equals(updatedMap.Name, name, StringComparison.OrdinalIgnoreCase))
                {
                    SynonymMap fetchedMap = await client.GetSynonymMapAsync(name);
                    Assert.That(fetchedMap.Synonyms, Is.EqualTo(updatedMap.Synonyms));
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

            Assert.That(tokens.Select(t => t.Token), Is.EqualTo(new[] { "The", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog." }));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task AnalyzeTextWithNormalizer()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            AnalyzeTextOptions request = new("I dARe YoU tO reAd It IN A nORmAl vOiCE.")
            {
                NormalizerName = LexicalNormalizerName.Lowercase
            };

            Response<IReadOnlyList<AnalyzedTokenInfo>> result = await client.AnalyzeTextAsync(resources.IndexName, request);
            IReadOnlyList<AnalyzedTokenInfo> tokens = result.Value;

            Assert.That(tokens.Count, Is.EqualTo(1));
            Assert.That(tokens[0].Token, Is.EqualTo("i dare you to read it in a normal voice."));

            request = new("Item ① in my ⑽ point rant is that 75⁰F is uncomfortably warm.")
            {
                NormalizerName = LexicalNormalizerName.AsciiFolding
            };

            result = await client.AnalyzeTextAsync(resources.IndexName, request);
            tokens = result.Value;

            Assert.That(tokens.Count, Is.EqualTo(1));
            Assert.That(tokens[0].Token, Is.EqualTo("Item 1 in my (10) point rant is that 750F is uncomfortably warm."));
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

            Assert.That(createdIndex.ScoringProfiles.Count, Is.EqualTo(1));
            Assert.That(createdIndex.ScoringProfiles[0].Name, Is.EqualTo(scoringProfileName));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string deploymentName = "gpt-4.1";
            SearchIndexClient client = resources.GetIndexClient();
            var knowledgeBaseName = Recording.Random.GetName(8);
            var knowledgeSourceName = Recording.Random.GetName(8);

            SearchIndexKnowledgeSource indexKnowledgeSource = new(knowledgeSourceName, new(resources.IndexName));
            KnowledgeSource knowledgeSource = await client.CreateKnowledgeSourceAsync(indexKnowledgeSource);
            var knowledgeSources = new List<KnowledgeSourceReference>
            {
                new KnowledgeSourceReference(knowledgeSource.Name),
            };

            var knowledgeBase = new KnowledgeBase(
                knowledgeBaseName,
                knowledgeSources,
                new List<KnowledgeBaseModel>{
                    new KnowledgeBaseAzureOpenAIModel(
                        new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                            ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY"),
                            DeploymentName = deploymentName,
                            ModelName = AzureOpenAIModelName.Gpt41
                        })
                },
                new KnowledgeRetrievalLowReasoningEffort(),
                KnowledgeRetrievalOutputMode.AnswerSynthesis,
                null,
                null,
                "Description of the Knowledge Base",
                null,
                "Summarize the answer into three sentences.",
                null);

            KnowledgeBase actualAgent = await client.CreateKnowledgeBaseAsync(knowledgeBase);
            KnowledgeBase expectedAgent = knowledgeBase;

            Assert.That(actualAgent.Name, Is.EqualTo(expectedAgent.Name));
            Assert.That(actualAgent.Models, Is.EqualTo(expectedAgent.Models).Using(KnowledgeBaseModelComparer.Instance));
            Assert.That(actualAgent.KnowledgeSources, Is.EqualTo(expectedAgent.KnowledgeSources).Using(KnowledgeSourceReferenceComparer.Instance));

            await client.DeleteKnowledgeBaseAsync(knowledgeBaseName);
            await client.DeleteKnowledgeSourceAsync(knowledgeSource.Name);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        //[PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CrudKnowledgeBaseWithReasoningEffort()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string deploymentName = "gpt-4.1";
            SearchIndexClient client = resources.GetIndexClient();
            var knowledgeBaseName = Recording.Random.GetName(8);
            var knowledgeSourceName = Recording.Random.GetName(8);

            SearchIndexKnowledgeSource indexKnowledgeSource = new(knowledgeSourceName, new(resources.IndexName));
            KnowledgeSource knowledgeSource = await client.CreateKnowledgeSourceAsync(indexKnowledgeSource);
            var knowledgeSources = new List<KnowledgeSourceReference>
            {
                new KnowledgeSourceReference(knowledgeSource.Name),
            };

            var knowledgeBase = new KnowledgeBase(knowledgeBaseName, knowledgeSources)
            {
                RetrievalInstructions = "Retrieval instructions",
                AnswerInstructions = "Summarize the answer into three sentences.",
                Description = "Description of the Knowledge Base",
                RetrievalReasoningEffort = new KnowledgeRetrievalMediumReasoningEffort(),
                OutputMode = KnowledgeRetrievalOutputMode.AnswerSynthesis
            };
            knowledgeBase.Models.Add(
                    new KnowledgeBaseAzureOpenAIModel(
                        new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(TestEnvironment.OpenAIEndpoint),
                            ApiKey = TestEnvironment.OpenAIKey,
                            DeploymentName = deploymentName,
                            ModelName = AzureOpenAIModelName.Gpt41
                        }));

            // Create and compare reasoning effort
            KnowledgeBase actualAgent = await client.CreateKnowledgeBaseAsync(knowledgeBase);
            Assert.IsNotNull(actualAgent.RetrievalReasoningEffort);
            Assert.IsInstanceOf<KnowledgeRetrievalMediumReasoningEffort>(actualAgent.RetrievalReasoningEffort);

            // Update to LowReasoningEffort
            actualAgent.RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort();
            KnowledgeBase updatedAgent = await client.CreateOrUpdateKnowledgeBaseAsync(actualAgent);
            Assert.IsNotNull(updatedAgent.RetrievalReasoningEffort);
            Assert.IsInstanceOf<KnowledgeRetrievalLowReasoningEffort>(updatedAgent.RetrievalReasoningEffort);

            // Get and verify the reasoning effort persisted
            KnowledgeBase fetchedAgent = await client.GetKnowledgeBaseAsync(knowledgeBaseName);
            Assert.IsNotNull(fetchedAgent.RetrievalReasoningEffort);
            Assert.IsInstanceOf<KnowledgeRetrievalLowReasoningEffort>(fetchedAgent.RetrievalReasoningEffort);

            await client.DeleteKnowledgeBaseAsync(knowledgeBaseName);
            await client.DeleteKnowledgeSourceAsync(knowledgeSource.Name);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task DeleteKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);
            SearchIndexClient client = resources.GetIndexClient();

            await client.DeleteKnowledgeBaseAsync(resources.KnowledgeBaseName);

            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.GetKnowledgeBaseAsync(resources.KnowledgeBaseName);
            });

            Assert.That(ex.Status, Is.EqualTo(404));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task UpdateKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            string deploymentName = "gpt-4.1";
            SearchIndexClient client = resources.GetIndexClient();
            var knowledgeBaseName = Recording.Random.GetName(8);
            var knowledgeSourceName = Recording.Random.GetName(8);

            SearchIndexKnowledgeSource indexKnowledgeSource = new(knowledgeSourceName, new(resources.IndexName));
            KnowledgeSource knowledgeSource = await client.CreateKnowledgeSourceAsync(indexKnowledgeSource);

            var knowledgeBase = new KnowledgeBase(
                knowledgeBaseName,
                knowledgeSources: new List<KnowledgeSourceReference>
                {
                    new KnowledgeSourceReference(knowledgeSource.Name),
                },
                models: new List<KnowledgeBaseModel>{
                    new KnowledgeBaseAzureOpenAIModel(
                        new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                            ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY"),
                            DeploymentName = deploymentName,
                            ModelName = AzureOpenAIModelName.Gpt41
                        })
                },
                retrievalReasoningEffort: new KnowledgeRetrievalLowReasoningEffort(),
                KnowledgeRetrievalOutputMode.AnswerSynthesis,
                eTag: null,
                encryptionKey: null,
                description: "Description of the Knowledge Base",
                retrievalInstructions: "Retrieval Instructions",
                answerInstructions: "Summarize the answer into three sentences.",
                serializedAdditionalRawData: null
                );

            KnowledgeBase createdAgent = await client.CreateKnowledgeBaseAsync(knowledgeBase);
            createdAgent.Description = "Updated description";
            KnowledgeBase updatedAgent = await client.CreateOrUpdateKnowledgeBaseAsync(createdAgent);

            Assert.That(updatedAgent.Name, Is.EqualTo(createdAgent.Name));
            Assert.That(updatedAgent.Description, Is.EqualTo(createdAgent.Description));
            Assert.That(createdAgent.Models, Is.EqualTo(updatedAgent.Models).Using(KnowledgeBaseModelComparer.Instance));
            Assert.That(createdAgent.KnowledgeSources, Is.EqualTo(updatedAgent.KnowledgeSources).Using(KnowledgeSourceReferenceComparer.Instance));

            await client.DeleteKnowledgeBaseAsync(knowledgeBaseName);
            await client.DeleteKnowledgeSourceAsync(knowledgeSource.Name);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task GetKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            SearchIndexClient client = resources.GetIndexClient();
            KnowledgeBase agent = await client.GetKnowledgeBaseAsync(resources.KnowledgeBaseName);

            Assert.That(agent.Name, Is.EqualTo(resources.KnowledgeBaseName));
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task GetKnowledgeBases()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            bool found = false;
            await foreach (KnowledgeBase agent in client.GetKnowledgeBasesAsync())
            {
                found |= string.Equals(resources.KnowledgeBaseName, agent.Name, StringComparison.InvariantCultureIgnoreCase);
            }

            Assert.That(found, Is.True, "Knowledge agent not found");
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task CrudRemoteSharePointKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            var remoteSharePointKnowledgeSource = new RemoteSharePointKnowledgeSource("sharepoint");

            KnowledgeSource createdKs = await client.CreateKnowledgeSourceAsync(remoteSharePointKnowledgeSource);
            Assert.IsNotNull(createdKs);

            createdKs.Description = "Updated description";
            RemoteSharePointKnowledgeSource updatedKs = (RemoteSharePointKnowledgeSource)await client.CreateOrUpdateKnowledgeSourceAsync(createdKs);
            Assert.That(updatedKs.Description, Is.EqualTo("Updated description"));

            KnowledgeSource fetchedKs = await client.GetKnowledgeSourceAsync(remoteSharePointKnowledgeSource.Name);
            Assert.IsNotNull(fetchedKs);
            Assert.That(fetchedKs.Description, Is.EqualTo("Updated description"));

            await client.DeleteKnowledgeSourceAsync(remoteSharePointKnowledgeSource.Name);
        }

        [Test]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2025_11_01_Preview)]
        public async Task CrudWebKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            SearchIndexClient client = resources.GetIndexClient();

            var webKs = new WebKnowledgeSource("web") { WebParameters = new WebKnowledgeSourceParameters() { Domains = new WebKnowledgeSourceDomains() } };
            webKs.WebParameters.Domains.AllowedDomains.Add(new WebKnowledgeSourceDomain("example.com"));
            webKs.WebParameters.Domains.BlockedDomains.Add(new WebKnowledgeSourceDomain("blocked.com"));

            KnowledgeSource createdKs = await client.CreateKnowledgeSourceAsync(webKs);
            Assert.IsNotNull(createdKs);
            Assert.That(createdKs is WebKnowledgeSource, Is.True);
            var createdWebKs = createdKs as WebKnowledgeSource;
            Assert.That(createdWebKs.WebParameters.Domains.AllowedDomains.Count, Is.EqualTo(1));
            Assert.That(createdWebKs.WebParameters.Domains.BlockedDomains.Count, Is.EqualTo(1));

            createdWebKs.Description = "Updated description";
            WebKnowledgeSource updatedKs = (WebKnowledgeSource)await client.CreateOrUpdateKnowledgeSourceAsync(createdWebKs);
            Assert.That(updatedKs.Description, Is.EqualTo("Updated description"));
            Assert.That(updatedKs.WebParameters.Domains.AllowedDomains.Count, Is.EqualTo(1));
            Assert.That(updatedKs.WebParameters.Domains.BlockedDomains.Count, Is.EqualTo(1));

            KnowledgeSource fetchedKs = await client.GetKnowledgeSourceAsync(webKs.Name);
            Assert.IsNotNull(fetchedKs);
            Assert.That(fetchedKs.Description, Is.EqualTo("Updated description"));

            await client.DeleteKnowledgeSourceAsync(webKs.Name);
        }
    }
}
