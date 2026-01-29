// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Speech.Transcription
{
    public partial class TranscriptionDiarizationOptions
    {
        /// <summary>
        /// Custom serialization to auto-enable diarization when MaxSpeakers is set.
        /// The 'enabled' property is automatically set to true when maxSpeakers is specified.
        /// </summary>
        private void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<TranscriptionDiarizationOptions>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(TranscriptionDiarizationOptions)} does not support writing '{format}' format.");
            }

            // Auto-enable if MaxSpeakers is configured
            bool shouldEnable = Optional.IsDefined(MaxSpeakers);

            if (shouldEnable)
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(true);
            }
            else if (Optional.IsDefined(Enabled))
            {
                // Only write explicit enabled value if MaxSpeakers is not set (for deserialization round-trip)
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }

            if (Optional.IsDefined(MaxSpeakers))
            {
                writer.WritePropertyName("maxSpeakers"u8);
                writer.WriteNumberValue(MaxSpeakers.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value, ModelSerializationExtensions.JsonDocumentOptions))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }
    }
}
