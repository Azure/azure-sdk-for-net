# Release History

## 12.1.1 (2020-01)
 - Fixed issue where SAS content headers were not URL encoded when using QueueSasBuilder.
 - Fixed bug where using SAS connection string from portal would throw an exception if it included
   table endpoint.

## 12.1.0
- Added check to enforce TokenCredential is used only over HTTPS
- Support using SAS token from connection string
- Fixed issue where AccountName on QueueUriBuilder would not be populated
  for non-IP style Uris.

## 12.0.0 (2019-11)
- Renamed a number of operations and models to better align with other client
  libraries and the .NET Framework Design Guidelines

## 12.0.0-preview.4 (2019-10)
- Support for geo-redundant read from secondary location on failure
- Verification of echoed client request IDs
- Added convenient resource Name properties on all clients

## 12.0.0-preview.3 (2019-09)
- Added QueueUriBuilder for addressing Azure Storage resources
- Bug fixes

For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 (2019-08)
- Distributed Tracing
- Bug fixes

## 12.0.0-preview.1 (2019-07)
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
