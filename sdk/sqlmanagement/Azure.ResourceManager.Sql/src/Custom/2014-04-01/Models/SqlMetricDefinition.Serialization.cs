// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class SqlMetricDefinition : IUtf8JsonSerializable, IJsonModel<SqlMetricDefinition>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<SqlMetricDefinition>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<SqlMetricDefinition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricDefinition>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SqlMetricDefinition)} does not support writing '{format}' format.");
            }

            if (options.Format != "W" && Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteObjectValue(Name, options);
            }
            if (options.Format != "W" && Optional.IsDefined(PrimaryAggregationType))
            {
                writer.WritePropertyName("primaryAggregationType"u8);
                writer.WriteStringValue(PrimaryAggregationType.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(ResourceUriString))
            {
                writer.WritePropertyName("resourceUri"u8);
                writer.WriteStringValue(ResourceUriString);
            }
            if (options.Format != "W" && Optional.IsDefined(Unit))
            {
                writer.WritePropertyName("unit"u8);
                writer.WriteStringValue(Unit.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(MetricAvailabilities))
            {
                writer.WritePropertyName("metricAvailabilities"u8);
                writer.WriteStartArray();
                foreach (var item in MetricAvailabilities)
                {
                    writer.WriteObjectValue(item, options);
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

        SqlMetricDefinition IJsonModel<SqlMetricDefinition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricDefinition>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SqlMetricDefinition)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeSqlMetricDefinition(document.RootElement, options);
        }

        internal static SqlMetricDefinition DeserializeSqlMetricDefinition(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            SqlMetricName name = default;
            SqlMetricPrimaryAggregationType? primaryAggregationType = default;
            string resourceUri = default;
            SqlMetricDefinitionUnitType? unit = default;
            IReadOnlyList<SqlMetricAvailability> metricAvailabilities = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    name = SqlMetricName.DeserializeSqlMetricName(property.Value, options);
                    continue;
                }
                if (property.NameEquals("primaryAggregationType"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    primaryAggregationType = new SqlMetricPrimaryAggregationType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("resourceUri"u8))
                {
                    resourceUri = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("unit"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    unit = new SqlMetricDefinitionUnitType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("metricAvailabilities"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<SqlMetricAvailability> array = new List<SqlMetricAvailability>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(SqlMetricAvailability.DeserializeSqlMetricAvailability(item, options));
                    }
                    metricAvailabilities = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new SqlMetricDefinition(
                name,
                primaryAggregationType,
                resourceUri,
                unit,
                metricAvailabilities ?? new ChangeTrackingList<SqlMetricAvailability>(),
                serializedAdditionalRawData);
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Name), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  name: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Name))
                {
                    builder.Append("  name: ");
                    BicepSerializationHelpers.AppendChildObject(builder, Name, options, 2, false, "  name: ");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PrimaryAggregationType), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  primaryAggregationType: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PrimaryAggregationType))
                {
                    builder.Append("  primaryAggregationType: ");
                    builder.AppendLine($"'{PrimaryAggregationType.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ResourceUriString), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  resourceUri: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ResourceUriString))
                {
                    builder.Append("  resourceUri: ");
                    if (ResourceUriString.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ResourceUriString}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ResourceUriString}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Unit), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  unit: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Unit))
                {
                    builder.Append("  unit: ");
                    builder.AppendLine($"'{Unit.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(MetricAvailabilities), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  metricAvailabilities: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsCollectionDefined(MetricAvailabilities))
                {
                    if (MetricAvailabilities.Any())
                    {
                        builder.Append("  metricAvailabilities: ");
                        builder.AppendLine("[");
                        foreach (var item in MetricAvailabilities)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  metricAvailabilities: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<SqlMetricDefinition>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricDefinition>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerSqlContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(SqlMetricDefinition)} does not support writing '{options.Format}' format.");
            }
        }

        SqlMetricDefinition IPersistableModel<SqlMetricDefinition>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<SqlMetricDefinition>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeSqlMetricDefinition(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(SqlMetricDefinition)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SqlMetricDefinition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
