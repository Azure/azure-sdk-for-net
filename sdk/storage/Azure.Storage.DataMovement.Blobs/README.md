# Azure Storage Data Movement Blobs client library for .NET

> Server Version: 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2020-02-02

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant. Azure Storage
includes Azure Blobs (objects), Azure Data Lake Storage Gen2, Azure Files,
and Azure Queues.

The Azure Storage Data Movement library is optimized for uploading, downloading and
copying customer data.

The Azure.Storage.DataMovement.Blobs library provides infrastructure shared by the other
Azure Storage client libraries.

[Source code][source] | [Package (NuGet)][package] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.DataMovement.Blobs` client library will be included:

```dotnetcli
dotnet add package Azure.Storage.DataMovement --prerelease
dotnet add package Azure.Storage.DataMovement.Blobs --prerelease
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

### Extensions on `BlobContainerClient`

For applicatons with preexisting code using Azure.Storage.Blobs, this package provides extension methods for `BlobContainerClient` to get some of the benefits of the `TransferManager` with minimal extra code.

Instantiate the BlobContainerClient
```C# Snippet:ExtensionMethodCreateContainerClient
BlobServiceClient service = new BlobServiceClient(serviceUri, credential);

BlobContainerClient container = service.GetBlobContainerClient(containerName);
```

Upload a local directory to the root of the container
```C# Snippet:ExtensionMethodSimpleUploadToRoot
DataTransfer transfer = await container.StartUploadDirectoryAsync(localPath);

await transfer.WaitForCompletionAsync();
```

Upload a local directory to a virtual directory in the container by specifying a directory prefix
```C# Snippet:ExtensionMethodSimpleUploadToDirectoryPrefix
DataTransfer transfer = await container.StartUploadDirectoryAsync(localPath, blobDirectoryPrefix);

await transfer.WaitForCompletionAsync();
```

Upload a local directory to a virtual directory in the container specifying more advanced options
```C# Snippet:ExtensionMethodSimpleUploadWithOptions
BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
{
    BlobContainerOptions = new BlobStorageResourceContainerOptions
    {
        DirectoryPrefix = blobDirectoryPrefix
    },
    TransferOptions = new TransferOptions()
    {
        CreateMode = StorageResourceCreateMode.Overwrite,
    }
};

DataTransfer transfer = await container.StartUploadDirectoryAsync(localPath, options);

await transfer.WaitForCompletionAsync();
```

Download the entire container to a local directory
```C# Snippet:ExtensionMethodSimpleDownloadContainer
DataTransfer transfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath);

await transfer.WaitForCompletionAsync();
```

Download a directory in the container by specifying a directory prefix
```C# Snippet:ExtensionMethodSimpleDownloadContainerDirectory
DataTransfer tranfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath2, blobDirectoryPrefix);

await tranfer.WaitForCompletionAsync();
```

Download from the container specifying more advanced options
```C# Snippet:ExtensionMethodSimpleDownloadContainerDirectoryWithOptions
BlobContainerClientTransferOptions options = new BlobContainerClientTransferOptions
{
    BlobContainerOptions = new BlobStorageResourceContainerOptions
    {
        DirectoryPrefix = blobDirectoryPrefix
    },
    TransferOptions = new TransferOptions()
    {
        CreateMode = StorageResourceCreateMode.Overwrite,
    }
};

DataTransfer tranfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath2, options);

await tranfer.WaitForCompletionAsync();
```

### Initializing Blob Storage `StorageResource`

Azure.Storage.DataMovement.Blobs exposes a `StorageResource` for each type of blob (block, page, append) as well as a blob container. Storage resources are initialized with the appropriate client object from Azure.Storage.Blobs.

```C# Snippet:ResourceConstruction_Blobs
StorageResource containerResource = new BlobStorageResourceContainer(blobContainerClient);
StorageResource blockBlobResource = new BlockBlobStorageResource(blockBlobClient);
StorageResource pageBlobResource = new PageBlobStorageResource(pageBlobClient);
StorageResource appendBlobResource = new AppendBlobStorageResource(appendBlobClient);
```

Blob `StorageResource` objects can be constructed with optional "options" arguments specific to the type of resource.

```C# Snippet:ResourceConstruction_Blobs_WithOptions_VirtualDirectory
BlobStorageResourceContainerOptions virtualDirectoryOptions = new()
{
    DirectoryPrefix = "blob/directory/prefix"
};

StorageResource virtualDirectoryResource = new BlobStorageResourceContainer(
    blobContainerClient,
    virtualDirectoryOptions);
```

```C# Snippet:ResourceConstruction_Blobs_WithOptions_BlockBlob
BlockBlobStorageResourceOptions leasedResourceOptions = new()
{
    SourceConditions = new()
    {
        LeaseId = leaseId
    }
};
StorageResource leasedBlockBlobResource = new BlockBlobStorageResource(
    blockBlobClient,
    leasedResourceOptions);
```

When resuming a transfer, a credential to Azure Storage is likely needed. Credentials are not persisted by the transfer manager. When using `BlobStorageResources.TryGetResourceProviders()` to recreate a `StorageResource` for resume, the returned provider can create the resource with a credential specified by the calling code. This allows for workflows like scoping generation of a Shared Access Signature to the given resource path. Your application should provide its own mechanism for getting the appropriate credential, represented by `GenerateMySasCredential()` in the sample below.

```C# Snippet:RehydrateBlobResource
StorageResource sourceResource = null;
StorageResource destinationResource = null;
if (BlobStorageResources.TryGetResourceProviders(
    info,
    out BlobStorageResourceProvider blobSrcProvider,
    out BlobStorageResourceProvider blobDstProvider))
{
    sourceResource ??= await blobSrcProvider?.MakeResourceAsync(
        GenerateMySasCredential(info.SourcePath));
    destinationResource ??= await blobSrcProvider?.MakeResourceAsync(
        GenerateMySasCredential(info.DestinationPath));
}
```

### Upload

An upload takes place between a local file `StorageResource` as source and blob `StorageResource` as destination.

Upload a block blob.

```C# Snippet:SimpleBlobUpload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new LocalFileStorageResource(sourceLocalPath),
    destinationResource: new BlockBlobStorageResource(destinationBlob));
await dataTransfer.WaitForCompletionAsync();
```

Upload a directory as a specific blob type.

```C# Snippet:SimpleDirectoryUpload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new LocalDirectoryStorageResourceContainer(sourcePath),
    destinationResource: new BlobStorageResourceContainer(
        blobContainerClient,
        new BlobStorageResourceContainerOptions()
        {
            // Block blobs are the default if not specified
            BlobType = BlobType.Block,
            DirectoryPrefix = optionalDestinationPrefix,
        }),
    transferOptions: options);
await dataTransfer.WaitForCompletionAsync();
```

### Download

A download takes place between a blob `StorageResource` as source and local file `StorageResource` as destination.

Download a block blob.

```C# Snippet:SimpleBlockBlobDownload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new BlockBlobStorageResource(sourceBlobClient),
    destinationResource: new LocalFileStorageResource(downloadPath));
await dataTransfer.WaitForCompletionAsync();
```

Download a container which may contain a mix of blob types.

```C# Snippet:SimpleDirectoryDownload_Blob
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new BlobStorageResourceContainer(
        blobContainerClient,
        new BlobStorageResourceContainerOptions()
        {
            DirectoryPrefix = optionalSourcePrefix
        }),
    destinationResource: new LocalDirectoryStorageResourceContainer(downloadPath));
await dataTransfer.WaitForCompletionAsync();
```

### Blob Copy

A copy takes place between two blob `StorageResource` instances. Copying between to Azure blobs uses PUT from URL REST APIs, which do not pass data through the calling machine.

Copy a single blob. Note the change in blob type on this copy from block to append.

```C# Snippet:s2sCopyBlob
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new BlockBlobStorageResource(sourceBlockBlobClient),
    destinationResource: new AppendBlobStorageResource(destinationAppendBlobClient));
await dataTransfer.WaitForCompletionAsync();
```

Copy a blob container.

```C# Snippet:s2sCopyBlobContainer
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: new BlobStorageResourceContainer(
        sourceContainer,
        new BlobStorageResourceContainerOptions()
        {
            DirectoryPrefix = sourceDirectoryName
        }),
    destinationResource: new BlobStorageResourceContainer(
        destinationContainer,
        new BlobStorageResourceContainerOptions()
        {
            // all source blobs will be copied as a single type of destination blob
            // defaults to block blobs if unspecified
            BlobType = BlobType.Block,
            DirectoryPrefix = downloadPath
        }));
```

## Troubleshooting

***TODO***

## Next steps

***TODO***

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.Common/src
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
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs/samples
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
