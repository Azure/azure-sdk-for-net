// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Azure.Security.KeyVault.Keys;
using NUnit.Framework;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

namespace Azure.Search.Documents.Tests.Samples
{
    // Keep the fixture version compatible with the existing recording.
    [ClientTestFixture(SearchClientOptions.ServiceVersion.V2024_07_01)]
    public class EncryptedIndex : SearchTestBase
    {
        public EncryptedIndex(bool async, SearchClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
            // TODO: enable after new KeyValue is released (after Dec 2023)
            TestDiagnostics = false;
        }

        [Test]
        [SyncOnly]
        public async Task CreateDoubleEncryptedIndex()
        {
            if (Mode != RecordedTestMode.Playback)
            {
                if (!TestEnvironment.RunDoubleEncryptedIndex)
                {
                    Assert.Ignore(
                        "Set SEARCH_RUN_DOUBLE_ENCRYPTED_INDEX=true to allow creating and deleting encryption test objects. " +
                        "See the CreateDoubleEncryptedIndex section in .env.example for prerequisites.");
                }

                TestEnvironment.ValidateDoubleEncryptedIndexConfiguration();
            }

            string keyVaultUrl = TestEnvironment.KeyVaultUrl;
            if (string.IsNullOrEmpty(keyVaultUrl))
            {
                Assert.Ignore("A Key Vault was not deployed");
            }

            // Create the key and persist the name and version.
            KeyClient keyClient = CreateKeyClient(keyVaultUrl);
            KeyVaultKey key = await CreateEncryptionKey(keyClient);
            Stack<Func<Task>> cleanUpTasks = new Stack<Func<Task>>();
            // Older recordings did not delete the key and contain no deletion requests.
            if (Recording.GetVariable("DeleteEncryptionKey", "true") == "true")
            {
                cleanUpTasks.Push(async () =>
                {
                    DeleteKeyOperation deletion = await keyClient.StartDeleteKeyAsync(key.Name, CancellationToken.None);
                    await deletion.WaitForCompletionAsync(CancellationToken.None);
                });
            }

            try
            {
                Environment.SetEnvironmentVariable("KEYVAULT_URL", keyVaultUrl);
                Environment.SetEnvironmentVariable("KEYVAULT_KEY_NAME", key.Name);
                Environment.SetEnvironmentVariable("KEYVAULT_KEY_VERSION", key.Properties.Version);

                // Create the blob container and persist connection information.
                SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this, populate: true, true);
                cleanUpTasks.Push(() => resources.DisposeAsync().AsTask());
                // Preserve offline playback of recordings made before managed-identity storage connections.
                bool legacyPlayback = Mode == RecordedTestMode.Playback &&
                    !Recording.Variables.ContainsKey("SEARCH_STORAGE_RESOURCE_ID");
                string storageConnectionString = legacyPlayback
                    ? $"DefaultEndpointsProtocol=https;AccountName={resources.StorageAccountName};AccountKey={resources.StorageAccountKey};EndpointSuffix={resources.StorageEndpointSuffix}"
                    : resources.StorageAccountConnectionString;
                Environment.SetEnvironmentVariable("STORAGE_CONNECTION_STRING", storageConnectionString);
                Environment.SetEnvironmentVariable("STORAGE_CONTAINER_NAME", resources.BlobContainerName);
                Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());

                #region Snippet:Azure_Search_Tests_EncryptedIndex_CreateDoubleEncryptedIndex_Index
                // Create a credential to connect to Key Vault and use a specific key version created previously.
                SearchResourceEncryptionKey encryptionKey = new SearchResourceEncryptionKey(
                    new Uri(Environment.GetEnvironmentVariable("KEYVAULT_URL")),
                    Environment.GetEnvironmentVariable("KEYVAULT_KEY_NAME"),
                    Environment.GetEnvironmentVariable("KEYVAULT_KEY_VERSION"));

                // Create a connection to our storage blob container using the credential.
                string dataSourceConnectionName = "hotels-data-source";
#if !SNIPPET
                dataSourceConnectionName = Recording.Random.GetName();
#endif
                SearchIndexerDataSourceConnection dataSourceConnection = new SearchIndexerDataSourceConnection(
                    dataSourceConnectionName,
                    SearchIndexerDataSourceType.AzureBlob,
                    Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING"),
                    new SearchIndexerDataContainer(
                        Environment.GetEnvironmentVariable("STORAGE_CONTAINER_NAME")
                    )
                )
                {
                    EncryptionKey = encryptionKey
                };

                // Create an indexer to process documents from the blob container into the index.
                // You can optionally configure a skillset to use cognitive services when processing documents.
                // Set the SearchIndexerSkillset.EncryptionKey to the same credential if you use a skillset.
                string indexName = "hotels";
                string indexerName = "hotels-indexer";
#if !SNIPPET
                indexName = resources.IndexName;
                indexerName = Recording.Random.GetName();
#endif
                SearchIndexer indexer = new SearchIndexer(
                    indexerName,
                    dataSourceConnectionName,
                    indexName)
                {
                    EncryptionKey = encryptionKey,

                    // Map the fields in our documents we want to index.
                    FieldMappings =
                    {
                        new FieldMapping("HotelId"),
                        new FieldMapping("HotelName"),
                        new FieldMapping("Description"),
                        new FieldMapping("Tags"),
                        new FieldMapping("Address")
                    },
                    Parameters = new IndexingParameters
                    {
                        // Tell the indexer to parse each blob as a separate JSON document.
                        IndexingParametersConfiguration = new IndexingParametersConfiguration
                        {
                            ParsingMode = BlobIndexerParsingMode.Json
                        }
                    }
                };

                // Now connect to our Search service and set up the data source and indexer.
                // Documents already in the storage blob will begin indexing immediately.
                Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
                TokenCredential credential = new DefaultAzureCredential();
#if !SNIPPET
                credential = TestEnvironment.Credential;
#endif

                SearchIndexerClient indexerClient = new SearchIndexerClient(endpoint, credential);
#if !SNIPPET
                indexerClient = legacyPlayback
                    ? InstrumentClient(new SearchIndexerClient(endpoint, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()))
                    : resources.GetIndexerClient();
#endif
                indexerClient.CreateDataSourceConnection(dataSourceConnection);
#if !SNIPPET
                cleanUpTasks.Push(() => indexerClient.DeleteDataSourceConnectionAsync(dataSourceConnectionName, cancellationToken: CancellationToken.None));
#endif
                indexerClient.CreateIndexer(indexer);
#if !SNIPPET
                cleanUpTasks.Push(() => indexerClient.DeleteIndexerAsync(indexerName, cancellationToken: CancellationToken.None));
#endif
                #endregion Snippet:Azure_Search_Tests_EncryptedIndex_CreateDoubleEncryptedIndex_Index

                await WaitForIndexingAsync(indexerClient, indexerName);

                #region Snippet:Azure_Search_Tests_EncryptedIndex_CreateDoubleEncryptedIndex_Query
                // Create a SearchClient and search for luxury hotels. In production, grant only the roles needed for querying.
                SearchClient searchClient = new SearchClient(endpoint, "hotels", credential);
#if !SNIPPET
                searchClient = legacyPlayback
                    ? InstrumentClient(new SearchClient(endpoint, resources.IndexName, new AzureKeyCredential(resources.PrimaryApiKey), GetSearchClientOptions()))
                    : resources.GetSearchClient();
                bool found = false;
#endif
                Response<SearchResults<Hotel>> results = searchClient.Search<Hotel>("luxury hotels");
                foreach (SearchResult<Hotel> result in results.Value.GetResults())
                {
                    Hotel hotel = result.Document;
#if !SNIPPET
                    found = true;
#endif

                    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
                    Console.WriteLine($"  Description: {hotel.Description}");
                }
                #endregion Snippet:Azure_Search_Tests_EncryptedIndex_CreateDoubleEncryptedIndex_Query
#if !SNIPPET
                Assert.IsTrue(found, "No luxury hotels were found in index");
#endif
            }
            finally
            {
                // We want to await these individual to create a deterministic order for playing back tests.
                foreach (Func<Task> cleanUpTask in cleanUpTasks)
                {
                    await cleanUpTask();
                }
            }
        }

        private KeyClient CreateKeyClient(string keyVaultUrl) =>
            CreateClient<KeyClient>(
                new Uri(keyVaultUrl),
                TestEnvironment.Credential,
                // Pin the service version to mitigate ProjectReference-based pipelines from failing playback with newer versions.
                InstrumentClientOptions<KeyClientOptions>(new KeyClientOptions(KeyClientOptions.ServiceVersion.V7_0)));

        private async Task<KeyVaultKey> CreateEncryptionKey(KeyClient client) =>
            await client.CreateRsaKeyAsync(
                    new CreateRsaKeyOptions(Recording.Random.GetName())
                    {
                        KeySize = 2048,
                        KeyOperations =
                        {
                            KeyOperation.WrapKey,
                            KeyOperation.UnwrapKey,
                        },
                    });
    }
}
