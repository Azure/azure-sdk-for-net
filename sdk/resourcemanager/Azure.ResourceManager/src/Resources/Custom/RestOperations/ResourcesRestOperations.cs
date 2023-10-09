// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Resources
{
    internal partial class ResourcesRestOperations
    {
        internal HttpMessage CreateGetByIdRequest(string resourceId, string apiVersion)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/", false);
            uri.AppendPath(resourceId, false);
            uri.AppendQuery("api-version", apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Gets a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="apiVersion"/> is null. </exception>
        public async Task<Response<GenericResourceData>> GetByIdAsync(string resourceId, string apiVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            using var message = CreateGetByIdRequest(resourceId, apiVersion);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        GenericResourceData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = GenericResourceData.DeserializeGenericResourceData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((GenericResourceData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Gets a resource by ID. </summary>
        /// <param name="resourceId"> The fully qualified ID of the resource, including the resource name and resource type. Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}. </param>
        /// <param name="apiVersion"> The API version to use for the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceId"/> or <paramref name="apiVersion"/> is null. </exception>
        public Response<GenericResourceData> GetById(string resourceId, string apiVersion, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceId, nameof(resourceId));
            Argument.AssertNotNull(apiVersion, nameof(apiVersion));

            using var message = CreateGetByIdRequest(resourceId, apiVersion);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        GenericResourceData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = GenericResourceData.DeserializeGenericResourceData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((GenericResourceData)null, message.Response);
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
