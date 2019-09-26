// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Azure.Security.KeyVault.Certificates.Tests
{
    public class JsonStream : IDisposable
    {
        private readonly MemoryStream _buffer = new MemoryStream();

        public Utf8JsonWriter CreateWriter(JsonWriterOptions options = default) => new Utf8JsonWriter(_buffer, options);

        public void Dispose() => _buffer.Dispose();

        public override string ToString() => Encoding.UTF8.GetString(_buffer.GetBuffer(), 0, (int)_buffer.Length);
    }
}
