// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class TableResponseProperties : IUtf8JsonSerializable, IXmlSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
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
        internal static TableResponseProperties DeserializeTableResponseProperties(JsonElement element)
        {
            TableResponseProperties result = new TableResponseProperties();
            foreach (var property in element.EnumerateObject())
            {
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
            writer.WriteStartElement(nameHint ?? "TableResponseProperties");
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
        internal static TableResponseProperties DeserializeTableResponseProperties(XElement element)
        {
            TableResponseProperties result = default;
            result = new TableResponseProperties(); string value = default;
            var tableName = element.Element("TableName");
            if (tableName != null)
            {
                value = (string)tableName;
            }
            result.TableName = value;
            string value0 = default;
            var odatatype = element.Element("odata.type");
            if (odatatype != null)
            {
                value0 = (string)odatatype;
            }
            result.OdataType = value0;
            string value1 = default;
            var odataid = element.Element("odata.id");
            if (odataid != null)
            {
                value1 = (string)odataid;
            }
            result.OdataId = value1;
            string value2 = default;
            var odataeditLink = element.Element("odata.editLink");
            if (odataeditLink != null)
            {
                value2 = (string)odataeditLink;
            }
            result.OdataEditLink = value2;
            return result;
        }
    }
}
