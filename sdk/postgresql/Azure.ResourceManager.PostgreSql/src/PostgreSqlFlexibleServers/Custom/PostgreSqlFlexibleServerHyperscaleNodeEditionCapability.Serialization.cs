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

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerHyperscaleNodeEditionCapability : IUtf8JsonSerializable, IJsonModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>)this).Write(writer, new ModelReaderWriterOptions("W"));

        void IJsonModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PostgreSqlFlexibleServerHyperscaleNodeEditionCapability)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(SupportedStorageEditions))
            {
                writer.WritePropertyName("supportedStorageEditions"u8);
                writer.WriteStartArray();
                foreach (var item in SupportedStorageEditions)
                {
                    writer.WriteObjectValue<PostgreSqlFlexibleServerStorageEditionCapability>(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(SupportedServerVersions))
            {
                writer.WritePropertyName("supportedServerVersions"u8);
                writer.WriteStartArray();
                foreach (var item in SupportedServerVersions)
                {
                    writer.WriteObjectValue<PostgreSqlFlexibleServerServerVersionCapability>(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsCollectionDefined(SupportedNodeTypes))
            {
                writer.WritePropertyName("supportedNodeTypes"u8);
                writer.WriteStartArray();
                foreach (var item in SupportedNodeTypes)
                {
                    writer.WriteObjectValue<PostgreSqlFlexibleServerNodeTypeCapability>(item, options);
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && Optional.IsDefined(Status))
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status);
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

        PostgreSqlFlexibleServerHyperscaleNodeEditionCapability IJsonModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(PostgreSqlFlexibleServerHyperscaleNodeEditionCapability)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializePostgreSqlFlexibleServerHyperscaleNodeEditionCapability(document.RootElement, options);
        }

        internal static PostgreSqlFlexibleServerHyperscaleNodeEditionCapability DeserializePostgreSqlFlexibleServerHyperscaleNodeEditionCapability(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            IReadOnlyList<PostgreSqlFlexibleServerStorageEditionCapability> supportedStorageEditions = default;
            IReadOnlyList<PostgreSqlFlexibleServerServerVersionCapability> supportedServerVersions = default;
            IReadOnlyList<PostgreSqlFlexibleServerNodeTypeCapability> supportedNodeTypes = default;
            string status = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("supportedStorageEditions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PostgreSqlFlexibleServerStorageEditionCapability> array = new List<PostgreSqlFlexibleServerStorageEditionCapability>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PostgreSqlFlexibleServerStorageEditionCapability.DeserializePostgreSqlFlexibleServerStorageEditionCapability(item, options));
                    }
                    supportedStorageEditions = array;
                    continue;
                }
                if (property.NameEquals("supportedServerVersions"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PostgreSqlFlexibleServerServerVersionCapability> array = new List<PostgreSqlFlexibleServerServerVersionCapability>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PostgreSqlFlexibleServerServerVersionCapability.DeserializePostgreSqlFlexibleServerServerVersionCapability(item, options));
                    }
                    supportedServerVersions = array;
                    continue;
                }
                if (property.NameEquals("supportedNodeTypes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PostgreSqlFlexibleServerNodeTypeCapability> array = new List<PostgreSqlFlexibleServerNodeTypeCapability>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PostgreSqlFlexibleServerNodeTypeCapability.DeserializePostgreSqlFlexibleServerNodeTypeCapability(item, options));
                    }
                    supportedNodeTypes = array;
                    continue;
                }
                if (property.NameEquals("status"u8))
                {
                    status = property.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new PostgreSqlFlexibleServerHyperscaleNodeEditionCapability(
                name,
                supportedStorageEditions ?? new ChangeTrackingList<PostgreSqlFlexibleServerStorageEditionCapability>(),
                supportedServerVersions ?? new ChangeTrackingList<PostgreSqlFlexibleServerServerVersionCapability>(),
                supportedNodeTypes ?? new ChangeTrackingList<PostgreSqlFlexibleServerNodeTypeCapability>(),
                status,
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
            if (Optional.IsDefined(Name) || hasPropertyOverride)
            {
                builder.Append("  name: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Name.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Name}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Name}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SupportedStorageEditions), out propertyOverride);
            if (Optional.IsCollectionDefined(SupportedStorageEditions) || hasPropertyOverride)
            {
                if (SupportedStorageEditions.Any() || hasPropertyOverride)
                {
                    builder.Append("  supportedStorageEditions: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in SupportedStorageEditions)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  supportedStorageEditions: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SupportedServerVersions), out propertyOverride);
            if (Optional.IsCollectionDefined(SupportedServerVersions) || hasPropertyOverride)
            {
                if (SupportedServerVersions.Any() || hasPropertyOverride)
                {
                    builder.Append("  supportedServerVersions: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in SupportedServerVersions)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  supportedServerVersions: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SupportedNodeTypes), out propertyOverride);
            if (Optional.IsCollectionDefined(SupportedNodeTypes) || hasPropertyOverride)
            {
                if (SupportedNodeTypes.Any() || hasPropertyOverride)
                {
                    builder.Append("  supportedNodeTypes: ");
                    if (hasPropertyOverride)
                    {
                        builder.AppendLine($"{propertyOverride}");
                    }
                    else
                    {
                        builder.AppendLine("[");
                        foreach (var item in SupportedNodeTypes)
                        {
                            BicepSerializationHelpers.AppendChildObject(builder, item, options, 4, true, "  supportedNodeTypes: ");
                        }
                        builder.AppendLine("  ]");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Status), out propertyOverride);
            if (Optional.IsDefined(Status) || hasPropertyOverride)
            {
                builder.Append("  status: ");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"{propertyOverride}");
                }
                else
                {
                    if (Status.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Status}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Status}'");
                    }
                }
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerPostgreSqlContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(PostgreSqlFlexibleServerHyperscaleNodeEditionCapability)} does not support writing '{options.Format}' format.");
            }
        }

        PostgreSqlFlexibleServerHyperscaleNodeEditionCapability IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializePostgreSqlFlexibleServerHyperscaleNodeEditionCapability(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(PostgreSqlFlexibleServerHyperscaleNodeEditionCapability)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<PostgreSqlFlexibleServerHyperscaleNodeEditionCapability>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
