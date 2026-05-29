// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class SynonymMap
    {
        [CodeGenMember("ETag")]
        private string _etag;

        /// <summary>
        /// Keeps the synonym rules as a list for serialization purposes.
        /// </summary>
        [CodeGenMember("Synonyms")]
        public IList<string> SynonymsList { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="synonyms">
        /// The formatted synonyms string to define.
        /// Because only the "solr" synonym map format is currently supported, these are values delimited by "\n".
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="synonyms"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="synonyms"/> is null.</exception>
        public SynonymMap(string name, string synonyms)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(synonyms, nameof(synonyms));

            Name = name;
            SynonymsList = [.. synonyms.Split('\n')];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SynonymMap"/> class.
        /// </summary>
        /// <param name="name">The name of the synonym map.</param>
        /// <param name="reader">
        /// A <see cref="TextReader"/> from which formatted synonyms are read.
        /// Because only the "solr" synonym map format is currently supported, these are values delimited by "\n".
        /// </param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="reader"/> is null.</exception>
        public SynonymMap(string name, TextReader reader)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(reader, nameof(reader));

            Name = name;
            SynonymsList = [.. reader.ReadToEnd().Split('\n')];
        }

        /// <summary>
        /// The <see cref="global::Azure.ETag"/> of the <see cref="SynonymMap"/>.
        /// </summary>
        public ETag? ETag
        {
            get => _etag is null ? (ETag?)null : new ETag(_etag);
            set => _etag = value?.ToString();
        }

        /// <summary>
        /// A series of synonym rules in the specified synonym map format. The rules must be separated by newlines.
        /// </summary>
        public string Synonyms
        {
            get => SynonymsList is null ? null : string.Join("\n", SynonymsList);
            set => SynonymsList = value is null ? null : [.. value.Split('\n')];
        }

        /// <summary> The format of the synonym map. Only the "solr" format is currently supported. </summary>
        internal string Format { get; } = "solr";

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SynonymMap>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SynonymMap)} does not support writing '{format}' format.");
            }
            writer.WritePropertyName("name"u8);
            writer.WriteStringValue(Name);
            writer.WritePropertyName("format"u8);
            writer.WriteStringValue(Format);
            writer.WritePropertyName("synonyms"u8);
            // Write synonyms as a newline-delimited string, not as an array
            writer.WriteStringValue(Synonyms);
            if (Optional.IsDefined(EncryptionKey))
            {
                writer.WritePropertyName("encryptionKey"u8);
                writer.WriteObjectValue(EncryptionKey, options);
            }
            if (Optional.IsDefined(_etag))
            {
                writer.WritePropertyName("@odata.etag"u8);
                writer.WriteStringValue(_etag);
            }
            if (options.Format != "W" && _additionalBinaryDataProperties != null)
            {
                foreach (var item in _additionalBinaryDataProperties)
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
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static SynonymMap DeserializeSynonymMap(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string name = default;
            string format = default;
            IList<string> synonyms = default;
            SearchResourceEncryptionKey encryptionKey = default;
            string eTag = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("name"u8))
                {
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("format"u8))
                {
                    format = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("synonyms"u8))
                {
                    // Handle both string (old format) and array (new format) for backwards compatibility
                    if (prop.Value.ValueKind == JsonValueKind.String)
                    {
                        string stringValue = prop.Value.GetString();
                        synonyms = string.IsNullOrEmpty(stringValue) ? new List<string>() : [.. stringValue.Split('\n')];
                    }
                    else if (prop.Value.ValueKind == JsonValueKind.Array)
                    {
                        synonyms = new List<string>();
                        foreach (var item in prop.Value.EnumerateArray())
                        {
                            synonyms.Add(item.GetString());
                        }
                    }
                    else
                    {
                        synonyms = new List<string>();
                    }
                    continue;
                }
                if (prop.NameEquals("encryptionKey"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        encryptionKey = null;
                        continue;
                    }
                    encryptionKey = SearchResourceEncryptionKey.DeserializeSearchResourceEncryptionKey(prop.Value, options);
                    continue;
                }
                if (prop.NameEquals("@odata.etag"u8))
                {
                    eTag = prop.Value.GetString();
                    continue;
                }
                if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(prop.Name, BinaryData.FromString(prop.Value.GetRawText()));
                }
            }
            return new SynonymMap(
                name,
                format,
                synonyms,
                encryptionKey,
                eTag,
                additionalBinaryDataProperties);
        }
    }
}
