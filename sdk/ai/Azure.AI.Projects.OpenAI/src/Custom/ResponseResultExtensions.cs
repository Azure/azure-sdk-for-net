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

public static partial class ResponseResultExtensions
{
    public static ClientResult<ResponseResult> CreateResponse(this ResponsesClient responseClient, ProjectConversation conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = RemoveItems(conversation: conversation, agentRef: agentRef);
        ClientResult protocolResult = responseClient.CreateResponse(
            content,
            cancellationToken.ToRequestOptions() ?? new RequestOptions()
        );
        ResponseResult convenienceValue = (ResponseResult)protocolResult;
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    public static async Task<ClientResult<ResponseResult>> CreateResponseAsync(this ResponsesClient responseClient, ProjectConversation conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = RemoveItems(conversation: conversation, agentRef: agentRef);
        ClientResult protocolResult = await responseClient.CreateResponseAsync(
            content,
            cancellationToken.ToRequestOptions() ?? new RequestOptions()
        ).ConfigureAwait(false);
        ResponseResult convenienceValue = (ResponseResult)protocolResult;
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    private static BinaryContent RemoveItems(ProjectConversation conversation, AgentReference agentRef)
    {
        CreateResponseOptions responseOptions = new()
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
