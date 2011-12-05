//-----------------------------------------------------------------------
// <copyright file="QueueRequest.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
//    Contains code for the QueueRequest class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Provides a set of methods for constructing requests for queue operations.
    /// </summary>
    public static class QueueRequest
    {
        /// <summary>
        /// Constructs a web request to create a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest Create(Uri uri, int timeout)
        {
            return Request.Create(uri, timeout, null);
        }

        /// <summary>
        /// Constructs a web request to delete a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest Delete(Uri uri, int timeout)
        {
            return Request.Delete(uri, timeout, null);
        }

        /// <summary>
        /// Constructs a web request to return the user-defined metadata for the queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request for performing the operation.</returns>
        public static HttpWebRequest GetMetadata(Uri uri, int timeout)
        {
            return Request.GetMetadata(uri, timeout, null);
        }

        /// <summary>
        /// Constructs a web request to set user-defined metadata for the queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request for performing the operation.</returns>        
        public static HttpWebRequest SetMetadata(Uri uri, int timeout)
        {
            return Request.SetMetadata(uri, timeout, null);
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
        /// Constructs a web request to return a listing of all queues in the storage account.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="listingContext">A set of parameters for the listing operation.</param>
        /// <param name="detailsIncluded">One of the enumeration values indicating which details to include in the listing.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpWebRequest List(Uri uri, int timeout, ListingContext listingContext, QueueListingDetails detailsIncluded)
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

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// Constructs a web request to clear all messages in the queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpWebRequest ClearMessages(Uri uri, int timeout)
        {
            HttpWebRequest request = CreateWebRequest(uri, timeout, null);

            request.Method = "DELETE";

            return request;
        }

        /// <summary>
        /// Constructs a web request to delete the specified message.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="popReceipt">The pop receipt value for the message.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpWebRequest DeleteMessage(Uri uri, int timeout, string popReceipt)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add(Constants.QueryConstants.PopReceipt, popReceipt);

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "DELETE";

            return request;
        }

        /// <summary>
        /// Constructs a web request to retrieve a specified number of messages.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="numberOfMessages">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout for the message or messages.</param>
        /// <returns>A web request for the specified operation.</returns>
        public static HttpWebRequest GetMessages(Uri uri, int timeout, int? numberOfMessages, int? visibilityTimeout)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            if (numberOfMessages != null)
            {
                builder.Add("numofmessages", numberOfMessages.ToString());
            }

            if (visibilityTimeout != null)
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeout.ToString());
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// Constructs a web request to retrieve a specified number of messages without changing their visibility.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="numberOfMessages">The number of messages to retrieve.</param>
        /// <returns>A web request for performing the specified operation.</returns>
        public static HttpWebRequest PeekMessages(Uri uri, int timeout, int? numberOfMessages)
        {
            UriQueryBuilder builder = new UriQueryBuilder();
            builder.Add("peekonly", "true");

            if (numberOfMessages != null)
            {
                builder.Add("numofmessages", numberOfMessages.ToString());
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// Generates a web request to add a message to a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue's messages.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="messageTimeToLive">The message time-to-live, or null if no time-to-live is specified.</param>
        /// <returns>A web request for the put operation.</returns>
        public static HttpWebRequest PutMessage(Uri uri, int timeout, int? messageTimeToLive)
        {
            return PutMessage(uri, timeout, messageTimeToLive, null);
        }

        /// <summary>
        /// Generates a web request to add a message to a queue.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue's messages.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="messageTimeToLive">The message time-to-live in seconds. If null, the service default will be used.</param>
        /// <param name="visibilityTimeout">The length of time from now during which the message will be invisible, in seconds.
        /// If null, the message will be visible immediately.</param>
        /// <returns>A web request for the put operation.</returns>
        public static HttpWebRequest PutMessage(Uri uri, int timeout, int? messageTimeToLive, int? visibilityTimeout)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            if (visibilityTimeout != null)
            {
                builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeout.ToString());
            }

            if (messageTimeToLive != null)
            {
                builder.Add(Constants.QueryConstants.MessageTimeToLive, messageTimeToLive.ToString());
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "POST";

            return request;
        }

        /// <summary>
        /// Generates a web request to update a message.
        /// </summary>
        /// <param name="uri">The absolute URI to the message to update.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="popReceipt">The pop receipt of the message.</param>
        /// <param name="visibilityTimeout">The length of time from now during which the message will be invisible, in seconds.</param>
        /// <returns>A web request for the update operation.</returns>
        public static HttpWebRequest UpdateMessage(Uri uri, int timeout, string popReceipt, int visibilityTimeout)
        {
            UriQueryBuilder builder = new UriQueryBuilder();

            builder.Add(Constants.QueryConstants.PopReceipt, popReceipt);
            builder.Add(Constants.QueryConstants.VisibilityTimeout, visibilityTimeout.ToString());

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "PUT";

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
        /// Generates the message request body from a string containing the message.
        /// </summary>
        /// <param name="message">The content of the message.</param>
        /// <returns>The message request body as an array of bytes.</returns>
        public static byte[] GenerateMessageRequestBody(string message)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.NewLineHandling = NewLineHandling.Entitize;
            
            byte[] result = null;
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    writer.WriteStartElement(Constants.MessageElement);
                    writer.WriteElementString(Constants.MessageTextElement, message);
                    writer.WriteEndDocument();
                    writer.Close();
                }

                result = stream.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="uri">The absolute URI to the queue.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="query">The query.</param>
        /// <returns>A web request for performing the operation.</returns>
        private static HttpWebRequest CreateWebRequest(Uri uri, int timeout, UriQueryBuilder query)
        {
            return Request.CreateWebRequest(uri, timeout, query);
        }
    }
}
