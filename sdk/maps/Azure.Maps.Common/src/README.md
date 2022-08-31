# Azure Maps Common client library for .NET

Azure Maps is a Microsoft-managed service providing maps service that is...

The Azure.Maps.Common library provides infrastructure shared across other Azure Maps client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Maps.Common` client library will be included:

```dotnetcli
dotnet add package Azure.Maps.Search
dotnet add package Azure.Maps.Render
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a
[Storage Account][storage_account_docs] to use this package.

To create a new Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps], or the [Azure CLI][storage_account_create_cli].
Here's an example using the Azure CLI:

```Powershell
az storage account create --name MyStorageAccount --resource-group MyResourceGroup --location westus --sku Standard_LRS
```

## Key concepts

The Azure Storage Common client library contains shared infrastructure like
[authentication credentials][auth_credentials] and [RequestFailedException][RequestFailedException].

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

Please see the examples for [Blobs][blobs_examples], [Queues][queues_examples], and [Files][files_examples].

## Troubleshooting

All Azure Storage services will throw a [RequestFailedException][RequestFailedException]
with helpful [`ErrorCode`s][error_codes].

## Next steps

Get started with our [Common samples][samples] and then continue on with our [Blobs][blobs_samples], [Queues][queues_samples], and [Files][files_samples] samples.

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to these libraries.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Common%2FREADME.png)
