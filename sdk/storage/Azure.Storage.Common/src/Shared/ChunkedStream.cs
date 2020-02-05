// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;

namespace Azure.Storage.Shared
{
    internal readonly struct ChunkedStream : IDisposable
    {
        public ChunkedStream(long absolutePosition, byte[] bytes, int length, ArrayPool<byte> arrayPool)
        {
            AbsolutePosition = absolutePosition;
            Bytes = bytes;
            Length = length;
            ArrayPool = arrayPool;
        }

        public byte[] Bytes { get; }
        public int Length { get; }
        public ArrayPool<byte> ArrayPool { get; }
        public long AbsolutePosition { get; }

        public void Dispose()
        {
            ArrayPool.Return(Bytes);
        }
    }
}
