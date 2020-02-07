// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class StorageServiceProperties : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Logging != null)
            {
                writer.WritePropertyName("Logging");
                writer.WriteObjectValue(Logging);
            }
            if (HourMetrics != null)
            {
                writer.WritePropertyName("HourMetrics");
                writer.WriteObjectValue(HourMetrics);
            }
            if (MinuteMetrics != null)
            {
                writer.WritePropertyName("MinuteMetrics");
                writer.WriteObjectValue(MinuteMetrics);
            }
            if (Cors != null)
            {
                writer.WritePropertyName("Cors");
                writer.WriteStartArray();
                foreach (var item in Cors)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static StorageServiceProperties DeserializeStorageServiceProperties(JsonElement element)
        {
            StorageServiceProperties result = new StorageServiceProperties();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Logging"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Logging = Logging.DeserializeLogging(property.Value);
                    continue;
                }
                if (property.NameEquals("HourMetrics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.HourMetrics = Metrics.DeserializeMetrics(property.Value);
                    continue;
                }
                if (property.NameEquals("MinuteMetrics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.MinuteMetrics = Metrics.DeserializeMetrics(property.Value);
                    continue;
                }
                if (property.NameEquals("Cors"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Cors = new List<CorsRule>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Cors.Add(CorsRule.DeserializeCorsRule(item));
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "StorageServiceProperties");
            if (Logging != null)
            {
                writer.WriteObjectValue(Logging, "Logging");
            }
            if (HourMetrics != null)
            {
                writer.WriteObjectValue(HourMetrics, "HourMetrics");
            }
            if (MinuteMetrics != null)
            {
                writer.WriteObjectValue(MinuteMetrics, "MinuteMetrics");
            }
            if (Cors != null)
            {
                writer.WriteStartElement("Cors");
                foreach (var item in Cors)
                {
                    writer.WriteObjectValue(item, "CorsRule");
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static StorageServiceProperties DeserializeStorageServiceProperties(XElement element)
        {
            StorageServiceProperties result = default;
            result = new StorageServiceProperties(); Logging value = default;
            var logging = element.Element("Logging");
            if (logging != null)
            {
                value = Logging.DeserializeLogging(logging);
            }
            result.Logging = value;
            Metrics value0 = default;
            var hourMetrics = element.Element("HourMetrics");
            if (hourMetrics != null)
            {
                value0 = Metrics.DeserializeMetrics(hourMetrics);
            }
            result.HourMetrics = value0;
            Metrics value1 = default;
            var minuteMetrics = element.Element("MinuteMetrics");
            if (minuteMetrics != null)
            {
                value1 = Metrics.DeserializeMetrics(minuteMetrics);
            }
            result.MinuteMetrics = value1;
            var cors = element.Element("Cors");
            if (cors != null)
            {
                result.Cors = new List<CorsRule>();
                foreach (var e in cors.Elements("CorsRule"))
                {
                    CorsRule value2 = default;
                    value2 = CorsRule.DeserializeCorsRule(e);
                    result.Cors.Add(value2);
                }
            }
            return result;
        }
    }
}
