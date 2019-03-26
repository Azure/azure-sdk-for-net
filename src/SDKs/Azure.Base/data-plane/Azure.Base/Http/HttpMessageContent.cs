// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Base.Buffers;
using System.Threading.Tasks;
using System.Threading;
using System.Buffers;

namespace Azure.Base.Http
{
    public abstract class HttpPipelineRequestContent : IDisposable
    {
        public static HttpPipelineRequestContent Create(Stream stream) => new StreamContent(stream);
        public static HttpPipelineRequestContent Create(byte[] bytes) => new ArrayContent(bytes, 0, bytes.Length);

        public static HttpPipelineRequestContent Create(byte[] bytes, int index, int length) => new ArrayContent(bytes, index, length);

        public static HttpPipelineRequestContent Create(ReadOnlyMemory<byte> bytes) => new MemoryContent(bytes);

        public static HttpPipelineRequestContent Create(ReadOnlySequence<byte> bytes) => new ReadOnlySequenceContent(bytes);

        public abstract Task WriteTo(Stream stream, CancellationToken cancellation);

        public abstract bool TryComputeLength(out long length);

        public abstract void Dispose();

        sealed class StreamContent : HttpPipelineRequestContent
        {
            Stream _stream;
            readonly long _origin;

            public StreamContent(Stream stream)
            {
                if (!stream.CanSeek) throw new ArgumentException("stream must be seekable", nameof(stream));
                _origin = stream.Position;
                _stream = stream;
            }

            public sealed override bool TryComputeLength(out long length)
            {
                if (_stream.CanSeek)
                {
                    length = _stream.Length - _origin;
                    return true;
                }
                length = 0;
                return false;
            }

            public sealed async override Task WriteTo(Stream stream, CancellationToken cancellation)
            {
                _stream.Seek(_origin, SeekOrigin.Begin);
                await _stream.CopyToAsync(stream, 81920, cancellation).ConfigureAwait(false);
                await stream.FlushAsync(cancellation).ConfigureAwait(false);
            }

            public override void Dispose()
            {
                _stream?.Dispose();
                _stream = null;
            }
        }

        sealed class ArrayContent : HttpPipelineRequestContent
        {
            readonly byte[] _bytes;
            readonly int _contentStart;
            readonly int _contentLength;

            public ArrayContent(byte[] bytes, int index, int length)
            {
                _bytes = bytes;
                _contentStart = index;
                _contentLength = length;
            }

            public ReadOnlyMemory<byte> Bytes => _bytes.AsMemory(_contentStart, _contentLength);

            public override void Dispose() { }

            public override bool TryComputeLength(out long length)
            {
                length = _contentLength;
                return true;
            }

            public async override Task WriteTo(Stream stream, CancellationToken cancellation)
                => await stream.WriteAsync(_bytes, _contentStart, _contentLength, cancellation).ConfigureAwait(false);
        }

        sealed class MemoryContent : HttpPipelineRequestContent
        {
            readonly ReadOnlyMemory<byte> _bytes;

            public MemoryContent(ReadOnlyMemory<byte> bytes)
                => _bytes = bytes;

            public ReadOnlyMemory<byte> Bytes => _bytes;

            public override void Dispose() { }

            public override bool TryComputeLength(out long length)
            {
                length = _bytes.Length;
                return true;
            }

            public async override Task WriteTo(Stream stream, CancellationToken cancellation)
                => await stream.WriteAsync(_bytes, cancellation).ConfigureAwait(false);
        }

        sealed class ReadOnlySequenceContent : HttpPipelineRequestContent
        {
            readonly ReadOnlySequence<byte> _bytes;

            public ReadOnlySequenceContent(ReadOnlySequence<byte> bytes)
                => _bytes = bytes;

            public ReadOnlySequence<byte> Bytes => _bytes;

            public override void Dispose() { }

            public override bool TryComputeLength(out long length)
            {
                length = _bytes.Length;
                return true;
            }

            public async override Task WriteTo(Stream stream, CancellationToken cancellation)
                => await stream.WriteAsync(_bytes, cancellation).ConfigureAwait(false);
        }
    }
}
