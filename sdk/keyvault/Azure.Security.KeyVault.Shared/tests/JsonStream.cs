// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Security.KeyVault.Tests
{
    internal class JsonStream : IDisposable
    {
        private readonly MemoryStream _buffer;

        public JsonStream()
        {
            _buffer = new MemoryStream();
        }

        public JsonStream(string content)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(content);
            _buffer = new MemoryStream(buffer);
        }

        public Stream AsStream() => _buffer;

        public Utf8JsonWriter CreateWriter(JsonWriterOptions options = default) => new Utf8JsonWriter(_buffer, options);

        public void Dispose() => _buffer.Dispose();

        public override string ToString() => Encoding.UTF8.GetString(_buffer.GetBuffer(), 0, (int)_buffer.Length);

        public void WriteObject(IJsonSerializable @object, JsonWriterOptions options = default)
        {
            using Utf8JsonWriter writer = CreateWriter(options);

            writer.WriteStartObject();
            @object.WriteProperties(writer);
            writer.WriteEndObject();
        }
    }
}
