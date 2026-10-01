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

public partial class AgentWorkflowPreviewActionResponseItem : AgentResponseItem
{
    /// <summary> Gets or sets the legacy workflow action kind. </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public new string Kind
    {
        get => CSDLActionKind;
        set => CSDLActionKind = value;
    }

    /// <inheritdoc/>
    protected override AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeAgentWorkflowPreviewActionResponseItem(document.RootElement, options);
    }

    /// <inheritdoc/>
    protected override AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeAgentWorkflowPreviewActionResponseItem(document.RootElement, options);
    }

    internal AgentWorkflowPreviewActionResponseItem(AgentResponseItemKind @type, string id, AgentReference agentReference, string responseId, IDictionary<string, BinaryData> additionalBinaryDataProperties, string kind, string actionId, string parentActionId, string previousActionId, AgentWorkflowPreviewActionStatus? status) : base(@type, id, agentReference, responseId, additionalBinaryDataProperties)
    {
        Kind = kind;
        ActionId = actionId;
        ParentActionId = parentActionId;
        PreviousActionId = previousActionId;
        Status = status;
    }

    internal static AgentWorkflowPreviewActionResponseItem DeserializeAgentWorkflowPreviewActionResponseItem(JsonElement element, ModelReaderWriterOptions options)
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
        string kind = default;
        string actionId = default;
        string parentActionId = default;
        string previousActionId = default;
        AgentWorkflowPreviewActionStatus? status = default;
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
            if (prop.NameEquals("kind"u8))
            {
                kind = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("action_id"u8))
            {
                actionId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("parent_action_id"u8))
            {
                parentActionId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("previous_action_id"u8))
            {
                previousActionId = prop.Value.GetString();
                continue;
            }
            if (prop.NameEquals("status"u8))
            {
                status = new AgentWorkflowPreviewActionStatus(prop.Value.GetString());
                continue;
            }
            if (options.Format != "W")
            {
                additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
            }
        }
        return new AgentWorkflowPreviewActionResponseItem(
            @type,
            id,
            agentReference,
            responseId,
            additionalBinaryDataProperties,
            kind,
            actionId,
            parentActionId,
            previousActionId,
            status);
    }

    internal AgentWorkflowPreviewActionResponseItem(string csdlActionKind, string actionId, string parentActionId, string previousActionId, AgentWorkflowPreviewActionStatus? status, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(ResponseItemKind.WorkflowAction)
    {
        CSDLActionKind = csdlActionKind;
        ActionId = actionId;
        ParentActionId = parentActionId;
        PreviousActionId = previousActionId;
        Status = status;
        _additionalBinaryDataProperties = additionalBinaryDataProperties;
    }
}
