// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives;

public partial struct AdditionalProperties
{
    // Custom equality comparer for byte arrays to enable content-based comparison
    private sealed class ByteArrayEqualityComparer : IEqualityComparer<byte[]>
    {
        public static readonly ByteArrayEqualityComparer Instance = new();

        public bool Equals(byte[]? x, byte[]? y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x is null || y is null)
                return false;
            return x.AsSpan().SequenceEqual(y.AsSpan());
        }

        public int GetHashCode(byte[] obj)
        {
            if (obj is null)
                return 0;

            // Simple hash code implementation for byte arrays
#if NET8_0_OR_GREATER
            var hash = new HashCode();
            hash.AddBytes(obj);
            return hash.ToHashCode();
#else
            unchecked
            {
                int hash = 17;
                for (int i = 0; i < obj.Length; i++)
                {
                    hash = hash * 31 + obj[i];
                }
                return hash;
            }
#endif
        }
    }
}
