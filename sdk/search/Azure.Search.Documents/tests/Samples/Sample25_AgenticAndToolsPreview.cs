// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    public partial class NovemberPreviewSamples
    {
        [Test]
        [LiveOnly]
        public async Task AgenticSearchAndMicrosoftRetriever()
        {
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string indexName = PreviewName();
            await indexClient.CreateIndexAsync(PreviewHotelIndex(indexName));
            resources.TrackIndex(indexName);
            SearchClient searchClient = CreatePreviewSearchClient(resources, indexName);
            await UploadPreviewDocumentsAsync(searchClient, PreviewHotels());

            #region Snippet:Azure_Search_Documents_Sample25_AgenticSearch
            SearchResults<SearchDocument> search = await searchClient.SearchAsync<SearchDocument>(
                "Find hotel guest benefits including complimentary wireless internet and breakfast.",
                new SearchOptions
                {
                    QueryType = SearchQueryType.Agentic,
                    Debug = QueryDebugMode.Agentic,
                    SemanticSearch = new SemanticSearchOptions { SemanticConfigurationName = "hotels" },
                    AgenticOptions = new AgenticSearchOptions { MaxRuntimeInSeconds = 30 },
                    Select = { "id", "title", "content" },
                    Size = 3
                });
            await foreach (SearchResult<SearchDocument> hit in search.GetResultsAsync())
            {
                Console.WriteLine(hit.Document["title"]);
            }
            AgenticSearchDebugInfo debug = search.DebugInfo.Agentic;
            Console.WriteLine($"Termination: {debug.TerminationReason}");
            Console.WriteLine($"Planning tokens: {debug.Usage.AgenticPlanningTokens}; reasoning tokens: {debug.Usage.ReasoningTokens}");
            // Usage includes work on candidates that were not returned; do not add it again as separate billing.
            #endregion
            Assert.That((await ReadPreviewResultsAsync(search)).Count, Is.GreaterThan(0));
            Assert.That(debug.TerminationReason.ToString(), Is.Not.EqualTo("modelFailed"));
            Assert.That(debug.Usage.AgenticPlanningTokens + debug.Usage.ReasoningTokens, Is.GreaterThan(0));
            Assert.That(debug.SubQueries.All(query => !string.IsNullOrEmpty(query.Search) && query.Iteration >= 1), Is.True);

            string sourceName = indexName + "-source";
            string baseName = indexName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            #region Snippet:Azure_Search_Documents_Sample25_MicrosoftRetriever
            await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(
                sourceName, new SearchIndexKnowledgeSourceParameters(indexName)));
#if !SNIPPET
            resources.TrackSource(sourceName);
#endif
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(
                baseName, new[] { new KnowledgeSourceReference(sourceName) })
            {
                Models = { new KnowledgeBaseMicrosoftRetriever1Model() },
                RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            KnowledgeBaseRetrievalResponse retrieved = await retrievalClient.RetrieveAsync(new KnowledgeBaseRetrievalRequest
            {
                Intents = { new KnowledgeRetrievalSemanticIntent("hotel guest benefits") },
                IncludeActivity = true
            });
            foreach (KnowledgeBaseSearchIndexReference reference in retrieved.References.OfType<KnowledgeBaseSearchIndexReference>())
            {
                Console.WriteLine($"Retrieved hotel: {reference.DocKey}");
            }
            #endregion
            KnowledgeBase stored = await indexClient.GetKnowledgeBaseAsync(baseName);
            Assert.That(stored.Models.Single(), Is.TypeOf<KnowledgeBaseMicrosoftRetriever1Model>());
            AssertPreviewReferences(retrieved, "hotel-ca-1", "hotel-ca-2", "hotel-us-1");
        }

        [Test]
        [LiveOnly]
        public async Task KnowledgeBaseToolsSelectAndClear()
        {
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string indexName = PreviewName();
            await indexClient.CreateIndexAsync(PreviewHotelIndex(indexName));
            resources.TrackIndex(indexName);
            await UploadPreviewDocumentsAsync(CreatePreviewSearchClient(resources, indexName), PreviewHotels());
            string sourceName = indexName + "-source";
            string baseName = indexName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;
            await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(
                sourceName, new SearchIndexKnowledgeSourceParameters(indexName)));
            resources.TrackSource(sourceName);

            #region Snippet:Azure_Search_Documents_Sample25_KnowledgeBaseTools
            KnowledgeBase knowledgeBase = new KnowledgeBase(baseName, new[] { new KnowledgeSourceReference(sourceName) })
            {
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
                Tools =
                {
                    new KnowledgeBaseTool("canada-hotels", "Find hotel guest benefits in Canada.",
                        new[]
                        {
                            new KnowledgeBaseToolKnowledgeSourceReference(sourceName)
                            {
                                FilterAddOn = "country eq 'Canada'",
                                AlwaysQuerySource = true,
                                FailOnError = true
                            }
                        })
                    {
                        RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
                        RetrieveDefaults = new KnowledgeBaseRetrieveDefaults { MaxOutputDocuments = 10 }
                    }
                }
            };
            await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
            {
                Intents = { new KnowledgeRetrievalSemanticIntent("hotel guest benefits") },
                ToolName = "canada-hotels",
                IncludeActivity = true
            };
            KnowledgeBaseRetrievalResponse selected = await retrievalClient.RetrieveAsync(request);
            foreach (KnowledgeBaseSearchIndexReference reference in selected.References.OfType<KnowledgeBaseSearchIndexReference>())
            {
                Console.WriteLine($"Tool-scoped hotel: {reference.DocKey}");
            }
            #endregion
            AssertPreviewReferences(selected, "hotel-ca-1", "hotel-ca-2");

            KnowledgeBase stored = await indexClient.GetKnowledgeBaseAsync(baseName);
            Assert.That(stored.Tools.Single().Name, Is.EqualTo("canada-hotels"));
            stored.Tools.Clear();
            await indexClient.CreateOrUpdateKnowledgeBaseAsync(stored, onlyIfUnchanged: true);
            Assert.That((await indexClient.GetKnowledgeBaseAsync(baseName)).Value.Tools, Is.Empty);
            request.ToolName = null;
            AssertPreviewReferences((await retrievalClient.RetrieveAsync(request)).Value,
                "hotel-ca-1", "hotel-ca-2", "hotel-us-1");
        }

        [Test]
        [LiveOnly]
        public async Task QueryHintsAutomaticallyGroundFacetValues()
        {
            KnowledgeBaseAzureOpenAIModel model = PreviewChatModel();
            await using PreviewResources resources = CreatePreviewResources();
            SearchIndexClient indexClient = resources.Indexes;
            string indexName = PreviewName();
            await indexClient.CreateIndexAsync(PreviewHotelIndex(indexName));
            resources.TrackIndex(indexName);
            SearchClient searchClient = CreatePreviewSearchClient(resources, indexName);
            await UploadPreviewDocumentsAsync(searchClient, PreviewHotels());
            string sourceName = indexName + "-source";
            string baseName = indexName + "-kb";
            Uri endpoint = resources.Endpoint;
            AzureKeyCredential credential = resources.Credential;

            #region Snippet:Azure_Search_Documents_Sample25_QueryHintsAutoConfiguration
            SearchResults<SearchDocument> facets = await searchClient.SearchAsync<SearchDocument>("*",
                new SearchOptions { Facets = { "country,count:16" }, Size = 0 });
            Console.WriteLine($"Available countries: {string.Join(", ", facets.Facets["country"].Select(facet => facet.Value))}");
            SearchIndexKnowledgeSource source = new SearchIndexKnowledgeSource(
                sourceName, new SearchIndexKnowledgeSourceParameters(indexName)
                {
                    QueryHints = new SearchIndexKnowledgeSourceQueryHints
                    {
                        Filters =
                        {
                            new SearchIndexKnowledgeSourceFilterHint("country")
                            {
                                AutoConfiguration = new SearchIndexKnowledgeSourceFilterHintAutoConfiguration
                                {
                                    CacheTtl = 60,
                                    MaxFacetValueCount = 16
                                },
                                FilterInstructions = "When a country is specified, filter country using the exact resolved facet value."
                            }
                        }
                    }
                });
            await indexClient.CreateKnowledgeSourceAsync(source);
#if !SNIPPET
            resources.TrackSource(sourceName);
#endif
            await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(
                baseName, new[] { new KnowledgeSourceReference(sourceName) })
            {
                Models = { model },
                OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
            });
#if !SNIPPET
            resources.TrackBase(baseName);
#endif
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
#if !SNIPPET
            retrievalClient = CreatePreviewRetrievalClient(resources, baseName);
#endif
            // No explicit field values or request filter forces the result.
            KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(new KnowledgeBaseRetrievalRequest
            {
                Messages =
                {
                    new KnowledgeBaseMessage(new[]
                    {
                        new KnowledgeBaseMessageTextContent("Find hotel guest benefits for hotels in Canada only.")
                    })
                    {
                        Role = "user"
                    }
                },
                IncludeActivity = true
            });
            foreach (KnowledgeBaseSearchIndexActivityRecord activity in response.Activity.OfType<KnowledgeBaseSearchIndexActivityRecord>())
            {
                Console.WriteLine($"Generated filter: {activity.QueryHintProcessing?.GeneratedFilter}");
            }
            #endregion
            var stored = (SearchIndexKnowledgeSource)(await indexClient.GetKnowledgeSourceAsync(sourceName)).Value;
            Assert.That(stored.SearchIndexParameters.QueryHints.Filters.Single().FieldValues, Is.Empty);
            Assert.That(stored.SearchIndexParameters.QueryHints.Filters.Single().AutoConfiguration.CacheTtl, Is.EqualTo(60));
            AssertPreviewReferences(response, "hotel-ca-1", "hotel-ca-2");
            Assert.That(response.Activity.OfType<KnowledgeBaseSearchIndexActivityRecord>().Any(activity =>
                activity.QueryHintProcessing?.GeneratedFilter?.Contains("Canada") == true), Is.True);
        }
    }
}
