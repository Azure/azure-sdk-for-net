// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Azure.Core;
using Typespec = Microsoft.TypeSpec.Generator.Customizations;

#pragma warning  disable SA1402 // File may only contain a single class, struct, or interface

namespace Azure.Search.Documents.Indexes.Models
{
    [Typespec.CodeGenType("KeywordTokenizerV2")]
    internal partial class InternalKeywordTokenizerV2 { }

    [Typespec.CodeGenType("KeywordTokenizer")]
    [Typespec.CodeGenSerialization(nameof(BufferSize), "bufferSize")]
    public partial class KeywordTokenizer
    {
        /// <summary> Initializes a new instance of <see cref="KeywordTokenizer"/> for deserialization. </summary>
        internal KeywordTokenizer()
        {
        }

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

            OdataType = "#Microsoft.Azure.Search.KeywordTokenizerV2";
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

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<KeywordTokenizer>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(KeywordTokenizer)} does not support writing '{format}' format.");
            }
            base.JsonModelWriteCore(writer, options);
            if (Optional.IsDefined(BufferSize))
            {
                writer.WritePropertyName("bufferSize"u8);
                writer.WriteNumberValue(BufferSize.Value);
            }
            if (Optional.IsDefined(MaxTokenLength))
            {
                writer.WritePropertyName("maxTokenLength"u8);
                writer.WriteNumberValue(MaxTokenLength.Value);
            }
        }

        internal static KeywordTokenizer DeserializeKeywordTokenizer(JsonElement element, ModelReaderWriterOptions options)
        {
            int? bufferSize = default;
            int? maxTokenLength = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> additionalProperties = new Dictionary<string, BinaryData>();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("@odata.type"))
                {
                    odataType = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }

                if (property.NameEquals("bufferSize"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    bufferSize = property.Value.GetInt32();
                    continue;
                }

                if (property.NameEquals("maxTokenLength"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            return new KeywordTokenizer(odataType, name, additionalProperties, bufferSize)
            {
                MaxTokenLength = maxTokenLength
            };
        }
    }
}
