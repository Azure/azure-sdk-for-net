// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    // These request methods use the Microsoft.Compute resource type so ArmClientOptions.SetApiVersion can override them.
    [CodeGenSuppress("CreateGetVirtualMachineScaleSetPublicIPAddressesRequest", typeof(Guid), typeof(string), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("CreateNextGetVirtualMachineScaleSetPublicIPAddressesRequest", typeof(Uri), typeof(Guid), typeof(string), typeof(string), typeof(RequestContext))]
    internal partial class PublicIPAddressesOperationGroup
    {
        private static readonly ResourceType s_virtualMachineScaleSetPublicIPAddressResourceType = new("Microsoft.Compute/virtualMachineScaleSets/publicIPAddresses");

        internal HttpMessage CreateGetVirtualMachineScaleSetPublicIPAddressesRequest(Guid subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/virtualMachineScaleSets/", false);
            uri.AppendPath(virtualMachineScaleSetName, true);
            uri.AppendPath("/publicipaddresses", false);
            uri.AppendQuery("api-version", GetVirtualMachineScaleSetPublicIPAddressApiVersion(), true);
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            _userAgent.Apply(message);
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateNextGetVirtualMachineScaleSetPublicIPAddressesRequest(Uri nextPage, Guid subscriptionId, string resourceGroupName, string virtualMachineScaleSetName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            if (nextPage.IsAbsoluteUri)
            {
                uri.Reset(nextPage);
            }
            else
            {
                uri.Reset(new Uri(_endpoint, nextPage));
            }
            uri.UpdateQuery("api-version", GetVirtualMachineScaleSetPublicIPAddressApiVersion());
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            _userAgent.Apply(message);
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        private string GetVirtualMachineScaleSetPublicIPAddressApiVersion()
            => _getApiVersion?.Invoke(s_virtualMachineScaleSetPublicIPAddressResourceType) ?? _apiVersion;
    }
}
