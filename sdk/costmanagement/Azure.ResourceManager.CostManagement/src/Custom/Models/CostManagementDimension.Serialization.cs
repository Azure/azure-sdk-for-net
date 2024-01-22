// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CostManagement.Models
{
    public partial class CostManagementDimension : IUtf8JsonSerializable, IJsonModel<CostManagementDimension>
    {
        internal static CostManagementDimension DeserializeCostManagementDimension(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<AzureLocation> location = default;
            Optional<string> sku = default;
            Optional<ETag> eTag = default;
            Optional<IReadOnlyDictionary<string, string>> tags = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> description = default;
            Optional<bool> filterEnabled = default;
            Optional<bool> groupingEnabled = default;
            Optional<IReadOnlyList<string>> data = default;
            Optional<int> total = default;
            Optional<string> category = default;
            Optional<DateTimeOffset> usageStart = default;
            Optional<DateTimeOffset> usageEnd = default;
            Optional<string> nextLink = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
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
                if (property.NameEquals("sku"u8))
                {
                    sku = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("eTag"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    eTag = new ETag(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    tags = dictionary;
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
                        if (property0.NameEquals("description"u8))
                        {
                            description = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("filterEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            filterEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("groupingEnabled"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            groupingEnabled = property0.Value.GetBoolean();
                            continue;
                        }
                        if (property0.NameEquals("data"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            data = array;
                            continue;
                        }
                        if (property0.NameEquals("total"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            total = property0.Value.GetInt32();
                            continue;
                        }
                        if (property0.NameEquals("category"u8))
                        {
                            category = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("usageStart"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            usageStart = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("usageEnd"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            usageEnd = property0.Value.GetDateTimeOffset("O");
                            continue;
                        }
                        if (property0.NameEquals("nextLink"u8))
                        {
                            nextLink = property0.Value.GetString();
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
            return new CostManagementDimension(id, name, type, systemData.Value, description.Value, Optional.ToNullable(filterEnabled), Optional.ToNullable(groupingEnabled), Optional.ToList(data), Optional.ToNullable(total), category.Value, Optional.ToNullable(usageStart), Optional.ToNullable(usageEnd), nextLink.Value, Optional.ToNullable(location), sku.Value, Optional.ToNullable(eTag), Optional.ToDictionary(tags), serializedAdditionalRawData);
        }
    }
}
