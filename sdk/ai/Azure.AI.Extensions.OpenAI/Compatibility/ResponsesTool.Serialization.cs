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

[PersistableModelProxy(typeof(UnknownResponsesTool))]
public abstract partial class ResponsesTool : IJsonModel<ResponsesTool>
{
    protected virtual ResponsesTool PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
        return DeserializeResponsesTool(document.RootElement, options);
    }

    protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        => ModelReaderWriter.Write(this, options, AzureAIExtensionsOpenAIContext.Default);

    BinaryData IPersistableModel<ResponsesTool>.Write(ModelReaderWriterOptions options) => PersistableModelWriteCore(options);
    ResponsesTool IPersistableModel<ResponsesTool>.Create(BinaryData data, ModelReaderWriterOptions options) => PersistableModelCreateCore(data, options);
    string IPersistableModel<ResponsesTool>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    void IJsonModel<ResponsesTool>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WriteStartObject();
        JsonModelWriteCore(writer, options);
        writer.WriteEndObject();
    }

    ResponsesTool IJsonModel<ResponsesTool>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        => JsonModelCreateCore(ref reader, options);

    protected virtual ResponsesTool JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeResponsesTool(document.RootElement, options);
    }

    protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        writer.WritePropertyName("type"u8);
        writer.WriteStringValue(Kind.ToString());
    }

    internal static ResponsesTool DeserializeResponsesTool(JsonElement element, ModelReaderWriterOptions options)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return null;
        }
        if (element.TryGetProperty("type"u8, out JsonElement discriminator))
        {
            switch (discriminator.GetString())
            {
                case "a2a_preview": return ResponsesA2APreviewTool.DeserializeResponsesA2APreviewTool(element, options);
                case "azure_ai_search": return ResponsesAzureAISearchTool.DeserializeResponsesAzureAISearchTool(element, options);
                case "azure_function": return ResponsesAzureFunctionTool.DeserializeResponsesAzureFunctionTool(element, options);
                case "bing_custom_search_preview": return ResponsesBingCustomSearchPreviewTool.DeserializeResponsesBingCustomSearchPreviewTool(element, options);
                case "bing_grounding": return ResponsesBingGroundingTool.DeserializeResponsesBingGroundingTool(element, options);
                case "browser_automation_preview": return ResponsesBrowserAutomationPreviewTool.DeserializeResponsesBrowserAutomationPreviewTool(element, options);
                case "capture_structured_outputs": return ResponsesCaptureStructuredOutputsTool.DeserializeResponsesCaptureStructuredOutputsTool(element, options);
                case "fabric_dataagent_preview": return ResponsesMicrosoftFabricPreviewTool.DeserializeResponsesMicrosoftFabricPreviewTool(element, options);
                case "fabric_iq_preview": return ResponsesFabricIQPreviewTool.DeserializeResponsesFabricIQPreviewTool(element, options);
                case "memory_search_preview": return ResponsesMemorySearchPreviewTool.DeserializeResponsesMemorySearchPreviewTool(element, options);
                case "openapi": return ResponsesOpenApiTool.DeserializeResponsesOpenApiTool(element, options);
                case "sharepoint_grounding_preview": return ResponsesSharepointPreviewTool.DeserializeResponsesSharepointPreviewTool(element, options);
                case "work_iq_preview": return ResponsesWorkIQPreviewTool.DeserializeResponsesWorkIQPreviewTool(element, options);
                case "computer_use_preview": return InternalComputerUsePreviewTool.DeserializeInternalComputerUsePreviewTool(element, options);
                case "file_search": return InternalFileSearchTool.DeserializeInternalFileSearchTool(element, options);
            }
        }

        ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(BinaryData.FromString(element.GetRawText()), options, OpenAIContext.Default);
        return new UnknownResponsesTool(tool);
    }

    public ResponseTool AsResponseTool()
    {
        if (this is UnknownResponsesTool unknownTool)
        {
            return unknownTool.InnerTool;
        }
        BinaryData data = ModelReaderWriter.Write(this, ModelReaderWriterOptions.Json, AzureAIExtensionsOpenAIContext.Default);
        return ModelReaderWriter.Read<ResponseTool>(data, ModelReaderWriterOptions.Json, OpenAIContext.Default);
    }

    public static implicit operator ResponseTool(ResponsesTool tool) => tool?.AsResponseTool();
}

internal sealed class UnknownResponsesTool : ResponsesTool
{
    internal UnknownResponsesTool(ResponseTool tool) : base(tool.Kind) => InnerTool = tool;
    internal ResponseTool InnerTool { get; }
}
