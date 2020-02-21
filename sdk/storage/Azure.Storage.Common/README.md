# Azure Storage Common client library for .NET

> Server Version: 2019-07-07 and 2019-02-02

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant. Azure Storage
includes Azure Blobs (objects), Azure Data Lake Storage Gen2, Azure Files,
and Azure Queues.

The Azure.Storage.Common library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.Common` client library will be included:

```Powershell
dotnet add package Azure.Storage.Blobs
dotnet add package Azure.Storage.Queues
dotnet add package Azure.Storage.Files.Shares
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

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Common/src
[package]: https://www.nuget.org/packages/Azure.Storage.Common/
[docs]: https://docs.microsoft.com/dotnet/api/azure.storage
[rest_docs]: https://docs.microsoft.com/rest/api/storageservices/
[product_docs]: https://docs.microsoft.com/azure/storage/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[auth_credentials]: src/StorageSharedKeyCredential.cs
[blobs_examples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs/README.md#Examples
[files_examples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files.Shares/README.md#Examples
[queues_examples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues/README.md#Examples
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[samples]: samples/
[blobs_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs/README.md#next-steps
[files_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files.Shares/README.md#next-steps
[queues_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues/README.md#next-steps
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
