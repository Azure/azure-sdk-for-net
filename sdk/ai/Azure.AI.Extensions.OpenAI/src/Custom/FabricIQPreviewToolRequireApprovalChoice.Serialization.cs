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
    ///
    /// </summary>
    public partial class FabricIQPreviewToolRequireApprovalChoice : IJsonModel<FabricIQPreviewToolRequireApprovalChoice>
    {
        void IJsonModel<FabricIQPreviewToolRequireApprovalChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => SerializeFabricIQPreviewToolRequireApprovalChoice(this, writer, options);

        FabricIQPreviewToolRequireApprovalChoice IJsonModel<FabricIQPreviewToolRequireApprovalChoice>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeFabricIQPreviewToolRequireApprovalChoice(document.RootElement, options);
        }

        BinaryData IPersistableModel<FabricIQPreviewToolRequireApprovalChoice>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options, null);
        }

        FabricIQPreviewToolRequireApprovalChoice IPersistableModel<FabricIQPreviewToolRequireApprovalChoice>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromBinaryData(data);

        string IPersistableModel<FabricIQPreviewToolRequireApprovalChoice>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

#pragma warning disable OPENAI001
        internal static void SerializeFabricIQPreviewToolRequireApprovalChoice(FabricIQPreviewToolRequireApprovalChoice instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (instance.ApprovalPolicy != null)
            {
                ((IJsonModel<McpToolCallApprovalPolicy>)instance.ApprovalPolicy).Write(writer, options);
            }
            else if (instance.ApprovalString is not null)
            {
                writer.WriteObjectValue(instance.ApprovalString, options);
            }
        }
#pragma warning restore OPENAI001

#pragma warning disable OPENAI001
        internal static FabricIQPreviewToolRequireApprovalChoice DeserializeFabricIQPreviewToolRequireApprovalChoice(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                McpToolCallApprovalPolicy approvalPolicy = ModelReaderWriter.Read<McpToolCallApprovalPolicy>(
                    BinaryData.FromString(element.GetRawText()),
                    options ?? ModelReaderWriterOptions.Json,
                    OpenAIContext.Default);
                return new FabricIQPreviewToolRequireApprovalChoice(approvalPolicy);
            }
            if (element.ValueKind == JsonValueKind.String)
            {
                return new FabricIQPreviewToolRequireApprovalChoice(element.GetString());
            }
            return null;
        }
#pragma warning restore OPENAI001

        internal static FabricIQPreviewToolRequireApprovalChoice FromBinaryData(BinaryData bytes)
        {
            if (bytes is null)
            {
                return new FabricIQPreviewToolRequireApprovalChoice();
            }
            using JsonDocument document = JsonDocument.Parse(bytes);
            return DeserializeFabricIQPreviewToolRequireApprovalChoice(document.RootElement);
        }
    }
}
