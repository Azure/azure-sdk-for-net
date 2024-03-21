// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    internal partial class PipelineRunsRestOperations
    {
        internal HttpMessage CreateQueryByFactoryNextPageRequest(string subscriptionId, string resourceGroupName, string factoryName, RunFilterContent content, string continuationToken)
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
            uri.AppendPath("/providers/Microsoft.DataFactory/factories/", false);
            uri.AppendPath(factoryName, true);
            uri.AppendPath("/queryPipelineRuns", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content0 = new Utf8JsonRequestContent();
            // copy filter parameters, and set continuation token
            content0.JsonWriter.WriteObjectValue(new RunFilterContent(continuationToken, content.LastUpdatedAfter, content.LastUpdatedBefore, content.Filters, content.OrderBy, null));
            request.Content = content0;
            _userAgent.Apply(message);
            return message;
        }
    }
}
