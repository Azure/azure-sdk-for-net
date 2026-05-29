// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

// NOTE: The following customization is intentionally retained for backward compatibility.
// In previous versions, all What-If operations were implemented as part of ArmDeploymentResource.
namespace Azure.ResourceManager.Resources
{
    internal partial class ArmDeployments
    {
        internal HttpMessage CreateWhatIfAtTenantScopeRequest(string deploymentName, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateWhatIfAtManagementGroupScopeRequest(string groupId, string deploymentName, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/providers/Microsoft.Management/managementGroups/", false);
            uri.AppendPath(groupId, true);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateWhatIfAtSubscriptionScopeRequest(string subscriptionId, string deploymentName, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateWhatIfAtResourceRequest(string subscriptionId, string resourceGroupName, string deploymentName, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourcegroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Resources/deployments/", false);
            uri.AppendPath(deploymentName, true);
            uri.AppendPath("/whatIf", false);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }
    }
}
