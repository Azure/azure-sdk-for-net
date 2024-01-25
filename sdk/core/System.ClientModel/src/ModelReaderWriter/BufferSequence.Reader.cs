// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Buffers;
using System.Diagnostics;

namespace System.ClientModel.Internal;

internal partial class BufferSequence
{
    //Only needed to restrict ctor access of Reader to BufferSequence
    private class ReaderInstance : Reader
    {
        public ReaderInstance(BufferSegment[] buffers, int count)
            : base(buffers, count)
        {
        }
    }

    internal class Reader : IDisposable
    {
        private readonly BufferSegment[] _buffers;
        private readonly int _count;
        private volatile int _isDisposed;
        private volatile int _copyCount;

        private protected Reader(BufferSegment[] buffers, int count)
        {
            _buffers = buffers;
            _count = count;
        }

        public bool TryComputeLength(out long length)
        {
            if (_isDisposed != 0)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            //no need to increment copy count since this is safe even if it happens while disposing
            length = 0;
            for (int i = 0; i < _count; i++)
            {
                length += _buffers[i].Written;
            }
            return true;
        }

        public void CopyTo(Stream stream, CancellationToken cancellation)
        {
            if (_isDisposed != 0)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            Interlocked.Increment(ref _copyCount);

            try
            {
                for (int i = 0; i < _count; i++)
                {
                    cancellation.ThrowIfCancellationRequested();

                    BufferSegment buffer = _buffers[i];
                    stream.Write(buffer.Array, 0, buffer.Written);
                }
            }
            finally
            {
                Interlocked.Decrement(ref _copyCount);
            }
        }

        public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            if (_isDisposed != 0)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            Interlocked.Increment(ref _copyCount);

            try
            {
                for (int i = 0; i < _count; i++)
                {
                    cancellation.ThrowIfCancellationRequested();

                    BufferSegment buffer = _buffers[i];
                    await stream.WriteAsync(buffer.Array, 0, buffer.Written, cancellation).ConfigureAwait(false);
                }
            }
            finally
            {
                Interlocked.Decrement(ref _copyCount);
            }
        }

        public BinaryData ToBinaryData()
        {
            if (_isDisposed != 0)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            Interlocked.Increment(ref _copyCount);

            try
            {
                bool gotLength = TryComputeLength(out long length);
                if (length > int.MaxValue)
                {
                    throw new InvalidOperationException($"Length of serialized model is too long.  Value was {length} max is {int.MaxValue}");
                }
                Debug.Assert(gotLength);
                using var stream = new MemoryStream((int)length);
                CopyTo(stream, default);
                return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
            }
            finally
            {
                Interlocked.Decrement(ref _copyCount);
            }
        }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref _isDisposed, 1) == 1)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            DateTime timeout = DateTime.Now.AddSeconds(30);
            while (_copyCount > 0)
            {
                if (DateTime.Now > timeout)
                {
                    throw new TimeoutException("Timeout waiting for readers to finish.");
                }
                Thread.Sleep(0);
            }

            for (int i = 0; i < _count; i++)
            {
                ArrayPool<byte>.Shared.Return(_buffers[i].Array);
            }
        }
    }
}
