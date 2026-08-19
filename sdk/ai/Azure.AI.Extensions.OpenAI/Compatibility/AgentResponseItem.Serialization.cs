// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591
#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

[PersistableModelProxy(typeof(UnknownAgentResponseItem))]
public abstract partial class AgentResponseItem : IJsonModel<AgentResponseItem>
{
    protected virtual AgentResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeAgentResponseItem(document.RootElement, options);
    }

    protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options, AzureAIExtensionsOpenAIContext.Default);

    BinaryData IPersistableModel<AgentResponseItem>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    AgentResponseItem IPersistableModel<AgentResponseItem>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
    string IPersistableModel<AgentResponseItem>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<AgentResponseItem>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    AgentResponseItem IJsonModel<AgentResponseItem>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => JsonModelCreateCore(ref reader, options);

    protected virtual AgentResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeAgentResponseItem(document.RootElement, options);
    }

    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WritePropertyName("type"u8);
        writer.WriteStringValue(Type.ToString());
        if (Optional.IsDefined(Id))
        {
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
        }
        if (Optional.IsDefined(AgentReference))
        {
            writer.WritePropertyName("agent_reference"u8);
            writer.WriteObjectValue(AgentReference, options);
        }
        if (Optional.IsDefined(ResponseId))
        {
            writer.WritePropertyName("response_id"u8);
            writer.WriteStringValue(ResponseId);
        }
    }

    internal static AgentResponseItem DeserializeAgentResponseItem(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("type"u8, out JsonElement discriminator))
        {
            switch (discriminator.GetString())
            {
                case "structured_outputs": return AgentStructuredOutputsResponseItem.DeserializeAgentStructuredOutputsResponseItem(element, options);
                case "workflow_action": return AgentWorkflowPreviewActionResponseItem.DeserializeAgentWorkflowPreviewActionResponseItem(element, options);
                case "oauth_consent_request": return OAuthConsentRequestResponseItem.DeserializeOAuthConsentRequestResponseItem(element, options);
                case "a2a_preview_call": return A2AToolCall.DeserializeA2AToolCall(element, options);
                case "a2a_preview_call_output": return A2AToolCallOutput.DeserializeA2AToolCallOutput(element, options);
                case "azure_ai_search_call": return AzureAISearchToolCall.DeserializeAzureAISearchToolCall(element, options);
                case "azure_ai_search_call_output": return AzureAISearchToolCallOutput.DeserializeAzureAISearchToolCallOutput(element, options);
                case "azure_function_call": return AzureFunctionToolCall.DeserializeAzureFunctionToolCall(element, options);
                case "azure_function_call_output": return AzureFunctionToolCallOutput.DeserializeAzureFunctionToolCallOutput(element, options);
                case "bing_custom_search_preview_call": return BingCustomSearchToolCall.DeserializeBingCustomSearchToolCall(element, options);
                case "bing_custom_search_preview_call_output": return BingCustomSearchToolCallOutput.DeserializeBingCustomSearchToolCallOutput(element, options);
                case "bing_grounding_call": return BingGroundingToolCall.DeserializeBingGroundingToolCall(element, options);
                case "bing_grounding_call_output": return BingGroundingToolCallOutput.DeserializeBingGroundingToolCallOutput(element, options);
                case "browser_automation_preview_call": return BrowserAutomationToolCall.DeserializeBrowserAutomationToolCall(element, options);
                case "browser_automation_preview_call_output": return BrowserAutomationToolCallOutput.DeserializeBrowserAutomationToolCallOutput(element, options);
                case "fabric_dataagent_preview_call": return FabricDataAgentToolCall.DeserializeFabricDataAgentToolCall(element, options);
                case "fabric_dataagent_preview_call_output": return FabricDataAgentToolCallOutput.DeserializeFabricDataAgentToolCallOutput(element, options);
                case "memory_search_call": return MemorySearchToolCall.DeserializeMemorySearchToolCall(element, options);
                case "memory_command_preview_call": return MemoryCommandToolCall.DeserializeMemoryCommandToolCall(element, options);
                case "memory_command_preview_call_output": return MemoryCommandToolCallOutput.DeserializeMemoryCommandToolCallOutput(element, options);
                case "openapi_call": return OpenApiToolCall.DeserializeOpenApiToolCall(element, options);
                case "openapi_call_output": return OpenApiToolCallOutput.DeserializeOpenApiToolCallOutput(element, options);
                case "sharepoint_grounding_preview_call": return SharePointGroundingToolCall.DeserializeSharePointGroundingToolCall(element, options);
                case "sharepoint_grounding_preview_call_output": return SharePointGroundingToolCallOutput.DeserializeSharePointGroundingToolCallOutput(element, options);
            }
        }

        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(BinaryData.FromString(element.GetRawText()), options, OpenAIContext.Default);
        return new UnknownAgentResponseItem(item);
    }
}

internal sealed class UnknownAgentResponseItem : AgentResponseItem
{
    internal UnknownAgentResponseItem() { }
    internal UnknownAgentResponseItem(ResponseItem item) : base(item.Kind, item.Id, null, null) => InnerItem = item;
    internal UnknownAgentResponseItem(ResponseItemKind kind, string id, AgentReference agentReference, string responseId)
        : base(kind, id, agentReference, responseId) { }

    internal ResponseItem InnerItem { get; }
}
