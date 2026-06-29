// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class CsmDeploymentStatus : IJsonModel<CsmDeploymentStatus>
    {
        void IJsonModel<CsmDeploymentStatus>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CsmDeploymentStatus>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(CsmDeploymentStatus)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);

            if (Kind != null)
            {
                writer.WritePropertyName("kind"u8);
                writer.WriteStringValue(Kind);
            }

            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (DeploymentId != null)
            {
                writer.WritePropertyName("deploymentId"u8);
                writer.WriteStringValue(DeploymentId);
            }
            if (Status.HasValue)
            {
                writer.WritePropertyName("status"u8);
                writer.WriteStringValue(Status.Value.ToString());
            }
            if (NumberOfInstancesSuccessful.HasValue)
            {
                writer.WritePropertyName("numberOfInstancesSuccessful"u8);
                writer.WriteNumberValue(NumberOfInstancesSuccessful.Value);
            }
            if (NumberOfInstancesInProgress.HasValue)
            {
                writer.WritePropertyName("numberOfInstancesInProgress"u8);
                writer.WriteNumberValue(NumberOfInstancesInProgress.Value);
            }
            if (NumberOfInstancesFailed.HasValue)
            {
                writer.WritePropertyName("numberOfInstancesFailed"u8);
                writer.WriteNumberValue(NumberOfInstancesFailed.Value);
            }
            if (FailedInstancesLogs != null && FailedInstancesLogs.Count > 0)
            {
                writer.WritePropertyName("failedInstancesLogs"u8);
                writer.WriteStartArray();
                foreach (var log in FailedInstancesLogs)
                {
                    writer.WriteStringValue(log);
                }
                writer.WriteEndArray();
            }
            if (Errors != null && Errors.Count > 0)
            {
                writer.WritePropertyName("errors"u8);
                writer.WriteStartArray();
                foreach (var item in Errors)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IJsonModel<ResponseError>)item).Write(writer, options);
                    }
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();

            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var kv in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(kv.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(kv.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(kv.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        CsmDeploymentStatus IJsonModel<CsmDeploymentStatus>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeCsmDeploymentStatus(doc.RootElement, options);
        }

        internal static CsmDeploymentStatus DeserializeCsmDeploymentStatus(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            string kind = default;
            string deploymentId = default;
            DeploymentBuildStatus? status = default;
            int? numSucc = default;
            int? numProg = default;
            int? numFail = default;
            List<string> failedLogs = new List<string>();
            List<ResponseError> errors = new List<ResponseError>();
            Dictionary<string, BinaryData> raw = new Dictionary<string, BinaryData>();

            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    systemData = ModelReaderWriter.Read<SystemData>(BinaryData.FromString(prop.Value.GetRawText()), ModelSerializationExtensions.WireOptions, AzureResourceManagerAppServiceContext.Default);
                    continue;
                }
                if (prop.NameEquals("kind"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    kind = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    foreach (var inner in prop.Value.EnumerateObject())
                    {
                        if (inner.NameEquals("deploymentId"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            deploymentId = inner.Value.GetString();
                        }
                        else if (inner.NameEquals("status"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            status = new DeploymentBuildStatus(inner.Value.GetString());
                        }
                        else if (inner.NameEquals("numberOfInstancesSuccessful"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            numSucc = inner.Value.GetInt32();
                        }
                        else if (inner.NameEquals("numberOfInstancesInProgress"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            numProg = inner.Value.GetInt32();
                        }
                        else if (inner.NameEquals("numberOfInstancesFailed"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            numFail = inner.Value.GetInt32();
                        }
                        else if (inner.NameEquals("failedInstancesLogs"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            foreach (var item in inner.Value.EnumerateArray())
                            {
                                failedLogs.Add(item.ValueKind == JsonValueKind.Null ? null : item.GetString());
                            }
                        }
                        else if (inner.NameEquals("errors"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            foreach (var item in inner.Value.EnumerateArray())
                            {
                                if (item.ValueKind == JsonValueKind.Null)
                                {
                                    errors.Add(null);
                                }
                                else
                                {
                                    errors.Add(ModelReaderWriter.Read<ResponseError>(BinaryData.FromString(item.GetRawText()), ModelSerializationExtensions.WireOptions, AzureResourceManagerAppServiceContext.Default));
                                }
                            }
                        }
                    }
                    continue;
                }
                raw[prop.Name] = BinaryData.FromString(prop.Value.GetRawText());
            }
            return new CsmDeploymentStatus(id, name, resourceType, systemData, kind, deploymentId, status, numSucc, numProg, numFail, failedLogs, errors, raw);
        }

        BinaryData IPersistableModel<CsmDeploymentStatus>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CsmDeploymentStatus>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(CsmDeploymentStatus)} does not support writing '{options.Format}' format.");
            }
        }

        CsmDeploymentStatus IPersistableModel<CsmDeploymentStatus>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<CsmDeploymentStatus>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeCsmDeploymentStatus(document.RootElement, options);
                }
                default:
                    throw new FormatException($"The model {nameof(CsmDeploymentStatus)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<CsmDeploymentStatus>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
