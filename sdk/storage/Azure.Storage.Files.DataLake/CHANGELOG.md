# Release History

## 12.4.0-preview.1 (Unreleased)

## 12.3.1 (2020-08-18)
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.3.0 (2020-08-13)
- Includes all features from 12.3.0-preview.1 through 12.3.0-preview.2.
- Fixed bug where DataLakeFileSystemClient.SetAccessPolicy() sends DateTimeOffset.MinValue when StartsOn and ExpiresOn when not set in DataLakeAccessPolicy
- Added nullable properties, PolicyStartsOn and PolicyExpiresOn to DataLakeAccessPolicy
- Added DataLakeFileClient.OpenWrite().

## 12.3.0-preview.2 (2020-07-27)
- Fixed bug where DataLakeUriBuilder would return LastDirectoryOrFileName and DirectoryOrFilePath URL-encoded.
- Updated DataLakeSasBuilder to correctly order raw string permissions and make the permissions lowercase.
- Fixed bug where DataLakeFileClient.Query() failed when query response was > ~200 MB.
- Added DataLakeFileClient.OpenRead().
- Fixed bug where DataLakeFileClient.Query() would buffer the query response before parsing the Avro contents.

## 12.3.0-preview.1 (2020-07-03)
- Added support for service version 2019-12-12.
- Added support for Jumbo Files.
- Fixed bug where DataLakeFileClient, DataLakeDirectoryClient, and DataLakePathClient.Name and .Path were sometimes URL-encoded.
- Fixed bug where DataLakeDirectoryClient.GetSubDirectory(), GetFile(), CreateSubDirectory(), and CreateFile() were returning clients with an incorrect URI.

## 12.2.2 (2020-06)
- This release contains bug fixes to improve quality.

## 12.2.1 (2020-06)
- Fixed bug where download could hang indefinietly on .NET Framework

## 12.2.0 (2020-05)
- Added DataLakeFileClient.Upload() overload that allows setting metadata, permissions and umask.
- Fixed bug where PathClient.Rename() was not functioning correctly with SAS.
- Added DataLakeFileSystemClient.GetPathClient().
- Fixed bug where data lake errors weren't parsed correctly.

## 12.1.0 (2020-04)
- Fixed bug where DataLakeFileSystemClient.DeleteIfExistsAsync() would throw an exception if the underlying File System did not exist.
- Added PathProperties.IsDirectory
- Fixed bug where DataLakeFileClient.Read() would throw an exception when download an empty File.

## 12.0.0 (2020-03)
- Added DataLakeFileClient.Upload(), which creates a file, appends data to it, and flushes the file in one user-facing API call.
- Added Exists(), CreateIfNotExists(), and DeleteIfExists() to DataLakeFileSystemClient, DataLakePathClient, DataLakeDirectoryClient, and DataLakeFileClient.
- Made PathClient.Create() and .CreateAsync() public.
- Removed DataLakeFileClient.GetRootDirectory().

## 12.0.0-preview.9
- Added support for service version 2019-07-07.
- Added DataLakeFileClient.ReadTo() and .ReadToAsync() APIs, providing support for parallel downloads to Stream and Files.
- Added progress reporting to DataLakeFileClient.Append() and .AppendAsync().
- Added DataLakeFileSystemClient.GetRootDirectoryClient().
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
