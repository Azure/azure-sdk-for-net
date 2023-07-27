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
using Newtonsoft.Json.Linq;

namespace Azure.Core.Tests.Public.ModelSerializationTests.Models
{
    internal class UnknownBaseModel : BaseModel, IUtf8JsonSerializable, IJsonModelSerializable<UnknownBaseModel>, IJsonModelSerializable
    {
        private Dictionary<string, BinaryData> RawData { get; set; } = new Dictionary<string, BinaryData>();

        public UnknownBaseModel()
        {
            Kind = "Unknown";
        }

        internal UnknownBaseModel(string kind, string name, Dictionary<string, BinaryData> rawData)
        {
            Kind = kind;
            Name = name;
            RawData = rawData;
        }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModelSerializable<UnknownBaseModel>)this).Serialize(writer, new ModelSerializerOptions(ModelSerializerFormat.Wire));

        void IJsonModelSerializable<UnknownBaseModel>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => Serialize(writer, options);

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

        internal static UnknownBaseModel DeserializeUnknownBaseModel(JsonElement element, ModelSerializerOptions? options = default)
        {
            options ??= new ModelSerializerOptions(ModelSerializerFormat.Wire);

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string kind = default;
            Optional<string> name = default;
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
                if (options.Value.Format == ModelSerializerFormat.Json)
                {
                    //this means it's an unknown property we got
                    rawData.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            return new UnknownBaseModel(kind, name, rawData);
        }

        UnknownBaseModel IModelSerializable<UnknownBaseModel>.Deserialize(BinaryData data, ModelSerializerOptions options)
        {
            return DeserializeUnknownBaseModel(JsonDocument.Parse(data.ToString()).RootElement, options);
        }

        UnknownBaseModel IJsonModelSerializable<UnknownBaseModel>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeUnknownBaseModel(doc.RootElement, options);
        }

        BinaryData IModelSerializable<UnknownBaseModel>.Serialize(ModelSerializerOptions options) => ModelSerializerHelper.SerializeToBinaryData(writer => Serialize(writer, options));

        void IJsonModelSerializable<object>.Serialize(Utf8JsonWriter writer, ModelSerializerOptions options) => ((IJsonModelSerializable<UnknownBaseModel>)this).Serialize(writer, options);

        object IJsonModelSerializable<object>.Deserialize(ref Utf8JsonReader reader, ModelSerializerOptions options) => ((IJsonModelSerializable<UnknownBaseModel>)this).Deserialize(ref reader, options);

        object IModelSerializable<object>.Deserialize(BinaryData data, ModelSerializerOptions options) => ((IModelSerializable<UnknownBaseModel>)this).Deserialize(data, options);

        BinaryData IModelSerializable<object>.Serialize(ModelSerializerOptions options) => ((IModelSerializable<UnknownBaseModel>)this).Serialize(options);
    }
}
