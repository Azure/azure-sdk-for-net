// -----------------------------------------------------------------------------------------
// <copyright file="HttpWebRequestFactory.cs" company="Microsoft">
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
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
 
#if !COMMON
using System.Xml;
using System.Xml.Linq;
#endif

using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Core.Util;

namespace Microsoft.WindowsAzure.Storage.Shared.Protocol
{
    public static class HttpWebRequestFactory
    {
        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="uri">The request Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest CreateWebRequest(string method, Uri uri, int? timeout, UriQueryBuilder builder, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            if (timeout != 0)
            {
                builder.Add("timeout", timeout.ToString());
            }

            Uri uriRequest = builder.AddToUri(uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriRequest);
            request.Method = method;
            request.Headers.Add(Constants.HeaderConstants.StorageVersionHeader, Constants.HeaderConstants.TargetStorageVersion);
            request.UserAgent = Constants.HeaderConstants.UserAgent;
            request.KeepAlive = true;

            // Disable the Expect 100-Continue
            request.ServicePoint.Expect100Continue = false;

            return request;
        }

        /// <summary>
        /// Creates the specified Uri.
        /// </summary>
        /// <param name="uri">The Uri to create.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest Create(Uri uri, int? timeout, UriQueryBuilder builder, OperationContext operationContext)
        {
            HttpWebRequest request = CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a cloud resource.
        /// </summary>
        /// <param name="uri">The absolute URI to the resource.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="builder">An optional query builder to use.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        internal static HttpWebRequest GetAcl(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "acl");

            HttpWebRequest request = CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a cloud resource.
        /// </summary>
        /// <param name="uri">The absolute URI to the resource.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="builder">An optional query builder to use.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to use to perform the operation.</returns>
        internal static HttpWebRequest SetAcl(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "acl");

            HttpWebRequest request = CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
            return request;
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="uri">The Uri to query.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest GetProperties(Uri uri, int? timeout, UriQueryBuilder builder, OperationContext operationContext)
        {
            HttpWebRequest request = CreateWebRequest(WebRequestMethods.Http.Head, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <param name="uri">The blob Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest GetMetadata(Uri uri, int? timeout, UriQueryBuilder builder, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "metadata");

            HttpWebRequest request = CreateWebRequest(WebRequestMethods.Http.Head, uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Sets the metadata.
        /// </summary>
        /// <param name="uri">The blob Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest SetMetadata(Uri uri, int? timeout, UriQueryBuilder builder, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "metadata");

            HttpWebRequest request = CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
            request.ContentLength = 0;
            return request;
        }

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="metadata">The metadata.</param>
        internal static void AddMetadata(HttpWebRequest request, IDictionary<string, string> metadata)
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
        internal static void AddMetadata(HttpWebRequest request, string name, string value)
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
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest Delete(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            HttpWebRequest request = CreateWebRequest("DELETE", uri, timeout, builder, operationContext);
            return request;
        }

        /// <summary>
        /// Creates a web request to get the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to get the service properties.</returns>
        internal static HttpWebRequest GetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }
            
            builder.Add(Constants.QueryConstants.Component, "properties");
            builder.Add(Constants.QueryConstants.ResourceType, "service");

            return CreateWebRequest(WebRequestMethods.Http.Get, uri, timeout, builder, operationContext);
        }

        /// <summary>
        /// Creates a web request to set the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object for tracking the current operation.</param>
        /// <returns>A web request to set the service properties.</returns>
        internal static HttpWebRequest SetServiceProperties(Uri uri, UriQueryBuilder builder, int? timeout, OperationContext operationContext)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "properties");
            builder.Add(Constants.QueryConstants.ResourceType, "service");

            return CreateWebRequest(WebRequestMethods.Http.Put, uri, timeout, builder, operationContext);
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
    }
}
