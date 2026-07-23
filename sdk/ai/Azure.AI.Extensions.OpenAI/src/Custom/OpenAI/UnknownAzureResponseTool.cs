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
    /// A <see cref="ResponseTool"/> dispatcher registered with <see cref="AzureAIExtensionsOpenAIContext"/>.
    /// OpenAI's built-in <c>DeserializeResponseTool</c> is a closed discriminator switch that buckets
    /// Azure-specific tool kinds into an opaque unknown fallback, so echoed tool definitions never materialize to
    /// their concrete Azure subtypes. This proxy reads the payload's <c>type</c> discriminator and re-dispatches to
    /// the matching generated <c>Deserialize*</c> method, falling back to OpenAI's own deserialization for kinds it
    /// does not recognize. It mirrors <see cref="UnknownAzureResponseItem"/> for the tool axis.
    /// </summary>
    internal partial class UnknownAzureResponseTool : ResponseTool
    {
        // The single source of truth for the Azure-specific tool discriminators this package can strongly type.
        // Keyed by the named ResponseToolKind extension constants (ResponseToolKindExtensions), each entry carries
        // the concrete subtype and its deserializer. It is used both to dispatch a polymorphic read
        // (DeserializeFromDiscriminator) and to decide whether an already materialized tool still needs
        // normalization (TryGetAzureToolType), so the two never drift apart.
        #pragma warning disable AAIP001
        private static readonly IReadOnlyDictionary<ResponseToolKind, (Type Type, Func<JsonElement, ModelReaderWriterOptions, ResponseTool> Deserialize)> AzureToolDispatch =
        new Dictionary<ResponseToolKind, (Type, Func<JsonElement, ModelReaderWriterOptions, ResponseTool>)>
            {
                [ResponseToolKind.A2APreview] = (typeof(A2APreviewTool), A2APreviewTool.DeserializeA2APreviewTool),
                [ResponseToolKind.AzureAISearch] = (typeof(AzureAISearchTool), AzureAISearchTool.DeserializeAzureAISearchTool),
                [ResponseToolKind.AzureFunction] = (typeof(AzureFunctionTool), AzureFunctionTool.DeserializeAzureFunctionTool),
                [ResponseToolKind.BingCustomSearchPreview] = (typeof(BingCustomSearchPreviewTool), BingCustomSearchPreviewTool.DeserializeBingCustomSearchPreviewTool),
                [ResponseToolKind.BingGrounding] = (typeof(BingGroundingTool), BingGroundingTool.DeserializeBingGroundingTool),
                [ResponseToolKind.BrowserAutomationPreview] = (typeof(BrowserAutomationPreviewTool), BrowserAutomationPreviewTool.DeserializeBrowserAutomationPreviewTool),
                [ResponseToolKind.CaptureStructuredOutputs] = (typeof(CaptureStructuredOutputsTool), CaptureStructuredOutputsTool.DeserializeCaptureStructuredOutputsTool),
                [ResponseToolKind.FabricIQPreview] = (typeof(FabricIQPreviewTool), FabricIQPreviewTool.DeserializeFabricIQPreviewTool),
                [ResponseToolKind.MemorySearchPreview] = (typeof(MemorySearchPreviewTool), MemorySearchPreviewTool.DeserializeMemorySearchPreviewTool),
                [ResponseToolKind.FabricDataAgentPreview] = (typeof(MicrosoftFabricPreviewTool), MicrosoftFabricPreviewTool.DeserializeMicrosoftFabricPreviewTool),
                [ResponseToolKind.OpenAPI] = (typeof(OpenAPITool), OpenAPITool.DeserializeOpenAPITool),
                [ResponseToolKind.SharePointGroundingPreview] = (typeof(SharepointPreviewTool), SharepointPreviewTool.DeserializeSharepointPreviewTool),
                [ResponseToolKind.WorkIQPreview] = (typeof(WorkIQPreviewTool), WorkIQPreviewTool.DeserializeWorkIQPreviewTool),
            };
        #pragma warning restore AAIP001

        internal UnknownAzureResponseTool()
            : base(new ResponseToolKind("azure.unknown"))
        {
        }

        // Returns the concrete Azure subtype this package materializes for the given discriminator, if any. Used by
        // the client-side normalization gate to decide whether an already-materialized tool needs re-dispatch,
        // keyed off the known discriminator set rather than any OpenAI-internal opaque type name.
        internal static bool TryGetAzureToolType(ResponseToolKind kind, out Type type)
        {
            if (AzureToolDispatch.TryGetValue(kind, out (Type Type, Func<JsonElement, ModelReaderWriterOptions, ResponseTool> Deserialize) dispatch))
            {
                type = dispatch.Type;
                return true;
            }

            type = null;
            return false;
        }

        protected override ResponseTool PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeFromDiscriminator(document.RootElement, options);
        }

        protected override ResponseTool JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFromDiscriminator(document.RootElement, options);
        }

        private static ResponseTool DeserializeFromDiscriminator(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.TryGetProperty("type"u8, out JsonElement typeProperty)
                && typeProperty.ValueKind == JsonValueKind.String
                && AzureToolDispatch.TryGetValue(new ResponseToolKind(typeProperty.GetString()), out (Type Type, Func<JsonElement, ModelReaderWriterOptions, ResponseTool> Deserialize) dispatch))
            {
                return dispatch.Deserialize(element, options);
            }

            // Not an Azure-specific kind; defer to OpenAI's own deserialization (which yields either a
            // known OpenAI subtype or its internal unknown-tool fallback). Use the OpenAI context here so
            // this dispatcher is not re-entered.
            return ModelReaderWriter.Read<ResponseTool>(
                BinaryData.FromString(element.GetRawText()),
                options,
                OpenAIContext.Default);
        }
    }
}
