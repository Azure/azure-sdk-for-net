// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_05_01_Preview)]
    public partial class KnowledgeSourceFreshnessPreview : SearchTestBase
    {
        public KnowledgeSourceFreshnessPreview(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateKnowledgeSourceWithFreshnessPolicy()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this, populate: true);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);
            Environment.SetEnvironmentVariable("STORAGE_CONNECTION_STRING", resources.StorageAccountConnectionString);
            Environment.SetEnvironmentVariable("STORAGE_CONTAINER_NAME", resources.BlobContainerName ?? "my-documents");

            string testBlobSourceName = Recording.Random.GetName();
            string testSearchSourceName = Recording.Random.GetName();
            string testBaseName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateSourceWithPolicy
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                // Configure ingestion parameters with a freshness policy.
                // The freshnessPolicy enables freshness-aware retrieval, biasing
                // results toward newer documents during RAG scenarios.
                // BoostingDuration uses ISO 8601 duration format (e.g., "P90D" = 90 days).
                // Documents modified within this window receive the highest freshness boost.
                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
                string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

                string blobSourceName = "my-blob-source";
#if !SNIPPET
                blobSourceName = testBlobSourceName;
#endif

                string storageConnectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING");
                string containerName = Environment.GetEnvironmentVariable("STORAGE_CONTAINER_NAME");

                AzureBlobKnowledgeSource blobSource = new AzureBlobKnowledgeSource(
                    blobSourceName,
                    new AzureBlobKnowledgeSourceParameters(
                        storageConnectionString,
                        containerName)
                    {
                        IngestionParameters = new KnowledgeSourceIngestionParameters
                        {
                            FreshnessPolicy = new FreshnessPolicy
                            {
                                // Documents modified within the last 90 days get the highest boost.
                                // The boost decays linearly over this window.
                                BoostingDuration = "P90D"
                            },
                            EmbeddingModel = new KnowledgeSourceAzureOpenAIVectorizer
                            {
                                AzureOpenAIParameters = new AzureOpenAIVectorizerParameters
                                {
                                    ResourceUri = new Uri(openAIEndpoint),
                                    ApiKey = openAIKey,
                                    DeploymentName = "text-embedding-3-large",
                                    ModelName = "text-embedding-3-large"
                                }
                            }
                        }
                    })
                {
                    Description = "Blob source with freshness-aware retrieval"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(blobSource);
                Console.WriteLine($"Created knowledge source '{createdSource.Name}' with freshness policy");
                #endregion Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateSourceWithPolicy

                Assert.AreEqual(testBlobSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is AzureBlobKnowledgeSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                // Also create a search index source without freshness for the multi-source KB
                string searchSourceName = "my-search-source";
#if !SNIPPET
                searchSourceName = testSearchSourceName;
#endif
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexKnowledgeSource searchSource = new SearchIndexKnowledgeSource(
                    searchSourceName,
                    new SearchIndexKnowledgeSourceParameters(indexName)
                    {
                        SourceDataFields =
                        {
                            new SearchIndexFieldReference("hotelId"),
                            new SearchIndexFieldReference("hotelName"),
                            new SearchIndexFieldReference("description"),
                        }
                    })
                {
                    Description = "Search index source without freshness"
                };

                await indexClient.CreateKnowledgeSourceAsync(searchSource);

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateKBWithFreshness
                // Create a knowledge base and enable freshness per knowledge source.
                // enableFreshness = true activates the freshness scoring profile for
                // that source during retrieval, biasing results toward newer documents.
                // Sources without freshness enabled use standard relevance ranking.
                string knowledgeBaseName = "my-freshness-kb";
#if !SNIPPET
                knowledgeBaseName = testBaseName;
#endif
                KnowledgeBase knowledgeBase = new KnowledgeBase(
                    knowledgeBaseName,
                    knowledgeSources: new[]
                    {
                        new KnowledgeSourceReference(blobSourceName)
                        {
                            // Enable freshness-aware retrieval for the blob source
                            EnableFreshness = true
                        },
                        new KnowledgeSourceReference(searchSourceName)
                        {
                            // Freshness not enabled for this source — standard ranking applies
                            EnableFreshness = false
                        }
                    })
                {
                    Description = "KB with selective freshness-aware retrieval",
                    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
                    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
                };

#if !SNIPPET
                string openAIEndpoint2 = TestEnvironment.OpenAIEndpoint;
                string openAIKey2 = TestEnvironment.OpenAIKey;
                if (!string.IsNullOrEmpty(openAIEndpoint2))
                {
                    knowledgeBase.Models.Add(
                        new KnowledgeBaseAzureOpenAIModel(
                            new AzureOpenAIVectorizerParameters
                            {
                                ResourceUri = new Uri(openAIEndpoint2),
                                ApiKey = openAIKey2,
                                DeploymentName = "gpt-5.4-mini",
                                ModelName = AzureOpenAIModelName.Gpt54Mini
                            }));
                }
#endif

                KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
                Console.WriteLine($"Created knowledge base '{createdBase.Name}'");

                // Verify freshness settings on the knowledge source references
                foreach (KnowledgeSourceReference ksRef in createdBase.KnowledgeSources)
                {
                    Console.WriteLine($"  Source '{ksRef.Name}': freshness = {ksRef.EnableFreshness}");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateKBWithFreshness

                await DelayAsync(TimeSpan.FromSeconds(2));

                #region Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Retrieve
                // Retrieve from the knowledge base. The blob source will use
                // freshness-aware ranking (newer documents boosted), while the
                // search index source uses standard relevance ranking.
                KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
                    endpoint, knowledgeBaseName, credential);
#if !SNIPPET
                retrievalClient = InstrumentClient(new KnowledgeBaseRetrievalClient(
                    endpoint, testBaseName, credential, InstrumentClientOptions(new SearchClientOptions())));
#endif

                KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
                {
                    IncludeActivity = true
                };
                request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the latest updates?"));

                Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
                KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

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

                foreach (KnowledgeBaseReference reference in retrievalResponse.References)
                {
                    Console.WriteLine($"Reference ID: {reference.Id}");
                }
                #endregion Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Retrieve

                Assert.IsNotNull(retrievalResponse);
                Assert.IsNotNull(retrievalResponse.Response);
            }
            finally
            {
                if (testClient != null)
                {
                    try
                    { await testClient.DeleteKnowledgeBaseAsync(testBaseName, cancellationToken: CancellationToken.None); }
                    catch { }
                    try
                    { await testClient.DeleteKnowledgeSourceAsync(testBlobSourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                    try
                    { await testClient.DeleteKnowledgeSourceAsync(testSearchSourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                }
            }
        }
    }
}
