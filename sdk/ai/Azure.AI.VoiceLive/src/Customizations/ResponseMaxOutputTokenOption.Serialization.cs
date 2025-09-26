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
    public partial class MaxResponseOutputTokensOption : IJsonModel<MaxResponseOutputTokensOption>
    {
        void IJsonModel<MaxResponseOutputTokensOption>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => SerializeConversationMaxTokensChoice(this, writer, options);

        MaxResponseOutputTokensOption IJsonModel<MaxResponseOutputTokensOption>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationMaxTokensChoice(document.RootElement, options);
        }

        BinaryData IPersistableModel<MaxResponseOutputTokensOption>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options, null);
        }

        MaxResponseOutputTokensOption IPersistableModel<MaxResponseOutputTokensOption>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromBinaryData(data);

        string IPersistableModel<MaxResponseOutputTokensOption>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static void SerializeConversationMaxTokensChoice(MaxResponseOutputTokensOption instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (instance._isDefaultNullValue == true)
            {
                writer.WriteNullValue();
            }
            else if (instance._stringValue is not null)
            {
                writer.WriteStringValue(instance._stringValue);
            }
            else if (instance.NumericValue.HasValue)
            {
                writer.WriteNumberValue(instance.NumericValue.Value);
            }
        }

        internal static MaxResponseOutputTokensOption DeserializeConversationMaxTokensChoice(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return new MaxResponseOutputTokensOption(isDefaultNullValue: true);
            }
            if (element.ValueKind == JsonValueKind.String)
            {
                return new MaxResponseOutputTokensOption(stringValue: element.GetString());
            }
            if (element.ValueKind == JsonValueKind.Number)
            {
                return new MaxResponseOutputTokensOption(numberValue: element.GetInt32());
            }
            return null;
        }

        internal static MaxResponseOutputTokensOption FromBinaryData(BinaryData bytes)
        {
            if (bytes is null)
            {
                return new MaxResponseOutputTokensOption(isDefaultNullValue: true);
            }
            using JsonDocument document = JsonDocument.Parse(bytes);
            return DeserializeConversationMaxTokensChoice(document.RootElement);
        }
    }
}
