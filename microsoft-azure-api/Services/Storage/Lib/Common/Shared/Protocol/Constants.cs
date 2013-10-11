// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Contains storage constants.
    /// </summary>
#if WINDOWS_RT
    internal
#else
    public
#endif
 static class Constants
    {
        /// <summary>
        /// Maximum number of shared access policy identifiers supported by server.
        /// </summary>
        public const int MaxSharedAccessPolicyIdentifiers = 5;

        /// <summary>
        /// Default Write Block Size used by Blob stream.
        /// </summary>
        public const int DefaultWriteBlockSizeBytes = (int)(4 * Constants.MB);

        /// <summary>
        /// The maximum size of a blob before it must be separated into blocks.
        /// </summary>
        public const long MaxSingleUploadBlobSize = 64 * MB;

        /// <summary>
        /// The maximum size of a single block.
        /// </summary>
        public const int MaxBlockSize = (int)(4 * Constants.MB);

        /// <summary>
        /// The maximum size of a range get operation that returns content MD5.
        /// </summary>
        public const int MaxRangeGetContentMD5Size = (int)(4 * Constants.MB);

        /// <summary>
        /// The maximum number of blocks.
        /// </summary>
        public const long MaxBlockNumber = 50000;

        /// <summary>
        /// The maximum size of a blob with blocks.
        /// </summary>
        public const long MaxBlobSize = MaxBlockNumber * MaxBlockSize;

        /// <summary>
        /// Default client side timeout for all service clients.
        /// </summary>
        public static readonly TimeSpan DefaultClientSideTimeout = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Default server side timeout for all service clients.
        /// </summary>
        public static readonly TimeSpan DefaultServerSideTimeout = TimeSpan.FromSeconds(90);

        /// <summary>
        /// Maximum Retry Policy back-off
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Backoff", Justification = "Reviewed")]
        public static readonly TimeSpan MaximumRetryBackoff = TimeSpan.FromHours(1);

        /// <summary>
        /// Maximum allowed timeout for any request.
        /// </summary>
        public static readonly TimeSpan MaximumAllowedTimeout = TimeSpan.FromSeconds(int.MaxValue);

        /// <summary>
        /// Default size of buffer for unknown sized requests.
        /// </summary>
        internal const int DefaultBufferSize = (int)(64 * KB);

        /// <summary>
        /// Common name to be used for all loggers.
        /// </summary>
        internal const string LogSourceName = "Microsoft.WindowsAzure.Storage";

        /// <summary>
        /// The size of a page in a PageBlob.
        /// </summary>
        internal const int PageSize = 512;

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
        public const string CommittedBlocksElement = "CommittedBlocks";

        /// <summary>
        /// XML element for uncommitted blocks.
        /// </summary>
        public const string UncommittedBlocksElement = "UncommittedBlocks";

        /// <summary>
        /// XML element for blocks.
        /// </summary>
        public const string BlockElement = "Block";

        /// <summary>
        /// XML element for names.
        /// </summary>
        public const string NameElement = "Name";

        /// <summary>
        /// XML element for sizes.
        /// </summary>
        public const string SizeElement = "Size";

        /// <summary>
        /// XML element for block lists.
        /// </summary>
        public const string BlockListElement = "BlockList";

        /// <summary>
        /// XML element for queue message lists.
        /// </summary>
        public const string MessagesElement = "QueueMessagesList";

        /// <summary>
        /// XML element for queue messages.
        /// </summary>
        public const string MessageElement = "QueueMessage";

        /// <summary>
        /// XML element for message IDs.
        /// </summary>
        public const string MessageIdElement = "MessageId";

        /// <summary>
        /// XML element for insertion times.
        /// </summary>
        public const string InsertionTimeElement = "InsertionTime";

        /// <summary>
        /// XML element for expiration times.
        /// </summary>
        public const string ExpirationTimeElement = "ExpirationTime";

        /// <summary>
        /// XML element for pop receipts.
        /// </summary>
        public const string PopReceiptElement = "PopReceipt";

        /// <summary>
        /// XML element for the time next visible fields.
        /// </summary>
        public const string TimeNextVisibleElement = "TimeNextVisible";

        /// <summary>
        /// XML element for message texts.
        /// </summary>
        public const string MessageTextElement = "MessageText";

        /// <summary>
        /// XML element for dequeue counts.
        /// </summary>
        public const string DequeueCountElement = "DequeueCount";

        /// <summary>
        /// XML element for page ranges.
        /// </summary>
        public const string PageRangeElement = "PageRange";

        /// <summary>
        /// XML element for page list elements.
        /// </summary>
        public const string PageListElement = "PageList";

        /// <summary>
        /// XML element for page range start elements.
        /// </summary>
        public const string StartElement = "Start";

        /// <summary>
        /// XML element for page range end elements.
        /// </summary>
        public const string EndElement = "End";

        /// <summary>
        /// XML element for delimiters.
        /// </summary>
        public const string DelimiterElement = "Delimiter";

        /// <summary>
        /// XML element for blob prefixes.
        /// </summary>
        public const string BlobPrefixElement = "BlobPrefix";

        /// <summary>
        /// XML element for content type fields.
        /// </summary>
        public const string CacheControlElement = "Cache-Control";

        /// <summary>
        /// XML element for content type fields.
        /// </summary>
        public const string ContentTypeElement = "Content-Type";

        /// <summary>
        /// XML element for content encoding fields.
        /// </summary>
        public const string ContentEncodingElement = "Content-Encoding";

        /// <summary>
        /// XML element for content language fields.
        /// </summary>
        public const string ContentLanguageElement = "Content-Language";

        /// <summary>
        /// XML element for content length fields.
        /// </summary>
        public const string ContentLengthElement = "Content-Length";

        /// <summary>
        /// XML element for content MD5 fields.
        /// </summary>
        public const string ContentMD5Element = "Content-MD5";

        /// <summary>
        /// XML element for enumeration results.
        /// </summary>
        public const string EnumerationResultsElement = "EnumerationResults";

        /// <summary>
        /// XML element for blobs.
        /// </summary>
        public const string BlobsElement = "Blobs";

        /// <summary>
        /// XML element for prefixes.
        /// </summary>
        public const string PrefixElement = "Prefix";

        /// <summary>
        /// XML element for maximum results.
        /// </summary>
        public const string MaxResultsElement = "MaxResults";

        /// <summary>
        /// XML element for markers.
        /// </summary>
        public const string MarkerElement = "Marker";

        /// <summary>
        /// XML element for the next marker.
        /// </summary>
        public const string NextMarkerElement = "NextMarker";

        /// <summary>
        /// XML element for the ETag.
        /// </summary>
        public const string EtagElement = "Etag";

        /// <summary>
        /// XML element for the last modified date.
        /// </summary>
        public const string LastModifiedElement = "Last-Modified";

        /// <summary>
        /// XML element for the Url.
        /// </summary>
        public const string UrlElement = "Url";

        /// <summary>
        /// XML element for blobs.
        /// </summary>
        public const string BlobElement = "Blob";

        /// <summary>
        /// XML element for copy ID.
        /// </summary>
        public const string CopyIdElement = "CopyId";

        /// <summary>
        /// XML element for copy status.
        /// </summary>
        public const string CopyStatusElement = "CopyStatus";

        /// <summary>
        /// XML element for copy source.
        /// </summary>
        public const string CopySourceElement = "CopySource";

        /// <summary>
        /// XML element for copy progress.
        /// </summary>
        public const string CopyProgressElement = "CopyProgress";

        /// <summary>
        /// XML element for copy completion time.
        /// </summary>
        public const string CopyCompletionTimeElement = "CopyCompletionTime";

        /// <summary>
        /// XML element for copy status description.
        /// </summary>
        public const string CopyStatusDescriptionElement = "CopyStatusDescription";

        /// <summary>
        /// Constant signaling a page blob.
        /// </summary>
        public const string PageBlobValue = "PageBlob";

        /// <summary>
        /// Constant signaling a block blob.
        /// </summary>
        public const string BlockBlobValue = "BlockBlob";

        /// <summary>
        /// Constant signaling the blob is locked.
        /// </summary>
        public const string LockedValue = "locked";

        /// <summary>
        /// Constant signaling the blob is unlocked.
        /// </summary>
        public const string UnlockedValue = "unlocked";

        /// <summary>
        /// Constant signaling the resource is available for leasing.
        /// </summary>
        public const string LeaseAvailableValue = "available";

        /// <summary>
        /// Constant signaling the resource is leased.
        /// </summary>
        public const string LeasedValue = "leased";

        /// <summary>
        /// Constant signaling the resource's lease has expired.
        /// </summary>
        public const string LeaseExpiredValue = "expired";

        /// <summary>
        /// Constant signaling the resource's lease is breaking.
        /// </summary>
        public const string LeaseBreakingValue = "breaking";

        /// <summary>
        /// Constant signaling the resource's lease is broken.
        /// </summary>
        public const string LeaseBrokenValue = "broken";

        /// <summary>
        /// Constant signaling the resource's lease is infinite.
        /// </summary>
        public const string LeaseInfiniteValue = "infinite";

        /// <summary>
        /// Constant signaling the resource's lease is fixed (finite).
        /// </summary>
        public const string LeaseFixedValue = "fixed";

        /// <summary>
        /// Constant for a pending copy.
        /// </summary>
        public const string CopyPendingValue = "pending";

        /// <summary>
        /// Constant for a successful copy.
        /// </summary>
        public const string CopySuccessValue = "success";

        /// <summary>
        /// Constant for an aborted copy.
        /// </summary>
        public const string CopyAbortedValue = "aborted";

        /// <summary>
        /// Constant for a failed copy.
        /// </summary>
        public const string CopyFailedValue = "failed";

        /// <summary>
        /// XML element for blob types.
        /// </summary>
        public const string BlobTypeElement = "BlobType";

        /// <summary>
        /// XML element for the lease status.
        /// </summary>
        public const string LeaseStatusElement = "LeaseStatus";

        /// <summary>
        /// XML element for the lease status.
        /// </summary>
        public const string LeaseStateElement = "LeaseState";

        /// <summary>
        /// XML element for the lease status.
        /// </summary>
        public const string LeaseDurationElement = "LeaseDuration";

        /// <summary>
        /// XML element for snapshots.
        /// </summary>
        public const string SnapshotElement = "Snapshot";

        /// <summary>
        /// XML element for containers.
        /// </summary>
        public const string ContainersElement = "Containers";

        /// <summary>
        /// XML element for a container.
        /// </summary>
        public const string ContainerElement = "Container";

        /// <summary>
        /// XML element for queues.
        /// </summary>
        public const string QueuesElement = "Queues";

        /// <summary>
        /// Version 2 of the XML element for the queue name.
        /// </summary>
        public const string QueueNameElement = "Name";

        /// <summary>
        /// XML element for the queue.
        /// </summary>
        public const string QueueElement = "Queue";

        /// <summary>
        /// XML element for properties.
        /// </summary>
        public const string PropertiesElement = "Properties";

        /// <summary>
        /// XML element for the metadata.
        /// </summary>
        public const string MetadataElement = "Metadata";

        /// <summary>
        /// XML element for an invalid metadata name.
        /// </summary>
        public const string InvalidMetadataName = "x-ms-invalid-name";

        /// <summary>
        /// XML element for maximum results.
        /// </summary>
        public const string MaxResults = "MaxResults";

        /// <summary>
        /// XML element for committed blocks.
        /// </summary>
        public const string CommittedElement = "Committed";

        /// <summary>
        /// XML element for uncommitted blocks.
        /// </summary>
        public const string UncommittedElement = "Uncommitted";

        /// <summary>
        /// XML element for the latest.
        /// </summary>
        public const string LatestElement = "Latest";

        /// <summary>
        /// XML element for signed identifiers.
        /// </summary>
        public const string SignedIdentifiers = "SignedIdentifiers";

        /// <summary>
        /// XML element for a signed identifier.
        /// </summary>
        public const string SignedIdentifier = "SignedIdentifier";

        /// <summary>
        /// XML element for access policies.
        /// </summary>
        public const string AccessPolicy = "AccessPolicy";

        /// <summary>
        /// XML attribute for IDs.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// XML element for the start time of an access policy.
        /// </summary>
        public const string Start = "Start";

        /// <summary>
        /// XML element for the end of an access policy.
        /// </summary>
        public const string Expiry = "Expiry";

        /// <summary>
        /// XML element for the permissions of an access policy.
        /// </summary>
        public const string Permission = "Permission";

        /// <summary>
        /// The URI path component to access the messages in a queue.
        /// </summary>
        public const string Messages = "messages";

        /// <summary>
        /// XML element for exception details.
        /// </summary>
        internal const string ErrorException = "exceptiondetails";

        /// <summary>
        /// XML root element for errors.
        /// </summary>
        public const string ErrorRootElement = "Error";

        /// <summary>
        /// XML element for error codes.
        /// </summary>
        public const string ErrorCode = "Code";

        /// <summary>
        /// XML element for error codes returned by the preview tenants.
        /// </summary>
        internal const string ErrorCodePreview = "code";

        /// <summary>
        /// XML element for error messages.
        /// </summary>
        public const string ErrorMessage = "Message";

        /// <summary>
        /// XML element for error messages.
        /// </summary>
        internal const string ErrorMessagePreview = "message";

        /// <summary>
        /// XML element for exception messages.
        /// </summary>
        public const string ErrorExceptionMessage = "ExceptionMessage";

        /// <summary>
        /// XML element for stack traces.
        /// </summary>
        public const string ErrorExceptionStackTrace = "StackTrace";

        /// <summary>
        /// Constants for HTTP headers.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Reviewed.")]
        public static class HeaderConstants
        {
            static HeaderConstants()
            {
#if WINDOWS_PHONE
                UserAgentComment = string.Format(CultureInfo.InvariantCulture, "(.NET CLR {0}; Windows Phone {1})", Environment.Version, Environment.OSVersion.Version);
#elif WINDOWS_RT
                UserAgentComment = "(Windows Runtime)";
#else
                UserAgentComment = string.Format(CultureInfo.InvariantCulture, "(.NET CLR {0}; {1} {2})", Environment.Version, Environment.OSVersion.Platform, Environment.OSVersion.Version);
#endif

                UserAgent = UserAgentProductName + "/" + UserAgentProductVersion + " " + UserAgentComment;
            }

            /// <summary>
            /// Specifies the value to use for UserAgent header.
            /// </summary>
            public static readonly string UserAgent;

            /// <summary>
            /// Specifies the comment to use for UserAgent header.
            /// </summary>
            public static readonly string UserAgentComment;

            /// <summary>
            /// Specifies the value to use for UserAgent header.
            /// </summary>
            public const string UserAgentProductName = "WA-Storage";

            /// <summary>
            /// Specifies the value to use for UserAgent header.
            /// </summary>
            public const string UserAgentProductVersion = "2.1.0.3";

            /// <summary>
            /// Master Windows Azure Storage header prefix.
            /// </summary>
            internal const string PrefixForStorageHeader = "x-ms-";

            /// <summary>
            /// True Header.
            /// </summary>
            public const string TrueHeader = "true";

            /// <summary>
            /// False Header.
            /// </summary>
            public const string FalseHeader = "false";

            /// <summary>
            /// Header prefix for properties.
            /// </summary>
            internal const string PrefixForStorageProperties = "x-ms-prop-";

            /// <summary>
            /// Header prefix for metadata.
            /// </summary>
            internal const string PrefixForStorageMetadata = "x-ms-meta-";

            /// <summary>
            /// Header that specifies content length.
            /// </summary>
            public const string ContentLengthHeader = "content-length";

            /// <summary>
            /// Header that specifies content language.
            /// </summary>
            public const string ContentLanguageHeader = "content-language";

            /// <summary>
            /// Header for data ranges.
            /// </summary>
            public const string RangeHeader = PrefixForStorageHeader + "range";

            /// <summary>
            /// Header for range content MD5.
            /// </summary>
            public const string RangeContentMD5Header = PrefixForStorageHeader + "range-get-content-md5";

            /// <summary>
            /// Header for storage version.
            /// </summary>
            public const string StorageVersionHeader = PrefixForStorageHeader + "version";

            /// <summary>
            /// Header for copy source.
            /// </summary>
            public const string CopySourceHeader = PrefixForStorageHeader + "copy-source";

            /// <summary>
            /// Header for the If-Match condition.
            /// </summary>
            public const string SourceIfMatchHeader = PrefixForStorageHeader + "source-if-match";

            /// <summary>
            /// Header for the If-Modified-Since condition.
            /// </summary>
            public const string SourceIfModifiedSinceHeader = PrefixForStorageHeader + "source-if-modified-since";

            /// <summary>
            /// Header for the If-None-Match condition.
            /// </summary>
            public const string SourceIfNoneMatchHeader = PrefixForStorageHeader + "source-if-none-match";

            /// <summary>
            /// Header for the If-Unmodified-Since condition.
            /// </summary>
            public const string SourceIfUnmodifiedSinceHeader = PrefixForStorageHeader + "source-if-unmodified-since";

            /// <summary>
            /// Header for the If-Sequence-Number-LE condition.
            /// </summary>
            public const string IfSequenceNumberLEHeader = PrefixForStorageHeader + "if-sequence-number-le";

            /// <summary>
            /// Header for the If-Sequence-Number-LT condition.
            /// </summary>
            public const string IfSequenceNumberLTHeader = PrefixForStorageHeader + "if-sequence-number-lt";

            /// <summary>
            /// Header for the If-Sequence-Number-EQ condition.
            /// </summary>
            public const string IfSequenceNumberEqHeader = PrefixForStorageHeader + "if-sequence-number-eq";

            /// <summary>
            /// Header for the blob type.
            /// </summary>
            public const string BlobType = PrefixForStorageHeader + "blob-type";

            /// <summary>
            /// Header for snapshots.
            /// </summary>
            public const string SnapshotHeader = PrefixForStorageHeader + "snapshot";

            /// <summary>
            /// Header to delete snapshots.
            /// </summary>
            public const string DeleteSnapshotHeader = PrefixForStorageHeader + "delete-snapshots";

            /// <summary>
            /// Header that specifies approximate message count of a queue.
            /// </summary>
            public const string ApproximateMessagesCount = PrefixForStorageHeader + "approximate-messages-count";

            /// <summary>
            /// Header that specifies blob caching control.
            /// </summary>
            public const string CacheControlHeader = PrefixForStorageHeader + "blob-cache-control";

            /// <summary>
            /// Header that specifies blob content encoding.
            /// </summary>
            public const string ContentEncodingHeader = PrefixForStorageHeader + "blob-content-encoding";

            /// <summary>
            /// Header that specifies blob content language.
            /// </summary>
            public const string BlobContentLanguageHeader = PrefixForStorageHeader + "blob-content-language";

            /// <summary>
            /// Header that specifies blob content MD5.
            /// </summary>
            public const string BlobContentMD5Header = PrefixForStorageHeader + "blob-content-md5";

            /// <summary>
            /// Header that specifies blob content type.
            /// </summary>
            public const string ContentTypeHeader = PrefixForStorageHeader + "blob-content-type";

            /// <summary>
            /// Header that specifies blob content length.
            /// </summary>
            public const string BlobContentLengthHeader = PrefixForStorageHeader + "blob-content-length";

            /// <summary>
            /// Header that specifies blob sequence number.
            /// </summary>
            public const string BlobSequenceNumber = PrefixForStorageHeader + "blob-sequence-number";

            /// <summary>
            /// Header that specifies sequence number action.
            /// </summary>
            public const string SequenceNumberAction = PrefixForStorageHeader + "sequence-number-action";

            /// <summary>
            /// Header that specifies lease ID.
            /// </summary>
            public const string LeaseIdHeader = PrefixForStorageHeader + "lease-id";

            /// <summary>
            /// Header that specifies lease status.
            /// </summary>
            public const string LeaseStatus = PrefixForStorageHeader + "lease-status";

            /// <summary>
            /// Header that specifies lease status.
            /// </summary>
            public const string LeaseState = PrefixForStorageHeader + "lease-state";

            /// <summary>
            /// Header that specifies page write mode.
            /// </summary>
            public const string PageWrite = PrefixForStorageHeader + "page-write";

            /// <summary>
            /// Header that specifies the date.
            /// </summary>
            public const string Date = PrefixForStorageHeader + "date";

            /// <summary>
            /// Header indicating the request ID.
            /// </summary>
            public const string RequestIdHeader = PrefixForStorageHeader + "request-id";

            /// <summary>
            /// Header indicating the client request ID.
            /// </summary>
            public const string ClientRequestIdHeader = PrefixForStorageHeader + "client-request-id";

            /// <summary>
            /// Header that specifies public access to blobs.
            /// </summary>
            public const string BlobPublicAccess = PrefixForStorageHeader + "blob-public-access";

            /// <summary>
            /// Format string for specifying ranges.
            /// </summary>
            public const string RangeHeaderFormat = "bytes={0}-{1}";

            /// <summary>
            /// Current storage version header value.
            /// Every time this version changes, assembly version needs to be updated as well.
            /// </summary>
            internal const string TargetStorageVersion = "2012-02-12";

            /// <summary>
            /// Specifies the page blob type.
            /// </summary>
            public const string PageBlob = "PageBlob";

            /// <summary>
            /// Specifies the block blob type.
            /// </summary>
            public const string BlockBlob = "BlockBlob";

            /// <summary>
            /// Specifies only snapshots are to be included.
            /// </summary>
            public const string SnapshotsOnlyValue = "only";

            /// <summary>
            /// Specifies snapshots are to be included.
            /// </summary>
            public const string IncludeSnapshotsValue = "include";

            /// <summary>
            /// Header that specifies the pop receipt for a message.
            /// </summary>
            public const string PopReceipt = PrefixForStorageHeader + "popreceipt";

            /// <summary>
            /// Header that specifies the next visible time for a message.
            /// </summary>
            public const string NextVisibleTime = PrefixForStorageHeader + "time-next-visible";

            /// <summary>
            /// Header that specifies whether to peek-only.
            /// </summary>
            public const string PeekOnly = "peekonly";

            /// <summary>
            /// Header that specifies whether data in the container may be accessed publicly and what level of access is to be allowed.
            /// </summary>
            public const string ContainerPublicAccessType = PrefixForStorageHeader + "blob-public-access";

            /// <summary>
            /// Header that specifies the lease action to perform.
            /// </summary>
            public const string LeaseActionHeader = PrefixForStorageHeader + "lease-action";

            /// <summary>
            /// Header that specifies the proposed lease ID for a leasing operation.
            /// </summary>
            public const string ProposedLeaseIdHeader = PrefixForStorageHeader + "proposed-lease-id";

            /// <summary>
            /// Header that specifies the duration of a lease.
            /// </summary>
            public const string LeaseDurationHeader = PrefixForStorageHeader + "lease-duration";

            /// <summary>
            /// Header that specifies the break period of a lease.
            /// </summary>
            public const string LeaseBreakPeriodHeader = PrefixForStorageHeader + "lease-break-period";

            /// <summary>
            /// Header that specifies the remaining lease time.
            /// </summary>
            public const string LeaseTimeHeader = PrefixForStorageHeader + "lease-time";

            /// <summary>
            /// Header that specifies the key name for explicit keys.
            /// </summary>
            public const string KeyNameHeader = PrefixForStorageHeader + "key-name";

            /// <summary>
            /// Header that specifies the copy ID.
            /// </summary>
            public const string CopyIdHeader = PrefixForStorageHeader + "copy-id";

            /// <summary>
            /// Header that specifies the copy last modified time.
            /// </summary>
            public const string CopyCompletionTimeHeader = PrefixForStorageHeader + "copy-completion-time";

            /// <summary>
            /// Header that specifies the copy status.
            /// </summary>
            public const string CopyStatusHeader = PrefixForStorageHeader + "copy-status";

            /// <summary>
            /// Header that specifies the copy progress.
            /// </summary>
            public const string CopyProgressHeader = PrefixForStorageHeader + "copy-progress";

            /// <summary>
            /// Header that specifies a copy error message.
            /// </summary>
            public const string CopyDescriptionHeader = PrefixForStorageHeader + "copy-status-description";

            /// <summary>
            /// Header that specifies the copy action.
            /// </summary>
            public const string CopyActionHeader = PrefixForStorageHeader + "copy-action";

            /// <summary>
            /// The value of the copy action header that signifies an abort operation.
            /// </summary>
            public const string CopyActionAbort = "abort";
        }

        /// <summary>
        /// Constants for query strings.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Reviewed.")]
        public static class QueryConstants
        {
            /// <summary>
            /// Query component for snapshot time.
            /// </summary>
            public const string Snapshot = "snapshot";

            /// <summary>
            /// Query component for the signed SAS start time.
            /// </summary>
            public const string SignedStart = "st";

            /// <summary>
            /// Query component for the signed SAS expiry time.
            /// </summary>
            public const string SignedExpiry = "se";

            /// <summary>
            /// Query component for the signed SAS resource.
            /// </summary>
            public const string SignedResource = "sr";

            /// <summary>
            /// Query component for the SAS table name.
            /// </summary>
            public const string SasTableName = "tn";

            /// <summary>
            /// Query component for the signed SAS permissions.
            /// </summary>
            public const string SignedPermissions = "sp";

            /// <summary>
            /// Query component for the SAS start partition key.
            /// </summary>
            public const string StartPartitionKey = "spk";

            /// <summary>
            /// Query component for the SAS start row key.
            /// </summary>
            public const string StartRowKey = "srk";

            /// <summary>
            /// Query component for the SAS end partition key.
            /// </summary>
            public const string EndPartitionKey = "epk";

            /// <summary>
            /// Query component for the SAS end row key.
            /// </summary>
            public const string EndRowKey = "erk";

            /// <summary>
            /// Query component for the signed SAS identifier.
            /// </summary>
            public const string SignedIdentifier = "si";

            /// <summary>
            /// Query component for the signing SAS key.
            /// </summary>
            public const string SignedKey = "sk";

            /// <summary>
            /// Query component for the signed SAS version.
            /// </summary>
            public const string SignedVersion = "sv";

            /// <summary>
            /// Query component for SAS signature.
            /// </summary>
            public const string Signature = "sig";

            /// <summary>
            /// Query component for message time-to-live.
            /// </summary>
            public const string MessageTimeToLive = "messagettl";

            /// <summary>
            /// Query component for message visibility timeout.
            /// </summary>
            public const string VisibilityTimeout = "visibilitytimeout";

            /// <summary>
            /// Query component for the number of messages.
            /// </summary>
            [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Num", Justification = "Reviewed : Num is allowed in an identifier name.")]
            public const string NumOfMessages = "numofmessages";

            /// <summary>
            /// Query component for message pop receipt.
            /// </summary>
            public const string PopReceipt = "popreceipt";

            /// <summary>
            /// Query component for resource type.
            /// </summary>
            public const string ResourceType = "restype";

            /// <summary>
            /// Query component for the operation (component) to access.
            /// </summary>
            public const string Component = "comp";

            /// <summary>
            /// Query component for the copy ID.
            /// </summary>
            public const string CopyId = "copyid";
        }

        /// <summary>
        /// Constants for Result Continuations
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible", Justification = "Reviewed.")]
        public static class ContinuationConstants
        {
            /// <summary>
            /// Top Element for Continuation Tokens
            /// </summary>
            public const string ContinuationTopElement = "ContinuationToken";

            /// <summary>
            /// XML element for the next marker.
            /// </summary>
            public const string NextMarkerElement = "NextMarker";

            /// <summary>
            /// XML element for the next partition key.
            /// </summary>
            public const string NextPartitionKeyElement = "NextPartitionKey";

            /// <summary>
            /// XML element for the next row key.
            /// </summary>
            public const string NextRowKeyElement = "NextRowKey";

            /// <summary>
            /// XML element for the next table name.
            /// </summary>
            public const string NextTableNameElement = "NextTableName";

            /// <summary>
            /// XML element for the token version.
            /// </summary>
            public const string VersionElement = "Version";

            /// <summary>
            /// Stores the current token version value.
            /// </summary>
            public const string CurrentVersion = "2.0";

            /// <summary>
            /// XML element for the token type.
            /// </summary>
            public const string TypeElement = "Type";

            /// <summary>
            /// Specifies the blob continuation token type.
            /// </summary>
            public const string BlobType = "Blob";

            /// <summary>
            /// Specifies the queue continuation token type.
            /// </summary>
            public const string QueueType = "Queue";

            /// <summary>
            /// Specifies the table continuation token type.
            /// </summary>
            public const string TableType = "Table";
        }
    }
}