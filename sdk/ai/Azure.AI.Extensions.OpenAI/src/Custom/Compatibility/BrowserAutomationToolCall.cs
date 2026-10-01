// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable AAIP001
#pragma warning disable AAIP002

namespace Azure.AI.Extensions.OpenAI;

public partial class BrowserAutomationToolCall : AgentResponseItem
{
    /// <inheritdoc/>
    protected override AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeBrowserAutomationToolCall(document.RootElement, options);
    }

    /// <inheritdoc/>
    protected override AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeBrowserAutomationToolCall(document.RootElement, options);
    }

    internal BrowserAutomationToolCall(AgentResponseItemKind @type, string id, AgentReference agentReference, string responseId, IDictionary<string, BinaryData> additionalBinaryDataProperties, string callId, string arguments, ToolCallStatus status) : base(@type, id, agentReference, responseId, additionalBinaryDataProperties)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
    }

    internal static BrowserAutomationToolCall DeserializeBrowserAutomationToolCall(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        AgentResponseItemKind @type = default;
        string id = default;
        AgentReference agentReference = default;
        string responseId = default;
        IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        string callId = default;
        string arguments = default;
        ToolCallStatus status = default;
        foreach (var prop in element.EnumerateObject())
        {
            if (prop.NameEquals("type"u8))
            {
                @type = new AgentResponseItemKind(prop.Value.GetString());
                continue;
            }
            if (prop.NameEquals("id"u8))
            {
                id = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("agent_reference"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                agentReference = AgentReference.DeserializeAgentReference(prop.Value, options);
                continue;
            }
            if (prop.NameEquals("response_id"u8))
            {
                responseId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("call_id"u8))
            {
                callId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("arguments"u8))
            {
                arguments = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("status"u8))
            {
                status = prop.Value.GetString().ToToolCallStatus();
                continue;
            }
            if (options.Format != "W")
            {
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
        }
        return new BrowserAutomationToolCall(
            @type,
            id,
            agentReference,
            responseId,
            additionalBinaryDataProperties,
            callId,
            arguments,
            status);
    }

    internal BrowserAutomationToolCall(string callId, string arguments, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.BrowserAutomationPreviewCall)
    {
        CallId = callId;
        Arguments = arguments;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
