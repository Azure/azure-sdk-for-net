// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql.Models;
using SystemData = Azure.ResourceManager.Models.SystemData;

namespace Azure.ResourceManager.Sql
{
    public partial class DistributedAvailabilityGroupData : IUtf8JsonSerializable, IJsonModel<DistributedAvailabilityGroupData>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<DistributedAvailabilityGroupData>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<DistributedAvailabilityGroupData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DistributedAvailabilityGroupData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DistributedAvailabilityGroupData)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(TargetDatabase))
            {
                writer.WritePropertyName("targetDatabase"u8);
                writer.WriteStringValue(TargetDatabase);
            }
            if (Optional.IsDefined(SourceEndpoint))
            {
                writer.WritePropertyName("sourceEndpoint"u8);
                writer.WriteStringValue(SourceEndpoint);
            }
            if (Optional.IsDefined(PrimaryAvailabilityGroupName))
            {
                writer.WritePropertyName("primaryAvailabilityGroupName"u8);
                writer.WriteStringValue(PrimaryAvailabilityGroupName);
            }
            if (Optional.IsDefined(SecondaryAvailabilityGroupName))
            {
                writer.WritePropertyName("secondaryAvailabilityGroupName"u8);
                writer.WriteStringValue(SecondaryAvailabilityGroupName);
            }
            if (Optional.IsDefined(ReplicationMode))
            {
                writer.WritePropertyName("replicationMode"u8);
                writer.WriteStringValue(ReplicationMode.Value.ToString());
            }
            if (options.Format != "W" && Optional.IsDefined(DistributedAvailabilityGroupId))
            {
                writer.WritePropertyName("distributedAvailabilityGroupId"u8);
                writer.WriteStringValue(DistributedAvailabilityGroupId.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(SourceReplicaId))
            {
                writer.WritePropertyName("sourceReplicaId"u8);
                writer.WriteStringValue(SourceReplicaId.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(TargetReplicaId))
            {
                writer.WritePropertyName("targetReplicaId"u8);
                writer.WriteStringValue(TargetReplicaId.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(LinkState))
            {
                writer.WritePropertyName("linkState"u8);
                writer.WriteStringValue(LinkState);
            }
            if (options.Format != "W" && Optional.IsDefined(LastHardenedLsn))
            {
                writer.WritePropertyName("lastHardenedLsn"u8);
                writer.WriteStringValue(LastHardenedLsn);
            }
            writer.WriteEndObject();
        }

        DistributedAvailabilityGroupData IJsonModel<DistributedAvailabilityGroupData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DistributedAvailabilityGroupData>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DistributedAvailabilityGroupData)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeDistributedAvailabilityGroupData(document.RootElement, options);
        }

        internal static DistributedAvailabilityGroupData DeserializeDistributedAvailabilityGroupData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            SystemData systemData = default;
            string targetDatabase = default;
            string sourceEndpoint = default;
            string primaryAvailabilityGroupName = default;
            string secondaryAvailabilityGroupName = default;
            DistributedAvailabilityGroupReplicationMode? replicationMode = default;
            Guid? distributedAvailabilityGroupId = default;
            Guid? sourceReplicaId = default;
            Guid? targetReplicaId = default;
            string linkState = default;
            string lastHardenedLsn = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    systemData = ModelReaderWriter.Read<SystemData>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), ModelSerializationExtensions.WireOptions, AzureResourceManagerSqlContext.Default);
                    continue;
                }
                if (property.NameEquals("properties"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("targetDatabase"u8))
                        {
                            targetDatabase = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("sourceEndpoint"u8))
                        {
                            sourceEndpoint = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("primaryAvailabilityGroupName"u8))
                        {
                            primaryAvailabilityGroupName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("secondaryAvailabilityGroupName"u8))
                        {
                            secondaryAvailabilityGroupName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("replicationMode"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            replicationMode = new DistributedAvailabilityGroupReplicationMode(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("distributedAvailabilityGroupId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            distributedAvailabilityGroupId = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("sourceReplicaId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            sourceReplicaId = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("targetReplicaId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            targetReplicaId = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("linkState"u8))
                        {
                            linkState = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("lastHardenedLsn"u8))
                        {
                            lastHardenedLsn = property0.Value.GetString();
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DistributedAvailabilityGroupData(
                id,
                name,
                type,
                systemData,
                targetDatabase,
                sourceEndpoint,
                primaryAvailabilityGroupName,
                secondaryAvailabilityGroupName,
                replicationMode,
                distributedAvailabilityGroupId,
                sourceReplicaId,
                targetReplicaId,
                linkState,
                lastHardenedLsn,
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Id), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  id: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Id))
                {
                    builder.Append("  id: ");
                    builder.AppendLine($"'{Id.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SystemData), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  systemData: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SystemData))
                {
                    builder.Append("  systemData: ");
                    builder.AppendLine($"'{SystemData.ToString()}'");
                }
            }

            builder.Append("  properties:");
            builder.AppendLine(" {");
            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(TargetDatabase), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    targetDatabase: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(TargetDatabase))
                {
                    builder.Append("    targetDatabase: ");
                    if (TargetDatabase.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{TargetDatabase}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{TargetDatabase}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SourceEndpoint), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    sourceEndpoint: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SourceEndpoint))
                {
                    builder.Append("    sourceEndpoint: ");
                    if (SourceEndpoint.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{SourceEndpoint}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{SourceEndpoint}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PrimaryAvailabilityGroupName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    primaryAvailabilityGroupName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PrimaryAvailabilityGroupName))
                {
                    builder.Append("    primaryAvailabilityGroupName: ");
                    if (PrimaryAvailabilityGroupName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{PrimaryAvailabilityGroupName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{PrimaryAvailabilityGroupName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SecondaryAvailabilityGroupName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    secondaryAvailabilityGroupName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SecondaryAvailabilityGroupName))
                {
                    builder.Append("    secondaryAvailabilityGroupName: ");
                    if (SecondaryAvailabilityGroupName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{SecondaryAvailabilityGroupName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{SecondaryAvailabilityGroupName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ReplicationMode), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    replicationMode: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ReplicationMode))
                {
                    builder.Append("    replicationMode: ");
                    builder.AppendLine($"'{ReplicationMode.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(DistributedAvailabilityGroupId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    distributedAvailabilityGroupId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(DistributedAvailabilityGroupId))
                {
                    builder.Append("    distributedAvailabilityGroupId: ");
                    builder.AppendLine($"'{DistributedAvailabilityGroupId.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(SourceReplicaId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    sourceReplicaId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(SourceReplicaId))
                {
                    builder.Append("    sourceReplicaId: ");
                    builder.AppendLine($"'{SourceReplicaId.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(TargetReplicaId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    targetReplicaId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(TargetReplicaId))
                {
                    builder.Append("    targetReplicaId: ");
                    builder.AppendLine($"'{TargetReplicaId.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LinkState), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    linkState: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(LinkState))
                {
                    builder.Append("    linkState: ");
                    if (LinkState.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{LinkState}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{LinkState}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(LastHardenedLsn), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    lastHardenedLsn: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(LastHardenedLsn))
                {
                    builder.Append("    lastHardenedLsn: ");
                    if (LastHardenedLsn.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{LastHardenedLsn}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{LastHardenedLsn}'");
                    }
                }
            }

            builder.AppendLine("  }");
            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<DistributedAvailabilityGroupData>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DistributedAvailabilityGroupData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerSqlContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(DistributedAvailabilityGroupData)} does not support writing '{options.Format}' format.");
            }
        }

        DistributedAvailabilityGroupData IPersistableModel<DistributedAvailabilityGroupData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DistributedAvailabilityGroupData>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeDistributedAvailabilityGroupData(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(DistributedAvailabilityGroupData)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<DistributedAvailabilityGroupData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
