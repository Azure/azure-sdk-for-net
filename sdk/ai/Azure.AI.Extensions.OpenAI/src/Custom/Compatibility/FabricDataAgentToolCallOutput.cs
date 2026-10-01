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

public partial class FabricDataAgentToolCallOutput : AgentResponseItem
{
    /// <inheritdoc/>
    protected override AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeFabricDataAgentToolCallOutput(document.RootElement, options);
    }

    /// <inheritdoc/>
    protected override AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeFabricDataAgentToolCallOutput(document.RootElement, options);
    }

    internal FabricDataAgentToolCallOutput(AgentResponseItemKind @type, string id, AgentReference agentReference, string responseId, IDictionary<string, BinaryData> additionalBinaryDataProperties, string callId, BinaryData output, ToolCallStatus status) : base(@type, id, agentReference, responseId, additionalBinaryDataProperties)
    {
        CallId = callId;
        Output = output;
        Status = status;
    }

    internal static FabricDataAgentToolCallOutput DeserializeFabricDataAgentToolCallOutput(JsonElement element, ModelReaderWriterOptions options)
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
        BinaryData output = default;
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
            if (prop.NameEquals("output"u8))
            {
                if (prop.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                output = BinaryData.FromString(prop.Value.GetRawText());
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
        return new FabricDataAgentToolCallOutput(
            @type,
            id,
            agentReference,
            responseId,
            additionalBinaryDataProperties,
            callId,
            output,
            status);
    }

    internal FabricDataAgentToolCallOutput(string callId, BinaryData output, ToolCallStatus status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.FabricDataAgentPreviewCallOutput)
    {
        CallId = callId;
        Output = output;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
