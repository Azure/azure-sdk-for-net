// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenModel("NGramTokenFilterV2")]
    public partial class NGramTokenFilter : IUtf8JsonSerializable
    {
        /// <summary>
        /// Initializes a new instance of NGramTokenFilter.
        /// </summary>
        /// <param name="name">
        /// The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores,
        /// can only start and end with alphanumeric characters, and is limited to 128 characters.
        /// </param>
        public NGramTokenFilter(string name) : base(name)
        {
            Argument.AssertNotNull(name, nameof(name));

            ODataType = "#Microsoft.Azure.Search.NGramTokenFilterV2";
        }

        /// <summary>
        /// The minimum n-gram length. Default is 1.
        /// Maximum is 300.
        /// Must be less than the value of maxGram.
        /// </summary>
        public int? MinGram { get; set; }

        /// <summary>
        /// The maximum n-gram length. Default is 2.
        /// Maximum is 300.
        /// </summary>
        public int? MaxGram { get; set; }

        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("@odata.type");
            writer.WriteStringValue(ODataType);

            writer.WritePropertyName("name");
            writer.WriteStringValue(Name);

            if (MinGram != null)
            {
                writer.WritePropertyName("minGram");
                writer.WriteNumberValue(MinGram.Value);
            }

            if (MaxGram != null)
            {
                writer.WritePropertyName("maxGram");
                writer.WriteNumberValue(MaxGram.Value);
            }

            writer.WriteEndObject();
        }

        internal static NGramTokenFilter DeserializeNGramTokenFilter(JsonElement element)
        {
            int? minGram = default;
            int? maxGram = default;
            string odataType = default;
            string name = default;
            foreach (var property in element.EnumerateObject())
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

                if (property.NameEquals("minGram"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    minGram = property.Value.GetInt32();
                    continue;
                }

                if (property.NameEquals("maxGram"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    maxGram = property.Value.GetInt32();
                    continue;
                }
            }

            return new NGramTokenFilter(name)
            {
                ODataType = odataType,
                MinGram = minGram,
                MaxGram = maxGram,
            };
        }
    }
}
