// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core;

internal partial class UnsafeBufferSequence
{
    //Only needed to restrict ctor access of Reader to BufferSequence
    private class ReaderInstance : Reader
    {
        public ReaderInstance(UnsafeBufferSegment[] buffers, int count)
            : base(buffers, count)
        {
        }
    }

    internal class Reader : IDisposable
    {
        private UnsafeBufferSegment[] _buffers;
        private int _count;
        private bool _isDisposed;
        private static readonly object _disposeLock = new object();

        private protected Reader(UnsafeBufferSegment[] buffers, int count)
        {
            _buffers = buffers;
            _count = count;
        }

        public long Length
        {
            get
            {
                if (_isDisposed)
                {
                    throw new ObjectDisposedException(nameof(Reader));
                }

                long result = 0;
                for (int i = 0; i < _count; i++)
                {
                    result += _buffers[i].Written;
                }
                return result;
            }
        }

        public void CopyTo(Stream stream, CancellationToken cancellation)
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            for (int i = 0; i < _count; i++)
            {
                cancellation.ThrowIfCancellationRequested();

                UnsafeBufferSegment buffer = _buffers[i];
                stream.Write(buffer.Array, 0, buffer.Written);
            }
        }

        public async Task CopyToAsync(Stream stream, CancellationToken cancellation)
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            for (int i = 0; i < _count; i++)
            {
                cancellation.ThrowIfCancellationRequested();

                UnsafeBufferSegment buffer = _buffers[i];
                await stream.WriteAsync(buffer.Array, 0, buffer.Written, cancellation).ConfigureAwait(false);
            }
        }

        public BinaryData ToBinaryData()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(nameof(Reader));
            }

            long length = Length;
            if (length > int.MaxValue)
            {
                throw new InvalidOperationException($"Length of serialized model is too long.  Value was {length} max is {int.MaxValue}");
            }
            using var stream = new MemoryStream((int)length);
            CopyTo(stream, default);
            return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
        }

        public void Dispose()
        {
            if (!_isDisposed)
            {
                lock (_disposeLock)
                {
                    if (!_isDisposed)
                    {
                        int buffersToReturnCount = _count;
                        var buffersToReturn = _buffers;
                        _count = 0;
                        _buffers = Array.Empty<UnsafeBufferSegment>();
                        for (int i = 0; i < buffersToReturnCount; i++)
                        {
                            ArrayPool<byte>.Shared.Return(buffersToReturn[i].Array);
                        }
                        _isDisposed = true;
                    }
                }
            }
        }
    }
}
