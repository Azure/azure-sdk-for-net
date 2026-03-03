// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Buffers;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class GZipUtf8JsonRequestContent: RequestContent
    {
        private GZipStream _gzip;
#if NETFRAMEWORK
        private MemoryStream _stream;
        private readonly RequestContent _content;
#else
        private readonly ArrayBufferWriter<byte> _buffer;
        private readonly BufferWriterStream _bufferStream;
#endif

        public Utf8JsonWriter JsonWriter { get; }

        public GZipUtf8JsonRequestContent(RequestContent content)
        {
#if NETFRAMEWORK
            _stream = new MemoryStream();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            _content = Create(_stream);
#else
            _buffer = new ArrayBufferWriter<byte>();
            _bufferStream = new BufferWriterStream(_buffer);
            _gzip = new GZipStream(_bufferStream, CompressionMode.Compress, true);
#endif
            JsonWriter = new Utf8JsonWriter(_gzip);
            content.WriteTo(_gzip, default);
            Flush();
        }

        public GZipUtf8JsonRequestContent()
        {
#if NETFRAMEWORK
            _stream = new MemoryStream();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            _content = Create(_stream);
#else
            _buffer = new ArrayBufferWriter<byte>();
            _bufferStream = new BufferWriterStream(_buffer);
            _gzip = new GZipStream(_bufferStream, CompressionMode.Compress, true);
#endif
            JsonWriter = new Utf8JsonWriter(_gzip);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
#if NETFRAMEWORK
            MemoryStream tempStream = new MemoryStream();
            await JsonWriter.FlushAsync(cancellation).ConfigureAwait(false);
            _gzip.Dispose();
            await _content.WriteToAsync(tempStream, cancellation).ConfigureAwait(false);
            tempStream.Position = 0;
            tempStream.CopyTo(stream);
            _stream = tempStream;
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            JsonWriter.Reset(_gzip);
#else
            await FlushAsync().ConfigureAwait(false);
            var memory = _buffer.WrittenMemory;
#if NET6_0_OR_GREATER
            await stream.WriteAsync(memory, cancellation).ConfigureAwait(false);
#else
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
#endif
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            //TODO: https://github.com/Azure/azure-sdk-for-net/issues/30691
#if NETFRAMEWORK
            MemoryStream tempStream = new MemoryStream();
            JsonWriter.Flush();
            _gzip.Dispose();
            _content.WriteTo(tempStream, cancellation);
            tempStream.Position = 0;
            tempStream.CopyTo(stream);
            _stream = tempStream;
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            JsonWriter.Reset(_gzip);
#else
            Flush();
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
            //TODO: https://github.com/Azure/azure-sdk-for-net/issues/30691
            Flush();
#if NETFRAMEWORK
            length = _stream.Length;
#else
            length = _buffer.WrittenCount;
#endif
            return true;
        }

        public override void Dispose()
        {
            JsonWriter.Dispose();
            _gzip.Dispose();
#if NETFRAMEWORK
            _content.Dispose();
            _stream.Dispose();
#endif
        }

        private void Flush()
        {
            JsonWriter.Flush();
            _gzip.Flush();
#if NETFRAMEWORK // .NETFramework 4.6.1 The stream can only be properly flushed via Dispose().  As a result, we must recreate the Stream after Flush/Dispose. See https://github.com/dotnet/runtime/issues/15371 for details.
            _gzip.Dispose();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            JsonWriter.Reset(_gzip);
#endif
        }

        private async Task FlushAsync()
        {
            await JsonWriter.FlushAsync().ConfigureAwait(false);
            await _gzip.FlushAsync().ConfigureAwait(false);
#if NETFRAMEWORK // .NETFramework 4.6.1 The stream can only be properly flushed via Dispose().  As a result, we must recreate the Stream after Flush/Dispose. See https://github.com/dotnet/runtime/issues/15371 for details.
            _gzip.Dispose();
            _gzip = new GZipStream(_stream, CompressionMode.Compress, true);
            JsonWriter.Reset(_gzip);
#endif
        }

        private sealed class BufferWriterStream : Stream
        {
            private readonly ArrayBufferWriter<byte> _writer;

            public BufferWriterStream(ArrayBufferWriter<byte> writer)
            {
                _writer = writer;
            }

            public override bool CanRead => false;
            public override bool CanSeek => false;
            public override bool CanWrite => true;
            public override long Length => _writer.WrittenCount;
            public override long Position
            {
                get => _writer.WrittenCount;
                set => throw new NotSupportedException();
            }

            public override void Flush() { }

            public override void Write(byte[] buffer, int offset, int count)
            {
                var span = _writer.GetSpan(count);
                buffer.AsSpan(offset, count).CopyTo(span);
                _writer.Advance(count);
            }

            public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
            public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
            public override void SetLength(long value) => throw new NotSupportedException();
        }
    }
}
