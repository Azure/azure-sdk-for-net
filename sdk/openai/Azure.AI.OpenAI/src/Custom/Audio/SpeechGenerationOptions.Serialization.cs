// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

[CodeGenSuppress("global::System.ClientModel.Primitives.IJsonModel<Azure.AI.OpenAI.SpeechGenerationOptions>.Write", typeof(Utf8JsonWriter), typeof(ModelReaderWriterOptions))]
public partial class SpeechGenerationOptions : IJsonModel<SpeechGenerationOptions>
{
    // CUSTOM CODE NOTE:
    //   We manipulate the object model of this type relative to the wire format in several places; currently, this is
    //   best facilitated by performing a complete customization of the serialization.
    //TODO: Should use the property based serialization overrides here instead of the full serialization override.
    void IJsonModel<SpeechGenerationOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
    {
        var format = options.Format == "W" ? ((IPersistableModel<SpeechGenerationOptions>)this).GetFormatFromOptions(options) : options.Format;
        if (format != "J")
        {
            throw new FormatException($"The model {nameof(SpeechGenerationOptions)} does not support writing '{format}' format.");
        }

        writer.WriteStartObject();
        writer.WritePropertyName("model"u8);
        writer.WriteStringValue(DeploymentName);
        writer.WritePropertyName("input"u8);
        writer.WriteStringValue(Input);
        writer.WritePropertyName("voice"u8);
        writer.WriteStringValue(Voice.ToString());
        if (Optional.IsDefined(ResponseFormat))
        {
            writer.WritePropertyName("response_format"u8);
            writer.WriteStringValue(ResponseFormat.Value.ToString());
        }
        if (Optional.IsDefined(Speed))
        {
            writer.WritePropertyName("speed"u8);
            writer.WriteNumberValue(Speed.Value);
        }
        if (options.Format != "W" && _serializedAdditionalRawData != null)
        {
            foreach (var item in _serializedAdditionalRawData)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                using (JsonDocument document = JsonDocument.Parse(item.Value))
                {
                    JsonSerializer.Serialize(writer, document.RootElement);
                }
#endif
            }
        }
        writer.WriteEndObject();
    }
}
