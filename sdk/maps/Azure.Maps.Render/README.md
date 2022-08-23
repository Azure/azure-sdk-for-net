# Azure Maps Render client library for .NET

Azure Maps Render is a render library that can fetch image tiles and get copyrights.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Render/src) | [API reference documentation](https://docs.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://docs.microsoft.com/rest/api/maps/render) | [Product documentation](https://docs.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Render --prerelease
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

```C# Snippet:InstantiateRenderClientViaSubscriptionKey
// Create a MapsRenderClient that will authenticate through Subscription Key (Shared key)
var credential = new AzureKeyCredential("<My Subscription Key>");
MapsRenderClient client = new MapsRenderClient(credential);
```

#### Azure AD Authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsRenderClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, set `TENANT_ID`, `CLIENT_ID`, and `CLIENT_SECRET` to environment variable and call `DefaultAzureCredential()` method to get credential. `CLIENT_ID` and `CLIENT_SECRET` are the service principal ID and secret that can access Azure Maps account.

We also need **Azure Maps Client ID** which can get from Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

```C# Snippet:InstantiateRenderClientViaAAD
// Create a MapsRenderClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";
MapsRenderClient client = new MapsRenderClient(credential, clientId);
```

## Key concepts

MapsRenderClient is designed for:

* Communicate with Azure Maps endpoint to get images and tiles
* Communicate with Azure Maps endpoint to get copyrights for images and tiles

Learn more about examples in [samples](https://github.com/dubiety/azure-sdk-for-net/tree/feature/maps-render/sdk/maps/Azure.Maps.Render/samples)

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Render/samples). Rendering map tiles requires the knowledge about zoom levels and tile grid system. Please refer to the [document](https://docs.microsoft.com/azure/azure-maps/zoom-levels-and-tile-grid) for zoom levels and tile grid.

### Render Images

Here is a simple example of rendering imagery tiles:

```C# Snippet:RenderImageryTiles
var credential = new DefaultAzureCredential();
var clientId = TestEnvironment.MapAccountClientId;
var client = new MapsRenderClient(credential, clientId);

int zoom = 10, tileSize = 300;

// Get tile X, Y index by coordinate, zoom and tile size information
TileMath.PositionToTileXY(
    new GeoPosition(13.3854, 52.517), zoom, tileSize,
    out var tileX, out var tileY
);

// Get imagery tile
var imageryTile = client.GetMapImageryTile(new TileIndex(tileX, tileY, zoom));
Assert.IsNotNull(imageryTile);

// Prepare a file stream to save the imagery
using (var fileStream = File.Create(".\\BerlinImagery.png"))
{
    imageryTile.Value.CopyTo(fileStream);
    Assert.IsTrue(fileStream.Length > 0);
}
```

## Troubleshooting

### General

When you interact with the Maps Render service, errors returned by the Render service correspond to the same HTTP status codes returned for REST API requests.

For example, if you try to get an imagery tile with wrong tile index, an error is returned, indicating "Bad Request" (400).

```C# Snippet:CatchRenderException
try
{
    Response<Stream> imageryTile = client.GetMapImageryTile(new TileIndex(12, 12, 2));
    var imageryStream = new MemoryStream();
    imageryTile.Value.CopyTo(imageryStream);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

## Next steps

* [More detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Render/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/maps/Azure.Maps.Render/README.png)
