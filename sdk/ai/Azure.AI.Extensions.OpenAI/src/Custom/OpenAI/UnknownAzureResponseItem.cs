// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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
        // The single source of truth for the Azure-specific item discriminators this package can strongly type.
        // Keyed by the named ResponseItemKind extension constants (ResponseItemKindExtensions), each entry carries
        // the concrete subtype and its deserializer. It is used both to dispatch a polymorphic read
        // (DeserializeFromDiscriminator) and to decide whether an already materialized item still needs
        // normalization (TryGetAzureItemType), so the two never drift apart.
        private static readonly IReadOnlyDictionary<ResponseItemKind, (Type Type, Func<JsonElement, ModelReaderWriterOptions, ResponseItem> Deserialize)> AzureItemDispatch =
            new Dictionary<ResponseItemKind, (Type, Func<JsonElement, ModelReaderWriterOptions, ResponseItem>)>
            {
                [ResponseItemKind.A2APreviewCall] = (typeof(A2AToolCall), A2AToolCall.DeserializeA2AToolCall),
                [ResponseItemKind.A2APreviewCallOutput] = (typeof(A2AToolCallOutput), A2AToolCallOutput.DeserializeA2AToolCallOutput),
                [ResponseItemKind.StructuredOutputs] = (typeof(AgentStructuredOutputsResponseItem), AgentStructuredOutputsResponseItem.DeserializeAgentStructuredOutputsResponseItem),
                [ResponseItemKind.WorkflowAction] = (typeof(AgentWorkflowPreviewActionResponseItem), AgentWorkflowPreviewActionResponseItem.DeserializeAgentWorkflowPreviewActionResponseItem),
                [ResponseItemKind.AzureAISearchCall] = (typeof(AzureAISearchToolCall), AzureAISearchToolCall.DeserializeAzureAISearchToolCall),
                [ResponseItemKind.AzureAISearchCallOutput] = (typeof(AzureAISearchToolCallOutput), AzureAISearchToolCallOutput.DeserializeAzureAISearchToolCallOutput),
                [ResponseItemKind.AzureFunctionCall] = (typeof(AzureFunctionToolCall), AzureFunctionToolCall.DeserializeAzureFunctionToolCall),
                [ResponseItemKind.AzureFunctionCallOutput] = (typeof(AzureFunctionToolCallOutput), AzureFunctionToolCallOutput.DeserializeAzureFunctionToolCallOutput),
                [ResponseItemKind.BingCustomSearchPreviewCall] = (typeof(BingCustomSearchToolCall), BingCustomSearchToolCall.DeserializeBingCustomSearchToolCall),
                [ResponseItemKind.BingCustomSearchPreviewCallOutput] = (typeof(BingCustomSearchToolCallOutput), BingCustomSearchToolCallOutput.DeserializeBingCustomSearchToolCallOutput),
                [ResponseItemKind.BingGroundingCall] = (typeof(BingGroundingToolCall), BingGroundingToolCall.DeserializeBingGroundingToolCall),
                [ResponseItemKind.BingGroundingCallOutput] = (typeof(BingGroundingToolCallOutput), BingGroundingToolCallOutput.DeserializeBingGroundingToolCallOutput),
                [ResponseItemKind.BrowserAutomationPreviewCall] = (typeof(BrowserAutomationToolCall), BrowserAutomationToolCall.DeserializeBrowserAutomationToolCall),
                [ResponseItemKind.BrowserAutomationPreviewCallOutput] = (typeof(BrowserAutomationToolCallOutput), BrowserAutomationToolCallOutput.DeserializeBrowserAutomationToolCallOutput),
                [ResponseItemKind.FabricDataAgentPreviewCall] = (typeof(FabricDataAgentToolCall), FabricDataAgentToolCall.DeserializeFabricDataAgentToolCall),
                [ResponseItemKind.FabricDataAgentPreviewCallOutput] = (typeof(FabricDataAgentToolCallOutput), FabricDataAgentToolCallOutput.DeserializeFabricDataAgentToolCallOutput),
                [ResponseItemKind.MemoryCommandPreviewCall] = (typeof(MemoryCommandToolCall), MemoryCommandToolCall.DeserializeMemoryCommandToolCall),
                [ResponseItemKind.MemoryCommandPreviewCallOutput] = (typeof(MemoryCommandToolCallOutput), MemoryCommandToolCallOutput.DeserializeMemoryCommandToolCallOutput),
                [ResponseItemKind.MemorySearchCall] = (typeof(MemorySearchToolCall), MemorySearchToolCall.DeserializeMemorySearchToolCall),
                [ResponseItemKind.OAuthConsentRequest] = (typeof(OAuthConsentRequestResponseItem), OAuthConsentRequestResponseItem.DeserializeOAuthConsentRequestResponseItem),
                [ResponseItemKind.OpenApiCall] = (typeof(OpenApiToolCall), OpenApiToolCall.DeserializeOpenApiToolCall),
                [ResponseItemKind.OpenApiCallOutput] = (typeof(OpenApiToolCallOutput), OpenApiToolCallOutput.DeserializeOpenApiToolCallOutput),
                [ResponseItemKind.SharepointGroundingPreviewCall] = (typeof(SharepointGroundingToolCall), SharepointGroundingToolCall.DeserializeSharepointGroundingToolCall),
                [ResponseItemKind.SharepointGroundingPreviewCallOutput] = (typeof(SharepointGroundingToolCallOutput), SharepointGroundingToolCallOutput.DeserializeSharepointGroundingToolCallOutput),
            };

        internal UnknownAzureResponseItem()
            : base(new ResponseItemKind("azure.unknown"))
        {
        }

        // Returns the concrete Azure subtype this package materializes for the given discriminator, if any. Used by
        // the client-side normalization gate to decide whether an already-materialized item needs re-dispatch,
        // keyed off the known discriminator set rather than any OpenAI-internal opaque type name.
        internal static bool TryGetAzureItemType(ResponseItemKind kind, out Type type)
        {
            if (AzureItemDispatch.TryGetValue(kind, out (Type Type, Func<JsonElement, ModelReaderWriterOptions, ResponseItem> Deserialize) dispatch))
            {
                type = dispatch.Type;
                return true;
            }

            type = null;
            return false;
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
            if (element.TryGetProperty("type"u8, out JsonElement typeProperty)
                && typeProperty.ValueKind == JsonValueKind.String
                && AzureItemDispatch.TryGetValue(new ResponseItemKind(typeProperty.GetString()), out (Type Type, Func<JsonElement, ModelReaderWriterOptions, ResponseItem> Deserialize) dispatch))
            {
                return dispatch.Deserialize(element, options);
            }

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
