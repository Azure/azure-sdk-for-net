# Azure Storage Data Movement Blobs client library for .NET

> Server Version: 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2020-02-02

## Project Status: Beta

This product is in beta. Some features will be missing or have significant bugs. Please see [Known Issues](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/KnownIssues.md) for detailed information.

---

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

For applications with preexisting code using Azure.Storage.Blobs, this package provides extension methods for `BlobContainerClient` to get some of the benefits of the `TransferManager` with minimal extra code.

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
        BlobDirectoryPrefix = blobDirectoryPrefix
    },
    TransferOptions = new DataTransferOptions()
    {
        CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
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
        BlobDirectoryPrefix = blobDirectoryPrefix
    },
    TransferOptions = new DataTransferOptions()
    {
        CreationPreference = StorageResourceCreationPreference.OverwriteIfExists,
    }
};

DataTransfer tranfer = await container.StartDownloadToDirectoryAsync(localDirectoryPath2, options);

await tranfer.WaitForCompletionAsync();
```

### Initializing Blob Storage `StorageResource`

Azure.Storage.DataMovement.Blobs exposes `BlobsStorageResourceProvider` to create `StorageResource` instances for each type of blob (block, page, append) as well as a blob container. The resource provider should be initialized with a credential to properly authenticate the storage resources. The following demonstrates this using an `Azure.Core` token credential.

```C# Snippet:MakeProvider_TokenCredential
BlobsStorageResourceProvider blobs = new(tokenCredential);
```

To create a blob `StorageResource`, use the methods `FromBlob` or `FromContainer`.

```C# Snippet:ResourceConstruction_Blobs
StorageResource container = blobs.FromContainer(
    "http://myaccount.blob.core.windows.net/container");

// Block blobs are the default if no options are specified
StorageResource blockBlob = blobs.FromBlob(
    "http://myaccount.blob.core.windows.net/container/sample-blob-block",
    new BlockBlobStorageResourceOptions());
StorageResource pageBlob = blobs.FromBlob(
    "http://myaccount.blob.core.windows.net/container/sample-blob-page",
    new PageBlobStorageResourceOptions());
StorageResource appendBlob = blobs.FromBlob(
    "http://myaccount.blob.core.windows.net/container/sample-blob-append",
    new AppendBlobStorageResourceOptions());
```

Storage resources can also be initialized with the appropriate client object from Azure.Storage.Blobs. Since these resources will use the credential already present in the client object, no credential is required in the provider when using `FromClient()`. **However**, a `BlobsStorageResourceProvider` must still have a credential if it is to be used in `TransferManagerOptions` for resuming a transfer.

```C# Snippet:ResourceConstruction_FromClients_Blobs
BlobsStorageResourceProvider blobs = new();
StorageResource containerResource = blobs.FromClient(blobContainerClient);
StorageResource blockBlobResource = blobs.FromClient(blockBlobClient);
StorageResource pageBlobResource = blobs.FromClient(pageBlobClient);
StorageResource appendBlobResource = blobs.FromClient(appendBlobClient);
```

There are more options which can be used when creating a blob storage resource. Below are some examples.

```C# Snippet:ResourceConstruction_Blobs_WithOptions_VirtualDirectory
BlobStorageResourceContainerOptions virtualDirectoryOptions = new()
{
    BlobDirectoryPrefix = "blob/directory/prefix"
};

StorageResource virtualDirectoryResource = blobs.FromClient(
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
StorageResource leasedBlockBlobResource = blobs.FromClient(
    blockBlobClient,
    resourceOptions);
```

### Upload

An upload takes place between a local file `StorageResource` as source and blob `StorageResource` as destination.

Upload a block blob.

```C# Snippet:SimpleBlobUpload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: files.FromFile(sourceLocalPath),
    destinationResource: blobs.FromBlob(destinationBlobUri));
await dataTransfer.WaitForCompletionAsync();
```

Upload a directory as a specific blob type.

```C# Snippet:SimpleDirectoryUpload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: files.FromDirectory(sourcePath),
    destinationResource: blobs.FromContainer(
        blobContainerUri,
        new BlobStorageResourceContainerOptions()
        {
            // Block blobs are the default if not specified
            BlobType = BlobType.Block,
            BlobDirectoryPrefix = optionalDestinationPrefix,
        }));
```

### Download

A download takes place between a blob `StorageResource` as source and local file `StorageResource` as destination.

Download a blob.

```C# Snippet:SimpleBlockBlobDownload
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: blobs.FromBlob(sourceBlobUri),
    destinationResource: files.FromFile(downloadPath));
await dataTransfer.WaitForCompletionAsync();
```

Download a container which may contain a mix of blob types.

```C# Snippet:SimpleDirectoryDownload_Blob
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: blobs.FromContainer(
        blobContainerUri,
        new BlobStorageResourceContainerOptions()
        {
            BlobDirectoryPrefix = optionalSourcePrefix
        }),
    destinationResource: files.FromDirectory(downloadPath));
await dataTransfer.WaitForCompletionAsync();
```

### Blob Copy

A copy takes place between two blob `StorageResource` instances. Copying between to Azure blobs uses PUT from URL REST APIs, which do not transfer data through the machine running DataMovement.

Copy a single blob. Note the destination blob is an append blob, regardless of the first blob's type.

```C# Snippet:s2sCopyBlob
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource: blobs.FromBlob(sourceBlobUri),
    destinationResource: blobs.FromBlob(destinationBlobUri, new AppendBlobStorageResourceOptions()));
await dataTransfer.WaitForCompletionAsync();
```

Copy a blob container.

```C# Snippet:s2sCopyBlobContainer
DataTransfer dataTransfer = await transferManager.StartTransferAsync(
sourceResource: blobs.FromContainer(
    sourceContainerUri,
    new BlobStorageResourceContainerOptions()
    {
        BlobDirectoryPrefix = sourceDirectoryName
    }),
destinationResource: blobs.FromContainer(
    destinationContainerUri,
    new BlobStorageResourceContainerOptions()
    {
        // all source blobs will be copied as a single type of destination blob
        // defaults to block blobs if unspecified
        BlobType = BlobType.Block,
        BlobDirectoryPrefix = downloadPath
    }));
await dataTransfer.WaitForCompletionAsync();
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
