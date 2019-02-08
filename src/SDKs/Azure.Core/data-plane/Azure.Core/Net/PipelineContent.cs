// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core.Buffers;
using System.Threading.Tasks;
using System.Threading;

namespace Azure.Core.Http
{
    public abstract class PipelineContent : IDisposable
    {
        public static PipelineContent Create(Stream stream) => new StreamContent(stream);
        public static PipelineContent Create(byte[] bytes) => new ArrayContent(bytes, 0, bytes.Length);

        public static PipelineContent Create(byte[] bytes, int index, int length) => new ArrayContent(bytes, index, length);

        public static PipelineContent Create(ReadOnlyMemory<byte> bytes) => new MemoryContent(bytes);

        public abstract Task WriteTo(Stream stream, CancellationToken cancellation); // TODO (pri 1): should this support cancellations

        public abstract bool TryComputeLength(out long length);

        public abstract void Dispose();

        sealed class StreamContent : PipelineContent
        {
            Stream _stream;

            public StreamContent(Stream stream)
            {
                if (!stream.CanSeek) throw new ArgumentException("stream must be seekable", nameof(stream));
                _stream = stream;
            }

            public sealed override bool TryComputeLength(out long length)
            {
                if (_stream.CanSeek)
                {
                    length = _stream.Length;
                    return true;
                }
                length = 0;
                return false;
            }

            public sealed async override Task WriteTo(Stream stream, CancellationToken cancellation)
            {
                _stream.Seek(0, SeekOrigin.Begin);
                await _stream.CopyToAsync(stream, 81920, cancellation).ConfigureAwait(false);
                await stream.FlushAsync().ConfigureAwait(false);
            }

            public override void Dispose()
            {
                _stream?.Dispose();
                _stream = null;
            }
        }

        sealed class ArrayContent : PipelineContent
        {
            byte[] _bytes;
            int _contentStart;
            int _contentLength;

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
            {
                await stream.WriteAsync(_bytes, _contentStart, _contentLength, cancellation);
            }
        }

        sealed class MemoryContent : PipelineContent
        {
            ReadOnlyMemory<byte> _bytes;

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
                => await stream.WriteAsync(_bytes, cancellation);
        }
    }
}
