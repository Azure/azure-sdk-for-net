# Azure.Search.Documents Samples - Customer-managed Encryption Keys

Azure AI Search automatically encrypts indexed content at rest with [service-managed keys](https://learn.microsoft.com/azure/security/fundamentals/encryption-atrest#azure-encryption-at-rest-components). If more protection is needed, you can supplement default encryption with an additional encryption layer using keys that you create and manage in Azure Key Vault. This sample shows you how to set up and use customer-managed keys to further encrypt your data source connections, skillsets, indexers, and indexes for additional security.

## Getting started

This sample uses the Search service's system-assigned managed identity for
Key Vault access. Grant it Key Vault Crypto Service Encryption User on the
vault. The test runner needs Key Vault Crypto Officer to create the key,
along with Search and Storage roles specified in this document - [Configure customer-managed keys for Azure AI Search encrypted data](https://learn.microsoft.com/azure/search/search-security-manage-encryption-keys).
Application IDs and application secrets are not required for this identity path.

Use a Basic-or-higher Search service and a Key Vault with Azure RBAC, soft delete,
and purge protection enabled. Configure network access for both the caller and
the Search service. See [configure customer-managed keys for data encryption](https://learn.microsoft.com/azure/search/search-security-manage-encryption-keys)
for the service requirements.

## Using the encryption key

Once you have a Key Vault key you can use for wrapping and unwrapping service keys, you can create a `SearchResourceEncryptionKey` with the information about the key and credentials for your service principal if not using Managed Identity.

```C# Snippet:Azure_Search_Tests_EncryptedIndex_CreateDoubleEncryptedIndex_Index
// Create a credential to connect to Key Vault and use a specific key version created previously.
SearchResourceEncryptionKey encryptionKey = new SearchResourceEncryptionKey(
    new Uri(Environment.GetEnvironmentVariable("KEYVAULT_URL")),
    Environment.GetEnvironmentVariable("KEYVAULT_KEY_NAME"),
    Environment.GetEnvironmentVariable("KEYVAULT_KEY_VERSION"));

// Create a connection to our storage blob container using the credential.
string dataSourceConnectionName = "hotels-data-source";
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

SearchIndexerClient indexerClient = new SearchIndexerClient(endpoint, credential);
indexerClient.CreateDataSourceConnection(dataSourceConnection);
indexerClient.CreateIndexer(indexer);
```

The data source connections, skillsets, indexers, and indexes are doubly encrypted, but querying the index works exactly the same as normally encrypted index encrypted by the service:

```C# Snippet:Azure_Search_Tests_EncryptedIndex_CreateDoubleEncryptedIndex_Query
// Create a SearchClient and search for luxury hotels. In production, grant only the roles needed for querying.
SearchClient searchClient = new SearchClient(endpoint, "hotels", credential);
Response<SearchResults<Hotel>> results = searchClient.Search<Hotel>("luxury hotels");
foreach (SearchResult<Hotel> result in results.Value.GetResults())
{
    Hotel hotel = result.Document;

    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
    Console.WriteLine($"  Description: {hotel.Description}");
}
```
