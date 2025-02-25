// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.ClientShared;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    public class ModelWithPersistableStream : IPersistableStreamModel<ModelWithPersistableStream>
    {
        private readonly Dictionary<string, BinaryData> _rawData;

        public ModelWithPersistableStream()
        {
            _rawData = new Dictionary<string, BinaryData>();
            Fields = new List<string>();
            KeyValuePairs = new Dictionary<string, string>();
        }

        internal ModelWithPersistableStream(string? name, int xProperty, int? nullProperty, IList<string> fields, IDictionary<string, string> keyValuePairs, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            XProperty = xProperty;
            NullProperty = nullProperty;
            Fields = fields;
            KeyValuePairs = keyValuePairs;
            _rawData = rawData;
        }

        private void AssertHasValue<T>(T? value, string name)
        {
            if (value is null)
                throw new ArgumentNullException(name);
        }

        public string? Name { get; }

        private int? _xProperty;
        public int XProperty
        {
            get
            {
                AssertHasValue(_xProperty, nameof(XProperty));
                return _xProperty!.Value;
            }
            set => _xProperty = value;
        }

        public IList<string> Fields { get; }
        public int? NullProperty = null;
        public IDictionary<string, string> KeyValuePairs { get; }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (OptionalProperty.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (OptionalProperty.IsCollectionDefined(Fields))
            {
                writer.WritePropertyName("fields"u8);
                writer.WriteStartArray();
                foreach (string field in Fields)
                {
                    writer.WriteStringValue(field);
                }
                writer.WriteEndArray();
            }
            if (OptionalProperty.IsDefined(NullProperty))
            {
                writer.WritePropertyName("nullProperty"u8);
                writer.WriteNumberValue(NullProperty!.Value);
            }
            if (OptionalProperty.IsCollectionDefined(KeyValuePairs))
            {
                writer.WritePropertyName("keyValuePairs"u8);
                writer.WriteStartObject();
                foreach (var item in KeyValuePairs)
                {
                    writer.WritePropertyName(item.Key);
                    if (item.Value == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }

            if (options.Format == "J")
            {
                writer.WritePropertyName("xProperty"u8);
                writer.WriteNumberValue(XProperty);
            }
            if (options.Format == "J")
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        private void SerializeRawData(Utf8JsonWriter writer)
        {
            //write out the raw data
            foreach (var property in _rawData)
            {
                writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
                writer.WriteRawValue(property.Value);
#else
                JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
            }
        }

        internal static ModelWithPersistableStream DeserializeModelX(JsonElement element, ModelReaderWriterOptions? options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(ModelWithPersistableStream)}'");
            }

            OptionalProperty<string> name = default;
            int xProperty = default;
            OptionalProperty<int> nullProperty = default;
            OptionalProperty<IList<string>> fields = default;
            OptionalProperty<IDictionary<string, string>> keyValuePairs = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    fields = property.Value.EnumerateArray().Select(element => element.GetString()!).ToList();
                    continue;
                }
                if (property.NameEquals("nullProperty"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    nullProperty = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("keyValuePairs"u8))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (JsonProperty property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString()!);
                    }
                    keyValuePairs = dictionary;
                    continue;
                }
                if (property.NameEquals("xProperty"u8))
                {
                    xProperty = property.Value.GetInt32();
                    continue;
                }
                if (options.Format == "J")
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            return new ModelWithPersistableStream(name, xProperty, OptionalProperty.ToNullable(nullProperty), OptionalProperty.ToList(fields), OptionalProperty.ToDictionary(keyValuePairs), rawData);
        }

        ModelWithPersistableStream IPersistableModel<ModelWithPersistableStream>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return DeserializeModelX(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        BinaryData IPersistableModel<ModelWithPersistableStream>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using MemoryStream stream = new MemoryStream();
            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            Serialize(writer, options);
            writer.Flush();
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        string IPersistableModel<ModelWithPersistableStream>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        public void Write(Stream stream, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using Utf8JsonWriter writer = new Utf8JsonWriter(stream);
            Serialize(writer, options);
            writer.Flush();
            if (stream.CanSeek)
            {
                stream.Position = 0;
            }
        }
    }
}
