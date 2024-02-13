// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.CostManagement.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CostManagement
{
    public partial class CostManagementExportData : IUtf8JsonSerializable, IJsonModel<CostManagementExportData>
    {
        internal static CostManagementExportData DeserializeCostManagementExportData(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<ETag> eTag = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<ExportFormatType> format = default;
            Optional<ExportDeliveryInfo> deliveryInfo = default;
            Optional<ExportDefinition> definition = default;
            Optional<ExportExecutionListResult> runHistory = default;
            Optional<bool> partitionData = default;
            Optional<DateTimeOffset> nextRunTimeEstimate = default;
            Optional<ExportSchedule> schedule = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("eTag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    eTag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("id"u8))
                {
                    // Service may return resource id without '/'.
                    id = property.Value.GetString().StartsWith("/") ? new ResourceIdentifier(property.Value.GetString()) : new ResourceIdentifier($"/{property.Value.GetString()}");
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
                        if (property0.NameEquals("format"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            format = new ExportFormatType(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("deliveryInfo"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            deliveryInfo = ExportDeliveryInfo.DeserializeExportDeliveryInfo(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("definition"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            definition = ExportDefinition.DeserializeExportDefinition(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("runHistory"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            runHistory = ExportExecutionListResult.DeserializeExportExecutionListResult(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("partitionData"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            partitionData = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("nextRunTimeEstimate"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            nextRunTimeEstimate = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("schedule"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            schedule = ExportSchedule.DeserializeExportSchedule(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new CostManagementExportData(id, name, type, systemData.Value, Optional.ToNullable(format), deliveryInfo.Value, definition.Value, runHistory.Value, Optional.ToNullable(partitionData), Optional.ToNullable(nextRunTimeEstimate), schedule.Value, Optional.ToNullable(eTag), serializedAdditionalRawData);
        }
    }
}
