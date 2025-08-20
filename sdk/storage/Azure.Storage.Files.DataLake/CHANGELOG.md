# Release History

## 12.24.0-beta.1 (Unreleased)

### Features Added
- Added support for service version 2025-11-05.
- Added more useful error message when the SDK encounters an x-ms-version mis-match issue.

## 12.23.0-beta.1 (2025-05-06)

### Features Added
- Added support for service version 2025-07-05.

## 12.22.0 (2025-03-11)

### Features Added
- Includes all features from 12.22.0-beta.1
- Added the following Client Builders: `AddDataLakeServiceClient(Uri, Azure.SasCredential)`, `AddDataLakeServiceClient(Uri, TokenCredential)`

### Bugs Fixed
- Fixed bug where a `DataLakeServiceClient`, `DataLakeFileSystemClient`, `DataLakeDirectoryClient`, `DataLakeFileClient`, `DataLakePathClient` created with a connection string with an account name specified (e.g. "AccountName=..;"), the account name was not populated on the Storage Clients if the account name was not also specified in the endpoint. (#42925)
- Fixed bug where a `DataLakeServiceClient`, `DataLakeFileSystemClient`, `DataLakeDirectoryClient`, `DataLakeFileClient`, `DataLakePathClient` created with a `StorageSharedKeyCredential`, the account name was not populated on the Storage Clients if the account name was not also specified in the endpoint. (#42925)

## 12.22.0-beta.1 (2025-02-11)

### Features Added
- Added support for service version 2025-05-05.

## 12.21.0 (2024-11-12)

### Features Added
- Includes all features from 12.21.0-beta.1 and 12.21.0-beta.2.

## 12.21.0-beta.2 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.20.1 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.21.0-beta.1 (2024-10-08)

### Features Added
- Added support for service version 2025-01-05.
- Added GenerateUserDelegationSasUri() for DataLakePathClient, DataLakeFileSystemClient, and DataLakeDirectoryClient
- Deprecated Read()/ReadAsync() in favor of ReadStreaming()/ReadStreamingAsync() and ReadContent()/ReadContentAsync() for DataLake #45418
- Added GenerateUserDelegationSasUri() to DataLakeFileSystemClient, DataLakePathClient, DataLakeDirectoryClient, and DataLakeFileClient.

## 12.20.0 (2024-09-18)

### Features Added
- Includes all features from 12.20.0-beta.1.

### Bugs Fixed
- Fixed \[BUG\] Method overload DataLakeFileClient.OpenReadAsync()/OpenRead() to correctly handle the allowBlobModifications flag #45516

## 12.20.0-beta.1 (2024-08-06)

### Features Added
- Added support for service version 2024-11-04.
- Added ability to retrieve SAS string to sign for debugging purposes.

## 12.19.1 (2024-07-25)

### Bugs Fixed
- Fixed \[BUG\] Azure Blob Storage Client SDK No Longer Supports Globalization Invariant Mode for Account Key Authentication #45052

## 12.19.0 (2024-07-16)

### Features Added
- Includes all features from 12.19.0-beta.1.

### Bugs Fixed
- Fixed bug where storage clients when constructed with URLs with '#' character would truncate the path at the '#'.

## 12.19.0-beta.1 (2024-06-11)
- Added support for service version 2024-08-04.
- Added more detailed messaging for authorization failure cases.

## 12.18.0 (2024-05-13)
- Includes all features from 12.18.0-beta.1 and 12.18.0-beta.2.
- Fixed bug where `DataLakeFileSystemClient` and `DatalakeFileClient` did not throw an exception on empty/null filesystem names and file names, respectively, when constructing a client.

## 12.18.0-beta.2 (2024-04-15)
- Added support for service version 2024-05-04.
- Added ability to retrieve path ACL with DataLakePath/File/DirectoryClient.GetProperties(), .GetPropertiesAsync(), DataLakeFileClient.Read(), and .ReadAsync().
- Fixed bug where on `DataLakeDirectoryClient`, `DataLakeFileClient` and `DataLakePathClient`, calling `.Rename(..)` will throw a 403 Authentication Error, if the source storage client was instantiated with a SAS on the `Uri`, will not pass the SAS to the destination- Fixed bug where on `ShareDirectoryClient`, `ShareFileClient` and `DataLakePathClient`, calling `.Rename(..)` will throw a 403 Authentication Error, if the source storage client was instantiated with a SAS on the `Uri`, will not pass the SAS to the destination client, when the destination does not have any credentials.

## 12.18.0-beta.1 (2023-12-05)
- Added support for service version 2024-02-04.
- Fixed bug where SAS Directory Depth ("sdd") value 10 or over will add 6 to the sdd value

## 12.17.1 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.17.0 (2023-11-06)
- Includes all features from 12.17.0-beta.1.

## 12.17.0-beta.1 (2023-10-16)
- Added support for service version 2023-11-03.
- Added support for DataLakeClientOptions.Audience

## 12.16.0 (2023-09-12)
- Includes all features from 12.16.0-beta.1.

## 12.16.0-beta.1 (2023-08-08)
- Added support for service version 2023-05-03 and 2023-08-03.
- Added support for paginated directory delete when using AAD authentication.  Note that this feature only applies to HNS storage accounts.

## 12.15.0 (2023-07-11)
- Includes all features from 12.15.0-beta.1.
- Fixed bug where DatalakePathClient.Rename was using the filesystem name parameter for the destination path and vice versa.

## 12.15.0-beta.1 (2023-05-30)
- Added support for service version 2023-01-03.
- Added Owner, Group, and Permissions properties to PathProperties.
- Added EncryptionContext property to DataLakeFileUploadOptions.

## 12.14.0 (2023-04-11)
- Includes all features from 12.14.0-beta.1.

## 12.14.0-beta.1 (2023-03-28)
- Fixed bug where sticky bit and execution bit were not formed and parsed correctly in PathPermissions
- Added support for service version 2022-11-02.
- Added support for Encryption Context.

## 12.13.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.13.0 (2023-02-21)
- Includes all features from 12.13.0-beta.1.
- Added FileDownloadDetails.CreatedOn property.

## 12.13.0-beta.1 (2023-02-07)
- Added support for service version 2021-12-02.
- Added support for leasing operations on DataLakeFileClient.Append(), .AppendAsync(), .Flush(), and .FlushAsync().
- Added support for sticky bit and execution bit to both be set on permissions of a path.

## 12.12.1 (2022-10-13)
- Fixed bug where DataLakeQueryCsvTextOptions was not properly sending the RecordSeparator when calling DataLakeFileClient.Query()

## 12.12.0 (2022-10-12)
- Includes all features from 12.12.0-beta.1.

## 12.12.0-beta.1 (2022-08-23)
- Added support for service version 2021-10-04.
- Added support for SDK-calculated transactional checksums on data transfer.
- Added support for flush parameter to DataLakeFileClient.Append() and .AppendAsync().
- Added support for encryption scopes.
- Added support for encryption scope SAS.
- Fixed bug where DataLakeFileSystemClient.GetParentServiceClient() persisted the filesystem name in the URL of the returned DataLakeServiceClient
- Fixed bug where PathItem.ETag was not being deserialized correctly.

## 12.11.0 (2022-07-07)
- Includes all features from 12.11.0-beta.1.
- Fixed bug where DataLakePathClient.Rename() was not passing the AzureSasCredential to the source.

## 12.11.0-beta.1 (2022-06-15)
- Added support for service version 2021-08-06.
- Added ability to set permission, umask, owner, group, ACL, lease, and expiry time on DataLakeFileClient.Create() and .CreateAsync(), DataLakeDirectoryClient.Create() and .CreateAsync(), and DataLakePathClient.Create() and .CreateAsync().
- Fixed bug where DataLakeDirectoryClient.GetPaths() and DataLakeFileSystemClient.GetPaths() called on a storage account without HNS enabled throws a FormatException when parsing the Date Time.

## 12.10.0 (2022-05-02)
- Includes all features from 12.10.0-beta.1.

## 12.10.0-beta.1 (2022-04-12)
- Added support for service version 2021-06-08.
- Added support for Customer Provided Key server-side encryption of files.
- Added ability to retrieve path CreatedOn and ExpiresOn times with DataLakeFileSystemClient.GetPaths() and .GetPathsAsync().
- Added support for DataLakeFileSystemClient.GetPathClient().

## 12.9.0 (2022-03-10)
- Includes all features from 12.9.0-beta.1, 12.9.0-beta.2, and 12.9.0-beta.3 except SDK-calculated transactional checksums on data transfer.
- Removed preview support for SDK-calculated transactional checksums on data transfer.

## 12.9.0-beta.3 (2022-02-07)
- Added support for service version 2021-04-10.

## 12.9.0-beta.2 (2021-11-30)
- Added supprot for service version 2021-02-12.
- Added support for listing system file systems with DataLakeServiceClient.GetFileSystems() and .GetFileSystemsAsync().

## 12.9.0-beta.1 (2021-11-03)
- Added support for service version 2020-12-06.
- Added support for SDK-calculated transactional hash checksums on data transfer.
- Fixed bug / regression where the ETag values that had quotation marks surrounding it were being removed starting in version 12.7.0.
- Fixed bug where DataLakeUriBuilder incorrectly convert "blob" or "dfs" in the account name in the Uri when attempting to convert the URL to a dfs or blob endpoint.

## 12.8.0 (2021-09-08)
- Includes all features from 12.8.0-beta.1 and 12.8.0-beta.2.

## 12.8.0-beta.2 (2021-07-23)
- This release contains bug fixes to improve quality.

## 12.8.0-beta.1 (2021-07-22)
- Added support for service version 2020-10-02.
- Added support for Parquet as an input format in DataLakeFileClient.Query().
- Added support for RequestConditions parameter validation.  If a request condition is set for an API that doesn't support it, and ArguementException will be thrown.
    - This feature can be disabled with the environment variable "AZURE_STORAGE_DISABLE_REQUEST_CONDITIONS_VALIDATION" or the App Context switch "Azure.Storage.DisableRequestConditionsValidation".

## 12.7.0 (2021-06-08)
- Includes all features from 12.7.0-beta.4
- Fixed bug where DataLakeFileClient.Read could corrupt data on retry.
- Fixed bug where specifying "*" as IfMatch condition could lead to inconsistend read in DataLakeFileClient.ReadTo.
- Fixed bug where specifying conditions in DataLakeFileClient.OpenRead could override allowModifications flag in DataLakeOpenReadOptions leading to inconsistent read.
- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.

## 12.6.2 (2021-05-20)
- This release contains bug fixes to improve quality.

## 12.7.0-beta.4 (2021-05-12)
- Added support for service version 2020-08-04.
- Added support for Soft Delete for Hierarchical-Namespace enabled accounts.
- DataLakeLeaseClient now remembers the Lease ID after a lease change.
- Fixed bug where clients would sometimes throw a NullReferenceException when calling GenerateSas() with a DataLakeSasBuilder parameter.
- Deprecated property DataLakeSasBuilder.Version, so when generating SAS will always use the latest Storage Service SAS version.

## 12.7.0-beta.3 (2021-04-09)
- Aligned storage URL parsing with other platforms.

## 12.6.1 (2021-03-29)
- Fixed bug where ClientDiagnostics's DiagnosticListener was leaking resources.

## 12.7.0-beta.2 (2021-03-09)
- Changed error codes from numerical (404) to descriptive (PathNotFound).

## 12.7.0-beta.1 (2021-02-09)
- Added support for service version 2020-06-12.
- Added support for listing deleted file systems and restoring deleted file systems.
- Fixed bug where DataLakeFileSystemClient.CanGenerateSasUri, DataLakeDirectoryClient.CanGenerateSasUri, DataLakeFileClient.CanGenerateSasUri, DataLakePathClient.CanGenerateSasUri, DataLakeServiceClient.CanGenerateSasUri was not mockable

## 12.6.0 (2021-01-12)
- Includes all features from 12.6.0-beta.1
- Fixed bug where the Stream returned by DataLakeFileClient.OpenRead() would return a different Length after calls to Seek().
- Added constructors taking connection string to DataLakeServiceClient, DataLakeFileSystemClient, DataLakeDirectoryClient, and DataLakeFileClient.
- Fixed bug where DataLakePathClient.SetPermissions(), DataLakeFileClient.SetPermissions(), and DataLakeDirectoryClient.SetPermissions() could not just set Owner or Group.
- Fixed bug where DataLakeDirectoryClient initialized with a Uri would throw a null exception when GetPaths() was called.
- Added support for AzureSasCredential. That allows SAS rotation for long living clients.

## 12.6.0-beta.1 (2020-12-07)
- Added support for service version 2020-04-08.
- Fixed bug where DataLakeServiceClient.GetFileSystemClient(), DataLakeFileSystemClient.GetFileClient(), DataLakeFileSystemClient.GetDirectoryClient(),
DataLakeDirectoryClient.GetSubDirectoryClient() and DataLakeFileClient.GetFileClient() created clients that could not generate a SAS from clients that could generate a SAS.

## 12.5.0 (2020-11-10)
- Includes all features from 12.5.0-preview.1
- Fixed bug where DataLakeFileSystem.SetAccessPolicy() would throw an exception if signed identifier permissions were not in the correct order.
- Added additional info to exception messages.
- Added DataLakeDirectoryClient.GetPaths().
- Fixed bug where Data Lake SDK coudn't handle SASs with start and expiry time in format other than yyyy-MM-ddTHH:mm:ssZ.
- Added ability to set Position on streams created with DataLakeFileClient.OpenRead().
- Added CanGenerateSasUri property and GenerateSasUri() to DataLakePathClient, DataLakeFileClient, DataLakeDirectoryClient and DataLakeFileSystemClient.
- Added CanGenerateAccountSasUri property and GenerateAccountSasUri() to DataLakeServiceClient.
- Restored single upload threshold for parallel uploads from 5 TB to 256 MB.

## 12.5.0-preview.1 (2020-09-30)
- Added support for service version 2020-02-10.
- Added support for Directory SAS.
- Added support for File Set Expiry.
- Fixed bug where Stream returned from DataLakeFileClient.OpenWrite() did not flush while disposing preventing compatibility with using keyword.
- Fixed bug where DataLakeFileClient.Upload() could not upload read-only files.
- Fixed bug where DataLakeBlobAccessPolicy.StartsOn and .ExpiresOn would cause the process to crash.
- Added seekability to DataLakeFileClient.OpenRead().
- Added Close and RetainUncommitedData to DataLakeFileUploadOptions.
- Fixed bug where DataLakeDirectoryClient.Rename(), DataLakeFileClient.Rename(), and DataLakeFileClient.Rename() couldn't handle source paths with special characters.
- Added DataLakeClientBuilderExtensions.

## 12.4.0 (2020-08-31)
- Fixed bug where DataLakeFileClient.Upload() would deadlock if the content stream's position was not 0.
- Fixed bug in DataLakeFileClient.OpenRead() causing us to do more download called than necessary.

## 12.3.1 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

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

## 12.2.2 
- This release contains bug fixes to improve quality.

## 12.2.1 
- Fixed bug where download could hang indefinietly on .NET Framework

## 12.2.0 
- Added DataLakeFileClient.Upload() overload that allows setting metadata, permissions and umask.
- Fixed bug where PathClient.Rename() was not functioning correctly with SAS.
- Added DataLakeFileSystemClient.GetPathClient().
- Fixed bug where data lake errors weren't parsed correctly.

## 12.1.0 
- Fixed bug where DataLakeFileSystemClient.DeleteIfExistsAsync() would throw an exception if the underlying File System did not exist.
- Added PathProperties.IsDirectory
- Fixed bug where DataLakeFileClient.Read() would throw an exception when download an empty File.

## 12.0.0 
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

## 12.0.0-preview.6 
This preview is the first release supporting DataLake for Azure
Data Lake Gen 2.
