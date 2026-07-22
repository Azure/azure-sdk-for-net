// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Conversations;
using OpenAI.Files;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

//#pragma warning disable SCME0001

/// <summary>
/// The class containing various extension methods.
/// </summary>
public static partial class AzureAIExtensions
{
    // ResponseItem
    /// <summary> Converts an OpenAI response item into an agent response item. </summary>
    /// <param name="responseItem"> The OpenAI response item to convert. </param>
    /// <returns> The agent response item representation. </returns>
    internal static ResponseItem AsAgentResponseItem(this ResponseItem responseItem)
    {
        BinaryData serializedResponseItem = ModelReaderWriter.Write(responseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseItem>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
    }

    // Whether an already-materialized item still needs client-side normalization: its discriminator is one this
    // package can strongly type (per UnknownAzureResponseItem's dispatch table) and it is not already that concrete
    // type. Keying off the known-discriminator set — rather than matching OpenAI's internal opaque type name — means
    // an upstream rename of that fallback cannot silently disable normalization, and it is naturally idempotent.
    [Experimental("AAIP001")]
    private static bool NeedsAgentItemNormalization(ResponseItem item)
        => item is not null
            && UnknownAzureResponseItem.TryGetAzureItemType(item.Kind, out Type azureType)
            && !azureType.IsInstanceOfType(item);

    // Returns the strongly-typed Azure subtype for an item that needs it, or the item unchanged otherwise.
    [Experimental("AAIP001")]
    private static ResponseItem NormalizeAgentResponseItem(ResponseItem item)
        => NeedsAgentItemNormalization(item) ? item.AsAgentResponseItem() : item;

    // Round-trips a tool through the Azure context so a tool that OpenAI could not strongly type re-dispatches
    // to its concrete Azure subtype, mirroring AsAgentResponseItem for the tool axis.
    private static ResponseTool AsAgentResponseTool(ResponseTool responseTool)
    {
        BinaryData serializedTool = ModelReaderWriter.Write(responseTool, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseTool>(serializedTool, ModelSerializationExtensions.WireOptions, AzureAIExtensionsOpenAIContext.Default);
    }

    // Whether an already-materialized tool still needs client-side normalization, keyed off the known Azure tool
    // discriminator set (see NeedsAgentItemNormalization for the rationale).
    private static bool NeedsAgentToolNormalization(ResponseTool tool)
        => tool is not null
            && UnknownAzureResponseTool.TryGetAzureToolType(tool.Kind, out Type azureType)
            && !azureType.IsInstanceOfType(tool);

    // Returns the strongly-typed Azure subtype for a tool that needs it, or the tool unchanged otherwise.
    private static ResponseTool NormalizeAgentResponseTool(ResponseTool tool)
        => NeedsAgentToolNormalization(tool) ? AsAgentResponseTool(tool) : tool;

    /// <summary>
    /// Re-dispatches any opaque (unrecognized) items in a response's output through the Azure
    /// context so callers receive strongly-typed Azure subtypes without invoking
    /// <see cref="AsAgentResponseItem(ResponseItem)"/> themselves. Mutates the output list in
    /// place. Non-Azure unknowns round-trip back to the same opaque type, so this is a no-op for
    /// them. This is a temporary client-side bridge until nested-item deserialization is handled
    /// by the serialization proxy.
    /// </summary>
    [Experimental("AAIP001")]
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
            if (NeedsAgentItemNormalization(item))
            {
                items[i] = item.AsAgentResponseItem();
            }
        }
    }

    /// <summary>
    /// Re-dispatches any opaque (unrecognized) tool definitions echoed on a response through the
    /// Azure context so callers receive strongly-typed Azure tool subtypes (e.g.
    /// <c>BingGroundingTool</c>) rather than OpenAI's opaque unknown-tool fallback. Mutates the
    /// tool list in place. Non-Azure unknowns round-trip back to the same opaque type, so this is a
    /// no-op for them. Temporary client-side bridge, mirroring <see cref="NormalizeAgentOutputItems"/>.
    /// </summary>
    internal static void NormalizeAgentTools(ResponseResult response)
    {
        if (response is null)
        {
            return;
        }

        IList<ResponseTool> tools = response.Tools;
        if (tools is null || tools.IsReadOnly)
        {
            return;
        }

        for (int i = 0; i < tools.Count; i++)
        {
            ResponseTool tool = tools[i];
            if (NeedsAgentToolNormalization(tool))
            {
                tools[i] = AsAgentResponseTool(tool);
            }
        }
    }

    /// <summary>
    /// Normalizes both the output items and the echoed tool definitions of a response, so callers
    /// receive strongly-typed Azure subtypes across the whole result. Null-safe.
    /// </summary>
    [Experimental("AAIP001")]
    internal static void NormalizeAgentResponse(ResponseResult response)
    {
        NormalizeAgentOutputItems(response);
        NormalizeAgentTools(response);
    }

    /// <summary>
    /// Re-dispatches opaque response items and tools carried by a streaming update into their
    /// strongly-typed Azure subtypes, mutating the update in place. Incremental item updates carry a
    /// single <c>ResponseItem</c>; every lifecycle update
    /// (created/in&#8209;progress/queued/incomplete/failed/completed) carries a snapshot
    /// <see cref="ResponseResult"/> whose output items and tools are normalized via
    /// <see cref="NormalizeAgentResponse(ResponseResult)"/> — a consumer inspecting the response on,
    /// say, a failed update must still see typed items. Other update kinds pass through unchanged.
    /// Temporary client-side bridge, mirroring <see cref="NormalizeAgentResponse"/>.
    /// </summary>
    [Experimental("AAIP001")]
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
                NormalizeAgentResponse(completed.Response);
                break;
            case StreamingResponseCreatedUpdate created:
                NormalizeAgentResponse(created.Response);
                break;
            case StreamingResponseInProgressUpdate inProgress:
                NormalizeAgentResponse(inProgress.Response);
                break;
            case StreamingResponseQueuedUpdate queued:
                NormalizeAgentResponse(queued.Response);
                break;
            case StreamingResponseIncompleteUpdate incomplete:
                NormalizeAgentResponse(incomplete.Response);
                break;
            case StreamingResponseFailedUpdate failed:
                NormalizeAgentResponse(failed.Response);
                break;
        }

        return update;
    }

    // ResponseItem
    extension(ResponseItem item)
    {
        /// <summary> Gets the agent that produced this response item, when reported by the service. </summary>
        [Experimental("SCME0001")]
        public AgentReference AgentReference
        {
            get => item.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);
        }

        /// <summary> Gets the ID of the response on which this item was created, when reported by the service. </summary>
        [Experimental("SCME0001")]
        public string ResponseId
        {
            get => item.Patch.GetStringEx("$.response_id"u8);
        }
    }

    // ResponseResult
    extension(ResponseResult response)
    {
        /// <summary> Gets the agent associated with the response result. </summary>
        [Experimental("SCME0001")]
        public AgentReference Agent
        {
            get => response.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);
        }

        /// <summary> Gets the agent conversation ID associated with the response result. </summary>
        [Experimental("SCME0001")]
        public string AgentConversationId
        {
            get => response.Patch.GetStringEx("$.conversation.id"u8);
        }
    }

    // ResponsesClient
    /// <summary> Creates a response for an existing project conversation and agent. </summary>
    /// <param name="responseClient"> The response client used to send the request. </param>
    /// <param name="conversation"> The project conversation to continue. </param>
    /// <param name="agentRef"> The agent that should create the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    [Experimental("AAIP001")]
    public static ClientResult<ResponseResult> CreateResponse(this ResponsesClient responseClient, ConversationResource conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = RemoveItems(conversation: conversation, agentRef: agentRef);
        ClientResult protocolResult = responseClient.CreateResponse(
            content,
            cancellationToken.ToRequestOptions() ?? new RequestOptions()
        );
        ResponseResult convenienceValue = (ResponseResult)protocolResult;
        NormalizeAgentResponse(convenienceValue);
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    /// <summary> Asynchronously creates a response for an existing project conversation and agent. </summary>
    /// <param name="responseClient"> The response client used to send the request. </param>
    /// <param name="conversation"> The project conversation to continue. </param>
    /// <param name="agentRef"> The agent that should create the response. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <returns> The created response result. </returns>
    [Experimental("AAIP001")]
    public static async Task<ClientResult<ResponseResult>> CreateResponseAsync(this ResponsesClient responseClient, ConversationResource conversation, AgentReference agentRef, CancellationToken cancellationToken = default)
    {
        using BinaryContent content = RemoveItems(conversation: conversation, agentRef: agentRef);
        ClientResult protocolResult = await responseClient.CreateResponseAsync(
            content,
            cancellationToken.ToRequestOptions() ?? new RequestOptions()
        ).ConfigureAwait(false);
        ResponseResult convenienceValue = (ResponseResult)protocolResult;
        NormalizeAgentResponse(convenienceValue);
        return ClientResult.FromValue(convenienceValue, protocolResult.GetRawResponse());
    }

    [Experimental("SCME0001")]
    private static BinaryContent RemoveItems(ConversationResource conversation, AgentReference agentRef)
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
        [Experimental("SCME0001")]
        public AgentReference Agent
        {
            get => options.Patch.GetJsonModelEx<AgentReference>("$.agent_reference"u8);
            set => options.Patch.SetOrClearEx("$.agent_reference"u8, "$.agent_reference"u8, value);
        }

        /// <summary> Gets or sets the agent conversation ID associated with the response options. </summary>
        [Experimental("SCME0001")]
        public string AgentConversationId
        {
            get => options.Patch.GetStringEx("$.conversation.id"u8);
            set => options.Patch.SetOrClearEx("$.conversation.id"u8, "$.conversation"u8, value);
        }
    }
}
