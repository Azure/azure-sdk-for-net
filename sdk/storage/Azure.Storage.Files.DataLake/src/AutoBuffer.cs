// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;

namespace Azure.Storage.Files.DataLake
{
    internal class AutoBuffer : IDisposable
    {
        private bool _disposed;
        private byte[] _buffer;
        private int _size;

        public AutoBuffer(long size)
        {
            if (size > 0 && size <= Int32.MaxValue)
            {
                _size = Convert.ToInt32(size);
                _buffer = ArrayPool<byte>.Shared.Rent(_size);
            }
        }

        public AutoBuffer(double size) : this(Convert.ToInt64(size))
        {
        }

        public byte[] Buffer
        {
            get
            {
                return _buffer;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_size > 0)
                {
                    ArrayPool<byte>.Shared.Return(_buffer);
                }
            }

            _disposed = true;
        }
    }
}