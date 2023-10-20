// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;

namespace System.Net.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    public class ModelY : BaseModel, IUtf8JsonContentWriteable, IJsonModel<ModelY>
    {
        public ModelY()
            : base(null)
        {
            Kind = "Y";
        }

        internal ModelY(string kind, string name, string yProperty, Dictionary<string, BinaryData> rawData)
            : base(rawData)
        {
            Kind = kind;
            Name = name;
            YProperty = yProperty;
        }

        public string YProperty { get; private set; }

        void IUtf8JsonContentWriteable.Write(Utf8JsonWriter writer) => ((IJsonModel<ModelY>)this).Write(writer, ModelReaderWriterOptions.DefaultWireOptions);

        void IJsonModel<ModelY>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Serialize(writer, options);

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
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                writer.WritePropertyName("yProperty"u8);
                writer.WriteStringValue(YProperty);
            }
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static ModelY DeserializeModelY(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new ModelY(kind, name, yProperty, rawData);
        }

        ModelY IModel<ModelY>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            return DeserializeModelY(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        ModelY IJsonModel<ModelY>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeModelY(doc.RootElement, options);
        }

        BinaryData IModel<ModelY>.Write(ModelReaderWriterOptions options)
        {
            ModelSerializerHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.WriteCore(this, options);
        }
    }
}
