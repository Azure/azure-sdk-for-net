// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class CorsRule : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("AllowedOrigins");
            writer.WriteStringValue(AllowedOrigins);
            writer.WritePropertyName("AllowedMethods");
            writer.WriteStringValue(AllowedMethods);
            writer.WritePropertyName("AllowedHeaders");
            writer.WriteStringValue(AllowedHeaders);
            writer.WritePropertyName("ExposedHeaders");
            writer.WriteStringValue(ExposedHeaders);
            writer.WritePropertyName("MaxAgeInSeconds");
            writer.WriteNumberValue(MaxAgeInSeconds);
            writer.WriteEndObject();
        }
        internal static CorsRule DeserializeCorsRule(JsonElement element)
        {
            CorsRule result = new CorsRule();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("AllowedOrigins"))
                {
                    result.AllowedOrigins = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("AllowedMethods"))
                {
                    result.AllowedMethods = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("AllowedHeaders"))
                {
                    result.AllowedHeaders = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("ExposedHeaders"))
                {
                    result.ExposedHeaders = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("MaxAgeInSeconds"))
                {
                    result.MaxAgeInSeconds = property.Value.GetInt32();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "CorsRule");
            writer.WriteStartElement("AllowedOrigins");
            writer.WriteValue(AllowedOrigins);
            writer.WriteEndElement();
            writer.WriteStartElement("AllowedMethods");
            writer.WriteValue(AllowedMethods);
            writer.WriteEndElement();
            writer.WriteStartElement("AllowedHeaders");
            writer.WriteValue(AllowedHeaders);
            writer.WriteEndElement();
            writer.WriteStartElement("ExposedHeaders");
            writer.WriteValue(ExposedHeaders);
            writer.WriteEndElement();
            writer.WriteStartElement("MaxAgeInSeconds");
            writer.WriteValue(MaxAgeInSeconds);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        internal static CorsRule DeserializeCorsRule(XElement element)
        {
            CorsRule result = default;
            result = new CorsRule(); string value = default;
            var allowedOrigins = element.Element("AllowedOrigins");
            if (allowedOrigins != null)
            {
                value = (string)allowedOrigins;
            }
            result.AllowedOrigins = value;
            string value0 = default;
            var allowedMethods = element.Element("AllowedMethods");
            if (allowedMethods != null)
            {
                value0 = (string)allowedMethods;
            }
            result.AllowedMethods = value0;
            string value1 = default;
            var allowedHeaders = element.Element("AllowedHeaders");
            if (allowedHeaders != null)
            {
                value1 = (string)allowedHeaders;
            }
            result.AllowedHeaders = value1;
            string value2 = default;
            var exposedHeaders = element.Element("ExposedHeaders");
            if (exposedHeaders != null)
            {
                value2 = (string)exposedHeaders;
            }
            result.ExposedHeaders = value2;
            int value3 = default;
            var maxAgeInSeconds = element.Element("MaxAgeInSeconds");
            if (maxAgeInSeconds != null)
            {
                value3 = (int)maxAgeInSeconds;
            }
            result.MaxAgeInSeconds = value3;
            return result;
        }
    }
}
