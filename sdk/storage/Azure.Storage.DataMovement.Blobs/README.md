# Azure Storage Data Movement Blobs client library for .NET

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant.

The Azure Storage Data Movement Blobs library is optimized for uploading, downloading and
copying blobs.

The Azure.Storage.DataMovement.Blobs library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage Data Movement Blobs client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.Storage.DataMovement.Blobs
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
The Azure.Storage.DataMovement.Blobs library uses clients from the Azure.Storage.Blobs package to communicate with the Azure Blob Storage service. For more information see the Azure.Storage.Blobs [authentication documentation](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Blobs#authenticate-the-client).

### Permissions

The authenticated blob storage resource needs the following permissions to perform a transfer:

1. Read
2. List (for container transfers)
3. Write
4. Add (specific to append blobs)
5. Delete (for cleanup of a failed transfer item)
6. Create

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
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

This section demonstrates usage of Data Movement for interacting with blob storage.

### Using the TransferManager for Blob Transfers

The `TransferManager` is the primary class for managing data transfers between storage resources. See [Setup the TransferManager sample](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement#setup-the-transfermanager).


### Initializing Blob Storage `StorageResource`

Azure.Storage.DataMovement.Blobs exposes `BlobsStorageResourceProvider` to create `StorageResource` instances for each type of blob (block, page, append) as well as a blob container. The resource provider should be initialized with a credential to properly authenticate the storage resources. The following demonstrates this using an `Azure.Core` token credential.

```C# Snippet:MakeProvider_TokenCredential
BlobsStorageResourceProvider blobs = new(tokenCredential);
```

To create a blob `StorageResource`, use the methods `FromBlob` or `FromContainer`.

```C# Snippet:ResourceConstruction_Blobs
StorageResource container = await blobs.FromContainerAsync(
    new Uri("https://myaccount.blob.core.windows.net/container"));

// Block blobs are the default if no options are specified
StorageResource blockBlob = await blobs.FromBlobAsync(
    new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-block"),
    new BlockBlobStorageResourceOptions());
StorageResource pageBlob = await blobs.FromBlobAsync(
    new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-page"),
    new PageBlobStorageResourceOptions());
StorageResource appendBlob = await blobs.FromBlobAsync(
    new Uri("https://myaccount.blob.core.windows.net/container/sample-blob-append"),
    new AppendBlobStorageResourceOptions());
```

Storage resources can also be initialized with the appropriate client object from Azure.Storage.Blobs. Since these resources will use the credential already present in the client object, no credential is required in the provider when using `FromClient()`. **However**, a `BlobsStorageResourceProvider` must still have a credential if it is to be used in `TransferManagerOptions` for resuming a transfer.

```C# Snippet:ResourceConstruction_FromClients_Blobs
StorageResource containerResource = BlobsStorageResourceProvider.FromClient(blobContainerClient);
StorageResource blockBlobResource = BlobsStorageResourceProvider.FromClient(blockBlobClient);
StorageResource pageBlobResource = BlobsStorageResourceProvider.FromClient(pageBlobClient);
StorageResource appendBlobResource = BlobsStorageResourceProvider.FromClient(appendBlobClient);
```

There are more options which can be used when creating a blob storage resource. Below are some examples.

```C# Snippet:ResourceConstruction_Blobs_WithOptions_VirtualDirectory
BlobStorageResourceContainerOptions virtualDirectoryOptions = new()
{
    BlobPrefix = "blob/directory/prefix"
};

StorageResource virtualDirectoryResource = BlobsStorageResourceProvider.FromClient(
    blobContainerClient,
    virtualDirectoryOptions);
```

```C# Snippet:ResourceConstruction_Blobs_WithOptions_BlockBlob
BlockBlobStorageResourceOptions resourceOptions = new()
{
    Metadata = new Dictionary<string, string>
        {
            { "key", "value" }
        }
};
StorageResource leasedBlockBlobResource = BlobsStorageResourceProvider.FromClient(
    blockBlobClient,
    resourceOptions);
```

### Upload

An upload takes place between a local file `StorageResource` as source and blob `StorageResource` as destination.

Upload a block blob.

```C# Snippet:SimpleBlobUpload
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalPath),
    destinationResource: await blobs.FromBlobAsync(destinationBlobUri));
await transferOperation.WaitForCompletionAsync();
```

Upload a directory as a specific blob type.

```C# Snippet:SimpleDirectoryUpload
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromDirectory(sourcePath),
    destinationResource: await blobs.FromContainerAsync(
        blobContainerUri,
        new BlobStorageResourceContainerOptions()
        {
            // Block blobs are the default if not specified
            BlobType = BlobType.Block,
            BlobPrefix = optionalDestinationPrefix,
        }));
```

### Download

A download takes place between a blob `StorageResource` as source and local file `StorageResource` as destination.

Download a blob.

```C# Snippet:SimpleBlockBlobDownload
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: await blobs.FromBlobAsync(sourceBlobUri),
    destinationResource: LocalFilesStorageResourceProvider.FromFile(downloadPath));
await transferOperation.WaitForCompletionAsync();
```

Download a container which may contain a mix of blob types.

```C# Snippet:SimpleDirectoryDownload_Blob
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: await blobs.FromContainerAsync(
        blobContainerUri,
        new BlobStorageResourceContainerOptions()
        {
            BlobPrefix = optionalSourcePrefix
        }),
    destinationResource: LocalFilesStorageResourceProvider.FromDirectory(downloadPath));
await transferOperation.WaitForCompletionAsync();
```

### Blob Copy

A copy takes place between two blob `StorageResource` instances. Copying between to Azure blobs uses PUT from URL REST APIs, which do not transfer data through the machine running DataMovement.

Copy a single blob. Note the destination blob is an append blob, regardless of the first blob's type.

```C# Snippet:s2sCopyBlob
TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: await blobs.FromBlobAsync(sourceBlobUri),
    destinationResource: await blobs.FromBlobAsync(destinationBlobUri, new AppendBlobStorageResourceOptions()));
await transferOperation.WaitForCompletionAsync();
```

Copy a blob container.

```C# Snippet:s2sCopyBlobContainer
TransferOperation transferOperation = await transferManager.StartTransferAsync(
sourceResource: await blobs.FromContainerAsync(
    sourceContainerUri,
    new BlobStorageResourceContainerOptions()
    {
        BlobPrefix = sourceDirectoryName
    }),
destinationResource: await blobs.FromContainerAsync(
    destinationContainerUri,
    new BlobStorageResourceContainerOptions()
    {
        // all source blobs will be copied as a single type of destination blob
        // defaults to block blobs if unspecified
        BlobType = BlobType.Block,
        BlobPrefix = downloadPath
    }));
await transferOperation.WaitForCompletionAsync();
```

### Resume using ShareFilesStorageResourceProvider

To resume a transfer with Blob(s), valid credentials must be provided. See the sample below.

```C# Snippet:TransferManagerResumeTransfers
TokenCredential tokenCredential = new DefaultAzureCredential();
BlobsStorageResourceProvider blobs = new(tokenCredential);
TransferManager transferManager = new TransferManager(new TransferManagerOptions()
{
    ProvidersForResuming = new List<StorageResourceProvider>() { blobs }
});
// Get resumable transfers from transfer manager
await foreach (TransferProperties properties in transferManager.GetResumableTransfersAsync())
{
    // Resume the transfer
    if (properties.SourceUri.AbsoluteUri == "https://storageaccount.blob.core.windows.net/containername/blobpath")
    {
        await transferManager.ResumeTransferAsync(properties.TransferId);
    }
}
```

For more information regarding pause, resume, and/or checkpointing, see [Pause and Resume Checkpointing](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement/samples/PauseResumeCheckpointing.md).

### Extensions on `BlobContainerClient`

For applications with preexisting code using Azure.Storage.Blobs, this package provides extension methods for `BlobContainerClient` to get some of the benefits of the `TransferManager` with minimal extra code.

Instantiate the BlobContainerClient
```C# Snippet:ExtensionMethodCreateContainerClient
BlobServiceClient service = new BlobServiceClient(serviceUri, credential);

BlobContainerClient container = service.GetBlobContainerClient(containerName);
```

Upload a local directory to the root of the container
```C# Snippet:ExtensionMethodSimpleUploadToRoot
TransferOperation transfer = await container.UploadDirectoryAsync(WaitUntil.Started, localPath);

await transfer.WaitForCompletionAsync();
```

Upload a local directory to a virtual directory in the container by specifying a directory prefix
```C# Snippet:ExtensionMethodSimpleUploadToDirectoryPrefix
TransferOperation transfer = await container.UploadDirectoryAsync(WaitUntil.Started, localPath, blobDirectoryPrefix);

await transfer.WaitForCompletionAsync();
```

Upload a local directory to a virtual directory in the container specifying more advanced options
```C# Snippet:ExtensionMethodSimpleUploadWithOptions
BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
{
    BlobContainerOptions = new BlobStorageResourceContainerOptions
    {
        BlobPrefix = blobDirectoryPrefix
    },
    TransferOptions = new TransferOptions()
    {
        CreationMode = StorageResourceCreationMode.OverwriteIfExists,
    }
};

TransferOperation transfer = await container.UploadDirectoryAsync(WaitUntil.Started, localPath, options);

await transfer.WaitForCompletionAsync();
```

Download the entire container to a local directory
```C# Snippet:ExtensionMethodSimpleDownloadContainer
TransferOperation transfer = await container.DownloadToDirectoryAsync(WaitUntil.Started, localDirectoryPath);

await transfer.WaitForCompletionAsync();
```

Download a directory in the container by specifying a directory prefix
```C# Snippet:ExtensionMethodSimpleDownloadContainerDirectory
TransferOperation transfer = await container.DownloadToDirectoryAsync(WaitUntil.Started, localDirectoryPath2, blobDirectoryPrefix);

await transfer.WaitForCompletionAsync();
```

Download from the container specifying more advanced options
```C# Snippet:ExtensionMethodSimpleDownloadContainerDirectoryWithOptions
BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
{
    BlobContainerOptions = new BlobStorageResourceContainerOptions
    {
        BlobPrefix = blobDirectoryPrefix
    },
    TransferOptions = new TransferOptions()
    {
        CreationMode = StorageResourceCreationMode.OverwriteIfExists,
    }
};

TransferOperation transfer = await container.DownloadToDirectoryAsync(WaitUntil.Started, localDirectoryPath2, options);

await transfer.WaitForCompletionAsync();
```

## Troubleshooting

See [Handling Failed Transfers](#handling-failed-transfers) and [Enabling Logging](https://learn.microsoft.com/dotnet/azure/sdk/logging) to assist with any troubleshooting.

See [Known Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/KnownIssues.md) for detailed information.

## Next steps

Get started with our [Share Files Samples][share_samples].

For more base Transfer Manager scenarios see [DataMovement samples][datamovement_base].

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

<!-- LINKS -->
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Common/src
[package]: https://www.nuget.org/packages/Azure.Storage.Common/
[docs]: https://learn.microsoft.com/dotnet/api/azure.storage
[rest_docs]: https://learn.microsoft.com/rest/api/storageservices/
[product_docs]: https://learn.microsoft.com/azure/storage/
[nuget]: https://www.nuget.org/
[storage_account_docs]: https://learn.microsoft.com/azure/storage/common/storage-account-overview
[storage_account_create_ps]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-powershell
[storage_account_create_cli]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-cli
[storage_account_create_portal]: https://learn.microsoft.com/azure/storage/common/storage-quickstart-create-account?tabs=azure-portal
[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://learn.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[datamovement_base]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement
[share_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Files.Shares/samples
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
