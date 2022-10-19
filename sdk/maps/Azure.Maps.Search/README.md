# Azure Maps Search client library for .NET

Azure Maps Search is a library that can query for locations, points of interests or search within a geometric area.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/src) | [API reference documentation](https://docs.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://docs.microsoft.com/rest/api/maps/search) | [Product documentation](https://docs.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Maps.Search --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://docs.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 2 ways to authenticate the client: Shared key authentication and Azure AD.

#### Shared Key Authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key Authentication** section

```C# Snippet:InstantiateSearchClientViaSubscriptionKey
// Create a SearchClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsSearchClient client = new MapsSearchClient(credential);
```

#### Azure AD Authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the MapsSearchClient class. The Azure Identity library makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, set `TENANT_ID`, `CLIENT_ID`, and `CLIENT_SECRET` to environment variable and call `DefaultAzureCredential()` method to get credential. `CLIENT_ID` and `CLIENT_SECRET` are the service principal ID and secret that can access Azure Maps account.

We also need **Azure Maps Client ID** which can get from Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

```C# Snippet:InstantiateSearchClientViaAAD
// Create a MapsSearchClient that will authenticate through AAD
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsSearchClient client = new MapsSearchClient(credential, clientId);
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
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

You can familiarize yourself with different APIs using our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/tests/Samples).

### Example Get Polygons

```C# Snippet:GetPolygons
// Get Addresses
Response<SearchAddressResult> searchResult = await client.SearchAddressAsync("Seattle");

// Extract geometry ids from addresses
string geometry0Id = searchResult.Value.Results[0].DataSources.Geometry.Id;
string geometry1Id = searchResult.Value.Results[1].DataSources.Geometry.Id;

// Extract position coordinates
GeoPosition positionCoordinates = searchResult.Value.Results[0].Position;

// Get polygons from geometry ids
PolygonResult polygonResponse = await client.GetPolygonsAsync(new[] { geometry0Id, geometry1Id });

// Get polygons objects
IReadOnlyList<PolygonObject> polygonList = polygonResponse.Polygons;
```

### Example Fuzzy Search

```C# Snippet:FuzzySearch
Response<SearchAddressResult> fuzzySearchResponse = await client.FuzzySearchAsync("coffee", new FuzzySearchOptions
{
    Coordinates = new GeoPosition(121.56, 25.04),
    Language = SearchLanguage.EnglishUsa
});

// Print out the possible results
Console.WriteLine("The possible results for coffee shop:");
foreach (SearchAddressResultItem result in fuzzySearchResponse.Value.Results)
{
    Console.WriteLine("Coordinate: {0}, Address: {1}",
        result.Position, result.Address.FreeformAddress);
}
```

### Example Reverse Search Cross Street Address

```C# Snippet:ReverseSearchCrossStreetAddress
var reverseResult = await client.ReverseSearchCrossStreetAddressAsync(new ReverseSearchCrossStreetOptions
{
    Coordinates = new GeoPosition(121.0, 24.0),
    Language = SearchLanguage.EnglishUsa
});
```

### Example Search Structured Address

```C# Snippet:SearchStructuredAddress
var address = new StructuredAddress
{
    CountryCode = "US",
    StreetNumber = "15127",
    StreetName = "NE 24th Street",
    Municipality = "Redmond",
    CountrySubdivision = "WA",
    PostalCode = "98052"
};
Response<SearchAddressResult> searchResult = await client.SearchStructuredAddressAsync(address);

SearchAddressResultItem resultItem = searchResult.Value.Results[0];
Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
    resultItem.Position, resultItem.Address.FreeformAddress);
```

### Example Search Inside Geometry

```C# Snippet:SearchInsideGeometry
GeoPolygon sfPolygon = new GeoPolygon(new[]
{
    new GeoPosition(-122.43576049804686, 37.752415234354402),
    new GeoPosition(-122.4330139160, 37.706604725423119),
    new GeoPosition(-122.36434936523438, 37.712059855877314),
    new GeoPosition(-122.43576049804686, 37.7524152343544)
});

GeoPolygon taipeiPolygon = new GeoPolygon(new[]
{
    new GeoPosition(121.56, 25.04),
    new GeoPosition(121.565, 25.04),
    new GeoPosition(121.565, 25.045),
    new GeoPosition(121.56, 25.045),
    new GeoPosition(121.56, 25.04)
});

// Search coffee shop in Both polygons, return results in en-US
Response<SearchAddressResult> searchResponse = await client.SearchInsideGeometryAsync("coffee", new GeoCollection(new[] { sfPolygon, taipeiPolygon }), new SearchInsideGeometryOptions
{
    Language = SearchLanguage.EnglishUsa
});

// Get Taipei Cafe and San Francisco cafe and print first place
SearchAddressResultItem taipeiCafe = searchResponse.Value.Results.Where(addressItem => addressItem.SearchAddressResultType == "POI" && addressItem.Address.Municipality == "Taipei City").First();
SearchAddressResultItem sfCafe = searchResponse.Value.Results.Where(addressItem => addressItem.SearchAddressResultType == "POI" && addressItem.Address.Municipality == "San Francisco").First();

Console.WriteLine("Possible Coffee shop in the Polygons:");
Console.WriteLine("Coffee shop address in Taipei: {0}", taipeiCafe.Address.FreeformAddress);
Console.WriteLine("Coffee shop address in San Francisco: {0}", sfCafe.Address.FreeformAddress);
```

### Example Search Address

```C# Snippet:SearchAddress
Response<SearchAddressResult> searchResult = await client.SearchAddressAsync("Seattle");

SearchAddressResultItem resultItem = searchResult.Value.Results[0];
Console.WriteLine("First result - Coordinate: {0}, Address: {1}",
    resultItem.Position, resultItem.Address.FreeformAddress);
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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/maps/Azure.Maps.Search/README.png)
