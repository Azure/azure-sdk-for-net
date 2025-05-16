// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Azure.Messaging.EventHubs.Core
{
    /// <summary>
    ///   Allows events to be resolved to partitions using common patterns such as
    ///   round-robin assignment and hashing of partitions keys.
    /// </summary>
    ///
    internal class PartitionResolver
    {
        /// <summary>The index to use for automatic partition assignment.</summary>
        private int _partitionAssignmentIndex = -1;

        /// <summary>
        ///   Assigns a partition using a round-robin approach.
        /// </summary>
        ///
        /// <param name="partitions">The set of available partitions.</param>
        ///
        /// <returns>The zero-based index of the selected partition from the available set.</returns>
        ///
        public virtual string AssignRoundRobin(string[] partitions)
        {
            // At some point, overflow is possible; ensure that the increment is
            // unchecked to allow rollover without an exception.

            unchecked
            {
                var index = Interlocked.Increment(ref _partitionAssignmentIndex);

                // If the increment rolls over to a negative value, attempt to reset to 0.
                //
                // If the exchange is successful, the return from the call will match the
                // original overflow value; in this case, the local index can safely be set to 0.
                //
                // If the call returns another value, a different caller has reset the assignment
                // index, and another increment is needed to avoid duplication for the local index.
                //
                // It is possible (though incredibly unlikely) that the assignment index will overflow
                // negative again after the exchange/increment.  To guard against that scenario, the
                // reset is performed in a loop.
                //
                // Rolling over can create a slightly unfair distribution due to the sequence changing,
                // but avoids corner-case errors with negative values not aligning to a valid index range.

                while (index < 0)
                {
                    var original = index;

                    index = Interlocked.CompareExchange(ref _partitionAssignmentIndex, 0, index);
                    index = (index == original) ? 0 : Interlocked.Increment(ref _partitionAssignmentIndex);
                }

                return partitions[(index % partitions.Length)];
            }
        }

        /// <summary>
        ///   Assigns a partition using a hash-based approach based on the provided
        ///   <paramref name="partitionKey" />.
        /// </summary>
        ///
        /// <param name="partitionKey">The partition key to use as the basis for partition assignment.</param>
        /// <param name="partitions">The set of available partitions.</param>
        ///
        /// <returns>The zero-based index of the selected partition from the available set.</returns>
        ///
        public virtual string AssignForPartitionKey(string partitionKey,
                                                    string[] partitions)
        {
            var hashValue = GenerateHashCode(partitionKey);
            return partitions[Math.Abs(hashValue % partitions.Length)];
        }

        /// <summary>
        ///   Generates a hash code for a partition key using Jenkins' lookup3 algorithm.
        /// </summary>
        ///
        /// <param name="partitionKey">The partition key to generate a hash code for.</param>
        ///
        /// <returns>The generated hash code.</returns>
        ///
        /// <remarks>
        ///   This implementation is a direct port of the Event Hubs service code; it is intended to match
        ///   the gateway hashing algorithm as closely as possible and should not be adjusted without careful
        ///   consideration.
        /// </remarks>
        ///
        [SkipLocalsInit]
        private static short GenerateHashCode(string partitionKey)
        {
            if (partitionKey == null)
            {
                return 0;
            }

            const int MaxStackLimit = 256;

            byte[] sharedBuffer = null;

            var partitionKeySpan = partitionKey.AsSpan();
            var encoding = Encoding.UTF8;
            var partitionKeyByteLength = encoding.GetMaxByteCount(partitionKey.Length);

            var hashBuffer = partitionKeyByteLength <= MaxStackLimit ?
                stackalloc byte[MaxStackLimit] :
                sharedBuffer = ArrayPool<byte>.Shared.Rent(partitionKeyByteLength);

            var written = encoding.GetBytes(partitionKeySpan, hashBuffer);

            ComputeHash(hashBuffer.Slice(0, written), seed1: 0, seed2: 0, out uint hash1, out uint hash2);

            if (sharedBuffer != null)
            {
                ArrayPool<byte>.Shared.Return(sharedBuffer);
            }

            return (short)(hash1 ^ hash2);
        }

        /// <summary>
        ///   Computes a hash value using Jenkins' lookup3 algorithm.
        /// </summary>
        ///
        /// <param name="data">The data to base the hash on.</param>
        /// <param name="seed1">A seed value for the first hash.</param>
        /// <param name="seed2">A seed value for the second hash.</param>
        /// <param name="hash1">The first computed hash for the <paramref name="data" />.</param>
        /// <param name="hash2">The second computed hash for the <paramref name="data" />.</param>
        ///
        /// <remarks>
        ///   This implementation is a direct port of the Event Hubs service code; it is intended to match
        ///   the gateway hashing algorithm as closely as possible and should not be adjusted without careful
        ///   consideration.
        /// </remarks>
        ///
        private static void ComputeHash(ReadOnlySpan<byte> data,
                                        uint seed1,
                                        uint seed2,
                                        out uint hash1,
                                        out uint hash2)
        {
            uint len = (uint)data.Length;
            uint a = 0xDEADBEEF + len + seed1;
            uint b = a;
            uint c = a + seed2;

            int chunks = data.Length > 12 ? (data.Length - 1) / 12 : 0;

            ref byte ptr = ref MemoryMarshal.GetReference(data);
            for (int i = 0; i < chunks; i++)
            {
                uint w0 = Unsafe.ReadUnaligned<uint>(ref ptr);
                uint w1 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref ptr, 4));
                uint w2 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref ptr, 8));
                ptr = ref Unsafe.Add(ref ptr, 12);

                if (!BitConverter.IsLittleEndian)
                {
                    w0 = BinaryPrimitives.ReverseEndianness(w0);
                    w1 = BinaryPrimitives.ReverseEndianness(w1);
                    w2 = BinaryPrimitives.ReverseEndianness(w2);
                }

                a += w0;
                b += w1;
                c += w2;

                a -= c;
                a ^= (c << 4) | (c >> 28);
                c += b;

                b -= a;
                b ^= (a << 6) | (a >> 26);
                a += c;

                c -= b;
                c ^= (b << 8) | (b >> 24);
                b += a;

                a -= c;
                a ^= (c << 16) | (c >> 16);
                c += b;

                b -= a;
                b ^= (a << 19) | (a >> 13);
                a += c;

                c -= b;
                c ^= (b << 4) | (b >> 28);
                b += a;
            }

            int consumed = chunks * 12;
            ref byte tail = ref Unsafe.Add(ref MemoryMarshal.GetReference(data), consumed);
            int left = data.Length - consumed;
            switch (left)
            {
                case 12:
                    a += BitConverter.IsLittleEndian ? Unsafe.ReadUnaligned<uint>(ref tail) : BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref tail));
                    b += BitConverter.IsLittleEndian ? Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref tail, 4)) : BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref tail, 4)));
                    c += BitConverter.IsLittleEndian ? Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref tail, 8)) : BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref tail, 8)));
                    break;
                case 11:
                    c += (uint)Unsafe.Add(ref tail, 10) << 16;
                    goto case 10;
                case 10:
                    c += (uint)Unsafe.Add(ref tail, 9) << 8;
                    goto case 9;
                case 9:
                    c += Unsafe.Add(ref tail, 8);
                    goto case 8;
                case 8:
                    b += BitConverter.IsLittleEndian ? Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref tail, 4)) : BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref tail, 4)));
                    a += BitConverter.IsLittleEndian ? Unsafe.ReadUnaligned<uint>(ref tail) : BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref tail));
                    break;
                case 7:
                    b += (uint)Unsafe.Add(ref tail, 6) << 16;
                    goto case 6;
                case 6:
                    b += (uint)Unsafe.Add(ref tail, 5) << 8;
                    goto case 5;
                case 5:
                    b += Unsafe.Add(ref tail, 4);
                    goto case 4;
                case 4:
                    a += BitConverter.IsLittleEndian ? Unsafe.ReadUnaligned<uint>(ref tail) : BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref tail));
                    break;
                case 3:
                    a += (uint)Unsafe.Add(ref tail, 2) << 16;
                    goto case 2;
                case 2:
                    a += (uint)Unsafe.Add(ref tail, 1) << 8;
                    goto case 1;
                case 1:
                    a += Unsafe.Add(ref tail, 0);
                    break;
                case 0:
                    hash1 = c;
                    hash2 = b;
                    return;
            }

            c ^= b;
            c -= (b << 14) | (b >> 18);

            a ^= c;
            a -= (c << 11) | (c >> 21);

            b ^= a;
            b -= (a << 25) | (a >> 7);

            c ^= b;
            c -= (b << 16) | (b >> 16);

            a ^= c;
            a -= (c << 4) | (c >> 28);

            b ^= a;
            b -= (a << 14) | (a >> 18);

            c ^= b;
            c -= (b << 24) | (b >> 8);

            hash1 = c;
            hash2 = b;
        }
    }
}
