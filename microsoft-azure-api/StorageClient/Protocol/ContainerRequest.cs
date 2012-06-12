//-----------------------------------------------------------------------
// <copyright file="ContainerRequest.cs" company="Microsoft">
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
//    Contains code for the ContainerRequest class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Provides a set of methods for constructing requests for container operations.
    /// </summary>
    public static class ContainerRequest
    {
        /// <summary>
        /// Constructs a web request to create a new container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Create(Uri uri, int timeout)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            return Request.Create(uri, timeout, containerBuilder);
        }

        /// <summary>
        /// Constructs a web request to delete the container and all of the blobs within it.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Delete(Uri uri, int timeout, AccessCondition accessCondition)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpWebRequest request = Request.Delete(uri, timeout, containerBuilder);

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Generates a web request to return the user-defined metadata for this container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest GetMetadata(Uri uri, int timeout, AccessCondition accessCondition)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpWebRequest request = Request.GetMetadata(uri, timeout, containerBuilder);

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Generates a web request to return the properties and user-defined metadata for this container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest GetProperties(Uri uri, int timeout, AccessCondition accessCondition)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpWebRequest request = Request.GetProperties(uri, timeout, containerBuilder);

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Generates a web request to set user-defined metadata for the container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest SetMetadata(Uri uri, int timeout, AccessCondition accessCondition)
        {
            UriQueryBuilder containerBuilder = GetContainerUriQueryBuilder();
            HttpWebRequest request = Request.SetMetadata(uri, timeout, containerBuilder);

            Request.ApplyAccessCondition(accessCondition, request, false);

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
        public static HttpWebRequest Lease(Uri uri, int timeout, LeaseAction action, string proposedLeaseId, int? leaseDuration, int? leaseBreakPeriod, AccessCondition accessCondition)
        {
            UriQueryBuilder builder = GetContainerUriQueryBuilder();
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
        /// Signs the request for Shared Key Lite authentication.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="credentials">The account credentials.</param>
        public static void SignRequestForSharedKeyLite(HttpWebRequest request, Credentials credentials)
        {
            Request.SignRequestForBlobAndQueuesSharedKeyLite(request, credentials);
        }

        /// <summary>
        /// Constructs a web request to return a listing of all containers in this storage account.
        /// </summary>
        /// <param name="uri">The absolute URI for the account.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <param name="detailsIncluded">Additional details to return with the listing.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpWebRequest List(Uri uri, int timeout, ListingContext listingContext, ContainerListingDetails detailsIncluded)
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

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a container.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="accessCondition">The access condition to apply to the request.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpWebRequest GetAcl(Uri uri, int timeout, AccessCondition accessCondition)
        {
            HttpWebRequest request = Request.GetAcl(uri, timeout, GetContainerUriQueryBuilder());

            Request.ApplyAccessCondition(accessCondition, request, false);

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
        public static HttpWebRequest SetAcl(Uri uri, int timeout, BlobContainerPublicAccessType publicAccess, AccessCondition accessCondition)
        {
            HttpWebRequest request = Request.SetAcl(uri, timeout, GetContainerUriQueryBuilder());

            if (publicAccess != BlobContainerPublicAccessType.Off)
            {
                request.Headers.Add("x-ms-blob-public-access", publicAccess.ToString().ToLower());
            }

            Request.ApplyAccessCondition(accessCondition, request, false);

            return request;
        }

        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        public static void WriteSharedAccessIdentifiers(SharedAccessBlobPolicies sharedAccessPolicies, Stream outputStream)
        {
            Request.WriteSharedAccessIdentifiers(
                sharedAccessPolicies,
                outputStream,
                (policy, writer) =>
                {
                    writer.WriteElementString(
                        Constants.Start,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessStartTime));
                    writer.WriteElementString(
                        Constants.Expiry,
                        SharedAccessSignatureHelper.GetDateTimeOrEmpty(policy.SharedAccessExpiryTime));
                    writer.WriteElementString(
                        Constants.Permission,
                        SharedAccessBlobPolicy.PermissionsToString(policy.Permissions));
                });
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

        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="uri">The absolute URI to the container.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="query">The query builder to use.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        private static HttpWebRequest CreateWebRequest(Uri uri, int timeout, UriQueryBuilder query)
        {
            return Request.CreateWebRequest(uri, timeout, query);
        }
    }
}
