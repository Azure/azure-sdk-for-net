// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    public partial class AnalyzeResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("version");
            writer.WriteStringValue(Version);
            writer.WritePropertyName("readResults");
            writer.WriteStartArray();
            foreach (var item in ReadResults)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (PageResults != null)
            {
                writer.WritePropertyName("pageResults");
                writer.WriteStartArray();
                foreach (var item0 in PageResults)
                {
                    writer.WriteObjectValue(item0);
                }
                writer.WriteEndArray();
            }
            if (DocumentResults != null)
            {
                writer.WritePropertyName("documentResults");
                writer.WriteStartArray();
                foreach (var item0 in DocumentResults)
                {
                    writer.WriteObjectValue(item0);
                }
                writer.WriteEndArray();
            }
            if (Errors != null)
            {
                writer.WritePropertyName("errors");
                writer.WriteStartArray();
                foreach (var item0 in Errors)
                {
                    writer.WriteObjectValue(item0);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
        internal static AnalyzeResult DeserializeAnalyzeResult(JsonElement element)
        {
            AnalyzeResult result = new AnalyzeResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("version"))
                {
                    result.Version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("readResults"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.ReadResults.Add(ReadResult.DeserializeReadResult(item));
                    }
                    continue;
                }
                if (property.NameEquals("pageResults"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.PageResults = new List<PageResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.PageResults.Add(PageResult.DeserializePageResult(item));
                    }
                    continue;
                }
                if (property.NameEquals("documentResults"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.DocumentResults = new List<DocumentResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.DocumentResults.Add(DocumentResult.DeserializeDocumentResult(item));
                    }
                    continue;
                }
                if (property.NameEquals("errors"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Errors = new List<ErrorInformation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Errors.Add(ErrorInformation.DeserializeErrorInformation(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
