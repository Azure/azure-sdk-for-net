# Migration Guide: From Microsoft.Azure.Storage.DataMovement to Azure.Storage.DataMovement

This guide intends to assist customers in migrating from version 2 of the Azure Storage .NET Data Movement library to version 12.
It will focus on side-by-side comparisons for similar operations between the v12 package, [`Azure.Storage.DataMovement`](https://www.nuget.org/packages/Azure.Storage.DataMovement) and v2 package, [`Microsoft.Azure.Storage.DataMovement`](https://www.nuget.org/packages/Microsoft.Azure.Storage.DataMovement/).

Familiarity with the legacy data movement client library is assumed. For those new to the Azure Storage Data Movement client library for .NET, please refer to the Quickstart (TODO link) for the v12 library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Authentication](#authentication)
  - [Type structure](#type-structure)
    - [TransferManager](#transfermanager)
    - [Storage resources and providers](#storage-resources-and-providers)
    - [TransferContext &rarr; TransferOptions](#transfercontext--transferoptions)
- [Migration samples](#migration-samples)
- [Additional information](#additional-information)

## Migration benefits

Version 12 of the Data Movemenet library inherits all the benefits of the version 12 storage client libraries, detailed in the next section. In addition, the following are benefits of the new design:

TODO

### Core client library migration benefits

To understand why we created our version 12 client libraries, you may refer to the Tech Community blog post, [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) or refer to our video [Introducing the New Azure SDKs](https://aka.ms/azsdk/intro).

Included are the following:
- Thread-safe synchronous and asynchronous APIs
- Improved performance
- Consistent and idiomatic code organization, naming, and API structure, aligned with a set of common guidelines
- The learning curve associated with the libraries was reduced

Note: The blog post linked above announces deprecation for previous versions of the library.

## General changes

### Package and namespaces

Package names and the namespaces root for version 12 Azure client libraries follow the pattern `Azure.[Area].[Service]` where the legacy libraries followed the pattern `Microsoft.Azure.[Area].[Service]`.

In this case, the legacy package was installed with:
```
dotnet add package Microsoft.Azure.Storage.DataMovement
```

While version 12 is now installed with:
```
dotnet add package Azure.Storage.DataMovement
dotnet add package Azure.Storage.DataMovement.Blobs
```

Note the separation of the Data Movement package from the Blob Storage Data Movement package. Packages to other storage services can be added or removed from your installation.

### Type Structure

This section to discuss the following as important structural API changes:

- Changes to the `TransferManager`
- New `StorageResource` type and storage resource providers
- Replacing `TransferContext` with `TransferOptions`

#### TransferManager

The `TransferManager` is still the core type that handles transfers in Data Movement, though its API has been completely rewritten.
It is no longer a static type, though **we recommend maintaining a singleton instance** for optimal usage.

All transfer methods for upload, download, and copy, for both files and directories, have been replaced with a single instance method:
```csharp
Task<TransferOperation> StartTransferAsync(
    StorageResource sourceResource,
    StorageResource destinationResource,
    TransferOptions transferOptions = default,
    CancellationToken cancellationToken = default)
```
The appropriate upload, download, or copy operation will be performed based on the `StorageResource` instances passed. E.g., a `sourceResource` pointing to a local file and a `destinationResource` pointing to an Azure blob will perform an upload. More information on `StorageResource` can be found in the following section on [storage resources and providers](#storage-resources-and-providers).

The following table is a quick reference of where to find functionality from legacy `TransferManager` APIs. This **does not** imply fully identical behavior between libraries.

| Operation | Legacy `TransferManager` API | Modern API
| --------- | ---------- | ---------- |
| Upload, Download, Copy | `UploadAsync`, `UploadDirectoryAsync`, `DownloadAsync`, `DownloadDirectoryAsync`, `CopyAsync`, `CopyDirectoryAsync` | `TransferManager.StartTransferAsync`
| Limit concurrent transfers | `Configurations.ParallelOperations` | `TransferManagerOptions.MaximumConcurrency` (applied at TransferManager construction)
| Limit concurrent listings | `Configurations.MaxListingConcurrency` | Not implemented
| Limit memory usage | `Configurations.MaximumCacheSize` | Not implemented
| Set chunking size | `Configurations.BlockSize` | `TransferOptions.MaximumTransferChunkSize` (applied at TransferManager construction)
| Alter user agent string | `Configurations.UserAgentPrefix` | Not implemented

#### Storage Resources and Providers

The modern library introduces a new and unified `StorageResource` type. While the legacy library directly used types like `CloudBlob` and `CloudFile` in its API, the modern library uses `StorageResource` to define transfer source and destination. Storage resources can be further divided into two subtypes: **items** and **containers**. Examples of items are block blobs and local files. Examples of containers are blob containers and local folders.

**Important:** a transfer **must** be between two items or two containers. An exception will be thrown when attempting to transfer an item to a container and vice versa.

`StorageResource` instances are obtained through providers. Providers are often scoped to a single storage service and will have unique APIs to acquire `StorageResource` instances as well as properly authenticate them. Here is an example using providers to create an upload to an Azure blob. Further examples can be found in our [migration samples](#migration-samples).

```csharp
BlobsStorageResourceProvider blobs = new(myTokenCredential);
TransferManager transferManager = new TransferManager();

TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: LocalFilesStorageResourceProvider.FromFile(sourceLocalPath),
    destinationResource: blobs.FromBlob(destinationBlobUri));
```

Providers can also be registered with the `TransferManager` at construction as a mechanism to resume in case of a failure. (TODO link to resume sample).

#### TransferContext &rarr; TransferOptions

In the legacy library, `TransferContext` was an object with per-transfer specifications. In the modern library, `TransferOptions` is its replacement.

Not all functionality exposed by `TransferContext` is currently supported in the modern Data Movement library.

The following table is a quick reference of where to find functionality from legacy `TransferContext` APIs. This **does not** imply fully identical behavior between libraries.

| Configuration | Legacy `TransferContext` API | Modern API
| ------------- | ---------------------------- | ----------
| Checkpointing | `TransferCheckpoint` provided at `TransferContext` construction |  `TransferCheckpointStoreOptions` provided at `TransferManagerOptions` construction.
| Observe checkpointing | `LastCheckpoint` | Not implemented
| Client request ID | `ClientRequestId` | Not implemented
| Logging | `LogLevel` | **No longer per-transfer**. `TransferManagerOptions.Diagnostics`.
| Overwrite | `ShouldOverwriteCallbackAsync` | `TransferOptions.CreationPreference`
| Progress Handling | `ProgressHandler` | `TransferOptions.ProgressHandlerOptions`
| Transfer Updates | `FileTransferred`, `FileSkipped`, `FileFailed` | `TransferOptions.ItemTransferCompleted`, `TransferOptions.ItemTransferFailed`, `TransferOptions.ItemTransferSkipped`, `TransferOptions.TransferStatusChanged`
| Attributes | `SetAttributesContextAsync` | TODO

### Authentication

#### Azure Active Directory

TODO

You can view more [Identity samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#examples) for how to authenticate with the Identity package.

#### SAS

TODO

#### Shared Key

TODO

## Migration Samples

This section contains side-by-side samples of legacy vs modern library usage of various features.
These samples are not meant to be exhaustive, but demonstrate a wide variety of uses that may need migration.

- Upload
  - Upload single file to blob storage
  - Upload directory to blob storage
- Download
  - Download single blob
  - Download blob directory
- Service to service copy
  - Copy blob to blob
  - Copy share file to blob

### Upload

#### Upload single file to blob storage

**Legacy:**
```csharp
// these values provided by your code
string filePath, containerName, blobName;
CloudBlobClient client;
```
```csharp
// upload blob
await TransferManager.UploadAsync(
    filePath,
    client.GetContainerReference(containerName).GetBlockBlobReference(blobName));
```
**Modern:**
```csharp
// these values provided by your code
string filePath, blobUri;
BlobsStorageResourceProvider blobs;
TransferManager transferManager;
```

```csharp
// upload blob
TranferOperation operation = await transferManager.StartTransferAsync(
    LocalFilesStorageResourceProvider.FromFile(filePath),
    blobs.FromBlob(blobUri));
await operation.WaitForCompletionAsync();
```

#### Upload directory to blob storage

**Legacy:**
```csharp
// these values provided by your code
string directoryPath, containerName, blobDirectoryPath;
CloudBlobClient client;
```
```csharp
// upload blob
await TransferManager.UploadDirectoryAsync(
    directoryPath,
    client.GetContainerReference(containerName).GetDirectoryReference(blobDirectoryPath));
```
**Modern:**
```csharp
// these values provided by your code
string directoryPath, containerUri, blobDirectoryPath;
BlobsStorageResourceProvider blobs;
TransferManager transferManager;
```

```csharp
// upload blobs
TranferOperation operation = await transferManager.StartTransferAsync(
    LocalFilesStorageResourceProvider.FromDirectory(directoryPath),
    blobs.FromContainer(containerUri, new BlobStorageResourceContainerOptions()
    {
        BlobDirectoryPrefix = blobDirectoryPath,
    }));
await operation.WaitForCompletionAsync();
```

### Download

#### Download single blob

**Legacy:**
```csharp
// these values provided by your code
string filePath, containerName, blobName;
CloudBlobClient client;
```
```csharp
// download blob
await TransferManager.DownloadAsync(
    client.GetContainerReference(containerName).GetBlockBlobReference(blobName),
    filePath);
```
**Modern:**
```csharp
// these values provided by your code
string filePath, blobUri;
BlobsStorageResourceProvider blobs;
TransferManager transferManager;
```
```csharp
// download blob
TranferOperation operation = await transferManager.StartTransferAsync(
    blobs.FromBlob(blobUri),
    LocalFilesStorageResourceProvider.FromFile(filePath));
await operation.WaitForCompletionAsync();
```

#### Download blob directory

**Legacy:**
```csharp
// these values provided by your code
string directoryPath, containerName, blobDirectoryPath;
CloudBlobClient client;
```
```csharp
// download blob directory
await TransferManager.DownloadDirectoryAsync(
    client.GetContainerReference(containerName).GetDirectoryReference(blobDirectoryPath),
    filePath,
    options: null,
    context: null);
```
**Modern:**
```csharp
// these values provided by your code
string directoryPath, containerUri, blobDirectoryPath;
BlobsStorageResourceProvider blobs;
TransferManager transferManager;
```
```csharp
// download blob directory
TranferOperation operation = await transferManager.StartTransferAsync(
    blobs.FromContainer(containerUri, new BlobStorageResourceContainerOptions()
    {
        BlobDirectoryPrefix = blobDirectoryPath,
    }),
    LocalFilesStorageResourceProvider.FromDirectory(directoryPath));
await operation.WaitForCompletionAsync();
```

### Copy

#### Copy blob to blob

Note: The modern data movement library only supports service side sync copy.

**Legacy:**
```csharp
// these values provided by your code
string srcContainerName, srcBlobName, dstContainerName, dstBlobName;
CloudBlobClient client;
```
```csharp
// copy blob
await TransferManager.DownloadAsync(
    client.GetContainerReference(srcContainerName).GetBlockBlobReference(srcBlobName),
    client.GetContainerReference(dstContainerName).GetBlockBlobReference(dstBlobName),
    CopyMethod.ServiceSideSyncCopy);
```
**Modern:**
```csharp
// these values provided by your code
string srcBlobUri, dstBlobUri;
BlobsStorageResourceProvider blobs;
TransferManager transferManager;
```
```csharp
// copy blob
TranferOperation operation = await transferManager.StartTransferAsync(
    blobs.FromBlob(srcBlobUri),
    blobs.FromBlob(dstBlobUri));
await operation.WaitForCompletionAsync();
```

#### Copy blob to share file

Note: File shares requires the Azure.Storage.DataMovement.Files.Shares package.

**Legacy:**
```csharp
// these values provided by your code
string containerName, blobName, shareName, filePath;
CloudBlobClient blobClient;
CloudFileClient fileClient;
```
```csharp
// copy file
await TransferManager.DownloadAsync(
    blobClient.GetContainerReference(srcContainerName).GetBlockBlobReference(srcBlobName),
    fileClient.GetShareReference(dstContainerName).GetRootDirectoryReference().GetBlockBlobReference(dstBlobName),
    CopyMethod.ServiceSideSyncCopy);
```
**Modern:**
```csharp
// these values provided by your code
string blobUri, fileUri;
BlobsStorageResourceProvider blobs;
ShareFilesStorageResourceProvider files;
TransferManager transferManager;
```
```csharp
// copy file
TranferOperation operation = await transferManager.StartTransferAsync(
    blobs.FromBlob(blobUri),
    files.FromFile(fileUri));
await operation.WaitForCompletionAsync();
```

### Progress Reporting

#### Post-transfer report

In the legacy data movement library, it was possible to check a report of how many files were or were not transferred in a directory transfer, as shown below.
With the modern library, applications must instead enable progress reporting or listen to transfer events, as detailed in the following sections.

```csharp
TransferStatus status = await TransferManager.UploadDirectoryAsync(
    directoryPath,
    client.GetContainerReference(containerName).GetDirectoryReference(blobDirectoryPath));
// observe status
// status.NumberOfFilesTransferred
// status.NumberOfFilesSkipped
// status.NumberOfFilesFailed
// status.BytesTransferred
```

#### IProgress

**Legacy:**
```csharp
// progress handler provided by your code
IProgress<TransferStatus> progress;
```
```csharp
await TransferManager.UploadDirectoryAsync(
    directoryPath,
    client.GetContainerReference(containerName).GetDirectoryReference(blobDirectoryPath),
    options: default,
    new DirectoryTransferContext()
    {
        ProgressHandler = progress,
    });
```
**Modern:**
```csharp
// progress handler provided by your code
IProgress<TransferProgress> progress;
// if TransferProgress report is desired for
// each transfer of bytes, set to true.
bool reportBytes;
```
```csharp
// upload blobs
TranferOperation operation = await transferManager.StartTransferAsync(
    LocalFilesStorageResourceProvider.FromDirectory(directoryPath),
    blobs.FromContainer(containerUri, new BlobStorageResourceContainerOptions()
    {
        BlobDirectoryPrefix = blobDirectoryPath,
    }),
    new TransferOptions()
    {
        new ProgressHandlerOptions()
        {
            ProgressHandler = progress,
            TrackBytesTransferred = reportBytes;
        }
    });
await operation.WaitForCompletionAsync();
```

#### Eventing (new to modern library)

**Modern:**
```csharp
// callback provided by your code
Func<TransferItemCompletedEventArgs, Task> onItemCompleted;
Func<TransferItemSkippedEventArgs, Task> onItemSkipped;
Func<TransferItemFailedEventArgs, Task> onItemFailed;
```
```csharp
TransferOptions options = new TransferOptions();
options.ItemTransferCompleted += onItemCompleted;
options.ItemTransferSkipped += onItemSkipped;
options.ItemTransferFailed += onItemFailed;
TranferOperation operation = await transferManager.StartTransferAsync(
    LocalFilesStorageResourceProvider.FromDirectory(directoryPath),
    blobs.FromContainer(containerUri, new BlobStorageResourceContainerOptions()
    {
        BlobDirectoryPrefix = blobDirectoryPath,
    }),
    options);
await operation.WaitForCompletionAsync();
```

### Pause and resume

#### Pause

In the legacy library, transfers were paused by invoking a cancellation token.
In the modern library, transfers are paused by calling the pause method on a given `TransferOperation`.

**Legacy:**
```csharp
CancellationTokenSource cts = new();
Task uploadTask = TransferManager.UploadAsync(source, destination, cts.Token);
cts.Cancel();
```
**Modern:**
```csharp
TransferOperation transfer = await transferManager.StartTransferAsync(source, destination);
await transfer.PauseAsync();
```

#### Resume

In the legacy library, transfers were resumed by starting a transfer that matched an existing transfer in the context's journal.
In the modern library, a separate resume API exists to resume a transfer by ID.

For resume, the transfer manager must be configured with a provider for each service involved in a transfer to be resumed.
This allows for the appropriate credential to be supplied, as credentials are not stored in the checkpointer.

No provider is needed for local files.

No checkpointer is needed to be supplied; it is enabled by default to write to a temporary directory on the local machine.
Checkpointer options may be supplied to the transfer manager to configure the directory or to disable checkpointing entirely.

**Legacy:**
```csharp
SingleTransferContext context = new(journalStream);
Task uploadTask = TransferManager.UploadAsync(
    source,
    destination,
    options: default,
    context);
```
**Modern:**
```csharp
TransferManager transferManager = new(new TransferManagerOptions()
{
    // enable to resume transfers involving blob storage
    ResumeProviders = new() { new BlobsStorageResourceProvider(myCredential) },
});
TransferOperation transfer = await transferManager.ResumeTransferAsync(transferId);
```

The modern `TransferManager` also has methods to enumerate resumable transfers.

```csharp
List<TranferOperation> operations = new();
await foreach (TransferProperties transferProperties in transferManager.GetResumableTransfersAsync())
{
    operations.Add(await transferManager.ResumeTransferAsync());
}
```

The above sample is a simplified version of `TransferManager.ResumeAllTransfersAsync()` and can be simplified to the following.

```csharp
List<TranferOperation> operations = await transferManager.ResumeAllTransfersAsync();
```

## Additional information

### Links and references
- Quickstart (TODO link)
- Samples (TODO link)
- DataMovement reference (TODO link)
- [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) blog post
