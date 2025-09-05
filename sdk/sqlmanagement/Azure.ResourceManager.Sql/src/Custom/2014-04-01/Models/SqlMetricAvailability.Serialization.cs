// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlMetricAvailability : IUtf8JsonSerializable, IJsonModel<SqlMetricAvailability>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SqlMetricAvailability>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<SqlMetricAvailability>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricAvailability>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SqlMetricAvailability)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(Retention))
            {
                writer.WritePropertyName("retention"u8);
                writer.WriteStringValue(Retention);
            }
            if (options.Format != "W" && Optional.IsDefined(TimeGrain))
            {
                writer.WritePropertyName("timeGrain"u8);
                writer.WriteStringValue(TimeGrain);
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

        SqlMetricAvailability IJsonModel<SqlMetricAvailability>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricAvailability>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SqlMetricAvailability)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSqlMetricAvailability(document.RootElement, options);
        }

        internal static SqlMetricAvailability DeserializeSqlMetricAvailability(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string retention = default;
            string timeGrain = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("retention"u8))
                {
                    retention = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("timeGrain"u8))
                {
                    timeGrain = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new SqlMetricAvailability(retention, timeGrain, serializedAdditionalRawData);
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;

            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Retention), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  retention: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Retention))
                {
                    builder.Append("  retention: ");
                    if (Retention.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Retention}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Retention}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(TimeGrain), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  timeGrain: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(TimeGrain))
                {
                    builder.Append("  timeGrain: ");
                    if (TimeGrain.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{TimeGrain}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{TimeGrain}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<SqlMetricAvailability>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricAvailability>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerSqlContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(SqlMetricAvailability)} does not support writing '{options.Format}' format.");
            }
        }

        SqlMetricAvailability IPersistableModel<SqlMetricAvailability>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricAvailability>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeSqlMetricAvailability(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SqlMetricAvailability)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SqlMetricAvailability>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
