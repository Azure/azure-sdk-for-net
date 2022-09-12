# Azure Maps Route client library for .NET

Azure Maps Route is a library that can find route to a location or point of interests.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Route/src) | [API reference documentation](https://docs.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://docs.microsoft.com/rest/api/maps/route) | [Product documentation](https://docs.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Route --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://docs.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --disable-local-auth true --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2" --accept-tos
```

### Authenticate the client

There are 2 ways to authenticate the client: Shared key authentication and Azure AD.

#### Shared Key Authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key Authentication** section

```C# Snippet:InstantiateRouteClientViaSubscriptionKey
// Create a MapsRouteClient that will authenticate through Subscription Key (Shared key)
var credential = new AzureKeyCredential("<My Subscription Key>");
MapsRouteClient client = new MapsRouteClient(credential);
```

#### Azure AD Authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsRouteClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, set `TENANT_ID`, `CLIENT_ID`, and `CLIENT_SECRET` to environment variable and call `DefaultAzureCredential()` method to get credential. `CLIENT_ID` and `CLIENT_SECRET` are the service principal ID and secret that can access Azure Maps account.

We also need **Azure Maps Client ID** which can get from Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRouteClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";
MapsRouteClient client = new MapsRouteClient(credential, clientId);
```

## Key concepts

`MapsRouteClient` is designed for:

* Communicate with Azure Maps endpoint to get route to locations or point of interests
* Communicate with Azure Maps endpoint to calculate a set of locations that can be reached from the origin point based on fuel, energy, time or distance budget that is specified
* Communicate with Azure Maps endpoint to calculate a matrix of route summaries for a set of routes defined by origin and destination locations

Learn more about examples in [samples](https://github.com/dubiety/azure-sdk-for-net/tree/feature/maps-route/sdk/maps/Azure.Maps.Route/samples)

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Route/samples).

Before calling route APIs, instantiate a `MapsRouteClient` first. Below example uses AAD to create the client instance:

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRouteClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";
MapsRouteClient client = new MapsRouteClient(credential, clientId);
```

### Route Directions

Here is a simple example of routing to a location:

```C# Snippet:GetDirections
// Create origin and destination routing points
var routePoints = new List<GeoPosition>() {
    new GeoPosition(123.751, 45.9375),
    new GeoPosition(123.791, 45.96875),
    new GeoPosition(123.767, 45.90625)
};

// Create Route direction query object
var query = new RouteDirectionQuery(routePoints);
var result = client.GetDirections(query);

// Route direction result
Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeInSeconds);

// Route points
foreach (var leg in result.Value.Routes[0].Legs)
{
    Console.WriteLine("Route path:");
    foreach (var point in leg.Points)
    {
        Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
    }
}
```

User can also specify the travel mode, route type, language, and other options when route to point of interests:

```C# Snippet:RouteDirectionsWithOptions
// Create origin and destination routing points
var routePoints = new List<GeoPosition>() {
    new GeoPosition(123.751, 45.9375),
    new GeoPosition(123.791, 45.96875),
    new GeoPosition(123.767, 45.90625)
};

var options = new RouteDirectionOptions()
{
    RouteType = RouteType.Fastest,
    UseTrafficData = true,
    TravelMode = TravelMode.Bicycle,
    Language = "en-US",
};

// Create Route direction query object
var query = new RouteDirectionQuery(routePoints);
var result = client.GetDirections(query);

// Route direction result
Console.WriteLine($"Total {0} route results", result.Value.Routes.Count);
Console.WriteLine(result.Value.Routes[0].Summary.LengthInMeters);
Console.WriteLine(result.Value.Routes[0].Summary.TravelTimeInSeconds);

// Route points
foreach (var leg in result.Value.Routes[0].Legs)
{
    Console.WriteLine("Route path:");
    foreach (var point in leg.Points)
    {
        Console.WriteLine($"point({point.Latitude}, {point.Longitude})");
    }
}
```

For more detailed examples, please [route direction samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Route/samples/RouteDirectionsSamples.md) page.

### Route Matrix

To find the route matrix between multiple origins and destinations, Azure Maps route matrix APIs should suite your needs. A simple route matrix request example looks like the snippet below:

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

An async route matrix request looks like below. This is useful when user have `origin * destination > 100` data points.

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
    ComputeTravelTime = ComputeTravelTime.All,
};

// Invoke an async route matrix request
var operation = client.StartRequestRouteMatrix(routeMatrixOptions);

// A moment later, get the result from the operation
var result = operation.WaitForCompletion();
```

For more detailed examples, please [route matrix samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Route/samples/RouteMatrixSamples.md) page.

### Route Range

Route range API helps to find a set of locations that can be reached from the origin point based on fuel, energy, time or distance budget that is specified. A polygon boundary (or Isochrone) is returned in a counterclockwise orientation as well as the precise polygon center which was the result of the origin point.

```C# Snippet:SimpleRouteRange
// Search from a point of time budget that can be reached in 2000 seconds
var options = new RouteRangeOptions(46, 123.75)
{
    TimeBudget = new TimeSpan(0, 20, 0)
};
var result = client.GetRouteRange(options);
```

For more detailed examples, please [route range samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Route/samples/RouteMatrixSamples.md) page.

## Troubleshooting

### General

When you interact with the Azure Maps Services, errors returned by the Language service correspond to the same HTTP status codes returned for REST API requests.

For example, if you pass wrong routing points, an error is returned, indicating "Bad Request".400

```C# Snippet:CatchRouteException
try
{
    // An empty route points list
    var routePoints = new List<GeoPosition>() { };
    var query = new RouteDirectionQuery(routePoints);

    var result = client.GetDirections(query);
    // Do something with result ...
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

## Next steps

* [More detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Route/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/template/Azure.Template/README.png)
