// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;
// this is required, the generator will generate another SystemData in Azure.ResourceManager.Monitor.Models under the hood and remove it in the last step if it is unused. If we did not specify that, it will have ambiguity while determining if that SystemData is truly unused
using SystemData = Azure.ResourceManager.Models.SystemData;

namespace Azure.ResourceManager.Monitor
{
    public partial class LogProfileData
    {
        // this customization method is here to fix the deserialization issue for some non-nullable properties
        // they will return as nullable in the service response
        internal static LogProfileData DeserializeLogProfileData(JsonElement element)
        {
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<SystemData> systemData = default;
            Optional<ResourceIdentifier> storageAccountId = default;
            Optional<ResourceIdentifier> serviceBusRuleId = default;
            IList<AzureLocation> locations = default;
            IList<string> categories = default;
            RetentionPolicy retentionPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        // change this to nullable since the service might send null value for tags in the response
                        tags = null;
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
                if (property.NameEquals("location"))
                {
                    // enclosing this deserialization in this if since the service might return null value for this property
                    // and we cannot resolve this using a directive since this property is inherited from base type ResourceData
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        location = new AzureLocation(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    // enclosing this deserialization in this if since the service might return null value for this property
                    // and we cannot resolve this using a directive since this property is inherited from base type ResourceData
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        type = new ResourceType(property.Value.GetString());
                    }
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    systemData = JsonSerializer.Deserialize<SystemData>(property.Value.ToString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        if (property0.NameEquals("storageAccountId"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                storageAccountId = null;
                                continue;
                            }
                            storageAccountId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("serviceBusRuleId"))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                serviceBusRuleId = null;
                                continue;
                            }
                            serviceBusRuleId = new ResourceIdentifier(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("locations"))
                        {
                            List<AzureLocation> array = new List<AzureLocation>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(new AzureLocation(item.GetString()));
                            }
                            locations = array;
                            continue;
                        }
                        if (property0.NameEquals("categories"))
                        {
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
                            }
                            categories = array;
                            continue;
                        }
                        if (property0.NameEquals("retentionPolicy"))
                        {
                            retentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new LogProfileData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, storageAccountId.Value, serviceBusRuleId.Value, locations, categories, retentionPolicy);
        }
    }
}
