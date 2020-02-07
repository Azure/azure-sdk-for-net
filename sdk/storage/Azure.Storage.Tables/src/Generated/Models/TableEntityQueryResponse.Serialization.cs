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
    public partial class TableEntityQueryResponse : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (OdataMetadata != null)
            {
                writer.WritePropertyName("odata.metadata");
                writer.WriteStringValue(OdataMetadata);
            }
            if (Value != null)
            {
                writer.WritePropertyName("value");
                writer.WriteStartArray();
                foreach (var item in Value)
                {
                    writer.WriteStartObject();
                    foreach (var item0 in item)
                    {
                        writer.WritePropertyName(item0.Key);
                        writer.WriteObjectValue(item0.Value);
                    }
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static TableEntityQueryResponse DeserializeTableEntityQueryResponse(JsonElement element)
        {
            TableEntityQueryResponse result = new TableEntityQueryResponse();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("odata.metadata"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OdataMetadata = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Value = new List<IDictionary<string, object>>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        IDictionary<string, object> value = new Dictionary<string, object>();
                        foreach (var property0 in item.EnumerateObject())
                        {
                            value.Add(property0.Name, property0.Value.GetObject());
                        }
                        result.Value.Add(value);
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "TableEntityQueryResponse");
            if (OdataMetadata != null)
            {
                writer.WriteStartElement("odata.metadata");
                writer.WriteValue(OdataMetadata);
                writer.WriteEndElement();
            }
            if (Value != null)
            {
                foreach (var item in Value)
                {
                    foreach (var pair in item)
                    {
                        writer.WriteObjectValue(pair.Value, "!dictionary-item");
                    }
                }
            }
            writer.WriteEndElement();
        }
        internal static TableEntityQueryResponse DeserializeTableEntityQueryResponse(XElement element)
        {
            TableEntityQueryResponse result = default;
            result = new TableEntityQueryResponse(); string value = default;
            var odatametadata = element.Element("odata.metadata");
            if (odatametadata != null)
            {
                value = (string)odatametadata;
            }
            result.OdataMetadata = value;
            result.Value = new System.Collections.Generic.List<System.Collections.Generic.IDictionary<string, object>>();
            foreach (var e in element.Elements("TableEntityProperties"))
            {
                System.Collections.Generic.IDictionary<string, object> value0 = default;
                value0 = new System.Collections.Generic.Dictionary<string, object>(); var elements = e.Elements();
                foreach (var e0 in elements)
                {
                    object value1 = default;
                    value1 = e0.(null);
                    value0.Add(e0.Name.LocalName, value1);
                }
                result.Value.Add(value0);
            }
            return result;
        }
    }
}
