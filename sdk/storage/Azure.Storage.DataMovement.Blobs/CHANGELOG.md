# Release History

## 12.0.0-beta.3 (Unreleased)

### Features Added
- Added `ResourceOptions` to `BlobStorageResourceContainerOptions` which allows setting resource specific options on all resources in a container transfer.

### Breaking Changes
- Removed `Traits` and `States` from `BlobStorageResourceContainerOptions`.
- Removed `CopyMethod` from `BlobStorageResourceContainerOptions`. Use `ResouceOptions.CopyMethod` now.

### Bugs Fixed
- Fixed bug where the extension methods `BlobContainerClient.StartUploadDirectoryAsync` and `StartDownloadToDirectoryAsync` throws an exception when attempting to lazy construct the `TransferManager`.

### Other Changes

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
