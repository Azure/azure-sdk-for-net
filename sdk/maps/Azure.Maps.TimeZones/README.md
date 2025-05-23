# Azure Maps TimeZone client library for .NET

Azure Maps TimeZone is a library which contains Azure Maps TimeZone APIs.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.TimeZones/src) | [API reference documentation](https://learn.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://learn.microsoft.com/rest/api/maps/timezone) | [Product documentation](https://learn.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.TimeZones --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://learn.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 3  ways to authenticate the client: Shared key authentication, Microsoft Entra and Shared Access Signature (SAS) Authentication.

#### Shared Key authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key authentication** section

```C# Snippet:InstantiateTimeZoneClientViaSubscriptionKey
// Create a MapsTimeZoneClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsTimeZoneClient client = new MapsTimeZoneClient(credential);
```

#### Microsoft Entra authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsTimeZoneClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Microsoft Entra support for authenticating Azure SDK clients with their corresponding Azure services.

To use Microsoft Entra authentication, the environment variables as described in the [Azure Identity README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and create a `DefaultAzureCredential` instance to use with the `MapsTimeZoneClient`.

We also need an **Azure Maps Client ID** which can be found on the Azure Maps page > Authentication tab > "Client ID" in Microsoft Entra Authentication section.

```C# Snippet:InstantiateTimeZoneClientViaMicrosoftEntra
// Create a MapsTimeZoneClient that will authenticate through MicrosoftEntra
DefaultAzureCredential credential = new DefaultAzureCredential();
string clientId = "<My Map Account Client Id>";
MapsTimeZoneClient client = new MapsTimeZoneClient(credential, clientId);
```

#### Shared Access Signature (SAS) Authentication

Shared access signature (SAS) tokens are authentication tokens created using the JSON Web token (JWT) format and are cryptographically signed to prove authentication for an application to the Azure Maps REST API.

Before integrating SAS token authentication, we need to install `Azure.ResourceManager` and `Azure.ResourceManager.Maps` (version `1.1.0` or higher):

```powershell
dotnet add package Azure.ResourceManager
dotnet add package Azure.ResourceManager.Maps
```

And then we can get SAS token via [List Sas](https://learn.microsoft.com/rest/api/maps-management/accounts/list-sas?tabs=HTTP) API and assign it to `MapsTimeZoneClient`. In the follow code sample, we fetch a specific maps account resource, and create a SAS token for 1 day expiry time when the code is executed.

```C# Snippet:InstantiateTimeZoneClientViaSas
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

// Create a MapsTimeZoneClient that will authenticate via SAS token
AzureSasCredential sasCredential = new AzureSasCredential(sas.Value.AccountSasToken);
MapsTimeZoneClient client = new MapsTimeZoneClient(sasCredential);
```

## Key concepts

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

You can familiarize yourself with different APIs using our [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.TimeZones/samples).

### Get TimeZone By ID

```C# Snippet:GetTimeZoneById
GetTimeZoneOptions options = new GetTimeZoneOptions()
{
    AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
};
Response<TimeZoneResult> response = client.GetTimeZoneById("Asia/Bahrain", options);
Console.WriteLine("Version: " + response.Value.Version);
Console.WriteLine("Countires: " + response.Value.TimeZones[0].Countries);
```

### Get TimeZone By Coordinates

```C# Snippet:GetTimeZoneByCoordinates
GetTimeZoneOptions options = new GetTimeZoneOptions()
{
    AdditionalTimeZoneReturnInformation = AdditionalTimeZoneReturnInformation.All
};
GeoPosition coordinates = new GeoPosition(121.5640089, 25.0338053);
Response<TimeZoneResult> response = client.GetTimeZoneByCoordinates(coordinates, options);

Console.WriteLine("Time zone for (latitude, longitude) = ({0}, {1}) is {2}: ",
    coordinates.Latitude, coordinates.Longitude,
    response.Value.TimeZones[0].Name.Generic);
```

### Get Windows TimeZone Ids

```C# Snippet:GetWindowsTimeZoneIds
Response<WindowsTimeZoneData> response = client.GetWindowsTimeZoneIds();
Console.WriteLine("Total time zones: " + response.Value.WindowsTimeZones.Count);
foreach (WindowsTimeZone timeZone in response.Value.WindowsTimeZones)
{
    Console.WriteLine("IANA Id: " + timeZone.IanaIds);
    Console.WriteLine("Windows ID: " + timeZone.WindowsId);
    Console.WriteLine("Territory: " + timeZone.Territory);
}
```

### Get Iana TimeZone Ids

```C# Snippet:GetTimeZoneIanaIds
Response<IanaIdData> response = client.GetTimeZoneIanaIds();
if (response.Value.IanaIds[0].AliasOf != null)
{
    Console.WriteLine("It is an alias: " + response.Value.IanaIds[0].AliasOf);
}
else
{
    Console.WriteLine("It is not an alias");
}
Console.WriteLine("IANA Id: " + response.Value.IanaIds[0].Id);
```

### Get Iana Version

```C# Snippet:GetIanaVersion
Response<TimeZoneIanaVersionResult> response = client.GetIanaVersion();
Console.WriteLine("IANA Version: " + response.Value.Version);
```

### Convert Windows TimeZone To Iana

```C# Snippet:ConvertWindowsTimeZoneToIana
Response<IanaIdData> response = client.ConvertWindowsTimeZoneToIana("Dateline Standard Time");
Console.WriteLine("IANA Id: " + response.Value.IanaIds[0].Id);
```

## Troubleshooting

### General

When you interact with the Azure Maps services, errors returned by the service correspond to the same HTTP status codes returned for [REST API requests](https://learn.microsoft.com/rest/api/maps/timezone).

For example, if you search with an invalid coordinate, a error is returned, indicating "Bad Request".

## Next steps

* For more context and additional scenarios, please see: [detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.TimeZones/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.
