# Azure Maps Routing client library for .NET

Azure Maps Routing is a library that can find route to a location or points of interest.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing/src) | [API reference documentation](https://learn.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://learn.microsoft.com/rest/api/maps/route) | [Product documentation](https://learn.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Routing --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://learn.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 2 ways to authenticate the client: Shared key authentication and Azure AD.

#### Shared Key authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key authentication** section

```C# Snippet:InstantiateRouteClientViaSubscriptionKey
// Create a MapsRoutingClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsRoutingClient client = new MapsRoutingClient(credential);
```

#### Azure AD authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsRoutingClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, set the environment variables as described in the [Azure Identity README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and create a `DefaultAzureCredential` instance to use with the `MapsRoutingClient`.

We also need an **Azure Maps Client ID** which can be found on the Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

![AzureMapsPortal](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Routing/images/azure-maps-portal.png?raw=true)

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRoutingClient that will authenticate through Active Directory
TokenCredential credential = new DefaultAzureCredential();
string clientId = "<Your Map ClientId>";
MapsRoutingClient client = new MapsRoutingClient(credential, clientId);
```

#### Shared Access Signature (SAS) Authentication

Shared access signature (SAS) tokens are authentication tokens created using the JSON Web token (JWT) format and are cryptographically signed to prove authentication for an application to the Azure Maps REST API.

Before integrating SAS token authentication, we need to install `Azure.ResourceManager` and `Azure.ResourceManager.Maps` (version `1.1.0-beta.2` or higher):

```powershell
dotnet add package Azure.ResourceManager
dotnet add package Azure.ResourceManager.Maps --prerelease
```

In the code, we need to import the following lines for both Azure Maps SDK and ResourceManager:

```C# Snippet:RouteImportNamespaces
using Azure.Core.GeoJson;
using Azure.Maps.Routing;
using Azure.Maps.Routing.Models;
```

```C# Snippet:RouteSasAuthImportNamespaces
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
```

And then we can get SAS token via [List Sas](https://learn.microsoft.com/rest/api/maps-management/accounts/list-sas?tabs=HTTP) API and assign it to `MapsRoutingClient`. In the follow code sample, we fetch a specific maps account resource, and create a SAS token for 1 day expiry time when the code is executed.

```C# Snippet:InstantiateRouteClientViaSas
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
MapsRoutingClient client = new MapsRoutingClient(sasCredential);
```

## Key concepts

`MapsRoutingClient` is designed to:

* Communicate with Azure Maps endpoint to get route to locations or point of interests
* Communicate with Azure Maps endpoint to calculate a set of locations that can be reached from the origin point based on fuel, energy, time or distance budget that is specified
* Communicate with Azure Maps endpoint to calculate a matrix of route summaries for a set of routes defined by origin and destination locations

Learn more by viewing our examples in [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing/samples)

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

You can familiarize yourself with different APIs using our [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing/samples).

Before calling route APIs, instantiate a `MapsRoutingClient` first. This example uses AAD to create the client instance:

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRoutingClient that will authenticate through Active Directory
TokenCredential credential = new DefaultAzureCredential();
string clientId = "<Your Map ClientId>";
MapsRoutingClient client = new MapsRoutingClient(credential, clientId);
```

### Route Directions

Here is a simple example of routing to a location:

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

For more detailed examples, please see the [route direction samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Routing/samples/RouteDirectionsSamples.md) page.

### Route Matrix

To find the route matrix between multiple origins and destinations, Azure Maps route matrix APIs should suite your needs. A simple route matrix request example looks like the snippet below:

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

An async route matrix request looks like below. This is useful when you have `origin * destination > 100` data points.

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

For more detailed examples, please see the [route matrix samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Routing/samples/RouteMatrixSamples.md) page.

### Route Range

The route range API helps to find a set of locations that can be reached from the origin point based on fuel, energy, time or distance budget that is specified. A polygon boundary (or Isochrone) is returned in a counterclockwise orientation as well as the precise polygon center which was the result of the origin point.

```C# Snippet:SimpleRouteRange
// Search from a point of time budget that can be reached in 2000 seconds
RouteRangeOptions options = new RouteRangeOptions(123.75, 46)
{
    TimeBudget = new TimeSpan(0, 20, 0)
};
Response<RouteRangeResult> result = client.GetRouteRange(options);
```

For more detailed examples, please see the [route range samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Routing/samples/RouteMatrixSamples.md) page.

## Troubleshooting

### General

When you interact with the Azure Maps services, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you pass wrong routing points, an error is returned, indicating "Bad Request" (HTTP 400).

```C# Snippet:CatchRouteException
try
{
    // An empty route points list
    List<GeoPosition> routePoints = new List<GeoPosition>() { };
    RouteDirectionQuery query = new RouteDirectionQuery(routePoints);

    Response<RouteDirections> result = client.GetDirections(query);
    // Do something with result ...
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

## Next steps

* For more context and additional scenarios, please see: [detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.
