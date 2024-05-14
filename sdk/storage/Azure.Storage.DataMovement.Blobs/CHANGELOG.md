# Release History

## 12.0.0-beta.5 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
