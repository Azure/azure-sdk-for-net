﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    public class ModelX : BaseModel, IJsonModel<ModelX>
    {
        public ModelX()
            : base(null)
        {
            Kind = "X";
        }

        internal ModelX(string kind, string name, int xProperty, int? nullProperty, IList<string> fields, IDictionary<string, string> keyValuePairs, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
            XProperty = xProperty;
            NullProperty = nullProperty;
            Fields = fields;
            KeyValuePairs = keyValuePairs;
        }

        public int XProperty { get; }
        public IList<string> Fields { get; }
        public int? NullProperty = null;
        public IDictionary<string, string> KeyValuePairs { get; }

        void IJsonModel<ModelX>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            Serialize(writer, options);
        }

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
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
                writer.WriteNumberValue(NullProperty.Value);
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

        internal static ModelX DeserializeModelX(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
            OptionalProperty<string> name = default;
            int xProperty = default;
            OptionalProperty<int> nullProperty = default;
            OptionalProperty<IList<string>> fields = default;
            OptionalProperty<IDictionary<string, string>> keyValuePairs = default;
            Dictionary<string, BinaryData> rawData = new Dictionary<string, BinaryData>();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"u8))
                {
                    kind = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("fields"u8))
                {
                    fields = property.Value.EnumerateArray().Select(element => element.GetString()).ToList();
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
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
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
            return new ModelX(kind, name, xProperty, OptionalProperty.ToNullable(nullProperty), OptionalProperty.ToList(fields), OptionalProperty.ToDictionary(keyValuePairs), rawData);
        }

        ModelX IPersistableModel<ModelX>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return DeserializeModelX(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        ModelX IJsonModel<ModelX>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelX(doc.RootElement, options);
        }

        BinaryData IPersistableModel<ModelX>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        string IPersistableModel<ModelX>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
