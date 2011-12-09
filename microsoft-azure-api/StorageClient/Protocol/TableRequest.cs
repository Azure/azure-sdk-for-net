//-----------------------------------------------------------------------
// <copyright file="TableRequest.cs" company="Microsoft">
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
//    Contains code for the TableRequest class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Provides a set of methods for constructing requests for table operations.
    /// </summary>
    public static class TableRequest
    {
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
        /// Signs the request for Shared Key authentication.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="credentials">The account credentials.</param>
        /// <remarks>The table service usually expects requests to use Shared Key Lite authentication.
        /// Use <see cref="SignRequestForSharedKeyLite"/> for those requests.</remarks>
        public static void SignRequest(HttpWebRequest request, Credentials credentials)
        {
            Request.SignRequestForTablesSharedKey(request, credentials);
        }

        /// <summary>
        /// Signs the request for Shared Key Lite authentication.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="credentials">The account credentials.</param>
        public static void SignRequestForSharedKeyLite(HttpWebRequest request, Credentials credentials)
        {
            Request.SignRequestForTablesSharedKeyLite(request, credentials);
        }
    }
}
