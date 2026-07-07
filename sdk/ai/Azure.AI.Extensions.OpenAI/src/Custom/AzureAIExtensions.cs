// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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

    // The runtime type OpenAI materializes for any response item whose "type" discriminator
    // it does not recognize (this includes all Azure-specific kinds). Matched by name because
    // the type is internal to the OpenAI assembly.
    private const string OpenAIUnknownResponseItemTypeName = "OpenAI.Responses.InternalUnknownItemResource";

    // True when OpenAI could not recognize the item's discriminator and bucketed it into its
    // opaque unknown type. Those are the only items that need re-dispatch through the Azure context.
    private static bool IsOpaqueAgentResponseItem(ResponseItem item)
        => item is not null
            && string.Equals(item.GetType().FullName, OpenAIUnknownResponseItemTypeName, StringComparison.Ordinal);

    // Returns the strongly-typed Azure subtype for an opaque item, or the item unchanged otherwise.
    private static ResponseItem NormalizeAgentResponseItem(ResponseItem item)
        => IsOpaqueAgentResponseItem(item) ? item.AsAgentResponseItem() : item;

    /// <summary>
    /// Re-dispatches any opaque (unrecognized) items in a response's output through the Azure
    /// context so callers receive strongly-typed Azure subtypes without invoking
    /// <see cref="AsAgentResponseItem(ResponseItem)"/> themselves. Mutates the output list in
    /// place. Non-Azure unknowns round-trip back to the same opaque type, so this is a no-op for
    /// them. This is a temporary client-side bridge until nested-item deserialization is handled
    /// by the serialization proxy.
    /// </summary>
    internal static void NormalizeAgentOutputItems(ResponseResult response)
    {
        if (response is null)
        {
            return;
        }

        IList<ResponseItem> items = response.OutputItems;
        if (items is null || items.IsReadOnly)
        {
            return;
        }

        for (int i = 0; i < items.Count; i++)
        {
            ResponseItem item = items[i];
            if (IsOpaqueAgentResponseItem(item))
            {
                items[i] = item.AsAgentResponseItem();
            }
        }
    }

    /// <summary>
    /// Re-dispatches opaque response items carried by a streaming update into their strongly-typed
    /// Azure subtypes, mutating the update in place. Incremental item updates carry a single
    /// <c>ResponseItem</c>; the terminal completed update carries the full aggregate
    /// <see cref="ResponseResult"/>, whose output items are normalized via
    /// <see cref="NormalizeAgentOutputItems(ResponseResult)"/>. Other update kinds pass through
    /// unchanged. Temporary client-side bridge, mirroring <see cref="NormalizeAgentOutputItems"/>.
    /// </summary>
    internal static StreamingResponseUpdate NormalizeStreamingUpdate(StreamingResponseUpdate update)
    {
        switch (update)
        {
            case StreamingResponseOutputItemAddedUpdate added:
                added.Item = NormalizeAgentResponseItem(added.Item);
                break;
            case StreamingResponseOutputItemDoneUpdate done:
                done.Item = NormalizeAgentResponseItem(done.Item);
                break;
            case StreamingResponseCompletedUpdate completed:
                NormalizeAgentOutputItems(completed.Response);
                break;
        }

        return update;
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
        NormalizeAgentOutputItems(convenienceValue);
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
        NormalizeAgentOutputItems(convenienceValue);
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
