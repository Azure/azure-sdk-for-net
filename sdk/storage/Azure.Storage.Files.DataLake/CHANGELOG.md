# Release History

## 12.0.0-preview.9
- Added support for service version 2019-07-07.
- Added DataLakeFileClient.ReadTo() and .ReadToAsync() APIs, providing support for parallel downloads to Stream and Files.
- Added progress reporting to DataLakeFileClient.Append() and .AppendAsync().
- Added DataLakeFileSysteClient.GetRootDirectoryClient().
- Fixed issue where SAS didn't work with signed identifiers.
- Renamed LeaseDurationType, LeaseState, and LeaseStatus to DataLakeLeaseDuration, DataLakeLeaseState, and DataLakeLeaseStatus
- Sanitized header values in exceptions.

## 12.0.0-preview.8
 - Fixed issue where SAS content headers were not URL encoded when using DataLakeSasBuilder.
 - Fixed issue where certain query parameters were not being logged.

## 12.0.0-preview.7
- Added check to enforce TokenCredential is used only over HTTPS
- Enabled diagnostic tracing
- Added FileSystemClient.GetAccessPolicy and SetAccessPolicy
- Added Path property to DataLakePathClient
- Renamed DataLakeFileSystemClient.ListPaths to GetPaths
- Added PathPermissions and PathAccessControlEntry

## 12.0.0-preview.6 (2019-11)
This preview is the first release supporting DataLake for Azure
Data Lake Gen 2.
