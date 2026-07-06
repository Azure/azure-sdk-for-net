// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI
{
    /// <summary>
    /// A <see cref="ResponseItem"/> dispatcher registered with <see cref="AzureAIExtensionsOpenAIContext"/>.
    /// OpenAI's built-in <c>DeserializeResponseItem</c> is a closed discriminator switch that buckets
    /// Azure-specific item kinds into an opaque unknown fallback, so those payloads never materialize to their
    /// concrete Azure subtypes. This proxy reads the payload's <c>type</c> discriminator and re-dispatches to
    /// the matching generated <c>Deserialize*</c> method, falling back to OpenAI's own deserialization for kinds
    /// it does not recognize.
    /// </summary>
    internal partial class UnknownAzureResponseItem : ResponseItem
    {
        internal UnknownAzureResponseItem()
            : base(new ResponseItemKind("azure.unknown"))
        {
        }

        protected override ResponseItem PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeFromDiscriminator(document.RootElement, options);
        }

        protected override ResponseItem JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFromDiscriminator(document.RootElement, options);
        }

        private static ResponseItem DeserializeFromDiscriminator(JsonElement element, ModelReaderWriterOptions options)
        {
            string kind = null;
            if (element.TryGetProperty("type"u8, out JsonElement typeProperty) && typeProperty.ValueKind == JsonValueKind.String)
            {
                kind = typeProperty.GetString();
            }

            switch (kind)
            {
                case "a2a_preview_call":
                    return A2AToolCall.DeserializeA2AToolCall(element, options);
                case "a2a_preview_call_output":
                    return A2AToolCallOutput.DeserializeA2AToolCallOutput(element, options);
                case "structured_outputs":
                    return AgentStructuredOutputsResponseItem.DeserializeAgentStructuredOutputsResponseItem(element, options);
                case "workflow_action":
                    return AgentWorkflowPreviewActionResponseItem.DeserializeAgentWorkflowPreviewActionResponseItem(element, options);
                case "azure_ai_search_call":
                    return AzureAISearchToolCall.DeserializeAzureAISearchToolCall(element, options);
                case "azure_ai_search_call_output":
                    return AzureAISearchToolCallOutput.DeserializeAzureAISearchToolCallOutput(element, options);
                case "azure_function_call":
                    return AzureFunctionToolCall.DeserializeAzureFunctionToolCall(element, options);
                case "azure_function_call_output":
                    return AzureFunctionToolCallOutput.DeserializeAzureFunctionToolCallOutput(element, options);
                case "bing_custom_search_preview_call":
                    return BingCustomSearchToolCall.DeserializeBingCustomSearchToolCall(element, options);
                case "bing_custom_search_preview_call_output":
                    return BingCustomSearchToolCallOutput.DeserializeBingCustomSearchToolCallOutput(element, options);
                case "bing_grounding_call":
                    return BingGroundingToolCall.DeserializeBingGroundingToolCall(element, options);
                case "bing_grounding_call_output":
                    return BingGroundingToolCallOutput.DeserializeBingGroundingToolCallOutput(element, options);
                case "browser_automation_preview_call":
                    return BrowserAutomationToolCall.DeserializeBrowserAutomationToolCall(element, options);
                case "browser_automation_preview_call_output":
                    return BrowserAutomationToolCallOutput.DeserializeBrowserAutomationToolCallOutput(element, options);
                case "fabric_dataagent_preview_call":
                    return FabricDataAgentToolCall.DeserializeFabricDataAgentToolCall(element, options);
                case "fabric_dataagent_preview_call_output":
                    return FabricDataAgentToolCallOutput.DeserializeFabricDataAgentToolCallOutput(element, options);
                case "memory_command_preview_call":
                    return MemoryCommandToolCall.DeserializeMemoryCommandToolCall(element, options);
                case "memory_command_preview_call_output":
                    return MemoryCommandToolCallOutput.DeserializeMemoryCommandToolCallOutput(element, options);
                case "memory_search_call":
                    return MemorySearchToolCall.DeserializeMemorySearchToolCall(element, options);
                case "oauth_consent_request":
                    return OAuthConsentRequestResponseItem.DeserializeOAuthConsentRequestResponseItem(element, options);
                case "openapi_call":
                    return OpenApiToolCall.DeserializeOpenApiToolCall(element, options);
                case "openapi_call_output":
                    return OpenApiToolCallOutput.DeserializeOpenApiToolCallOutput(element, options);
                case "sharepoint_grounding_preview_call":
                    return SharepointGroundingToolCall.DeserializeSharepointGroundingToolCall(element, options);
                case "sharepoint_grounding_preview_call_output":
                    return SharepointGroundingToolCallOutput.DeserializeSharepointGroundingToolCallOutput(element, options);
                default:
                    // Not an Azure-specific kind; defer to OpenAI's own deserialization (which yields either a
                    // known OpenAI subtype or its internal unknown-item fallback). Use the OpenAI context here so
                    // this dispatcher is not re-entered.
                    return ModelReaderWriter.Read<ResponseItem>(
                        BinaryData.FromString(element.GetRawText()),
                        options,
                        OpenAIContext.Default);
            }
        }
    }
}
