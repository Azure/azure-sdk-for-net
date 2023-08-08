﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Serialization
{
    public sealed partial class ModelWriter : IDisposable
    {
        private sealed class SequenceBuilder : IBufferWriter<byte>, IDisposable
        {
            private struct Buffer
            {
                public byte[] Array;
                public int Written;
            }

            private volatile Buffer[] _buffers; // this is an array so items can be accessed by ref
            private volatile int _count;
            private int _segmentSize;

            /// <summary>
            /// Initializes a new instance of <see cref="SequenceBuilder"/>.
            /// </summary>
            /// <param name="segmentSize">The size of each buffer segment.</param>
            public SequenceBuilder(int segmentSize = 4096)
            {
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

            /// <inheritdoc cref="RequestContent.TryComputeLength(out long)"/>
            public bool TryComputeLength(out long length)
            {
                length = 0;
                for (int i = 0; i < _count; i++)
                {
                    length += _buffers[i].Written;
                }
                return true;
            }

            /// <inheritdoc cref="RequestContent.WriteTo(Stream, CancellationToken)"/>
            public void CopyTo(Stream stream, CancellationToken cancellation)
            {
                for (int i = 0; i < _count; i++)
                {
                    Buffer buffer = _buffers[i];
                    stream.Write(buffer.Array, 0, buffer.Written);
                }
            }

            /// <inheritdoc cref="RequestContent.WriteToAsync(Stream, CancellationToken)"/>
            public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
            {
                for (int i = 0; i < _count; i++)
                {
                    Buffer buffer = _buffers[i];
                    await stream.WriteAsync(buffer.Array, 0, buffer.Written).ConfigureAwait(false);
                }
            }
        }
    }
}
