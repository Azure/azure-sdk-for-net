//-----------------------------------------------------------------------
// <copyright file="BlobRequest.cs" company="Microsoft">
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
//    Contains code for the BlobRequest class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Provides a set of methods for constructing requests for blob operations.
    /// </summary>
    public static class BlobRequest
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
        public static HttpWebRequest Put(Uri uri, int timeout, BlobProperties properties, BlobType blobType, long pageBlobSize, AccessCondition accessCondition)
        {
            if (blobType == BlobType.Unspecified)
            {
                throw new InvalidOperationException(SR.UndefinedBlobType);
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, null);

            request.Method = "PUT";

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

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
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
        public static HttpWebRequest Delete(Uri uri, int timeout, DateTime? snapshot, DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            if (snapshot != null && deleteSnapshotsOption != DeleteSnapshotsOption.None)
            {
                throw new InvalidOperationException(String.Format(SR.DeleteSnapshotsNotValidError, "deleteSnapshotsOption", "snapshot"));
            }

            BlobRequest.AddSnapshot(builder, snapshot);

            var request = Request.Delete(uri, timeout, builder);

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

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Constructs a web request to return the user-defined metadata for the blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operiaton.</returns>
        public static HttpWebRequest GetMetadata(Uri uri, int timeout, DateTime? snapshot, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            BlobRequest.AddSnapshot(builder, snapshot);

            HttpWebRequest request = Request.GetMetadata(uri, timeout, builder);
            Request.ApplyAccessCondition(accessCondition, request, false);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set user-defined metadata for the blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest SetMetadata(Uri uri, int timeout, AccessCondition accessCondition)
        {
            var request = Request.SetMetadata(uri, timeout, null);
            Request.ApplyAccessCondition(accessCondition, request, false);
            return request;
        }

        /// <summary>
        /// Signs the request for Shared Key authentication.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="credentials">The account credentials.</param>
        public static void SignRequest(HttpWebRequest request, Credentials credentials)
        {
            Request.SignRequestForBlobAndQueue(request, credentials);
        }

        /// <summary>
        /// Adds user-defined metadata to the request as one or more name-value pairs.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="metadata">The user-defined metadata.</param>
        public static void AddMetadata(HttpWebRequest request, NameValueCollection metadata)
        {
            Request.AddMetadata(request, metadata);
        }

        /// <summary>
        /// Adds user-defined metadata to the request as a single name-value pair.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="name">The metadata name.</param>
        /// <param name="value">The metadata value.</param>
        public static void AddMetadata(HttpWebRequest request, string name, string value)
        {
            Request.AddMetadata(request, name, value);
        }

        /// <summary>
        /// Constructs a web request to return the blob's system properties.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest GetProperties(Uri uri, int timeout, DateTime? snapshot, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            BlobRequest.AddSnapshot(builder, snapshot);

            var request = Request.GetProperties(uri, timeout, builder);
            Request.ApplyAccessCondition(accessCondition, request, false);
            return request;
        }

        /// <summary>
        /// Signs the request for Shared Key Lite authentication.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="credentials">The account credentials.</param>
        public static void SignRequestForSharedKeyLite(HttpWebRequest request, Credentials credentials)
        {
            Request.SignRequestForBlobAndQueuesSharedKeyLite(request, credentials);
        }

        /// <summary>
        /// Generates a web request to return a listing of all blobs in the container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest List(Uri uri, int timeout, BlobListingContext listingContext)
        {
            UriQueryBuilder builder = ContainerRequest.GetContainerUriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "list");

            if (listingContext != null)
            {
                if (listingContext.Prefix != null)
                {
                    builder.Add("prefix", listingContext.Prefix);
                }

                if (listingContext.Delimiter != null)
                {
                    builder.Add("delimiter", listingContext.Delimiter);
                }

                if (listingContext.Marker != null)
                {
                    builder.Add("marker", listingContext.Marker);
                }

                if (listingContext.MaxResults != null)
                {
                    builder.Add("maxresults", listingContext.MaxResults.ToString());
                }

                if (listingContext.Include != BlobListingDetails.None)
                {
                    StringBuilder sb = new StringBuilder();

                    bool started = false;

                    if ((listingContext.Include & BlobListingDetails.Snapshots) == BlobListingDetails.Snapshots)
                    {
                        if (!started)
                        {
                            started = true;
                        }
                        else
                        {
                            sb.Append(",");
                        }

                        sb.Append("snapshots");
                    }

                    if ((listingContext.Include & BlobListingDetails.UncommittedBlobs) == BlobListingDetails.UncommittedBlobs)
                    {
                        if (!started)
                        {
                            started = true;
                        }
                        else
                        {
                            sb.Append(",");
                        }

                        sb.Append("uncommittedblobs");
                    }

                    if ((listingContext.Include & BlobListingDetails.Metadata) == BlobListingDetails.Metadata)
                    {
                        if (!started)
                        {
                            started = true;
                        }
                        else
                        {
                            sb.Append(",");
                        }

                        sb.Append("metadata");
                    }

                    if ((listingContext.Include & BlobListingDetails.Copy) == BlobListingDetails.Copy)
                    {
                        if (!started)
                        {
                            started = true;
                        }
                        else
                        {
                            sb.Append(",");
                        }

                        sb.Append("copy");
                    }

                    builder.Add("include", sb.ToString());
                }
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

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
        public static HttpWebRequest CopyFrom(Uri uri, int timeout, Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition)
        {
            HttpWebRequest request = CreateWebRequest(uri, timeout, null);

            request.ContentLength = 0;
            request.Method = "PUT";

            request.Headers.Add(Constants.HeaderConstants.CopySourceHeader, source.AbsoluteUri);
            Request.ApplyAccessCondition(destAccessCondition, request, false);
            Request.ApplyAccessCondition(sourceAccessCondition, request, true);

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
        public static HttpWebRequest AbortCopy(Uri uri, int timeout, string copyId, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "copy");
            builder.Add(Constants.QueryConstants.CopyId, copyId);

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.ContentLength = 0;
            request.Method = "PUT";

            request.Headers.Add(Constants.HeaderConstants.CopyActionHeader, Constants.HeaderConstants.CopyActionAbort);
            Request.ApplyAccessCondition(accessCondition, request, false);

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
        public static HttpWebRequest Get(Uri uri, int timeout, DateTime? snapshot, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            BlobRequest.AddSnapshot(builder, snapshot);

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            Request.ApplyAccessCondition(accessCondition, request, false);

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
        public static HttpWebRequest Get(Uri uri, int timeout, DateTime? snapshot, long offset, long? count, AccessCondition accessCondition)
        {
            HttpWebRequest request = Get(uri, timeout, snapshot, accessCondition);

            string rangeStart = offset.ToString();
            string rangeEnd = string.Empty;
            if (count.HasValue)
            {
                rangeEnd = (offset + count.Value - 1).ToString();
            }

            string rangeHeaderValue = string.Format(
                            CultureInfo.InvariantCulture,
                            Constants.HeaderConstants.RangeHeaderFormat,
                            rangeStart,
                            rangeEnd);

            request.Headers.Add(Constants.HeaderConstants.StorageRangeHeader, rangeHeaderValue);

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
        public static HttpWebRequest GetBlockList(Uri uri, int timeout, DateTime? snapshot, BlockListingFilter typesOfBlocks, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "blocklist");

            builder.Add("blocklisttype", typesOfBlocks.ToString());
        
            BlobRequest.AddSnapshot(builder, snapshot);

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Constructs a web request to return the list of active page ranges for a page blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="snapshot">The snapshot timestamp, if the blob is a snapshot.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest GetPageRanges(Uri uri, int timeout, DateTime? snapshot, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "pagelist");

            BlobRequest.AddSnapshot(builder, snapshot);

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            Request.ApplyAccessCondition(accessCondition, request, false);

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
        public static HttpWebRequest Lease(Uri uri, int timeout, LeaseAction action, string proposedLeaseId, int? leaseDuration, int? leaseBreakPeriod, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "lease");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.ContentLength = 0;
            request.Method = "PUT";

            // Add Headers
            Request.AddLeaseAction(request, action);
            Request.AddLeaseDuration(request, leaseDuration);
            Request.AddProposedLeaseId(request, proposedLeaseId);
            Request.AddLeaseBreakPeriod(request, leaseBreakPeriod);

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Constructs a web request to write a block to a block blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="blockId">The block ID for this block.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest PutBlock(Uri uri, int timeout, string blockId, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "block");

            builder.Add("blockid", blockId);

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "PUT";

            Request.ApplyAccessCondition(accessCondition, request, false);

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
        public static HttpWebRequest PutBlockList(
            Uri uri,
            int timeout,
            BlobProperties properties,
            AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "blocklist");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "PUT";

            Request.AddOptionalHeader(request, Constants.HeaderConstants.CacheControlHeader, properties.CacheControl);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.ContentTypeHeader, properties.ContentType);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.BlobContentMD5Header, properties.ContentMD5);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.ContentLanguageHeader, properties.ContentLanguage);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.ContentEncodingHeader, properties.ContentEncoding);

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Writes the body of the block list to the specified stream in XML format.
        /// </summary>
        /// <param name="blocks">An enumerable collection of <see cref="PutBlockListItem"/> objects.</param>
        /// <param name="outputStream">The stream to which the block list is written.</param>
        public static void WriteBlockListBody(IEnumerable<PutBlockListItem> blocks, Stream outputStream)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            using (XmlWriter writer = XmlWriter.Create(outputStream, settings))
            {
                writer.WriteStartElement(Constants.BlockListElement);

                foreach (var block in blocks)
                {
                    if (block.SearchMode == BlockSearchMode.Committed)
                    {
                        writer.WriteElementString(Constants.CommittedElement, block.Id);
                    }
                    else if (block.SearchMode == BlockSearchMode.Uncommitted)
                    {
                        writer.WriteElementString(Constants.UncommittedElement, block.Id);
                    }
                    else if (block.SearchMode == BlockSearchMode.Latest)
                    {
                        writer.WriteElementString(Constants.LatestElement, block.Id);
                    }
                }

                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Constructs a web request to write or clear a range of pages in a page blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The blob's properties.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest PutPage(Uri uri, int timeout, PutPageProperties properties, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "page");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "PUT";

            Request.AddOptionalHeader(request, Constants.HeaderConstants.RangeHeader, properties.Range.ToString());

            // Page write is either update or clean; required
            request.Headers.Add(Constants.HeaderConstants.PageWrite, properties.PageWrite.ToString());

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Constructs a web request to set system properties for a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="properties">The blob's properties.</param>
        /// <param name="newBlobSize">The new blob size, if the blob is a page blob. Set this parameter to <c>null</c> to keep the existing blob size.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest SetProperties(Uri uri, int timeout, BlobProperties properties, long? newBlobSize, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.ContentLength = 0;
            request.Method = "PUT";

            if (newBlobSize.HasValue)
            {
                request.Headers.Add(Constants.HeaderConstants.Size, newBlobSize.Value.ToString(NumberFormatInfo.InvariantInfo));
                properties.Length = newBlobSize.Value;
            }

            Request.AddOptionalHeader(request, Constants.HeaderConstants.CacheControlHeader, properties.CacheControl);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.ContentEncodingHeader, properties.ContentEncoding);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.ContentLanguageHeader, properties.ContentLanguage);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.BlobContentMD5Header, properties.ContentMD5);
            Request.AddOptionalHeader(request, Constants.HeaderConstants.ContentTypeHeader, properties.ContentType);

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Constructs a web request to create a snapshot of a blob.
        /// </summary>
        /// <param name="uri">The absolute URI to the blob.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Snapshot(Uri uri, int timeout, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "snapshot");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.ContentLength = 0;
            request.Method = "PUT";

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Creates a web request to get the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <returns>A web request to get the service properties.</returns>
        public static HttpWebRequest GetServiceProperties(Uri uri, int timeout)
        {
            return Request.GetServiceProperties(uri, timeout);
        }

        /// <summary>
        /// Creates a web request to set the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <returns>A web request to set the service properties.</returns>
        public static HttpWebRequest SetServiceProperties(Uri uri, int timeout)
        {
            return Request.SetServiceProperties(uri, timeout);
        }

        /// <summary>
        /// Writes service properties to a stream, formatted in XML.
        /// </summary>
        /// <param name="properties">The service properties to format and write to the stream.</param>
        /// <param name="outputStream">The stream to which the formatted properties are to be written.</param>
        public static void WriteServiceProperties(ServiceProperties properties, Stream outputStream)
        {
            Request.WriteServiceProperties(properties, outputStream);
        }

        /// <summary>
        /// Adds the snapshot.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="snapshot">The snapshot version, if the blob is a snapshot.</param>
        private static void AddSnapshot(UriQueryBuilder builder, DateTime? snapshot)
        {
            if (snapshot != null)
            {
                builder.Add("snapshot", Request.ConvertDateTimeToSnapshotString(snapshot.Value.ToUniversalTime()));
            }
        }

        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="uri">The Uri of the resource.</param>
        /// <param name="timeout">The timeout to apply.</param>
        /// <param name="query">The query builder to use.</param>
        /// <returns>The resulting <see cref="HttpWebRequest"/>.</returns>
        private static HttpWebRequest CreateWebRequest(Uri uri, int timeout, UriQueryBuilder query)
        {
            return Request.CreateWebRequest(uri, timeout, query);
        }
    }
}
