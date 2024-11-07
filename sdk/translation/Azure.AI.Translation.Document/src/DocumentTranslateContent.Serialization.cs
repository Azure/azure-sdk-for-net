// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    public partial class DocumentTranslateContent : IUtf8JsonSerializable, IJsonModel<DocumentTranslateContent>
    {
        internal virtual MultipartFormDataRequestContent ToMultipartRequestContent()
        {
            MultipartFormDataRequestContent content = new MultipartFormDataRequestContent();
            content.Add(MultipartDocument.Content, "document", MultipartDocument.Name, MultipartDocument.ContentType);
            if (Optional.IsCollectionDefined(MultipartGlossary))
            {
                foreach (MultipartFormFileData item in MultipartGlossary)
                {
                    content.Add(item.Content, "glossary", item.Name, item.ContentType);
                }
            }
            return content;
        }

        void global::System.ClientModel.Primitives.IJsonModel<global::Azure.AI.Translation.Document.DocumentTranslateContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<DocumentTranslateContent>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(DocumentTranslateContent)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("document"u8);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(global::System.BinaryData.FromStream(MultipartDocument.Content));
#else
            using (JsonDocument document = JsonDocument.Parse(BinaryData.FromStream(MultipartDocument.Content)))
            {
                JsonSerializer.Serialize(writer, document.RootElement);
            }
#endif
            if (Optional.IsCollectionDefined(MultipartGlossary))
            {
                writer.WritePropertyName("glossary"u8);
                writer.WriteStartArray();
                foreach (var item in MultipartGlossary)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(global::System.BinaryData.FromStream(item.Content));
#else
                    using (JsonDocument document = JsonDocument.Parse(BinaryData.FromStream(item.Content)))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static DocumentTranslateContent DeserializeDocumentTranslateContent(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            MultipartFormFileData document = default;
            IList<MultipartFormFileData> glossary = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("document"u8))
                {
                    document = new MultipartFormFileData(null, BinaryData.FromString(property.Value.GetRawText()).ToStream(), null);
                    continue;
                }
                if (property.NameEquals("glossary"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<MultipartFormFileData> array = new List<MultipartFormFileData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(new MultipartFormFileData(null, BinaryData.FromString(item.GetRawText()).ToStream(), null));
                        }
                    }
                    glossary = array;
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new DocumentTranslateContent(document, glossary ?? new ChangeTrackingList<MultipartFormFileData>(), serializedAdditionalRawData);
        }
    }
}
