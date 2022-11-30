﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Messaging.WebPubSub.Clients
{
    internal sealed class MemoryBufferWriter : Stream, IBufferWriter<byte>
    {
        [ThreadStatic]
        private static MemoryBufferWriter _cachedInstance;

#if DEBUG
        private bool _inUse;
#endif

        private readonly int _minimumSegmentSize;
        private int _bytesWritten;

        private List<CompletedBuffer> _completedSegments;
        private byte[] _currentSegment;
        private int _position;

        public MemoryBufferWriter(int minimumSegmentSize = 4096)
        {
            _minimumSegmentSize = minimumSegmentSize;
        }

        public override long Length => _bytesWritten;
        public override bool CanRead => false;
        public override bool CanSeek => false;
        public override bool CanWrite => true;
        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        /// <summary>
        /// Use the thread local cached <see cref="MemoryBufferWriter"/> instance to write data synchronously.<br/>
        /// Please do <b>NOT</b> use <em>await</em> in the using scope.<br/>
        /// For <em>await</em> case, please create a new instance.
        /// </summary>
        public static LocalLease GetLocalLease() => new(Get());

        private static MemoryBufferWriter Get()
        {
            var writer = _cachedInstance;
            if (writer == null)
            {
                writer = new MemoryBufferWriter();
            }
            else
            {
                // Taken off the thread static
                _cachedInstance = null;
            }
#if DEBUG
            if (writer._inUse)
            {
                throw new InvalidOperationException("The reader wasn't returned!");
            }

            writer._inUse = true;
#endif

            return writer;
        }

        private static void Return(MemoryBufferWriter writer)
        {
            _cachedInstance = writer;
#if DEBUG
            writer._inUse = false;
#endif
            writer.Reset();
        }

        public void Reset()
        {
            if (_completedSegments != null)
            {
                for (var i = 0; i < _completedSegments.Count; i++)
                {
                    _completedSegments[i].Return();
                }

                _completedSegments.Clear();
            }

            if (_currentSegment != null)
            {
                ArrayPool<byte>.Shared.Return(_currentSegment);
                _currentSegment = null;
            }

            _bytesWritten = 0;
            _position = 0;
        }

        public void Advance(int count)
        {
            _bytesWritten += count;
            _position += count;
        }

        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            EnsureCapacity(sizeHint);

            return _currentSegment.AsMemory(_position, _currentSegment.Length - _position);
        }

        public Span<byte> GetSpan(int sizeHint = 0)
        {
            EnsureCapacity(sizeHint);

            return _currentSegment.AsSpan(_position, _currentSegment.Length - _position);
        }

        public void CopyTo(IBufferWriter<byte> destination)
        {
            if (_completedSegments != null)
            {
                // Copy completed segments
                var count = _completedSegments.Count;
                for (var i = 0; i < count; i++)
                {
                    destination.Write(_completedSegments[i].Span);
                }
            }

            destination.Write(_currentSegment.AsSpan(0, _position));
        }

        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            if (_completedSegments == null)
            {
                // There is only one segment so write without awaiting.
                return destination.WriteAsync(_currentSegment, 0, _position, cancellationToken);
            }

            return CopyToSlowAsync(destination);
        }

        private void EnsureCapacity(int sizeHint)
        {
            // This does the Right Thing. It only subtracts _position from the current segment length if it's non-null.
            // If _currentSegment is null, it returns 0.
            var remainingSize = _currentSegment?.Length - _position ?? 0;

            // If the sizeHint is 0, any capacity will do
            // Otherwise, the buffer must have enough space for the entire size hint, or we need to add a segment.
            if ((sizeHint == 0 && remainingSize > 0) || (sizeHint > 0 && remainingSize >= sizeHint))
            {
                // We have capacity in the current segment
                return;
            }

            AddSegment(sizeHint);
        }

        private void AddSegment(int sizeHint = 0)
        {
            if (_currentSegment != null)
            {
                // We're adding a segment to the list
                if (_completedSegments == null)
                {
                    _completedSegments = new List<CompletedBuffer>();
                }

                // Position might be less than the segment length if there wasn't enough space to satisfy the sizeHint when
                // GetMemory was called. In that case we'll take the current segment and call it "completed", but need to
                // ignore any empty space in it.
                _completedSegments.Add(new CompletedBuffer(_currentSegment, _position));
            }

            // Get a new buffer using the minimum segment size, unless the size hint is larger than a single segment.
            _currentSegment = ArrayPool<byte>.Shared.Rent(Math.Max(_minimumSegmentSize, sizeHint));
            _position = 0;
        }

        private async Task CopyToSlowAsync(Stream destination)
        {
            if (_completedSegments != null)
            {
                // Copy full segments
                var count = _completedSegments.Count;
                for (var i = 0; i < count; i++)
                {
                    var segment = _completedSegments[i];
                    await destination.WriteAsync(segment.Buffer, 0, segment.Length, CancellationToken.None).ConfigureAwait(false);
                }
            }
            await destination.WriteAsync(_currentSegment, 0, _position).ConfigureAwait(false);
        }

        public byte[] ToArray()
        {
            if (_currentSegment == null)
            {
                return Array.Empty<byte>();
            }

            var result = new byte[_bytesWritten];

            var totalWritten = 0;

            if (_completedSegments != null)
            {
                // Copy full segments
                var count = _completedSegments.Count;
                for (var i = 0; i < count; i++)
                {
                    var segment = _completedSegments[i];
                    segment.Span.CopyTo(result.AsSpan(totalWritten));
                    totalWritten += segment.Span.Length;
                }
            }

            // Copy current incomplete segment
            _currentSegment.AsSpan(0, _position).CopyTo(result.AsSpan(totalWritten));

            return result;
        }

        public void CopyTo(Span<byte> span)
        {
            Debug.Assert(span.Length >= _bytesWritten);

            if (_currentSegment == null)
            {
                return;
            }

            var totalWritten = 0;

            if (_completedSegments != null)
            {
                // Copy full segments
                var count = _completedSegments.Count;
                for (var i = 0; i < count; i++)
                {
                    var segment = _completedSegments[i];
                    segment.Span.CopyTo(span.Slice(totalWritten));
                    totalWritten += segment.Span.Length;
                }
            }

            // Copy current incomplete segment
            _currentSegment.AsSpan(0, _position).CopyTo(span.Slice(totalWritten));

            Debug.Assert(_bytesWritten == totalWritten + _position);
        }

        public override void Flush() { }
        public override Task FlushAsync(CancellationToken cancellationToken) => Task.CompletedTask;
        public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException();
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();
        public override void SetLength(long value) => throw new NotSupportedException();

        public override void WriteByte(byte value)
        {
            if (_currentSegment != null && (uint)_position < (uint)_currentSegment.Length)
            {
                _currentSegment[_position] = value;
            }
            else
            {
                AddSegment();
                _currentSegment[0] = value;
            }

            _position++;
            _bytesWritten++;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var position = _position;
            if (_currentSegment != null && position < _currentSegment.Length - count)
            {
                Buffer.BlockCopy(buffer, offset, _currentSegment, position, count);

                _position = position + count;
                _bytesWritten += count;
            }
            else
            {
                BuffersExtensions.Write(this, buffer.AsSpan(offset, count));
            }
        }

#if NETCOREAPP
        public override void Write(ReadOnlySpan<byte> span)
        {
            if (_currentSegment != null && span.TryCopyTo(_currentSegment.AsSpan(_position)))
            {
                _position += span.Length;
                _bytesWritten += span.Length;
            }
            else
            {
                BuffersExtensions.Write(this, span);
            }
        }
#endif

        public ReadOnlySequence<byte> AsReadOnlySequence()
        {
            if (_bytesWritten == 0)
            {
                return ReadOnlySequence<byte>.Empty;
            }
            Segment head = null;
            Segment current = null;
            if (_completedSegments != null)
            {
                foreach (var seg in _completedSegments)
                {
                    var next = new Segment(seg.Buffer, seg.Length);
                    if (current != null)
                    {
                        current.SetNext(next);
                        current = next;
                    }
                    else
                    {
                        current = next;
                        head = next;
                    }
                }
            }
            if (_position > 0)
            {
                var next = new Segment(_currentSegment, _position);
                if (current != null)
                {
                    current.SetNext(next);
                    current = next;
                }
                else
                {
                    current = next;
                    head = next;
                }
            }
            return new ReadOnlySequence<byte>(head, 0, current, current.Memory.Length);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Reset();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Holds a byte[] from the pool and a size value. Basically a Memory but guaranteed to be backed by an ArrayPool byte[], so that we know we can return it.
        /// </summary>
        private readonly struct CompletedBuffer
        {
            public byte[] Buffer { get; }
            public int Length { get; }

            public ReadOnlySpan<byte> Span => Buffer.AsSpan(0, Length);

            public CompletedBuffer(byte[] buffer, int length)
            {
                Buffer = buffer;
                Length = length;
            }

            public void Return()
            {
                ArrayPool<byte>.Shared.Return(Buffer);
            }
        }

        private sealed class Segment : ReadOnlySequenceSegment<byte>
        {
            public Segment(byte[] array, int count) => Memory = new ReadOnlyMemory<byte>(array, 0, count);

            internal void SetNext(Segment next)
            {
                Next = next;
                next.RunningIndex = RunningIndex + Memory.Length;
            }
        }

        public struct LocalLease : IDisposable
        {
            public LocalLease(MemoryBufferWriter writer) => Writer = writer;

            public MemoryBufferWriter Writer { get; }

            public void Dispose() => MemoryBufferWriter.Return(Writer);
        }
    }
}
