// -----------------------------------------------------------------------------------------
// <copyright file="QueueHttpWebRequestFactory.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    /// <summary>
    /// A factory class for constructing a web request against the Queue service.
    /// </summary>
    public static class QueueHttpWebRequestFactory
    {
        /// <summary>
        /// Creates a web request to get the properties of the Queue service.
        /// </summary>
        /// <param name="uri">The absolute URI to the Queue service.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to get the Queue service properties.
        /// </returns>
        public static HttpWebRequest GetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.GetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Creates a web request to set the properties of the Queue service.
        /// </summary>
        /// <param name="uri">The absolute URI to the Queue service.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to set the Queue service properties.
        /// </returns>
        public static HttpWebRequest SetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.SetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Writes Queue service properties to a stream, formatted in XML.
        /// </summary>
        /// <param name="properties">The service properties to format and write to the stream.</param>
        /// <param name="outputStream">The stream to which the formatted properties are to be written.</param>
        public static void WriteServiceProperties(ServiceProperties properties, Stream outputStream)
        {
            properties.WriteServiceProperties(outputStream);
        }

        /// <summary>
        /// Constructs a web request to create a new queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Create(Uri uri, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.Create(uri, timeout, null, operationContext);
        }

        /// <summary>
        /// Constructs a web request to delete the queue and all of the messages within it.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest Delete(Uri uri, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.Delete(uri, null, timeout, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to clear all messages in the queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest ClearMessages(Uri uri, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.Delete(uri, null, timeout, operationContext);
            return request;
        }

        /// <summary>
        /// Generates a web request to return the user-defined metadata for this queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest GetMetadata(Uri uri, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.GetMetadata(uri, timeout, null, operationContext);
            return request;
        }

        /// <summary>
        /// Generates a web request to set user-defined metadata for the queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest SetMetadata(Uri uri, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.SetMetadata(uri, timeout, null, operationContext);
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
        /// Constructs a web request to return a listing of all queues in this storage account.
        /// </summary>
        /// <param name="uri">The absolute URI for the account.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <param name="detailsIncluded">Additional details to return with the listing.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpWebRequest List(Uri uri, int? timeout, ListingContext listingContext, QueueListingDetails detailsIncluded, OperationContext operationContext)
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

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest GetAcl(Uri uri, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.GetAcl(uri, null, timeout, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest SetAcl(Uri uri, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = HttpWebRequestFactory.SetAcl(uri, null, timeout, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to add a message for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="timeToLiveInSeconds">The message time-to-live, in seconds.</param>
        /// <param name="visibilityTimeoutInSeconds">The visibility timeout, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest AddMessage(Uri uri, int? timeout, int? timeToLiveInSeconds, int? visibilityTimeoutInSeconds, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            if (timeToLiveInSeconds != null)
            {
                builder.Add(Constants.QueryConstants.MessageTimeToLive, timeToLiveInSeconds.ToString());
            }

            if (visibilityTimeoutInSeconds != null)
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeoutInSeconds.ToString());
            }

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Post, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to update a message.
        /// </summary>
        /// <param name="uri">The absolute URI to the message to update.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="popReceipt">The pop receipt of the message.</param>
        /// <param name="visibilityTimeoutInSeconds">The length of time from now during which the message will be invisible, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for the update operation.</returns>
        public static HttpWebRequest UpdateMessage(Uri uri, int? timeout, string popReceipt, int visibilityTimeoutInSeconds, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            builder.Add(Constants.QueryConstants.PopReceipt, popReceipt);
            builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeoutInSeconds.ToString());

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to update a message.
        /// </summary>
        /// <param name="uri">The absolute URI to the message to update.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="popReceipt">The pop receipt of the message.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for the update operation.</returns>
        public static HttpWebRequest DeleteMessage(Uri uri, int? timeout, string popReceipt, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.PopReceipt, popReceipt);

            HttpWebRequest request = HttpWebRequestFactory.Delete(uri, builder, timeout, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to get messages for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="numberOfMessages">The number of messages.</param>
        /// <param name="visibilityTimeout">The visibility timeout.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest GetMessages(Uri uri, int? timeout, int numberOfMessages, TimeSpan? visibilityTimeout, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            builder.Add(Constants.QueryConstants.NumOfMessages, numberOfMessages.ToString());

            if (visibilityTimeout != null)
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeout.Value.RoundUpToSeconds().ToString());
            }

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to peeks messages for a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="numberOfMessages">The number of messages.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest PeekMessages(Uri uri, int? timeout, int numberOfMessages, OperationContext operationContext)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add("peekonly", "true");

            builder.Add(Constants.QueryConstants.NumOfMessages, numberOfMessages.ToString());

            HttpWebRequest request = HttpWebRequestFactory.CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
            return request;
        }
    }
}
