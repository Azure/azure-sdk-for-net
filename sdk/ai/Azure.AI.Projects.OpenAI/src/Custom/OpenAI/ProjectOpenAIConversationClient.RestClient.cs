// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.AI.Projects.OpenAI;
using OpenAI.Conversations;

namespace Azure.AI.Projects.OpenAI;

public partial class ProjectOpenAIConversationClient : ConversationClient
{
    /*
     * Protocol message implementations are reproduced from the official OpenAI library
     * https://github.com/openai/openai-dotnet/blob/ba45b1f4a01b0f0ca6e0e75d6382d7a1662ffa90/src/Generated/ConversationClient.RestClient.cs#L18
     * This logic is temporary pending incorporation of convenience layer Conversations support in the official library.
     */

    private static PipelineMessageClassifier _pipelineMessageClassifier200;
    private static PipelineMessageClassifier PipelineMessageClassifier200 => _pipelineMessageClassifier200 = PipelineMessageClassifier.Create(stackalloc ushort[] { 200 });

    internal PipelineMessage CreateGetAgentConversationsRequest(int? limit, string order, string after, string before, string agentName, string agentId, RequestOptions options)
    {
        ClientUriBuilder uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/openai/conversations", false);
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
        if (agentName != null)
        {
            uri.AppendQuery("agent_name", agentName, true);
        }
        if (agentId != null)
        {
            uri.AppendQuery("agent_id", agentId, true);
        }
        PipelineMessage message = Pipeline.CreateMessage(uri.ToUri(), "GET", PipelineMessageClassifier200);
        PipelineRequest request = message.Request;
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }

    internal virtual PipelineMessage CreateGetAgentConversationItemsRequest(string conversationId, int? limit, string order, string after, IEnumerable<IncludedConversationItemProperty> include, RequestOptions options)
    {
        ClientUriBuilder uri = new ClientUriBuilder();
        uri.Reset(_endpoint);
        uri.AppendPath("/conversations/", false);
        uri.AppendPath(conversationId, true);
        uri.AppendPath("/items", false);
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
        if (include != null && !(include is ChangeTrackingList<IncludedConversationItemProperty> changeTrackingList && changeTrackingList.IsUndefined))
        {
            foreach (var @param in include)
            {
                uri.AppendQuery("include", @param.ToString(), true);
            }
        }
        PipelineMessage message = Pipeline.CreateMessage(uri.ToUri(), "GET", PipelineMessageClassifier200);
        PipelineRequest request = message.Request;
        request.Headers.Set("Accept", "application/json");
        message.Apply(options);
        return message;
    }
}
