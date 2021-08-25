// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage
{
    /// <summary>
    /// Private memory pool specific to Azure storage transfers, based on ArrayPool.
    /// </summary>
    internal class StorageMemoryPool : MemoryPool<byte>
    {
        private ArrayPool<byte> _arrayPool;

        public StorageMemoryPool(int maxArrayLength, int maxArraysPerBucket)
        {
            MaxBufferSize = maxArrayLength;
            _arrayPool = ArrayPool<byte>.Create(maxArrayLength, maxArraysPerBucket);
        }

        public override int MaxBufferSize { get; }

        public override IMemoryOwner<byte> Rent(int minBufferSize = -1)
        {
            lock (_arrayPool)
            {
                return new StorageMemoryOwner(this, minBufferSize);
            }
        }

        protected override void Dispose(bool disposing) => _arrayPool = default;

        private class StorageMemoryOwner : IMemoryOwner<byte>
        {
            public StorageMemoryOwner(StorageMemoryPool pool, int minimumLength)
            {
                _arrayPool = pool._arrayPool;
                Memory = _arrayPool.Rent(minimumLength);
            }

            private ArrayPool<byte> _arrayPool;

            public Memory<byte> Memory { get; private set; }

            #region IDisposable Support
            private bool _disposedValue; // To detect redundant calls

            public void Dispose()
            {
                if (!_disposedValue)
                {
                    _disposedValue = true;

                    _arrayPool.Return(Memory.ToArray());
                    _arrayPool = null;
                    Memory = null;
                }
            }
            #endregion
        }
    }
}
