﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
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
        /// The storage account connection string.
        /// </summary>
        public string StorageAccountConnectionString => $"DefaultEndpointsProtocol=https;AccountName={StorageAccountName};AccountKey={StorageAccountKey};EndpointSuffix=core.windows.net";

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
        /// The URI of the Search service.
        /// </summary>
        public Uri Endpoint => new Uri($"https://{SearchServiceName}.search.windows.net");

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
        /// Create a new Search Service resource with an empty Hotel index.
        /// See TestResources.Data.cs for the index schema.
        /// </summary>
        /// <param name="fixture">
        /// The TestFixture with context about our current test run,
        /// recordings, instrumentation, etc.
        /// </param>
        /// <returns>A new TestResources context.</returns>
        public static async Task<SearchResources> CreateWithEmptyHotelsIndexAsync(SearchTestBase fixture)
        {
            var resources = new SearchResources(fixture);
            await resources.CreateSearchServiceAndIndexAsync();
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
        public static async Task<SearchResources> CreateWithHotelsIndexAsync(SearchTestBase fixture)
        {
            var resources = new SearchResources(fixture);
            await resources.CreateSearchServiceIndexAndDocumentsAsync();
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
        /// <returns>A new <see cref="SearchResources"/> context.</returns>
        public static async Task<SearchResources> CreateWithBlobStorageAndIndexAsync(SearchTestBase fixture)
        {
            var resources = new SearchResources(fixture);

            // Keep them ordered or records may not match seeded random names.
            await resources.CreateSearchServiceAndIndexAsync();
            await resources.CreateHotelsBlobContainerAsync();

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
        public static async Task<SearchResources> GetSharedHotelsIndexAsync(SearchTestBase fixture)
        {
            await SharedSearchResources.EnsureInitialized(async () => await CreateWithHotelsIndexAsync(fixture));

            // Clone it for the current fixture (note that setting these values
            // will create the recording ServiceName/IndexName/etc. variables)
            return new SearchResources(fixture)
            {
                IndexName = SharedSearchResources.Search.IndexName,
            };
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
        /// <returns>This TestResources context.</returns>
        private async Task<SearchResources> CreateSearchServiceAndIndexAsync()
        {
            // Create the index
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                // Generate a random Index Name
                IndexName = Random.GetName(8);

                SearchIndexClient client = new SearchIndexClient(Endpoint, new AzureKeyCredential(PrimaryApiKey));
                await client.CreateIndexAsync(GetHotelIndex(IndexName));

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
        private async Task<SearchResources> CreateSearchServiceIndexAndDocumentsAsync()
        {
            // Create the Search Service and Index first
            await CreateSearchServiceAndIndexAsync();

            // Upload the documents
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                SearchClient client = new SearchClient(Endpoint, IndexName, new AzureKeyCredential(PrimaryApiKey));
                IndexDocumentsBatch<Hotel> batch = IndexDocumentsBatch.Upload(TestDocuments);
                await client.IndexDocumentsAsync(batch);

                await WaitForIndexingAsync();
            }

            return this;
        }

        /// <summary>
        /// Upload <see cref="TestDocuments"/> to a new blob storage container identified by <see cref="BlobContainerName"/>.
        /// </summary>
        /// <returns>The current <see cref="SearchResources"/>.</returns>
        private async Task<SearchResources> CreateHotelsBlobContainerAsync()
        {
            if (TestFixture.Mode != RecordedTestMode.Playback)
            {
                BlobContainerName = Random.GetName(8);

                using CancellationTokenSource cts = new CancellationTokenSource(Timeout);

                BlobContainerClient client = new BlobContainerClient(StorageAccountConnectionString, BlobContainerName);
                await client.CreateIfNotExistsAsync(cancellationToken: cts.Token);

                RequiresBlobContainerCleanup = true;

                Hotel[] hotels = TestDocuments;
                List<Task> tasks = new List<Task>(hotels.Length);

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

                await Task.WhenAll(tasks);
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
