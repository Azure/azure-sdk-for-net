// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    internal partial class FormFieldsReport_internal : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("fieldName");
            writer.WriteStringValue(FieldName);
            writer.WritePropertyName("accuracy");
            writer.WriteNumberValue(Accuracy);
            writer.WriteEndObject();
        }
        internal static FormFieldsReport_internal DeserializeFormFieldsReport_internal(JsonElement element)
        {
            FormFieldsReport_internal result = new FormFieldsReport_internal();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("fieldName"))
                {
                    result.FieldName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("accuracy"))
                {
                    result.Accuracy = property.Value.GetSingle();
                    continue;
                }
            }
            return result;
        }
    }
}
