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
    public sealed class SequenceWriter : IBufferWriter<byte>, IDisposable
    {
        private SequenceSegment? _first;
        private SequenceSegment? _last;

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
        /// <param name="bufferSize">The max size of each buffer segment.</param>
        public SequenceWriter(int bufferSize = 4096)
        {
            _bufferSize = bufferSize;
            _buffers = Array.Empty<Buffer>();
        }

        /// <inheritdoc/>
        public void Advance(int bytesWritten)
        {
            ref Buffer last = ref _buffers[_count - 1];
            last.Written += bytesWritten;
            if (last.Written > last.Array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(bytesWritten));
            }
        }

        /// <inheritdoc/>
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

            byte[] newArray = AddBuffer(sizeToRent);
            return newArray;
        }

        private byte[] AddBuffer(int sizeToRent)
        {
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

        /// <inheritdoc/>
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
            SequenceSegment? current = _first;
            while (current is not null)
            {
                var next = (SequenceSegment?)current.Next;
                current.Dispose();
                current = next;
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
        public void WriteTo(Stream stream, CancellationToken cancellation)
        {
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                stream.Write(buffer.Array, 0, buffer.Written);
            }
        }

        /// <inheritdoc cref="RequestContent.WriteToAsync(Stream, CancellationToken)"/>
        public async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            for (int i = 0; i < _count; i++)
            {
                var buffer = _buffers[i];
                await stream.WriteAsync(buffer.Array, 0, buffer.Written, cancellation).ConfigureAwait(false);
            }
        }

        private class SequenceSegment : ReadOnlySequenceSegment<byte>, IDisposable
        {
            public int Index { get; }

            public SequenceSegment(byte[] array, int length, long runningIndex, int index)
            {
                Memory = new Memory<byte>(array, 0, length);
                RunningIndex = runningIndex;
                Index = index;
            }

            public void Add(byte[] array, int length, int index)
            {
                Next = new SequenceSegment(array, length, RunningIndex + Memory.Length, index);
            }

            public void Dispose()
            {
                Memory = Memory<byte>.Empty;
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

            if (_first is null)
            {
                _first = new SequenceSegment(_buffers[0].Array, _buffers[0].Written, 0, 0);
                _last = _first;
            }

            if (_count == 1)
            {
                return new ReadOnlySequence<byte>(_first, 0, _first, _first.Memory.Length);
            }

            SequenceSegment current = _last!;

            for (int i = _last!.Index + 1; i < _count; i++)
            {
                if (i == _count - 1 && _buffers[i].Written == 0)
                    break;
                current!.Add(_buffers[i].Array, _buffers[i].Written, i);
                current = (SequenceSegment)current.Next!;
            }

            _last = current;

            // if there is anything written to the last buffer we need to add a new one to ensure previously returned sequences are not mutated
            if (_buffers[_count - 1].Written > 0)
                AddBuffer(_bufferSize);

            return new ReadOnlySequence<byte>(_first, 0, _last, _last.Memory.Length);
        }
    }
}
