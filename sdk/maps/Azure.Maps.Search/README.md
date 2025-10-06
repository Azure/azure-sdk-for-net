# Azure Maps Search client library for .NET

Azure Maps Search is a library that can query for locations, points of interests or search within a geometric area.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/src) | [API reference documentation](https://learn.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://learn.microsoft.com/rest/api/maps/search) | [Product documentation](https://learn.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Maps.Search --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://learn.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 3 ways to authenticate the client: Shared key authentication, Microsoft Entra authentication and shared access signature (SAS) authentication.

#### Shared Key Authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key Authentication** section

```C# Snippet:InstantiateSearchClientViaSubscriptionKey
// Create a SearchClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsSearchClient client = new MapsSearchClient(credential);
```

#### Microsoft Entra Authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the MapsSearchClient class. The Azure Identity library makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use Microsoft Entra authentication, set `TENANT_ID`, `CLIENT_ID`, and `CLIENT_SECRET` to environment variable and call `DefaultAzureCredential()` method to get credential. `CLIENT_ID` and `CLIENT_SECRET` are the service principal ID and secret that can access Azure Maps account.

We also need **Azure Maps Client ID** which can get from Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

```C# Snippet:InstantiateSearchClientViaMicrosoftEntra
// Create a MapsSearchClient that will authenticate through Microsoft Entra
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsSearchClient client = new MapsSearchClient(credential, clientId);
```

#### Shared Access Signature (SAS) Authentication

Shared access signature (SAS) tokens are authentication tokens created using the JSON Web token (JWT) format and are cryptographically signed to prove authentication for an application to the Azure Maps REST API.

Before integrating SAS token authentication, we need to install `Azure.ResourceManager` and `Azure.ResourceManager.Maps` (version `1.1.0-beta.2` or higher):

```powershell
dotnet add package Azure.ResourceManager
dotnet add package Azure.ResourceManager.Maps --prerelease
```

In the code, we need to import the following lines for both Azure Maps SDK and ResourceManager:

```C# Snippet:SearchImportNamespaces
using Azure.Maps.Search.Models;
```

```C# Snippet:SearchSasAuthImportNamespaces
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
```

And then we can get SAS token via [List Sas](https://learn.microsoft.com/rest/api/maps-management/accounts/list-sas?tabs=HTTP) API and assign it to `MapsSearchClient`. In the follow code sample, we fetch a specific maps account resource, and create a SAS token for 1 day expiry time when the code is executed.

```C# Snippet:InstantiateSearchClientViaSas
// Get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
TokenCredential cred = new DefaultAzureCredential();
// Authenticate your client
ArmClient armClient = new ArmClient(cred);

string subscriptionId = "MyMapsSubscriptionId";
string resourceGroupName = "MyMapsResourceGroupName";
string accountName = "MyMapsAccountName";

// Get maps account resource
ResourceIdentifier mapsAccountResourceId = MapsAccountResource.CreateResourceIdentifier(subscriptionId, resourceGroupName, accountName);
MapsAccountResource mapsAccount = armClient.GetMapsAccountResource(mapsAccountResourceId);

// Assign SAS token information
// Every time you want to SAS token, update the principal ID, max rate, start and expiry time
string principalId = "MyManagedIdentityObjectId";
int maxRatePerSecond = 500;

// Set start and expiry time for the SAS token in round-trip date/time format
DateTime now = DateTime.Now;
string start = now.ToString("O");
string expiry = now.AddDays(1).ToString("O");

MapsAccountSasContent sasContent = new MapsAccountSasContent(MapsSigningKey.PrimaryKey, principalId, maxRatePerSecond, start, expiry);
Response<MapsAccountSasToken> sas = mapsAccount.GetSas(sasContent);

// Create a SearchClient that will authenticate via SAS token
AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
MapsSearchClient client = new MapsSearchClient(sasCredential);
```

## Key concepts

`MapsSearchClient` is designed to:

* Communicate with Azure Maps endpoint to query addresses or points of locations
* Communicate with Azure Maps endpoint to request the geometry data such as a city or country outline for a set of entities
* Communicate with Azure Maps endpoint to perform a free form search inside a single geometry or many of them

Learn more by viewing our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/tests/Samples)

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

You can familiarize yourself with different APIs using our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/tests/Samples).

### Example Get Geocoding

```C# Snippet:GetGeocoding
Response<GeocodingResponse> searchResult = client.GetGeocoding("1 Microsoft Way, Redmond, WA 98052");
for (int i = 0; i < searchResult.Value.Features.Count; i++)
{
    Console.WriteLine("Coordinate:" + string.Join(",", searchResult.Value.Features[i].Geometry.Coordinates));
}
```

### Example Get Geocoding Batch

```C# Snippet:GetGeocodingBatch
List<GeocodingQuery> queries = new List<GeocodingQuery>
        {
            new GeocodingQuery()
            {
                Query ="15171 NE 24th St, Redmond, WA 98052, United States"
            },
            new GeocodingQuery()
            {
                 AddressLine = "400 Broad St"
            },
        };
Response<GeocodingBatchResponse> results = client.GetGeocodingBatch(queries);

// Print coordinates
for (var i = 0; i < results.Value.BatchItems.Count; i++)
{
    for (var j = 0; j < results.Value.BatchItems[i].Features.Count; j++)
    {
        Console.WriteLine("Coordinates: " + string.Join(",", results.Value.BatchItems[i].Features[j].Geometry.Coordinates));
    }
}
```

### Example Get Polygon

```C# Snippet:GetPolygon
GetPolygonOptions options = new GetPolygonOptions()
{
    Coordinates = new GeoPosition(-122.204141, 47.61256),
    ResultType = BoundaryResultTypeEnum.Locality,
    Resolution = ResolutionEnum.Small,
};
Response<Boundary> result = client.GetPolygon(options);

// Print polygon information
Console.WriteLine($"Boundary copyright URL: {result.Value.Properties?.CopyrightUrl}");
Console.WriteLine($"Boundary copyright: {result.Value.Properties?.Copyright}");

Console.WriteLine($"{result.Value.Geometry.Count} polygons in the result.");
Console.WriteLine($"First polygon coordinates (latitude, longitude):");

// Print polygon coordinates
foreach (var coordinate in ((GeoPolygon)result.Value.Geometry[0]).Coordinates[0])
{
    Console.WriteLine($"{coordinate.Latitude:N5}, {coordinate.Longitude:N5}");
}
```

### Example Get Reverse Geocoding

```C# Snippet:GetReverseGeocoding
GeoPosition coordinates = new GeoPosition(-122.138685, 47.6305637);
Response<GeocodingResponse> result = client.GetReverseGeocoding(coordinates);

// Print addresses
for (int i = 0; i < result.Value.Features.Count; i++)
{
    Console.WriteLine(result.Value.Features[i].Properties.Address.FormattedAddress);
}
```

### Example Get Reverse Geocoding Batch

```C# Snippet:GetReverseGeocodingBatch
List<ReverseGeocodingQuery> items = new List<ReverseGeocodingQuery>
        {
            new ReverseGeocodingQuery()
            {
                Coordinates = new GeoPosition(-122.349309, 47.620498)
            },
            new ReverseGeocodingQuery()
            {
                Coordinates = new GeoPosition(-122.138679, 47.630356),
                ResultTypes = new List<ReverseGeocodingResultTypeEnum>(){ ReverseGeocodingResultTypeEnum.Address, ReverseGeocodingResultTypeEnum.Neighborhood }
            },
        };
Response<GeocodingBatchResponse> result = client.GetReverseGeocodingBatch(items);

// Print addresses
for (var i = 0; i < result.Value.BatchItems.Count; i++)
{
    Console.WriteLine(result.Value.BatchItems[i].Features[0].Properties.Address.AddressLine);
    Console.WriteLine(result.Value.BatchItems[i].Features[0].Properties.Address.Neighborhood);
}
```

## Troubleshooting

### General

When you interact with the Azure Maps Services, errors returned by the Language service correspond to the same HTTP status codes returned for REST API requests.

For example, if you try to search with invalid coordinates, a error is returned, indicating "Bad Request".400

## Next steps

* [More samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.
