// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("MaintenanceConfigurationData")]

namespace Azure.ResourceManager.Maintenance
{
    public partial class MaintenanceConfigurationData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartObject();
                foreach (var item in Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(Namespace))
            {
                writer.WritePropertyName("namespace"u8);
                writer.WriteStringValue(Namespace);
            }
            if (Optional.IsCollectionDefined(ExtensionProperties))
            {
                writer.WritePropertyName("extensionProperties"u8);
                writer.WriteStartObject();
                foreach (var item in ExtensionProperties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(MaintenanceScope))
            {
                writer.WritePropertyName("maintenanceScope"u8);
                writer.WriteStringValue(MaintenanceScope.Value.ToString());
            }
            if (Optional.IsDefined(Visibility))
            {
                writer.WritePropertyName("visibility"u8);
                writer.WriteStringValue(Visibility.Value.ToString());
            }
            writer.WritePropertyName("maintenanceWindow"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(StartOn))
            {
                writer.WritePropertyName("startDateTime"u8);
                writer.WriteStringValue(StartOn.Value, "yyyy-MM-dd hh:mm");
            }
            if (Optional.IsDefined(ExpireOn))
            {
                writer.WritePropertyName("expirationDateTime"u8);
                writer.WriteStringValue(ExpireOn.Value, "yyyy-MM-dd hh:mm");
            }
            if (Optional.IsDefined(Duration))
            {
                writer.WritePropertyName("duration"u8);
                writer.WriteStringValue(Duration.Value, "c");
            }
            if (Optional.IsDefined(TimeZone))
            {
                writer.WritePropertyName("timeZone"u8);
                writer.WriteStringValue(TimeZone);
            }
            if (Optional.IsDefined(RecurEvery))
            {
                writer.WritePropertyName("recurEvery"u8);
                writer.WriteStringValue(RecurEvery);
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static MaintenanceConfigurationData DeserializeMaintenanceConfigurationData(JsonElement element)
        {
            Optional<IDictionary<string, string>> tags = default;
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<string> @namespace = default;
            Optional<IDictionary<string, string>> extensionProperties = default;
            Optional<MaintenanceScope> maintenanceScope = default;
            Optional<MaintenanceConfigurationVisibility> visibility = default;
            Optional<DateTimeOffset> startDateTime = default;
            Optional<DateTimeOffset> expirationDateTime = default;
            Optional<TimeSpan> duration = default;
            Optional<string> timeZone = default;
            Optional<string> recurEvery = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
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
                if (property.NameEquals("location"u8))
                {
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
                        property.ThrowNonNullablePropertyIsNull();
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
                        if (property0.NameEquals("namespace"u8))
                        {
                            @namespace = property0.Value.GetString();
                            continue;
                        }
                        if (property0.NameEquals("extensionProperties"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            Dictionary<string, string> dictionary = new Dictionary<string, string>();
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                dictionary.Add(property1.Name, property1.Value.GetString());
                            }
                            extensionProperties = dictionary;
                            continue;
                        }
                        if (property0.NameEquals("maintenanceScope"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            maintenanceScope = new MaintenanceScope(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("visibility"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            visibility = new MaintenanceConfigurationVisibility(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("maintenanceWindow"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                property0.ThrowNonNullablePropertyIsNull();
                                continue;
                            }
                            foreach (var property1 in property0.Value.EnumerateObject())
                            {
                                if (property1.NameEquals("startDateTime"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        property1.ThrowNonNullablePropertyIsNull();
                                        continue;
                                    }
                                    startDateTime = property1.Value.GetDateTimeOffset("O");
                                    continue;
                                }
                                if (property1.NameEquals("expirationDateTime"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        property1.ThrowNonNullablePropertyIsNull();
                                        continue;
                                    }
                                    expirationDateTime = property1.Value.GetDateTimeOffset("O");
                                    continue;
                                }
                                if (property1.NameEquals("duration"u8))
                                {
                                    if (property1.Value.ValueKind == JsonValueKind.Null)
                                    {
                                        property1.ThrowNonNullablePropertyIsNull();
                                        continue;
                                    }
                                    duration = property1.Value.GetTimeSpan("c");
                                    continue;
                                }
                                if (property1.NameEquals("timeZone"u8))
                                {
                                    timeZone = property1.Value.GetString();
                                    continue;
                                }
                                if (property1.NameEquals("recurEvery"u8))
                                {
                                    recurEvery = property1.Value.GetString();
                                    continue;
                                }
                            }
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new MaintenanceConfigurationData(id, name, type, systemData.Value, Optional.ToDictionary(tags), location, @namespace.Value, Optional.ToDictionary(extensionProperties), Optional.ToNullable(maintenanceScope), Optional.ToNullable(visibility), Optional.ToNullable(startDateTime), Optional.ToNullable(expirationDateTime), Optional.ToNullable(duration), timeZone.Value, recurEvery.Value);
        }
    }
}
