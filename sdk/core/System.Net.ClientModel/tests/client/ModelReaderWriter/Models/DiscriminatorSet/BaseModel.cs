// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using System.Text.Json;

namespace System.Net.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    [ModelReaderProxy(typeof(UnknownBaseModel))]
    public abstract class BaseModel : IJsonModel<BaseModel>
    {
        private Dictionary<string, BinaryData> _rawData;

        public static implicit operator RequestBody(BaseModel baseModel)
        {
            if (baseModel == null)
            {
                return null;
            }

            return RequestBody.Create(baseModel, ModelReaderWriterOptions.DefaultWireOptions);
        }

        public static explicit operator BaseModel(Result result)
        {
            ClientUtilities.AssertNotNull(result, nameof(result));

            using JsonDocument jsonDocument = JsonDocument.Parse((BinaryData)result.GetRawResponse().Body);
            return DeserializeBaseModel(jsonDocument.RootElement, ModelReaderWriterOptions.DefaultWireOptions);
        }

        protected internal BaseModel(Dictionary<string, BinaryData> rawData)
        {
            _rawData = rawData ?? new Dictionary<string, BinaryData>();
        }

        public string Kind { get; internal set; }
        public string Name { get; set; }

        protected internal void SerializeRawData(Utf8JsonWriter writer)
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

        void IJsonModel<BaseModel>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            if (options.Format == ModelReaderWriterFormat.Json)
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeBaseModel(BinaryData data, ModelReaderWriterOptions options)
            => DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);

        internal static BaseModel DeserializeBaseModel(JsonElement element, ModelReaderWriterOptions options = default)
        {
            options ??= ModelReaderWriterOptions.DefaultWireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "X":
                        return ModelX.DeserializeModelX(element, options);
                    case "Y":
                        return ModelY.DeserializeModelY(element, options);
                }
            }

            //Deserialize unknown subtype
            string kind = default;
            OptionalProperty<string> name = default;
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
                if (options.Format == ModelReaderWriterFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new UnknownBaseModel(kind, name, rawData);
        }

        BaseModel IModel<BaseModel>.Read(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        BaseModel IJsonModel<BaseModel>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseModel(doc.RootElement, options);
        }

        BinaryData IModel<BaseModel>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(this, options);
        }

        ModelReaderWriterFormat IModel<BaseModel>.GetWireFormat(ModelReaderWriterOptions options) => ModelReaderWriterFormat.Json;
    }
}
