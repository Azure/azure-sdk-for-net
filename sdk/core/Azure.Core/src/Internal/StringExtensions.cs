// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    internal static class StringExtensions
    {
        public static int IndexOfOrdinal(this string s, char c)
        {
#if NET5_0
            return s.IndexOf(c, StringComparison.Ordinal);
#else
            return s.IndexOf(c);
#endif
        }

        public static int GetHashCodeOrdinal(this string? s)
        {
            if (s == null) return 0;

#if NET5_0
            return s.GetHashCode(StringComparison.Ordinal);
#else
            return StringComparer.Ordinal.GetHashCode(s);
#endif
        }
    }
}
