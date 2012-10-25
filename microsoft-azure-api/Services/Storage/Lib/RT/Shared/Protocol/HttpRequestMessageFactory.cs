// -----------------------------------------------------------------------------------------
// <copyright file="HttpRequestMessageFactory.cs" company="Microsoft">
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

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;

    internal static class HttpRequestMessageFactory
    {
        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="uri">The request Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpRequestMessage CreateRequestMessage(HttpMethod method, Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            if (timeout != null && timeout != 0)
            {
                builder.Add("timeout", timeout.ToString());
            }

            Uri uriRequest = builder.AddToUri(uri);

            HttpRequestMessage msg = new HttpRequestMessage(method, uriRequest);
            msg.Content = content;

            return msg;
        }

        /// <summary>
        /// Creates the specified Uri.
        /// </summary>
        /// <param name="uri">The Uri to create.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpRequestMessage Create(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a cloud resource.
        /// </summary>
        /// <param name="uri">The absolute URI to the resource.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="builder">An optional query builder to use.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        internal static HttpRequestMessage GetAcl(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "acl");

            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a cloud resource.
        /// </summary>
        /// <param name="uri">The absolute URI to the resource.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="builder">An optional query builder to use.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        internal static HttpRequestMessage SetAcl(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "acl");

            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="uri">The Uri to query.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpRequestMessage GetProperties(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Head, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <param name="uri">The blob Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpRequestMessage GetMetadata(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "metadata");

            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Head, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Sets the metadata.
        /// </summary>
        /// <param name="uri">The blob Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpRequestMessage SetMetadata(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "metadata");

            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="metadata">The metadata.</param>
        internal static void AddMetadata(HttpRequestMessage request, IDictionary<string, string> metadata)
        {
            if (metadata != null)
            {
                foreach (KeyValuePair<string, string> entry in metadata)
                {
                    AddMetadata(request, entry.Key, entry.Value);
                }
            }
        }

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="name">The metadata name.</param>
        /// <param name="value">The metadata value.</param>
        internal static void AddMetadata(HttpRequestMessage request, string name, string value)
        {
            CommonUtils.AssertNotNullOrEmpty("value", value);
            request.Headers.Add("x-ms-meta-" + name, value);
        }

        /// <summary>
        /// Deletes the specified Uri.
        /// </summary>
        /// <param name="uri">The Uri to delete.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpRequestMessage Delete(Uri uri, int? timeout, UriQueryBuilder builder, HttpContent content, OperationContext operationContext)
        {
            HttpRequestMessage request = CreateRequestMessage(HttpMethod.Delete, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Creates a web request to get the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to get the service properties.</returns>
        internal static HttpRequestMessage GetServiceProperties(Uri uri, int? timeout, OperationContext operationContext)
        {
            UriQueryBuilder builder = GetServiceUriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Get, uri, timeout, builder, null /* content */, operationContext);
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
            UriQueryBuilder builder = GetServiceUriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpRequestMessage request = HttpRequestMessageFactory.CreateRequestMessage(HttpMethod.Put, uri, timeout, builder, content, operationContext);
            return request;
        }

        /// <summary>
        /// Generates a query builder for building service requests.
        /// </summary>
        /// <returns>A <see cref="UriQueryBuilder"/> for building service requests.</returns>
        internal static UriQueryBuilder GetServiceUriQueryBuilder()
        {
            UriQueryBuilder uriBuilder = new UriQueryBuilder();
            uriBuilder.Add(Constants.QueryConstants.ResourceType, "service");
            return uriBuilder;
        }

        public static HttpRequestMessage BuildRequest<T>(HttpMethod method, StorageCommandBase<T> cmd, HttpContent content, OperationContext operationContext)
        {
            if (cmd.Builder == null)
            {
                cmd.Builder = new UriQueryBuilder();
            }

            if (cmd.ServerTimeoutInSeconds.HasValue && cmd.ServerTimeoutInSeconds != 0)
            {
                cmd.Builder.Add("timeout", cmd.ServerTimeoutInSeconds.ToString());
            }

            Uri uriRequest = cmd.Builder.AddToUri(cmd.Uri);

            HttpRequestMessage msg = new HttpRequestMessage(method, uriRequest);
            msg.Content = content;
            return msg;
        }
    }
}
