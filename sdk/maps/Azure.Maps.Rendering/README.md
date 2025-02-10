# Azure Maps Render client library for .NET

Azure Maps Render is a library that can fetch image tiles and copyright information.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Rendering/src) | [API reference documentation](https://learn.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://learn.microsoft.com/rest/api/maps/render) | [Product documentation](https://learn.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Rendering --prerelease
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

```C# Snippet:InstantiateRenderClientViaSubscriptionKey
// Create a MapsRenderingClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsRenderingClient client = new MapsRenderingClient(credential);
```

#### Azure AD authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsRenderingClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, the environment variables as described in the [Azure Identity README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and create a `DefaultAzureCredential` instance to use with the `MapsRenderingClient`.

We also need an **Azure Maps Client ID** which can be found on the Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

![AzureMapsPortal](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Rendering/images/azure-maps-portal.png?raw=true "Azure Maps portal website")

```C# Snippet:InstantiateRenderClientViaAAD
// Create a MapsRenderingClient that will authenticate through Active Directory
TokenCredential credential = new DefaultAzureCredential();
string clientId = "<Your Map ClientId>";
MapsRenderingClient client = new MapsRenderingClient(credential, clientId);
```

#### Shared Access Signature (SAS) Authentication

Shared access signature (SAS) tokens are authentication tokens created using the JSON Web token (JWT) format and are cryptographically signed to prove authentication for an application to the Azure Maps REST API.

Before integrating SAS token authentication, we need to install `Azure.ResourceManager` and `Azure.ResourceManager.Maps` (version `1.1.0-beta.2` or higher):

```powershell
dotnet add package Azure.ResourceManager
dotnet add package Azure.ResourceManager.Maps --prerelease
```

In the code, we need to import the following lines for both Azure Maps SDK and ResourceManager:

```C# Snippet:RenderImportNamespaces
using Azure.Maps.Rendering;
```

```C# Snippet:RenderSasAuthImportNamespaces
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Maps;
using Azure.ResourceManager.Maps.Models;
```

And then we can get SAS token via [List Sas](https://learn.microsoft.com/rest/api/maps-management/accounts/list-sas?tabs=HTTP) API and assign it to `MapsRenderingClient`. In the follow code sample, we fetch a specific maps account resource, and create a SAS token for 1 day expiry time when the code is executed.

```C# Snippet:InstantiateRenderingClientViaSas
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
MapsRenderingClient client = new MapsRenderingClient(sasCredential);
```

## Key concepts

MapsRenderingClient is designed for:

* Communicate with Azure Maps endpoint to get images and tiles
* Communicate with Azure Maps endpoint to get copyrights for images and tiles

Learn more about examples in [samples](https://github.com/dubiety/azure-sdk-for-net/tree/feature/maps-render/sdk/maps/Azure.Maps.Rendering/samples)

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

You can familiarize yourself with different APIs using our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Rendering/samples). Rendering map tiles requires knowledge about zoom levels and tile grid system. Please refer to the [documentation](https://learn.microsoft.com/azure/azure-maps/zoom-levels-and-tile-grid) for more information.

### Get Imagery Tiles

Here is a simple example of rendering imagery tiles:

```C# Snippet:GetImageryMapTiles
int zoom = 10, tileSize = 256;

// Get tile X, Y index by coordinate, zoom and tile size information
MapTileIndex tileIndex = MapsRenderingClient.PositionToTileXY(new GeoPosition(13.3854, 52.517), zoom, tileSize);

// Fetch imagery map tiles
GetMapTileOptions GetMapTileOptions = new GetMapTileOptions(
    MapTileSetId.MicrosoftImagery,
    new MapTileIndex(tileIndex.X, tileIndex.Y, zoom)
);
Response<Stream> mapTile = client.GetMapTile(GetMapTileOptions);

// Prepare a file stream to save the imagery
using (FileStream fileStream = File.Create(".\\BerlinImagery.png"))
{
    mapTile.Value.CopyTo(fileStream);
}
```

## Troubleshooting

### General

When you interact with the Azure Maps services, errors returned by the service correspond to the same HTTP status codes returned for [REST API requests](https://learn.microsoft.com/rest/api/maps/render).

For example, if you try to get an imagery tile with wrong tile index, an error is returned, indicating "Bad Request" (HTTP 400).

```C# Snippet:CatchRenderException
try
{
    var options = new GetMapTileOptions(
        MapTileSetId.MicrosoftBaseHybrid,
        new MapTileIndex(12, 12, 2)
    );

    Response<Stream> imageryTile = client.GetMapTile(options);
    using var imageryStream = new MemoryStream();
    imageryTile.Value.CopyTo(imageryStream);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

## Next steps

* For more context and additional scenarios, please see: [detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Rendering/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.
