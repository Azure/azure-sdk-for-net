// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Copied from https://github.com/aspnet/Extensions/tree/master/src/Primitives/src

using System;
using System.Collections.Generic;

namespace Azure.Core.Http.Multipart
{
    internal class StringSegmentComparer : IComparer<StringSegment>, IEqualityComparer<StringSegment>
    {
        public static StringSegmentComparer Ordinal { get; }
            = new StringSegmentComparer(StringComparison.Ordinal, StringComparer.Ordinal);

        public static StringSegmentComparer OrdinalIgnoreCase { get; }
            = new StringSegmentComparer(StringComparison.OrdinalIgnoreCase, StringComparer.OrdinalIgnoreCase);

        private StringSegmentComparer(StringComparison comparison, StringComparer comparer)
        {
            Comparison = comparison;
            Comparer = comparer;
        }

        private StringComparison Comparison { get; }
        private StringComparer Comparer { get; }

        public int Compare(StringSegment x, StringSegment y)
        {
            return StringSegment.Compare(x, y, Comparison);
        }

        public bool Equals(StringSegment x, StringSegment y)
        {
            return StringSegment.Equals(x, y, Comparison);
        }

        public int GetHashCode(StringSegment obj)
        {
#if NETCOREAPP
            return string.GetHashCode(obj.AsSpan(), Comparison);
#else
            if (!obj.HasValue)
            {
                return 0;
            }

            // .NET Core strings use randomized hash codes for security reasons. Consequently we must materialize the StringSegment as a string
            return Comparer.GetHashCode(obj.Value);
#endif
        }
    }
}
