// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.IO;
using System.IO.Compression;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class GZipUtf8JsonRequestContent: RequestContent
    {
#pragma warning disable CA2213 // Disposable fields should be disposed
        private GZipStream _gzip;
        private readonly MemoryStream _stream;
#pragma warning restore CA2213 // Disposable fields should be disposed
        private readonly RequestContent _content;

        public Utf8JsonWriter JsonWriter { get; }

        public GZipUtf8JsonRequestContent(RequestContent content)
        {
            _stream = new MemoryStream();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            _content = Create(_stream);
            JsonWriter = new Utf8JsonWriter(_gzip);
            content.WriteTo(_gzip, default);
            Flush();
        }

        public GZipUtf8JsonRequestContent()
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
#if NETFRAMEWORK
            MemoryStream tempStream = new MemoryStream();
            JsonWriter.Flush();
            _gzip.Dispose();
            _content.WriteTo(tempStream, cancellation);
            tempStream.Position = 0;
            tempStream.CopyTo(stream);
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            JsonWriter.Reset(_gzip);
#else
            Flush();
            _content.WriteTo(stream, cancellation);
#endif
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
            _content.Dispose();
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
