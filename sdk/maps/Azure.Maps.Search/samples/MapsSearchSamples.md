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
var query = "15171 NE 24th St, Redmond, WA 98052, United States";
Response <GeocodingResponse> result = client.GetGeocoding(query);
Console.WriteLine("Result for query: \"{0}\"", query);
Console.WriteLine(result);
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
                 Coordinates = new GeoPosition(121.5, 25.0)
            },
        };
Response<GeocodingBatchResponse> results = client.GetGeocodingBatch(queries);
Console.WriteLine(results);
```

## Get Polygon

```C# Snippet:GetPolygon
GetPolygonOptions options = new GetPolygonOptions()
{
    Coordinates = new GeoPosition(121.5, 25.0)
};
Response<Boundary> result = client.GetPolygon(options);
Console.WriteLine(result);
```

## Get Reverse Geocoding

Translate a coordinate (example: 37.786505, -122.3862) into a human understandable street address. Most often this is needed in tracking applications where you receive a GPS feed from the device or asset and wish to know what address where the coordinate is located. You can use `GetReverseGeocoding` (or `GetReverseGeocodingAsync` for asynchronous call):


```C# Snippet:GetReverseGeocoding
GeoPosition coordinates = new GeoPosition(-122.138685, 47.6305637);
Response<GeocodingResponse> result = client.GetReverseGeocoding(coordinates);
```

You can also search multiple coordinates. If the queries are less than 100, use `GetReverseGeocodingBatch` (or `GetReverseGeocodingBatchAsync` for asynchronous call):

```C# Snippet:GetReverseGeocodingBatch
List<ReverseGeocodingQuery> items = new List<ReverseGeocodingQuery>
        {
            new ReverseGeocodingQuery()
            {
                Coordinates = new GeoPosition(121.53, 25.0)
            },
            new ReverseGeocodingQuery()
            {
                Coordinates = new GeoPosition(121.5, 25.0)
            },
        };
Response<GeocodingBatchResponse> result = client.GetReverseGeocodingBatch(items);
```
