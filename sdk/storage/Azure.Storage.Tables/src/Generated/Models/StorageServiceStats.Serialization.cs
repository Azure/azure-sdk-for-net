// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageServiceStats : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (GeoReplication != null)
            {
                writer.WritePropertyName("GeoReplication");
                writer.WriteObjectValue(GeoReplication);
            }
            writer.WriteEndObject();
        }
        internal static StorageServiceStats DeserializeStorageServiceStats(JsonElement element)
        {
            StorageServiceStats result = new StorageServiceStats();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("GeoReplication"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.GeoReplication = GeoReplication.DeserializeGeoReplication(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "StorageServiceStats");
            if (GeoReplication != null)
            {
                writer.WriteObjectValue(GeoReplication, "GeoReplication");
            }
            writer.WriteEndElement();
        }
        internal static StorageServiceStats DeserializeStorageServiceStats(XElement element)
        {
            StorageServiceStats result = default;
            result = new StorageServiceStats(); GeoReplication value = default;
            var geoReplication = element.Element("GeoReplication");
            if (geoReplication != null)
            {
                value = GeoReplication.DeserializeGeoReplication(geoReplication);
            }
            result.GeoReplication = value;
            return result;
        }
    }
}
