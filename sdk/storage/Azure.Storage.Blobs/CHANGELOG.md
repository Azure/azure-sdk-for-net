# Release History

## 12.6.0 (2020-08-31)
- Fixed bug where BlobClient.Upload(), BlockBlobClient.Upload(), AppendBlobClient.AppendBlock(), and PageBlobClient.UploadPages() would deadlock if the content stream's position was not 0.
- Fixed bug in BlobBaseClient.OpenRead() causing us to do more download called than necessary.
- Fixed bug where PageBlobWriteStream would advance Position 2x the number of written bytes.

## 12.5.1 (2020-08-18)
- Fixed bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 12.5.0 (2020-08-13)
- Includes all features from 12.5.0-preview.1 through 12.5.0-preview.6.
- Added support for custom local emulator hostname for blob storage endpoints.
- Fixed bug where BlobContainerClient.SetAccessPolicy() sends DateTimeOffset.MinValue when StartsOn and ExpiresOn when not set in BlobAccessPolicy
- Added nullable properties, PolicyStartsOn and PolicyExpiresOn to BlobAccessPolicy
- Added BlockBlobClient.OpenWrite(), AppendBlobClient.OpenWrite(), and PageBlobClient.OpenWrite()

## 12.5.0-preview.6 (2020-07-27)
- Fixed bug where BlockBlobClient and PageBlobClient would throw NullReferenceExceptions when using Uri constructor.
- Fixed bug where .WithSnapshot() and .WithVersion() would URL-encode the name of the new clients.
- Updated BlobSasBuilder to correctly order raw string permissions and make the permissions lowercase.
- Fixed bug where BlockBlobClient.Query() failed when query response was > ~200 MB.
- Added BlobBaseClient.OpenRead().
- Fixed bug where BlockBlobClient.Query() would buffer the query response before parsing the Avro contents.

## 12.5.0-preview.5 (2020-07-03)
- Added support for service version 2019-12-12.
- Added support for Blob Tags.
- Added support for Blob Version.
- Added support for Object Replication Service.
- Added support for Append Seal.
- Added support for Jumbo Blobs.
- Added support for setting Access Tier on Blob Snapshots and Versions.
- Added support for BlobServiceProperties.StaticWebsite.DefaultIndexDocumentPath.
- Added RehydratePriority to BlobProperties and BlobItemProperties.
- Fixed bug where BlobBaseClient.DownloadTo() was throwing an exception when downloading blobs of size 0.
- Fixed bug where BlobBaseClient.DownloadTo() was not disposing the network stream.
- Fixed bug where all BlobModelFactory.BlobProperties() parameters were required.
- Fixed bug where BlobBaseClient.BlobName was encoded, affecting SAS generation.
- Fixed bug where AccountType enum was missing BlockBlobStorage and FileStorage

## 12.5.0-preview.4 (2020-06)
- This preview contains bug fixes to improve quality.

## 12.5.0-preview.1 (2020-06)
- This preview adds support for client-side encryption, compatible with data uploaded in previous major versions.

## 12.4.4 (2020-06)
- This release contains bug fixes to improve quality.

## 12.4.3 (2020-06)
- Fixed bug where copy from URL did not handle non-ASCII characters correctly
- Fixed bug where download could hang indefinietly on .NET Framework

## 12.4.2 (2020-05)
- Fixed bug where blob, file and directory names were not URL encoded.
- Fixed bug where BlobBaseClient.DownloadAsync() could download data incorrectly if intermittent network failure occurs.

## 12.4.1 (2020-04)
- Fixed bug where BlobContainerClient.DeleteIfExistsAsync() would throw an exception if hierarchical namespace was enabled, and the underlying container didn't exist.
- Fixed bug where BlobBaseClient.DownloadAsync() would throw an exception when download an empty Blob.
- Fixed bug where BlockBlobClient.CommitBlockListAsync() would throw an exception when commiting previously committed blocks.

## 12.4.0 (2020-03)
- Fixed bug in BlobBaseClient.Download() and BlobClient.Upload() where TransferOptions.MaximumTransferLength was ignored.

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
