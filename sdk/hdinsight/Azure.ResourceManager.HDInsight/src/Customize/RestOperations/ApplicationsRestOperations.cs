// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.HDInsight
{
    internal partial class Applications
    {
        internal HttpMessage CreateGetAzureAsyncOperationStatusRequest(string subscriptionId, string resourceGroupName, string clusterName, string applicationName, string operationId, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.HDInsight/clusters/", false);
            uri.AppendPath(clusterName, true);
            uri.AppendPath("/applications/", false);
            uri.AppendPath(applicationName, true);
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
