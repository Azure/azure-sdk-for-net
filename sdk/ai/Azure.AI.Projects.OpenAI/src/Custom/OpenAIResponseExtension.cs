// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Projects.OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

public static partial class OpenAIResponseExtension
{
    public static ClientResult<OpenAIResponse> CreateResponse(this OpenAIResponseClient responseClient, AgentConversation conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = RemoveItems(conversation: conversation, agentRef: agentRef);
        ClientResult protocolResult = responseClient.CreateResponse(
            content,
            cancellationToken.ToRequestOptions() ?? new RequestOptions()
        );
        OpenAIResponse convenienceValue = (OpenAIResponse)protocolResult;
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    public static async Task<ClientResult<OpenAIResponse>> CreateResponseAsync(this OpenAIResponseClient responseClient, AgentConversation conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = RemoveItems(conversation: conversation, agentRef: agentRef);
        ClientResult protocolResult = await responseClient.CreateResponseAsync(
            content,
            cancellationToken.ToRequestOptions() ?? new RequestOptions()
        ).ConfigureAwait(false);
        OpenAIResponse convenienceValue = (OpenAIResponse)protocolResult;
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    private static BinaryContent RemoveItems(AgentConversation conversation, AgentReference agentRef)
    {
        ResponseCreationOptions responseOptions = new()
        {
            Agent = agentRef,
            AgentConversationId = conversation.Id,
        };
        using BinaryContent contentBytes = BinaryContent.Create(responseOptions, ModelSerializationExtensions.WireOptions);
        using var stream = new MemoryStream();
        contentBytes.WriteTo(stream);
        string json = Encoding.UTF8.GetString(stream.ToArray());
        JsonObject fixedOptions = new();
        JsonObject options = JsonObject.Parse(json).AsObject();
        options.Remove("input");
        return BinaryContent.CreateJson(options.ToJsonString());
    }
}
