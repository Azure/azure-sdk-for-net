# Route Matrix Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing#getting-started) for details.

## Import the namespaces

```C# Snippet:RouteImportNamespace
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

## Synchronous Route Matrix Request

You can send synchronous Route Matrix request when `origins * destination <= 100 request`.

```C# Snippet:GetImmediateRouteMatrix
// A simple route matrix request
RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
{
    // two origin points
    Origins = new List<GeoPosition>()
    {
        new GeoPosition(123.751, 45.9375),
        new GeoPosition(123.791, 45.96875)
    },
    // one destination point
    Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
};
Response<RouteMatrixResult> result = client.GetImmediateRouteMatrix(routeMatrixQuery);
```

To add more options to route matrix request, one can use `RouteMatrixOptions` as argument to the request:

```C# Snippet:SyncRouteMatrixWithOptions
// route matrix query
RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
{
    // two origin points
    Origins = new List<GeoPosition>()
    {
        new GeoPosition(123.751, 45.9375),
        new GeoPosition(123.791, 45.96875)
    },
    // one destination point
    Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
};

// Add more options for route matrix request
RouteMatrixOptions options = new RouteMatrixOptions(routeMatrixQuery)
{
    UseTrafficData = true,
    RouteType = RouteType.Economy
};
options.Avoid.Add(RouteAvoidType.Ferries);
options.Avoid.Add(RouteAvoidType.UnpavedRoads);

Response<RouteMatrixResult> result = client.GetImmediateRouteMatrix(options);
```

## Asynchronous Route Matrix Request

If the route matrix request is large (`origins * destination > 100`), one can use asynchronous route matrix and wait for the request to finish later. The maximum matrix available is `origins * destination <= 700`.

```C# Snippet:SimpleAsyncRouteMatrixRequest
// Instantiate route matrix query
RouteMatrixQuery routeMatrixQuery = new RouteMatrixQuery
{
    // two origin points
    Origins = new List<GeoPosition>()
    {
        new GeoPosition(123.751, 45.9375),
        new GeoPosition(123.791, 45.96875)
    },
    // one destination point
    Destinations = new List<GeoPosition>() { new GeoPosition(123.767, 45.90625) },
};

// Instantiate route matrix options
RouteMatrixOptions routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
{
    TravelTimeType = TravelTimeType.All,
};

// Invoke an long-running operation route matrix request and directly wait for completion
GetRouteMatrixOperation result = client.GetRouteMatrix(WaitUntil.Completed, routeMatrixOptions);
```

The asynchronous route matrix result will be cached for 14 days. You can fetch the result from server via a `RouteMatrixOperation` with the same `Id`:

```C# Snippet:AsyncRouteMatrixRequestWithOperationId
// Invoke an async route matrix request and get the result later via assigning `WaitUntil.Started`
GetRouteMatrixOperation operation = client.GetRouteMatrix(WaitUntil.Started, routeMatrixOptions);

// Get the operation ID and store somewhere
string operationId = operation.Id;
```

Within 14 days, You can use the same operation ID to fetch the same result. One precondition is the client endpoint should be the same:

```C# Snippet:AsyncRouteMatrixRequestWithOperationId2
// Within 14 days, users can retrive the cached result with operation ID
// The `endpoint` argument in `client` should be the same!
GetRouteMatrixOperation newRouteMatrixOperation = new GetRouteMatrixOperation(client, operationId);
Response<RouteMatrixResult> result = newRouteMatrixOperation.WaitForCompletion();
```

## Route Matrix Result

The route matrix result is stored in `RouteMatrixResult` type. You can access the `Matrix` from `RouteMatrixResult`:

```C# Snippet:RouteMatrixResult
// Route matrix result summary
Console.WriteLine($"Total request routes: {0}, Successful routes: {1}",
    result.Value.Summary.TotalRoutes,
    result.Value.Summary.SuccessfulRoutes);

// Route matrix result
foreach (IList<RouteMatrix> routeResult in result.Value.Matrix)
{
    Console.WriteLine("Route result:");
    foreach (RouteMatrix route in routeResult)
    {
        RouteLegSummary summary = route.Summary;
        Console.WriteLine($"Travel time: {summary.TravelTimeInSeconds} seconds");
        Console.WriteLine($"Travel length: {summary.LengthInMeters} meters");
        Console.WriteLine($"Departure at: {summary.DepartureTime.ToString()} meters");
        Console.WriteLine($"Arrive at: {summary.ArrivalTime.ToString()} meters");
    }
}
```
