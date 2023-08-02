// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// A buffer writer which writes large sequences of data into smaller shared buffers.
    /// </summary>
    internal sealed class SequenceWriter : IBufferWriter<byte>, IDisposable
    {
        private struct Buffer
        {
            public byte[] Array;
            public int Written;
        }

        private Buffer[] _buffers; // this is an array so items can be accessed by ref
        private int _count;
        private int _bufferSize;

        /// <summary>
        /// Initializes a new instance of <see cref="SequenceWriter"/>.
        /// </summary>
        /// <param name="segmentSize">The size of each buffer segment.</param>
        public SequenceWriter(int segmentSize = 4096)
        {
            _bufferSize = segmentSize;
            _buffers = Array.Empty<Buffer>();
        }

        /// <summary>
        /// Notifies the <see cref="SequenceWriter"/> that bytes bytes were written to the output <see cref="Span{T}"/> or <see cref="Memory{T}"/>.
        /// You must request a new buffer after calling <see cref="Advance(int)"/> to continue writing more data; you cannot write to a previously acquired buffer.
        /// </summary>
        /// <param name="bytesWritten">The number of bytes written to the <see cref="Span{T}"/> or <see cref="Memory{T}"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Advance(int bytesWritten)
        {
            ref Buffer last = ref _buffers[_count - 1];
            last.Written += bytesWritten;
            if (last.Written > last.Array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(bytesWritten));
            }
        }

        /// <summary>
        /// Returns a <see cref="Memory{T}"/> to write to that is at least the requested size, as specified by the <paramref name="sizeHint"/> parameter.
        /// </summary>
        /// <param name="sizeHint">The minimum length of the returned <see cref="Memory{T}"/>. If less than 256, a buffer of size 256 will be returned.</param>
        /// <returns>A memory buffer of at least <paramref name="sizeHint"/> bytes. If <paramref name="sizeHint"/> is less than 256, a buffer of size 256 will be returned.</returns>
        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            if (sizeHint < 256)
                sizeHint = 256;

            int sizeToRent = sizeHint > _bufferSize ? sizeHint : _bufferSize;

            if (_buffers.Length == 0)
            {
                _buffers = new Buffer[1];
                _buffers[0].Array = ArrayPool<byte>.Shared.Rent(sizeToRent);
                _count = 1;
            }

            ref Buffer last = ref _buffers[_count - 1];
            var free = last.Array.AsMemory(last.Written);
            if (free.Length >= sizeHint)
                return free;

            // else allocate a new buffer:
            var newArray = ArrayPool<byte>.Shared.Rent(sizeToRent);

            // add buffer to _buffers
            if (_buffers.Length == _count)
            {
                // resize _buffers
                var resized = new Buffer[_buffers.Length * 2];
                _buffers.CopyTo(resized, 0);
                _buffers = resized;
            }

            _buffers[_count].Array = newArray;
            _count++;
            return newArray;
        }

        /// <summary>
        /// Returns a <see cref="Span{T}"/> to write to that is at least the requested size, as specified by the <paramref name="sizeHint"/> parameter.
        /// </summary>
        /// <param name="sizeHint">The minimum length of the returned <see cref="Span{T}"/>. If less than 256, a buffer of size 256 will be returned.</param>
        /// <returns>A buffer of at least <paramref name="sizeHint"/> bytes. If <paramref name="sizeHint"/> is less than 256, a buffer of size 256 will be returned.</returns>
        public Span<byte> GetSpan(int sizeHint = 0)
        {
            Memory<byte> memory = GetMemory(sizeHint);
            return memory.Span;
        }

        /// <summary>
        /// Disposes the SequenceWriter and returns the underlying buffers to the pool.
        /// </summary>
        public void Dispose()
        {
            // should we harden it? we really cannot afford use-after-free bugs. they might cause data corruption.
            // should we lock other members on this instance when we are disposing?
            int bufferCountToFree = _count;
            _count = 0;
            Buffer[] buffersToFree = _buffers;
            _buffers = Array.Empty<Buffer>();

            for (int i = 0; i < bufferCountToFree; i++)
            {
                ArrayPool<byte>.Shared.Return(buffersToFree[i].Array);
            }
        }

        /// <inheritdoc cref="RequestContent.TryComputeLength(out long)"/>
        public bool TryComputeLength(out long length)
        {
            length = 0;
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                length += buffer.Written;
            }
            return true;
        }

        /// <inheritdoc cref="RequestContent.WriteTo(Stream, CancellationToken)"/>
        public void CopyTo(Stream stream, CancellationToken cancellation)
        {
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                stream.Write(buffer.Array, 0, buffer.Written);
            }
        }

        /// <inheritdoc cref="RequestContent.WriteToAsync(Stream, CancellationToken)"/>
        public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                await stream.WriteAsync(buffer.Array, 0, buffer.Written).ConfigureAwait(false);
            }
        }
    }
}
