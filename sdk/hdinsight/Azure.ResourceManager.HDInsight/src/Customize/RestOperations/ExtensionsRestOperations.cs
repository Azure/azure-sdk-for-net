// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.HDInsight
{
    internal partial class Extensions
    {
        internal HttpMessage CreateGetExtensionRequest(string subscriptionId, string resourceGroupName, string clusterName, string extensionName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(extensionName, true);
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

        internal HttpMessage CreateCreateExtensionRequest(string subscriptionId, string resourceGroupName, string clusterName, string extensionName, RequestContent content, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(extensionName, true);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Put;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateDeleteExtensionRequest(string subscriptionId, string resourceGroupName, string clusterName, string extensionName, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(extensionName, true);
            if (_apiVersion != null)
            {
                uri.AppendQuery("api-version", _apiVersion, true);
            }
            HttpMessage message = Pipeline.CreateMessage();
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Delete;
            return message;
        }

        internal HttpMessage CreateGetExtensionAsyncOperationStatusRequest(string subscriptionId, string resourceGroupName, string clusterName, string extensionName, string operationId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/extensions/", false);
            uri.AppendPath(extensionName, true);
            uri.AppendPath("/azureAsyncOperations/", false);
            uri.AppendPath(operationId, true);
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
