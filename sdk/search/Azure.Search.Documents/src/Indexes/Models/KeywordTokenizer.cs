// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Text.Json;
using Azure.Core;
using System.ClientModel.Primitives;
using System.ClientModel;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("KeywordTokenizerV2")]
    [CodeGenSuppress(nameof(KeywordTokenizer), typeof(string), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(int?))]
    public partial class KeywordTokenizer : IUtf8JsonSerializable
    {
        /// <summary>
        /// Initializes a new instance of KeywordTokenizer.
        /// </summary>
        /// <param name="name">
        /// The name of the tokenizer. It must only contain letters, digits, spaces,
        /// dashes or underscores, can only start and end with alphanumeric characters,
        /// and is limited to 128 characters.
        /// </param>
        public KeywordTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ODataType = "#Microsoft.Azure.Search.KeywordTokenizerV2";
        }

        /// <summary> Initializes a new instance of <see cref="KeywordTokenizer"/>. </summary>
        /// <param name="oDataType"> A URI fragment specifying the type of tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="maxTokenLength"> The maximum token length. Default is 256. Tokens longer than the maximum length are split. The maximum token length that can be used is 300 characters. </param>
        /// <param name="bufferSize"> The buffer size. </param>
        internal KeywordTokenizer(string oDataType, string name, IDictionary<string, BinaryData> serializedAdditionalRawData, int? maxTokenLength, int? bufferSize) : base(oDataType, name, serializedAdditionalRawData)
        {
            MaxTokenLength = maxTokenLength;
            BufferSize = bufferSize;
            ODataType = oDataType ?? "#Microsoft.Azure.Search.KeywordTokenizerV2";
        }

        /// <summary>
        /// The read buffer size in bytes. Default is 256.
        /// Setting this property on new instances of <see cref="KeywordTokenizer"/> may result in an error
        /// when sending new requests to the Azure Cognitive Search service.
        /// </summary>
        public int? BufferSize { get; set; }

        /// <summary>
        /// The maximum token length. Default is 256.
        /// Tokens longer than the maximum length are split.
        /// The maximum token length that can be used is 300 characters.
        /// </summary>
        public int? MaxTokenLength { get; set; }

        // Use global scope to fully qualify name to work around bug in generator currently.
        void global::System.ClientModel.Primitives.IJsonModel<KeywordTokenizer>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<KeywordTokenizer>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new InvalidOperationException($"The model {nameof(KeywordTokenizer)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("@odata.type"u8);
            writer.WriteStringValue(ODataType);
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            if (Optional.IsDefined(BufferSize))
            {
                writer.WritePropertyName("bufferSize");
                writer.WriteNumberValue(BufferSize.Value);
            }
            if (Optional.IsDefined(MaxTokenLength))
            {
                writer.WritePropertyName("maxTokenLength"u8);
                writer.WriteNumberValue(MaxTokenLength.Value);
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

        internal static KeywordTokenizer DeserializeKeywordTokenizer(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string odataType = default;
            string name = default;
            Optional<int> maxTokenLength = default;
            Optional<int> bufferSize = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"u8))
                {
                    odataType = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("maxTokenLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("bufferSize"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bufferSize = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new KeywordTokenizer(odataType, name, serializedAdditionalRawData, Optional.ToNullable(maxTokenLength), Optional.ToNullable(bufferSize));
        }
    }
}
