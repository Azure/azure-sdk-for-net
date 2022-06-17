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
        private GZipStream _gzip;
        private readonly MemoryStream _stream;
        private readonly RequestContent _content;

        public Utf8JsonWriter JsonWriter { get; }

        public GZipUtf8JsonRequestContent(RequestContent content)
        {
            _stream = new MemoryStream();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            _content = Create(_stream);
            JsonWriter = new Utf8JsonWriter(_gzip);
            content.WriteTo(_gzip, default);
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
            _gzip.Flush();
            await JsonWriter.FlushAsync(cancellation).ConfigureAwait(false);
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
            _gzip.Flush();
            JsonWriter.Flush();
            _content.WriteTo(stream, cancellation);
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
            _content.Dispose();
            _stream.Dispose();
            _gzip.Dispose();
        }
    }
}
