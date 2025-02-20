# Azure Storage Blobs Batch client library for .NET

> Server Version: 2021-02-12, 2020-12-06, 2020-10-02, 2020-08-04, 2020-06-12, 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2019-02-02

Azure Blob storage is Microsoft's object storage solution for the cloud. Blob
storage is optimized for storing massive amounts of unstructured data.  This
library allows you to batch multiple Azure Blob Storage operations in a single request.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Blobs Batch client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Storage.Blobs.Batch
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

### Authenticate the client

In order to interact with the Azure Blobs Storage service for batch operations, you'll need to create an instance of the BlobServiceClient class.  The [Azure Identity library][identity] makes it easy to add Azure Active Directory support for authenticating Azure SDK clients with their corresponding Azure services.

```C# Snippet:SampleSnippetsBlobBatch_Auth
// Create a BlobServiceClient that will authenticate through Active Directory
Uri accountUri = new Uri("https://MYSTORAGEACCOUNT.blob.core.windows.net/");
BlobServiceClient client = new BlobServiceClient(accountUri, new DefaultAzureCredential());
BlobBatchClient batch = client.GetBlobBatchClient();
```

## Key concepts

Batching supports two types of subrequests: SetBlobAccessTier for block blobs and DeleteBlob for blobs.

- Only supports up to 256 subrequests in a single batch. The size of the body for a batch request cannot exceed 4MB.
- There are no guarantees on the order of execution of the batch subrequests.
- Batch subrequest execution is not atomic. Each subrequest is executed independently.
- Each subrequest must be for a resource within the same storage account.

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

### Deleting blobs

```C# Snippet:SampleSnippetsBatch_DeleteBatch
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";
string containerName = "sample-container";

// Get a reference to a container named "sample-container" and then create it
BlobServiceClient service = new BlobServiceClient(connectionString);
BlobContainerClient container = service.GetBlobContainerClient(containerName);
container.Create();

// Create three blobs named "foo", "bar", and "baz"
BlobClient foo = container.GetBlobClient("foo");
BlobClient bar = container.GetBlobClient("bar");
BlobClient baz = container.GetBlobClient("baz");
foo.Upload(BinaryData.FromString("Foo!"));
bar.Upload(BinaryData.FromString("Bar!"));
baz.Upload(BinaryData.FromString("Baz!"));

// Delete all three blobs at once
BlobBatchClient batch = service.GetBlobBatchClient();
batch.DeleteBlobs(new Uri[] { foo.Uri, bar.Uri, baz.Uri });
```

### Setting Access Tiers

```C# Snippet:SampleSnippetsBatch_AccessTier
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";
string containerName = "sample-container";

// Get a reference to a container named "sample-container" and then create it
BlobServiceClient service = new BlobServiceClient(connectionString);
BlobContainerClient container = service.GetBlobContainerClient(containerName);
container.Create();
// Create three blobs named "foo", "bar", and "baz"
BlobClient foo = container.GetBlobClient("foo");
BlobClient bar = container.GetBlobClient("bar");
BlobClient baz = container.GetBlobClient("baz");
foo.Upload(BinaryData.FromString("Foo!"));
bar.Upload(BinaryData.FromString("Bar!"));
baz.Upload(BinaryData.FromString("Baz!"));

// Set the access tier for all three blobs at once
BlobBatchClient batch = service.GetBlobBatchClient();
batch.SetBlobsAccessTier(new Uri[] { foo.Uri, bar.Uri, baz.Uri }, AccessTier.Cool);
```

### Fine-grained control

```C# Snippet:SampleSnippetsBatch_FineGrainedBatching
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";
string containerName = "sample-container";

// Get a reference to a container named "sample-container" and then create it
BlobServiceClient service = new BlobServiceClient(connectionString);
BlobContainerClient container = service.GetBlobContainerClient(containerName);
container.Create();

// Create three blobs named "foo", "bar", and "baz"
BlobClient foo = container.GetBlobClient("foo");
BlobClient bar = container.GetBlobClient("bar");
BlobClient baz = container.GetBlobClient("baz");
foo.Upload(BinaryData.FromString("Foo!"));
foo.CreateSnapshot();
bar.Upload(BinaryData.FromString("Bar!"));
bar.CreateSnapshot();
baz.Upload(BinaryData.FromString("Baz!"));

// Create a batch with three deletes
BlobBatchClient batchClient = service.GetBlobBatchClient();
BlobBatch batch = batchClient.CreateBatch();
batch.DeleteBlob(foo.Uri, DeleteSnapshotsOption.IncludeSnapshots);
batch.DeleteBlob(bar.Uri, DeleteSnapshotsOption.OnlySnapshots);
batch.DeleteBlob(baz.Uri);

// Submit the batch
batchClient.SubmitBatch(batch);
```

## Troubleshooting

All Blob service operations will throw a
[RequestFailedException][RequestFailedException] on failure with
helpful [`ErrorCode`s][error_codes].  Many of these errors are recoverable.  Subrequest failures will be bundled together into an AggregateException.

```C# Snippet:SampleSnippetsBatch_Troubleshooting
// Get a connection string to our Azure Storage account.
string connectionString = "<connection_string>";
string containerName = "sample-container";

// Get a reference to a container named "sample-container" and then create it
BlobServiceClient service = new BlobServiceClient(connectionString);
BlobContainerClient container = service.GetBlobContainerClient(containerName);
container.Create();

// Create a blob named "valid"
BlobClient valid = container.GetBlobClient("valid");
valid.Upload(BinaryData.FromString("Valid!"));

// Get a reference to a blob named "invalid", but never create it
BlobClient invalid = container.GetBlobClient("invalid");

// Delete both blobs at the same time
BlobBatchClient batch = service.GetBlobBatchClient();
try
{
    batch.DeleteBlobs(new Uri[] { valid.Uri, invalid.Uri });
}
catch (AggregateException)
{
    // An aggregate exception is thrown for all the individual failures
    // Check ex.InnerExceptions for RequestFailedException instances
}
```

## Next steps

Check out our [sync](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs.Batch/samples/Sample03a_Batching.cs) and [async](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs.Batch/samples/Sample03b_BatchingAsync.cs) samples for more.

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

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs.Batch/src
[package]: https://www.nuget.org/packages/Azure.Storage.Blobs.Batch/
[docs]: https://azure.github.io/azure-sdk-for-net/storage.html
[rest_docs]: https://learn.microsoft.com/rest/api/storageservices/blob-service-rest-api
[product_docs]: https://learn.microsoft.com/azure/storage/blobs/storage-blobs-overview
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/blob-service-error-codes
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
