// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Keys.Cryptography
{
    internal static class ByteExtensions
    {
        internal static bool SequenceEqualConstantTime(this byte[] self, byte[] other)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (other == null)
                throw new ArgumentNullException(nameof(other));

            // Constant time comparison of two byte arrays
            uint difference = (uint)self.Length ^ (uint)other.Length;

            for (var i = 0; i < self.Length && i < other.Length; i++)
            {
                difference |= (uint)(self[i] ^ other[i]);
            }

            return difference == 0;
        }

        internal static byte[] Or(this byte[] self, byte[] other)
        {
            return Or(self, other, 0);
        }

        internal static byte[] Or(this byte[] self, byte[] other, int offset)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (self.Length > other.Length - offset)
                throw new ArgumentException("self and other lengths do not match");

            var result = new byte[self.Length];

            for (var i = 0; i < self.Length; i++)
            {
                result[i] = (byte)(self[i] | other[offset + i]);
            }

            return result;
        }

        internal static byte[] Xor(this byte[] self, byte[] other, bool inPlace = false)
        {
            return Xor(self, other, 0, inPlace);
        }

        internal static byte[] Xor(this byte[] self, byte[] other, int offset, bool inPlace = false)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (other == null)
                throw new ArgumentNullException(nameof(other));

            if (self.Length > other.Length - offset)
                throw new ArgumentException("self and other lengths do not match");

            byte[] result = (inPlace) ? self : new byte[self.Length];

            for (var i = 0; i < self.Length; i++)
            {
                result[i] = (byte)(self[i] ^ other[offset + i]);
            }

            return result;
        }

        internal static byte[] Take(this byte[] self, int count)
        {
            return Take(self, 0, count);
        }

        internal static byte[] Take(this byte[] self, int offset, int count)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (offset < 0)
                throw new ArgumentException($"{nameof(offset)} cannot be < 0", nameof(offset));

            if (count <= 0)
                throw new ArgumentException($"{nameof(count)} cannot be <= 0", nameof(count));

            if (offset + count > self.Length)
                throw new ArgumentException("offset + count cannot be > self.Length", nameof(count));

            // Return the same array if we want the same elements.
            if (offset == 0 && count == self.Length)
            {
                return self;
            }

            var result = new byte[count];

            Array.Copy(self, offset, result, 0, count);

            return result;
        }

        internal static void Zero(this byte[] self)
        {
            if (self == null)
                throw new ArgumentNullException(nameof(self));

            Array.Clear(self, 0, self.Length);
        }
    }
}
