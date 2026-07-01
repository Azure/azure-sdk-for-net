// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Perf
{
    internal class GZipUtf8JsonRequestContentOld : RequestContent
    {
        private GZipStream _gzip;
        private MemoryStream _stream;
        private readonly RequestContent _content;

        public Utf8JsonWriter JsonWriter { get; }

        public GZipUtf8JsonRequestContentOld()
        {
            _stream = new MemoryStream();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            _content = Create(_stream);
            JsonWriter = new Utf8JsonWriter(_gzip);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            await FlushAsync().ConfigureAwait(false);
            await _content.WriteToAsync(stream, cancellation).ConfigureAwait(false);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            Flush();
            _content.WriteTo(stream, cancellation);
        }

        public override bool TryComputeLength(out long length)
        {
            Flush();
            length = _stream.Length;
            return true;
        }

        public override void Dispose()
        {
            JsonWriter.Dispose();
            _gzip.Dispose();
            _content.Dispose();
            _stream.Dispose();
        }

        private void Flush()
        {
            JsonWriter.Flush();
            _gzip.Flush();
        }

        private async Task FlushAsync()
        {
            await JsonWriter.FlushAsync().ConfigureAwait(false);
            await _gzip.FlushAsync().ConfigureAwait(false);
        }
    }
}
