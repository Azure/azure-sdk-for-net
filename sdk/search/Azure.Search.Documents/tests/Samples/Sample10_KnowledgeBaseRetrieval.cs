// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Models;
#endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2026_04_01), ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
    public partial class KnowledgeBaseRetrieval : SearchTestBase
    {
        public KnowledgeBaseRetrieval(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null/* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task SetupAndRetrieveFromKnowledgeBase()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_BASE_NAME", resources.KnowledgeBaseName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_Retrieve
            // Get the service endpoint and API key from the environment
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeBaseName = Environment.GetEnvironmentVariable("KNOWLEDGE_BASE_NAME");

            // Create a KnowledgeBaseRetrievalClient to query the knowledge base
            KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential);
#if !SNIPPET
            retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                endpoint, knowledgeBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

            // Build a retrieval request with a semantic intent
            KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest();
            request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

            // Retrieve relevant content from the knowledge base
            Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
            KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

            // Display the response messages
            foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
            {
                foreach (KnowledgeBaseMessageContent content in message.Content)
                {
                    if (content is KnowledgeBaseMessageTextContent textContent)
                    {
                        Console.WriteLine($"Response: {textContent.Text}");
                    }
                }
            }

            // Display the references used in the response
            foreach (KnowledgeBaseReference reference in retrievalResponse.References)
            {
                Console.WriteLine($"Reference ID: {reference.Id}");
            }
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_Retrieve

            Assert.IsNotNull(retrievalResponse);
            Assert.IsNotNull(retrievalResponse.Response);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task EndToEndKnowledgeBase()
        {
            await using SearchResources resources = SearchResources.CreateWithNoIndexes(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);

            SearchIndexClient testIndexClient = null;
            string testIndexName = Recording.Random.GetName();
            string testSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateIndex
                // Get the service endpoint and API key from the environment
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                // Create a SearchIndexClient
                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testIndexClient = indexClient;
#endif

                // Define the index with semantic search
                string indexName = "hotels-knowledge-base";
#if !SNIPPET
                indexName = testIndexName;
#endif
                SearchIndex searchIndex = new SearchIndex(indexName)
                {
                    Fields =
                    {
                        new SimpleField("HotelId", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
                        new SearchableField("HotelName") { IsFilterable = true, IsSortable = true },
                        new SearchableField("Description") { IsFilterable = true },
                        new SearchableField("Category") { IsFilterable = true, IsSortable = true, IsFacetable = true },
                    },
                    SemanticSearch = new Indexes.Models.SemanticSearch
                    {
                        Configurations =
                        {
                            new SemanticConfiguration("my-semantic-config", new SemanticPrioritizedFields
                            {
                                TitleField = new SemanticField("HotelName"),
                                ContentFields =
                                {
                                    new SemanticField("Description")
                                },
                                KeywordsFields =
                                {
                                    new SemanticField("Category")
                                }
                            })
                        }
                    }
                };

                await indexClient.CreateIndexAsync(searchIndex);
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateIndex

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_UploadDocuments
                // Upload documents to the index
                SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
#if !SNIPPET
                searchClient = InstrumentClient(new SearchClient(endpoint, testIndexName, credential, GetSearchClientOptions()));
#endif

                var hotels = new[]
                {
                    new { HotelId = "1", HotelName = "Fancy Stay", Description = "Best hotel in town if you like luxury hotels.", Category = "Luxury" },
                    new { HotelId = "2", HotelName = "Roach Motel", Description = "Cheapest hotel in town.", Category = "Budget" },
                    new { HotelId = "3", HotelName = "EconoStay", Description = "Very popular hotel in town.", Category = "Budget" },
                    new { HotelId = "4", HotelName = "Modern Stay", Description = "Modern architecture, very polite staff and very clean.", Category = "Luxury" },
                };

                await searchClient.IndexDocumentsAsync(IndexDocumentsBatch.Upload(hotels));
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_UploadDocuments

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateKnowledgeSource
                // Create a knowledge source that references the search index
                string knowledgeSourceName = "hotels-knowledge-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif
                SearchIndexKnowledgeSource knowledgeSource = new SearchIndexKnowledgeSource(
                    knowledgeSourceName,
                    new SearchIndexKnowledgeSourceParameters(indexName)
                    {
                        // Specify which fields should be included in references
                        SourceDataFields =
                        {
                            new SearchIndexFieldReference("HotelId"),
                            new SearchIndexFieldReference("HotelName"),
                        }
                    })
                {
                    Description = "Knowledge source for hotel data"
                };

                await indexClient.CreateKnowledgeSourceAsync(knowledgeSource);
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateKnowledgeSource

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateKnowledgeBase
                // Create a knowledge base that orchestrates retrieval from the knowledge source
                string knowledgeBaseName = "hotels-knowledge-base";
#if !SNIPPET
                knowledgeBaseName = testBaseName;
#endif
                KnowledgeBase knowledgeBase = new KnowledgeBase(
                    knowledgeBaseName,
                    knowledgeSources: new[]
                    {
                        new KnowledgeSourceReference(knowledgeSourceName)
                    })
                {
                    Description = "Knowledge base for hotel information retrieval"
                };

                // Optionally add an Azure OpenAI model for query planning
                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
                string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");
#if !SNIPPET
                if (!string.IsNullOrEmpty(openAIEndpoint))
                {
#endif
                    knowledgeBase.Models.Add(
                        new KnowledgeBaseAzureOpenAIModel(
                            new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint),
                                ApiKey = openAIKey,
                                DeploymentName = "gpt-5-mini",
                                ModelName = AzureOpenAIModelName.Gpt5Mini
                            }));
#if !SNIPPET
                }
#endif

                await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_CreateKnowledgeBase

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_RetrieveFromKnowledgeBase
                // Create a KnowledgeBaseRetrievalClient to query the knowledge base
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, testBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                // Build a retrieval request with a semantic intent
                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest();
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

                // Retrieve relevant content from the knowledge base
                Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
                KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

                // Display the response messages
                foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
                {
                    foreach (KnowledgeBaseMessageContent content in message.Content)
                    {
                        if (content is KnowledgeBaseMessageTextContent textContent)
                        {
                            Console.WriteLine($"Response: {textContent.Text}");
                        }
                    }
                }

                // Display the references used in the response
                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");
                }
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample10_KnowledgeBase_RetrieveFromKnowledgeBase

                Assert.IsNotNull(retrievalResponse);
                Assert.IsNotNull(retrievalResponse.Response);
            }
            finally
            {
                // Clean up resources in reverse order
                if (testIndexClient != null)
                {
                    try
                    { await testIndexClient.DeleteKnowledgeBaseAsync(testBaseName, cancellationToken: CancellationToken.None); }
                    catch { }
                    try
                    { await testIndexClient.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                    try
                    { await testIndexClient.DeleteIndexAsync(testIndexName, cancellationToken: CancellationToken.None); }
                    catch { }
                }
            }
        }
    }
}
