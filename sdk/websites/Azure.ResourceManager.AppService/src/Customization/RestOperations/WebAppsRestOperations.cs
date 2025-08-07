// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;

namespace Azure.ResourceManager.AppService
{
    //we do this change due to the rest api accordingly did not followed the swagger spec which responsed the post wrapped by a "Properties" as a name. It just response the content like "{default="ABC", default2 ="CDE"}".
    //so we retrived the post and iterate the  json object above then Add to the AppServiceConfigurationDictionary.Properties.
    // then we can convert the Dictionary result to AppServiceConfigurationDictionary without Deserialization.
    internal partial class WebAppsRestOperations
    {
        /// <summary> Description for Get function keys for a function in a web site, or a deployment slot. </summary>
        /// <param name="subscriptionId"> Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000). </param>
        /// <param name="resourceGroupName"> Name of the resource group to which the resource belongs. </param>
        /// <param name="name"> Site name. </param>
        /// <param name="slot"> Name of the deployment slot. </param>
        /// <param name="functionName"> Function name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/>, <paramref name="slot"/> or <paramref name="functionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/>, <paramref name="slot"/> or <paramref name="functionName"/> is an empty string, and was expected to be non-empty. </exception>
        public async Task<Response<AppServiceConfigurationDictionary>> ListFunctionKeysSlotAsync(string subscriptionId, string resourceGroupName, string name, string slot, string functionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(slot, nameof(slot));
            Argument.AssertNotNullOrEmpty(functionName, nameof(functionName));

            using var message = CreateListFunctionKeysSlotRequest(subscriptionId, resourceGroupName, name, slot, functionName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        AppServiceConfigurationDictionary value = new AppServiceConfigurationDictionary();
                        foreach (var property in document.RootElement.EnumerateObject())
                        {
                            value.Properties.Add(property.Name, property.Value.GetString());
                        }
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
        /// <param name="slot"> Name of the deployment slot. </param>
        /// <param name="functionName"> Function name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/>, <paramref name="slot"/> or <paramref name="functionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="name"/>, <paramref name="slot"/> or <paramref name="functionName"/> is an empty string, and was expected to be non-empty. </exception>
        public Response<AppServiceConfigurationDictionary> ListFunctionKeysSlot(string subscriptionId, string resourceGroupName, string name, string slot, string functionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(slot, nameof(slot));
            Argument.AssertNotNullOrEmpty(functionName, nameof(functionName));

            using var message = CreateListFunctionKeysSlotRequest(subscriptionId, resourceGroupName, name, slot, functionName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        AppServiceConfigurationDictionary value = new AppServiceConfigurationDictionary();
                        foreach (var property in document.RootElement.EnumerateObject())
                        {
                            value.Properties.Add(property.Name, property.Value.GetString());
                        }
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
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        AppServiceConfigurationDictionary value = new AppServiceConfigurationDictionary();
                        foreach (var property in document.RootElement.EnumerateObject())
                        {
                            value.Properties.Add(property.Name, property.Value.GetString());
                        }
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
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        AppServiceConfigurationDictionary value = new AppServiceConfigurationDictionary();
                        foreach (var property in document.RootElement.EnumerateObject())
                        {
                            value.Properties.Add(property.Name, property.Value.GetString());
                        }
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}