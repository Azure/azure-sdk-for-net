# Azure Storage Files Data Lake client library for .NET

> Server Version: 2019-02-02
Azure Data Lake includes all the capabilities required to make it easy for developers, data scientists, 
and analysts to store data of any size, shape, and speed, and do all types of processing and analytics 
across platforms and languages. It removes the complexities of ingesting and storing all of your data
while making it faster to get up and running with batch, streaming, and interactive analytics.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Files Data Lake client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Storage.Files.DataLake --version 12.0.0-preview.4
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

TODO: Add Key Concepts

## Examples

TODO: Add Examples

## Troubleshooting

All File DataLake service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.

TODO: Update sample

```c#
string connectionString = "<connection_string>";
// Try to create a container named "sample-container" and avoid any potential race
// conditions that might arise by checking if the container exists before creating
BlobContainerClient container = new BlobContainerClient(connectionString, "sample-container");
try
{
    container.Create();
}
catch (RequestFailedException ex)
    when (ex.ErrorCode == BlobErrorCode.ContainerAlreadyExists)
{
    // Ignore any errors if the container already exists
}
```

## Next steps

TODO: Link Samples

## Contributing

See the [Storage CONTRIBUTING.md][storage_contrib] for details on building,
testing, and contributing to this library.

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Blobs.Cryptography%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Files.DataLake/src
[package]: https://www.nuget.org/packages/Azure.Storage.Files.DataLake/
[docs]: https://azure.github.io/azure-sdk-for-net/storage.html
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/datalakestoragegen2/filesystem
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/blobs/?toc=%2fazure%2fstorage%2fblobs%2ftoc.json
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://docs.microsoft.com/en-us/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://docs.microsoft.com/en-us/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/en-us/rest/api/storageservices/blob-service-error-codes
[storage_contrib]: ../CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com