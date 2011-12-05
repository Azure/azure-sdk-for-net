//-----------------------------------------------------------------------
// <copyright file="QueueResponse.cs" company="Microsoft">
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
//    Contains code for the QueueResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Provides a set of methods for parsing responses from queue operations.
    /// </summary>
    public static class QueueResponse
    {
        /// <summary>
        /// Returns extended error information from the storage service, that is in addition to the HTTP status code returned with the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object containing extended error information returned with the response.</returns>
        public static StorageExtendedErrorInformation GetError(HttpWebResponse response)
        {
            return Response.GetError(response);
        }

        /// <summary>
        /// Gets a collection of user-defined metadata from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A collection of user-defined metadata, as name-value pairs.</returns>
        public static NameValueCollection GetMetadata(HttpWebResponse response)
        {
            return Response.GetMetadata(response);
        }

        /// <summary>
        /// Gets an array of values for a specified name-value pair from a response that includes user-defined metadata.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <param name="name">The name associated with the metadata values to return.</param>
        /// <returns>An array of metadata values.</returns>
        public static string[] GetMetadata(HttpWebResponse response, string name)
        {
            return Response.GetMetadata(response, name);
        }

        /// <summary>
        /// Gets the request ID from the response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A unique value associated with the request.</returns>
        public static string GetRequestId(HttpWebResponse response)
        {
            return Response.GetRequestId(response);
        }

        /// <summary>
        /// Extracts the pop receipt from a web response header.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The pop receipt stored in the header of the response.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Storage only supports HTTP")]
        public static string GetPopReceipt(HttpWebResponse response)
        {
            return response.Headers[Constants.HeaderConstants.PopReceipt];
        }

        /// <summary>
        /// Extracts the next visibility time from a web response header.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The time of next visibility stored in the header of the response.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Storage only supports HTTP")]
        public static DateTime GetNextVisibleTime(HttpWebResponse response)
        {
            string timeString = response.Headers[Constants.HeaderConstants.NextVisibleTime];

            return timeString.ToUTCTime();
        }

        /// <summary>
        /// Gets the approximate message count for the queue.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The approximate count for the queue.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Storage only supports HTTP")]
        public static string GetApproximateMessageCount(HttpWebResponse response)
        {
            return response.Headers[Constants.HeaderConstants.ApproximateMessagesCount];
        }

        /// <summary>
        /// Parses the response from an operation to get messages from the queue.
        /// </summary>
        /// <param name="stream">The stream to parse.</param>
        /// <returns>An object that may be used for parsing data from the results of a message retrieval operation.</returns>
        public static GetMessagesResponse GetMessages(Stream stream)
        {
            return new GetMessagesResponse(stream);
        }

        /// <summary>
        /// Parses the response from an operation to get messages from the queue.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object that may be used for parsing data from the results of a message retrieval operation.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Storage only supports HTTP")]
        public static GetMessagesResponse GetMessages(HttpWebResponse response)
        {
            return new GetMessagesResponse(response.GetResponseStream());
        }

        /// <summary>
        /// Parses the response for a queue listing operation.
        /// </summary>
        /// <param name="stream">The response stream.</param>
        /// <returns>An object that may be used for parsing data from the results of a queue listing operation.</returns>
        public static ListQueuesResponse List(Stream stream)
        {
            return new ListQueuesResponse(stream);
        }

        /// <summary>
        /// Parses the response for a queue listing operation.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object that may be used for parsing data from the results of a queue listing operation.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Storage only supports HTTP")]
        public static ListQueuesResponse List(HttpWebResponse response)
        {
            return new ListQueuesResponse(response.GetResponseStream());
        }

        /// <summary>
        /// Parses the response from an operation to peek messages from the queue.
        /// </summary>
        /// <param name="stream">The stream to parse.</param>
        /// <returns>An object that may be used for parsing data from the results of a message peeking operation.</returns>
        public static PeekMessagesResponse PeekMessages(Stream stream)
        {
            return new PeekMessagesResponse(stream);
        }

        /// <summary>
        /// Parses the response from an operation to peek messages from the queue.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>An object that may be used for parsing data from the results of a message peeking operation.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1011:ConsiderPassingBaseTypesAsParameters",
            Justification = "Storage only supports HTTP")]
        public static PeekMessagesResponse PeekMessages(HttpWebResponse response)
        {
            return new PeekMessagesResponse(response.GetResponseStream());
        }

        /// <summary>
        /// Reads service properties from a stream.
        /// </summary>
        /// <param name="inputStream">The stream from which to read the service properties.</param>
        /// <returns>The service properties stored in the stream.</returns>
        public static ServiceProperties ReadServiceProperties(Stream inputStream)
        {
            return Response.ReadServiceProperties(inputStream);
        }
    }
}
