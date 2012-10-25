// -----------------------------------------------------------------------------------------
// <copyright file="TableHttpRequestMessageFactory.cs" company="Microsoft">
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
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    internal static class TableHttpRequestMessageFactory
    {
        /// <summary>
        /// Constructs a web request to create a new table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Create(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.Create(uri, timeout, null /* builder */, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to delete the table
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        public static HttpRequestMessage Delete(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.Delete(uri, timeout, null /* builder */, content, operationContext);
            return request;
        }
 
        /// <summary>
        /// Constructs a web request to return the ACL for a table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpRequestMessage GetAcl(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.GetAcl(uri, timeout, null /* builder */, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        public static HttpRequestMessage SetAcl(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.SetAcl(uri, timeout, null /* builder */, content, operationContext);
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
            HttpRequestMessage request = HttpRequestMessageFactory.GetServiceProperties(uri, timeout, operationContext);
            return request;
        }

        /// <summary>
        /// Creates a web request to set the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to set the service properties.</returns>
        internal static HttpRequestMessage SetServiceProperties(Uri uri, int? timeout, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = HttpRequestMessageFactory.SetServiceProperties(uri, timeout, content, operationContext);
            return request;
        }
    }
}
