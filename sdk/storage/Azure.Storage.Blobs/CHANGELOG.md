# Release History

## 12.25.1 (2025-09-24)

### Bugs Fixed
- Fixed bug for processing partitioned downloads for empty blobs with content validation enabled.

## 12.25.0 (2025-07-14)

### Features Added
- Includes all features from 12.25.0-beta.1
- Includes all features from 12.24.1

## 12.26.0-beta.1 (2025-06-09)

### Features Added
- Added support for service version 2025-11-05.
- AppendBlobClient.AppendBlobFromUri(), .AppendBlockFromUriAsync(), BlobBaseClient.StartCopyFromUri(), .StartCopyFromUriAsync(), SyncCopyFromUri(), .SyncCopyFromUriAsync(), BlockBlobClient.StageBlockFromUri(), .StageBlockFromUriAsync(), PageBlobClient.UploadPagesFromUri(), and .UploadPagesFromUri() will now return CopySourceStatusCode, CopySourceErrorCode, and CopySourceErrorMessage as part of error responses.
- Added more useful error message when the SDK encounters an x-ms-version mis-match issue.

### Other Changes
- Changed BlobServiceClient.AccountName to be virtual so that it can be overridden and mocked.

## 12.24.1 (2025-06-10)

### Features Added
- Added `PageBlobCreateOptions.PremiumPageBlobAccessTier` for `PageBlobClient.Create(..)`

## 12.25.0-beta.1 (2025-05-06)

### Features Added
- Added support for service version 2025-07-05.
- Added support for the `SourceShareTokenIntent` parameter to `AppendBlobClient.AppendBlockFromUri()`, `.AppendBlockFromUriAsync()`, `BlockBlobClient.StageBlockFromUri()`, `.StageBlockFromUriAsync()`, `BlockBlobClient.SyncUploadFromUri()`, `.SyncUploadFromUriAsync()`, `BlobBaseClient.SyncCopyFromUri()`, `.SyncCopyFromUriAsync()`, `PageBlobClient.UploadPagesFromUri()`, `.UploadPagesFromUriAsync()`,
- Added `PageBlobCreateOptions.PremiumPageBlobAccessTier` to `PageBlobClient.Create(..)` overloads.

## 12.24.0 (2025-03-11)

### Features Added
- Includes all features from 12.24.0-beta.1
- Added the following Client Builders: `AddBlobServiceClient(Uri, Azure.SasCredential)`, `AddBlobServiceClient(Uri, TokenCredential)`

### Bugs Fixed
- Fixed bug where a `BlobServiceClient`, `BlobContainerClient`, `BlobBaseClient` created with a connection string with an account name specified (e.g. "AccountName=..;"), the account name was not populated on the Storage Clients if the account name was not also specified in the endpoint. (#42925)
- Fixed bug where a `BlobServiceClient`, `BlobContainerClient`, `BlobBaseClient` created with a `StorageSharedKeyCredential`, the account name was not populated on the Storage Clients if the account name was not also specified in the endpoint. (#42925)

## 12.24.0-beta.1 (2025-02-11)

### Features Added
- Added support for service version 2025-05-05.

## 12.23.0 (2024-11-12)

### Features Added
- Includes all features from 12.23.0-beta.1 and 12.23.0-beta.2

### Bugs Fixed
- Fixed bug where network download streams were not properly disposed.
- Fixed bug where DownloadToAsync() did not dispose all its network streams on error in some cases.

## 12.23.0-beta.2 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.22.2 (2024-10-10)

### Other Changes
- Upgraded `System.Text.Json` package dependency to 6.0.10 for security fix.

## 12.23.0-beta.1 (2024-10-08)

### Features Added
- Added support for service version 2025-01-05.
- Added GenerateUserDelegationSasUri() to BlobBaseClient and BlobContainerClient.
- Added BlobErrorCode.BlobAccessTierNotSupportedForAccountType enum value.

### Bugs Fixed
- Fixed bug where BlobClient.Upload(BinaryData content, ..) did not properly dispose stream after wrapping the BinaryData passed.

## 12.22.1 (2024-09-25)

### Other Changes
- Integrated decryption for CSE v2.1

## 12.22.0 (2024-09-18)

### Features Added
- Includes all features from 12.22.0-beta.1

### Bugs Fixed
- Fixed \[BUG\] Method overload BlobBaseClient.OpenReadAsync()/OpenRead() to correctly handle the allowBlobModifications flag #45516
- Fixed \[BUG\] Fixed Equality failures due to implicit cast on BlobErrorCode #44213

## 12.21.2 (2024-08-08)

### Bugs Fixed
- Fixed \[BUG\] WrapKeyInternal to correctly call WrapKey in sync flow #42160

## 12.22.0-beta.1 (2024-08-06)

### Features Added
- Added support for service version 2024-11-04.
- Added ability to retrieve SAS string to sign for debugging purposes.

### Bugs Fixed
- Fixed \[BUG\] BlobContainerClient(connectionString, blobContainerName, options) ctor to set clientSideEncryptionOptions #44623

## 12.21.1 (2024-07-25)

### Bugs Fixed
- Fixed \[BUG\] Azure Blob Storage Client SDK No Longer Supports Globalization Invariant Mode for Account Key Authentication #45052

## 12.21.0 (2024-07-16)

### Features Added
- Includes all features from 12.21.0-beta.1.

### Bugs Fixed
- Fixed bug where storage clients when constructed with URLs with '#' character would truncate the blob name at the '#'.

## 12.21.0-beta.1 (2024-06-11)
- Added support for service version 2024-08-04.
- Added BlobContainerClient.GetAccountInfo(), .GetAccountInfoAsync(), BlobBaseClient.GetAccountInfo(), and .GetAccountInfoAsync() APIs.
- Added more detailed messaging for authorization failure cases.

## 12.20.0 (2024-05-13)
- Includes all features from 12.20.0-beta.1 and 12.20.0-beta.2.
- Fixed bug where `BlobContainerClient` and `BlobBaseClient` did not throw an exception on empty/null container names and blob names, respectively, when constructing a client. 

## 12.20.0-beta.2 (2024-04-15)
- Added support for service version 2024-05-04.
- Fixed bug where BlockBlobClient.Upload() and .UploadAsync() would throw an exception if BlobUploadOptions was null.
- Fixed a bug where some valid shared access signatures were improperly parsed, throwing an exception.

## 12.20.0-beta.1 (2023-12-05)
- Added support for service version 2024-02-04.

## 12.19.1 (2023-11-13)
- Distributed tracing with `ActivitySource` is stable and no longer requires the [Experimental feature-flag](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## 12.19.0 (2023-11-06)
- Includes all features from 12.19.0-beta.1.

## 12.19.0-beta.1 (2023-10-16)
- Added support for service version 2023-11-03.
- Added support for BlobClientOptions.Audience

## 12.18.0 (2023-09-12)
- Includes all features from 12.18.0-beta.1.

## 12.18.0-beta.1 (2023-08-08)
- Added support for service version 2023-05-03 and 2023-08-03.
- Added RehydratePendingToCold value to ArchiveStatus enum.

## 12.17.0 (2023-07-11)
- Includes all features from 12.17.0-beta.1.

## 12.17.0-beta.1 (2023-05-30)
- Added support for service version 2023-01-03.
- Content length limit for AppendBlobClient.Append(), .AppendAsync(), .AppendBlockFromUri(), and .AppendBlockFromUriAsync() raised from 4 MiB to 100 MiB.

## 12.16.0 (2023-04-11)
- Includes all features from 12.16.0-beta.1.

## 12.16.0-beta.1 (2023-03-28)
- Added support for service version 2022-11-02.
- Fixed bug where GenerateSasUri did not honor TrimBlobNameSlashes when creating the SAS (#34591).

## 12.15.1 (2023-03-24)
- Bumped Azure.Core dependency from 1.28 and 1.30, fixing issue with headers being non-resilient to double dispose of the request.

## 12.15.0 (2023-02-21)
- Includes all features from 12.15.0-beta.1.
- Added BlobDownloadDetails.CreatedOn property.

## 12.15.0-beta.1 (2023-02-07)
- Added support for service version 2021-12-02.
- Added support for Blob Cold Tier.
- Fixed bug where BlobErrorCode.IncrementalCopyOfEarlierVersionSnapshotNotAllowed was spelled incorrectly.
- Fixed bug / regression where BlobContainerClient.GetProperties would return null instead of PublicAccessType.None for the BlobContainerProperties.PublicAccess

## 12.14.1 (2022-10-20)
- Fixed bug were BlobBaseClient constructor taking a URI and BlobClientOptions would ignore BlobClientOptions.TrimBlobNameSlashes.

## 12.14.0 (2022-10-12)
- Includes all features from 12.14.0-beta.1.
- Added support for leading and trailing '/' characters in blob names when constructing URIs via builder.

## 12.14.0-beta.1 (2022-08-23)
- Added support for service version 2021-10-04.
- Added support for SDK-calculated transactional checksums on data transfer.

## 12.13.1 (2022-08-22)
- Added support for downloading blobs with bugged client-side encryption metadata from previous library versions.

## 12.13.0 (2022-07-07)
- Includes all features from 12.13.0-beta.1.

## 12.13.0-beta.1 (2022-06-15)
- Added support for service version 2021-08-06.
- Added support for clientside encryption V2.0
  - GCM support
  - V2.0 is considered a security upgrade, and it is recommended applications switch to server-side encryption or upgrade to clientside V2.0.
- Fixed bug where calling AppendBlockFromUri() without AppendBlobAppendBlockFromUriOptions throws a null exception error

## 12.12.0 (2022-05-02)
- Includes all features from 12.12.0-beta.1.

## 12.12.0-beta.1 (2022-04-12)
- Added support for service version 2021-06-08.
- Added pageable versions of PageBlobClient.GetPageRanges() and .GetPageRangesAsync().
- Added ability to copy source blob tags for BlobBaseClient.SyncCopyFromUri() and .SyncCopyFromUriAsync().
- Fixed a bug where CopyFromUriOperation was throwing an Exception when the status of the blob copy was aborted or failed.

## 12.11.0 (2022-03-10)
- Includes all features from 12.11.0-beta.1, 12.11.0-beta.2, and 12.11.0-beta.3 except SDK-calculated transactional checksums on data transfer.
- Added support for progress reporting with DownloadToAsync().
- Fixed a bug where BlobBaseClient.DownloadTo() would result in an ObjectDisposedException on .NET Framework in certain network conditions.
- Added nullable version of `BlobProperties.CopyStatus` called `BlobCopyStatus`, allowing a null value when Storage doesn't return a value.
- Fixed a bug where BlobContainerClient.GetProperties() would throw an ArgumentNullException when the AccessPolicy was null
- Removed preview support for SDK-calculated transactional checksums on data transfer.
- Fixed a bug where BlobUriBuilder was case sensitive for parameter names.

## 12.11.0-beta.3 (2022-02-07)
- Added support for service version 2021-04-10.
- Added support for BlobContainerClient.FilterBlobsByTag().
- Added support for BlobContainerClient.OpenWriteAsync().
- Fixed bug where BlobSasBuilder.SetPermissions(string rawPermissions) was not properly handling the Permanent Delete ('y') and set Immutability Policy ('i') permissions.
- Fixed a bug where BlobClient.Upload() and UploadAsync() would result in a NullReferenceException when trying to overwrite a blob with client-side encryption enabled

## 12.11.0-beta.2 (2021-11-30)
- Added support for service version 2021-02-12
- Added support for listing system containers with BlobServiceClient.GetBlobContainers() and .GetBlobContainersAsync().
- Added support for blob names container invalid XML characters.
- Added support for updating the key encryption key on a client-side encrypted blob.
- Fixed a bug where BlobClient.Upload() and UploadAsync() when using client-side encryption would modify the Dictionary instance passed by the caller for blob metadata.
- Fixed a bug where BlobClient.Upload() and UploadAsync() when using client-side encryption would not respect StorageTransferOptions.InitialTransferSize.

## 12.11.0-beta.1 (2021-11-03)
- Added support for service version 2020-12-06.
- Added support for Encryption Scope SAS.
- Added support for Encryption Scopes with BlobBaseClient.SyncCopyFromUriAsync().
- Added support for generating SAS URLs with the Permanent Delete ('y') SAS permission.
- Added support for SDK-calculated transactional hash checksums on data transfer.
- Fixed bug where BlobContainerClient.GetBlobs() and .GetBlobsByHierarchyAsync() was not parsing the Object Replication Metadata correctly
- Fixed bug / regression where the ETag values that had quotation marks surrounding it were being removed starting in version 12.9.0.

## 12.10.0 (2021-09-08)
- Includes all features from 12.10.0-beta.1 and 12.10.0-beta.2.

## 12.10.0-beta.2 (2021-07-23)
- This release contains bug fixes to improve quality.

## 12.10.0-beta.1 (2021-07-22)
- Added support for service version 2020-10-02.
- Added support for Immutable Storage with Versioning
    - Added BlobBaseClient.SetImmutibilityPolicy()
    - Added BlobBaseClient.DeleteImmutabilityPolicy()
    - Added BlobBaseClient.SetLegalHold()
- Added support for listing deleted root blobs with versions to BlobContainerClient.GetBlobs() and .GetBlobsByHierarchy()
- Added support for OAuth copy sources for synchronous copy operations.
- Added support for Parquet as an input format in BlockBlobClient.Query().
- Added optimization to unwrap encryption key once for DownloadTo and OpenRead when Client Side Encryption is enabled.
- Added support for RequestConditions parameter validation.  If a request condition is set for an API that doesn't support it, and ArguementException will be thrown.
    - This feature can be disabled with the environment variable "AZURE_STORAGE_DISABLE_REQUEST_CONDITIONS_VALIDATION" or the App Context switch "Azure.Storage.DisableRequestConditionsValidation".
- Fixed bug where BlobBaseClient.DownloadStreamingAsync() won't correctly parse the LeaseStatus header.
- Fixed bug where BlobBaseClient.DownloadContentAsync() fails on 304 response.

## 12.9.1 (2021-06-23)
- Added optimization to unwrap encryption key once for DownloadTo and OpenRead when Client Side Encryption is enabled.

## 12.9.0 (2021-06-08)
- Includes all features from 12.9.0-beta.4.
- Fixed bug where BlobClient.DownloadStreaming or BlobClient.DownloadData could corrupt data on retry.
- Fixed bug where specifying "*" as IfMatch condition could lead to inconsistend read in BlobClient.DownloadTo.
- Fixed bug where specifying conditions in BlobBaseClient.OpenRead could override allowModifications flag in BlobOpenReadOptions leading to inconsistent read.
- Fixed bug where BlobProperties.IsLatestVersion from BlobBaseClient.GetProperties did not set the value (defaulted to false).
- Fixed bug where reading blob with Client Side Encryption enabled results in high CPU.

- TenantId can now be discovered through the service challenge response, when using a TokenCredential for authorization.
    - A new property is now available on the ClientOptions called `EnableTenantDiscovery`. If set to true, the client will attempt an initial unauthorized request to the service to prompt a challenge containing the tenantId hint.

## 12.8.4 (2021-05-20)
- Fixed bug where Client Side Encryption during large transactions (greater than max int value) would throw an exception.

## 12.9.0-beta.4 (2021-05-12)
- Added support for service version 2020-08-04.
- Added WithCustomerProvidedKey() and WithEncryptionScope() to BlobClient, BlobBaseClient, AppendBlobClient, and PageBlobClient.
- BlobLeaseClient now remembers the Lease ID after a lease change.
- Fixed bug where clients would sometimes throw a NullReferenceException when calling GenerateSas() with a BlobSasBuilder parameter.
- Fixed bug where BlobBaseClient.Exists() would not function correctly on blobs encrypted with CPK.
- Includes all updates and fixes from 12.8.2 and 12.8.3

## 12.8.3 (2021-04-27)
- Fixed bug where Stream returned by BlockBlobClient.OpenWrite could corrupt blocks if flushed between writes.

## 12.8.2 (2021-04-27)
- This release contains bug fixes to improve quality.

## 12.9.0-beta.3 (2021-04-09)
- This release contains bug fixes to improve quality.

## 12.8.1 (2021-03-29)
- Fixed bug where ClientDiagnostics's DiagnosticListener was leaking resources.

## 12.9.0-beta.2 (2021-03-09)
- Fixed a bug where BlockBlobClient.GetBlockList threw when dealing with extremely large blocks.
- Fixed bug where `Stream` returned by `BlockBlobClient.OpenWrite` could corrupt blocks if flushed between writes.
- Added BlobBaseClient.DownloadContent and BlobClient.Upload overloads that work with [BinaryData](https://github.com/Azure/azure-sdk-for-net/tree/System.Memory.Data_1.0.1/sdk/core/System.Memory.Data).
- Added BlobBaseClient.DownloadStreaming that replaces BlobBaseClient.Download.

## 12.9.0-beta.1 (2021-02-09)
- Added support for service version 2020-06-12.
- Fixed bug where BlobBaseClient.CanGenerateSasUri, BlobContainerClient.CanGenerateSasUri, BlobServiceClient.CanGenerateSasUri was not mockable

## 12.8.0 (2021-01-12)
- Includes all features from 12.8.0-beta.1
- Fixed bug where the Stream returned by BlobBaseClient.OpenRead() would return a different Length after calls to Seek().
- Fixed bug where BlobBaseClient.Exists() did not function correctly for blob encrypted with Customer Provided Key or Encryption Scope.
- Added support for AzureSasCredential. That allows SAS rotation for long living clients.

## 12.8.0-beta.1 (2020-12-07)
- Added support for service version 2020-04-08.
- Added BlockBlobClient.SyncUploadFromUri().
- Added support for LeaseId parameter for BlobBaseClient.Get/SetTags().
- Added Tags to BlobTaggedItem
- Fixed bug where BlobContainerClient.GetBlobClient(), BlobContainerClient.GetParentServiceClient(), BlobServiceClient.GetBlobContainerClient(), BlobBaseClient.WithClientSideEncryptionOptions(), BlobBaseClient.GetParentBlobContainerClient(), BlobBaseClient.WithSnapshot() and BlobBaseClient.WithVersion() created clients that could not generate a SAS from clients that could generate a SAS
- Added IsHierarchicalNamespaceEnabled to AccountInfo.

## 12.7.0 (2020-11-10)
- Includes all features from 12.7.0-preview.1
- Fixed bug where BlobContainerClient.SetAccessPolicy() would throw an exception if signed identifier permissions were not in the correct order.
- Added seekability to BaseBlobClient.OpenRead().
- Added additional info to exception messages.
- Fixed bug where Blobs SDK coudn't handle SASs with start and expiry time in format other than yyyy-MM-ddTHH:mm:ssZ.
- Added ability to set Position on streams created with BlobBaseClient.OpenRead().
- Added CanGenerateSasUri property, GenerateSasUri() to BlobBaseClient, BlobClient, BlockBlobClient, AppendBlobClient, PageBlobClient and BlobContainerClient.
- Added CanAccountGenerateSasUri property, GenerateAccountSasUri() to BlobServiceClient.
- Deprecated property BlobSasBuilder.Version, so when generating SAS will always use the latest Storage Service SAS version.
- Added ability to get parent BlobContainerClient from BlobBaseClient and to get parent BlobServiceClient from BlobContainerClient.
- Restored single upload threshold for parallel uploads from 5 TB to 256 MB.

## 12.7.0-preview.1 (2020-09-30)
- Added support for service version 2020-02-10.
- Added support for Blob Query Arrow output format.
- Added support for Blob Last Access Time tracking.
- Added support for Container Soft Delete.
- Fixed bug where Stream returned from AppendBlobClient.OpenWrite(), BlockBlobClient.OpenWrite() and PageBlobClient.OpenWrite() did not flush while disposing preventing compatibility with using keyword.
- Fixed bug where Listing Blobs with BlobTraits.Metadata would return BlobItems with null metadata instead of an empty dictionary if no metadata was present.
- Fixed bug where BlobAccessPolicy.StartsOn and .ExpiresOn would cause the process to crash.
- Added seekability to BlobBaseClient.OpenRead().

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

## 12.5.0-preview.4 
- This preview contains bug fixes to improve quality.

## 12.5.0-preview.1 
- This preview adds support for client-side encryption, compatible with data uploaded in previous major versions.

## 12.4.4 
- This release contains bug fixes to improve quality.

## 12.4.3 
- Fixed bug where copy from URL did not handle non-ASCII characters correctly
- Fixed bug where download could hang indefinietly on .NET Framework

## 12.4.2 
- Fixed bug where blob, file and directory names were not URL encoded.
- Fixed bug where BlobBaseClient.DownloadAsync() could download data incorrectly if intermittent network failure occurs.

## 12.4.1 
- Fixed bug where BlobContainerClient.DeleteIfExistsAsync() would throw an exception if hierarchical namespace was enabled, and the underlying container didn't exist.
- Fixed bug where BlobBaseClient.DownloadAsync() would throw an exception when download an empty Blob.
- Fixed bug where BlockBlobClient.CommitBlockListAsync() would throw an exception when commiting previously committed blocks.

## 12.4.0 
- Fixed bug in BlobBaseClient.Download() and BlobClient.Upload() where TransferOptions.MaximumTransferLength was ignored.

## 12.3.0 
- Added support for service version 2019-07-07.
- Added support for Encryption Scopes.
- Modified BlockBlobClient.Upload() and .UploadAsync() to support parallel and multi-part uploads.
- Fixed issue where SAS didn't work with signed identifiers.
- Sanitized header values in exceptions.

## 12.2.0 
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

## 12.0.0 
- Renamed a number of operations and models to better align with other client
  libraries and the .NET Framework Design Guidelines
- Parallel upload/download performance improvements

## 12.0.0-preview.4 
- Added support for Customer Provided Key server side encryption
- Verification of echoed client request IDs
- Support for geo-redundant read from secondary location on failure
- Added CreateIfNotExists and DeleteIfNotExists convenience methods for Blobs
- Added convenient resource Name properties on all clients

## 12.0.0-preview.3 
- New Storage features for service version 2019-02-02 (including Customer
  Provided Key, expanded Set Tier support, the ability to set rehydration
  priority, etc.)
- Parallel upload/download
- Added BlobUriBuilder for addressing Azure Storage resources

For more information, please visit: https://aka.ms/azure-sdk-preview3-net.

## 12.0.0-preview.2 
- Distributed Tracing
- Bug fixes

## 12.0.0-preview.1 
This preview is the first release of a ground-up rewrite of our client
libraries to ensure consistency, idiomatic design, productivity, and an
excellent developer experience.  It was created following the Azure SDK Design
Guidelines for .NET at https://azuresdkspecs.z5.web.core.windows.net/DotNetSpec.html.

For more information, please visit: https://aka.ms/azure-sdk-preview1-net.
