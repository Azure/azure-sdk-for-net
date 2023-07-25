﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    /// <summary>
    /// .
    /// </summary>
    public sealed class SequenceWriter : IBufferWriter<byte>, IDisposable
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
        /// .
        /// </summary>
        /// <param name="bufferSize"></param>
        public SequenceWriter(int bufferSize = 4096)
        {
            _bufferSize = bufferSize;
            _buffers = Array.Empty<Buffer>();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="bytesWritten"></param>
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
        /// .
        /// </summary>
        /// <param name="sizeHint"></param>
        /// <returns></returns>
        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            if (sizeHint < 256)
                sizeHint = 256;

            if (_buffers.Length == 0)
            {
                _buffers = new Buffer[1];
                _buffers[0].Array = ArrayPool<byte>.Shared.Rent(_bufferSize);
                _count = 1;
            }

            ref Buffer last = ref _buffers[_count - 1];
            var free = last.Array.AsMemory(last.Written);
            if (free.Length >= sizeHint)
                return free;

            // else allocate a new buffer:
            var newArray = ArrayPool<byte>.Shared.Rent(_bufferSize);

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
        /// .
        /// </summary>
        /// <param name="sizeHint"></param>
        /// <returns></returns>
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
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                ArrayPool<byte>.Shared.Return(buffer.Array);
            }
            _buffers = Array.Empty<Buffer>();
            _count = 0;
        }

        /// <summary>
        /// Compute the length of the data written to the SequenceWriter.
        /// </summary>
        /// <param name="length"> The length of the buffer returned. </param>
        /// <returns> A bool indicating whether or not the length was able to be calculated. </returns>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellation"></param>
        public void WriteTo(Stream stream, CancellationToken cancellation)
        {
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                stream.Write(buffer.Array, 0, buffer.Written);
            }
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                await stream.WriteAsync(buffer.Array, 0, buffer.Written).ConfigureAwait(false);
            }
        }

        private class MultiBufferSegment : ReadOnlySequenceSegment<byte>
        {
            public MultiBufferSegment(byte[] array, int length, long runningIndex)
            {
                Memory = new Memory<byte>(array, 0, length);
                RunningIndex = runningIndex;
            }

            public void Add(byte[] array, int length)
            {
                Next = new MultiBufferSegment(array, length, RunningIndex + Memory.Length);
            }
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns></returns>
        public ReadOnlySequence<byte> GetReadOnlySequence()
        {
            if (_count == 0)
                return ReadOnlySequence<byte>.Empty;

            if (_count == 1)
                return new ReadOnlySequence<byte>(_buffers[0].Array, 0, _buffers[0].Written);

            MultiBufferSegment first = new MultiBufferSegment(_buffers[0].Array, _buffers[0].Written, 0);
            MultiBufferSegment previous = first;
            for (int i = 1; i < _count; i++)
            {
                previous!.Add(_buffers[i].Array, _buffers[i].Written);
                previous = (MultiBufferSegment)previous.Next!;
            }

            return new ReadOnlySequence<byte>(first, 0, previous, previous.Memory.Length);
        }
    }
}
