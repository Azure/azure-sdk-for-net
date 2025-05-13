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
    public partial class ElasticPoolActivity : IUtf8JsonSerializable, IJsonModel<ElasticPoolActivity>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<ElasticPoolActivity>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<ElasticPoolActivity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ElasticPoolActivity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ElasticPoolActivity)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(Location))
            {
                writer.WritePropertyName("location"u8);
                writer.WriteStringValue(Location.Value);
            }
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (options.Format != "W" && Optional.IsDefined(EndOn))
            {
                writer.WritePropertyName("endTime"u8);
                writer.WriteStringValue(EndOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(ErrorCode))
            {
                writer.WritePropertyName("errorCode"u8);
                writer.WriteNumberValue(ErrorCode.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(ErrorMessage))
            {
                writer.WritePropertyName("errorMessage"u8);
                writer.WriteStringValue(ErrorMessage);
            }
            if (options.Format != "W" && Optional.IsDefined(ErrorSeverity))
            {
                writer.WritePropertyName("errorSeverity"u8);
                writer.WriteNumberValue(ErrorSeverity.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(Operation))
            {
                writer.WritePropertyName("operation"u8);
                writer.WriteStringValue(Operation);
            }
            if (options.Format != "W" && Optional.IsDefined(OperationId))
            {
                writer.WritePropertyName("operationId"u8);
                writer.WriteStringValue(OperationId.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(PercentComplete))
            {
                writer.WritePropertyName("percentComplete"u8);
                writer.WriteNumberValue(PercentComplete.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedDatabaseDtuMax))
            {
                writer.WritePropertyName("requestedDatabaseDtuMax"u8);
                writer.WriteNumberValue(RequestedDatabaseDtuMax.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedDatabaseDtuMin))
            {
                writer.WritePropertyName("requestedDatabaseDtuMin"u8);
                writer.WriteNumberValue(RequestedDatabaseDtuMin.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedDtu))
            {
                writer.WritePropertyName("requestedDtu"u8);
                writer.WriteNumberValue(RequestedDtu.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedElasticPoolName))
            {
                writer.WritePropertyName("requestedElasticPoolName"u8);
                writer.WriteStringValue(RequestedElasticPoolName);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedStorageLimitInGB))
            {
                writer.WritePropertyName("requestedStorageLimitInGB"u8);
                writer.WriteNumberValue(RequestedStorageLimitInGB.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(ElasticPoolName))
            {
                writer.WritePropertyName("elasticPoolName"u8);
                writer.WriteStringValue(ElasticPoolName);
            }
            if (options.Format != "W" && Optional.IsDefined(ServerName))
            {
                writer.WritePropertyName("serverName"u8);
                writer.WriteStringValue(ServerName);
            }
            if (options.Format != "W" && Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startTime"u8);
                writer.WriteStringValue(StartOn.Value, "O");
            }
            if (options.Format != "W" && Optional.IsDefined(State))
            {
                writer.WritePropertyName("state"u8);
                writer.WriteStringValue(State);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedStorageLimitInMB))
            {
                writer.WritePropertyName("requestedStorageLimitInMB"u8);
                writer.WriteNumberValue(RequestedStorageLimitInMB.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedDatabaseDtuGuarantee))
            {
                writer.WritePropertyName("requestedDatabaseDtuGuarantee"u8);
                writer.WriteNumberValue(RequestedDatabaseDtuGuarantee.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedDatabaseDtuCap))
            {
                writer.WritePropertyName("requestedDatabaseDtuCap"u8);
                writer.WriteNumberValue(RequestedDatabaseDtuCap.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(RequestedDtuGuarantee))
            {
                writer.WritePropertyName("requestedDtuGuarantee"u8);
                writer.WriteNumberValue(RequestedDtuGuarantee.Value);
            }
            writer.WriteEndObject();
        }

        ElasticPoolActivity IJsonModel<ElasticPoolActivity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ElasticPoolActivity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ElasticPoolActivity)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeElasticPoolActivity(document.RootElement, options);
        }

        internal static ElasticPoolActivity DeserializeElasticPoolActivity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureLocation? location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            ResourceManager.Models.SystemData systemData = default;
            DateTimeOffset? endTime = default;
            int? errorCode = default;
            string errorMessage = default;
            int? errorSeverity = default;
            string operation = default;
            Guid? operationId = default;
            int? percentComplete = default;
            int? requestedDatabaseDtuMax = default;
            int? requestedDatabaseDtuMin = default;
            int? requestedDtu = default;
            string requestedElasticPoolName = default;
            long? requestedStorageLimitInGB = default;
            string elasticPoolName = default;
            string serverName = default;
            DateTimeOffset? startTime = default;
            string state = default;
            int? requestedStorageLimitInMB = default;
            int? requestedDatabaseDtuGuarantee = default;
            int? requestedDatabaseDtuCap = default;
            int? requestedDtuGuarantee = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("location"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    location = new AzureLocation(property.Value.GetString());
                    continue;
                }
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
                    systemData = JsonSerializer.Deserialize<ResourceManager.Models.SystemData>(property.Value.GetRawText());
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
                        if (property0.NameEquals("endTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            endTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("errorCode"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            errorCode = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("errorMessage"u8))
                        {
                            errorMessage = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("errorSeverity"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            errorSeverity = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("operation"u8))
                        {
                            operation = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("operationId"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            operationId = property0.Value.GetGuid();
                            continue;
                        }
                        if (property0.NameEquals("percentComplete"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            percentComplete = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedDatabaseDtuMax"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedDatabaseDtuMax = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedDatabaseDtuMin"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedDatabaseDtuMin = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedDtu"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedDtu = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedElasticPoolName"u8))
                        {
                            requestedElasticPoolName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("requestedStorageLimitInGB"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedStorageLimitInGB = property0.Value.GetInt64();
                            continue;
                        }
                        if (property0.NameEquals("elasticPoolName"u8))
                        {
                            elasticPoolName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("serverName"u8))
                        {
                            serverName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("startTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            startTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("state"u8))
                        {
                            state = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("requestedStorageLimitInMB"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedStorageLimitInMB = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedDatabaseDtuGuarantee"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedDatabaseDtuGuarantee = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedDatabaseDtuCap"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedDatabaseDtuCap = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("requestedDtuGuarantee"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            requestedDtuGuarantee = property0.Value.GetInt32();
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
            return new ElasticPoolActivity(
                id,
                name,
                type,
                systemData,
                location,
                endTime,
                errorCode,
                errorMessage,
                errorSeverity,
                operation,
                operationId,
                percentComplete,
                requestedDatabaseDtuMax,
                requestedDatabaseDtuMin,
                requestedDtu,
                requestedElasticPoolName,
                requestedStorageLimitInGB,
                elasticPoolName,
                serverName,
                startTime,
                state,
                requestedStorageLimitInMB,
                requestedDatabaseDtuGuarantee,
                requestedDatabaseDtuCap,
                requestedDtuGuarantee,
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Location), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("  location: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Location))
                {
                    builder.Append("  location: ");
                    builder.AppendLine($"'{Location.Value.ToString()}'");
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

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ResourceManager.Models.SystemData), out propertyOverride);
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
            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(EndOn), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    endTime: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(EndOn))
                {
                    builder.Append("    endTime: ");
                    var formattedDateTimeString = TypeFormatters.ToString(EndOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ErrorCode), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    errorCode: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ErrorCode))
                {
                    builder.Append("    errorCode: ");
                    builder.AppendLine($"{ErrorCode.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ErrorMessage), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    errorMessage: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ErrorMessage))
                {
                    builder.Append("    errorMessage: ");
                    if (ErrorMessage.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ErrorMessage}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ErrorMessage}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ErrorSeverity), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    errorSeverity: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ErrorSeverity))
                {
                    builder.Append("    errorSeverity: ");
                    builder.AppendLine($"{ErrorSeverity.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(Operation), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    operation: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(Operation))
                {
                    builder.Append("    operation: ");
                    if (Operation.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{Operation}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{Operation}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(OperationId), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    operationId: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(OperationId))
                {
                    builder.Append("    operationId: ");
                    builder.AppendLine($"'{OperationId.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(PercentComplete), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    percentComplete: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(PercentComplete))
                {
                    builder.Append("    percentComplete: ");
                    builder.AppendLine($"{PercentComplete.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedDatabaseDtuMax), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedDatabaseDtuMax: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedDatabaseDtuMax))
                {
                    builder.Append("    requestedDatabaseDtuMax: ");
                    builder.AppendLine($"{RequestedDatabaseDtuMax.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedDatabaseDtuMin), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedDatabaseDtuMin: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedDatabaseDtuMin))
                {
                    builder.Append("    requestedDatabaseDtuMin: ");
                    builder.AppendLine($"{RequestedDatabaseDtuMin.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedDtu), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedDtu: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedDtu))
                {
                    builder.Append("    requestedDtu: ");
                    builder.AppendLine($"{RequestedDtu.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedElasticPoolName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedElasticPoolName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedElasticPoolName))
                {
                    builder.Append("    requestedElasticPoolName: ");
                    if (RequestedElasticPoolName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{RequestedElasticPoolName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{RequestedElasticPoolName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedStorageLimitInGB), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedStorageLimitInGB: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedStorageLimitInGB))
                {
                    builder.Append("    requestedStorageLimitInGB: ");
                    builder.AppendLine($"'{RequestedStorageLimitInGB.Value.ToString()}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ElasticPoolName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    elasticPoolName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ElasticPoolName))
                {
                    builder.Append("    elasticPoolName: ");
                    if (ElasticPoolName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ElasticPoolName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ElasticPoolName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ServerName), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    serverName: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(ServerName))
                {
                    builder.Append("    serverName: ");
                    if (ServerName.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{ServerName}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{ServerName}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(StartOn), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    startTime: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(StartOn))
                {
                    builder.Append("    startTime: ");
                    var formattedDateTimeString = TypeFormatters.ToString(StartOn.Value, "o");
                    builder.AppendLine($"'{formattedDateTimeString}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(State), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    state: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(State))
                {
                    builder.Append("    state: ");
                    if (State.Contains(Environment.NewLine))
                    {
                        builder.AppendLine("'''");
                        builder.AppendLine($"{State}'''");
                    }
                    else
                    {
                        builder.AppendLine($"'{State}'");
                    }
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedStorageLimitInMB), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedStorageLimitInMB: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedStorageLimitInMB))
                {
                    builder.Append("    requestedStorageLimitInMB: ");
                    builder.AppendLine($"{RequestedStorageLimitInMB.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedDatabaseDtuGuarantee), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedDatabaseDtuGuarantee: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedDatabaseDtuGuarantee))
                {
                    builder.Append("    requestedDatabaseDtuGuarantee: ");
                    builder.AppendLine($"{RequestedDatabaseDtuGuarantee.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedDatabaseDtuCap), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedDatabaseDtuCap: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedDatabaseDtuCap))
                {
                    builder.Append("    requestedDatabaseDtuCap: ");
                    builder.AppendLine($"{RequestedDatabaseDtuCap.Value}");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(RequestedDtuGuarantee), out propertyOverride);
            if (hasPropertyOverride)
            {
                builder.Append("    requestedDtuGuarantee: ");
                builder.AppendLine(propertyOverride);
            }
            else
            {
                if (Optional.IsDefined(RequestedDtuGuarantee))
                {
                    builder.Append("    requestedDtuGuarantee: ");
                    builder.AppendLine($"{RequestedDtuGuarantee.Value}");
                }
            }

            builder.AppendLine("  }");
            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        BinaryData IPersistableModel<ElasticPoolActivity>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ElasticPoolActivity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerSqlContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(ElasticPoolActivity)} does not support writing '{options.Format}' format.");
            }
        }

        ElasticPoolActivity IPersistableModel<ElasticPoolActivity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ElasticPoolActivity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
                        return DeserializeElasticPoolActivity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ElasticPoolActivity)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<ElasticPoolActivity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
