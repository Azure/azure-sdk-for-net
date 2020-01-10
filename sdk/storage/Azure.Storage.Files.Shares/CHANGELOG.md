# Release History

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
