# Azure Maps Common client library for .NET

Azure Maps is a Microsoft-managed service providing maps service that is...

The Azure.Maps.Common library provides infrastructure shared across other Azure Maps client libraries.

[Source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Common/src) | [API reference documentation](https://learn.microsoft.com/rest/api/maps/) | [Product documentation](https://learn.microsoft.com/azure/azure-maps)

## Getting started

### Install the package

Install the Azure Maps client library for .NET you'd like to use with [NuGet](https://www.nuget.org/) and the `Azure.Maps.Common` client library will be included. Choose the packages you want to install:

```dotnetcli
dotnet add package Azure.Maps.Search --prerelease
dotnet add package Azure.Maps.Routing --prerelease
dotnet add package Azure.Maps.Rendering --prerelease
dotnet add package Azure.Maps.Geolocation --prerelease
```

### Prerequisites

> You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/) and [Azure Maps account](https://learn.microsoft.com/azure/azure-maps/quick-demo-map-app#create-an-azure-maps-account).

To create a new Azure Maps account, you can use the Azure Portal, Azure PowerShell, or the Azure CLI. Here's an example using the Azure CLI:

```powershell
az maps account create --kind "Gen2" --account-name "myMapAccountName" --resource-group "<resource group>" --sku "G2"
```

### Authenticate the client

There are 2 ways to authenticate the client: Shared key authentication and Azure AD. Please refer to other Azure Maps packages for detailed description.

## Key concepts

The Azure Maps Common client library contains shared infrastructure like
[LocalizedMapView](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/maps/Azure.Maps.Common/src/LocalizedMapView.cs) and [RequestFailedException](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/src/RequestFailedException.cs).

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

Please see the examples for [Search](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search), [Routing](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing), [Rendering](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Rendering) and [Geolocation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation).

## Troubleshooting

If instantiate a `null` `LocalizedMapView`, the program will throw a `ArgumentNullException` error.

## Next steps

Get started with our [Search](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Search/samples), [Routing](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Routing/samples), [Rendering](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Rendering/samples) and [Geolocation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/maps/Azure.Maps.Geolocation/samples) samples.

## Contributing

See the [CONTRIBUTING.md](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact <opencode@microsoft.com> with any additional questions or comments.
