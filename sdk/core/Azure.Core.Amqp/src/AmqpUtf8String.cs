// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;

namespace Azure.Core.Amqp
{
    /// <summary>
    /// Represents borrowed UTF-8 bytes that are encoded as an AMQP string.
    /// </summary>
    /// <remarks>
    /// The bytes are not copied. Keep them valid and unchanged until the operation
    /// using the value completes. When adding the value to a message batch, keep
    /// the bytes valid and unchanged until the batch is disposed.
    /// </remarks>
    public class AmqpUtf8String
    {
        private static readonly UTF8Encoding StrictUtf8 = new UTF8Encoding(false, true);

        private AmqpUtf8String(ReadOnlyMemory<byte> bytes)
        {
            Bytes = bytes;
        }

        /// <summary>Gets the borrowed UTF-8 bytes.</summary>
        public ReadOnlyMemory<byte> Bytes { get; }

        /// <summary>
        /// Creates an AMQP string from UTF-8 bytes without copying or decoding them
        /// into a managed string.
        /// </summary>
        /// <param name="bytes">The UTF-8 bytes to borrow.</param>
        /// <returns>A value that can be used in an AMQP application-property dictionary.</returns>
        /// <exception cref="ArgumentException">The bytes are not valid UTF-8.</exception>
        public static AmqpUtf8String FromBytes(ReadOnlyMemory<byte> bytes)
        {
            try
            {
                ValidateUtf8(bytes);
            }
            catch (DecoderFallbackException exception)
            {
                throw new ArgumentException("The bytes must contain valid UTF-8.", nameof(bytes), exception);
            }

            return new EncodedString(bytes);
        }

        private static unsafe void ValidateUtf8(ReadOnlyMemory<byte> bytes)
        {
            if (!bytes.IsEmpty)
            {
                fixed (byte* buffer = bytes.Span)
                {
                    StrictUtf8.GetCharCount(buffer, bytes.Length);
                }
            }
        }

        // A private subtype keeps the native serializer out of the public API and
        // allows each converter to pass through the same value without an adapter.
        private sealed class EncodedString : AmqpUtf8String, IAmqpSerializable
        {
            public EncodedString(ReadOnlyMemory<byte> bytes) : base(bytes)
            {
            }

            public int EncodeSize => checked(Bytes.Length + (Bytes.Length <= byte.MaxValue ? 2 : 5));

            public void Encode(ByteBuffer buffer)
            {
                ValidateUtf8(Bytes);
                AmqpBitConverter.WriteUByte(buffer, Bytes.Length <= byte.MaxValue ? (byte)0xA1 : (byte)0xB1);
                if (Bytes.Length <= byte.MaxValue)
                {
                    AmqpBitConverter.WriteUByte(buffer, (byte)Bytes.Length);
                }
                else
                {
                    AmqpBitConverter.WriteUInt(buffer, (uint)Bytes.Length);
                }

                if (Bytes.IsEmpty)
                {
                    return;
                }

                if (MemoryMarshal.TryGetArray(Bytes, out ArraySegment<byte> segment))
                {
                    AmqpBitConverter.WriteBytes(buffer, segment.Array!, segment.Offset, segment.Count);
                }
                else
                {
                    foreach (byte value in Bytes.Span)
                    {
                        AmqpBitConverter.WriteUByte(buffer, value);
                    }
                }
            }

            public void Decode(ByteBuffer buffer) =>
                throw new NotSupportedException("UTF-8 values are decoded as managed strings.");
        }
    }
}
