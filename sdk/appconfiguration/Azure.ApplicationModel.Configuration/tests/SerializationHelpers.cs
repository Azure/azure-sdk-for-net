// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.Text.Json;

namespace Azure.ApplicationModel.Configuration.Tests
{
    internal class SerializationHelpers
    {
        public delegate void SerializerFunc<in T>(ref Utf8JsonWriter writer, T t);

        public static byte[] Serialize<T>(T t, SerializerFunc<T> serializerFunc)
        {
            // 2048 get a buffer large enough for all test objects
            var buffer = ArrayPool<byte>.Shared.Rent(2048);
            try
            {
                var writer = new FixedSizedBufferWriter(buffer);
                var json = new Utf8JsonWriter(writer);
                serializerFunc(ref json, t);
                return buffer.AsMemory().Slice(0, (int)json.BytesWritten).ToArray();
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
