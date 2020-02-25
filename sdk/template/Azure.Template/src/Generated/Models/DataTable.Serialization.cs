// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class DataTable : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("rows");
            writer.WriteNumberValue(Rows);
            writer.WritePropertyName("columns");
            writer.WriteNumberValue(Columns);
            writer.WritePropertyName("cells");
            writer.WriteStartArray();
            foreach (var item in Cells)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static DataTable DeserializeDataTable(JsonElement element)
        {
            DataTable result = new DataTable();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rows"))
                {
                    result.Rows = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columns"))
                {
                    result.Columns = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("cells"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Cells.Add(DataTableCell.DeserializeDataTableCell(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
