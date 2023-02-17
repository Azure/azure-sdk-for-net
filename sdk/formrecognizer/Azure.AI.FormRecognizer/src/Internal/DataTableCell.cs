// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenModel("DataTableCell")]
    internal partial class DataTableCell
    {
        // We're ovewriting the generated deserialization method to fix two service behaviors:
        // 1. The 'elements' JSON property is sometimes returned as 'null', which makes the generated
        //    code throw in debug mode.
        // 2. The 'confidence' property sometimes is not returned, which makes it default to '0'.
        //    The overwritten method uses our 'DefaultConfidenceValue'.
        //
        // There's no intent to change these behaviors on the service side so we must keep this workaround.

        internal static DataTableCell DeserializeDataTableCell(JsonElement element)
        {
            int rowIndex = default;
            int columnIndex = default;
            int? rowSpan = default;
            int? columnSpan = default;
            string text = default;
            IReadOnlyList<float> boundingBox = default;
            float confidence = Constants.DefaultConfidenceValue;
            IReadOnlyList<string> elements = default;
            bool? isHeader = default;
            bool? isFooter = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("rowIndex"))
                {
                    rowIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columnIndex"))
                {
                    columnIndex = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("rowSpan"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    rowSpan = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("columnSpan"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    columnSpan = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("boundingBox"))
                {
                    List<float> array = new List<float>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetSingle());
                    }
                    boundingBox = array;
                    continue;
                }
                if (property.NameEquals("confidence"))
                {
                    confidence = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("elements"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(item.GetString());
                        }
                    }
                    elements = array;
                    continue;
                }
                if (property.NameEquals("isHeader"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isHeader = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("isFooter"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isFooter = property.Value.GetBoolean();
                    continue;
                }
            }
            return new DataTableCell(rowIndex, columnIndex, rowSpan, columnSpan, text, boundingBox, confidence, elements, isHeader, isFooter);
        }
    }
}
