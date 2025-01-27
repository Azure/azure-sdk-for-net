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
LocalFilesStorageResourceProvider files = new();
BlobsStorageResourceProvider blobs = new(myTokenCredential);
TransferManager transferManager = new TransferManager();

TransferOperation transferOperation = await transferManager.StartTransferAsync(
    sourceResource: files.FromFile(sourceLocalPath),
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

TODO
- Upload
- Download
- S2S
- Progress reporting
- Error reporting
- Pause/Resume

## Additional information

### Links and references
- Quickstart (TODO link)
- Samples (TODO link)
- DataMovement reference (TODO link)
- [Announcing the Azure Storage v12 Client Libraries](https://techcommunity.microsoft.com/t5/azure-storage/announcing-the-azure-storage-v12-client-libraries/ba-p/1482394) blog post
