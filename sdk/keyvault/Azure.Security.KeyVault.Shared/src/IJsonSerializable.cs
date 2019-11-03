// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
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
        public static void Deserialize(this IJsonDeserializable obj, Stream content)
        {
            using JsonDocument json = JsonDocument.Parse(content, default);
            obj.ReadProperties(json.RootElement);
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
    }
}
