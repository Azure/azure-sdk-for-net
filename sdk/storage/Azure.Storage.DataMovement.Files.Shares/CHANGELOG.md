# Release History

## 12.3.0-beta.1 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Resolved memory leak issue with `CancellationTokenSource` usage not being properly disposed, namely in the following areas:
    - `TransferOperation` disposes the `CancellationTokenSource` after transfer reaches a `Completed` or `Paused` state
    - `TransferManager` uses a `CancellationTokenSource` also does not link the`CancellationToken` passed to it's methods
    - Removed usage of `CancellationTokenSource` from handling the chunking of large transfers. This only affects transfers that cannot be completed in one request.
- Fixed bug where cached referenced `TransferOperation`s from the `TransferManager` were not being cleared on dispose.
- Fixed bug where referenced `TransferOperation` from the transfers stored in the `TransferManager` after they reach a `Completed` or `Paused` state where not being removed.

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
- Added support for preserving NFS properties and permissions in Share Files and Share Directories for Share-to-Share copy transfers.
- Added support for preserving SMB properties and permissions in Share Directories for Share-to-Share copy transfers.
- Added basic support for handling hard links and soft links in NFS Share-to-Share copy and Share-to-local download transfers.

### Breaking Changes
- Added protocol validation for Share-to-Share copy transfers. Validation is enabled by default and will fail the transfer if there are no share-level permissions. To bypass this, please enable `SkipProtocolValidation`.

## 12.1.0 (2025-02-27)

### Features added
- Added support for anonymous access by adding a default constructor for `ShareFilesStorageResourceProvider`.

### Bugs Fixed
- Fixed an issue that would prevent transfers of large files (>200 GiB) for certain destination resource types.

## 12.0.0 (2025-02-11)

### Breaking Changes
- Changed `ShareFileStorangeResourceOptions.FilePermissions` from `DataTransferProperty` to `bool?`
- Changed the following types from `DataTranferProperty<string>` to `string`
    - `ShareFileStorageResourceOptions.ContentType`
    - `ShareFileStorageResourceOptions.ContentDisposition`
    - `ShareFileStorageResourceOptions.CacheControl`
- Changed the following types from `DataTransferProperty<string[]>` to `string[]`
    - `ShareFileStorageResourceOptions.ContentEncoding`
    - `ShareFileStorageResourceOptions.ContentLanguage`
- Changed the following types from `DataTransferProperty<IDictionary<string, string>>` to `IDictionary<string, string>`
    - `ShareFileStorageResourceOptions.FileMetadata`
    - `ShareFileStorageResourceOptions.DirectoryMetadata`
- Changed the following types from `DataTransferProperty<DateTimeOffset?>` to `DateTimeOffset?`
    -  `ShareFileStorageResourceOptions.FileCreatedOn`
     - `ShareFileStorageResourceOptions.FileLastWrittenOn`
     - `ShareFileStorageResourceOptions.FileChangedOn`
- Changed `ShareDirectoryClient.StartUploadDirectoryAsync` to `ShareDirectoryClient.UploadDirectoryAsync` and added a required `waitUntil` parameter.
- Changed `ShareDirectoryClient.StartDownloadToDirectoryAsync` to `ShareDirectoryClient.DownloadToDirectoryAsync` and added a required `waitUntil` parameter.
- Several refactors to `ShareFilesStorageResourceProvider`:
  - Removed nested delegates `GetStorageSharedKeyCredential`, `GetTokenCredential`, and `GetAzureSasCredential`.
  - Removed default constructor.
  - Removed constructor overload for `GetTokenCredential` entirely.
  - Changed constructor overloads for `GetStorageSharedKeyCredential` and `GetAzureSasCredential` to use `Func`. These callbacks are also now async, returning a `ValueTask`, and the `readOnly` parameter was removed.
  - Changed `FromFile` and `FromDirectory` to async, returning a `ValueTask`, and renamed to `FromFileAsync` and `FromDirectoryAsync` respectively.
  - Changed `FromClient` methods to `static` methods.

### Bugs Fixed
- Fixed File Attributes with ReadOnly does not transfer / copy correctly bug #2167

## 12.0.0-beta.3 (2024-10-14)

### Breaking Changes
- Changed `FromDirectory(string directoryUri, ShareFileStorageResourceOptions options = default)` to `FromDirectory(Uri directoryUri, ShareFileStorageResourceOptions options = default)`
- Changed `FromFile(string fileUri, ShareFileStorageResourceOptions options = default)` to `FromFile(Uri fileUri, ShareFileStorageResourceOptions options = default)`

### Bugs Fixed
- Fixed bug where copying a Azure Storage Blob to a Share File would not be able to convert Content Language and Content Encoding to the `string[]` type.
- Fixed bug where LastWrittenOn property was not being preserved when copying a Share File to another Share File.

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.0.0-beta.2 (2024-07-16)

### Features Added
- Improved upload and copying chunking strategy for large Share Files to improve speed
- Added ability to preserve Share File Metadata, properties, and Permissions on Share File to Share File copy.

### Breaking Changes
  - Removed `DownloadTransferValidationOptions` and `UploadTransferValidationOptions` from `ShareFileStorageResourceOptions`.
  - Removed `ShareFileStorageResourceOptions.SmbProperties`, use the following instead:
      - `ShareFileStorageResourceOptions.FilePermissionKey`
      - `ShareFileStorageResourceOptions.FileAttributes`
      - `ShareFileStorageResourceOptions.FileCreatedOn`
      - `ShareFileStorageResourceOptions.FileLastWrittenOn`
      - `ShareFileStorageResourceOptions.FileChangedOn`
  - Removed `ShareFileStorageResourceOptions.HttpHeaders`, use the following instead:
      - `ShareFileStorageResourceOptions.ContentType`
      - `ShareFileStorageResourceOptions.ContentLanguage`
      - `ShareFileStorageResourceOptions.ContentEncoding`
      - `ShareFileStorageResourceOptions.ContentDisposition`
      - `ShareFileStorageResourceOptions.CacheControl`
  - Changed `ShareFileStorageResourceOptions.FileMetadata` and `DirectoryMetadata` to be wrapped by `DataTransferProperty` type to allow preserving.
  - Removed `ShareFileStorageResourceOptions.FilePermissionKey` and `FilePermissions` use `ShareFileStorageResourceOptions.FilePermissions` instead.`

## 12.0.0-beta.1 (2023-12-05)

- This preview is the first release of a ground-up rewrite of our client data movement
libraries (for Share Files support) to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

- For known issues and limitations, see https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/KnownIssues.md.

- For Azure SDK lifecycle and support policy, see https://azure.github.io/azure-sdk/policies_support.html.
