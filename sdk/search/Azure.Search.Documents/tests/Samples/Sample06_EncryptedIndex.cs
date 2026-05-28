// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
using Azure.Security.KeyVault.Keys;
using NUnit.Framework;

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

namespace Azure.Search.Documents.Tests.Samples
{
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
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;
            if (string.IsNullOrEmpty(keyVaultUrl))
            {
                Assert.Ignore("A Key Vault was not deployed");
            }

            // Create the key and persist the name and version.
            KeyVaultKey key = await CreateEncryptionKey(keyVaultUrl);
            Environment.SetEnvironmentVariable("KEYVAULT_URL", keyVaultUrl);
            Environment.SetEnvironmentVariable("KEYVAULT_KEY_NAME", key.Name);
            Environment.SetEnvironmentVariable("KEYVAULT_KEY_VERSION", key.Properties.Version);

            // Persist the service principal.
            Environment.SetEnvironmentVariable("APPLICATION_ID", TestEnvironment.ClientId);
            Environment.SetEnvironmentVariable("APPLICATION_SECRET", TestEnvironment.RecordedClientSecret);

            // Create the blob container and persist connection information.
            await using SearchResources resources = await SearchResources.CreateWithBlobStorageAndIndexAsync(this, populate: true, true);
            Environment.SetEnvironmentVariable("STORAGE_CONNECTION_STRING", resources.StorageAccountConnectionString);
            Environment.SetEnvironmentVariable("STORAGE_CONTAINER_NAME", resources.BlobContainerName);
            Environment.SetEnvironmentVariable("SEARCH_ENDPOINT", resources.Endpoint.ToString());
            Environment.SetEnvironmentVariable("SEARCH_API_KEY", resources.PrimaryApiKey);

            // Define clean up tasks to be invoked in reverse order added.
            Stack<Func<Task>> cleanUpTasks = new Stack<Func<Task>>();
            try
            {
                #region Snippet:Azure_Search_Tests_Sample06_EncryptedIndex_CreateDoubleEncryptedIndex_Index
                // Create a credential to connect to Key Vault and use a specific key version created previously.
                SearchResourceEncryptionKey encryptionKey = new SearchResourceEncryptionKey(
                    new Uri(Environment.GetEnvironmentVariable("KEYVAULT_URL")),
                    Environment.GetEnvironmentVariable("KEYVAULT_KEY_NAME"),
                    Environment.GetEnvironmentVariable("KEYVAULT_KEY_VERSION"))
                {
                    ApplicationId = Environment.GetEnvironmentVariable("APPLICATION_ID"),
                    ApplicationSecret = Environment.GetEnvironmentVariable("APPLICATION_SECRET"),
                };

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
                AzureKeyCredential credential = new AzureKeyCredential(
                    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

                SearchIndexerClient indexerClient = new SearchIndexerClient(endpoint, credential);
#if !SNIPPET
                indexerClient = resources.GetIndexerClient();
#endif
                indexerClient.CreateDataSourceConnection(dataSourceConnection);
#if !SNIPPET
                cleanUpTasks.Push(() => indexerClient.DeleteDataSourceConnectionAsync(dataSourceConnectionName));
#endif
                indexerClient.CreateIndexer(indexer);
#if !SNIPPET
                cleanUpTasks.Push(() => indexerClient.DeleteIndexerAsync(indexerName));
#endif
                #endregion Snippet:Azure_Search_Tests_Sample06_EncryptedIndex_CreateDoubleEncryptedIndex_Index

                await WaitForIndexingAsync(indexerClient, indexerName);

                #region Snippet:Azure_Search_Tests_Sample06_EncryptedIndex_CreateDoubleEncryptedIndex_Query
                // Create a SearchClient and search for luxury hotels. In production, be sure to use the query key.
                SearchClient searchClient = new SearchClient(endpoint, "hotels", credential);
#if !SNIPPET
                searchClient = resources.GetSearchClient();
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
                #endregion Snippet:Azure_Search_Tests_Sample06_EncryptedIndex_CreateDoubleEncryptedIndex_Query
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

        private async Task<KeyVaultKey> CreateEncryptionKey(string keyVaultUrl) =>
            await CreateClient<KeyClient>(
                new Uri(keyVaultUrl),
                TestEnvironment.Credential,
                // Pin the service version to mitigate ProjectReference-based pipelines from failing playback with newer versions.
                InstrumentClientOptions<KeyClientOptions>(new KeyClientOptions(KeyClientOptions.ServiceVersion.V7_0)))
                .CreateRsaKeyAsync(
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
