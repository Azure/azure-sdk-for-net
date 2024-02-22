# Release History

## 12.18.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed
- Fixed bug where on `ShareDirectoryClient` and `ShareFileClient`, calling `.Rename(..)` will throw a 403 Authentication Error, if the source storage client was instantiated with a SAS on the `Uri`, will not pass the SAS to the destination client, when the destination does not have any credentials.

### Other Changes

## 12.18.0-beta.1 (2023-12-05)
- Added support for service version 2024-02-04.

## 12.17.1 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.17.0 (2023-11-06)
- Includes all features from 12.17.0-beta.1.
- Fixed bug where the x-ms-file-request-intent request header was not being sent for ShareFileClient.UploadRangeFromUri() and .UploadRangeFromUriAsync().

## 12.17.0-beta.1 (2023-10-16)
- Added support for service version 2023-11-03.
- Added support for ShareClientOptions.Audience

## 12.16.0 (2023-09-12)
- Includes all features from 12.16.0-beta.1.

## 12.16.0-beta.1 (2023-08-08)
- Added support for service version 2023-05-03 and 2023-08-03.

## 12.15.0 (2023-07-23)
- Includes all features from 12.15.0-beta.1.

## 12.15.0-beta.1 (2023-05-30)
- Added support for service version 2023-01-03.
- Added AccessRights property to ShareFileHandle.

## 12.14.0 (2023-04-11)
- Includes all features from 12.14.0-beta.1.

## 12.14.0-beta.1 (2023-03-28)
- Added support for service version 2022-11-02.
- Added support OAuth.
- Added support for Trailing Dot.

## 12.13.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.13.0 (2023-02-21)
- Includes all features from 12.13.0-beta.1.

## 12.13.0-beta.1 (2023-02-07)
- Added support for service version 2021-12-02.
- Added support for invalid XML characters in file and directory names for ShareDirectoryClient.GetfilesAndDirectories(), .GetHandles(), and ShareFileClient.GetHandles().

## 12.12.1 (2022-10-25)
- Fixed bug where ShareFileClient Download() and DownloadAsync() would return a consumed stream when TransferValidation was enabled.

## 12.12.0 (2022-10-12)
- Includes all features from 12.12.0-beta.1.
- Added support for StorageTransferOptions on ShareFile upload (concurrency not supported).

## 12.12.0-beta.1 (2022-08-23)
- Added support for service version 2021-10-04.
- Added support for SDK-calculated transactional checksums on data transfer.
- Fixed bug where ShareClient.GetParentServiceClient() persisted the filesystem name in the URL of the returned ShareServiceClient

## 12.11.0 (2022-07-07)
- Includes all features from 12.11.0-beta.1.
- Fixed bug where ShareFileClient and ShareDirectoryClient Rename() was not passing the AzureSasCredential to the source.

## 12.11.0-beta.1 (2022-06-15)
- Added support for service version 2021-08-06.
- Added ability to set file change time with ShareFileClient.StartCopy() and .StartCopyAsync().

## 12.10.0 (2022-05-02)
- Includes all features from 12.10.0-beta.1.

## 12.10.0-beta.1 (2022-04-12)
- Added support for service version 2021-06-08.
- Added ability to maintain a file's current LastWrittenOn time when calling ShareFileClient.PutRange(), .PutRangeAsync(), .PutRangeFromUri(), and .PutRangeFromUriAsync().
- Added ability to specify a file or directory's ChangedOn time when calling ShareFileClient/ShareDirectoryClient.Create(), .CreateAsync(), .SetProperties(), .SetPropertiesAsync(), .Rename(), and .RenameAsync().
- Added ability to specify Content-Type on a file when calling ShareFileClient.Rename(), .RenameAsync().

## 12.9.0 (2022-03-10)
- Includes all features from 12.9.0-beta.1, 12.9.0-beta.2, and 12.9.0-beta.3 except SDK-calculated transactional checksums on data transfer.
- Fixed bug where ShareFileClient.StartCopy() and .StartCopyAsync() were not sending the ignoreReadonly parameter correctly.
- Added new overload of ShareFileClient.StartCopy() and .StartCopyAsync(), added new parameters allowing the copying of the source file's CreatedOn, LastWrittenOn, and FileAttributes properties.
- Removed preview support for SDK-calculated transactional checksums on data transfer.
- Fixed bug where ShareUriBuilder was case sensitive for parameter names.

## 12.9.0-beta.3 (2022-02-07)
- Added support for service version 2021-04-10.
- Added support for ShareDirectoryClient.Rename() and ShareFileClient.Rename().
- Fixed a memory leak in ShareFileClient.UploadAsync().

## 12.9.0-beta.2 (2021-11-30)
- Added support for service version 2021-02-12.
- Added support for premium file share ProvisionedBandwidthMiBps property.

## 12.9.0-beta.1 (2021-11-03)
- Added support for service version 2020-12-06.
- Added support for SDK-calculated transactional hash checksums on data transfer.
- Fixed bug / regression where the ETag values that had quotation marks surrounding it were being removed starting in version 12.7.0.

## 12.8.0 (2021-09-08)
- Includes all features from 12.8.0-beta.1 and 12.8.0-beta.2.

## 12.8.0-beta.2 (2021-07-23)
- This release contains bug fixes to improve quality.

## 12.8.0-beta.1 (2021-07-22)
- Added support for service version 2020-10-02.
- Added support for OAuth copy sources in ShareFileClient.UploadRangeFromUri()
- Added support for including additional information in ShareDirectoryClient.GetFilesAndDirectories().
- Fixed bug where ShareDirectoryClient.SetMetadataAsync() would not property parse Last-Modified response header.
- Fixed bug where ShareFileClient.DownloadAsync() would fail downloading zero-length file.

## 12.7.0 (2021-06-08)
- Includes all features from 12.7.0-beta.4.
- Fixed bug where specifying conditions in ShareFileClient.OpenRead could override allowModifications flag in ShareFileOpenReadOptions leading to inconsistent read.
- Fixed bug where retry during streaming of ShareFileClient.Download result could lead to inconsistent read.
- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.

## 12.6.2 (2021-05-20)
- This release contains bug fixes to improve quality.

## 12.7.0-beta.4 (2021-05-12)
- Added support for service version 2020-08-04.
- Added support for Share and Share Snapshot Lease.
- ShareLeaseClient now remembers the Lease ID after a lease change.
- Fixed bug where clients would sometimes throw a NullReferenceException when calling GenerateSas() with a ShareSasBuilder parameter.
- Deprecated property ShareSasBuilder.Version, so when generating SAS will always use the latest Storage Service SAS version.

## 12.7.0-beta.3 (2021-04-09)
- This release contains bug fixes to improve quality.

## 12.6.1 (2021-03-29)
- Fixed bug where ClientDiagnostics's DiagnosticListener was leaking resources.

## 12.7.0-beta.2 (2021-03-09)
- This release contains bug fixes to improve quality.

## 12.7.0-beta.1 (2021-02-09)
- Added support for service version 2020-06-12.
- Fixed bug where ShareFileClient.CanGenerateSasUri, ShareDirectoryClient.CanGenerateSasUri, ShareClient.CanGenerateSasUri, ShareServiceClient.CanGenerateSasUri was not mockable

## 12.6.0 (2021-01-12)
- Includes all features from 12.5.6-beta.1
- Fixed bug where the Stream returned by ShareFileClient.OpenRead() would return a different Length after calls to Seek().
- Added support for AzureSasCredential. That allows SAS rotation for long living clients.

## 12.6.0-beta.1 (2020-12-07)
- Added support for service version 2020-04-08.
- Added support for Share Enabled Protocol and Share Squash Root.
- Fixed bug where ShareServiceClient.GetShareClient(), ShareClient.GetDirectoryClient(), ShareClient.GetRootDirectoryClient(), ShareClient.WithSnapshot(), ShareDirectoryClient.GetSubDirectoryClient() and ShareDirectoryClient.GetFileClient() created clients that could not generate a SAS from clients that could generate a SAS

## 12.5.0 (2020-11-10)
- Includes all features from 12.5.0-preview.1
- Fixed bug where ShareDirectoryClient.Exists(), .DeleteIfExists() and ShareFileClient.Exists(), .DeleteIfExists() would thrown an exception when the directory or file's parent directory didn't exist.
- Renamed ShareClient.SetTier() -> ShareClient.SetProperties().  SetProperties() can be used to set both Share Tier and Share Quota.
- Changed ShareDeleteOptions.IncludeSnapshots -> .ShareSnapshotsDeleteOption, and added option to also delete Share Snapshots that have been leased.
- Added additional info to exception messages.
- Removed ability to create a ShareLeaseClient for a Share or Share Snapshot.  This feature has been rescheduled for future release.
- Fixed bug where File Share SDK coudn't handle SASs with start and expiry time in format other than yyyy-MM-ddTHH:mm:ssZ.
- Added ability to set Position on streams created with ShareFileClient.OpenRead().
- Added CanGenerateSasUri property and GenerateSasUri() to ShareFileClient, ShareDirectoryClient and ShareClient.
- Added CanGenerateSasUri property and GenerateAccountSasUri() to ShareServiceClient.
- Changed default constructor for FileSmbProperties from internal to public.

## 12.5.0-preview.1 (2020-09-30)
- Added support for service version 2020-02-10.
- Added support for 4 TB files.
- Added support for SMB Multichannel.
- Added support for Share and Share Snapshot Leases.
- Added support for Get File Range Diff.
- Added support for Set Share Tier.
- Fixed bug where Stream returned from ShareFileClient.OpenWrite() did not flush while disposing preventing compatibility with using keyword.
- Fixed bug where ShareAccessPolicy.StartsOn and .ExpiresOn would cause the process to crash.
- Added seekability to ShareFileClient.OpenRead().

## 12.4.0 (2020-08-31)
- Fixed bug where ShareFileClient.Upload() and .UploadRange() would deadlock if the content stream's position was not zero.
- Fixed bug in ShareFileClient.OpenRead() causing us to do more download called than necessary.
- Fixed bug where ShareClient.Delete() could not delete Share Snapshots unless the includeSnapshots parameter was set to false.

## 12.3.1 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.3.0 (2020-08-13)
- Includes all features from 12.3.0-preview.1 through 12.3.0-preview.2.
- Fixed bug where ShareClient.SetAccessPolicy() sends DateTimeOffset.MinValue when StartsOn and ExpiresOn when not set in ShareAccessPolicy
- Added nullable properties, PolicyStartsOn and PolicyExpiresOn to ShareAccessPolicy
- Added ShareFileClient.OpenWrite().

## 12.3.0-preview.2 (2020-07-27)
- Fixed bug where ShareUriBuilder would return LastDirectoryOrFileName and DirectoryOrFilePath URL-encoded.
- Updated ShareSasBuilder to correctly order raw string permissions and make the permissions lowercase.
- Added ShareFileClient.OpenRead().
- Fixed bug where in ShareFileClient.Upload(), all exceptions except for LeaseNotPresentWithFileOperation were not being thrown.

## 12.3.0-preview.1 (2020-07-03)
- Added support for service version 2019-12-12.
- Added support for Large Files.
- Added support for File Soft Delete.
- Fixed bug where ShareDirectoryClient and ShareFileClient.Name and .Path were sometimes URL-encoded.
- Fixed bug where ShareClient.WithSnapshot(), ShareDirectoryClient.WithSnapshot(), and ShareFileClient.WithSnapshot() were not functioning correctly.

## 12.2.3 
- This release contains bug fixes to improve quality.

## 12.2.2 
- Fixed bug where copy from URL did not handle non-ASCII characters correctly
- Fixed bug where download could hang indefinietly on .NET Framework

## 12.2.1 
- Fixed bug where blob, file and directory names were not URL encoded.

## 12.2.0 
- Added Exists() and DeleteIfExists() to ShareClient, ShareDirectoryClient, and ShareFileClient.
- Added CreateIfNotExists() to ShareClient and ShareDirectoryClient.

## 12.1.0 
- Added support for service version 2019-07-07.
- Added support for file leases.
- Added FailedHandlesCount to CloseHandlesResult.
- Added SMB parameters to File Copy APIs.
- Added premium file share properties.
- Added ShareFileClient.ClearRangesAsync() API.
- Fixed issue where SAS didn't work with signed identifiers.
- Sanitized header values in exceptions.

## 12.0.1 
 - Fixed issue where SAS content headers were not URL encoded when using ShareSasBuilder.
 - Fixed bug where using SAS connection string from portal would throw an exception if it included
   table endpoint.

## 12.0.0 
- Added check to enforce TokenCredential is used only over HTTPS
- Support using SAS token from connection string
- Updated ShareFileRangeInfo to use HttpRange
- Update return types of ForceCloseAllHandles/ForceCloseHandle to be CloseHandlesResult
  and Response<CloseHandlesResult>, respectively
- Fixed issue where AccountName on ShareUriBuilder would not be populated
  for non-IP style Uris.

## 12.0.0-preview.5 
- Renamed Azure.Storage.Files to Azure.Storage.Files.Shares to better align
  with the newly released Azure.Storage.Files.DataLake and provide a consistent
  set of APIs for working with files on Azure

## 12.0.0-preview.4 
- Added FileClient.PutRangeFromUri operation
- Verification of echoed client request IDs
- Added convenient resource Name properties on all clients

## 12.0.0-preview.3 
- New Storage features for service version 2019-02-02 (including new APIs that
  expose all SMB features)
- Added FileClient.Upload convenience helper to support arbitrarily large files
- Added FileUriBuilder for addressing Azure Storage resources

- For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 
- Distributed Tracing
- Bug fixes

## 12.0.0-preview.1 
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
