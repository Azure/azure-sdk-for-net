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
    public partial class ResponseMaxOutputTokensOption : IJsonModel<ResponseMaxOutputTokensOption>
    {
        void IJsonModel<ResponseMaxOutputTokensOption>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => SerializeConversationMaxTokensChoice(this, writer, options);

        ResponseMaxOutputTokensOption IJsonModel<ResponseMaxOutputTokensOption>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeConversationMaxTokensChoice(document.RootElement, options);
        }

        BinaryData IPersistableModel<ResponseMaxOutputTokensOption>.Write(ModelReaderWriterOptions options)
        {
            return ModelReaderWriter.Write(this, options, null);
        }

        ResponseMaxOutputTokensOption IPersistableModel<ResponseMaxOutputTokensOption>.Create(BinaryData data, ModelReaderWriterOptions options)
            => FromBinaryData(data);

        string IPersistableModel<ResponseMaxOutputTokensOption>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static void SerializeConversationMaxTokensChoice(ResponseMaxOutputTokensOption instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
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

        internal static ResponseMaxOutputTokensOption DeserializeConversationMaxTokensChoice(JsonElement element, ModelReaderWriterOptions options = null)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return new ResponseMaxOutputTokensOption(isDefaultNullValue: true);
            }
            if (element.ValueKind == JsonValueKind.String)
            {
                return new ResponseMaxOutputTokensOption(stringValue: element.GetString());
            }
            if (element.ValueKind == JsonValueKind.Number)
            {
                return new ResponseMaxOutputTokensOption(numberValue: element.GetInt32());
            }
            return null;
        }

        internal static ResponseMaxOutputTokensOption FromBinaryData(BinaryData bytes)
        {
            if (bytes is null)
            {
                return new ResponseMaxOutputTokensOption(isDefaultNullValue: true);
            }
            using JsonDocument document = JsonDocument.Parse(bytes);
            return DeserializeConversationMaxTokensChoice(document.RootElement);
        }
    }
}
