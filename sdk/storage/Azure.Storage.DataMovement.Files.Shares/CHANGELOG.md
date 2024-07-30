# Release History

## 12.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

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
