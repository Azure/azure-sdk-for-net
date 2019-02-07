// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.Buffers
{
    /// <summary>
    /// Sequence<typeparamref name="T"/> is a builder of a sequence of buffers/arrays rented from a buffer pool
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <remarks>Be very careful when disposing Sequence<typeparamref name="T"/>. Calling a dispose on a sequence copy will result in pool corruption.</remarks>
    struct Sequence<T> : IBufferWriter<T>
    {
        const int DefaultLength = 4096;

        T[] _buffer; // this is just an optimization for the case where the sequence has one segment. otherwise all could be stored in the segment fields below.
        int _commited;
        Segment<T> _first;
        Segment<T> _last;

        ArrayPool<T> _pool;

        public Sequence(ArrayPool<T> pool)
        {
            _pool = pool;
            _buffer = default;
            _commited = default;
            _first = default;
            _last = default;
        }

        #region IBufferWriter<T> implementations
        public Memory<T> GetMemory(int minimumLength = 0)
        {
            if (_buffer == null) {
                _buffer = _pool.Rent(Math.Max(minimumLength, DefaultLength));
                Debug.Assert(_buffer.Length >= minimumLength);
                _commited = 0;
                return _buffer;
            }

            if(_buffer.Length - _commited >= minimumLength) {
                return _buffer.AsMemory(_commited);
            }

            if (_first == null) {
                _first = new Segment<T>(_buffer, 0, _commited);
                _last = _first;
            }
            else {
                _last = _last.Append(_buffer, 0, _commited);
            }

            _commited = 0;
            _buffer = null;
            return GetMemory(minimumLength);
        }

        public Span<T> GetSpan(int minimumLength = 0)
        {
            if (_buffer == null)
            {
                _buffer = _pool.Rent(Math.Max(minimumLength, DefaultLength));
                Debug.Assert(_buffer.Length >= minimumLength);
                _commited = 0;
                return _buffer;
            }

            if (_buffer.Length - _commited >= minimumLength)
            {
                return _buffer.AsSpan(_commited);
            }

            if (_first == null)
            {
                _first = new Segment<T>(_buffer, 0, _commited);
                _last = _first;
            }
            else
            {
                _last = _last.Append(_buffer, 0, _commited);
            }

            _commited = 0;
            _buffer = null;
            return GetSpan(minimumLength);
        }

        public void Advance(int count)
        {
            Debug.Assert(_buffer != null);
            _commited += count;
            if (_commited > _buffer.Length) throw new ArgumentOutOfRangeException(nameof(count));
        }
        #endregion

        public void Dispose()
        {
            var buffer = Interlocked.Exchange(ref _buffer, null);
            if (buffer != default) {
                _pool.Return(buffer);
            }

            _first?.Dispose(_pool);
            _first = default;
            _last = default;
            _commited = default;
        }

        public ReadOnlySequence<T> AsReadOnly()
        {
            if (_first == null) {
                if (_buffer == null) {
                    return ReadOnlySequence<T>.Empty;
                }
                return new ReadOnlySequence<T>(_buffer, 0, _commited);
            }

            if (_buffer != null) {
                _last = _last.Append(_buffer, 0, _commited);
                _buffer = null;
                _commited = 0;
            }
            return new ReadOnlySequence<T>(_first, 0, _last, _last.Memory.Length);
        }

        public long Length {
            get {
                if (_buffer == null) return 0;
                if (_first == null) return _commited;
                return _last.RunningIndex + _last.Memory.Length + _commited;
            }
        }

        public bool IsSingleSegment => _first == null;
    
        // TODO (pri 2): this is a very inneficient implementation.
        public static Sequence<T> Merge(ref Sequence<T> first, ref Sequence<T> second)
        {
            int total;
            checked {
                total = (int)(first.Length + second.Length);
                var array = first._pool.Rent(total);
                first.AsReadOnly().CopyTo(array);
                second.AsReadOnly().CopyTo(array.AsSpan((int)first.Length));
                var result = new Sequence<T>(first._pool);
                result._buffer = array;
                result._commited = total;
                first.Dispose();
                second.Dispose();
                return result;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            if (_commited == 0) return string.Empty;
            var bytes = _buffer as byte[];
            if (bytes != null)
            {
                return Encoding.UTF8.GetString(bytes, 0, _commited);
            }
            return $"{Length}";
        }
    }

    static class SequenceExtensions
    {
        public static async Task<Sequence<byte>> ReadAsync(this Stream stream, Sequence<byte> buffer, CancellationToken cancellation)
        {
            var memory = buffer.GetMemory();
            if (!MemoryMarshal.TryGetArray(memory, out ArraySegment<byte> segment))
            {
                throw new NotImplementedException();
            }
            var read = await stream.ReadAsync(segment.Array, 0, segment.Count, cancellation).ConfigureAwait(false);
            buffer.Advance(read);
            return buffer;
        }
    }

    sealed class Segment<T> : ReadOnlySequenceSegment<T>
    {
        T[] _buffer; // Do not access the buffer without ensuring synchronization with Dispose.

        public Segment(T[] buffer, int index, int count)
        {
            _buffer = buffer;
            Memory = _buffer.AsMemory(index, count);
        }

        public Segment<T> Append(T[] buffer, int index, int count)
        {
            var next = new Segment<T>(buffer, index, count);
            next.RunningIndex = RunningIndex + Memory.Length;
            Next = next;
            return next;
        }

        public void Dispose(ArrayPool<T> pool)
        {
            var buffer = Interlocked.Exchange(ref _buffer, null);
            if (buffer != null)
            {
                pool.Return(buffer);
                RunningIndex = 0;
            }
            Debug.Assert(RunningIndex == 0);

            // The following must be called, even if this._buffer was already Disposed (was null).
            // This is to ensure that when Dispose returns, all segments had been returned to the pool.
            // i.e. don't put the calls below inside the if block above.
            var next = Next as Segment<T>;
            Next = null;
            if (next != null) next.Dispose(pool);
        }
    }
}
