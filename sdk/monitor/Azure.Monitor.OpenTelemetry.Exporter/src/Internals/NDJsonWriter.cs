// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Text.Json;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal sealed class NDJsonWriter : IDisposable
    {
        private static readonly byte[] s_separator = { (byte)'\n' };

        private readonly Azure.Core.ArrayBufferWriter<byte> _buffer = new();

        public NDJsonWriter()
        {
            JsonWriter = new Utf8JsonWriter(_buffer, new JsonWriterOptions() { SkipValidation = true });
        }

        public Utf8JsonWriter JsonWriter { get; }

        public void WriteNewLine()
        {
            JsonWriter.Flush();
            JsonWriter.Reset();
            _buffer.Write(s_separator);
        }

        public ReadOnlyMemory<byte> ToBytes()
        {
            JsonWriter.Flush();
            return _buffer.WrittenMemory;
        }

        public override string ToString()
        {
#if NET8_0_OR_GREATER
            return System.Text.Encoding.UTF8.GetString(_buffer.WrittenSpan);
#else
            return System.Text.Encoding.UTF8.GetString(_buffer.WrittenSpan.ToArray());
#endif
        }

        public void Dispose()
        {
            JsonWriter.Dispose();
        }
    }
}
