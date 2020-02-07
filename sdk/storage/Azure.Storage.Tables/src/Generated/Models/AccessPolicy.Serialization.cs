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
    public partial class AccessPolicy : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Start");
            writer.WriteStringValue(Start, "S");
            writer.WritePropertyName("Expiry");
            writer.WriteStringValue(Expiry, "S");
            writer.WritePropertyName("Permission");
            writer.WriteStringValue(Permission);
            writer.WriteEndObject();
        }
        internal static AccessPolicy DeserializeAccessPolicy(JsonElement element)
        {
            AccessPolicy result = new AccessPolicy();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Start"))
                {
                    result.Start = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("Expiry"))
                {
                    result.Expiry = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("Permission"))
                {
                    result.Permission = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "AccessPolicy");
            writer.WriteStartElement("Start");
            writer.WriteValue(Start, "S");
            writer.WriteEndElement();
            writer.WriteStartElement("Expiry");
            writer.WriteValue(Expiry, "S");
            writer.WriteEndElement();
            writer.WriteStartElement("Permission");
            writer.WriteValue(Permission);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        internal static AccessPolicy DeserializeAccessPolicy(XElement element)
        {
            AccessPolicy result = default;
            result = new AccessPolicy(); DateTimeOffset value = default;
            var start = element.Element("Start");
            if (start != null)
            {
                value = start.GetDateTimeOffsetValue("S");
            }
            result.Start = value;
            DateTimeOffset value0 = default;
            var expiry = element.Element("Expiry");
            if (expiry != null)
            {
                value0 = expiry.GetDateTimeOffsetValue("S");
            }
            result.Expiry = value0;
            string value1 = default;
            var permission = element.Element("Permission");
            if (permission != null)
            {
                value1 = (string)permission;
            }
            result.Permission = value1;
            return result;
        }
    }
}
