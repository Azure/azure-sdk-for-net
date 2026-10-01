// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001
#pragma warning disable SCME0001

#pragma warning disable AAIP001
#pragma warning disable AAIP002

namespace Azure.AI.Extensions.OpenAI;

/// <summary> The legacy base for Foundry response items. </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[PersistableModelProxy(typeof(UnknownAgentResponseItem))]
public abstract partial class AgentResponseItem : ResponseItem, IJsonModel<AgentResponseItem>, IJsonModel<ResponseItem>
{
    private protected readonly IDictionary<string, BinaryData> _legacyAdditionalBinaryDataProperties;
    private AgentReference _agentReference;
    private string _responseId;

    private protected AgentResponseItem(ResponseItemKind kind) : base(kind)
    {
    }

    private protected AgentResponseItem(AgentResponseItemKind kind) : this(new ResponseItemKind(kind.ToString()))
    {
    }

    internal AgentResponseItem() : this(new ResponseItemKind("unknown"))
    {
    }

    internal AgentResponseItem(AgentResponseItemKind type, string id, AgentReference agentReference, string responseId,
        IDictionary<string, BinaryData> additionalBinaryDataProperties) : this(type)
    {
        Id = id;
        AgentReference = agentReference;
        ResponseId = responseId;
        _legacyAdditionalBinaryDataProperties = additionalBinaryDataProperties;
    }

    internal AgentResponseItemKind Type => new AgentResponseItemKind(base.Kind.ToString());

    /// <summary> Gets or sets the agent that created the item. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AgentReference AgentReference
    {
        get => _agentReference;
        set
        {
            _agentReference = value;
            Patch.SetOrClearEx("$.agent_reference"u8, "$.agent_reference"u8, value);
        }
    }

    /// <summary> Gets or sets the response that created the item. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string ResponseId
    {
        get => _responseId;
        set
        {
            _responseId = value;
            Patch.SetOrClearEx("$.response_id"u8, "$.response_id"u8, value);
        }
    }

    /// <summary> Creates a legacy structured-output item. </summary>
    public static AgentResponseItem CreateStructuredOutputsItem(BinaryData output = null) => new AgentStructuredOutputsResponseItem(output);

    /// <summary> Creates a legacy workflow action item. </summary>
    public static AgentResponseItem CreateWorkflowPreviewActionItem(string actionKind, string actionId)
        => new AgentWorkflowPreviewActionResponseItem(actionKind, actionId, null);

    /// <summary> Creates an independent OpenAI representation of this item. </summary>
    public ResponseItem AsResponseResultItem() => ModelReaderWriter.Read<ResponseItem>(
        ModelReaderWriter.Write(this, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default),
        ModelReaderWriterOptions.Json, OpenAIContext.Default);

    // C# operator syntax forbids conversions between base and derived types. Keep
    // the original CLR method names so already-compiled conversion calls bind.
    /// <summary> Preserves the legacy conversion entry point for compiled callers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SpecialName]
    public static ResponseItem op_Implicit(AgentResponseItem agentResponseItem) => agentResponseItem.AsResponseResultItem();

    /// <summary> Preserves the legacy conversion entry point for compiled callers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SpecialName]
    public static AgentResponseItem op_Implicit(ResponseItem responseItem) => responseItem.AsAgentResponseItem();

    /// <summary> Reads an item through the legacy virtual contract. </summary>
    protected new virtual AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeAgentResponseItem(document.RootElement, options);
    }

    /// <summary> Reads an item through the legacy virtual contract. </summary>
    protected new virtual AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeAgentResponseItem(document.RootElement, options);
    }

    /// <summary> Serializes the item using its most-derived model implementation. </summary>
    protected override BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        return ModelReaderWriter.Write(this, options, AzureAIExtensionsOpenAIContext.Default);
    }

    /// <summary> Writes the common response item and legacy attribution properties. </summary>
    protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        ValidateLegacyFormat(options);
        base.JsonModelWriteCore(writer, options);
        if (AgentReference != null)
        {
            writer.WritePropertyName("agent_reference"u8);
            writer.WriteObjectValue(AgentReference, options);
        }
        if (ResponseId != null)
        {
            writer.WriteString("response_id"u8, ResponseId);
        }
        if (_legacyAdditionalBinaryDataProperties != null && (options.Format != "W" || this is UnknownAgentResponseItem))
        {
            foreach (KeyValuePair<string, BinaryData> property in _legacyAdditionalBinaryDataProperties)
            {
                writer.WritePropertyName(property.Key);
                using JsonDocument value = JsonDocument.Parse(property.Value);
                value.RootElement.WriteTo(writer);
            }
        }
    }

    private protected static void ValidateLegacyFormat(ModelReaderWriterOptions options)
    {
        if (options.Format != "J" && options.Format != "W")
        {
            throw new FormatException($"The model {nameof(AgentResponseItem)} does not support '{options.Format}' format.");
        }
    }

    BinaryData IPersistableModel<AgentResponseItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    AgentResponseItem IPersistableModel<AgentResponseItem>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
    string IPersistableModel<AgentResponseItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    AgentResponseItem IJsonModel<AgentResponseItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
    void IJsonModel<AgentResponseItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);
    BinaryData IPersistableModel<ResponseItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    ResponseItem IPersistableModel<ResponseItem>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
    string IPersistableModel<ResponseItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    ResponseItem IJsonModel<ResponseItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => JsonModelCreateCore(ref reader, options);
    void IJsonModel<ResponseItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => WriteJson(writer, options);

    private void WriteJson(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    internal static AgentResponseItem DeserializeAgentResponseItem(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        string kind = element.TryGetProperty("type"u8, out JsonElement discriminator) ? discriminator.GetString() : null;
        return kind switch
        {
            "structured_outputs" => AgentStructuredOutputsResponseItem.DeserializeAgentStructuredOutputsResponseItem(element, options),
            "workflow_action" => AgentWorkflowPreviewActionResponseItem.DeserializeAgentWorkflowPreviewActionResponseItem(element, options),
            "oauth_consent_request" => OAuthConsentRequestResponseItem.DeserializeOAuthConsentRequestResponseItem(element, options),
            "memory_search_call" => MemorySearchToolCallResponseItem.DeserializeMemorySearchToolCallResponseItem(element, options),
            "bing_grounding_call" => BingGroundingToolCall.DeserializeBingGroundingToolCall(element, options),
            "bing_grounding_call_output" => BingGroundingToolCallOutput.DeserializeBingGroundingToolCallOutput(element, options),
            "sharepoint_grounding_preview_call" => SharepointGroundingToolCall.DeserializeSharepointGroundingToolCall(element, options),
            "sharepoint_grounding_preview_call_output" => SharepointGroundingToolCallOutput.DeserializeSharepointGroundingToolCallOutput(element, options),
            "azure_ai_search_call" => AzureAISearchToolCall.DeserializeAzureAISearchToolCall(element, options),
            "azure_ai_search_call_output" => AzureAISearchToolCallOutput.DeserializeAzureAISearchToolCallOutput(element, options),
            "bing_custom_search_preview_call" => BingCustomSearchToolCall.DeserializeBingCustomSearchToolCall(element, options),
            "bing_custom_search_preview_call_output" => BingCustomSearchToolCallOutput.DeserializeBingCustomSearchToolCallOutput(element, options),
            "openapi_call" => OpenApiToolCall.DeserializeOpenApiToolCall(element, options),
            "openapi_call_output" => OpenApiToolCallOutput.DeserializeOpenApiToolCallOutput(element, options),
            "browser_automation_preview_call" => BrowserAutomationToolCall.DeserializeBrowserAutomationToolCall(element, options),
            "browser_automation_preview_call_output" => BrowserAutomationToolCallOutput.DeserializeBrowserAutomationToolCallOutput(element, options),
            "fabric_dataagent_preview_call" => FabricDataAgentToolCall.DeserializeFabricDataAgentToolCall(element, options),
            "fabric_dataagent_preview_call_output" => FabricDataAgentToolCallOutput.DeserializeFabricDataAgentToolCallOutput(element, options),
            "azure_function_call" => AzureFunctionToolCall.DeserializeAzureFunctionToolCall(element, options),
            "azure_function_call_output" => AzureFunctionToolCallOutput.DeserializeAzureFunctionToolCallOutput(element, options),
            "a2a_preview_call" => A2AToolCall.DeserializeA2AToolCall(element, options),
            "a2a_preview_call_output" => A2AToolCallOutput.DeserializeA2AToolCallOutput(element, options),
            _ => UnknownAgentResponseItem.DeserializeUnknownAgentResponseItem(element, options)
        };
    }
}
