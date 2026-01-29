// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Speech.Transcription
{
    public partial class EnhancedModeProperties
    {
        /// <summary>
        /// Custom serialization to auto-enable enhanced mode when properties are set.
        /// The 'enabled' property is automatically set to true when task, targetLanguage, or prompt are specified.
        /// </summary>
        private void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<EnhancedModeProperties>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(EnhancedModeProperties)} does not support writing '{format}' format.");
            }

            // Auto-enable if any property is configured
            bool shouldEnable = Optional.IsDefined(Task) ||
                               Optional.IsDefined(TargetLanguage) ||
                               Optional.IsCollectionDefined(Prompt);

            if (shouldEnable)
            {
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(true);
            }
            else if (Optional.IsDefined(Enabled))
            {
                // Only write explicit enabled value if nothing else is set (for deserialization round-trip)
                writer.WritePropertyName("enabled"u8);
                writer.WriteBooleanValue(Enabled.Value);
            }

            if (Optional.IsDefined(Task))
            {
                writer.WritePropertyName("task"u8);
                writer.WriteStringValue(Task);
            }
            if (Optional.IsDefined(TargetLanguage))
            {
                writer.WritePropertyName("targetLanguage"u8);
                writer.WriteStringValue(TargetLanguage);
            }
            if (Optional.IsCollectionDefined(Prompt))
            {
                writer.WritePropertyName("prompt"u8);
                writer.WriteStartArray();
                foreach (var item in Prompt)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
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
