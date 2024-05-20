# Release History

## 12.0.0-beta.2 (Unreleased)

### Features Added
- Improved upload and copying chunking strategy for large Share Files to improve speed

### Breaking Changes
  - Removed `DownloadTransferValidationOptions` and `UploadTransferValidationOptions` from `ShareFileStorageResourceOptions`.

### Bugs Fixed

### Other Changes

## 12.0.0-beta.1 (2023-12-05)

- This preview is the first release of a ground-up rewrite of our client data movement
libraries (for Share Files support) to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

- For known issues and limitations, see https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/storage/Azure.Storage.DataMovement/KnownIssues.md.

- For Azure SDK lifecycle and support policy, see https://azure.github.io/azure-sdk/policies_support.html.
