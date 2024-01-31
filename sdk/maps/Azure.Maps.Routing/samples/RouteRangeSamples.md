# Route Range Samples

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

## Route Range with Options

Route range API helps to find a set of locations that can be reached from the origin point based on fuel, energy, time or distance budget that is specified. A polygon boundary (or Isochrone) is returned in a counterclockwise orientation as well as the precise polygon center which was the result of the origin point.

The sample below search for the route range for a coordinate that can be reached within specific time:

```C# Snippet:SimpleRouteRange
// Search from a point of time budget that can be reached in 2000 seconds
RouteRangeOptions options = new RouteRangeOptions(123.75, 46)
{
    TimeBudget = new TimeSpan(0, 20, 0)
};
Response<RouteRangeResult> result = client.GetRouteRange(options);
```

You can fine tune the route range via different options:

```C# Snippet:ComplexRouteRange
GeoPosition geoPosition = new GeoPosition(123.75, 46);
// Search from a point of distance budget that can be reached in 6075.35 meters,
// And departure time after 2 hours later in car
RouteRangeOptions options = new RouteRangeOptions(geoPosition)
{
    DistanceBudgetInMeters = 6075.38,
    DepartAt = DateTimeOffset.Now.AddHours(2),
    RouteType = RouteType.Shortest,
    TravelMode = TravelMode.Car
};
Response<RouteRangeResult> result = client.GetRouteRange(options);
```

The result is stored in `ReachableRange` in the return value:

```C# Snippet:ReachableRouteRangeResult
// Suppose we have `result` as the return value from client.GetRouteRange(options)
Console.WriteLine("Center point (Lat, Long): ({0}, {1})",
    result.Value.ReachableRange.Center.Longitude,
    result.Value.ReachableRange.Center.Latitude);

Console.WriteLine("Reachable route range polygon:");
foreach (GeoPosition point in result.Value.ReachableRange.Boundary)
{
    Console.WriteLine($"({point.Longitude}, {point.Latitude})");
}
```
