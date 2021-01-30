# Release History

## 12.7.0-beta.1 (Unreleased)


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
