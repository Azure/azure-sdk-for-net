// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
#nullable disable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[System.Diagnostics.CodeAnalysis.Experimental("AAIP001")]
public partial class SharepointGroundingToolCall : AgentResponseItem, IJsonModel<SharepointGroundingToolCall>
{
    public SharepointGroundingToolCall(string callId, string arguments, ToolCallStatus status)
        : base(AgentResponseItemKind.SharepointGroundingPreviewCall)
    {
        Argument.AssertNotNull(callId, nameof(callId));
        Argument.AssertNotNull(arguments, nameof(arguments));
        CallId = callId;
        Arguments = arguments;
        Status = status;
    }

    internal SharepointGroundingToolCall(
        string id,
        AgentReference agentReference,
        string responseId,
        string callId,
        string arguments,
        ToolCallStatus status)
        : base("sharepoint_grounding_preview_call", id, agentReference, responseId)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
    }

    public string CallId { get; set; }
    public string Arguments { get; set; }
    public ToolCallStatus Status { get; set; }

    protected override AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeSharepointGroundingToolCall(document.RootElement, options);
    }

    protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => WriteModel(writer => ((IJsonModel<SharepointGroundingToolCall>)this).Write(writer, options));

    protected override AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeSharepointGroundingToolCall(document.RootElement, options);
    }

    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.JsonModelWriteCore(writer, options);
        writer.WritePropertyName("call_id"u8);
        writer.WriteStringValue(CallId);
        writer.WritePropertyName("arguments"u8);
        writer.WriteStringValue(Arguments);
        writer.WritePropertyName("status"u8);
        writer.WriteStringValue(Status.ToSerialString());
    }

    void IJsonModel<SharepointGroundingToolCall>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    SharepointGroundingToolCall IJsonModel<SharepointGroundingToolCall>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => (SharepointGroundingToolCall)JsonModelCreateCore(ref reader, options);
    BinaryData IPersistableModel<SharepointGroundingToolCall>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    SharepointGroundingToolCall IPersistableModel<SharepointGroundingToolCall>.Create(BinaryData data, ModelReaderWriterOptions options)
        => (SharepointGroundingToolCall)PersistableModelCreateCore(data, options);
    string IPersistableModel<SharepointGroundingToolCall>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    private static SharepointGroundingToolCall DeserializeSharepointGroundingToolCall(JsonElement element, ModelReaderWriterOptions options)
    {
        SharePointGroundingToolCall value = SharePointGroundingToolCall.DeserializeSharePointGroundingToolCall(element, options);
        return value == null ? null : new(value.Id, value.AgentReference, value.ResponseId, value.CallId, value.Arguments, value.Status);
    }

    private static BinaryData WriteModel(Action<Utf8JsonWriter> write)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            write(writer);
            writer.Flush();
        }
        return BinaryData.FromBytes(stream.ToArray());
    }
}

[System.Diagnostics.CodeAnalysis.Experimental("AAIP001")]
public partial class SharepointGroundingToolCallOutput : AgentResponseItem, IJsonModel<SharepointGroundingToolCallOutput>
{
    public SharepointGroundingToolCallOutput(string callId, ToolCallStatus status)
        : base(AgentResponseItemKind.SharepointGroundingPreviewCallOutput)
    {
        Argument.AssertNotNull(callId, nameof(callId));
        CallId = callId;
        Status = status;
    }

    internal SharepointGroundingToolCallOutput(
        string id,
        AgentReference agentReference,
        string responseId,
        string callId,
        BinaryData output,
        ToolCallStatus status)
        : base("sharepoint_grounding_preview_call_output", id, agentReference, responseId)
    {
        CallId = callId;
        Output = output;
        Status = status;
    }

    public string CallId { get; set; }
    public BinaryData Output { get; set; }
    public ToolCallStatus Status { get; set; }

    protected override AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeSharepointGroundingToolCallOutput(document.RootElement, options);
    }

    protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => WriteModel(writer => ((IJsonModel<SharepointGroundingToolCallOutput>)this).Write(writer, options));

    protected override AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeSharepointGroundingToolCallOutput(document.RootElement, options);
    }

    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        base.JsonModelWriteCore(writer, options);
        writer.WritePropertyName("call_id"u8);
        writer.WriteStringValue(CallId);
        if (Optional.IsDefined(Output))
        {
            writer.WritePropertyName("output"u8);
#if NET6_0_OR_GREATER
            writer.WriteRawValue(Output);
#else
            using JsonDocument document = JsonDocument.Parse(Output);
            JsonSerializer.Serialize(writer, document.RootElement);
#endif
        }
        writer.WritePropertyName("status"u8);
        writer.WriteStringValue(Status.ToSerialString());
    }

    void IJsonModel<SharepointGroundingToolCallOutput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    SharepointGroundingToolCallOutput IJsonModel<SharepointGroundingToolCallOutput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => (SharepointGroundingToolCallOutput)JsonModelCreateCore(ref reader, options);
    BinaryData IPersistableModel<SharepointGroundingToolCallOutput>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    SharepointGroundingToolCallOutput IPersistableModel<SharepointGroundingToolCallOutput>.Create(BinaryData data, ModelReaderWriterOptions options)
        => (SharepointGroundingToolCallOutput)PersistableModelCreateCore(data, options);
    string IPersistableModel<SharepointGroundingToolCallOutput>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    private static SharepointGroundingToolCallOutput DeserializeSharepointGroundingToolCallOutput(JsonElement element, ModelReaderWriterOptions options)
    {
        SharePointGroundingToolCallOutput value = SharePointGroundingToolCallOutput.DeserializeSharePointGroundingToolCallOutput(element, options);
        return value == null ? null : new(value.Id, value.AgentReference, value.ResponseId, value.CallId, value.Output, value.Status);
    }

    private static BinaryData WriteModel(Action<Utf8JsonWriter> write)
    {
        using MemoryStream stream = new();
        using (Utf8JsonWriter writer = new(stream))
        {
            write(writer);
            writer.Flush();
        }
        return BinaryData.FromBytes(stream.ToArray());
    }
}
