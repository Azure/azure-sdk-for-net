// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Storage
{
    internal static partial class IHasherExtensions
    {
        /// <summary>
        /// Creates a new buffer with the current hash calculation and returns it.
        /// Note that some implementations have an explicit hash finalization step.
        /// Therefore this method should NOT be called to observe a partial calculation.
        /// </summary>
        public static Memory<byte> GetFinalHash(this IHasher hasher)
        {
            var checksum = new Memory<byte>(new byte[hasher.HashSizeInBytes]);
            hasher.GetFinalHash(checksum.Span);
            return checksum;
        }
    }
}
