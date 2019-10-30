# Azure Storage Blobs Batch client library for .NET

> Server Version: 2019-02-02

Azure Blob storage is Microsoft's object storage solution for the cloud. Blob
storage is optimized for storing massive amounts of unstructured data.  This
library allows you to batch multiple Azure Blob Storage operations in a single request.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Blobs Batch client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Storage.Blobs.Batch --version 12.0.0-preview.4
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

Batching supports two types of subrequests: SetBlobAccessTier for block blobs and DeleteBlob for blobs.

- Only supports up to 256 subrequests in a single batch. The size of the body for a batch request cannot exceed 4MB.
- There are no guarantees on the order of execution of the batch subrequests.
- Batch subrequest execution is not atomic. Each subrequest is executed independently.
- Each subrequest must be for a resource within the same storage account.

## Examples

### Deleting blobs

```c#
using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Models;

// Get a connection string to our Azure Storage account.  You can
// obtain your connection string from the Azure Portal (click
// Access Keys under Settings in the Portal Storage account blade)
// or using the Azure CLI with:
//
//     az storage account show-connection-string --name <account_name> --resource-group <resource_group>
//
// And you can provide the connection string to your application
// using an environment variable.
string connectionString = "<connection_string>";
BlobServiceClient serviceClient = new BlobServiceClient(connectionString);

// Get URIs for a couple of existing blobs
Uri a = serviceClient.GetBlobContainerClient("letters").GetBlobClient("a").Uri;
Uri b = serviceClient.GetBlobContainerClient("letters").GetBlobClient("b").Uri;
Uri c = serviceClient.GetBlobContainerClient("letters").GetBlobClient("c").Uri;

// Create a batch client
BlobBatchClient batchClient = serviceClient.GetBlobBatchClient();

// Delete several blobs in one batched request
batchClient.DeleteBlobs(new Uri[] { a, b, c });
```

### Setting Access Tiers
```c#
string connectionString = "<connection_string>";
BlobServiceClient serviceClient = new BlobServiceClient(connectionString);

// Get URIs for a couple of existing blobs
Uri a = serviceClient.GetBlobContainerClient("letters").GetBlobClient("a").Uri;
Uri b = serviceClient.GetBlobContainerClient("letters").GetBlobClient("b").Uri;
Uri c = serviceClient.GetBlobContainerClient("letters").GetBlobClient("c").Uri;

// Create a batch client
BlobBatchClient batchClient = serviceClient.GetBlobBatchClient();

// Set the access tier for several blobs in one batched request
batchClient.SetBlobsAccessTier(new Uri[] { a, b, c }, AccessTier.Hot);
```

### Fine-grained control
```c#
string connectionString = "<connection_string>";
BlobServiceClient serviceClient = new BlobServiceClient(connectionString);

// Create a batch client
BlobBatchClient batchClient = serviceClient.GetBlobBatchClient();

// Create a batch
BlobBatch batch = batchClient.GetBlobBatchClient();

// Add a few deletions to the batch
batch.DeleteBlob("letters", "a");
batch.DeleteBlob("letters", "b", DeleteSnapshotsOption.Include);

// Submit the batch
batchClient.SubmitBatch(batch);
```

## Troubleshooting

All Blob service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.  Subrequest failures will be bundled together into an AggregateException.

```c#
string connectionString = "<connection_string>";
BlobServiceClient serviceClient = new BlobServiceClient(connectionString);

// Get URIs for a blob that exists and a blob that doesn't exist
Uri valid = serviceClient.GetBlobContainerClient("valid").GetBlobClient("a").Uri;
Uri invalid = serviceClient.GetBlobContainerClient("invalid").GetBlobClient("b").Uri;

// Create a batch client
BlobBatchClient batchClient = serviceClient.GetBlobBatchClient();
try
{
    // Delete several blobs in a single request
    batchClient.DeleteBlobs(new Uri[] { valid, invalid });
}
catch (AggregateException ex)
{
    // Check ex.InnerExceptions for RequestFailedException instances
}
```

## Next steps

Check out our [sync](../Azure.Storage.Blobs/samples/Sample03a_Batching.cs) and [async](../Azure.Storage.Blobs/samples/Sample03b_BatchingAsync.cs) samples for more.

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

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FAzure.Storage.Blobs.Batch%2FREADME.png)

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/storage/Azure.Storage.Blobs.Batch/src
[package]: https://www.nuget.org/packages/Azure.Storage.Blobs.Batch/
[docs]: https://azure.github.io/azure-sdk-for-net/api/Azure.Storage.Blobs.Batch.html
[rest_docs]: https://docs.microsoft.com/en-us/rest/api/storageservices/blob-service-rest-api
[product_docs]: https://docs.microsoft.com/en-us/azure/storage/blobs/storage-blobs-overview
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
