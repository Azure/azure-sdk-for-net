// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.SecurityCenter
{
    internal partial class DiscoveredSecuritySolutions
    {
        // These legacy REST helpers back obsolete GA methods whose paths are no longer represented by the generated TypeSpec client.
        internal HttpMessage CreateGetRequest(Guid subscriptionId, string resourceGroupName, AzureLocation ascLocation, string discoveredSecuritySolutionName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Security/locations/", false);
            uri.AppendPath(ascLocation.ToString(), true);
            uri.AppendPath("/discoveredSecuritySolutions/", false);
            uri.AppendPath(discoveredSecuritySolutionName, true);
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

        internal HttpMessage CreateGetByHomeRegionRequest(Guid subscriptionId, AzureLocation ascLocation, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId.ToString(), true);
            uri.AppendPath("/providers/Microsoft.Security/locations/", false);
            uri.AppendPath(ascLocation.ToString(), true);
            uri.AppendPath("/discoveredSecuritySolutions", false);
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

        internal HttpMessage CreateNextGetByHomeRegionRequest(Uri nextPage, Guid subscriptionId, AzureLocation ascLocation, RequestContext context)
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
            if (_apiVersion != null)
            {
                uri.UpdateQuery("api-version", _apiVersion);
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
