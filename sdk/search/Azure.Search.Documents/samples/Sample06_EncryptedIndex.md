# Azure.Search.Documents Samples - Customer-managed Encryption Keys

Azure AI Search automatically encrypts indexed content at rest with [service-managed keys](https://docs.microsoft.com/azure/security/fundamentals/encryption-atrest#azure-encryption-at-rest-components). If more protection is needed, you can supplement default encryption with an additional encryption layer using keys that you create and manage in Azure Key Vault. This sample shows you how to set up and use customer-managed keys to further encrypt your data source connections, skillsets, indexers, and indexes for additional security.

## Getting started

To begin using Customer-Managed Keys (CMK), follow steps 1 through 5 to [configure customer-managed keys for data encryption](https://docs.microsoft.com/azure/search/search-security-manage-encryption-keys). This will guide you how to configure your Key Vault, register a service principal if necessary, and grant appropriate access to a service principal for a Key Vault key. This can be a key you created previously, or you can create a key that can wrap and unwrap service keys, including AES and RSA keys like in the following example:

```bash
# Create a resource group for your Key Vault and Azure AI Search service.
# At this time, CMK is limited to certain regions including West US 2,
# so we'll create everything in that location.
az group create -n "<group-name>" -l westus2

az keyvault create -g "<group-name>" -n "<vault-name>" -l westus2 --enable-purge-protection

# Create a service principal for RBAC, or you can use Managed Identity.
az ad sp create-for-rbac -n "<app-name>" --skip-assignment
```

The last command will provide output like the following:

```json
{
    "appId": "<random-app-ID>",
    "displayName": "<app-name>",
    "name": "http://<app-name>",
    "password": "<random-password>",
    "tenant": "<tenant-ID>"
}
```

Using that information, set up the Key Vault policy to allow specific access permissions and create a key:

```bash
az keyvault set-policy -n "<vault-name>" --spn "<generated-app-ID>" --certificate-permissions get --key-permissions get wrapKey unwrapKey --secret-permissions get

# Create an RSA key that can wrap and unwrap service-managed keys.
az keyvault key create --vault-name "<vault-name>" -n "<key-name>" --kty rsa --size 2048 --expires "<Y-m-d'T'H:M:S'Z'>" --ops wrapKey unwrapKey
```

## Using the encryption key

Once you have a Key Vault key you can use for wrapping and unwrapping service keys, you can create a `SearchResourceEncryptionKey` with the information about the key and credentials for your service principal if not using Managed Identity.

```C# Snippet:Azure_Search_Tests_Sample06_EncryptedIndex_CreateDoubleEncryptedIndex_Index
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
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexerClient indexerClient = new SearchIndexerClient(endpoint, credential);
indexerClient.CreateDataSourceConnection(dataSourceConnection);
indexerClient.CreateIndexer(indexer);
```

The data source connections, skillsets, indexers, and indexes are doubly encrypted, but querying the index works exactly the same as normally encrypted index encrypted by the service:

```C# Snippet:Azure_Search_Tests_Sample06_EncryptedIndex_CreateDoubleEncryptedIndex_Query
// Create a SearchClient and search for luxury hotels. In production, be sure to use the query key.
SearchClient searchClient = new SearchClient(endpoint, "hotels", credential);
Response<SearchResults<Hotel>> results = searchClient.Search<Hotel>("luxury hotels");
foreach (SearchResult<Hotel> result in results.Value.GetResults())
{
    Hotel hotel = result.Document;

    Console.WriteLine($"{hotel.HotelName} ({hotel.HotelId})");
    Console.WriteLine($"  Description: {hotel.Description}");
}
```
