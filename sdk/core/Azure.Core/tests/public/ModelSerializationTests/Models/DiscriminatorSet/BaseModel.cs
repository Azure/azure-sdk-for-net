// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Serialization;
using Azure.Core;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    public abstract class BaseModel : IUtf8JsonSerializable, IJsonModelSerializable<BaseModel>, IJsonModelSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public string Kind { get; internal set; }
        public string Name { get; set; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable<BaseModel>)this).Serialize(writer, ModelSerializerOptions.DefaultAzureOptions);

        void IJsonModelSerializable<BaseModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

        private void Serialize(Utf8JsonWriter writer, ModelSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind"u8);
            writer.WriteStringValue(Kind);
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name"u8);
                writer.WriteStringValue(Name);
            }
            if (options.Format == ModelSerializerFormat.Json)
            {
                //write out the raw data
                foreach (var property in RawData)
                {
                    writer.WritePropertyName(property.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(property.Value);
#else
                    JsonSerializer.Serialize(writer, JsonDocument.Parse(property.Value.ToString()).RootElement);
#endif
                }
            }
            writer.WriteEndObject();
        }

        internal static BaseModel DeserializeBaseModel(BinaryData data, ModelSerializerOptions options)
            => DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);

        internal static BaseModel DeserializeBaseModel(JsonElement element, ModelSerializerOptions options = default)
        {
            options ??= ModelSerializerOptions.DefaultAzureOptions;

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
            return UnknownBaseModel.DeserializeUnknownBaseModel(element, options);
        }

        BaseModel IModelSerializable<BaseModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
            => DeserializeBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);

        BaseModel IJsonModelSerializable<BaseModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeBaseModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<BaseModel>.Serialize(ModelSerializerOptions options)
        {
            return ModelSerializerHelper.SerializeToBinaryData((writer) => { Serialize(writer, options); });
        }

        void IJsonModelSerializable<object>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => ((IJsonModelSerializable<BaseModel>)this).Serialize(writer, options);

        object IJsonModelSerializable<object>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options) => ((IJsonModelSerializable<BaseModel>)this).Deserialize(ref reader, options);

        object IModelSerializable<object>.Deserialize(BinaryData data, ModelSerializerOptions options) => ((IModelSerializable<BaseModel>)this).Deserialize(data, options);

        BinaryData IModelSerializable<object>.Serialize(ModelSerializerOptions options) => ((IModelSerializable<BaseModel>)this).Serialize(options);
    }
}
