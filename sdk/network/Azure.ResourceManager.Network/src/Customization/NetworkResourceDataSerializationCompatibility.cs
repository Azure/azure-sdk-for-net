// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ClientModel.Primitives;
using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Network
{
    internal static class NetworkResourceDataSerializationCompatibility
    {
        internal static ResourceIdentifier GetId(IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            string id = GetString(additionalBinaryDataProperties, "id");
            return id is null ? null : new ResourceIdentifier(id);
        }

        internal static string GetName(IDictionary<string, BinaryData> additionalBinaryDataProperties)
            => GetString(additionalBinaryDataProperties, "name");

        internal static ResourceType GetResourceType(IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            string type = GetString(additionalBinaryDataProperties, "type");
            return type is null ? default : new ResourceType(type);
        }

        internal static SystemData GetSystemData(IDictionary<string, BinaryData> additionalBinaryDataProperties)
            => TryGetValue(additionalBinaryDataProperties, "systemData", out BinaryData systemData)
                ? ModelReaderWriter.Read<SystemData>(systemData, ModelSerializationExtensions.WireOptions, AzureResourceManagerNetworkContext.Default)
                : null;

        internal static IDictionary<string, string> GetTags(IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            if (!TryGetValue(additionalBinaryDataProperties, "tags", out BinaryData tags))
            {
                return new ChangeTrackingDictionary<string, string>();
            }

            var result = new ChangeTrackingDictionary<string, string>();
            using JsonDocument document = JsonDocument.Parse(tags);
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                return result;
            }

            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                result.Add(property.Name, property.Value.ValueKind == JsonValueKind.Null ? null : property.Value.GetString());
            }
            return result;
        }

        internal static AzureLocation GetLocation(IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            string location = GetString(additionalBinaryDataProperties, "location");
            return location is null ? default : new AzureLocation(location);
        }

        internal static bool IsFrameworkResourceDataProperty(string propertyName)
            => propertyName is "id" or "name" or "type" or "systemData" or "tags" or "location";

        internal static IDictionary<string, BinaryData> CreateAdditionalData(JsonElement element, ModelReaderWriterOptions options, Func<JsonProperty, bool> handleProperty)
        {
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty prop in element.EnumerateObject())
            {
                if (IsFrameworkResourceDataProperty(prop.Name))
                {
                    additionalBinaryDataProperties[prop.Name] = BinaryData.FromString(prop.Value.GetRawText());
                    continue;
                }
                if (handleProperty(prop))
                {
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return additionalBinaryDataProperties;
        }

        private static string GetString(IDictionary<string, BinaryData> additionalBinaryDataProperties, string propertyName)
        {
            if (!TryGetValue(additionalBinaryDataProperties, propertyName, out BinaryData value))
            {
                return null;
            }

            using JsonDocument document = JsonDocument.Parse(value);
            return document.RootElement.ValueKind == JsonValueKind.Null ? null : document.RootElement.GetString();
        }

        private static bool TryGetValue(IDictionary<string, BinaryData> additionalBinaryDataProperties, string propertyName, out BinaryData value)
        {
            if (additionalBinaryDataProperties is null)
            {
                value = null;
                return false;
            }

            return additionalBinaryDataProperties.TryGetValue(propertyName, out value);
        }
    }
}
