// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Azure.Search.Documents.Tests.Samples;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Search.Documents.Tests
{
    /// <summary>
    /// Manage the creation and deletion of live test resources.  This uses the
    /// Track 1 management libraries to create the Search Service and
    /// (temporarily) the Track 1 data plane libraries to create and populate
    /// the Hotels index.
    /// </summary>
    public partial class SearchResources : IAsyncDisposable
    {
        /// <summary>
        /// A source of randomness for creating live test resources.  This
        /// should not be tied into test recordings because live resource
        /// creation is independent and not recorded.
        /// </summary>
        public static Random Random { get; } = new Random(Environment.TickCount);

        /// <summary>
        /// The timeout for cancellation.
        /// </summary>
        public static TimeSpan Timeout => Debugger.IsAttached ?
            System.Threading.Timeout.InfiniteTimeSpan :
            TimeSpan.FromMinutes(2);

        /// <summary>
        /// The name of the Search service.
        /// </summary>
        public string SearchServiceName => TestFixture.TestEnvironment.SearchServiceName;

        /// <summary>
        /// The storage account name.
        /// </summary>
        public string StorageAccountName => TestFixture.TestEnvironment.SearchStorageName;

        /// <summary>
        /// The storage account key.
        /// </summary>
        public string StorageAccountKey => TestFixture.TestEnvironment.SearchStorageKey;

        /// <summary>
        /// The storage endpoint suffix.
        /// </summary>
        public string StorageEndpointSuffix => TestFixture.TestEnvironment.StorageEndpointSuffix ?? "core.windows.net";
        /// <summary>
        /// The storage account connection string.
        /// </summary>
        public string StorageAccountConnectionString => $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={StorageAccountKey};EndpointSuffix={StorageEndpointSuffix}";

        /// <summary>
        /// The Cognitive Services key.
        /// </summary>
        public string CognitiveServicesKey => TestFixture.TestEnvironment.SearchCognitiveKey;

        /// <summary>
        /// The name of the blob container.
        /// </summary>
        public string BlobContainerName
        {
            get => TestFixture.Recording.GetVariable("BlobContainerName", _blobContainerName);
            set
            {
                TestFixture.Recording.SetVariable("BlobContainerName", value);
                _blobContainerName = value;
            }
        }
        private string _blobContainerName = null;

        /// <summary>
        /// The name of the index created for test data.
        /// </summary>
        public string IndexName
        {
            get => TestFixture.Recording.GetVariable("SearchIndexName", _indexName);
            set
            {
                TestFixture.Recording.SetVariable("SearchIndexName", value);
                _indexName = value;
            }
        }
        private string _indexName = null;

        /// <summary>
        /// The name of the knowledge agent created for test data.
        /// </summary>
        public string KnowledgeAgentName
        {
            get => TestFixture.Recording.GetVariable("KnowledgeAgentName", _agentName);
            set
            {
                TestFixture.Recording.SetVariable("KnowledgeAgentName", value);
                _agentName = value;
            }
        }
        private string _agentName = null;

        /// <summary>
        /// The name of the knowledge source created for test data.
        /// </summary>
        public string KnowledgeSourceName
        {
            get => TestFixture.Recording.GetVariable("KnowledgeSourceName", _sourceName);
            set
            {
                TestFixture.Recording.SetVariable("KnowledgeSourceName", value);
                _sourceName = value;
            }
        }
        private string _sourceName = null;

        /// <summary>
        /// The search endpoint suffix.
        /// </summary>
        public string SearchEndpointSuffix => TestFixture.TestEnvironment.SearchEndpointSuffix;

        /// <summary>
        /// The URI of the Search service.
        /// </summary>
        public Uri Endpoint => new Uri($"https://{SearchServiceName}.{SearchEndpointSuffix}");

        /// <summary>
        /// The Primary or Admin API key to authenticate requests to the
        /// service.
        /// </summary>
        public string PrimaryApiKey => TestFixture.TestEnvironment.SearchAdminKey;

        /// <summary>
        /// The Query API key to authenticate requests to the service.
        /// </summary>
        public string QueryApiKey => TestFixture.TestEnvironment.SearchQueryKey;

        /// <summary>
        /// Flag indicating whether these resources need to be cleaned up.
        /// This is true for any resources that we created.
        /// </summary>
        public bool RequiresCleanup { get; private set; }

        /// <summary>
        /// Flag indicating whether these knowledge agent resources need to be cleaned up.
        /// This is true for any knowledge agent resources that we created.
        /// </summary>
        public bool RequiresKnowledgeAgentCleanup { get; private set; }

        /// <summary>
        /// Flag indicating whether these knowledge source resources need to be cleaned up.
        /// This is true for any knowledge source resources that we created.
        /// </summary>
        public bool RequiresKnowledgeSourceCleanup { get; private set; }

        /// <summary>
        /// Flag indicating whether these storage resources need to be cleaned up.
        /// This is true for any storage resources that we created.
        /// </summary>
        public bool RequiresBlobContainerCleanup { get; private set; }

        /// <summary>
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </summary>
        public SearchTestBase TestFixture { get; private set; }

        #region Create Test Resources
        /// <summary>
        /// Direct folks toward the static helpers.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        private SearchResources(SearchTestBase fixture) => TestFixture = fixture;

        /// <summary>
        /// Create a new Search Service resource with no indexes.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>A new TestResources context.</returns>
        public static SearchResources CreateWithNoIndexes(SearchTestBase fixture)
        {
            return new SearchResources(fixture)
            {
                // We created no index, but others tests might. We'll check when cleaning up.
                RequiresCleanup = fixture.Recording.Mode != RecordedTestMode.Playback,
            };
        }

        /// <summary>
        /// Create a new Search Service resource with an empty index for a
        /// given model type.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>A new TestResources context.</returns>
        public static async Task<SearchResources> CreateWithEmptyIndexAsync<T>(SearchTestBase fixture, bool isSample = false)
        {
            // TODO: consider setting up RequiresCleanup so the index is deleted at the end of the test run.
            var resources = new SearchResources(fixture);
            await resources.CreateSearchServiceAndIndexAsync(isSample, name =>
                new SearchIndex(name)
                {
                    Fields = new FieldBuilder().Build(typeof(T))
                });
            return resources;
        }

        /// <summary>
        /// Create a new Search Service resource with an empty Hotel index.
        /// See TestResources.Data.cs for the index schema.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>A new TestResources context.</returns>
        public static async Task<SearchResources> CreateWithEmptyHotelsIndexAsync(SearchTestBase fixture, bool isSample = false)
        {
            // TODO: consider setting up RequiresCleanup so the index is deleted at the end of the test run.
            var resources = new SearchResources(fixture);
            await resources.CreateSearchServiceAndIndexAsync(isSample);
            return resources;
        }

        /// <summary>
        /// Create a new Search Service resource a Hotel index and sample data
        /// set.  See TestResources.Data.cs for the index schema and data set.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>A new TestResources context.</returns>
        public static async Task<SearchResources> CreateWithHotelsIndexAsync(SearchTestBase fixture, bool isSample = false)
        {
            // TODO: consider setting up RequiresCleanup so the index is deleted at the end of the test run.
            var resources = new SearchResources(fixture);
            await resources.CreateSearchServiceIndexAndDocumentsAsync(isSample);
            return resources;
        }

        /// <summary>
        /// Creates a new Search Service resource, including a Hotel index and sample data set.
        /// The index schema and data are defined in TestResources.Data.cs.
        /// The created index is used in knowledge agent creation.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>A new TestResources context.</returns>
        public static async Task<SearchResources> CreateWithknowledgeAgentAsync(SearchTestBase fixture, bool isSample = false)
        {
            var resources = new SearchResources(fixture);
            await resources.CreateKnowledgeAgentAsync();
            return resources;
        }

        /// <summary>
        /// Creates a new Search service resources with sample data
        /// loaded into a new blob container but no index.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <param name="populate">
        /// Whether to populate the container with Hotel documents. The default is false.
        /// </param>
        /// <returns>A new <see cref="SearchResources"/> context.</returns>
        public static async Task<SearchResources> CreateWithBlobStorageAsync(SearchTestBase fixture, bool populate = false, bool isSample = false)
        {
            // TODO: consider setting up RequiresCleanup so the index is deleted at the end of the test run.
            var resources = new SearchResources(fixture);
            await resources.CreateHotelsBlobContainerAsync(populate, isSample);
            return resources;
        }

        /// <summary>
        /// Creates a new Search service resources with a Hotel index and sample data
        /// loaded into a new blob container.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <param name="populate">
        /// Whether to populate the container with Hotel documents. The default is false.
        /// </param>
        /// <returns>A new <see cref="SearchResources"/> context.</returns>
        public static async Task<SearchResources> CreateWithBlobStorageAndIndexAsync(SearchTestBase fixture, bool populate = false, bool isSample = false)
        {
            // TODO: consider setting up RequiresCleanup so the index is deleted at the end of the test run.
            var resources = new SearchResources(fixture);

            // Keep them ordered or records may not match seeded random names.
            await resources.CreateSearchServiceAndIndexAsync(isSample);
            await resources.CreateHotelsBlobContainerAsync(populate, isSample);

            return resources;
        }

        /// <summary>
        /// Get a shared Search Service resource with a Hotel index and sample
        /// data set.  See TestResources.Data.cs for the index schema and data
        /// set.  This resource is shared across the entire test run and should
        /// not be mutated.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>The shared TestResources context.</returns>
        public static async Task<SearchResources> GetSharedHotelsIndexAsync(SearchTestBase fixture, bool isSample = false)
        {
            // TODO: consider whether we should delete the index at the end of the test run here.
            //       SharedSearchResources seems to purposely cache the index.
            await SharedSearchResources.EnsureInitialized(async () => await CreateWithHotelsIndexAsync(fixture, isSample), isSample);

            // Clone it for the current fixture (note that setting these values
            // will create the recording ServiceName/IndexName/etc. variables)
            return new SearchResources(fixture)
            {
                IndexName = isSample ? SharedSearchResources.SearchResourcesForSamples.IndexName : SharedSearchResources.SearchResourcesForTests.IndexName,
            };
        }

        /// <summary>
        /// Create a hotels index with the standard test documents and as many
        /// extra empty documents needed to test.
        /// </summary>
        /// <param name="size">The total number of documents in the index.</param>
        /// <returns>SearchResources for testing.</returns>
        public static async Task<SearchResources> CreateLargeHotelsIndexAsync(SearchTestBase fixture, int size, bool includeVectors = false, bool isSample = false)
        {
            // Start with the standard test hotels
            SearchResources resources = await CreateWithHotelsIndexAsync(fixture, isSample);

            // Create empty hotels with just an ID for the rest
            int existingDocumentCount = TestDocuments.Length;
            IEnumerable<string> hotelIds =
                Enumerable.Range(
                    existingDocumentCount + 1,
                    size - existingDocumentCount)
                .Select(id => id.ToString());

            List<SearchDocument> hotels = new();

            if (includeVectors)
            {
                hotels = hotelIds.Select(id => new SearchDocument { ["hotelId"] = id, ["descriptionVector"] = VectorSearchEmbeddings.DefaultVectorizeDescription }).ToList();
            }
            else
            {
                Random random = new();
                hotels = hotelIds.Select(id => new SearchDocument { ["hotelId"] = id, ["rating"] = random.Next(1, 6) }).ToList();
            }

            // Upload the empty hotels in batches of 1000 until we're complete
            SearchClient client = resources.GetSearchClient();
            for (int i = 0; i < hotels.Count; i += 1000)
            {
                IEnumerable<SearchDocument> nextHotels = hotels.Skip(i).Take(1000);
                if (!nextHotels.Any())
                { break; }
                await client.IndexDocumentsAsync(IndexDocumentsBatch.Upload(nextHotels));
                await resources.WaitForIndexingAsync();
            }

            return resources;
        }
        #endregion Create Test Resources

        #region Get Clients
        /// <summary>
        /// Get a <see cref="SearchIndexClient"/> to use for testing.
        /// </summary>
        /// <param name="options">Optional client options.</param>
        /// <returns>A <see cref="SearchIndexClient"/> instance.</returns>
        public SearchIndexClient GetIndexClient(SearchClientOptions options = null) =>
            TestFixture.InstrumentClient(
                new SearchIndexClient(
                    Endpoint,
                    new AzureKeyCredential(PrimaryApiKey),
                    TestFixture.GetSearchClientOptions(options)));

        /// <summary>
        /// Get a <see cref="SearchIndexerClient"/> to use for testing.
        /// </summary>
        /// <param name="options">Optional client options.</param>
        /// <returns>A <see cref="SearchIndexerClient"/> instance.</returns>
        public SearchIndexerClient GetIndexerClient(SearchClientOptions options = null) =>
            TestFixture.InstrumentClient(
                new SearchIndexerClient(
                    Endpoint,
                    new AzureKeyCredential(PrimaryApiKey),
                    TestFixture.GetSearchClientOptions(options)));

        /// <summary>
        /// Get a <see cref="SearchClient"/> to use for testing with an Admin API key.
        /// </summary>
        /// <param name="options">Optional client options.</param>
        /// <returns>A <see cref="SearchClient"/> instance.</returns>
        public SearchClient GetSearchClient(SearchClientOptions options = null)
        {
            Assert.IsNotNull(IndexName, "No index was created for these TestResources!");
            return TestFixture.InstrumentClient(
                GetIndexClient(options).GetSearchClient(IndexName));
        }

        /// <summary>
        /// Get a <see cref="SearchClient"/> to use for testing with a query API key.
        /// </summary>
        /// <param name="options">Optional client options.</param>
        /// <returns>A <see cref="SearchClient"/> instance.</returns>
        public SearchClient GetQueryClient(SearchClientOptions options = null)
        {
            Assert.IsNotNull(IndexName, "No index was created for these TestResources!");
            return TestFixture.InstrumentClient(
                new SearchClient(
                    Endpoint,
                    IndexName,
                    new AzureKeyCredential(QueryApiKey),
                    TestFixture.GetSearchClientOptions(options)));
        }
        #endregion Get Clients

        #region Service Management
        /// <summary>
        /// Automatically delete the Search Service when the resources are no
        /// longer needed.
        /// </summary>
        public async ValueTask DisposeAsync() => await Task.WhenAll(
            DeleteKnowledgeAgentAsync(),
            DeleteKnowledgeSourceAsync(),
            DeleteIndexAsync(),
            DeleteBlobContainerAsync());

        /// <summary>
        /// Deletes the index created as a test resource.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteIndexAsync()
        {
            if (RequiresCleanup && !string.IsNullOrEmpty(IndexName))
            {
                SearchIndexClient client = GetIndexClient();
                await client.DeleteIndexAsync(IndexName);
                RequiresCleanup = false;

                await WaitForIndexDeletionAsync();
            }
        }

        /// <summary>
        /// Deletes the knowledge source created as a test resource.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteKnowledgeSourceAsync()
        {
            if (RequiresKnowledgeSourceCleanup && !string.IsNullOrEmpty(KnowledgeSourceName))
            {
                SearchIndexClient client = GetIndexClient();
                await client.DeleteKnowledgeSourceAsync(KnowledgeSourceName);
                RequiresKnowledgeSourceCleanup = false;

                await WaitForKnowledgeSourceDeletionAsync();
            }
        }

        /// <summary>
        /// Deletes the knowledge agent created as a test resource.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteKnowledgeAgentAsync()
        {
            if (RequiresKnowledgeAgentCleanup && !string.IsNullOrEmpty(KnowledgeAgentName))
            {
                SearchIndexClient client = GetIndexClient();
                await client.DeleteKnowledgeAgentAsync(KnowledgeAgentName);
                RequiresKnowledgeAgentCleanup = false;

                await WaitForKnowledgeAgentDeletionAsync();
            }
        }

        /// <summary>
        /// Delete the Storage blob container created as a test resource.
        /// </summary>
        /// <returns></returns>
        private async Task DeleteBlobContainerAsync()
        {
            if (RequiresBlobContainerCleanup)
            {
                BlobContainerClient client = new BlobContainerClient(StorageAccountConnectionString, BlobContainerName);
                await client.DeleteIfExistsAsync();
                RequiresBlobContainerCleanup = false;

                await WaitForBlobContainerDeletionAsync();
            }
        }

        /// <summary>
        /// Create a new Search Service and empty Hotels Index.
        /// </summary>
        /// <param name="getIndex">
        /// Function to get an index definition using the provided name.
        /// </param>
        /// <returns>This TestResources context.</returns>
        private async Task<SearchResources> CreateSearchServiceAndIndexAsync(
            bool isSample, Func<string, SearchIndex> getIndex = null)
        {
            getIndex ??= isSample ? SearchResourcesSample.GetHotelIndex : GetHotelIndex;

            // Create the index
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                // Generate a random Index Name
                IndexName = Random.GetName(8);

                SearchIndexClient client = new SearchIndexClient(Endpoint, new AzureKeyCredential(PrimaryApiKey));
                await client.CreateIndexAsync(getIndex(IndexName));

                RequiresCleanup = true;

                // Give the index time to stabilize before running tests.
                await WaitForIndexCreationAsync();
            }

            return this;
        }

        /// <summary>
        /// Create a new Search Service, Hotels Index, and fill it with
        /// test documents.
        /// </summary>
        /// <returns>This TestResources context.</returns>
        private async Task<SearchResources> CreateSearchServiceIndexAndDocumentsAsync(bool isSample = false)
        {
            // Create the Search Service and Index first
            await CreateSearchServiceAndIndexAsync(isSample);

            // Upload the documents
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                SearchClient client = new SearchClient(Endpoint, IndexName, new AzureKeyCredential(PrimaryApiKey));

                if (isSample)
                {
                    await client.IndexDocumentsAsync(IndexDocumentsBatch.Upload(SearchResourcesSample.TestDocumentsForSample));
                }
                else
                {
                    await client.IndexDocumentsAsync(IndexDocumentsBatch.Upload(TestDocuments));
                }

                await WaitForIndexingAsync();
            }

            return this;
        }

        /// <summary>
        /// Create a new index and knowledge agent.
        /// </summary>
        /// <returns>This TestResources context.</returns>
        private async Task<SearchResources> CreateKnowledgeAgentAsync(bool isSample = false)
        {
            // Create index and upload documents
            await CreateSearchServiceIndexAndDocumentsAsync(isSample);

            // Create the knowledge agent
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                SearchIndexClient client = GetIndexClient();

                // Generate a random knowledge agent Name
                KnowledgeAgentName = Random.GetName(8);
                KnowledgeSourceName = Random.GetName(8);
                string deploymentName = "gpt-4.1";

                SearchIndexKnowledgeSource indexKnowledgeSource = new(KnowledgeSourceName, new(IndexName));
                KnowledgeSource knowledgeSource = await client.CreateKnowledgeSourceAsync(indexKnowledgeSource);
                RequiresKnowledgeSourceCleanup = true;
                await WaitForKnowledgeSourceCreationAsync();

                var knowledgeAgent = new KnowledgeAgent(
                    KnowledgeAgentName,
                    new List<KnowledgeAgentModel>{
                    new KnowledgeAgentAzureOpenAIModel(
                        new AzureOpenAIVectorizerParameters
                        {
                            ResourceUri = new Uri(Environment.GetEnvironmentVariable("OPENAI_ENDPOINT")),
                            ApiKey = Environment.GetEnvironmentVariable("OPENAI_KEY"),
                            DeploymentName = deploymentName,
                            ModelName = AzureOpenAIModelName.Gpt41
                        })
                    },
                    new List<KnowledgeSourceReference>
                    {
                    new KnowledgeSourceReference(knowledgeSource.Name)
                    });

                await client.CreateKnowledgeAgentAsync(knowledgeAgent);
                RequiresKnowledgeAgentCleanup = true;

                // Give the knowledge agent time to stabilize before running tests.
                await WaitForKnowledgeAgentCreationAsync();
            }

            return this;
        }

        /// <summary>
        /// Upload <see cref="TestDocuments"/> to a new blob storage container identified by <see cref="BlobContainerName"/>.
        /// </summary>
        /// <returns>The current <see cref="SearchResources"/>.</returns>
        private async Task<SearchResources> CreateHotelsBlobContainerAsync(bool populate, bool isSample)
        {
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                BlobContainerName = Random.GetName(8);

                using CancellationTokenSource cts = new CancellationTokenSource(Timeout);

                BlobContainerClient client = new BlobContainerClient(StorageAccountConnectionString, BlobContainerName);
                await client.CreateIfNotExistsAsync(cancellationToken: cts.Token);

                RequiresBlobContainerCleanup = true;

                if (populate)
                {
                    List<Task> tasks;
                    if (isSample)
                    {
                        Samples.Hotel[] hotels = SearchResourcesSample.TestDocumentsForSample;
                        tasks = new List<Task>(hotels.Length);

                        foreach (Samples.Hotel hotel in hotels)
                        {
                            Task task = Task.Run(async () =>
                            {
                                using MemoryStream stream = new MemoryStream();
                                await JsonSerializer
                                    .SerializeAsync(stream, hotel, JsonSerialization.SerializerOptions, cts.Token)
                                    .ConfigureAwait(false);

                                stream.Seek(0, SeekOrigin.Begin);

                                await client
                                    .UploadBlobAsync(hotel.HotelId, stream, cts.Token)
                                    .ConfigureAwait(false);
                            });

                            tasks.Add(task);
                        }
                    }
                    else
                    {
                        Hotel[] hotels = TestDocuments;
                        tasks = new List<Task>(hotels.Length);

                        foreach (Hotel hotel in hotels)
                        {
                            Task task = Task.Run(async () =>
                            {
                                using MemoryStream stream = new MemoryStream();
                                await JsonSerializer
                                    .SerializeAsync(stream, hotel, JsonSerialization.SerializerOptions, cts.Token)
                                    .ConfigureAwait(false);

                                stream.Seek(0, SeekOrigin.Begin);

                                await client
                                    .UploadBlobAsync(hotel.HotelId, stream, cts.Token)
                                    .ConfigureAwait(false);
                            });

                            tasks.Add(task);
                        }
                    }

                    await Task.WhenAll(tasks);
                }
            }

            return this;
        }

        /// <summary>
        /// Wait for the index to stabilize.
        /// </summary>
        /// <remarks>
        /// The default delay is 20s, but can be configured by setting the <c>AZURE_SEARCH_CREATE_DELAY</c>
        /// environment variable to the number of seconds you want to wait otherwise.
        /// </remarks>
        /// <returns>A Task to await.</returns>
        public async Task WaitForIndexCreationAsync()
        {
            TimeSpan delay = TimeSpan.FromSeconds(20);

            string value = Environment.GetEnvironmentVariable("AZURE_SEARCH_CREATE_DELAY");
            if (int.TryParse(value, out int numValue))
            {
                delay = TimeSpan.FromSeconds(numValue);
            }

            await TestFixture.DelayAsync(delay);
        }

        /// <summary>
        /// Wait for the index to be deleted.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForIndexDeletionAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(2));

        /// <summary>
        /// Wait for blob containers to be deleted.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForBlobContainerDeletionAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(2));

        /// <summary>
        /// Wait for uploaded documents to be indexed.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForIndexingAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(2));

        /// <summary>
        /// Wait for knowledge agent creation.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForKnowledgeAgentCreationAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(2));

        /// <summary>
        /// Wait for knowledge source creation.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForKnowledgeSourceCreationAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(2));

        /// <summary>
        /// Wait for the knowledge agent to be deleted.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForKnowledgeAgentDeletionAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(5));

        /// <summary>
        /// Wait for the knowledge source to be deleted.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForKnowledgeSourceDeletionAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(5));

        /// <summary>
        /// Wait for the synonym map to be updated.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForSynonymMapUpdateAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(5));

        /// <summary>
        /// Wait for the Search Service to be provisioned.
        /// </summary>
        /// <returns>A Task to await.</returns>
        public async Task WaitForServiceProvisioningAsync() =>
            await TestFixture.DelayAsync(TimeSpan.FromSeconds(10));

        #endregion Service Management
    }
}
