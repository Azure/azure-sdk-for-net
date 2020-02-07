// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class Metrics : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Version != null)
            {
                writer.WritePropertyName("Version");
                writer.WriteStringValue(Version);
            }
            writer.WritePropertyName("Enabled");
            writer.WriteBooleanValue(Enabled);
            if (IncludeAPIs != null)
            {
                writer.WritePropertyName("IncludeAPIs");
                writer.WriteBooleanValue(IncludeAPIs.Value);
            }
            if (RetentionPolicy != null)
            {
                writer.WritePropertyName("RetentionPolicy");
                writer.WriteObjectValue(RetentionPolicy);
            }
            writer.WriteEndObject();
        }
        internal static Metrics DeserializeMetrics(JsonElement element)
        {
            Metrics result = new Metrics();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Version"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("Enabled"))
                {
                    result.Enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("IncludeAPIs"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.IncludeAPIs = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("RetentionPolicy"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.RetentionPolicy = RetentionPolicy.DeserializeRetentionPolicy(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "Metrics");
            if (Version != null)
            {
                writer.WriteStartElement("Version");
                writer.WriteValue(Version);
                writer.WriteEndElement();
            }
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (IncludeAPIs != null)
            {
                writer.WriteStartElement("IncludeAPIs");
                writer.WriteValue(IncludeAPIs.Value);
                writer.WriteEndElement();
            }
            if (RetentionPolicy != null)
            {
                writer.WriteObjectValue(RetentionPolicy, "RetentionPolicy");
            }
            writer.WriteEndElement();
        }
        internal static Metrics DeserializeMetrics(XElement element)
        {
            Metrics result = default;
            result = new Metrics(); string value = default;
            var version = element.Element("Version");
            if (version != null)
            {
                value = (string)version;
            }
            result.Version = value;
            bool value0 = default;
            var enabled = element.Element("Enabled");
            if (enabled != null)
            {
                value0 = (bool)enabled;
            }
            result.Enabled = value0;
            bool? value1 = default;
            var includeAPIs = element.Element("IncludeAPIs");
            if (includeAPIs != null)
            {
                value1 = (bool?)includeAPIs;
            }
            result.IncludeAPIs = value1;
            RetentionPolicy value2 = default;
            var retentionPolicy = element.Element("RetentionPolicy");
            if (retentionPolicy != null)
            {
                value2 = RetentionPolicy.DeserializeRetentionPolicy(retentionPolicy);
            }
            result.RetentionPolicy = value2;
            return result;
        }
    }
}
