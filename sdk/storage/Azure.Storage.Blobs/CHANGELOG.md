# Release History

## 12.3.0 (2020-02)
- Added support for service version 2019-07-07.
- Added support for Encryption Scopes.
- Modified BlockBlobClient.Upload() and .UploadAsync() to support parallel and multi-part uploads.
- Fixed issue where SAS didn't work with signed identifiers.
- Sanitized header values in exceptions.

## 12.2.0 (2020-01)
 - Added Exists API to BlobBaseClient and BlobContainerClient
 - Fixed issue where SAS content headers were not URL encoded when using BlobSasBuilder.
 - Fixed progress reporting issue for parallel uploads
 - Fixed bug where using SAS connection string from portal would throw an exception if it included
   table endpoint.

## 12.1.0
- Added check to enforce TokenCredential is used only over HTTPS
- Support using SAS token from connection string
- Fixed issue where AccountName on BlobUriBuilder would not be populated
  for non-IP style Uris.

## 12.0.0 (2019-11)
- Renamed a number of operations and models to better align with other client
  libraries and the .NET Framework Design Guidelines
- Parallel upload/download performance improvements

## 12.0.0-preview.4 (2019-10)
- Added support for Customer Provided Key server side encryption
- Verification of echoed client request IDs
- Support for geo-redundant read from secondary location on failure
- Added CreateIfNotExists and DeleteIfNotExists convenience methods for Blobs
- Added convenient resource Name properties on all clients

## 12.0.0-preview.3 (2019-09)
- New Storage features for service version 2019-02-02 (including Customer
  Provided Key, expanded Set Tier support, the ability to set rehydration
  priority, etc.)
- Parallel upload/download
- Added BlobUriBuilder for addressing Azure Storage resources

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
