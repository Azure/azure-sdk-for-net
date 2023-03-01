// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Security.KeyVault
{
    internal class ModelConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert) => typeof(IJsonDeserializable).IsAssignableFrom(typeToConvert) || typeof(IJsonSerializable).IsAssignableFrom(typeToConvert);

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type converterType = typeof(ModelConverter<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(converterType);
        }

        public class ModelConverter<T> : JsonConverter<T>
        {
            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                object value = Activator.CreateInstance(typeToConvert, true);
                if (value is IJsonDeserializable deserializable)
                {
                    JsonDocument doc = JsonDocument.ParseValue(ref reader);
                    deserializable.ReadProperties(doc.RootElement);
                    return (T)deserializable;
                }

                throw new NotImplementedException();
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                if (value is IJsonSerializable serializable)
                {
                    writer.WriteStartObject();
                    serializable.WriteProperties(writer);
                    writer.WriteEndObject();

                    return;
                }

                throw new NotImplementedException();
            }
        }
    }
}
