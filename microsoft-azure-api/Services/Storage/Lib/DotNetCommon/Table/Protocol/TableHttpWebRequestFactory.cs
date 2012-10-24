//-----------------------------------------------------------------------
// <copyright file="TableWebRequestFactory.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Table.Protocol
{
    using System;
    using System.IO;
    using System.Net;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// Provides a set of methods for constructing requests for table operations.
    /// </summary>
    public static class TableHttpWebRequestFactory
    {
        /// <summary>
        /// Creates a web request to get the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <returns>A web request to get the service properties.</returns>
        public static HttpWebRequest GetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.GetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Creates a web request to set the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <returns>A web request to set the service properties.</returns>
        public static HttpWebRequest SetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.SetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Writes service properties to a stream, formatted in XML.
        /// </summary>
        /// <param name="properties">The service properties to format and write to the stream.</param>
        /// <param name="outputStream">The stream to which the formatted properties are to be written.</param>
        public static void WriteServiceProperties(ServiceProperties properties, Stream outputStream)
        {
            properties.WriteServiceProperties(outputStream);
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpWebRequest GetAcl(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.GetAcl(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpWebRequest SetAcl(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.SetAcl(uri, builder, timeout, operationContext);
        }       
    }
}