// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("LuceneStandardTokenizerV2")]
    [CodeGenSuppress(nameof(LuceneStandardTokenizer), typeof(string), typeof(IDictionary<string, BinaryData>), typeof(string), typeof(int?))]
    public partial class LuceneStandardTokenizer : IUtf8JsonSerializable
    {
        /// <summary>
        /// Initializes a new instance of LuceneStandardTokenizer.
        /// </summary>
        /// <param name="name">
        /// The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores,
        /// can only start and end with alphanumeric characters, and is limited to 128 characters.
        /// </param>
        public LuceneStandardTokenizer(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ODataType = "#Microsoft.Azure.Search.StandardTokenizerV2";
        }

        /// <summary>
        /// The maximum token length. Default is 255.
        /// Tokens longer than the maximum length are split.
        /// The maximum token length that can be used is 300 characters.
        /// </summary>
        public int? MaxTokenLength { get; set; }

        internal static LuceneStandardTokenizer DeserializeLuceneStandardTokenizer(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Optional<int> maxTokenLength = default;
            string odataType = default;
            string name = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> additionalPropertiesDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("maxTokenLength"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxTokenLength = property.Value.GetInt32();
                    continue;
                }
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
                if (options.Format != "W")
                {
                    additionalPropertiesDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = additionalPropertiesDictionary;
            return new LuceneStandardTokenizer(name)
            {
                ODataType = odataType,
                MaxTokenLength = Optional.ToNullable(maxTokenLength),
            };
        }
    }
}
