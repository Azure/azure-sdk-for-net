# Release History

## 4.1.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 4.0.0 (2022-08-18)

### Breaking Changes

The changes incorporated in this version are the product of migrating from the deprecated WindowsAzure .NET Storage SDK to the current Azure.Storage SDK. As a result, all the changes included in this version are **Breaking**. More information about migrating to Azure.Storage can be found [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.Blobs/AzureStorageNetMigrationV12.md).

- Support of the following target frameworks has been dropped as they are not supported by the current Azure.Storage SDK.
  - netstandard1.4,
  - netstandard1.5,
  - netstandard1.6,
  - net452,
  - net46

- Replaced the following WindowsAzure SDK class references with the following Azure.Storage counterparts:

| v11 | v12 |
|-------|--------|
| `CloudStorageAccount` | `BlobServiceClient` |
| `CloudBlobContainer`  | `BlobContainerClient` |
| `CloudAppendBlob` | `AppendBlobClient` |

- CloudJobExtensions
  - Modified the following method headers to replace `CloudStorageAccount` to accepting an instance of **BlobServiceClient**
    - `OutputStorage`
    - `PrepareOutputStorageAsync`
    - `GetOutputStorageContainerUrl`

- CloudTaskExtensions
  - Modified the `TaskOutputStorage` method header to replace `CloudStorageAccount` to accepting an instance of **BlobServiceClient**

- JobOutputStorage
  - Replaced all instances of `CloudStorageAccount` with **BlobServiceClient**
  - Replaced all instances of `CloudBlobContainer` with **BlobContainerClient**
  - Removed the `IRetryPolicy` reference from the constructors as it is no longer supported in the new storage sdk. If you wish to specify how retry attempts are made, you will have to do so by specifying the `Retry` property within the `BlobClientOptions` passed into the **BlobServiceClient** object. More information can be found [here](https://learn.microsoft.com/dotnet/api/azure.storage.blobs.blobclientoptions)
    - Renamed the `GetOutputAsync` method to **GetOutput** as the method is no longer asynchronous, also removed the `CancellationToken` parameter.

- OutputFileReference
  - Replaced all instances of `ICloudBlob` with **BlobBaseClient**
  - Modified the `DownloadToFileAsync` method to not accept a FileMode parameter.
  - Modified the `DeleteAsync` method to include a **DeleteSnapshotsOption** parameter for controlling options on deleting snapshots.

- TaskOutputStorage
  - Replaced all instances of `CloudStorageAccount` with **BlobServiceClient**
  - Replaced all instances of `CloudBlobContainer` with **BlobContainerClient**
  - Removed the `IRetryPolicy` reference from the constructors as it is no longer supported in the new storage sdk. If you wish to specify how retry attempts are made, you will have to do so by specifying the `Retry` property within the `BlobClientOptions` passed into the **BlobServiceClient** object. More information can be found [here](https://learn.microsoft.com/dotnet/api/azure.storage.blobs.blobclientoptions)
  - Renamed the `GetOutputAsync` method to **GetOutput** as the method is no longer asynchronous, also removed the `CancellationToken` parameter.

- TrackedFile
  - Modified constructor to accept an **AppendBlobClient** parameter instead of `CloudAppendBlob`
