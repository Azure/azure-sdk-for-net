# GeoJson Search Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search#getting-started) for details.

## Import the namespaces

```C# Snippet:SearchImportNamespaces
using Azure.Core.GeoJson;
using Azure.Maps.Search;
using Azure.Maps.Search.Models;
```

## Create Search Client

Before searching addresses, create a `MapsSearchClient` first. Either use subscription key or AAD.

Instantiate search client with subscription key:

```C# Snippet:InstantiateSearchClientViaSubscriptionKey
// Create a SearchClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsSearchClient client = new MapsSearchClient(credential);
```

Instantiate route client via AAD authentication:

```C# Snippet:InstantiateSearchClientViaAAD
// Create a MapsSearchClient that will authenticate through AAD
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsSearchClient client = new MapsSearchClient(credential, clientId);
```

## Search Inside Geometry

Search inside geometry API allows you to perform a free form search inside a single geometry or many of them:

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

## Get Polygon

Get Polygon API can get GeoPolygon objects from Geometry IDs. The example below can get polygon from search results:

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
