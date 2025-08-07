# Geocoding Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search#getting-started) for details.

## Import the namespaces

```C# Snippet:SearchImportNamespaces
using Azure.Maps.Search.Models;
```

## Create Search Client

Before searching addresses, create a `MapsSearchClient` first. Either use subscription key or Microsoft Entra.

Instantiate search client with subscription key:

```C# Snippet:InstantiateSearchClientViaSubscriptionKey
// Create a SearchClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsSearchClient client = new MapsSearchClient(credential);
```

Instantiate route client via Microsoft Entra authentication:

```C# Snippet:InstantiateSearchClientViaMicrosoftEntra
// Create a MapsSearchClient that will authenticate through Microsoft Entra
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsSearchClient client = new MapsSearchClient(credential, clientId);
```

## Get Geocoding

Most of the time, we only want to search for a specific address. We can call `GetGeocoding` (or `GetGeocodingAsync` for asynchronous call):

```C# Snippet:GetGeocoding
Response<GeocodingResponse> searchResult = client.GetGeocoding("1 Microsoft Way, Redmond, WA 98052");
for (int i = 0; i < searchResult.Value.Features.Count; i++)
{
    Console.WriteLine("Coordinate:" + string.Join(",", searchResult.Value.Features[i].Geometry.Coordinates));
}
```

You can also search multiple addresses. If the queries are less than 100, use `GetGeocodingBatch` (or `GetGeocodingBatchAsync` for asynchronous call):

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

## Get Polygon

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

## Get Reverse Geocoding

Translate a coordinate (example: 37.786505, -122.3862) into a human understandable street address. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. You can use `GetReverseGeocoding` (or `GetReverseGeocodingAsync` for asynchronous call):


```C# Snippet:GetReverseGeocoding
GeoPosition coordinates = new GeoPosition(-122.138685, 47.6305637);
Response<GeocodingResponse> result = client.GetReverseGeocoding(coordinates);

// Print addresses
for (int i = 0; i < result.Value.Features.Count; i++)
{
    Console.WriteLine(result.Value.Features[i].Properties.Address.FormattedAddress);
}
```

You can also search multiple coordinates. If the queries are less than 100, use `GetReverseGeocodingBatch` (or `GetReverseGeocodingBatchAsync` for asynchronous call):

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
