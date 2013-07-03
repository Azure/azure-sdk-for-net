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
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.IO;
    using System.Net;

    /// <summary>
    /// A factory class for constructing a web request to manage tables in the Table service.
    /// </summary>
    public static class TableHttpWebRequestFactory
    {
        /// <summary>
        /// Creates a web request to get the properties of the Table service.
        /// </summary>
        /// <param name="uri">The absolute URI to the Table service.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to get the Table service properties.
        /// </returns>
        public static HttpWebRequest GetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.GetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Creates a web request to set the properties of the Table service.
        /// </summary>
        /// <param name="uri">The absolute URI to the Table service.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval, in seconds.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to set the Table service properties.
        /// </returns>
        public static HttpWebRequest SetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.SetServiceProperties(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Writes Table service properties to a stream, formatted in XML.
        /// </summary>
        /// <param name="properties">The service properties to format and write to the stream.</param>
        /// <param name="outputStream">The stream to which the formatted properties are to be written.</param>
        public static void WriteServiceProperties(ServiceProperties properties, Stream outputStream)
        {
            CommonUtility.AssertNotNull("properties", properties);

            properties.WriteServiceProperties(outputStream);
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest GetAcl(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.GetAcl(uri, builder, timeout, operationContext);
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a table.
        /// </summary>
        /// <param name="uri">The absolute URI to the table.</param>
        /// <param name="builder">An object of type <see cref="UriQueryBuilder"/>, containing additional parameters to add to the URI query string.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext" /> object for tracking the current operation.</param>
        /// <returns>
        /// A web request to use to perform the operation.
        /// </returns>
        public static HttpWebRequest SetAcl(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            return HttpWebRequestFactory.SetAcl(uri, builder, timeout, operationContext);
        }       
    }
}