// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Serialization;
using System;
using System.IO;
using System.Text.Json;

namespace Azure.Security.KeyVault
{
    internal interface IJsonSerializable
    {
        void WriteProperties(Utf8JsonWriter json);
    }

    internal interface IJsonDeserializable
    {
        void ReadProperties(JsonElement json);
    }

    internal static class SerializationExtensions
    {
        private static readonly JsonObjectSerializer s_serializer = new JsonObjectSerializer(new()
        {
            Converters = { new ModelConverterFactory() },
        });

        public static void Deserialize(this IJsonDeserializable obj, Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            obj.ReadProperties(json.RootElement);
        }

        public static Response<T> Deserialize<T>(this Response response, Func<T> factory) where T: IJsonDeserializable
        {
            T value = factory();
            value.Deserialize(response.ContentStream);

            return Response.FromValue(value, response);
        }

        public static Response<T> DeserializeWithObjectSerialize<T>(this Response response) where T: IJsonSerializable
        {
            T obj = response.Content.ToObject<T>(s_serializer);
            return Response.FromValue(obj, response);
        }

        public static ReadOnlyMemory<byte> Serialize(this IJsonSerializable obj)
        {
            var writer = new ArrayBufferWriter<byte>();

            using (var json = new Utf8JsonWriter(writer))
            {
                json.WriteStartObject();

                obj.WriteProperties(json);

                json.WriteEndObject();
                json.Flush();
            }

            return writer.WrittenMemory;
        }

        public static RequestContent SerializeWithObjectSerializer(this IJsonSerializable obj) =>
            RequestContent.Create(obj, s_serializer);

        public static RequestContent ToRequestContent(this IJsonSerializable obj)
        {
            ReadOnlyMemory<byte> serialized = obj.Serialize();
            return RequestContent.Create(serialized);
        }
    }
}
