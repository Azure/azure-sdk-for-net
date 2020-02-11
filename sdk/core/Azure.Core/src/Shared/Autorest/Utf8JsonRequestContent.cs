// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class Utf8JsonRequestContent: RequestContent
    {
        private readonly ArrayBufferWriter<byte> _writer;

        public Utf8JsonWriter JsonWriter { get; }

        public Utf8JsonRequestContent()
        {
            _writer = new ArrayBufferWriter<byte>();
            JsonWriter = new Utf8JsonWriter(_writer);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            await JsonWriter.FlushAsync(cancellation).ConfigureAwait(false);
            using var content = Create(_writer.WrittenMemory);
            await content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            JsonWriter.Flush();
            using var content = Create(_writer.WrittenMemory);
            content.WriteTo(stream, cancellation);
        }

        public override bool TryComputeLength(out long length)
        {
            length = JsonWriter.BytesCommitted + JsonWriter.BytesPending;
            return true;
        }

        public override void Dispose()
        {
        }
    }
}
