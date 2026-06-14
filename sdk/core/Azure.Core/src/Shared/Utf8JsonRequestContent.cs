// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class Utf8JsonRequestContent : RequestContent
    {
        private readonly ArrayBufferWriter<byte> _buffer;

        public Utf8JsonWriter JsonWriter { get; }

        public Utf8JsonRequestContent()
        {
            _buffer = new ArrayBufferWriter<byte>();
            JsonWriter = new Utf8JsonWriter(_buffer);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            await JsonWriter.FlushAsync(cancellation).ConfigureAwait(false);
#if NET6_0_OR_GREATER
            await stream.WriteAsync(_buffer.WrittenMemory, cancellation).ConfigureAwait(false);
#else
            var memory = _buffer.WrittenMemory;
            if (MemoryMarshal.TryGetArray(memory, out var segment))
            {
                await stream.WriteAsync(segment.Array!, segment.Offset, segment.Count, cancellation).ConfigureAwait(false);
            }
            else
            {
                var bytes = memory.ToArray();
                await stream.WriteAsync(bytes, 0, bytes.Length, cancellation).ConfigureAwait(false);
            }
#endif
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            JsonWriter.Flush();
#if NET6_0_OR_GREATER
            stream.Write(_buffer.WrittenSpan);
#else
            var memory = _buffer.WrittenMemory;
            if (MemoryMarshal.TryGetArray(memory, out var segment))
            {
                stream.Write(segment.Array!, segment.Offset, segment.Count);
            }
            else
            {
                var bytes = memory.ToArray();
                stream.Write(bytes, 0, bytes.Length);
            }
#endif
        }

        public override bool TryComputeLength(out long length)
        {
            length = JsonWriter.BytesCommitted + JsonWriter.BytesPending;
            return true;
        }

        public override void Dispose()
        {
            JsonWriter.Dispose();
        }
    }
}
