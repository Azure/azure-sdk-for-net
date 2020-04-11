﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;

namespace Azure.Core.Tests.Buffers
{
    internal class BufferSegment : ReadOnlySequenceSegment<byte>
    {
        public BufferSegment(Memory<byte> memory)
        {
            Memory = memory;
        }

        public BufferSegment Append(Memory<byte> memory)
        {
            BufferSegment segment = new BufferSegment(memory)
            {
                RunningIndex = RunningIndex + Memory.Length
            };
            Next = segment;
            return segment;
        }
    }
}
