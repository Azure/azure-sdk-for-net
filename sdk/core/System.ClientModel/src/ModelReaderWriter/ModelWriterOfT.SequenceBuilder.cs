﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace System.ClientModel.Internal
{
    internal partial class ModelWriter<T> : IDisposable
    {
        /// <summary>
        /// This class is a helper to write to a <see cref="IBufferWriter{T}"/> in a thread safe manner.
        /// It uses the shared pool to allocate buffers and returns them to the pool when disposed.
        /// Since there is no way to ensure someone didn't keep a reference to one of the buffers
        /// it must be disposed of in the same context it was created and its referenced should not be stored or shared.
        /// </summary>
        private sealed class SequenceBuilder : IBufferWriter<byte>, IDisposable
        {
            private struct Buffer
            {
                public byte[] Array;
                public int Written;
            }

            private volatile Buffer[] _buffers; // this is an array so items can be accessed by ref
            private volatile int _count;
            private readonly int _segmentSize;

            /// <summary>
            /// Initializes a new instance of <see cref="SequenceBuilder"/>.
            /// </summary>
            /// <param name="segmentSize">The size of each buffer segment.</param>
            public SequenceBuilder(int segmentSize = 16384)
            {
                // we perf tested a very large and a small model and found that the performance
                // for 4k, 8k, 16k, 32k, was neglible for the small model but had a 30% alloc improvment
                // from 4k to 16k on the very large model.
                _segmentSize = segmentSize;
                _buffers = Array.Empty<Buffer>();
            }

            /// <summary>
            /// Notifies the <see cref="SequenceBuilder"/> that bytes bytes were written to the output <see cref="Span{T}"/> or <see cref="Memory{T}"/>.
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
                {
                    sizeHint = 256;
                }

                int sizeToRent = sizeHint > _segmentSize ? sizeHint : _segmentSize;

                if (_buffers.Length == 0)
                {
                    ExpandBuffers(sizeToRent);
                }

                ref Buffer last = ref _buffers[_count - 1];
                Memory<byte> free = last.Array.AsMemory(last.Written);
                if (free.Length >= sizeHint)
                {
                    return free;
                }

                // else allocate a new buffer:
                ExpandBuffers(sizeToRent);

                return _buffers[_count - 1].Array;
            }

            private readonly object _lock = new object();
            private void ExpandBuffers(int sizeToRent)
            {
                lock (_lock)
                {
                    int bufferCount = _count == 0 ? 1 : _count * 2;

                    Buffer[] resized = new Buffer[bufferCount];
                    if (_count > 0)
                    {
                        _buffers.CopyTo(resized, 0);
                    }
                    _buffers = resized;
                    _buffers[_count].Array = ArrayPool<byte>.Shared.Rent(sizeToRent);
                    _count = bufferCount == 1 ? bufferCount : _count + 1;
                }
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
                int bufferCountToFree;
                Buffer[] buffersToFree;
                lock (_lock)
                {
                    bufferCountToFree = _count;
                    buffersToFree = _buffers;
                    _count = 0;
                    _buffers = Array.Empty<Buffer>();
                }

                for (int i = 0; i < bufferCountToFree; i++)
                {
                    ArrayPool<byte>.Shared.Return(buffersToFree[i].Array);
                }
            }

            public bool TryComputeLength(out long length)
            {
                length = 0;
                for (int i = 0; i < _count; i++)
                {
                    length += _buffers[i].Written;
                }
                return true;
            }

            public void CopyTo(Stream stream, CancellationToken cancellation)
            {
                for (int i = 0; i < _count; i++)
                {
                    cancellation.ThrowIfCancellationRequested();

                    Buffer buffer = _buffers[i];
                    stream.Write(buffer.Array, 0, buffer.Written);
                }
            }

            public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
            {
                for (int i = 0; i < _count; i++)
                {
                    cancellation.ThrowIfCancellationRequested();

                    Buffer buffer = _buffers[i];
                    await stream.WriteAsync(buffer.Array, 0, buffer.Written, cancellation).ConfigureAwait(false);
                }
            }
        }
    }
}
