// -----------------------------------------------------------------------------------------
// <copyright file="BlobHttpRequestMessageFactory.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static class BlobHttpRequestMessageFactory
    {
        /// <summary>
        /// Constructs a web request to create a new block blob or page blob, or to update the content 
        /// of an existing block blob. 
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The properties to set for the blob.</param>
        /// <param name="blobType">The type of the blob.</param>
        /// <param name="pageBlobSize">For a page blob, the size of the blob. This parameter is ignored
        /// for block blobs.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Put(Uri uri, int? timeout, BlobProperties properties, BlobType blobType, long pageBlobSize, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            if (blobType == BlobType.Unspecified)
            {
                throw new InvalidOperationException(SR.UndefinedBlobType);
            }

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, null /* builder */, content, operationContext);

            if (properties.CacheControl != null)
            {
                request.Headers.CacheControl = CacheControlHeaderValue.Parse(properties.CacheControl);
            }

            if (content != null)
            {
                if (properties.ContentType != null)
                {
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse(properties.ContentType);
                }

                if (properties.ContentMD5 != null)
                {
                    content.Headers.ContentMD5 = Convert.FromBase64String(properties.ContentMD5);
                }

                if (properties.ContentLanguage != null)
                {
                    content.Headers.ContentLanguage.Add(properties.ContentLanguage);
                }

                if (properties.ContentEncoding != null)
                {
                    content.Headers.ContentEncoding.Add(properties.ContentEncoding);
                }
            }

            if (blobType == BlobType.PageBlob)
            {
                request.Headers.Add(Constants.HeaderConstants.BlobType, Constants.HeaderConstants.PageBlob);
                request.Headers.Add(Constants.HeaderConstants.Size, pageBlobSize.ToString(NumberFormatInfo.InvariantInfo));
                properties.Length = pageBlobSize;
            }
            else
            {
                request.Headers.Add(Constants.HeaderConstants.BlobType, Constants.HeaderConstants.BlockBlob);
            }

            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Adds the snapshot.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="snapshot">The snapshot version, if the blob is a snapshot.</param>
        private static void AddSnapshot(UriQueryBuilder builder, DateTimeOffset? snapshot)
        {
            if (snapshot.HasValue)
            {
                builder.Add("snapshot", BlobRequest.ConvertDateTimeToSnapshotString(snapshot.Value));
            }
        }

        /// <summary>
        /// Constructs a web request to return the list of valid page ranges for a page blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="offset">The starting offset of the data range over which to list page ranges, in bytes. Must be a multiple of 512.</param>
        /// <param name="count">The length of the data range over which to list page ranges, in bytes. Must be a multiple of 512.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage GetPageRanges(Uri uri, int? timeout, DateTimeOffset? snapshot, long? offset, long? count, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            if (offset.HasValue)
            {
                CommonUtility.AssertNotNull("count", count);
            }

            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "pagelist");
            BlobHttpRequestMessageFactory.AddSnapshot(builder, snapshot);

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            AddRange(request, offset, count);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Adds the Range Header for Blob Service Operations.
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="offset">Starting byte of the range</param>
        /// <param name="count">Number of bytes in the range</param>
        private static void AddRange(HttpRequestMessage request, long? offset, long? count)
        {
            if (count.HasValue)
            {
                CommonUtility.AssertNotNull("offset", offset);
                CommonUtility.AssertInBounds("count", count.Value, 1, long.MaxValue);
            }

            if (offset.HasValue)
            {
                string rangeStart = offset.ToString();
                string rangeEnd = string.Empty;
                if (count.HasValue)
                {
                    rangeEnd = (offset + count.Value - 1).ToString();
                }

                string rangeHeaderValue = string.Format(CultureInfo.InvariantCulture, Constants.HeaderConstants.RangeHeaderFormat, rangeStart, rangeEnd);
                request.Headers.Add(Constants.HeaderConstants.RangeHeader, rangeHeaderValue);
            }
        }

        /// <summary>
        /// Constructs a web request to return the blob's system properties.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpRequestMessage GetProperties(Uri uri, int? timeout, DateTimeOffset? snapshot, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            BlobHttpRequestMessageFactory.AddSnapshot(builder, snapshot);

            HttpRequestMessage request = HttpRequestMessageFactory.GetProperties(uri, timeout, builder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set system properties for a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The blob's properties.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage SetProperties(Uri uri, int? timeout, BlobProperties properties, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            request.AddOptionalHeader(Constants.HeaderConstants.CacheControlHeader, properties.CacheControl);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentEncodingHeader, properties.ContentEncoding);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentLanguageHeader, properties.ContentLanguage);
            request.AddOptionalHeader(Constants.HeaderConstants.BlobContentMD5Header, properties.ContentMD5);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentTypeHeader, properties.ContentType);

            request.ApplyAccessCondition(accessCondition);

            return request;
        }

        /// <summary>
        /// Constructs a web request to resize a page blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="newBlobSize">The new blob size, if the blob is a page blob. Set this parameter to <c>null</c> to keep the existing blob size.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Resize(Uri uri, int? timeout, long newBlobSize, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            request.Headers.Add(Constants.HeaderConstants.Size, newBlobSize.ToString(NumberFormatInfo.InvariantInfo));

            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set a page blob's sequence number.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="sequenceNumberAction">A value of type <see cref="SequenceNumberAction"/>, indicating the operation to perform on the sequence number.</param>
        /// <param name="sequenceNumber">The sequence number. Set this parameter to <c>null</c> if this operation is an increment action.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage SetSequenceNumber(Uri uri, int? timeout, SequenceNumberAction sequenceNumberAction, long? sequenceNumber, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            CommonUtility.AssertInBounds("sequenceNumberAction", sequenceNumberAction, SequenceNumberAction.Max, SequenceNumberAction.Increment);
            if (sequenceNumberAction == SequenceNumberAction.Increment)
            {
                if (sequenceNumber.HasValue)
                {
                    throw new ArgumentException(SR.BlobInvalidSequenceNumber, "sequenceNumber");
                }
            }
            else
            {
                CommonUtility.AssertNotNull("sequenceNumber", sequenceNumber);
                CommonUtility.AssertInBounds("sequenceNumber", sequenceNumber.Value, 0);
            }

            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            request.Headers.Add(Constants.HeaderConstants.SequenceNumberAction, sequenceNumberAction.ToString());
            if (sequenceNumberAction != SequenceNumberAction.Increment)
            {
                request.Headers.Add(Constants.HeaderConstants.BlobSequenceNumber, sequenceNumber.Value.ToString());
            }

            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to return the user-defined metadata for the blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpRequestMessage GetMetadata(Uri uri, int? timeout, DateTimeOffset? snapshot, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            BlobHttpRequestMessageFactory.AddSnapshot(builder, snapshot);

            HttpRequestMessage request = HttpRequestMessageFactory.GetMetadata(uri, timeout, builder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set user-defined metadata for the blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpRequestMessage SetMetadata(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.SetMetadata(uri, timeout, null /* builder */, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Adds user-defined metadata to the request as one or more name-value pairs.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="metadata">The user-defined metadata.</param>
        public static void AddMetadata(HttpRequestMessage request, IDictionary<string, string> metadata)
        {
            HttpRequestMessageFactory.AddMetadata(request, metadata);
        }

        /// <summary>
        /// Adds user-defined metadata to the request as a single name-value pair.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="name">The metadata name.</param>
        /// <param name="value">The metadata value.</param>
        public static void AddMetadata(HttpRequestMessage request, string name, string value)
        {
            HttpRequestMessageFactory.AddMetadata(request, name, value);
        }

        /// <summary>
        /// Constructs a web request to delete a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="deleteSnapshotsOption">A set of options indicating whether to delete only blobs, only snapshots, or both.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Delete(Uri uri, int? timeout, DateTimeOffset? snapshot, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            if ((snapshot != null) && (deleteSnapshotsOption != DeleteSnapshotsOption.None))
            {
                throw new InvalidOperationException(string.Format(SR.DeleteSnapshotsNotValidError, "deleteSnapshotsOption", "snapshot"));
            }

            UriQueryBuilder builder = new UriQueryBuilder();
            BlobHttpRequestMessageFactory.AddSnapshot(builder, snapshot);

            HttpRequestMessage request = HttpRequestMessageFactory.Delete(uri, timeout, builder, content, operationContext);

            switch (deleteSnapshotsOption)
            {
                case DeleteSnapshotsOption.None:
                    break; // nop

                case DeleteSnapshotsOption.IncludeSnapshots:
                    request.Headers.Add(
                        Constants.HeaderConstants.DeleteSnapshotHeader,
                        Constants.HeaderConstants.IncludeSnapshotsValue);
                    break;

                case DeleteSnapshotsOption.DeleteSnapshotsOnly:
                    request.Headers.Add(
                        Constants.HeaderConstants.DeleteSnapshotHeader,
                        Constants.HeaderConstants.SnapshotsOnlyValue);
                    break;
            }

            request.ApplyAccessCondition(accessCondition);

            return request;
        }

        /// <summary>
        /// Constructs a web request to create a snapshot of a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Snapshot(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "snapshot");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to use to acquire, renew, change, release or break the lease for the blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="action">The lease action to perform.</param>
        /// <param name="proposedLeaseId">A lease ID to propose for the result of an acquire or change operation,
        /// or null if no ID is proposed for an acquire operation. This should be null for renew, release, and break operations.</param>
        /// <param name="leaseDuration">The lease duration, in seconds, for acquire operations.
        /// If this is -1 then an infinite duration is specified. This should be null for renew, change, release, and break operations.</param>
        /// <param name="leaseBreakPeriod">The amount of time to wait, in seconds, after a break operation before the lease is broken.
        /// If this is null then the default time is used. This should be null for acquire, renew, change, and release operations.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Lease(Uri uri, int? timeout, LeaseAction action, string proposedLeaseId, int? leaseDuration, int? leaseBreakPeriod, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "lease");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);

            // Add lease headers
            BlobHttpRequestMessageFactory.AddLeaseAction(request, action);
            BlobHttpRequestMessageFactory.AddLeaseDuration(request, leaseDuration);
            BlobHttpRequestMessageFactory.AddProposedLeaseId(request, proposedLeaseId);
            BlobHttpRequestMessageFactory.AddLeaseBreakPeriod(request, leaseBreakPeriod);

            return request;
        }

        /// <summary>
        /// Adds a proposed lease id to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="proposedLeaseId">The proposed lease id.</param>
        internal static void AddProposedLeaseId(HttpRequestMessage request, string proposedLeaseId)
        {
            request.AddOptionalHeader(Constants.HeaderConstants.ProposedLeaseIdHeader, proposedLeaseId);
        }

        /// <summary>
        /// Adds a lease duration to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseDuration">The lease duration.</param>
        internal static void AddLeaseDuration(HttpRequestMessage request, int? leaseDuration)
        {
            request.AddOptionalHeader(Constants.HeaderConstants.LeaseDurationHeader, leaseDuration);
        }

        /// <summary>
        /// Adds a lease break period to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseBreakPeriod">The lease break period.</param>
        internal static void AddLeaseBreakPeriod(HttpRequestMessage request, int? leaseBreakPeriod)
        {
            request.AddOptionalHeader(Constants.HeaderConstants.LeaseBreakPeriodHeader, leaseBreakPeriod);
        }

        /// <summary>
        /// Adds a lease action to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseAction">The lease action.</param>
        internal static void AddLeaseAction(HttpRequestMessage request, LeaseAction leaseAction)
        {
            request.Headers.Add(Constants.HeaderConstants.LeaseActionHeader, leaseAction.ToString().ToLower());
        }

        /// <summary>
        /// Constructs a web request to write a block to a block blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="blockId">The block ID for this block.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage PutBlock(Uri uri, int? timeout, string blockId, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "block");
            builder.Add("blockid", blockId);

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            request.ApplyLeaseId(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to create or update a blob by committing a block list.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The properties to set for the blob.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpRequestMessage PutBlockList(Uri uri, int? timeout, BlobProperties properties, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "blocklist");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            request.AddOptionalHeader(Constants.HeaderConstants.CacheControlHeader, properties.CacheControl);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentTypeHeader, properties.ContentType);
            request.AddOptionalHeader(Constants.HeaderConstants.BlobContentMD5Header, properties.ContentMD5);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentLanguageHeader, properties.ContentLanguage);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentEncodingHeader, properties.ContentEncoding);

            request.ApplyAccessCondition(accessCondition);

            return request;
        }

        /// <summary>
        /// Constructs a web request to return the list of blocks for a block blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="typesOfBlocks">The types of blocks to include in the list: committed, uncommitted, or both.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage GetBlockList(Uri uri, int? timeout, DateTimeOffset? snapshot, BlockListingFilter typesOfBlocks, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "blocklist");
            builder.Add("blocklisttype", typesOfBlocks.ToString());
            BlobHttpRequestMessageFactory.AddSnapshot(builder, snapshot);

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to write or clear a range of pages in a page blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The blob's properties.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage PutPage(Uri uri, int? timeout, PageRange pageRange, PageWrite pageWrite, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "page");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            request.Headers.Add(Constants.HeaderConstants.RangeHeader, pageRange.ToString());
            request.Headers.Add(Constants.HeaderConstants.PageWrite, pageWrite.ToString());

            request.ApplyAccessCondition(accessCondition);
            request.ApplySequenceNumberCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to copy a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the destination blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="source">The absolute URI to the source blob, including any necessary authentication parameters.</param>
        /// <param name="sourceAccessCondition">The access condition to apply to the source blob.</param>
        /// <param name="destAccessCondition">The access condition to apply to the destination blob.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage CopyFrom(Uri uri, int? timeout, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, null /* builder */, content, operationContext);

            request.Headers.Add(Constants.HeaderConstants.CopySourceHeader, source.AbsoluteUri);
            request.ApplyAccessCondition(destAccessCondition);
            request.ApplyAccessConditionToSource(sourceAccessCondition);

            return request;
        }

        /// <summary>
        /// Generates a web request to abort a copy operation.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="copyId">The ID string of the copy operation to be aborted.</param>
        /// <param name="accessCondition">The access condition to apply to the request.
        ///     Only lease conditions are supported for this operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpRequestMessage AbortCopy(Uri uri, int? timeout, string copyId, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "copy");
            builder.Add(Constants.QueryConstants.CopyId, copyId);

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            request.Headers.Add(Constants.HeaderConstants.CopyActionHeader, Constants.HeaderConstants.CopyActionAbort);
            request.ApplyAccessCondition(accessCondition);

            return request;
        }

        /// <summary>
        /// Constructs a web request to get the blob's content, properties, and metadata.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot version, if the blob is a snapshot.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpRequestMessage Get(Uri uri, int? timeout, DateTimeOffset? snapshot, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            if (snapshot.HasValue)
            {
                builder.Add("snapshot", BlobRequest.ConvertDateTimeToSnapshotString(snapshot.Value));
            }

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to return a specified range of the blob's content, together with its properties and metadata.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="snapshot">The snapshot version, if the blob is a snapshot.</param>
        /// <param name="offset">The byte offset at which to begin returning content.</param>
        /// <param name="count">The number of bytes to return, or null to return all bytes through the end of the blob.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Get(Uri uri, int? timeout, DateTimeOffset? snapshot, long? offset, long? count, bool rangeContentMD5, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            if (offset.HasValue && offset.Value < 0)
            {
                CommonUtility.ArgumentOutOfRange("offset", offset);
            }
            
            if (offset.HasValue && rangeContentMD5)
            {
                CommonUtility.AssertNotNull("count", count);
                CommonUtility.AssertInBounds("count", count.Value, 1, Constants.MaxBlockSize);
            }

            HttpRequestMessage request = Get(uri, timeout, snapshot, accessCondition, content, operationContext);
            AddRange(request, offset, count);

            if (offset.HasValue && rangeContentMD5)
            {
                request.Headers.Add(Constants.HeaderConstants.RangeContentMD5Header, Constants.HeaderConstants.TrueHeader);
            }

            return request;
        }

        /// <summary>
        /// Constructs a web request to get the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A HttpRequestMessage to get the service properties.</returns>
        public static HttpRequestMessage GetServiceProperties(Uri uri, int? timeout, OperationContext operationContext)
        {
            return HttpRequestMessageFactory.GetServiceProperties(uri, timeout, operationContext);
        }

         /// <summary>
        /// Creates a web request to set the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to set the service properties.</returns>
        internal static HttpRequestMessage SetServiceProperties(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            return HttpRequestMessageFactory.SetServiceProperties(uri, timeout, content, operationContext);   
        }
    }
}
