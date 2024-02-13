// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests.ClientShared;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace System.ClientModel.Tests.Client.ModelReaderWriterTests.Models
{
    [PersistableModelProxy(typeof(UnknownBaseModel))]
    public abstract class BaseModel : IJsonModel<BaseModel?>
    {
        private readonly Dictionary<string, BinaryData> _rawData;

        protected internal BaseModel(Dictionary<string, BinaryData>? rawData)
        {
            _rawData = rawData ?? new Dictionary<string, BinaryData>();
        }

        internal Dictionary<string, BinaryData> GetRawData() => _rawData;

        public static implicit operator BinaryContent?(BaseModel? baseModel)
        {
            if (baseModel == null)
            {
                return null;
            }

            return BinaryContent.Create(new NonNullable(baseModel), ModelReaderWriterHelper.WireOptions);
        }

        public static explicit operator BaseModel?(ClientResult result)
        {
            if (result is null)
                throw new ArgumentNullException(nameof(result));

            using JsonDocument jsonDocument = JsonDocument.Parse(result.GetRawResponse().Content);
            return DeserializeBaseModel(jsonDocument.RootElement, ModelReaderWriterHelper.WireOptions);
        }

        public string? Kind { get; internal set; }
        public string? Name { get; set; }

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

        void IJsonModel<BaseModel?>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
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
            if (options.Format == "J")
            {
                SerializeRawData(writer);
            }
            writer.WriteEndObject();
        }

        internal static BaseModel? DeserializeBaseModel(BinaryData data, ModelReaderWriterOptions options)
            => DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);

        internal static BaseModel? DeserializeBaseModel(JsonElement element, ModelReaderWriterOptions? options = default)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

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
            string? kind = default;
            OptionalProperty<string>? name = default;
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
                    name = new(property.Value.GetString());
                    continue;
                }
                if (options.Format == "J")
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new UnknownBaseModel(kind, name, rawData);
        }

        BaseModel? IPersistableModel<BaseModel?>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        BaseModel? IJsonModel<BaseModel?>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseModel(doc.RootElement, options);
        }

        BinaryData IPersistableModel<BaseModel?>.Write(ModelReaderWriterOptions options)
        {
            ModelReaderWriterHelper.ValidateFormat(this, options.Format);

            return ModelReaderWriter.Write(new NonNullable(this), options);
        }

        string IPersistableModel<BaseModel?>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private class NonNullable : BaseModel, IPersistableModel<NonNullable>
        {
            private readonly BaseModel _value;

            public NonNullable(BaseModel model) : base(model.GetRawData())
            {
                if (model is null)
                    throw new ArgumentNullException(nameof(model));

                _value = model;
            }

            NonNullable IPersistableModel<NonNullable>.Create(BinaryData data, ModelReaderWriterOptions options)
                => new(((IPersistableModel<BaseModel>)_value).Create(data, options));

            string IPersistableModel<NonNullable>.GetFormatFromOptions(ModelReaderWriterOptions options)
                => ((IPersistableModel<BaseModel>)_value).GetFormatFromOptions(options);

            BinaryData IPersistableModel<NonNullable>.Write(ModelReaderWriterOptions options)
                => ((IPersistableModel<BaseModel>)_value).Write(options);
        }
    }
}
