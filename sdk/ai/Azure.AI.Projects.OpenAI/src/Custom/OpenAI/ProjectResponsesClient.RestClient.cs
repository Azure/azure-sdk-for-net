// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OpenAI;
using OpenAI.Conversations;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectResponsesClient
{
    private static PipelineMessageClassifier _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

    internal virtual PipelineMessage CreateGetProjectResponsesRequest(int? limit, string order, string after, string before, string agentName, string agentId, string conversationId, RequestOptions options)
    {
        ClientUriBuilder uri = new ClientUriBuilder();
        uri.Reset(Endpoint);
        uri.AppendPath("/responses", false);
        if (limit != null)
        {
            uri.AppendQuery("limit", TypeFormatters.ConvertToString(limit), true);
        }
        if (order != null)
        {
            uri.AppendQuery("order", order, true);
        }
        if (after != null)
        {
            uri.AppendQuery("after", after, true);
        }
        if (before != null)
        {
            uri.AppendQuery("before", before, true);
        }
        if (!string.IsNullOrEmpty(agentName))
        {
            uri.AppendQuery("agent_name", agentName, escape: true);
        }
        if (!string.IsNullOrEmpty(agentId))
        {
            uri.AppendQuery("agent_id", agentId, escape: true);
        }
        if (!string.IsNullOrEmpty(conversationId))
        {
            uri.AppendQuery("conversation_id", conversationId, escape: true);
        }
        PipelineMessage message = Pipeline.CreateMessage(uri.ToUri(), "GET", PipelineMessageClassifier200);
        PipelineRequest request = message.Request;
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }
}
