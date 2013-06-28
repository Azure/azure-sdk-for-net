//-----------------------------------------------------------------------
// <copyright file="BlobHttpWebRequestFactory.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// A factory class for constructing a web request for working with blobs in the Blob service.
    /// </summary>
    public static class BlobHttpWebRequestFactory
    {
        /// <summary>
        /// Creates a web request to get the properties of the Blob service.
        /// </summary>
        /// <param name="uri">The absolute URI to the Blob service.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to get the Blob service properties.
        /// </returns>
        public static HttpWebRequest GetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.GetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Creates a web request to set the properties of the Blob service.
        /// </summary>
        /// <param name="uri">The absolute URI to the Blob service.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to set the Blob service properties.
        /// </returns>
        public static HttpWebRequest SetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.SetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Writes Blob service properties to a stream, formatted in XML.
        /// </summary>
        /// <param name="properties">The service properties to format and write to the stream.</param>
        /// <param name="outputStream">The stream to which the formatted properties are to be written.</param>
        public static void WriteServiceProperties(ServiceProperties properties, Stream outputStream)
        {
            properties.WriteServiceProperties(outputStream);
        }

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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Put(Uri uri, int? timeout, BlobProperties properties, BlobType blobType, long pageBlobSize, AccessCondition accessCondition, OperationContext operationContext)
        {
            if (blobType == BlobType.Unspecified)
            {
                throw new InvalidOperationException(SR.UndefinedBlobType);
            }

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, null /* builder */, operationContext);

            if (properties.CacheControl != null)
            {
                request.Headers.Add(HttpRequestHeader.CacheControl, properties.CacheControl);
            }

            if (properties.ContentType != null)
            {
                // Setting it using Headers is an exception
                request.ContentType = properties.ContentType;
            }

            if (properties.ContentMD5 != null)
            {
                request.Headers.Add(HttpRequestHeader.ContentMd5, properties.ContentMD5);
            }

            if (properties.ContentLanguage != null)
            {
                request.Headers.Add(HttpRequestHeader.ContentLanguage, properties.ContentLanguage);
            }

            if (properties.ContentEncoding != null)
            {
                request.Headers.Add(HttpRequestHeader.ContentEncoding, properties.ContentEncoding);
            }

            if (blobType == BlobType.PageBlob)
            {
                request.ContentLength = 0;
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
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
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
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest GetPageRanges(Uri uri, int? timeout, DateTimeOffset? snapshot, long? offset, long? count, AccessCondition accessCondition, OperationContext operationContext)
        {
            if (offset.HasValue)
            {
                CommonUtils.AssertNotNull("count", count);
            }

            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "pagelist");
            BlobHttpWebRequestFactory.AddSnapshot(builder, snapshot);

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
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
        private static void AddRange(HttpWebRequest request, long? offset, long? count)
        {
            if (count.HasValue)
            {
                CommonUtils.AssertNotNull("offset", offset);
                CommonUtils.AssertInBounds("count", count.Value, 1, long.MaxValue);
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest GetProperties(Uri uri, int? timeout, DateTimeOffset? snapshot, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            BlobHttpWebRequestFactory.AddSnapshot(builder, snapshot);

            HttpWebRequest request = HttpWebRequestFactory.GetProperties(uri, timeout, builder, operationContext);
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest SetProperties(Uri uri, int? timeout, BlobProperties properties, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;

            request.AddOptionalHeader(Constants.HeaderConstants.CacheControlHeader, properties.CacheControl);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentEncodingHeader, properties.ContentEncoding);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentLanguageHeader, properties.ContentLanguage);
            request.AddOptionalHeader(Constants.HeaderConstants.BlobContentMD5Header, properties.ContentMD5);
            request.AddOptionalHeader(Constants.HeaderConstants.ContentTypeHeader, properties.ContentType);

            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to resize a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="newBlobSize">The new blob size, if the blob is a page blob. Set this parameter to <c>null</c> to keep the existing blob size.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Resize(Uri uri, int? timeout, long newBlobSize, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;

            request.Headers.Add(Constants.HeaderConstants.Size, newBlobSize.ToString(NumberFormatInfo.InvariantInfo));

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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest GetMetadata(Uri uri, int? timeout, DateTimeOffset? snapshot, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            BlobHttpWebRequestFactory.AddSnapshot(builder, snapshot);

            HttpWebRequest request = HttpWebRequestFactory.GetMetadata(uri, timeout, builder, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set user-defined metadata for the blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest SetMetadata(Uri uri, int? timeout, AccessCondition accessCondition, OperationContext operationContext)
        {
            var request = HttpWebRequestFactory.SetMetadata(uri, timeout, null /* builder */, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Adds user-defined metadata to the request as one or more name-value pairs.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="metadata">The user-defined metadata.</param>
        public static void AddMetadata(HttpWebRequest request, IDictionary<string, string> metadata)
        {
            HttpWebRequestFactory.AddMetadata(request, metadata);
        }

        /// <summary>
        /// Adds user-defined metadata to the request as a single name-value pair.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="name">The metadata name.</param>
        /// <param name="value">The metadata value.</param>
        public static void AddMetadata(HttpWebRequest request, string name, string value)
        {
            HttpWebRequestFactory.AddMetadata(request, name, value);
        }

        /// <summary>
        /// Constructs a web request to delete a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="deleteSnapshotsOption">A set of options indicating whether to delete only blobs, only snapshots, or both.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Delete(Uri uri, int? timeout, DateTimeOffset? snapshot, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, OperationContext operationContext)
        {
            if ((snapshot != null) && (deleteSnapshotsOption != DeleteSnapshotsOption.None))
            {
                throw new InvalidOperationException(string.Format(SR.DeleteSnapshotsNotValidError, "deleteSnapshotsOption", "snapshot"));
            }

            UriQueryBuilder builder = new UriQueryBuilder();
            BlobHttpWebRequestFactory.AddSnapshot(builder, snapshot);

            HttpWebRequest request = HttpWebRequestFactory.Delete(uri, builder, timeout, operationContext);

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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Snapshot(Uri uri, int? timeout, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "snapshot");

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Lease(Uri uri, int? timeout, LeaseAction action, string proposedLeaseId, int? leaseDuration, int? leaseBreakPeriod, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "lease");

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
            request.ApplyAccessCondition(accessCondition);

            // Add lease headers
            BlobHttpWebRequestFactory.AddLeaseAction(request, action);
            BlobHttpWebRequestFactory.AddLeaseDuration(request, leaseDuration);
            BlobHttpWebRequestFactory.AddProposedLeaseId(request, proposedLeaseId);
            BlobHttpWebRequestFactory.AddLeaseBreakPeriod(request, leaseBreakPeriod);

            return request;
        }

        /// <summary>
        /// Adds a proposed lease id to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="proposedLeaseId">The proposed lease id.</param>
        internal static void AddProposedLeaseId(HttpWebRequest request, string proposedLeaseId)
        {
            request.AddOptionalHeader(Constants.HeaderConstants.ProposedLeaseIdHeader, proposedLeaseId);
        }

        /// <summary>
        /// Adds a lease duration to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseDuration">The lease duration.</param>
        internal static void AddLeaseDuration(HttpWebRequest request, int? leaseDuration)
        {
            request.AddOptionalHeader(Constants.HeaderConstants.LeaseDurationHeader, leaseDuration);
        }

        /// <summary>
        /// Adds a lease break period to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseBreakPeriod">The lease break period.</param>
        internal static void AddLeaseBreakPeriod(HttpWebRequest request, int? leaseBreakPeriod)
        {
            request.AddOptionalHeader(Constants.HeaderConstants.LeaseBreakPeriodHeader, leaseBreakPeriod);
        }

        /// <summary>
        /// Adds a lease action to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseAction">The lease action.</param>
        internal static void AddLeaseAction(HttpWebRequest request, LeaseAction leaseAction)
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest PutBlock(Uri uri, int? timeout, string blockId, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "block");
            builder.Add("blockid", blockId);

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to create or update a blob by committing a block list.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The properties to set for the blob.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest PutBlockList(Uri uri, int? timeout, BlobProperties properties, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "blocklist");

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;

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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest GetBlockList(Uri uri, int? timeout, DateTimeOffset? snapshot, BlockListingFilter typesOfBlocks, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "blocklist");
            builder.Add("blocklisttype", typesOfBlocks.ToString());
            BlobHttpWebRequestFactory.AddSnapshot(builder, snapshot);
            
            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to write or clear a range of pages in a page blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="pageRange">The page range, defined by an object of type <see cref="PageRange"/>.</param>
        /// <param name="pageWrite">A value of type <see cref="PageWrite"/>, indicating the operation to perform on the page blob.</param>
        /// <param name="accessCondition">The <see cref="AccessCondition"/> to apply to the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest PutPage(Uri uri, int? timeout, PageRange pageRange, PageWrite pageWrite,  AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "page");

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
            
            request.AddOptionalHeader(Constants.HeaderConstants.RangeHeader, pageRange.ToString());
            request.Headers.Add(Constants.HeaderConstants.PageWrite, pageWrite.ToString());
            
            request.ApplyAccessCondition(accessCondition);
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest CopyFrom(Uri uri, int? timeout, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, null /* builder */, operationContext);
            request.ContentLength = 0;

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
        /// <param name="accessCondition">The access condition to apply to the request. Only lease conditions are supported for this operation.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest AbortCopy(Uri uri, int? timeout, string copyId, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "copy");
            builder.Add(Constants.QueryConstants.CopyId, copyId);

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;

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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest Get(Uri uri, int? timeout, DateTimeOffset? snapshot, AccessCondition accessCondition, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            if (snapshot.HasValue)
            {
                builder.Add("snapshot", BlobRequest.ConvertDateTimeToSnapshotString(snapshot.Value));
            }

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
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
        /// <param name="rangeContentMD5">If set to <c>true</c>, request an MD5 header for the specified range.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest Get(Uri uri, int? timeout, DateTimeOffset? snapshot, long? offset, long? count, bool rangeContentMD5, AccessCondition accessCondition, OperationContext operationContext)
        {
            if (offset.HasValue && rangeContentMD5)
            {
                CommonUtils.AssertNotNull("count", count);
                CommonUtils.AssertInBounds("count", count.Value, 1, Constants.MaxBlockSize);
            }

            HttpWebRequest request = Get(uri, timeout, snapshot, accessCondition, operationContext);
            AddRange(request, offset, count);

            if (offset.HasValue && rangeContentMD5)
            {
                request.Headers.Add(Constants.HeaderConstants.RangeContentMD5Header, "true");
            }

            return request;
        }
    }
}
