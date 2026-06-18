// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

#pragma warning disable SCME0001

/// <summary>
/// The class containing various extension methods.
/// </summary>
public static partial class AzureAIExtensions
{
    // ResponseItem
    /// <summary> Converts an OpenAI response item into an agent response item. </summary>
    /// <param name="responseItem"> The OpenAI response item to convert. </param>
    /// <returns> The agent response item representation. </returns>
    public static ResponseItem AsAgentResponseItem(this ResponseItem responseItem)
    {
        BinaryData serializedResponseItem = ModelReaderWriter.Write(responseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseItem>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
    }

    // ResponseResult
    extension(ResponseResult response)
    {
        /// <summary> Gets the agent associated with the response result. </summary>
        public AgentReference Agent => response.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);

        /// <summary> Gets the agent conversation ID associated with the response result. </summary>
        public string AgentConversationId => response.Patch.GetStringEx("$.conversation.id"u8);
    }

    // ResponsesClient
    /// <summary> Creates a response for an existing project conversation and agent. </summary>
    /// <param name="responseClient"> The response client used to send the request. </param>
    /// <param name="conversation"> The project conversation to continue. </param>
    /// <param name="agentRef"> The agent that should create the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
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

    /// <summary> Asynchronously creates a response for an existing project conversation and agent. </summary>
    /// <param name="responseClient"> The response client used to send the request. </param>
    /// <param name="conversation"> The project conversation to continue. </param>
    /// <param name="agentRef"> The agent that should create the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
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
        JsonObject options = JsonObject.Parse(json).AsObject();
        options.Remove("input");
        return BinaryContent.CreateJson(options.ToJsonString());
    }

    /// <summary> Gets the Azure file status value recorded on an OpenAI file. </summary>
    /// <param name="file"> The OpenAI file to inspect. </param>
    /// <returns> The Azure file status, or null when no status is available. </returns>
    public static string GetAzureFileStatus(this OpenAIFile file)
    {
        using BinaryContent contentBytes = BinaryContent.Create(file, ModelSerializationExtensions.WireOptions);
        using var stream = new MemoryStream();
        contentBytes.WriteTo(stream);
        string json = Encoding.UTF8.GetString(stream.ToArray());
        JsonDocument doc = JsonDocument.Parse(json);
        if (doc.RootElement.TryGetProperty("_sdk_status", out JsonElement extraStatusElement))
        {
            string extraStatusValue = extraStatusElement.GetString();
            if (!string.IsNullOrEmpty(extraStatusValue))
            {
                return extraStatusValue;
            }
        }
        return null;
    }

    extension(CreateResponseOptions options)
    {
        /// <summary> Gets or sets the agent associated with the response options. </summary>
        public AgentReference Agent
        {
            get => options.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);
            set => options.Patch.SetOrClearEx("$.agent_reference"u8, "$.agent_reference"u8, value);
        }

        /// <summary> Gets or sets the agent conversation ID associated with the response options. </summary>
        public string AgentConversationId
        {
            get => options.Patch.GetStringEx("$.conversation.id"u8);
            set => options.Patch.SetOrClearEx("$.conversation.id"u8, "$.conversation"u8, value);
        }
    }
}
