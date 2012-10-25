// -----------------------------------------------------------------------------------------
// <copyright file="ContainerHttpRequestMessageFactory.cs" company="Microsoft">
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
    using System.Net.Http;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static class ContainerHttpRequestMessageFactory
    {
        /// <summary>
        /// Constructs a web request to create a new container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Create(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            return HttpRequestMessageFactory.Create(uri, timeout, containerBuilder, content, operationContext);
        }

        /// <summary>
        /// Constructs a web request to delete the container and all of the blobs within it.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Delete(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpRequestMessage request = HttpRequestMessageFactory.Delete(uri, timeout, containerBuilder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to return the user-defined metadata for this container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage GetMetadata(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpRequestMessage request = HttpRequestMessageFactory.GetMetadata(uri, timeout, containerBuilder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to return the properties and user-defined metadata for this container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage GetProperties(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpRequestMessage request = HttpRequestMessageFactory.GetProperties(uri, timeout, containerBuilder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to set user-defined metadata for the container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage SetMetadata(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpRequestMessage request = HttpRequestMessageFactory.SetMetadata(uri, timeout, containerBuilder, content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to use to acquire, renew, change, release or break the lease for the container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
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
            UriQueryBuilder builder = GetContainerUriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "lease");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);

            // Add Headers
            BlobHttpRequestMessageFactory.AddLeaseAction(request, action);
            BlobHttpRequestMessageFactory.AddLeaseDuration(request, leaseDuration);
            BlobHttpRequestMessageFactory.AddProposedLeaseId(request, proposedLeaseId);
            BlobHttpRequestMessageFactory.AddLeaseBreakPeriod(request, leaseBreakPeriod);

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
        /// Constructs a web request to return a listing of all containers in this storage account.
        /// </summary>
        /// <param name="uri">The absolute URI for the account.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <param name="detailsIncluded">Additional details to return with the listing.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpRequestMessage List(Uri uri, int? timeout, ListingContext listingContext, ContainerListingDetails detailsIncluded, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "list");

            if (listingContext != null)
            {
                if (listingContext.Prefix != null)
                {
                    builder.Add("prefix", listingContext.Prefix);
                }

                if (listingContext.Marker != null)
                {
                    builder.Add("marker", listingContext.Marker);
                }

                if (listingContext.MaxResults != null)
                {
                    builder.Add("maxresults", listingContext.MaxResults.ToString());
                }
            }

            if ((detailsIncluded & ContainerListingDetails.Metadata) != 0)
            {
                builder.Add("include", "metadata");
            }

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpRequestMessage GetAcl(Uri uri, int? timeout, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.GetAcl(uri, timeout, GetContainerUriQueryBuilder(), content, operationContext);
            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="publicAccess">The type of public access to allow for the container.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpRequestMessage SetAcl(Uri uri, int? timeout, BlobContainerPublicAccessType publicAccess, AccessCondition accessCondition, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.SetAcl(uri, timeout, GetContainerUriQueryBuilder(), content, operationContext);

            if (publicAccess != BlobContainerPublicAccessType.Off)
            {
                request.Headers.Add("x-ms-blob-public-access", publicAccess.ToString().ToLower());
            }

            request.ApplyAccessCondition(accessCondition);
            return request;
        }

        /// <summary>
        /// Generates a web request to return a listing of all blobs in the container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage ListBlobs(Uri uri, int? timeout, BlobListingContext listingContext, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = ContainerHttpRequestMessageFactory.GetContainerUriQueryBuilder();
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

                if (listingContext.Details != BlobListingDetails.None)
                {
                    StringBuilder sb = new StringBuilder();

                    bool started = false;

                    if ((listingContext.Details & BlobListingDetails.Snapshots) == BlobListingDetails.Snapshots)
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

                    if ((listingContext.Details & BlobListingDetails.UncommittedBlobs) == BlobListingDetails.UncommittedBlobs)
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

                    if ((listingContext.Details & BlobListingDetails.Metadata) == BlobListingDetails.Metadata)
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

                    if ((listingContext.Details & BlobListingDetails.Copy) == BlobListingDetails.Copy)
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

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Gets the container Uri query builder.
        /// </summary>
        /// <returns>A <see cref="UriQueryBuilder"/> for the container.</returns>
        internal static UriQueryBuilder GetContainerUriQueryBuilder()
        {
            UriQueryBuilder uriBuilder = new UriQueryBuilder();
            uriBuilder.Add(Constants.QueryConstants.ResourceType, "container");
            return uriBuilder;
        }
    }
}
