# Release History

## 12.0.0-beta.4 (Unreleased)

### Features Added

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

### Bugs Fixed

### Other Changes

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
