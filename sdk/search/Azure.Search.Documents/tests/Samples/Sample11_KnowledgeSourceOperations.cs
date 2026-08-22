// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
#region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Namespaces
using System.IO;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
#endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Namespaces
using NUnit.Framework;

namespace Azure.Search.Documents.Tests.Samples
{
    [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_04_01)]
    public partial class KnowledgeSourceOperations : SearchTestBase
    {
        public KnowledgeSourceOperations(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task CreateSearchIndexKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            string testSourceName = Recording.Random.GetName();
            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_CreateSearchIndex
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

                // Create a knowledge source that references a search index
                string knowledgeSourceName = "my-search-index-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif
                SearchIndexKnowledgeSource searchIndexSource = new SearchIndexKnowledgeSource(
                    knowledgeSourceName,
                    new SearchIndexKnowledgeSourceParameters(indexName)
                    {
                        // Specify which fields to include in citation references
                        SourceDataFields =
                        {
                            new SearchIndexFieldReference("hotelId"),
                            new SearchIndexFieldReference("hotelName"),
                        },

                        // Guide query planning toward useful filters and boosts.
                        QueryHints = new SearchIndexKnowledgeSourceQueryHints
                        {
                            Filters =
                            {
                                new SearchIndexKnowledgeSourceFilterHint(
                                    "category",
                                    new[] { "Luxury", "Budget" })
                                {
                                    FilterInstructions = "Use this field when the user specifies a hotel category."
                                }
                            },
                            Boosts =
                            {
                                new SearchIndexKnowledgeSourceFieldValueBoost("category", 2.0)
                                {
                                    FieldValues = { "Luxury" },
                                    BoostInstructions = "Boost luxury hotels when premium amenities are requested."
                                }
                            }
                        }
                    })
                {
                    Description = "Hotels search index knowledge source"
                };

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(searchIndexSource);
                Console.WriteLine($"Created knowledge source '{createdSource.Name}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_CreateSearchIndex

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is SearchIndexKnowledgeSource);
                Assert.AreEqual(1, searchIndexSource.SearchIndexParameters.QueryHints.Filters.Count);
                Assert.AreEqual(1, searchIndexSource.SearchIndexParameters.QueryHints.Boosts.Count);
            }
            finally
            {
                SearchIndexClient client = resources.GetIndexClient();
                try
                { await client.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        [LiveOnly]
        [ServiceVersion(Min = SearchClientOptions.ServiceVersion.V2026_08_01_Preview)]
        public async Task CreatePrivateBlobKnowledgeSourceAndInspectAnalyzer()
        {
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAsync(
                this,
                populate: true,
                isSample: true);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("STORAGE_CONNECTION_STRING", resources.StorageAccountConnectionString);
            Environment.SetEnvironmentVariable("STORAGE_CONTAINER_NAME", resources.BlobContainerName);
            Environment.SetEnvironmentVariable("AI_SERVICES_ENDPOINT", resources.CognitiveServicesEndpoint);
            Environment.SetEnvironmentVariable("AI_SERVICES_KEY", resources.CognitiveServicesKey);
            Environment.SetEnvironmentVariable("OPENAI_ENDPOINT", TestEnvironment.OpenAIEndpoint);
            Environment.SetEnvironmentVariable("OPENAI_KEY", TestEnvironment.OpenAIKey);

            string testSourceName = Recording.Random.GetName();
            SearchIndexClient testClient = null;

            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_PrivateBlob
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
                testClient = indexClient;
#endif

                string knowledgeSourceName = "my-private-blob-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif
                string storageConnectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING");
                string containerName = Environment.GetEnvironmentVariable("STORAGE_CONTAINER_NAME");
                string aiServicesEndpoint = Environment.GetEnvironmentVariable("AI_SERVICES_ENDPOINT");
                string aiServicesKey = Environment.GetEnvironmentVariable("AI_SERVICES_KEY");
                string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
                string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

                KnowledgeSourceIngestionParameters ingestion = new KnowledgeSourceIngestionParameters
                {
                    // Private is a create-time setting for supported indexed sources.
                    NetworkAccessMode = KnowledgeSourceNetworkAccessMode.Private,
                    ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
                    AiServices = new AIServices(new Uri(aiServicesEndpoint))
                    {
                        ApiKey = aiServicesKey
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
                };

                AzureBlobKnowledgeSource blobSource = new AzureBlobKnowledgeSource(
                    knowledgeSourceName,
                    new AzureBlobKnowledgeSourceParameters(storageConnectionString, containerName)
                    {
                        IngestionParameters = ingestion
                    });

                await indexClient.CreateKnowledgeSourceAsync(blobSource);

                // Wait for the service to report the generated index. Creation is asynchronous.
                AzureBlobKnowledgeSource persisted = null;
                for (int attempt = 0; attempt < 12; attempt++)
                {
                    persisted = (AzureBlobKnowledgeSource)await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
                    if (persisted.AzureBlobParameters.CreatedResources?.AdditionalProperties.ContainsKey("index") == true)
                    {
                        break;
                    }
                    await Task.Delay(TimeSpan.FromSeconds(5));
                }

                KnowledgeSourceStatus status = await indexClient.GetKnowledgeSourceStatusAsync(knowledgeSourceName);

                Console.WriteLine($"Synchronization status: {status.SynchronizationStatus}");
                if (persisted?.AzureBlobParameters.CreatedResources is null)
                {
                    throw new InvalidOperationException("The service did not report generated resources.");
                }
                foreach (KeyValuePair<string, string> resource in persisted.AzureBlobParameters.CreatedResources.AdditionalProperties)
                {
                    Console.WriteLine($"Generated {resource.Key}: {resource.Value}");
                }

                if (!persisted.AzureBlobParameters.CreatedResources.AdditionalProperties.TryGetValue(
                    "index",
                    out string generatedIndexName))
                {
                    throw new InvalidOperationException("The service did not report a generated index.");
                }

                SearchIndex generatedIndex = await indexClient.GetIndexAsync(generatedIndexName);
                SearchField microsoftAnalyzerField = generatedIndex.Fields.FirstOrDefault(
                    field => field.AnalyzerName == LexicalAnalyzerName.EnMicrosoft);
                Console.WriteLine($"Service-selected analyzer: {microsoftAnalyzerField?.AnalyzerName}");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_PrivateBlob

                Assert.AreEqual(
                    KnowledgeSourceNetworkAccessMode.Private,
                    persisted.AzureBlobParameters.IngestionParameters.NetworkAccessMode);
                Assert.IsNotNull(microsoftAnalyzerField);
            }
            finally
            {
                if (testClient != null)
                {
                    try
                    { await testClient.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                    catch { }
                }
            }
        }

        [Test]
        public async Task CreateWebKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.GetSharedHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            string testSourceName = Recording.Random.GetName();
            try
            {
                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_CreateWeb
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

                // Create a web knowledge source with allowed and blocked domains
                string knowledgeSourceName = "my-web-source";
#if !SNIPPET
                knowledgeSourceName = testSourceName;
#endif
                WebKnowledgeSource webSource = new WebKnowledgeSource(knowledgeSourceName)
                {
                    Description = "Web knowledge source for documentation",
                    WebParameters = new WebKnowledgeSourceParameters
                    {
                        Domains = new WebKnowledgeSourceDomains()
                    }
                };
                webSource.WebParameters.Domains.AllowedDomains.Add(
                    new WebKnowledgeSourceDomain("learn.microsoft.com") { IncludeSubpages = true });
                webSource.WebParameters.Domains.BlockedDomains.Add(
                    new WebKnowledgeSourceDomain("internal.example.com"));

                KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(webSource);
                Console.WriteLine($"Created web knowledge source '{createdSource.Name}'");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_CreateWeb

                Assert.AreEqual(testSourceName, createdSource.Name);
                Assert.IsTrue(createdSource is WebKnowledgeSource);
                var createdWebSource = (WebKnowledgeSource)createdSource;
                Assert.AreEqual(1, createdWebSource.WebParameters.Domains.AllowedDomains.Count);
                Assert.AreEqual(1, createdWebSource.WebParameters.Domains.BlockedDomains.Count);
            }
            finally
            {
                SearchIndexClient client = resources.GetIndexClient();
                try
                { await client.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task GetKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME", resources.KnowledgeSourceName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Get
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get a specific knowledge source by name
            KnowledgeSource knowledgeSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
            Console.WriteLine($"Knowledge source '{knowledgeSource.Name}' of type {knowledgeSource.GetType().Name}");

            if (knowledgeSource is SearchIndexKnowledgeSource searchIndexSource)
            {
                Console.WriteLine($"  References index: {searchIndexSource.SearchIndexParameters.SearchIndexName}");
            }
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Get

            Assert.AreEqual(resources.KnowledgeSourceName, knowledgeSource.Name);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task ListKnowledgeSources()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_List
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Request small pages and let AsyncPageable follow opaque continuation
            // state internally. Do not parse or modify continuation tokens.
            HashSet<string> sourceNames = new HashSet<string>();
            await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync(pageSize: 1))
            {
                if (!sourceNames.Add(source.Name))
                {
                    throw new InvalidDataException($"Duplicate knowledge source '{source.Name}' was returned.");
                }
                Console.WriteLine($"Knowledge source: {source.Name} ({source.GetType().Name})");
            }
            Console.WriteLine($"Listed {sourceNames.Count} unique knowledge sources.");
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_List

            Assert.Contains(resources.KnowledgeSourceName, new List<string>(sourceNames));
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task UpdateKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("SEARCH_INDEX", resources.IndexName);

            string testSourceName = Recording.Random.GetName();
            try
            {
                SearchIndexClient testClient = InstrumentClient(
                    new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

                // Create a knowledge source first
                SearchIndexKnowledgeSource source = new SearchIndexKnowledgeSource(
                    testSourceName,
                    new SearchIndexKnowledgeSourceParameters(resources.IndexName));
                await testClient.CreateKnowledgeSourceAsync(source);

                await DelayAsync(TimeSpan.FromSeconds(2));

                Environment.SetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME", testSourceName);

                #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Update
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
                string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

                SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
                indexClient = testClient;
#endif

                // Get the existing knowledge source
                KnowledgeSource existingSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);

                // Update its description
                existingSource.Description = "Updated description for the knowledge source";

                KnowledgeSource updatedSource = await indexClient.CreateOrUpdateKnowledgeSourceAsync(existingSource);
                Console.WriteLine($"Updated knowledge source '{updatedSource.Name}': {updatedSource.Description}");
                #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Update

                Assert.AreEqual("Updated description for the knowledge source", updatedSource.Description);
            }
            finally
            {
                SearchIndexClient client = resources.GetIndexClient();
                try
                { await client.DeleteKnowledgeSourceAsync(testSourceName, cancellationToken: CancellationToken.None); }
                catch { }
            }
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task DeleteKnowledgeSource()
        {
            await using SearchResources resources = await SearchResources.CreateWithHotelsIndexAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            string testSourceName = Recording.Random.GetName();

            SearchIndexClient testClient = InstrumentClient(
                new SearchIndexClient(resources.Endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()));

            // Create a knowledge source to delete
            SearchIndexKnowledgeSource source = new SearchIndexKnowledgeSource(
                testSourceName,
                new SearchIndexKnowledgeSourceParameters(resources.IndexName));
            await testClient.CreateKnowledgeSourceAsync(source);

            await DelayAsync(TimeSpan.FromSeconds(2));

            Environment.SetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME", testSourceName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Delete
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = testClient;
#endif

            // Delete a knowledge source by name
            await indexClient.DeleteKnowledgeSourceAsync(knowledgeSourceName);
            Console.WriteLine($"Deleted knowledge source '{knowledgeSourceName}'");
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Delete

            // Verify it was deleted
            var ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await testClient.GetKnowledgeSourceAsync(testSourceName);
            });
            Assert.AreEqual(404, ex.Status);
        }

        [Test]
        [PlaybackOnly("Running it in the playback mode, eliminating the need for pipelines to create OpenAI resources.")]
        public async Task GetKnowledgeSourceStatus()
        {
            await using SearchResources resources = await SearchResources.CreateWithKnowledgeBaseAsync(this);

            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);
            Environment.SetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME", resources.KnowledgeSourceName);

            #region Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_GetStatus
            Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
            AzureKeyCredential credential = new AzureKeyCredential(
                Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
            string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

            SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);
#if !SNIPPET
            indexClient = InstrumentClient(new SearchIndexClient(endpoint, credential, GetSearchClientOptions()));
#endif

            // Get the status of a knowledge source
            KnowledgeSourceStatus status = await indexClient.GetKnowledgeSourceStatusAsync(knowledgeSourceName);
            Console.WriteLine($"Knowledge source kind: {status.Kind}");
            Console.WriteLine($"Synchronization status: {status.SynchronizationStatus}");
            Console.WriteLine($"Synchronization interval: {status.SynchronizationInterval}");

            if (status.LastSynchronizationState != null)
            {
                Console.WriteLine($"Last sync started: {status.LastSynchronizationState.StartTime}");
                Console.WriteLine($"Last sync ended: {status.LastSynchronizationState.EndTime}");
            }

            if (status.Statistics != null)
            {
                Console.WriteLine($"Total synchronizations: {status.Statistics.TotalSynchronization}");
            }
            #endregion Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_GetStatus

            Assert.IsNotNull(status.SynchronizationStatus);
        }
    }
}
