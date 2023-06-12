# Azure Maps Geolocation client library for .NET

Azure Maps Geolocation is a library that can find geolocation to a location or points of interest.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation/src) | [API reference documentation](https://docs.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://docs.microsoft.com/rest/api/maps/geolocation) | [Product documentation](https://docs.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Maps.Geolocation --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://docs.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 2 ways to authenticate the client: Shared key authentication and Azure AD.

#### Shared Key authentication

* Go to Azure Maps account > Authentication tab
* Copy `Primary Key` or `Secondary Key` under **Shared Key Authentication** section

```C# Snippet:InstantiateGeolocationClientViaSubscriptionKey
// Create a MapsGeolocationClient that will authenticate through Subscription Key (Shared key)
AzureKeyCredential credential = new AzureKeyCredential("<My Subscription Key>");
MapsGeolocationClient client = new MapsGeolocationClient(credential);
```

#### Azure AD authentication

In order to interact with the Azure Maps service, you'll need to create an instance of the `MapsGeolocationClient` class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, set the environment variables as described in the [Azure Identity README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) and create a `DefaultAzureCredential` instance to use with the `MapsRouteClient`.

We also need **Azure Maps Client ID** which can get from Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

```C# Snippet:InstantiateGeolocationClientViaAAD
// Create a MapsGeolocationClient that will authenticate through Active Directory
TokenCredential credential = new DefaultAzureCredential();
string clientId = "<Your Map ClientId>";
MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);
```

## Key concepts

`MapsGeolocationClient` is designed for:

* Communicate with Azure Maps Geolocation SDK endpoint to get location from given IP address

Learn more about examples in [samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation/samples)

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

You can familiarize yourself with different APIs using our [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation/samples).

Before calling geolocation APIs, instantiate a `MapsGeolocationClient` first. Below example uses AAD to create the client instance:

```C# Snippet:InstantiateGeolocationClientViaAAD
// Create a MapsGeolocationClient that will authenticate through Active Directory
TokenCredential credential = new DefaultAzureCredential();
string clientId = "<Your Map ClientId>";
MapsGeolocationClient client = new MapsGeolocationClient(credential, clientId);
```

### Get Location

This service will return the ISO country code for the provided IP address. Developers can use this information to block or alter certain content based on geographical locations where the application is being viewed from.

```C# Snippet:GetCountryCode
//Get location by given IP address
IPAddress ipAddress = IPAddress.Parse("2001:4898:80e8:b::189");
Response<CountryRegionResult> result = client.GetCountryCode(ipAddress);

//Get location result country code
Console.WriteLine($"Country code results by given IP Address: {result.Value.IsoCode}");
```

For more detailed examples, please see [geolocation samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Geolocation/samples/GetCountryCodeSamples.md) page.

## Troubleshooting

### General

When you interact with the Azure Maps services, errors returned by the Language service correspond to the same HTTP status codes returned for [REST API requests](https://docs.microsoft.com/rest/api/maps/geolocation).

For example, if you pass wrong IP address, an error is returned, indicating "Bad Request" (HTTP Status code: 400).

```C# Snippet:CatchGeolocationException
try
{
    // An invalid IP address
    IPAddress inValidIpAddress = IPAddress.Parse("2001:4898:80e8:b:123123213123");

    Response<CountryRegionResult> result = client.GetCountryCode(inValidIpAddress);
    // Do something with result ...
}
catch (FormatException e)
{
    Console.WriteLine(e.ToString());
}
```

## Next steps

* For more context and additional scenarios, please see: [More detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation/samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/template/Azure.Template/README.png)
