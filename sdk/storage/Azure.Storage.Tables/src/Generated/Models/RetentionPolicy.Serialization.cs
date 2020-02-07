// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class RetentionPolicy : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Enabled");
            writer.WriteBooleanValue(Enabled);
            if (Days != null)
            {
                writer.WritePropertyName("Days");
                writer.WriteNumberValue(Days.Value);
            }
            writer.WriteEndObject();
        }
        internal static RetentionPolicy DeserializeRetentionPolicy(JsonElement element)
        {
            RetentionPolicy result = new RetentionPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Enabled"))
                {
                    result.Enabled = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("Days"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Days = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "RetentionPolicy");
            writer.WriteStartElement("Enabled");
            writer.WriteValue(Enabled);
            writer.WriteEndElement();
            if (Days != null)
            {
                writer.WriteStartElement("Days");
                writer.WriteValue(Days.Value);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static RetentionPolicy DeserializeRetentionPolicy(XElement element)
        {
            RetentionPolicy result = default;
            result = new RetentionPolicy(); bool value = default;
            var enabled = element.Element("Enabled");
            if (enabled != null)
            {
                value = (bool)enabled;
            }
            result.Enabled = value;
            int? value0 = default;
            var days = element.Element("Days");
            if (days != null)
            {
                value0 = (int?)days;
            }
            result.Days = value0;
            return result;
        }
    }
}
