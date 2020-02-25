// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Template.Models
{
    public partial class AnalyzeOperationResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("status");
            writer.WriteStringValue(Status.ToSerialString());
            writer.WritePropertyName("createdDateTime");
            writer.WriteStringValue(CreatedDateTime, "S");
            writer.WritePropertyName("lastUpdatedDateTime");
            writer.WriteStringValue(LastUpdatedDateTime, "S");
            if (AnalyzeResult != null)
            {
                writer.WritePropertyName("analyzeResult");
                writer.WriteObjectValue(AnalyzeResult);
            }
            writer.WriteEndObject();
        }
        internal static AnalyzeOperationResult DeserializeAnalyzeOperationResult(JsonElement element)
        {
            AnalyzeOperationResult result = new AnalyzeOperationResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("status"))
                {
                    result.Status = property.Value.GetString().ToOperationStatus();
                    continue;
                }
                if (property.NameEquals("createdDateTime"))
                {
                    result.CreatedDateTime = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("lastUpdatedDateTime"))
                {
                    result.LastUpdatedDateTime = property.Value.GetDateTimeOffset("S");
                    continue;
                }
                if (property.NameEquals("analyzeResult"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.AnalyzeResult = AnalyzeResult.DeserializeAnalyzeResult(property.Value);
                    continue;
                }
            }
            return result;
        }
    }
}
