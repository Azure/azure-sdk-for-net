// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.Projects.Agents;

public partial class VoiceAgentMaxOutputTokens: IJsonModel<VoiceAgentMaxOutputTokens>
{
    void IJsonModel<VoiceAgentMaxOutputTokens>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => SerializeMaxResponseOutputTokensOption(this, writer, options);

    VoiceAgentMaxOutputTokens IJsonModel<VoiceAgentMaxOutputTokens>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
    {
        using JsonDocument document = JsonDocument.ParseValue(ref reader);
        return DeserializeVoiceAgentMaxOutputTokens(document.RootElement, options);
    }

    BinaryData IPersistableModel<VoiceAgentMaxOutputTokens>.Write(ModelReaderWriterOptions options)
    {
        return ModelReaderWriter.Write(this, options, null);
    }

    VoiceAgentMaxOutputTokens IPersistableModel<VoiceAgentMaxOutputTokens>.Create(BinaryData data, ModelReaderWriterOptions options)
        => FromBinaryData(data);

    string IPersistableModel<VoiceAgentMaxOutputTokens>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

    internal static void SerializeMaxResponseOutputTokensOption(VoiceAgentMaxOutputTokens instance, Utf8JsonWriter writer, ModelReaderWriterOptions options)
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

    internal static VoiceAgentMaxOutputTokens DeserializeVoiceAgentMaxOutputTokens(JsonElement element, ModelReaderWriterOptions options = null)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return new VoiceAgentMaxOutputTokens(isDefaultNullValue: true);
        }
        if (element.ValueKind == JsonValueKind.String)
        {
            return new VoiceAgentMaxOutputTokens(stringValue: element.GetString());
        }
        if (element.ValueKind == JsonValueKind.Number)
        {
            return new VoiceAgentMaxOutputTokens(numberValue: element.GetInt32());
        }
        return null;
    }

    internal static VoiceAgentMaxOutputTokens FromBinaryData(BinaryData bytes)
    {
        if (bytes is null)
        {
            return new VoiceAgentMaxOutputTokens(isDefaultNullValue: true);
        }
        using JsonDocument document = JsonDocument.Parse(bytes);
        return DeserializeVoiceAgentMaxOutputTokens(document.RootElement);
    }
}
