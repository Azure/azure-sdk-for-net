// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class SignedIdentifier : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("AccessPolicy");
            writer.WriteObjectValue(AccessPolicy);
            writer.WriteEndObject();
        }
        internal static SignedIdentifier DeserializeSignedIdentifier(JsonElement element)
        {
            SignedIdentifier result = new SignedIdentifier();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("Id"))
                {
                    result.Id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("AccessPolicy"))
                {
                    result.AccessPolicy = AccessPolicy.DeserializeAccessPolicy(property.Value);
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "SignedIdentifier");
            writer.WriteStartElement("Id");
            writer.WriteValue(Id);
            writer.WriteEndElement();
            writer.WriteObjectValue(AccessPolicy, "AccessPolicy");
            writer.WriteEndElement();
        }
        internal static SignedIdentifier DeserializeSignedIdentifier(XElement element)
        {
            SignedIdentifier result = default;
            result = new SignedIdentifier(); string value = default;
            var id = element.Element("Id");
            if (id != null)
            {
                value = (string)id;
            }
            result.Id = value;
            AccessPolicy value0 = default;
            var accessPolicy = element.Element("AccessPolicy");
            if (accessPolicy != null)
            {
                value0 = AccessPolicy.DeserializeAccessPolicy(accessPolicy);
            }
            result.AccessPolicy = value0;
            return result;
        }
    }
}
