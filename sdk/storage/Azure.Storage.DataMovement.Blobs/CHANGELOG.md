# Release History

## 12.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 12.2.2 (2025-09-10)

### Bugs Fixed
- Fixed an issue on upload transfers where file/directory names on the destination may be incorrect. The issue could occur if the path passed to `LocalFilesStorageResourceProvider.FromDirectory` contained a trailing slash.

## 12.2.1 (2025-08-06)

### Bugs Fixed
- Fixed an issue that could cause an exception when trying to resume a transfer that contained resources with special characters in the name.

## 12.2.0 (2025-07-21)

### Features Added
- Includes all features from 12.2.0-beta.1

### Bugs Fixed
- Fixed an issue with Copy transfers where if the source file/directory name contained certain special characters, the destination file name would incorrectly contain the encoded version of these characters.
- Fixed an issue with Upload transfers where file/directory names containing certain URL-encoded characters could cause the transfer to fail.


## 12.2.0-beta.1 (2025-06-17)

### Features Added
- Explicitly setting `BlobStorageResourceOptions.AccessTier` to `null` will disable preserving the access tier value from the source blob to the destination blob.

### Bugs Fixed
- Fixed bug where AccessTier for Premium Page Blobs were not being preserved.
- Fixed some issues when transferring virtual directories with Blob Storage as the source.

## 12.1.0 (2025-02-27)

### Features Added
- Added support for anonymous access by adding a default constructor for `BlobsStorageResourceProvider`.

### Bugs Fixed
- Fixed an issue that would prevent transfers of large files (>200 GiB) for certain destination resource types.

## 12.0.0 (2025-02-11)

### Breaking Changes
- Changed `BlobStorageResourceContainerOptions.BlobType` type from `DataTransferProperty<BlobType>` to `BlobType`
- Changed `BlobStorageResourceOptions.Metadata` type from `DataTransferProperty<IDictionary<string, string>>` to `IDictionary<string, string>`
- Changed the following types from `DataTranferProperty<string>` to `string`
    - `BlobStorageResourceOptions.ContentType`
    - `BlobStorageResourceOptions.ContentLanguage`
    - `BlobStorageResourceOptions.ContentEncoding`
    - `BlobStorageResourceOptions.ContentDisposition`
    - `BlobStorageResourceOptions.CacheControl`
- Renamed `BlobStorageResourceContainerOptions.BlobDirectoryPrefix` to `BlobPrefix`
- Changed `BlobContainerClient.StartUploadDirectoryAsync` to `BlobContainerClient.UploadDirectoryAsync` and added a required `waitUntil` parameter.
- Changed `BlobContainerClient.StartDownloadToDirectoryAsync` to `BlobContainerClient.DownloadToDirectoryAsync` and added a required `waitUntil` parameter.
- Several refactors to `BlobsStorageResourceProvider`:
  - Removed nested delegates `GetStorageSharedKeyCredential`, `GetTokenCredential`, and `GetAzureSasCredential`.
  - Removed default constructor.
  - Removed constructor overload for `GetTokenCredential` entirely.
  - Changed constructor overloads for `GetStorageSharedKeyCredential` and `GetAzureSasCredential` to use `Func`. These callbacks are also now async, returning a `ValueTask`, and the `readOnly` parameter was removed.
  - Changed `FromBlob` and `FromContainer` to async, returning a `ValueTask`, and renamed to `FromBlobAsync` and `FromContainerAsync` respectively.
  - Changed `FromClient` methods to `static` methods.

## 12.0.0-beta.6 (2024-10-14)

### Breaking Changes
- Changed `FromContainer(string containerUri, BlobStorageResourceContainerOptions options = default)` to `FromContainer(Uri containerUri, BlobStorageResourceContainerOptions options = default)`
- Changed `FromBlob(string blobUri, BlobStorageResourceOptions options = default)` to `FromBlob(Uri blobUri, BlobStorageResourceOptions options = default)`

### Bugs Fixed
- Fixed bug where using OAuth would not preserve source properties to destination properties.

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.0.0-beta.5 (2024-07-16)

### Features Added
- Added ability to preserve Blob Metadata and properties on Blob to Blob copy.
- Added ability to preserve Blob Type on Blob Container to Blob Container copy.

### Breaking Changes
- Changed `BlobStorageResourceOptions` members to be wrapped by `DataTransferProperty` type to allow preserving. The following members are affected:
    - `BlobStorageResourceOptions.ContentType`
    - `BlobStorageResourceOptions.ContentLanguage`
    - `BlobStorageResourceOptions.ContentEncoding`
    - `BlobStorageResourceOptions.ContentDisposition`
    - `BlobStorageResourceOptions.CacheControl`
    - `BlobStorageResourceOptions.Metadata`
- Changed `BlobStorageResourceContainerOptions.BlobType` from `Azure.Storage.Blobs.Models.BlobType` to `DataTransferProperty<Azure.Storage.Blobs.Models.BlobType>`

## 12.0.0-beta.4 (2023-12-05)

### Breaking Changes
- [BREAKING CHANGE] Removed `BlobStorageResourceProvider.MakeResourceAsync`. Instead use the appropriate `BlobStorageResourceProvider` constructor to pass credentials, and `.FromBlob()`, `.FromContainer()`, and `.FromClient()` to obtain a Blob `StorageResource`.
- [BREAKING CHANGE] Renamed `BlobStorageResourceContainerOptions.DirectoryPrefix` to `BlobDirectoryPrefix`
- [BREAKING CHANGE] Renamed `BlobStorageResourceContainerOptions.ResourceOptions` to `BlobOptions`
- [BREAKING CHANGE] Moved `BlobContainerClientTransferOptions` to the `Azure.Storage.DataMovement.Blobs` namespace
- [BREAKING CHANGE] Removed `position` parameter from `*BlobStorageResource.WriteFromStreamAsync`. Use `StorageResourceWriteToOffsetOptions.Position` instead.
- [BREAKING CHANGE] Made parameter `completeLength` from `*BlobStorageResource.CopyBlockFromUriAsync` mandatory.
- [BREAKING CHANGE] Removed `StorageResource.CanProduceUri` (including it's derived classes).
- [BREAKING CHANGE] Removed `StorageResource.Path`, use `StorageResource.Uri` instead.
- [BREAKING CHANGE] Removed `DestinationImmutabilityPolicy`, `LegalHold`, `UploadTransferValidationOptions`, and `DownloadTransferValidationOptions` from `BlobStorageResourceOptions` as they were not fully supported.
- [BREAKING CHANGE] Made the following from `public` to `internal` (Use `BlobStorageResourceProvider` instead to create `StorageResource`s):
    - `AppendBlobStorageResource`
    - `BlockBlobStorageResource`
    - `PageBlobStorageResource`
    - `BlobStorageResourceContainer`

## 12.0.0-beta.3 (2023-07-11)

### Features Added
- Added `ResourceOptions` to `BlobStorageResourceContainerOptions` which allows setting resource specific options on all resources in a container transfer.
- Added support authorization using Azure Active Directory when using Service to Service Copy.

### Breaking Changes
- [Breaking Change] Removed several options from `BlobStorageResourceContainerOptions`.
- [Breaking Change] Removed several options from `BlockBlobStorageResourceOptions`, `AppendBlobStorageResourceOptions`, and `PageBlobStorageResourceOptions`.

### Bugs Fixed
- Fixed bug where the extension methods `BlobContainerClient.StartUploadDirectoryAsync` and `StartDownloadToDirectoryAsync` throws an exception when attempting to lazy construct the `TransferManager`.

## 12.0.0-beta.2 (2023-04-26)
- This release contains bug fixes to improve quality.
- Added option to `BlobStorageResourceContainerOptions` to choose `BlobType` when uploading blobs.
- Added the following extension methods to upload and download blob virtual directories using the `BlobContainerClient`:
    - `BlobContainerClient.StartDownloadToDirectoryAsync`
    - `BlobContainerClient.StartUploadDirectoryAsync`

## 12.0.0-beta.1 (2022-12-15)
- This preview is the first release of a ground-up rewrite of our client data movement
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
