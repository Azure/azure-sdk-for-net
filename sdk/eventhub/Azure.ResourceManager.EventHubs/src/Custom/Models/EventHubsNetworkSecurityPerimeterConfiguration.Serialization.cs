// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.EventHubs.Models
{
    public partial class EventHubsNetworkSecurityPerimeterConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("location"u8);
            writer.WriteStringValue(Location);
            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Optional.IsDefined(ProvisioningState))
            {
                writer.WritePropertyName("provisioningState"u8);
                writer.WriteStringValue(ProvisioningState.Value.ToString());
            }
            if (Optional.IsCollectionDefined(ProvisioningIssues))
            {
                writer.WritePropertyName("provisioningIssues"u8);
                writer.WriteStartArray();
                foreach (var item in ProvisioningIssues)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        internal static EventHubsNetworkSecurityPerimeterConfiguration DeserializeEventHubsNetworkSecurityPerimeterConfiguration(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            AzureLocation location = default;
            ResourceIdentifier id = default;
            string name = default;
            ResourceType type = default;
            Optional<ResourceManager.Models.SystemData> systemData = default;
            Optional<EventHubsNetworkSecurityPerimeterConfigurationProvisioningState> provisioningState = default;
            Optional<IList<EventHubsProvisioningIssue>> provisioningIssues = default;
            Optional<EventHubsNetworkSecurityPerimeter> networkSecurityPerimeter = default;
            Optional<EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation> resourceAssociation = default;
            Optional<EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile> profile = default;
            foreach (var property in element.EnumerateObject())
            {
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
                        if (property0.NameEquals("provisioningState"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            provisioningState = new EventHubsNetworkSecurityPerimeterConfigurationProvisioningState(property0.Value.GetString());
                            continue;
                        }
                        if (property0.NameEquals("provisioningIssues"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            List<EventHubsProvisioningIssue> array = new List<EventHubsProvisioningIssue>();
                            foreach (var item in property0.Value.EnumerateArray())
                            {
                                array.Add(EventHubsProvisioningIssue.DeserializeEventHubsProvisioningIssue(item));
                            }
                            provisioningIssues = array;
                            continue;
                        }
                        if (property0.NameEquals("networkSecurityPerimeter"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            networkSecurityPerimeter = EventHubsNetworkSecurityPerimeter.DeserializeEventHubsNetworkSecurityPerimeter(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("resourceAssociation"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            resourceAssociation = EventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation.DeserializeEventHubsNetworkSecurityPerimeterConfigurationPropertiesResourceAssociation(property0.Value);
                            continue;
                        }
                        if (property0.NameEquals("profile"u8))
                        {
                            if (property0.Value.ValueKind == JsonValueKind.Null)
                            {
                                continue;
                            }
                            profile = EventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile.DeserializeEventHubsNetworkSecurityPerimeterConfigurationPropertiesProfile(property0.Value);
                            continue;
                        }
                    }
                    continue;
                }
            }
            return new EventHubsNetworkSecurityPerimeterConfiguration(id, name, type, systemData.Value, location, Optional.ToNullable(provisioningState), Optional.ToList(provisioningIssues), networkSecurityPerimeter.Value, resourceAssociation.Value, profile.Value);
        }
    }
}
