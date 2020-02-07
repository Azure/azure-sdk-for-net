// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class GeoReplication : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Status");
            writer.WriteStringValue(Status.ToString());
            writer.WritePropertyName("LastSyncTime");
            writer.WriteStringValue(LastSyncTime, "R");
            writer.WriteEndObject();
        }
        internal static GeoReplication DeserializeGeoReplication(JsonElement element)
        {
            GeoReplication result = new GeoReplication();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Status"))
                {
                    result.Status = new GeoReplicationStatusType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("LastSyncTime"))
                {
                    result.LastSyncTime = property.Value.GetDateTimeOffset("R");
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "GeoReplication");
            writer.WriteStartElement("Status");
            writer.WriteValue(Status.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("LastSyncTime");
            writer.WriteValue(LastSyncTime, "R");
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        internal static GeoReplication DeserializeGeoReplication(XElement element)
        {
            GeoReplication result = default;
            result = new GeoReplication(); GeoReplicationStatusType value = default;
            var status = element.Element("Status");
            if (status != null)
            {
                value = new GeoReplicationStatusType(status.Value);
            }
            result.Status = value;
            DateTimeOffset value0 = default;
            var lastSyncTime = element.Element("LastSyncTime");
            if (lastSyncTime != null)
            {
                value0 = lastSyncTime.GetDateTimeOffsetValue("R");
            }
            result.LastSyncTime = value0;
            return result;
        }
    }
}
