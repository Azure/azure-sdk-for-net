# Azure Maps Search client library for .NET

Azure Maps Search is a library that can query for locations, points of interests or search within a geometric area.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/src) | [API reference documentation](https://docs.microsoft.com/rest/api/maps/) | [REST API reference documentation](https://docs.microsoft.com/rest/api/maps/search) | [Product documentation](https://docs.microsoft.com/azure/azure-maps/)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.Maps.Search --prerelease
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

```C# Snippet:InstantiateSearchClientViaSubscriptionKey
// Create a MapsSearchClient that will authenticate through Subscription Key (Shared key)
var credential = new AzureKeyCredential("<My Subscription Key>");
var endpoint = GetRecordedOptionalVariable("ENDPOINT_URL");
SearchClient client = new SearchClient(credential, endpoint);
```

#### Azure AD Authentication

In order to interact with the Azure Blobs Storage service, you'll need to create an instance of the BlobServiceClient class. The [Azure Identity library](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md) makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

To use AAD authentication, set `TENANT_ID`, `CLIENT_ID`, and `CLIENT_SECRET` to environment variable and call `DefaultAzureCredential()` method to get credential. `CLIENT_ID` and `CLIENT_SECRET` are the service principal ID and secret that can access Azure Maps account.

We also need **Azure Maps Client ID** which can get from Azure Maps page > Authentication tab > "Client ID" in Azure Active Directory Authentication section.

```C# Snippet:InstantiateRouteClientViaAAD
// Create a MapsRouteClient that will authenticate through Active Directory
var credential = new DefaultAzureCredential();
var clientId = "<My Map Account Client Id>";
SearchClient client = new SearchClient(credential, clientId);
```

## Key concepts

`SearchClient` is designed for:

* Communicate with Azure Maps endpoint to query addresses or points of locations
* Communicate with Azure Maps endpoint to request the geometry data such as a city or country outline for a set of entities
* Communicate with Azure Maps endpoint to perform a free form search inside a single geometry or many of them

Learn more about examples in [samples](https://github.com/dubiety/azure-sdk-for-net/tree/feature/maps-search/sdk/maps/Azure.Maps.Search/tests/Samples)

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/tests/Samples).

Before calling search APIs, instantiate a `SearchClient` first. Below use AAD to create the client instance:

## Troubleshooting

### General

When you interact with the Azure Maps Services, errors returned by the Language service correspond to the same HTTP status codes returned for REST API requests.

For example, if you ...., a error is returned, indicating "Bad Request".400

## Next steps

* [More detailed samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/tests/Samples)

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/template/Azure.Template/README.png)