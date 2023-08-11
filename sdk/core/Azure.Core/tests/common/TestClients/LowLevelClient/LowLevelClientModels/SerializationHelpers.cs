// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Core.Experimental.Tests.Models
{
    public class SerializationHelpers
    {
        public delegate void SerializerFunc<in T>(ref Utf8JsonWriter writer, T t);

        public static byte[] Serialize<T>(T t, SerializerFunc<T> serializerFunc)
        {
            var writer = new ArrayBufferWriter<byte>();
            var json = new Utf8JsonWriter(writer);
            serializerFunc(ref json, t);
            json.Flush();
            return writer.WrittenMemory.ToArray();
        }
    }
}
