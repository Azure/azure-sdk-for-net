# Azure Planetary Computer client library for .NET

The Azure Planetary Computer client library provides programmatic access to Microsoft Planetary Computer Pro, a geospatial data management service built on Azure's hyperscale infrastructure. Microsoft Planetary Computer Pro empowers organizations to unlock the full potential of geospatial data by providing foundational capabilities to ingest, manage, search, and distribute geospatial datasets using the SpatioTemporal Asset Catalog (STAC) open specification.

This client library enables developers to interact with GeoCatalog resources, supporting workflows from gigabytes to tens of petabytes of geospatial data.

Use the client library for Azure Planetary Computer to:

- Create, read, update, and delete STAC collections and items
- Search for geospatial data with spatial and temporal filters
- Generate map tiles (XYZ, TileJSON, WMTS) and preview images
- Configure render options, mosaics, and tile settings
- Manage data ingestion from STAC catalogs
- Generate secure access tokens for collections and assets

[Source code][source_code]
| [Product documentation][pc_product_docs]
<!-- | [Package (NuGet)][pc_nuget] -->
<!-- | [API reference documentation][pc_ref_docs] -->

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Analytics.PlanetaryComputer --prerelease
```

### Prerequisites

- An [Azure subscription][azure_sub]
- A deployed Microsoft Planetary Computer Pro GeoCatalog resource in your Azure subscription
- [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or higher

### Authenticate the client

To interact with your GeoCatalog resource, create an instance of the client with your GeoCatalog endpoint and credentials.

Microsoft Entra ID authentication is required to ensure secure, unified enterprise identity and access management for your geospatial data.

To use the [DefaultAzureCredential][azure_identity] provider shown below, or other credential providers from the Azure SDK, install the `Azure.Identity` package:

```dotnetcli
dotnet add package Azure.Identity
```

You will also need to [register a new Microsoft Entra ID application and grant access][register_aad_app] to your GeoCatalog by assigning the appropriate role to your service principal.

```csharp
string endpoint = "https://your-endpoint.geocatalog.spatio.azure.com";
PlanetaryComputerProClient client = new PlanetaryComputerProClient(
    new Uri(endpoint),
    new DefaultAzureCredential());

// Get specific clients for different operations
StacClient stacClient = client.GetStacClient();
DataClient dataClient = client.GetDataClient();
IngestionClient ingestionClient = client.GetIngestionClient();
ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();
```

## Key concepts

### StacClient

The `StacClient` provides operations for managing STAC collections and items:

- **Collection Management**: Create, update, list, and delete STAC collections to organize your geospatial datasets
- **Item Management**: Create, read, update, and delete individual STAC items within collections
- **Search API**: Search for items using spatial and temporal filters, sorting, and queryable properties
- **API Conformance**: Retrieve STAC API conformance classes and landing page information
- **Collection Configuration**: Configure render options, mosaics, tile settings, and queryables

### TilerClient

The `TilerClient` provides operations for data visualization and tiling:

- **Tile Generation**: Generate map tiles (XYZ, TileJSON, WMTS) from collections, items, and mosaics
- **Data Visualization**: Create preview images, crop by GeoJSON or bounding box, extract point values
- **Asset Metadata**: Retrieve tile matrix sets and asset metadata for collections and items
- **Map Legends**: Retrieve class map legends (categorical) and interval legends (continuous)
- **Mosaic Operations**: Register and query STAC search-based mosaics for pixel-wise data retrieval

### IngestionClient

The `IngestionClient` provides operations for data ingestion management:

- **Ingestion Sources**: Set up ingestion sources using Managed Identity or SAS token authentication
- **Ingestion Definitions**: Define automated STAC catalog ingestion from public and private data sources
- **Ingestion Runs**: Create and monitor ingestion runs with detailed operation tracking
- **Managed Identities**: List and manage Azure Managed Identities for secure access

### SharedAccessSignatureClient

The `SharedAccessSignatureClient` provides operations for secure access:

- **Token Generation**: Generate SAS tokens with configurable duration for collections
- **Asset Signing**: Sign asset HREFs for secure downloads of managed storage assets
- **Token Revocation**: Revoke tokens when needed to control access

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets covering common GeoCatalog workflows.

### List STAC Collections

List all available STAC collections:

```C# Snippet:Sample01_ListCollections
// Create a Planetary Computer client
Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");
PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());
StacClient stacClient = client.GetStacClient();

// List all available STAC collections
Response<StacCatalogCollections> response = await stacClient.GetCollectionsAsync();
StacCatalogCollections collections = response.Value;

Console.WriteLine($"Found {collections.Collections.Count} collections:");
foreach (StacCollectionResource collection in collections.Collections)
{
    Console.WriteLine($"  - {collection.Id}: {collection.Title}");
}
```

### Search for STAC Items

Search for geospatial data items with spatial filters:

```C# Snippet:Sample04_SearchSpatial
// Create a Planetary Computer client

Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

                        StacClient stacClient = client.GetStacClient();

// Search for items within a bounding box using CQL2-JSON
var searchParams = new StacSearchParameters();
searchParams.Collections.Add("naip");
searchParams.FilterLang = FilterLanguage.Cql2Json;

// Define a spatial filter for Atlanta, Georgia area
searchParams.Filter["op"] = BinaryData.FromString("\"s_intersects\"");
searchParams.Filter["args"] = BinaryData.FromObjectAsJson(new object[]
{
    new Dictionary<string, string> { ["property"] = "geometry" },
    new Dictionary<string, object>
    {
        ["type"] = "Polygon",
        ["coordinates"] = new[]
        {
            new[]
            {
                new[] { -84.46, 33.60 },
                new[] { -84.39, 33.60 },
                new[] { -84.39, 33.67 },
                new[] { -84.46, 33.67 },
                new[] { -84.46, 33.60 }
            }
        }
    }
});

searchParams.Limit = 10;

Response<StacItemCollectionResource> response = await stacClient.SearchAsync(searchParams);
StacItemCollectionResource results = response.Value;

Console.WriteLine($"Found {results.Features.Count} items in the specified area");
foreach (StacItemResource item in results.Features)
{
    Console.WriteLine($"  Item: {item.Id}");
}
```

### Get STAC Item Details

Retrieve detailed information about a specific STAC item:

```C# Snippet:Sample04_GetItem
// Create a Planetary Computer client

Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

                        StacClient stacClient = client.GetStacClient();

// Get a specific item by ID
string collectionId = "naip";
string itemId = "tx_m_2609719_se_14_060_20201216";

Response<StacItemResource> response = await stacClient.GetItemAsync(collectionId, itemId);
StacItemResource item = response.Value;

Console.WriteLine($"Item ID: {item.Id}");
Console.WriteLine($"Collection: {item.Collection}");
Console.WriteLine($"Datetime: {item.Properties?.Datetime}");

Console.WriteLine($"\nAvailable Assets:");
foreach (var asset in item.Assets)
{
    Console.WriteLine($"  {asset.Key}: {asset.Value.Href}");
}
```

### Create STAC Collection

Create a new STAC collection for organizing geospatial data:

```C# Snippet:Sample08_CreateCollection
// Create a Planetary Computer client

Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

                        StacClient stacClient = client.GetStacClient();

// Define collection ID
string collectionId = "my-test-collection";

// Define spatial extent (global coverage)
var spatialExtent = new StacExtensionSpatialExtent();
spatialExtent.BoundingBox.Add(new List<float> { -180.0f, -90.0f, 180.0f, 90.0f });

// Define temporal extent
var temporalExtent = new StacCollectionTemporalExtent(
    new[] { new List<string> { "2018-01-01T00:00:00Z", "2018-12-31T23:59:59Z" } }
);

// Combine spatial and temporal extents
var extent = new StacExtensionExtent(spatialExtent, temporalExtent);

// Create collection resource
var collection = new StacCollectionResource(
    id: collectionId,
    description: "Test collection for demonstration",
    links: new List<StacLink>(),
    license: "CC-BY-4.0",
    extent: extent)
{
    StacVersion = "1.0.0",
    Title = "Test Collection",
    Type = "Collection"
};

// Start collection creation (asynchronous operation)
Operation createOperation = await stacClient.CreateCollectionAsync(
    WaitUntil.Started,
    collection
);

Console.WriteLine($"Collection creation started: {collectionId}");
Console.WriteLine("Note: Collection creation is asynchronous and may take time to complete");
```

### Generate Map Tiles

Generate map tiles from geospatial data:

```C# Snippet:Sample06_GetTile
// Create a Planetary Computer client

Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

                        DataClient dataClient = client.GetDataClient();

string collectionId = "naip";
string itemId = "tx_m_2609719_se_14_060_20201216";

// Get a specific tile
Response<BinaryData> response = await dataClient.GetTileAsync(
    collectionId: collectionId,
    itemId: itemId,
    tileMatrixSetId: "WebMercatorQuad",
    z: 14,
    x: 4349,
    y: 6564,
    scale: 1,
    format: "png",
    assets: new[] { "image" },
    assetBandIndices: "image|1,2,3"
);

byte[] tileImage = response.Value.ToArray();
Console.WriteLine($"Tile image: {tileImage.Length} bytes");
```

### Data Ingestion Management

Manage data ingestion operations:

```C# Snippet:Sample02_CompleteWorkflow
// Create a Planetary Computer client

Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

                        IngestionClient ingestionClient = client.GetIngestionClient();

string collectionId = "my-collection";
string sourceCatalogUrl = "https://example.com/catalog.json";

// Step 1: Create an ingestion definition
var ingestionDefinition = new IngestionInformation("StaticCatalog")
{
    DisplayName = "My Dataset Ingestion",
    SourceCatalogUrl = new Uri(sourceCatalogUrl),
    KeepOriginalAssets = true,
    SkipExistingItems = true
};

Response<IngestionInformation> createResponse = await ingestionClient.CreateAsync(
    collectionId,
    ingestionDefinition);
Guid ingestionId = createResponse.Value.Id;
Console.WriteLine($"Created ingestion: {ingestionId}");

// Step 2: Create and start an ingestion run
Response<IngestionRun> runResponse = await ingestionClient.CreateRunAsync(collectionId, ingestionId);
Guid runId = runResponse.Value.Id;
Console.WriteLine($"Started ingestion run: {runId}");

// Step 3: Monitor the run progress
Response<IngestionRun> statusResponse = await ingestionClient.GetRunAsync(collectionId, ingestionId, runId);
IngestionRun run = statusResponse.Value;

Console.WriteLine($"Run Status: {run.Operation.Status}");
Console.WriteLine($"Progress: {run.Operation.TotalSuccessfulItems}/{run.Operation.TotalItems} items");

// Step 4: List all runs for this ingestion
Console.WriteLine("\nAll runs for this ingestion:");
await foreach (IngestionRun r in ingestionClient.GetRunsAsync(collectionId, ingestionId))
{
    Console.WriteLine($"  Run {r.Id}: {r.Operation.Status}");
}
```

### Generate SAS Token for Secure Access

Generate Shared Access Signatures for secure data access:

```C# Snippet:Sample03_GetTokenDefaultDuration
// Create a Planetary Computer client

Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

                        ManagedStorageSharedAccessSignatureClient sasClient = client.GetManagedStorageSharedAccessSignatureClient();

// Get a SAS token with default duration (24 hours)
string collectionId = "naip";
Response<SharedAccessSignatureToken> response = await sasClient.GetTokenAsync(collectionId);
SharedAccessSignatureToken token = response.Value;

Console.WriteLine($"SAS Token: {token.Token.Substring(0, 50)}...");
Console.WriteLine($"Expires On: {token.ExpiresOn:yyyy-MM-dd HH:mm:ss} UTC");
```

## Troubleshooting

### General

When you interact with Azure Planetary Computer using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you try to retrieve a collection that doesn't exist, a `404` error is returned, indicating `Resource Not Found`.

```csharp
PlanetaryComputerProClient client = new PlanetaryComputerProClient(
    new Uri(endpoint),
    new DefaultAzureCredential());
StacClient stacClient = client.GetStacClient();

try
{
    Response<StacCollectionResource> response = await stacClient.GetCollectionAsync(
        "nonexistent-collection");
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine($"Collection not found: {ex.Message}");
}
```

### Logging

This library uses the standard .NET [EventSource](https://docs.microsoft.com/dotnet/api/system.diagnostics.tracing.eventsource) for logging. Logs can be enabled by adding the following to your application:

```C#
using Azure.Core.Diagnostics;

// Enable logging for Azure SDK
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

For more detailed logging, including request/response bodies, use the `DiagnosticsOptions`:

```C#
PlanetaryComputerProClientOptions options = new PlanetaryComputerProClientOptions
{
    Diagnostics =
    {
        IsLoggingEnabled = true,
        IsLoggingContentEnabled = true,
        LoggedContentSizeLimit = 4096
    }
};

PlanetaryComputerProClient client = new PlanetaryComputerProClient(
    new Uri(endpoint),
    new DefaultAzureCredential(),
    options);
```

## Next steps

<!-- View [samples][pc_samples] demonstrating common patterns for working with GeoCatalog resources -->
- Review the [product documentation][pc_product_docs] on Microsoft Learn
<!-- - Review the [API reference documentation][pc_ref_docs] for detailed information about the client library -->

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][code_of_conduct_faq] or contact [opencode@microsoft.com][email_opencode] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/planetarycomputer/Azure.Analytics.PlanetaryComputer/src
<!-- [pc_nuget]: https://www.nuget.org/packages/Azure.Analytics.PlanetaryComputer -->
<!-- [pc_ref_docs]: https://learn.microsoft.com/dotnet/api/azure.analytics.planetarycomputer -->
[pc_product_docs]: https://learn.microsoft.com/azure/planetary-computer/
<!-- [pc_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/planetarycomputer/Azure.Analytics.PlanetaryComputer/samples -->

[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme
[register_aad_app]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[code_of_conduct_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[email_opencode]: mailto:opencode@microsoft.com
