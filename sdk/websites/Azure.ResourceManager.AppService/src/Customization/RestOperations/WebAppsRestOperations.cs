// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Azure.ResourceManager.AppService.Models;
using System.Text.Json;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.AppService
{
    internal partial class WebAppsRestOperations
    {
        internal HttpMessage CreateListFunctionKeysRequest(string subscriptionId, string resourceGroupName, string name, string functionName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Web/sites/", false);
            uri.AppendPath(name, true);
            uri.AppendPath("/functions/", false);
            uri.AppendPath(functionName, true);
            uri.AppendPath("/listkeys", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            _userAgent.Apply(message);
            return message;
        }

        /// <summary> Description for Get function keys for a function in a web site, or a deployment slot. </summary>
        /// <param name="subscriptionId"> Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000). </param>
        /// <param name="resourceGroupName"> Name of the resource group to which the resource belongs. </param>
        /// <param name="name"> Site name. </param>
        /// <param name="functionName"> Function name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="functionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="functionName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release, please use `ListFunctionKeysAsDictionaryAsync` instead", false)]
        public async Task<Response<AppServiceConfigurationDictionary>> ListFunctionKeysAsync(string subscriptionId, string resourceGroupName, string name, string functionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(functionName, nameof(functionName));

            using var message = CreateListFunctionKeysRequest(subscriptionId, resourceGroupName, name, functionName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AppServiceConfigurationDictionary value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = AppServiceConfigurationDictionary.DeserializeAppServiceConfigurationDictionary(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }

        /// <summary> Description for Get function keys for a function in a web site, or a deployment slot. </summary>
        /// <param name="subscriptionId"> Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000). </param>
        /// <param name="resourceGroupName"> Name of the resource group to which the resource belongs. </param>
        /// <param name="name"> Site name. </param>
        /// <param name="functionName"> Function name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="functionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/> or <paramref name="functionName"/> is an empty string, and was expected to be non-empty. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release, please use `ListFunctionKeysAsDictionary` instead", false)]
        public Response<AppServiceConfigurationDictionary> ListFunctionKeys(string subscriptionId, string resourceGroupName, string name, string functionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(functionName, nameof(functionName));

            using var message = CreateListFunctionKeysRequest(subscriptionId, resourceGroupName, name, functionName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        AppServiceConfigurationDictionary value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = AppServiceConfigurationDictionary.DeserializeAppServiceConfigurationDictionary(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
