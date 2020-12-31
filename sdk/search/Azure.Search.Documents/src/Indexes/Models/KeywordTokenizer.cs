// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("KeywordTokenizerV2")]
    [CodeGenSuppress(nameof(KeywordTokenizer), typeof(string), typeof(string), typeof(int?))]
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
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(ODataType);

            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);

            if (BufferSize != null)
            {
                writer.WritePropertyName("bufferSize");
                writer.WriteNumberValue(BufferSize.Value);
            }

            if (MaxTokenLength != null)
            {
                writer.WritePropertyName("maxTokenLength");
                writer.WriteNumberValue(MaxTokenLength.Value);
            }

            writer.WriteEndObject();
        }

        internal static KeywordTokenizer DeserializeKeywordTokenizer(JsonElement element)
        {
            int? bufferSize = default;
            int? maxTokenLength = default;
            string odataType = default;
            string name = default;

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
            }

            return new KeywordTokenizer(name)
            {
                ODataType = odataType,
                BufferSize = bufferSize,
                MaxTokenLength = maxTokenLength,
            };
        }
    }
}
