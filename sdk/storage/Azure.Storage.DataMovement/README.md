# Azure Storage Data Movement Common client library for .NET

> Server Version: 2021-02-12, 2020-12-06, 2020-10-02, 2020-08-04, 2020-06-12, 2020-04-08, 2020-02-10, 2019-12-12, 2019-07-07, and 2020-02-02

Azure Storage is a Microsoft-managed service providing cloud storage that is
highly available, secure, durable, scalable, and redundant.

The Azure Storage Data Movement library is optimized for uploading, downloading and
copying customer data.

Currently this version of the Data Movement library only supports Blobs.

[Source code][source] | [API reference documentation][docs] | [REST API documentation][rest_docs] | [Product documentation][product_docs]

## Getting started

### Install the package

Install the Azure Storage client library for .NET you'd like to use with
[NuGet][nuget] and the `Azure.Storage.DataMovement` client library will be included:

```dotnetcli
dotnet add package Azure.Storage.DataMovement --prerelease
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

***TODO***

## Sample Usage

This section demonstrates usage of Data Movement regardless of extension package. Package-specific information and usage samples can be found in that package's documentation. These examples will use local disk and Azure Blob Storage when specific resources are needed for demonstration purposes, but the topics here will apply to other packages.

### Setup the `TransferManager`

Singleton usage of `TransferManager` is recommended. Providing `TransferManagerOptions` is optional.

```csharp
TransferManagerOptions options = new();
TransferManger transferManager = new TransferManager(options);
```

### Starting New Transfers

Transfers are defined by a source and destination `StorageResource`. There are two kinds of `StorageResource`: `StorageResourceSingle` and `StorageResourceContainer`. Source and destination of a given transfer must be of the same kind.

Configurations for accessing data are configured on the `StorageResource`. See further documentation for setting up and configuring your `StorageResource` objects.

```csharp
// provide these resources
StorageResource sourceResource, destinationResource;
// optionally configure options for this individual transfer
TransferOptions transferOptions = new();
// optional cancellation token for transfer startup
// not for cancelling the transfer once started!
CancellationToken cancellationToken;

DataTransfer dataTransfer = await transferManager.StartTransferAsync(
    sourceResource,
    destinationResource,
    transferOptions,
    cancellationToken);
```

### Monitoring Transfers

Transfers can be observed through several mechanisms, depending on your needs.

#### With `DataTransfer`

Simple observation can be done through a `DataTransfer` instance representing an individual transfer. This is obtained on transfer start. You can also enumerate through all transfers on a `TransferManager`.

```csharp
TransferManager transferManager;

await foreach (DataTransfer transfer in transferManager.GetTransfersAsync()) {
    // do something with transfer
}
```

`DataTransfer` contains property `TransferStatus`. You can read this to determine the state of the transfer. States include queued for transfer, in progress, paused, completed, and more.

`DataTransfer` also exposes a task for transfer completion that can be awaited.

```csharp
DataTransfer dataTransfer;

await dataTransfer.AwaitCompletion(cancellationToken);
```

#### With Events via `TransferOptions`

When starting a transfer, `TransferOptions` contains multiple events that can be listened to for observation. Below demonstrates listening to the event for a change in transfer status.

```csharp
TransferOptions transferOption;

transferOptions.TransferStatus += (TransferStatusEventArgs args) =>
{
    // handle status change on the whole transfer
}
```

#### With IProgress via `TransferOptions`

When starting a transfer, `TransferOptions` allows setting a progress handler that contains the progress information for the overall transfer. Granular progress updates will be communicated to the provided `IProgress` instance.

```csharp
TransferOptions transferOptions = new()
{
    ProgressHandler = new Progress<StorageTransferProgress>(storageTransferProgress =>
    {
        // handle progress update
    }),
    // optionally include the below if progress updates on bytes transferred are desired
    ProgressHandlerOptions = new()
    {
        TrackBytesTransferred = true
    }
}
```

### Pausing transfers

Transfers can be paused either by a given `DataTransfer` or through the `TransferManager` handling the transfer.

```csharp
DataTransfer dataTransfer;

await dataTransfer.PauseIfRunningAsync(cancellationToken);
```

```csharp
TransferManager transferManager;
string transferId;

await transferManager.PauseTransferIfRunningAsync(transferId, cancellationToken);
```

### Resuming transfers

Transfer progress is persisted such that it can resume from where it left off. No persisted knowledge is required from your code. The below sample queries a `TransferManager` for information on all resumable transfers and recreates the properly configured resources for these transfers using a helper method we'll define next. It then resumes each of those transfers with the given ID and puts the resulting `DataTransfer` objects into a list.

```csharp
TransferManager transferManager;

List<DataTransfer> resumedTransfers = new();
await foreach (DataTransferProperties transferProperties in transferManager.GetResumableTransfersAsync())
{
    (StorageResource resumeSource, StorageResource resumeDestination) = await MakeResourcesAsync(transferProperties);
    resumedTransfers.Add(await transferManager.ResumeTransferAsync(transferProperties.TransferId, resumeSource, resumeDestination));
}
```

Note that the transfer manager can only check for resumable transfers based on the `TransferCheckpointerOptions` configured in the `TransferManagerOptions` (default checkpointer options are used if none are provided).

The above sample's `MakeResourcesAsync` method is defined below. Different `DataMovement` packages provide their own helper functions to recreate the correctly configured `StorageResource` for resuming a transfer. The following example of such a method uses `Azure.Storage.DataMovement`'s built-in local filesystem helper and `Azure.Storage.DataMovement.Blobs`'s helper. You will need to add in other helpers for each package you use (e.g. `Azure.Storage.DataMovement.Files.Shares`).

Note these resources return a "provider" rather than the resource itself. The provider can make the resource using a credential argument based on resource information (or some other value that was not persisted), rather than create an unauthenticated `StorageResource`. More information on this can be found in applicable packages.

```csharp
async Task<(StorageResource Source, StorageResource Destination)> MakeResourcesAsync(DataTransferProperties info)
{
    StorageResource sourceResource = null, destinationResource = null;
    // ask DataMovement.Blobs if it can recreate source or destination resources to Blob Storage
    if (BlobStorageResources.TryGetResourceProviders(
        info,
        out BlobStorageResourceProvider blobSrcProvider,
        out BlobStorageResourceProvider blobDstProvider))
    {
        sourceResource ??= await blobSrcProvider?.MakeResourceAsync();
        destinationResource ??= await blobSrcProvider?.MakeResourceAsync();
    }
    // ask DataMovement if it can recreate source or destination resources to local storage
    if (LocalStorageResources.TryGetResourceProviders(
        info,
        out LocalStorageResourceProvider localSrcProvider,
        out LocalStorageResourceProvider localDstProvider))
    {
        sourceResource ??= localSrcProvider?.MakeResource();
        destinationResource ??= localDstProvider?.MakeResource();
    }
    return (sourceResource, destinationResource);
}
```

### Initializing Local File `StorageResource`

When transferring to or from local storage, construct a `LocalFileStorageResource` for single-file transfers or `LocalDirectoryStorageResourceContainer` for directory transfers. Use one of these as the source resource for upload and as the destination for download. Local to local copies are not supported.

```csharp
StorageResource fileResource = new LocalFileStorageResource("C:/path/to/file.txt");
StorageResource directoryResource = new LocalDirectoryStorageResourceContainer("C:/path/to/dir");
```

## Troubleshooting

***TODO***

## Next steps

Get started with our [Blob DataMovement samples][samples].

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
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement/src
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
[auth_credentials]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Common/src/StorageSharedKeyCredential.cs
[blobs_examples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs#examples
[RequestFailedException]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/src/RequestFailedException.cs
[error_codes]: https://docs.microsoft.com/rest/api/storageservices/common-rest-api-error-codes
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/storage/Azure.Storage.DataMovement.Blobs/samples
[storage_contrib]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
