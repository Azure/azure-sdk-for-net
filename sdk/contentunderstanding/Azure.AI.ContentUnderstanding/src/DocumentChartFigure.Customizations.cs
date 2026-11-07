// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    // SERVICE-FIX: Suppress DeserializeDocumentChartFigure to accept chart content that the service returns as an escaped JSON string instead of an object (https://github.com/Azure/azure-sdk-for-net/issues/57370)
    [CodeGenSuppress("DeserializeDocumentChartFigure", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class DocumentChartFigure
    {
        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static DocumentChartFigure DeserializeDocumentChartFigure(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            DocumentFigureKind kind = default;
            string id = default;
            string source = default;
            ContentSpan span = default;
            IList<string> elements = default;
            DocumentCaption caption = default;
            IList<DocumentFootnote> footnotes = default;
            string description = default;
            SemanticRole? role = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            IDictionary<string, BinaryData> content = default;
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("kind"u8))
                {
                    kind = new DocumentFigureKind(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("id"u8))
                {
                    id = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("source"u8))
                {
                    source = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("span"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    span = ContentSpan.DeserializeContentSpan(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("elements"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in prop.Value.EnumerateArray())
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
                if (prop.NameEquals("caption"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    caption = DocumentCaption.DeserializeDocumentCaption(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("footnotes"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<DocumentFootnote> array = new List<DocumentFootnote>();
                    foreach (var item in prop.Value.EnumerateArray())
                    {
                        array.Add(DocumentFootnote.DeserializeDocumentFootnote(item, options));
                    }
                    footnotes = array;
                    continue;
                }
                if (prop.NameEquals("description"u8))
                {
                    description = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("role"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    role = new SemanticRole(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("content"u8))
                {
                    // SERVICE-FIX: Accept the Chart.js config both as an object (TypeSpec definition) and as an escaped JSON string (some service responses)
                    using JsonDocument stringContent = prop.Value.ValueKind == JsonValueKind.String ? JsonDocument.Parse(prop.Value.GetString(), ModelSerializationExtensions.JsonDocumentOptions) : null;
                    JsonElement contentElement = stringContent?.RootElement ?? prop.Value;
                    Dictionary<string, BinaryData> dictionary = new Dictionary<string, BinaryData>();
                    foreach (var prop0 in contentElement.EnumerateObject())
                    {
                        if (prop0.Value.ValueKind == JsonValueKind.Null)
                        {
                            dictionary.Add(prop0.Name, null);
                        }
                        else
                        {
                            dictionary.Add(prop0.Name, prop0.Value.GetUtf8Bytes());
                        }
                    }
                    content = dictionary;
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, prop.Value.GetUtf8Bytes());
                }
            }
            return new DocumentChartFigure(
                kind,
                id,
                source,
                span,
                elements ?? new ChangeTrackingList<string>(),
                caption,
                footnotes ?? new ChangeTrackingList<DocumentFootnote>(),
                description,
                role,
                additionalBinaryDataProperties,
                content ?? new ChangeTrackingDictionary<string, BinaryData>());
        }
    }
}
