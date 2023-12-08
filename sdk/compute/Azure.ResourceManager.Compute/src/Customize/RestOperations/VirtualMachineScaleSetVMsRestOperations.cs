// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    internal partial class VirtualMachineScaleSetVMsRestOperations
    {
        internal HttpMessage CreateUpdateRequest(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, VirtualMachineScaleSetVmData data)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(virtualMachineScaleSetName, true);
            uri.AppendPath("/virtualMachines/", false);
            uri.AppendPath(instanceId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(data);
            request.Content = content;
            _userAgent.Apply(message);
            return message;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<Response> UpdateAsync(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(virtualMachineScaleSetName, nameof(virtualMachineScaleSetName));
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, virtualMachineScaleSetName, instanceId, data);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Response Update(string subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, string instanceId, VirtualMachineScaleSetVmData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNullOrEmpty(resourceGroupName, nameof(resourceGroupName));
            Argument.AssertNotNullOrEmpty(virtualMachineScaleSetName, nameof(virtualMachineScaleSetName));
            Argument.AssertNotNullOrEmpty(instanceId, nameof(instanceId));
            Argument.AssertNotNull(data, nameof(data));

            using var message = CreateUpdateRequest(subscriptionId, resourceGroupName, virtualMachineScaleSetName, instanceId, data);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw new RequestFailedException(message.Response);
            }
        }
    }
}
