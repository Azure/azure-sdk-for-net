// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Buffers;
using System.Runtime.CompilerServices;

namespace Azure.ApplicationModel.Configuration
{
    // TODO (pri 3): CoreFx will soon have a type like this. We should remove this one then.
    internal class FixedSizedBufferWriter : IBufferWriter<byte>
    {
        private readonly byte[] _buffer;
        private int _count;

        public FixedSizedBufferWriter(byte[] buffer)
        {
            _buffer = buffer;
        }

        public Memory<byte> GetMemory(int minimumLength = 0) => _buffer.AsMemory(_count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> GetSpan(int minimumLength = 0) => _buffer.AsSpan(_count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Advance(int bytes)
        {
            _count += bytes;
            if (_count > _buffer.Length)
            {
                throw new InvalidOperationException("Cannot advance past the end of the buffer.");
            }
        }
    }
}
