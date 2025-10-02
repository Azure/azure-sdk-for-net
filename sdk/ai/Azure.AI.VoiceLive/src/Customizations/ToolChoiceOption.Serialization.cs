// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    ///
    /// </summary>
    public partial class ToolChoiceOption : IJsonModel<ToolChoiceOption>
    {
        void IJsonModel<ToolChoiceOption>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => SerializeToolChoiceOption(this, writer, options);

        ToolChoiceOption IJsonModel<ToolChoiceOption>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeToolChoiceOption(document.RootElement, options);
        }

        BinaryData IPersistableModel<ToolChoiceOption>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options, null);
        }

        ToolChoiceOption IPersistableModel<ToolChoiceOption>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromBinaryData(data);

        string IPersistableModel<ToolChoiceOption>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static void SerializeToolChoiceOption(ToolChoiceOption instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (instance.ToolCallConstraint.HasValue)
            {
                writer.WriteStringValue(instance.ToolCallConstraint.Value.ToString());
            }
            else if (instance.FunctionName is not null)
            {
                var functionObject = new ToolChoiceFunctionObject(name: instance.FunctionName);
                writer.WriteObjectValue(functionObject, options);
            }
        }

        internal static ToolChoiceOption DeserializeToolChoiceOption(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                var functionObject = ToolChoiceFunctionObject.DeserializeToolChoiceFunctionObject(element, options);
                return new ToolChoiceOption(functionObject.Name);
            }
            if (element.ValueKind == JsonValueKind.String)
            {
                return new ToolChoiceOption(new ToolChoiceLiteral(element.GetString()));
            }
            return null;
        }

        internal static ToolChoiceOption FromBinaryData(BinaryData bytes)
        {
            if (bytes is null)
            {
                return new ToolChoiceOption();
            }
            using JsonDocument document = JsonDocument.Parse(bytes);
            return DeserializeToolChoiceOption(document.RootElement);
        }
    }
}
