// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    public partial class CostManagementAlertData : IUtf8JsonSerializable, IJsonModel<CostManagementAlertData>
    {
        internal static CostManagementAlertData DeserializeCostManagementAlertData(JsonElement element, ModelReaderWriterOptions options = null)
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
            Optional<AlertPropertiesDefinition> definition = default;
            Optional<string> description = default;
            Optional<CostManagementAlertSource> source = default;
            Optional<AlertPropertiesDetails> details = default;
            Optional<string> costEntityId = default;
            Optional<CostManagementAlertStatus> status = default;
            Optional<DateTimeOffset> creationTime = default;
            Optional<DateTimeOffset> closeTime = default;
            Optional<DateTimeOffset> modificationTime = default;
            Optional<string> statusModificationUserName = default;
            Optional<DateTimeOffset> statusModificationTime = default;
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
                        if (property0.NameEquals("definition"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            definition = AlertPropertiesDefinition.DeserializeAlertPropertiesDefinition(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("source"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            source = new CostManagementAlertSource(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("details"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            details = AlertPropertiesDetails.DeserializeAlertPropertiesDetails(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("costEntityId"u8))
                        {
                            costEntityId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("status"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            status = new CostManagementAlertStatus(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("creationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            creationTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("closeTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            closeTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("modificationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            modificationTime = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("statusModificationUserName"u8))
                        {
                            statusModificationUserName = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("statusModificationTime"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            statusModificationTime = property0.Value.GetDateTimeOffset("O");
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
            return new CostManagementAlertData(id, name, type, systemData.Value, definition.Value, description.Value, Optional.ToNullable(source), details.Value, costEntityId.Value, Optional.ToNullable(status), Optional.ToNullable(creationTime), Optional.ToNullable(closeTime), Optional.ToNullable(modificationTime), statusModificationUserName.Value, Optional.ToNullable(statusModificationTime), Optional.ToNullable(eTag), serializedAdditionalRawData);
        }
    }
}
