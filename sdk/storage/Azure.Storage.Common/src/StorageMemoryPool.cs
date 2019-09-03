// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Common;

namespace Azure.Storage
{
    /// <summary>
    /// Private memory pool specific to Azure storage transfers, based on ArrayPool.
    /// </summary>
    class StorageMemoryPool : MemoryPool<byte>
    {
        ArrayPool<byte> arrayPool;

        public StorageMemoryPool(int maxArrayLength, int maxArraysPerBucket)
        {
            this.MaxBufferSize = maxArrayLength;
            this.arrayPool = ArrayPool<byte>.Create(maxArrayLength, maxArraysPerBucket);
        }

        public override int MaxBufferSize { get; }

        public override IMemoryOwner<byte> Rent(int minBufferSize = -1)
        {
            lock (this.arrayPool)
            {
                return new StorageMemoryOwner(this, minBufferSize);
            }
        }

        protected override void Dispose(bool disposing) => this.arrayPool = default;

        class StorageMemoryOwner : IMemoryOwner<byte>
        {
            public StorageMemoryOwner(StorageMemoryPool pool, int minimumLength)
            {
                this.arrayPool = pool.arrayPool;
                this.Memory = this.arrayPool.Rent(minimumLength);
            }

            ArrayPool<byte> arrayPool;

            public Memory<byte> Memory { get; private set; }

            #region IDisposable Support
            private bool disposedValue = false; // To detect redundant calls

            public void Dispose()
            {
                if (!this.disposedValue)
                {
                    this.disposedValue = true;

                    this.arrayPool.Return(this.Memory.ToArray());
                    this.arrayPool = null;
                    this.Memory = null;
                }
            }
            #endregion
        }
    }
}
