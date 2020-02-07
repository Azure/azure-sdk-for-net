// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class TableResponse : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (OdataMetadata != null)
            {
                writer.WritePropertyName("odata.metadata");
                writer.WriteStringValue(OdataMetadata);
            }
            if (TableName != null)
            {
                writer.WritePropertyName("TableName");
                writer.WriteStringValue(TableName);
            }
            if (OdataType != null)
            {
                writer.WritePropertyName("odata.type");
                writer.WriteStringValue(OdataType);
            }
            if (OdataId != null)
            {
                writer.WritePropertyName("odata.id");
                writer.WriteStringValue(OdataId);
            }
            if (OdataEditLink != null)
            {
                writer.WritePropertyName("odata.editLink");
                writer.WriteStringValue(OdataEditLink);
            }
            writer.WriteEndObject();
        }
        internal static TableResponse DeserializeTableResponse(JsonElement element)
        {
            TableResponse result = new TableResponse();
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
                if (property.NameEquals("TableName"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.TableName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.type"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OdataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.id"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OdataId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("odata.editLink"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.OdataEditLink = property.Value.GetString();
                    continue;
                }
            }
            return result;
        }
        void IXmlSerializable.Write(XmlWriter writer, string nameHint)
        {
            writer.WriteStartElement(nameHint ?? "TableResponse");
            if (OdataMetadata != null)
            {
                writer.WriteStartElement("odata.metadata");
                writer.WriteValue(OdataMetadata);
                writer.WriteEndElement();
            }
            if (TableName != null)
            {
                writer.WriteStartElement("TableName");
                writer.WriteValue(TableName);
                writer.WriteEndElement();
            }
            if (OdataType != null)
            {
                writer.WriteStartElement("odata.type");
                writer.WriteValue(OdataType);
                writer.WriteEndElement();
            }
            if (OdataId != null)
            {
                writer.WriteStartElement("odata.id");
                writer.WriteValue(OdataId);
                writer.WriteEndElement();
            }
            if (OdataEditLink != null)
            {
                writer.WriteStartElement("odata.editLink");
                writer.WriteValue(OdataEditLink);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
        internal static TableResponse DeserializeTableResponse(XElement element)
        {
            TableResponse result = default;
            result = new TableResponse(); string value = default;
            var odatametadata = element.Element("odata.metadata");
            if (odatametadata != null)
            {
                value = (string)odatametadata;
            }
            result.OdataMetadata = value;
            string value0 = default;
            var tableName = element.Element("TableName");
            if (tableName != null)
            {
                value0 = (string)tableName;
            }
            result.TableName = value0;
            string value1 = default;
            var odatatype = element.Element("odata.type");
            if (odatatype != null)
            {
                value1 = (string)odatatype;
            }
            result.OdataType = value1;
            string value2 = default;
            var odataid = element.Element("odata.id");
            if (odataid != null)
            {
                value2 = (string)odataid;
            }
            result.OdataId = value2;
            string value3 = default;
            var odataeditLink = element.Element("odata.editLink");
            if (odataeditLink != null)
            {
                value3 = (string)odataeditLink;
            }
            result.OdataEditLink = value3;
            return result;
        }
    }
}
