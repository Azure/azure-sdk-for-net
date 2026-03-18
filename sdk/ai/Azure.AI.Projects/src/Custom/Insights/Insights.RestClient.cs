// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Projects;

public partial class Insights
{
    internal PipelineMessage CreateNextGetAllRequest(Uri nextPage, string foundryFeatures, string @type, string evalId, string runId, string agentName, bool? includeCoordinates, RequestOptions options)
    {
        ClientUriBuilder uri = new ClientUriBuilder();
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
        PipelineMessage message = Pipeline.CreateMessage(uri.ToUri(), "GET", PipelineMessageClassifier200);
        PipelineRequest request = message.Request;
        if (foundryFeatures != null)
        {
            request.Headers.Set("Foundry-Features", foundryFeatures);
        }
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }
}
