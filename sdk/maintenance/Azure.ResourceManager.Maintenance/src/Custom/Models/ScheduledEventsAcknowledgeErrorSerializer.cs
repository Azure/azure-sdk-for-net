// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.ResourceManager.Maintenance;

namespace Azure.ResourceManager.Maintenance.Models
{
    internal static class ScheduledEventsAcknowledgeErrorSerializer
    {
        internal static ScheduledEventsListAcknowledgeError DeserializeListError(BinaryData data, ModelReaderWriterOptions options)
        {
            ValidateFormat<ScheduledEventsListAcknowledgeError>(options);
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeListError(document.RootElement, options);
        }

        internal static ScheduledEventsListAcknowledgeError DeserializeListError(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ValidateFormat<ScheduledEventsListAcknowledgeError>(options);
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeListError(document.RootElement, options);
        }

        internal static ScheduledEventsListAcknowledgeErrorDetails DeserializeListErrorDetails(BinaryData data, ModelReaderWriterOptions options)
        {
            ValidateFormat<ScheduledEventsListAcknowledgeErrorDetails>(options);
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeListErrorDetails(document.RootElement, options);
        }

        internal static ScheduledEventsListAcknowledgeErrorDetails DeserializeListErrorDetails(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ValidateFormat<ScheduledEventsListAcknowledgeErrorDetails>(options);
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeListErrorDetails(document.RootElement, options);
        }

        internal static ScheduledEventsAcknowledgeErrorDetails DeserializeErrorDetails(BinaryData data, ModelReaderWriterOptions options)
        {
            ValidateFormat<ScheduledEventsAcknowledgeErrorDetails>(options);
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeErrorDetails(document.RootElement, options);
        }

        internal static ScheduledEventsAcknowledgeErrorDetails DeserializeErrorDetails(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ValidateFormat<ScheduledEventsAcknowledgeErrorDetails>(options);
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeErrorDetails(document.RootElement, options);
        }

        internal static void Write(Utf8JsonWriter writer, ScheduledEventsListAcknowledgeError model, ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalProperties)
        {
            ValidateFormat<ScheduledEventsListAcknowledgeError>(options);
            writer.WriteStartObject();
            if (model.Error != null)
            {
                writer.WritePropertyName("error"u8);
                writer.WriteObjectValue(model.Error, options);
            }
            WriteAdditionalProperties(writer, options, additionalProperties);
            writer.WriteEndObject();
        }

        internal static void Write(Utf8JsonWriter writer, ScheduledEventsListAcknowledgeErrorDetails model, ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalProperties)
        {
            ValidateFormat<ScheduledEventsListAcknowledgeErrorDetails>(options);
            writer.WriteStartObject();
            if (model.Code != null)
            {
                writer.WritePropertyName("code"u8);
                writer.WriteStringValue(model.Code);
            }
            if (model.Message != null)
            {
                writer.WritePropertyName("message"u8);
                writer.WriteStringValue(model.Message);
            }
            if (Optional.IsCollectionDefined(model.Details))
            {
                writer.WritePropertyName("details"u8);
                writer.WriteStartArray();
                foreach (ScheduledEventsAcknowledgeErrorDetails item in model.Details)
                {
                    writer.WriteObjectValue(item, options);
                }
                writer.WriteEndArray();
            }
            WriteAdditionalProperties(writer, options, additionalProperties);
            writer.WriteEndObject();
        }

        internal static void Write(Utf8JsonWriter writer, ScheduledEventsAcknowledgeErrorDetails model, ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalProperties)
        {
            ValidateFormat<ScheduledEventsAcknowledgeErrorDetails>(options);
            writer.WriteStartObject();
            if (model.Target != null)
            {
                writer.WritePropertyName("target"u8);
                writer.WriteStringValue(model.Target);
            }
            if (model.Code != null)
            {
                writer.WritePropertyName("code"u8);
                writer.WriteStringValue(model.Code);
            }
            if (model.Message != null)
            {
                writer.WritePropertyName("message"u8);
                writer.WriteStringValue(model.Message);
            }
            WriteAdditionalProperties(writer, options, additionalProperties);
            writer.WriteEndObject();
        }

        private static ScheduledEventsListAcknowledgeError DeserializeListError(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            ScheduledEventsListAcknowledgeErrorDetails error = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("error"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        error = DeserializeListErrorDetails(property.Value, options);
                    }
                    continue;
                }
                AddAdditionalProperty(options, additionalProperties, property);
            }
            return new ScheduledEventsListAcknowledgeError(error, additionalProperties);
        }

        private static ScheduledEventsListAcknowledgeErrorDetails DeserializeListErrorDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string code = default;
            string message = default;
            IReadOnlyList<ScheduledEventsAcknowledgeErrorDetails> details = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("details"u8))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        List<ScheduledEventsAcknowledgeErrorDetails> items = new List<ScheduledEventsAcknowledgeErrorDetails>();
                        foreach (JsonElement item in property.Value.EnumerateArray())
                        {
                            items.Add(DeserializeErrorDetails(item, options));
                        }
                        details = items;
                    }
                    continue;
                }
                AddAdditionalProperty(options, additionalProperties, property);
            }
            return new ScheduledEventsListAcknowledgeErrorDetails(code, message, details ?? new ChangeTrackingList<ScheduledEventsAcknowledgeErrorDetails>(), additionalProperties);
        }

        private static ScheduledEventsAcknowledgeErrorDetails DeserializeErrorDetails(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string target = default;
            string code = default;
            string message = default;
            IDictionary<string, BinaryData> additionalProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("target"u8))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("code"u8))
                {
                    code = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("message"u8))
                {
                    message = property.Value.GetString();
                    continue;
                }
                AddAdditionalProperty(options, additionalProperties, property);
            }
            return new ScheduledEventsAcknowledgeErrorDetails(target, code, message, additionalProperties);
        }

        private static void AddAdditionalProperty(ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalProperties, JsonProperty property)
        {
            if (options.Format != "W")
            {
                additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
            }
        }

        private static void WriteAdditionalProperties(Utf8JsonWriter writer, ModelReaderWriterOptions options, IDictionary<string, BinaryData> additionalProperties)
        {
            if (options.Format == "W" || additionalProperties == null)
            {
                return;
            }

            foreach (KeyValuePair<string, BinaryData> item in additionalProperties)
            {
                writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(item.Value);
#else
                using JsonDocument document = JsonDocument.Parse(item.Value);
                JsonSerializer.Serialize(writer, document.RootElement);
#endif
            }
        }

        private static void ValidateFormat<T>(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? "J" : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {typeof(T).Name} does not support reading or writing '{options.Format}' format.");
            }
        }
    }
}
