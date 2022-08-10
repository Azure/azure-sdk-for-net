# Route Matrix Samples

To use these samples, you'll first need to set up resources. See [getting started](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Route#getting-started) for details.

## Synchronous Route Matrix Request

User can send synchronous Route Matrix request when `origins * destination <= 100 request`.

```C# Snippet:SimpleSyncRouteMatrix
// A simple route matrix request
var routeMatrixQuery = new RouteMatrixQuery
{
    // two origin points
    Origins = new GeoPointCollection(new List<GeoPoint>() {
        new GeoPoint(45.9375, 123.751),
        new GeoPoint(45.96875, 123.791)
    }),
    // one destination point
    Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
};
var result = client.SyncRequestRouteMatrix(routeMatrixQuery);
```

To add more options to route matrix request, one can use `RouteMatrixOptions` as argument to the request:

```C# Snippet:SyncRouteMatrixWithOptions
// route matrix query
var routeMatrixQuery = new RouteMatrixQuery
{
    // two origin points
    Origins = new GeoPointCollection(new List<GeoPoint>() {
        new GeoPoint(45.9375, 123.751),
        new GeoPoint(45.96875, 123.791)
    }),
    // one destination point
    Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
};

// Add more options for route matrix request
var options = new RouteMatrixOptions(routeMatrixQuery)
{
    UseTrafficData = true,
    RouteType = RouteType.Economy
};
options.Avoid.Add(RouteAvoidType.Ferries);
options.Avoid.Add(RouteAvoidType.UnpavedRoads);

var result = client.SyncRequestRouteMatrix(options);
```

## Asynchronous Route Matrix Request

If the route matrix request is large (`origins * destination > 100`), one can use asynchronous route matrix and wait for the request to finish later. The maximum matrix available is `origins * destination <= 700`.

```C# Snippet:SimpleAsyncRouteMatrixRequest
// Instantiate route matrix query
var routeMatrixQuery = new RouteMatrixQuery
{
    // two origin points
    Origins = new GeoPointCollection(new List<GeoPoint>() {
        new GeoPoint(45.9375, 123.751),
        new GeoPoint(45.96875, 123.791)
    }),
    // one destination point
    Destinations = new GeoPointCollection(new List<GeoPoint>() { new GeoPoint(45.90625, 123.767) }),
};

// Instantiate route matrix options
var routeMatrixOptions = new RouteMatrixOptions(routeMatrixQuery)
{
    TravelTimeType = TravelTimeType.All,
};

// Invoke an async route matrix request
var operation = client.StartRequestRouteMatrix(routeMatrixOptions);

// A moment later, get the result from the operation
var result = operation.WaitForCompletion();
```

The asynchronous route matrix result will be cached for 14 days. User can fetch the result from server via a `RouteMatrixOperation` with the same `Id`:

```C# Snippet:AsyncRouteMatrixRequestWithOperationId
// Invoke an async route matrix request
var operation = client.StartRequestRouteMatrix(routeMatrixOptions);

// Get the operation ID and store somewhere
var operationId = operation.Id;
```

Within 14 days, user can use the same operation ID to fetch the same result. One precondition is the client endpoint should be the same:

```C# Snippet:AsyncRouteMatrixRequestWithOperationId2
// Within 14 days, users can retrive the cached result with operation ID
// The `endpoint` argument in `client` should be the same!
var newRouteMatrixOperation = new RequestRouteMatrixOperation(client, operationId);
var result = newRouteMatrixOperation.WaitForCompletion();
```

## Route Matrix Result

The route matrix result is stored in `RouteMatrixResult` type. User can access the `Matrix` from `RouteMatrixResult`:

```C# Snippet:RouteMatrixResult
// Route matrix result summary
Console.WriteLine($"Total request routes: {0}, Successful routes: {1}",
    result.Value.Summary.TotalRoutes,
    result.Value.Summary.SuccessfulRoutes);

// Route matrix result
foreach (var routeResult in result.Value.Matrix)
{
    Console.WriteLine("Route result:");
    foreach (var route in routeResult)
    {
        var summary = route.Response.Summary;
        Console.WriteLine($"Travel time: {summary.TravelTimeInSeconds} seconds");
        Console.WriteLine($"Travel length: {summary.LengthInMeters} meters");
        Console.WriteLine($"Departure at: {summary.DepartureTime.ToString()} meters");
        Console.WriteLine($"Arrive at: {summary.ArrivalTime.ToString()} meters");
    }
}
```
