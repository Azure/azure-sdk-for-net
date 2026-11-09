// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI;

public partial class WebIQPreviewToolRequireApprovalChoice : IJsonModel<WebIQPreviewToolRequireApprovalChoice>
{
    void IJsonModel<WebIQPreviewToolRequireApprovalChoice>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
           => SerializeWebIQPreviewToolRequireApprovalChoice(this, writer, options);

    WebIQPreviewToolRequireApprovalChoice IJsonModel<WebIQPreviewToolRequireApprovalChoice>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeWebIQPreviewToolRequireApprovalChoice(document.RootElement, options);
    }

    BinaryData IPersistableModel<WebIQPreviewToolRequireApprovalChoice>.Write(ModelReaderWriterOptions options)
    {
        return ModelReaderWriter.Write(this, options, null);
    }

    WebIQPreviewToolRequireApprovalChoice IPersistableModel<WebIQPreviewToolRequireApprovalChoice>.Create(BinaryData data, ModelReaderWriterOptions options)
        => FromBinaryData(data);

    string IPersistableModel<WebIQPreviewToolRequireApprovalChoice>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

#pragma warning disable OPENAI001
    internal static void SerializeWebIQPreviewToolRequireApprovalChoice(WebIQPreviewToolRequireApprovalChoice instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
    internal static WebIQPreviewToolRequireApprovalChoice DeserializeWebIQPreviewToolRequireApprovalChoice(JsonElement element, ModelReaderWriterOptions options = null)
    {
        if (element.ValueKind == JsonValueKind.Object)
        {
            McpToolCallApprovalPolicy approvalPolicy = ModelReaderWriter.Read<McpToolCallApprovalPolicy>(
                BinaryData.FromString(element.GetRawText()),
                options ?? ModelReaderWriterOptions.Json,
                OpenAIContext.Default);
            return new WebIQPreviewToolRequireApprovalChoice(approvalPolicy);
        }
        if (element.ValueKind == JsonValueKind.String)
        {
            return new WebIQPreviewToolRequireApprovalChoice(element.GetString());
        }
        return null;
    }
#pragma warning restore OPENAI001

    internal static WebIQPreviewToolRequireApprovalChoice FromBinaryData(BinaryData bytes)
    {
        if (bytes is null)
        {
            return new WebIQPreviewToolRequireApprovalChoice();
        }
        using JsonDocument document = JsonDocument.Parse(bytes);
        return DeserializeWebIQPreviewToolRequireApprovalChoice(document.RootElement);
    }
}
