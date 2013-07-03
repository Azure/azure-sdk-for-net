// -----------------------------------------------------------------------------------------
// <copyright file="QueueHttpRequestMessageFactory.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static class QueueHttpRequestMessageFactory
    {
        /// <summary>
        /// Constructs a web request to create a new queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Create(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            return HttpRequestMessageFactory.Create(uri, timeout, null, content, operationContext);
        }

        /// <summary>
        /// Constructs a web request to delete the queue and all of the messages within it.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Delete(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.Delete(uri, timeout, null, content, operationContext);
            return request;
        }

        /// <summary>
        /// Generates a web request to return the user-defined metadata for this queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage GetMetadata(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.GetMetadata(uri, timeout, null, content, operationContext);
            return request;
        }

        /// <summary>
        /// Generates a web request to set user-defined metadata for the queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage SetMetadata(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.SetMetadata(uri, timeout, null, content, operationContext);
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
        /// Constructs a web request to return a listing of all queues in this storage account.
        /// </summary>
        /// <param name="uri">The absolute URI for the account.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <param name="detailsIncluded">Additional details to return with the listing.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpRequestMessage List(Uri uri, int? timeout, ListingContext listingContext, QueueListingDetails detailsIncluded, HttpContent content, OperationContext operationContext)
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

            if ((detailsIncluded & QueueListingDetails.Metadata) != 0)
            {
                builder.Add("include", "metadata");
            }

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpRequestMessage GetAcl(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.GetAcl(uri, timeout, null, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpRequestMessage SetAcl(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.SetAcl(uri, timeout, null, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to add a message for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage AddMessage(Uri uri, int? timeout, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Post, uri, timeout, null, content, operationContext);

            if (timeToLive != null)
            {
                request.Headers.Add(Constants.QueryConstants.MessageTimeToLive, timeToLive.Value.TotalSeconds.ToString());
            }

            if (initialVisibilityDelay != null)
            {
                request.Headers.Add(Constants.QueryConstants.VisibilityTimeout, initialVisibilityDelay.Value.TotalSeconds.ToString());
            }

            return request;
        }

        /// <summary>
        /// Constructs a web request to update a message for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage UpdateMessage(Uri uri, int? timeout, string popReceipt, TimeSpan? visibilityTimeout, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            builder.Add(Constants.QueryConstants.PopReceipt, popReceipt);
            if (visibilityTimeout != null)
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeout.Value.TotalSeconds.ToString());
            }
            else
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, "0");
            }

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to delete a message for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage DeleteMessage(Uri uri, int? timeout, string popReceipt, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.PopReceipt, popReceipt);

            HttpRequestMessage request = HttpRequestMessageFactory.Delete(uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to get messages for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage GetMessages(Uri uri, int? timeout, int numberOfMessages, TimeSpan? visibilityTimeout, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            builder.Add(Constants.QueryConstants.NumOfMessages, numberOfMessages.ToString());

            if (visibilityTimeout != null)
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeout.Value.RoundUpToSeconds().ToString());
            }

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to peek messages for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage PeekMessages(Uri uri, int? timeout, int numberOfMessages, HttpContent content, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.HeaderConstants.PeekOnly, Constants.HeaderConstants.TrueHeader);
            builder.Add(Constants.QueryConstants.NumOfMessages, numberOfMessages.ToString());

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
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
