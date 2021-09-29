// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Resources
{
    internal partial class ProviderRestOperations
    {
        internal HttpMessage CreateGetAtTenantScopeRequest(string resourceProviderNamespace, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/providers/", false);
            uri.AppendPath(resourceProviderNamespace, true);
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            uri.AppendQuery("api-version", "2019-10-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public Response<ProviderInfo> GetAtTenantScope(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceProviderNamespace == null)
            {
                throw new ArgumentNullException(nameof(resourceProviderNamespace));
            }

            using var message = CreateGetAtTenantScopeRequest(resourceProviderNamespace, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderInfo value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProviderInfo.DeserializeProviderInfo(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        /// <summary> Gets the specified resource provider at the tenant level. </summary>
        /// <param name="resourceProviderNamespace"> The namespace of the resource provider. </param>
        /// <param name="expand"> The $expand query parameter. For example, to include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceProviderNamespace"/> is null. </exception>
        public async Task<Response<ProviderInfo>> GetAtTenantScopeAsync(string resourceProviderNamespace, string expand = null, CancellationToken cancellationToken = default)
        {
            if (resourceProviderNamespace == null)
            {
                throw new ArgumentNullException(nameof(resourceProviderNamespace));
            }

            using var message = CreateGetAtTenantScopeRequest(resourceProviderNamespace, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderInfo value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProviderInfo.DeserializeProviderInfo(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        internal HttpMessage CreateListAtTenantScopeRequest(int? top, string expand)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendPath("/providers", false);
            if (top != null)
            {
                uri.AppendQuery("$top", top.Value, true);
            }
            if (expand != null)
            {
                uri.AppendQuery("$expand", expand, true);
            }
            uri.AppendQuery("api-version", "2019-10-01", true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        internal HttpMessage CreateListAtTenantScopeNextPageRequest(string nextLink)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("UserAgentOverride", _userAgent);
            return message;
        }

        /// <summary> Gets all resource providers for the tenant. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all providers. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public Response<ProviderInfoListResult> ListAtTenantScope(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListAtTenantScopeRequest(top, expand);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderInfoListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProviderInfoListResult.DeserializeProviderInfoListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        /// <summary> Gets all resource providers for the tenant. </summary>
        /// <param name="top"> The number of results to return. If null is passed returns all providers. </param>
        /// <param name="expand"> The properties to include in the results. For example, use &amp;$expand=metadata in the query string to retrieve resource provider metadata. To include property aliases in response, use $expand=resourceTypes/aliases. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async Task<Response<ProviderInfoListResult>> ListAtTenantScopeAsync(int? top = null, string expand = null, CancellationToken cancellationToken = default)
        {
            using var message = CreateListAtTenantScopeRequest(top, expand);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderInfoListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProviderInfoListResult.DeserializeProviderInfoListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Gets all resource providers for the tenant. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public Response<ProviderInfoListResult> ListAtTenantScopeNextPage(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateListAtTenantScopeNextPageRequest(nextLink);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderInfoListResult value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = ProviderInfoListResult.DeserializeProviderInfoListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw _clientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        /// <summary> Gets all resource providers for the tenant. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/> is null. </exception>
        public async Task<Response<ProviderInfoListResult>> ListAtTenantScopeNextPageAsync(string nextLink, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }

            using var message = CreateListAtTenantScopeNextPageRequest(nextLink);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        ProviderInfoListResult value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = ProviderInfoListResult.DeserializeProviderInfoListResult(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }
    }
}
