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
    public partial class TableQueryResponse : IUtf8JsonSerializable, IXmlSerializable
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
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static TableQueryResponse DeserializeTableQueryResponse(JsonElement element)
        {
            TableQueryResponse result = new TableQueryResponse();
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
                    result.Value = new List<TableResponseProperties>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Value.Add(TableResponseProperties.DeserializeTableResponseProperties(item));
                    }
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "TableQueryResponse");
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
                    writer.WriteObjectValue(item, "TableResponseProperties");
                }
            }
            writer.WriteEndElement();
        }
        internal static TableQueryResponse DeserializeTableQueryResponse(XElement element)
        {
            TableQueryResponse result = default;
            result = new TableQueryResponse(); string value = default;
            var odatametadata = element.Element("odata.metadata");
            if (odatametadata != null)
            {
                value = (string)odatametadata;
            }
            result.OdataMetadata = value;
            result.Value = new System.Collections.Generic.List<Azure.Storage.Tables.Models.TableResponseProperties>();
            foreach (var e in element.Elements("TableResponseProperties"))
            {
                TableResponseProperties value0 = default;
                value0 = TableResponseProperties.DeserializeTableResponseProperties(e);
                result.Value.Add(value0);
            }
            return result;
        }
    }
}
