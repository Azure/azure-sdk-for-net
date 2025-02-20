# Route Directions Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing#getting-started) for details.

## Import the namespaces

```C# Snippet:RouteImportNamespaces
using Azure.Core.GeoJson;
using Azure.Maps.Routing;
using Azure.Maps.Routing.Models;
```

## Create Route Client

Before rendering any images or tiles, create a `MapsRoutingClient` first. Either use subscription key or AAD.

Instantiate route client with subscription key:

```C# Snippet:InstantiateRouteClientViaSubscriptionKey
// Create a MapsRoutingClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsRoutingClient client = new MapsRoutingClient(credential);
```

Instantiate route client via AAD authentication:

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRoutingClient that will authenticate through Active Directory
TokenCredential credential = new DefaultAzureCredential();
string clientId = "<Your Map ClientId>";
MapsRoutingClient client = new MapsRoutingClient(credential, clientId);
```

## Get Route Direction

Most of the time, we want to get a route direction, we can call `GetRouteDirection` to get the routing for a specific query:

```C# Snippet:GetDirections
// Create origin and destination routing points
List<GeoPosition> routePoints = new List<GeoPosition>()
{
    new GeoPosition(123.751, 45.9375),
    new GeoPosition(123.791, 45.96875),
    new GeoPosition(123.767, 45.90625)
};

// Create Route direction query object
RouteDirectionQuery query = new RouteDirectionQuery(routePoints);
Response<RouteDirections> result = client.GetDirections(query);

// Route direction result
Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeDuration);

// Route points
foreach (RouteLeg leg in result.Value.Routes[0].Legs)
{
    Console.WriteLine("Route path:");
    foreach (GeoPosition point in leg.Points)
    {
        Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
    }
}
```

You can also specify the travel mode, route type, language, and other options when route to point of interests:

```C# Snippet:RouteDirectionsWithOptions
// Create origin and destination routing points
List<GeoPosition> routePoints = new List<GeoPosition>()
{
    new GeoPosition(123.751, 45.9375),
    new GeoPosition(123.791, 45.96875),
    new GeoPosition(123.767, 45.90625)
};

RouteDirectionOptions options = new RouteDirectionOptions()
{
    RouteType = RouteType.Fastest,
    UseTrafficData = true,
    TravelMode = TravelMode.Bicycle,
    Language = RoutingLanguage.EnglishUsa,
};

// Create Route direction query object
RouteDirectionQuery query = new RouteDirectionQuery(routePoints);
Response<RouteDirections> result = client.GetDirections(query);

// Route direction result
Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeDuration);

// Route points
foreach (RouteLeg leg in result.Value.Routes[0].Legs)
{
    Console.WriteLine("Route path:");
    foreach (GeoPosition point in leg.Points)
    {
        Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
    }
}
```

## Synchronous Route Direction Batch Request

You can send batch synchronous Route Direction request when route direction queries `<= 100` requests:

```C# Snippet:GetDirectionsImmediateBatch
// Create a list of route direction queries
IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

queries.Add(new RouteDirectionQuery(
    new List<GeoPosition>()
    {
        new GeoPosition(123.751, 45.9375),
        new GeoPosition(123.791, 45.96875),
        new GeoPosition(123.767, 45.90625)
    },
    new RouteDirectionOptions()
    {
        TravelMode = TravelMode.Bicycle,
        RouteType = RouteType.Economy,
        UseTrafficData = false,
    })
);
queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

// Call synchronous route direction batch request
Response<RouteDirectionsBatchResult> response = client.GetDirectionsImmediateBatch(queries);
```

## Asynchronous Route Direction Batch Request

If there are more then `100` route direction queries, one can use asynchronous route direction batch request and wait for the request to finish later. The maximum matrix available queries are `700`.

```C# Snippet:AsyncRequestRouteDirectionsBatch
// Create a list of route direction queries
IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

queries.Add(new RouteDirectionQuery(
    new List<GeoPosition>()
    {
        new GeoPosition(123.751, 45.9375),
        new GeoPosition(123.791, 45.96875),
        new GeoPosition(123.767, 45.90625)
    },
    new RouteDirectionOptions()
    {
        TravelMode = TravelMode.Bicycle,
        RouteType = RouteType.Economy,
        UseTrafficData = false,
    })
);
queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

// Invoke asynchronous route direction batch request, we can get the result later via assigning `WaitUntil.Started`
GetDirectionsOperation operation = await client.GetDirectionsBatchAsync(WaitUntil.Started, queries);

// After a while, get the result back
Response<RouteDirectionsBatchResult> result = operation.WaitForCompletion();
```

The asynchronous route direction result will be cached for 14 days. You can fetch the result from server via a `RequestRouteDirectionsOperation` with the same `Id`:

```C# Snippet:AsyncRequestRouteDirectionsBatchWithOperationId
// Create a list of route direction queries
IList<RouteDirectionQuery> queries = new List<RouteDirectionQuery>();

queries.Add(new RouteDirectionQuery(
    new List<GeoPosition>()
    {
        new GeoPosition(123.751, 45.9375),
        new GeoPosition(123.791, 45.96875),
        new GeoPosition(123.767, 45.90625)
    },
    new RouteDirectionOptions()
    {
        TravelMode = TravelMode.Bicycle,
        RouteType = RouteType.Economy,
        UseTrafficData = false,
    })
);
queries.Add(new RouteDirectionQuery(new List<GeoPosition>() { new GeoPosition(123.751, 45.9375), new GeoPosition(123.767, 45.90625) }));

// Invoke asynchronous route direction batch request
GetDirectionsOperation operation = client.GetDirectionsBatch(WaitUntil.Started, queries);

// Get the operation ID and store somewhere
string operationId = operation.Id;
```

Within 14 days, you can use the same operation ID to fetch the same result. One precondition is the client endpoint should be the same:

```C# Snippet:AsyncRequestRouteDirectionsBatchWithOperationId2
// Within 14 days, users can retrive the cached result with operation ID
// The `endpoint` argument in `client` should be the same!
GetDirectionsOperation newRouteDirectionOperation = new GetDirectionsOperation(client, operationId);
Response<RouteDirectionsBatchResult> result = newRouteDirectionOperation.WaitForCompletion();
```

## Route Direction Result

Route direction result is stored in `RouteDirectionsBatchResult` type. You can access the `BatchItems` from `RouteDirectionsBatchResult`:

```C# Snippet:RouteDirectionsBatchResult
for (int i = 0; i < response.Value.Results.Count; i++)
{
    RouteDirectionsBatchItemResponse result = response.Value.Results[i];
    Console.WriteLine($"Batch item result {0}:", i);

    foreach (RouteData route in result.Routes)
    {
        Console.WriteLine($"Total length: {0} meters, travel time: {1} seconds",
            route.Summary.LengthInMeters, route.Summary.TravelTimeDuration
        );

        Console.WriteLine($"Route path:");
        for (int legIndex = 0; legIndex < route.Legs.Count; legIndex++)
        {
            Console.WriteLine($"Leg {0}", legIndex);
            foreach (GeoPosition point in route.Legs[legIndex].Points)
            {
                Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
            }
        }
    }
}
```
