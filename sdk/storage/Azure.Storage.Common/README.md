# Azure Storage common client library for .NET

> Server Version: 2018-11-09

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant. Azure Storage
includes Azure Blobs (objects), Azure Data Lake Storage Gen2, Azure Files,
and Azure Queues.

The Azure.Storage.Common library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][rest_docs] | [Product documentation][product_docs]

## Getting started
### Install the package
Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the common client library will be included:

```Powershell
Install-Package Azure.Storage.Blobs
Install-Package Azure.Storage.Queues
Install-Package Azure.Storage.Files
```

**Prerequisites**: You must have an [Azure subscription][azure_sub], and a
[Storage Account][storage_account_docs] to use these packages.

To create a Storage Account, you can use the [Azure Portal][storage_account_create_portal],
[Azure PowerShell][storage_account_create_ps] or [Azure CLI][storage_account_create_cli]:

## Key concepts
The Azure Storage common client library contains shared infrastructure like
[authentication credentials][auth_credentials] and [StorageRequestFailedException][StorageRequestFailedException].

## Examples
Please see the examples for [Blobs][blobs_examples], [Files][blobs_examples],
or [Queues][blobs_examples] to get started.

## Troubleshooting
All Azure Storage services will throw a [StorageRequestFailedException][StorageRequestFailedException]
with helpful [`ErrorCode`s][error_codes].

## Next steps
Get started with [Blobs][blobs_examples], [Files][blobs_examples], or [Queues][blobs_examples].

## Contributing
This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit https://cla.microsoft.com.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/)
or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any
additional questions or comments.
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Common%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Common/src
[package]: https://www.nuget.org/packages/Azure.Storage.Common/
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[auth_credentials]: src/SharedKeyCredential.cs
[StorageRequestFailedException]: src/StorageRequestFailedException.cs
[blobs_examples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs/README.md#Examples
[files_examples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files/README.md#Examples
[queues_examples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Queues/README.md#Examples
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/common-rest-api-error-codes