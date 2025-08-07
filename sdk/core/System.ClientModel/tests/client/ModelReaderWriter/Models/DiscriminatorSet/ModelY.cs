// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.ClientShared;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

#if SOURCE_GENERATOR
namespace System.ClientModel.SourceGeneration.Tests
#else
namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
#endif
{
    public class ModelY : BaseModel, IJsonModel<ModelY>
    {
        public ModelY()
            : base(null)
        {
            Kind = "Y";
        }

        internal ModelY(string kind, string? name, string? yProperty, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
            YProperty = yProperty;
        }

        public string? YProperty { get; private set; }

        void IJsonModel<ModelY>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions? options) => Serialize(writer, options);

        private void Serialize(Utf8JsonWriter writer, ModelReaderWriterOptions? options)
        {
            options ??= ModelReaderWriterOptions.Json;

            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (OptionalProperty.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == "J")
            {
                writer.WritePropertyName("yProperty"u8);
                writer.WriteStringValue(YProperty);
            }
            if (options.Format == "J")
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static ModelY DeserializeModelY(JsonElement element, ModelReaderWriterOptions? options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(ModelY)}'");
            }
            string? kind = default;
            OptionalProperty<string> name = default;
            OptionalProperty<string> yProperty = default;
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
                if (property.NameEquals("yProperty"u8))
                {
                    yProperty = property.Value.GetString();
                    continue;
                }
                if (options.Format == "J")
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            if (kind is null)
            {
                throw new JsonException($"Invalid JSON provided to deserialize type '{nameof(ModelY)}': Missing 'kind' property");
            }

            return new ModelY(kind, name, yProperty, rawData);
        }

        ModelY IPersistableModel<ModelY>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            return DeserializeModelY(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        ModelY IJsonModel<ModelY>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelY(doc.RootElement, options);
        }

        BinaryData IPersistableModel<ModelY>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        string IPersistableModel<ModelY>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
