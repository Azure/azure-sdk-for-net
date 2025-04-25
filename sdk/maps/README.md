# Microsoft Azure Maps client library for .NET

Microsoft Azure Maps is a Microsoft-managed service providing maps service that you can nevigate, search, render many polygons on top of it and you're also able to check timezone, weather or traffic information.

## Getting started

Below are the packages contained in Azure Maps:

- [Azure.Maps.Common][common] provides infrastructure shared by the other Azure Maps client libraries like localized map view enum.
- [Azure.Maps.Rendering][render] is the rendering SDK that user can get maps images or copyrights.
- [Azure.Maps.Routing][route] allows you to get the routing information for multiple origins and destinations.
- [Azure.Maps.Search][search] supports many searching functionalities for entities, point of interests (POI) or streets, and also supports reverse geocode a coordinate to a place or an entity.
- [Azure.Maps.Geolocation][geolocation] allows you to get the ISO country code for the provided IP address.
- [Azure.Maps.TimeZones][timezone] allows you to get time zone information for the world.
- [Azure.Maps.Weather][weather] allows you to get real-time, forecasted, and historical weather data.
### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Rendering --prerelease
dotnet add package Azure.Maps.Routing --prerelease
dotnet add package Azure.Maps.Search --prerelease
dotnet add package Azure.Maps.Geolocation --prerelease
dotnet add package Azure.Maps.TimeZones --prerelease
```

Azure.Maps.Common will be automatically installed when you install other packages.

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://learn.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 3  ways to authenticate the client: Shared key authentication, Microsoft Entra and Shared Access Signature (SAS) Authentication. Please refer to each package's README for details.

## Key concepts

Each maps service has its own client. You can access the client after installing the nuget package. Please refer to each package's README for more details.

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

You can familiarize yourself with different APIs under [Samples] directory for each service module. Below demonstrate how to interact with different service.

Imagine we'd like to search a amusement park that is closest to your home. After that, you want to know how to get there via public transfortation. You can interact with `Azure.Maps.Search`, `Azure.Maps.Routing` and `Azure.Maps.Rendering` packages (and many more!).

First, import the necessary namespaces:

```C#
// Import Rendering, Routing, and Search namespace (alphabetical ordering)
using Azure.Maps.Rendering;
using Azure.Maps.Routing;
using Azure.Maps.Search;
```

In the main function, instantiate `MapsSearchClient`, `MapsRoutingClient` and `MapsRenderingClient` either via subscription key, Microsoft Entra, or SAS token authentication. Below is an example of instantiation via Microsoft Entra:

```C#
// Create a MapsSearchClient and MapsRoutingClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";

MapsSearchClient searchClient = new MapsSearchClient(credential, clientId);
MapsRoutingClient routingClient = new MapsRoutingClient(credential, clientId);
MapsRenderingClient renderingClient = new MapsRenderingClient(credential, clientId);
```

Next, search for my home and amusement park via `MapsSearchClient`, and extract the coordinates from the results:

```C#
var homeAddress = searchClient.SearchAddress("15127 NE 24th St, Redmond, WA 98052");
var parkAddress = searchClient.FuzzySearch("Wings Over Washington", new FuzzySearchOptions
{
    // Should close to Seattle, we assign the coordinate to indicate search nearby
    Coordinates = new GeoPosition(-122.291, 47.594),
    Language = "en"
});

// Get Addresses for home coordinate and amusement park coordinate
var homeCoord = homeAddress.Value.Results[0].Position;
var parkCoord = parkaddress.Value.Results[0].Position;
```

We can get the routing direction and indicate we want to drive car there:

```C#
// Create origin and destination routing points, from my home to amusement park
var routePoints = new List<GeoPosition>() { homeCoord, parkCoord };

// Create Route direction query, indicate we want to drive car with the fastest route
var query = new RouteDirectionQuery(routePoints, new RouteDirectionOptions()
{
    RouteType = RouteType.Fastest,
    TravelMode = TravelMode.Car
});

// Call MapsRoutingClient's GetDirections method to get direction
var result = routingClient.GetDirections(query);

// Extract route result
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

Finally, if you want to save a image photo, `MapsRenderingClient` can help to achieve this:

```C#
// Prepare pushpin styles
var pushpinSet1 = new PushpinStyle(
    new List<PinPosition>()
    {
        new PinPosition(homeCoord.Longitude, homeCoord.Latitude, "Home"),
        new PinPosition(parkCoord.Longitude, parkCoord.Latitude, "Wings Over Washington"),
    })
{
    PinScale = 0.9,
    PinColor = Color.Red,
    LabelColor = Color.Beige,
    LabelScale = 18
};

// Prepare static image options
var staticImageOptions = new RenderStaticImageOptions(new GeoBoundingBox(-122.43, 47.58, -122.02, 47.7))
{
    TileLayer = MapImageLayer.Basic,
    TileStyle = MapImageStyle.Dark,
    ZoomLevel = 10,
    RenderLanguage = "en",
    Pins = new List<PushpinStyle>() { pushpinSet1 }
};

// Get static image
var image = renderingClient.GetMapStaticImage(staticImageOptions);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\HomeToWindsOverWashington.png"))
{
    image.Value.CopyTo(fileStream);
}
```

Voila! That's how we utilize `MapsSearchClient`, `MapsRoutingClient` and `MapsRenderingClient` at the same time. You can use whatever combinations within Azure Maps SDK or even integrate with other services' SDK. For more examples, please refer to each service's samples.

## Troubleshooting

### General

When you interact with the Azure Maps Services, errors returned by the Language service correspond to the same HTTP status codes returned for REST API requests.

For example, if you pass wrong routing points, an error is returned, indicating "Bad Request" (HTTP 400).

```C#
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

Please refer to each package's sample folder for more details.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

<!-- LINKS -->
[common]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Common
[render]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Rendering
[route]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing
[geolocation]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation
[search]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search
[timezone]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.TimeZones
[weather]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Weather
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com