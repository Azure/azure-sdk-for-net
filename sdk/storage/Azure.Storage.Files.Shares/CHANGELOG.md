# Release History

## 12.3.0-preview.1 (2020-07-02)
- Added support for service version 2019-12-12.
- Added support for Large Files.
- Added support for File Soft Delete.
- Fixed bug where ShareDirectoryClient and ShareFileClient.Name and .Path were sometimes URL-encoded.
- Fixed bug where ShareClient.WithSnapshot(), ShareDirectoryClient.WithSnapshot(), and ShareFileClient.WithSnapshot() were not functioning correctly.

## 12.2.3 (2020-06)
- This release contains bug fixes to improve quality.

## 12.2.2 (2020-06)
- Fixed bug where copy from URL did not handle non-ASCII characters correctly
- Fixed bug where download could hang indefinietly on .NET Framework

## 12.2.1 (2020-05)
- Fixed bug where blob, file and directory names were not URL encoded.

## 12.2.0 (2020-03)
- Added Exists() and DeleteIfExists() to ShareClient, ShareDirectoryClient, and ShareFileClient.
- Added CreateIfNotExists() to ShareClient and ShareDirectoryClient.

## 12.1.0 (2020-02)
- Added support for service version 2019-07-07.
- Added support for file leases.
- Added FailedHandlesCount to CloseHandlesResult.
- Added SMB parameters to File Copy APIs.
- Added premium file share properties.
- Added ShareFileClient.ClearRangesAsync() API.
- Fixed issue where SAS didn't work with signed identifiers.
- Sanitized header values in exceptions.

## 12.0.1 (2020-01)
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

## 12.0.0-preview.5 (2019-11)
- Renamed Azure.Storage.Files to Azure.Storage.Files.Shares to better align
  with the newly released Azure.Storage.Files.DataLake and provide a consistent
  set of APIs for working with files on Azure

## 12.0.0-preview.4 (2019-10)
- Added FileClient.PutRangeFromUri operation
- Verification of echoed client request IDs
- Added convenient resource Name properties on all clients

## 12.0.0-preview.3 (2019-09)
- New Storage features for service version 2019-02-02 (including new APIs that
  expose all SMB features)
- Added FileClient.Upload convenience helper to support arbitrarily large files
- Added FileUriBuilder for addressing Azure Storage resources

- For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 (2019-08)
- Distributed Tracing
- Bug fixes

## 12.0.0-preview.1 (2019-07)
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
