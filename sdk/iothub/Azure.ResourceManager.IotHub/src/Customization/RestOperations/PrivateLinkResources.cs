// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.IotHub
{
    internal partial class PrivateLinkResources
    {
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        protected PrivateLinkResources()
        {
        }

        internal PrivateLinkResources(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint, string apiVersion)
        {
            ClientDiagnostics = clientDiagnostics;
            _endpoint = endpoint;
            Pipeline = pipeline;
            _apiVersion = apiVersion;
        }

        public virtual HttpPipeline Pipeline { get; }

        internal ClientDiagnostics ClientDiagnostics { get; }

        internal HttpMessage CreateGetRequest(Guid subscriptionId, string resourceGroupName, string resourceName, string groupId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Devices/iotHubs/", false);
            uri.AppendPath(resourceName, true);
            uri.AppendPath("/privateLinkResources/", false);
            uri.AppendPath(groupId, true);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetAllRequest(Guid subscriptionId, string resourceGroupName, string resourceName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Devices/iotHubs/", false);
            uri.AppendPath(resourceName, true);
            uri.AppendPath("/privateLinkResources", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Get;
            request.Headers.SetValue("Accept", "application/json");
            return message;
        }
    }
}
