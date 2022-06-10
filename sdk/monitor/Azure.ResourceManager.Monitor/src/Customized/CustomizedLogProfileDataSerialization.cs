// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    public partial class LogProfileData
    {
        internal static LogProfileData DeserializeLogProfileData(JsonElement element)
        {
            IDictionary<string, string> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Azure.ResourceManager.Models.SystemData systemData = default;
            Optional<string> storageAccountId = default;
            Optional<string> serviceBusRuleId = default;
            IList<string> locations = default;
            IList<string> categories = default;
            RetentionPolicy retentionPolicy = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        Dictionary<string, string> dictionary = new Dictionary<string, string>();
                        foreach (var property0 in property.Value.EnumerateObject())
                        {
                            dictionary.Add(property0.Name, property0.Value.GetString());
                        }
                        tags = dictionary;
                    }
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        location = property.Value.GetString();
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
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        type = property.Value.GetString();
                    }
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    systemData = JsonSerializer.Deserialize<Azure.ResourceManager.Models.SystemData>(property.Value.ToString());
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
                            storageAccountId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("serviceBusRuleId"))
                        {
                            serviceBusRuleId = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("locations"))
                        {
                            List<string> array = new List<string>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(item.GetString());
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
            return new LogProfileData(id, name, type, systemData, tags, location, storageAccountId.Value, serviceBusRuleId.Value, locations, categories, retentionPolicy);
        }
    }
}
