//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the Constants class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;

    /// <summary>
    /// Contains storage constants.
    /// </summary>
    internal class Constants
    {
        /// <summary>
        /// Maximum number of shared access policy identifiers supported by server.
        /// </summary>
        public const int MaxSharedAccessPolicyIdentifiers = 5;

        /// <summary>
        /// Default client side timeout for all service clients.
        /// </summary>
        public static readonly TimeSpan DefaultClientSideTimeout = TimeSpan.FromSeconds(90);

        /// <summary>
        /// Maximum allowed timeout for any request.
        /// </summary>
        public static readonly TimeSpan MaximumAllowedTimeout = TimeSpan.FromSeconds(int.MaxValue);

        /// <summary>
        /// Default Write Block Size used by Blob stream.
        /// </summary>
        public const long DefaultWriteBlockSizeBytes = 4 * Constants.MB;

        /// <summary>
        /// Default Read Ahead Size used by Blob stream.     
        /// </summary>
        public const long DefaultReadAheadSizeBytes = 512 * Constants.KB;

        /// <summary>
        /// The maximum size of a blob before it must be separated into blocks.
        /// </summary>
        public const long MaxSingleUploadBlobSize = 64 * MB;

        /// <summary>
        /// The maximum size of a blob with blocks.
        /// </summary>
        public const long MaxBlobSize = 200 * GB;

        /// <summary>
        /// The maximum size of a single block.
        /// </summary>
        public const long MaxBlockSize = 4 * 1024 * 1024;

        /// <summary>
        /// The maximum number of blocks.
        /// </summary>
        public const long MaxBlockNumber = 50000;

        /// <summary>
        /// Default size of buffer for unknown sized requests.
        /// </summary>
        internal const int DefaultBufferSize = 84000;

        /// <summary>
        /// This is used to create V1 BlockIDs. The prefix must be Base64 compatible.
        /// </summary>
        internal static readonly string V1BlockPrefix = "MD5/";

        /// <summary>
        /// This is the offset of the V2 MD5 string where the MD5/ tag resides.
        /// </summary>
        internal static readonly int V1MD5blockIdExpectedLength = 28;

        /// <summary>
        /// This is used to create BlockIDs. The prefix must be Base64 compatible.
        /// </summary>
        internal const string V2blockPrefix = "V2/";

        /// <summary>
        /// This is used to create BlockIDs. The prefix must be Base64 compatible.
        /// </summary>
        internal static readonly string V2MD5blockIdFormat = V2blockPrefix + "{0}/{1}";

        /// <summary>
        /// This is the offset of the V2 MD5 string where the hash value resides.
        /// </summary>
        internal static readonly int V2MD5blockIdMD5Offset = V2blockPrefix.Length + 8 + 1;

        /// <summary>
        /// This is the expected length of a V2 MD5 Block ID string.
        /// </summary>
        internal static readonly int V2MD5blockIdExpectedLength = V2MD5blockIdMD5Offset + 24;        

        /// <summary>
        /// The size of a page in a PageBlob.
        /// </summary>
        internal const long PageSize = 512;
        
        /// <summary>
        /// A constant representing a kilo-byte (Non-SI version).
        /// </summary>
        internal const long KB = 1024;

        /// <summary>
        /// A constant representing a megabyte (Non-SI version).
        /// </summary>
        internal const long MB = 1024 * KB;

        /// <summary>
        /// A constant representing a megabyte (Non-SI version).
        /// </summary>
        internal const long GB = 1024 * MB;

        /// <summary>
        /// XML element for committed blocks.
        /// </summary>
        internal const string CommittedBlocksElement = "CommittedBlocks";

        /// <summary>
        /// XML element for uncommitted blocks.
        /// </summary>
        internal const string UncommittedBlocksElement = "UncommittedBlocks";

        /// <summary>
        /// XML element for blocks.
        /// </summary>
        internal const string BlockElement = "Block";

        /// <summary>
        /// XML element for names.
        /// </summary>
        internal const string NameElement = "Name";

        /// <summary>
        /// XML element for sizes.
        /// </summary>
        internal const string SizeElement = "Size";

        /// <summary>
        /// XML element for block lists.
        /// </summary>
        internal const string BlockListElement = "BlockList";

        /// <summary>
        /// XML element for queue message lists.
        /// </summary>
        internal const string MessagesElement = "QueueMessagesList";

        /// <summary>
        /// XML element for queue messages.
        /// </summary>
        internal const string MessageElement = "QueueMessage";

        /// <summary>
        /// XML element for message IDs.
        /// </summary>
        internal const string MessageIdElement = "MessageId";

        /// <summary>
        /// XML element for insertion times.
        /// </summary>
        internal const string InsertionTimeElement = "InsertionTime";

        /// <summary>
        /// XML element for expiration times.
        /// </summary>
        internal const string ExpirationTimeElement = "ExpirationTime";

        /// <summary>
        /// XML element for pop receipts.
        /// </summary>
        internal const string PopReceiptElement = "PopReceipt";

        /// <summary>
        /// XML element for the time next visible fields.
        /// </summary>
        internal const string TimeNextVisibleElement = "TimeNextVisible";

        /// <summary>
        /// XML element for message texts.
        /// </summary>
        internal const string MessageTextElement = "MessageText";

        /// <summary>
        /// XML element for dequeue counts.
        /// </summary>
        internal const string DequeueCountElement = "DequeueCount";

        /// <summary>
        /// XML element for page ranges.
        /// </summary>
        internal const string PageRangeElement = "PageRange";

        /// <summary>
        /// XML element for page list elements.
        /// </summary>
        internal const string PageListElement = "PageListElement";

        /// <summary>
        /// XML element for page range start elements.
        /// </summary>
        internal const string StartElement = "Start";

        /// <summary>
        /// XML element for page range end elements.
        /// </summary>
        internal const string EndElement = "End";

        /// <summary>
        /// XML element for delimiters.
        /// </summary>
        internal const string DelimiterElement = "Delimiter";

        /// <summary>
        /// XML element for blob prefixes.
        /// </summary>
        internal const string BlobPrefixElement = "BlobPrefix";

        /// <summary>
        /// XML element for content type fields.
        /// </summary>
        internal const string ContentTypeElement = "Content-Type";

        /// <summary>
        /// XML element for content encoding fields.
        /// </summary>
        internal const string ContentEncodingElement = "Content-Encoding";

        /// <summary>
        /// XML element for content language fields.
        /// </summary>
        internal const string ContentLanguageElement = "Content-Language";

        /// <summary>
        /// XML element for content length fields.
        /// </summary>
        internal const string ContentLengthElement = "Content-Length";

        /// <summary>
        /// XML element for content MD5 fields.
        /// </summary>
        internal const string ContentMD5Element = "Content-MD5";

        /// <summary>
        /// XML element for blobs.
        /// </summary>
        internal const string BlobsElement = "Blobs";

        /// <summary>
        /// XML element for prefixes.
        /// </summary>
        internal const string PrefixElement = "Prefix";

        /// <summary>
        /// XML element for maximum results.
        /// </summary>
        internal const string MaxResultsElement = "MaxResults";

        /// <summary>
        /// XML element for markers.
        /// </summary>
        internal const string MarkerElement = "Marker";

        /// <summary>
        /// XML element for the next marker.
        /// </summary>
        internal const string NextMarkerElement = "NextMarker";

        /// <summary>
        /// XML element for the ETag.
        /// </summary>
        internal const string EtagElement = "Etag";

        /// <summary>
        /// XML element for the last modified date.
        /// </summary>
        internal const string LastModifiedElement = "Last-Modified";

        /// <summary>
        /// XML element for the Url.
        /// </summary>
        internal const string UrlElement = "Url";

        /// <summary>
        /// XML element for blobs.
        /// </summary>
        internal const string BlobElement = "Blob";

        /// <summary>
        /// XML element for copy ID.
        /// </summary>
        internal const string CopyIdElement = "CopyId";

        /// <summary>
        /// XML element for copy status.
        /// </summary>
        internal const string CopyStatusElement = "CopyStatus";

        /// <summary>
        /// XML element for copy source.
        /// </summary>
        internal const string CopySourceElement = "CopySource";

        /// <summary>
        /// XML element for copy progress.
        /// </summary>
        internal const string CopyProgressElement = "CopyProgress";

        /// <summary>
        /// XML element for copy completion time.
        /// </summary>
        internal const string CopyCompletionTimeElement = "CopyCompletionTime";

        /// <summary>
        /// XML element for copy status description.
        /// </summary>
        internal const string CopyStatusDescriptionElement = "CopyStatusDescription";

        /// <summary>
        /// Constant signaling a page blob.
        /// </summary>
        internal const string PageBlobValue = "PageBlob";

        /// <summary>
        /// Constant signaling a block blob.
        /// </summary>
        internal const string BlockBlobValue = "BlockBlob";

        /// <summary>
        /// Constant signaling the blob is locked.
        /// </summary>
        internal const string LockedValue = "locked";

        /// <summary>
        /// Constant signaling the blob is unlocked.
        /// </summary>
        internal const string UnlockedValue = "unlocked";

        /// <summary>
        /// Constant signaling the resource is available for leasing.
        /// </summary>
        internal const string LeaseAvailableValue = "available";

        /// <summary>
        /// Constant signaling the resource is leased.
        /// </summary>
        internal const string LeasedValue = "leased";

        /// <summary>
        /// Constant signaling the resource's lease has expired.
        /// </summary>
        internal const string LeaseExpiredValue = "expired";

        /// <summary>
        /// Constant signaling the resource's lease is breaking.
        /// </summary>
        internal const string LeaseBreakingValue = "breaking";

        /// <summary>
        /// Constant signaling the resource's lease is broken.
        /// </summary>
        internal const string LeaseBrokenValue = "broken";

        /// <summary>
        /// Constant signaling the resource's lease is infinite.
        /// </summary>
        internal const string LeaseInfiniteValue = "infinite";

        /// <summary>
        /// Constant signaling the resource's lease is fixed (finite).
        /// </summary>
        internal const string LeaseFixedValue = "fixed";

        /// <summary>
        /// Constant for a pending copy.
        /// </summary>
        internal const string CopyPendingValue = "pending";

        /// <summary>
        /// Constant for a successful copy.
        /// </summary>
        internal const string CopySuccessValue = "success";

        /// <summary>
        /// Constant for an aborted copy.
        /// </summary>
        internal const string CopyAbortedValue = "aborted";

        /// <summary>
        /// Constant for a failed copy.
        /// </summary>
        internal const string CopyFailedValue = "failed";
        
        /// <summary>
        /// XML element for blob types.
        /// </summary>
        internal const string BlobTypeElement = "BlobType";

        /// <summary>
        /// XML element for the lease status.
        /// </summary>
        internal const string LeaseStatusElement = "LeaseStatus";

        /// <summary>
        /// XML element for the lease status.
        /// </summary>
        internal const string LeaseStateElement = "LeaseState";

        /// <summary>
        /// XML element for the lease status.
        /// </summary>
        internal const string LeaseDurationElement = "LeaseDuration";

        /// <summary>
        /// XML element for snapshots.
        /// </summary>
        internal const string SnapshotElement = "Snapshot";

        /// <summary>
        /// XML element for containers.
        /// </summary>
        internal const string ContainersElement = "Containers";

        /// <summary>
        /// XML element for a container.
        /// </summary>
        internal const string ContainerElement = "Container";

        /// <summary>
        /// XML element for queues.
        /// </summary>
        internal const string QueuesElement = "Queues";

        /// <summary>
        /// XML element for the queue name.
        /// </summary>
        internal const string QueueNameElement = "QueueName";

        /// <summary>
        /// Version 2 of the XML element for the queue name.
        /// </summary>
        internal const string QueueNameElementVer2 = "Name";

        /// <summary>
        /// XML element for the queue.
        /// </summary>
        internal const string QueueElement = "Queue";

        /// <summary>
        /// XML element for the metadata.
        /// </summary>
        internal const string MetadataElement = "Metadata";

        /// <summary>
        /// XML element for an invalid metadata name.
        /// </summary>
        internal const string InvalidMetadataName = "x-ms-invalid-name";

        /// <summary>
        /// XPath query for error codes.
        /// </summary>
        internal const string ErrorCodeQuery = "//Error/Code";

        /// <summary>
        /// XPath query for error messages.
        /// </summary>
        internal const string ErrorMessageQuery = "//Error/Message";

        /// <summary>
        /// XML element for maximum results.
        /// </summary>
        internal const string MaxResults = "MaxResults";

        /// <summary>
        /// XML element for committed blocks.
        /// </summary>
        internal const string CommittedElement = "Committed";

        /// <summary>
        /// XML element for uncommitted blocks.
        /// </summary>
        internal const string UncommittedElement = "Uncommitted";

        /// <summary>
        /// XML element for the latest.
        /// </summary>
        internal const string LatestElement = "Latest";

        /// <summary>
        /// XML element for signed identifiers.
        /// </summary>
        internal const string SignedIdentifiers = "SignedIdentifiers";

        /// <summary>
        /// XML element for a signed identifier.
        /// </summary>
        internal const string SignedIdentifier = "SignedIdentifier";

        /// <summary>
        /// XML element for access policies.
        /// </summary>
        internal const string AccessPolicy = "AccessPolicy";

        /// <summary>
        /// XML attribute for IDs.
        /// </summary>
        internal const string Id = "Id";

        /// <summary>
        /// XML element for the start time of an access policy.
        /// </summary>
        internal const string Start = "Start";

        /// <summary>
        /// XML element for the end of an access policy.
        /// </summary>
        internal const string Expiry = "Expiry";

        /// <summary>
        /// XML element for the permissions of an access policy.
        /// </summary>
        internal const string Permission = "Permission";

        /// <summary>
        /// The maximum size of a string property for the table service in bytes.
        /// </summary>
        internal const int TableServiceMaxStringPropertySizeInBytes = 64 * 1024;

        /// <summary>
        /// The maximum size of a string property for the table service in chars.
        /// </summary>
        internal const int TableServiceMaxStringPropertySizeInChars = TableServiceMaxStringPropertySizeInBytes / 2;

        /// <summary>
        /// The minimum supported <see cref="DateTime"/> value for the table service.
        /// </summary>
        internal static readonly DateTime TableServiceMinSupportedDateTime = DateTime.FromFileTime(0).ToUniversalTime().AddYears(200);

        /// <summary>
        /// The name of the special table used to store tables.
        /// </summary>
        internal const string TableServiceTablesName = "Tables";

        /// <summary>
        /// The timeout after which the WCF Data Services bug workaround kicks in. This should be greater than the timeout we pass to DataServiceContext (90 seconds).
        /// </summary>
        internal static readonly TimeSpan TableWorkaroundTimeout = TimeSpan.FromSeconds(120);

        /// <summary>
        /// The Uri path component to access the messages in a queue.
        /// </summary>
        internal const string Messages = "messages";

        /// <summary>
        /// XML root element for errors.
        /// </summary>
        internal const string ErrorRootElement = "Error";

        /// <summary>
        /// XML element for error codes.
        /// </summary>
        internal const string ErrorCode = "Code";

        /// <summary>
        /// XML element for error messages.
        /// </summary>
        internal const string ErrorMessage = "Message";

        /// <summary>
        /// XML element for exception details.
        /// </summary>
        internal const string ErrorException = "ExceptionDetails";

        /// <summary>
        /// XML element for exception messages.
        /// </summary>
        internal const string ErrorExceptionMessage = "ExceptionMessage";

        /// <summary>
        /// XML element for stack traces.
        /// </summary>
        internal const string ErrorExceptionStackTrace = "StackTrace";

        /// <summary>
        /// XML element for the authentication error details.
        /// </summary>
        internal const string AuthenticationErrorDetail = "AuthenticationErrorDetail";

        /// <summary>
        /// XML namespace for the WCF Data Services metadata.
        /// </summary>
        internal const string DataWebMetadataNamespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";

        /// <summary>
        /// XML element for table error codes.
        /// </summary>
        internal const string TableErrorCodeElement = "code";

        /// <summary>
        /// XML element for table error messages.
        /// </summary>
        internal const string TableErrorMessageElement = "message";

        /// <summary>
        /// Constants for HTTP headers.
        /// </summary>
        internal class HeaderConstants
        {
            /// <summary>
            /// Master Windows Azure Storage header prefix.
            /// </summary>
            internal const string PrefixForStorageHeader = "x-ms-";

            /// <summary>
            /// Header prefix for properties.
            /// </summary>
            internal const string PrefixForStorageProperties = "x-ms-prop-";

            /// <summary>
            /// Header prefix for metadata.
            /// </summary>
            internal const string PrefixForStorageMetadata = "x-ms-meta-";

            /// <summary>
            /// Header for data ranges.
            /// </summary>
            internal const string StorageRangeHeader = PrefixForStorageHeader + "range";

            /// <summary>
            /// Header for storage version.
            /// </summary>
            internal const string StorageVersionHeader = PrefixForStorageHeader + "version";

            /// <summary>
            /// Header for copy source.
            /// </summary>
            internal const string CopySourceHeader = PrefixForStorageHeader + "copy-source";

            /// <summary>
            /// Header for the If-Match condition.
            /// </summary>
            internal const string SourceIfMatchHeader = PrefixForStorageHeader + "source-if-match";

            /// <summary>
            /// Header for the If-Modified-Since condition.
            /// </summary>
            internal const string SourceIfModifiedSinceHeader = PrefixForStorageHeader + "source-if-modified-since";

            /// <summary>
            /// Header for the If-None-Match condition.
            /// </summary>
            internal const string SourceIfNoneMatchHeader = PrefixForStorageHeader + "source-if-none-match";

            /// <summary>
            /// Header for the If-Unmodified-Since condition.
            /// </summary>
            internal const string SourceIfUnmodifiedSinceHeader = PrefixForStorageHeader + "source-if-unmodified-since";

            /// <summary>
            /// Header for the blob content length.
            /// </summary>
            internal const string Size = PrefixForStorageHeader + "blob-content-length";

            /// <summary>
            /// Header for the blob type.
            /// </summary>
            internal const string BlobType = PrefixForStorageHeader + "blob-type";

            /// <summary>
            /// Header for snapshots.
            /// </summary>
            internal const string SnapshotHeader = PrefixForStorageHeader + "snapshot";

            /// <summary>
            /// Header to delete snapshots.
            /// </summary>
            internal const string DeleteSnapshotHeader = PrefixForStorageHeader + "delete-snapshots";

            /// <summary>
            /// Header that specifies approximate message count of a queue.
            /// </summary>
            internal const string ApproximateMessagesCount = PrefixForStorageHeader + "approximate-messages-count";

            /// <summary>
            /// Header that specifies a range.
            /// </summary>
            internal const string RangeHeader = PrefixForStorageHeader + "range";

            /// <summary>
            /// Header that specifies blob caching control.
            /// </summary>
            internal const string CacheControlHeader = PrefixForStorageHeader + "blob-cache-control";

            /// <summary>
            /// Header that specifies blob content encoding.
            /// </summary>
            internal const string ContentEncodingHeader = PrefixForStorageHeader + "blob-content-encoding";

            /// <summary>
            /// Header that specifies blob content language.
            /// </summary>
            internal const string ContentLanguageHeader = PrefixForStorageHeader + "blob-content-language";

            /// <summary>
            /// Header that specifies blob content MD5.
            /// </summary>
            internal const string BlobContentMD5Header = PrefixForStorageHeader + "blob-content-md5";

            /// <summary>
            /// Header that specifies blob content type.
            /// </summary>
            internal const string ContentTypeHeader = PrefixForStorageHeader + "blob-content-type";

            /// <summary>
            /// Header that specifies blob content length.
            /// </summary>
            internal const string ContentLengthHeader = PrefixForStorageHeader + "blob-content-length";

            /// <summary>
            /// Header that specifies lease ID.
            /// </summary>
            internal const string LeaseIdHeader = PrefixForStorageHeader + "lease-id";
            
            /// <summary>
            /// Header that specifies lease status.
            /// </summary>
            internal const string LeaseStatus = PrefixForStorageHeader + "lease-status";

            /// <summary>
            /// Header that specifies lease status.
            /// </summary>
            internal const string LeaseState = PrefixForStorageHeader + "lease-state";

            /// <summary>
            /// Header that specifies page write mode.
            /// </summary>
            internal const string PageWrite = PrefixForStorageHeader + "page-write";

            /// <summary>
            /// Header that specifies the date.
            /// </summary>
            internal const string Date = PrefixForStorageHeader + "date";

            /// <summary>
            /// Header indicating the request ID.
            /// </summary>
            internal const string RequestIdHeader = PrefixForStorageHeader + "request-id";

            /// <summary>
            /// Header that specifies public access to blobs.
            /// </summary>
            internal const string BlobPublicAccess = PrefixForStorageHeader + "blob-public-access";

            /// <summary>
            /// Format string for specifying ranges.
            /// </summary>
            internal const string RangeHeaderFormat = "bytes={0}-{1}";

            /// <summary>
            /// Current storage version header value.
            /// Every time this version changes, assembly version needs to be updated as well.
            /// </summary>
            internal const string TargetStorageVersion = "2012-02-12";

            /// <summary>
            /// Specifies the page blob type.
            /// </summary>
            internal const string PageBlob = "PageBlob";

            /// <summary>
            /// Specifies the block blob type.
            /// </summary>
            internal const string BlockBlob = "BlockBlob";

            /// <summary>
            /// Specifies only snapshots are to be included.
            /// </summary>
            internal const string SnapshotsOnlyValue = "only";

            /// <summary>
            /// Specifies snapshots are to be included.
            /// </summary>
            internal const string IncludeSnapshotsValue = "include";

            /// <summary>
            /// Specifies the value to use for UserAgent header.
            /// </summary>
            internal const string UserAgent = "WA-Storage/1.7.1";

            /// <summary>
            /// Header that specifies the pop receipt for a message.
            /// </summary>
            internal const string PopReceipt = PrefixForStorageHeader + "popreceipt";

            /// <summary>
            /// Header that specifies the next visible time for a message.
            /// </summary>
            internal const string NextVisibleTime = PrefixForStorageHeader + "time-next-visible";

            /// <summary>
            /// Header that specifies the lease action to perform.
            /// </summary>
            internal const string LeaseActionHeader = PrefixForStorageHeader + "lease-action";

            /// <summary>
            /// Header that specifies the proposed lease ID for a leasing operation.
            /// </summary>
            internal const string ProposedLeaseIdHeader = PrefixForStorageHeader + "proposed-lease-id";

            /// <summary>
            /// Header that specifies the duration of a lease.
            /// </summary>
            internal const string LeaseDurationHeader = PrefixForStorageHeader + "lease-duration";

            /// <summary>
            /// Header that specifies the break period of a lease.
            /// </summary>
            internal const string LeaseBreakPeriodHeader = PrefixForStorageHeader + "lease-break-period";

            /// <summary>
            /// Header that specifies the remaining lease time.
            /// </summary>
            internal const string LeaseTimeHeader = PrefixForStorageHeader + "lease-time";

            /// <summary>
            /// Header that specifies the key name for explicit keys.
            /// </summary>
            internal const string KeyNameHeader = PrefixForStorageHeader + "key-name";

            /// <summary>
            /// Header that specifies the copy ID.
            /// </summary>
            internal const string CopyIdHeader = PrefixForStorageHeader + "copy-id";

            /// <summary>
            /// Header that specifies the copy last modified time.
            /// </summary>
            internal const string CopyCompletionTimeHeader = PrefixForStorageHeader + "copy-completion-time";

            /// <summary>
            /// Header that specifies the copy status.
            /// </summary>
            internal const string CopyStatusHeader = PrefixForStorageHeader + "copy-status";

            /// <summary>
            /// Header that specifies the copy progress.
            /// </summary>
            internal const string CopyProgressHeader = PrefixForStorageHeader + "copy-progress";

            /// <summary>
            /// Header that specifies a copy error message.
            /// </summary>
            internal const string CopyDescriptionHeader = PrefixForStorageHeader + "copy-status-description";

            /// <summary>
            /// Header that specifies the copy action.
            /// </summary>
            internal const string CopyActionHeader = PrefixForStorageHeader + "copy-action";

            /// <summary>
            /// The value of the copy action header that signifies an abort operation.
            /// </summary>
            internal const string CopyActionAbort = "abort";
        }

        /// <summary>
        /// Constants for query strings.
        /// </summary>
        internal class QueryConstants
        {
            /// <summary>
            /// Query component for snapshot time.
            /// </summary>
            internal const string Snapshot = "snapshot";

            /// <summary>
            /// Query component for the signed SAS start time.
            /// </summary>
            internal const string SignedStart = "st";

            /// <summary>
            /// Query component for the signed SAS expiry time.
            /// </summary>
            internal const string SignedExpiry = "se";

            /// <summary>
            /// Query component for the signed SAS resource.
            /// </summary>
            internal const string SignedResource = "sr";

            /// <summary>
            /// Query component for the SAS table name.
            /// </summary>
            internal const string SasTableName = "tn";

            /// <summary>
            /// Query component for the signed SAS permissions.
            /// </summary>
            internal const string SignedPermissions = "sp";

            /// <summary>
            /// Query component for the SAS start partition key.
            /// </summary>
            internal const string StartPartitionKey = "spk";

            /// <summary>
            /// Query component for the SAS start row key.
            /// </summary>
            internal const string StartRowKey = "srk";

            /// <summary>
            /// Query component for the SAS end partition key.
            /// </summary>
            internal const string EndPartitionKey = "epk";

            /// <summary>
            /// Query component for the SAS end row key.
            /// </summary>
            internal const string EndRowKey = "erk";

            /// <summary>
            /// Query component for the signed SAS identifier.
            /// </summary>
            internal const string SignedIdentifier = "si";

            /// <summary>
            /// Query component for the signing SAS key.
            /// </summary>
            internal const string SignedKey = "sk";

            /// <summary>
            /// Query component for the signed SAS version.
            /// </summary>
            internal const string SignedVersion = "sv";

            /// <summary>
            /// Query component for SAS signature.
            /// </summary>
            internal const string Signature = "sig";

            /// <summary>
            /// Query component for message time-to-live.
            /// </summary>
            internal const string MessageTimeToLive = "messagettl";

            /// <summary>
            /// Query component for message visibility timeout.
            /// </summary>
            internal const string VisibilityTimeout = "visibilitytimeout";

            /// <summary>
            /// Query component for message pop receipt.
            /// </summary>
            internal const string PopReceipt = "popreceipt";

            /// <summary>
            /// Query component for resource type.
            /// </summary>
            internal const string ResourceType = "restype";

            /// <summary>
            /// Query component for the operation (component) to access.
            /// </summary>
            internal const string Component = "comp";

            /// <summary>
            /// Query component for the copy ID.
            /// </summary>
            internal const string CopyId = "copyid";
        }
    }
}