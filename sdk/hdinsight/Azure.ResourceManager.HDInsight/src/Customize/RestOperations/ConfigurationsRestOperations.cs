// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.HDInsight
{
    internal partial class Configurations
    {
        internal HttpMessage CreateGetConfigurationByNameRequest(string subscriptionId, string resourceGroupName, string clusterName, string configurationName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/configurations/", false);
            uri.AppendPath(configurationName, true);
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

        internal HttpMessage CreateUpdateConfigurationRequest(string subscriptionId, string resourceGroupName, string clusterName, string configurationName, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/configurations/", false);
            uri.AppendPath(configurationName, true);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Content = content;
            return message;
        }
    }
}
