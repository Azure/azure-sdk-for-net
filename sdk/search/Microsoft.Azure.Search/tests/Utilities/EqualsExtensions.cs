// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace System
{
    using Linq;

    public static class EqualsExtensions
    {
        public static bool EqualsDouble(this double? x, double? y)
        {
            if (x == null)
            {
                return y == null;
            }

            if (double.IsNaN(x.Value))
            {
                return y != null && double.IsNaN(y.Value);
            }

            return x == y;
        }

        public static bool EqualsDateTimeOffset(this DateTimeOffset? a, DateTimeOffset? b)
        {
            if (a == null)
            {
                return b == null;
            }

            if (b == null)
            {
                return false;
            }

            if (a.Value.EqualsExact(b.Value))
            {
                return true;
            }

            // Allow for some loss of precision in the tick count.
            long aTicks = a.Value.UtcTicks;
            long bTicks = b.Value.UtcTicks;

            return (aTicks / 10000) == (bTicks / 10000);
        }

        public static bool EqualsNullSafe<T>(this T a, T b) where T : class => (a == null) ? b == null : a.Equals(b);

        public static bool SequenceEqualsNullSafe<T>(this T[] a, T[] b) =>
            (a == null) ? (b == null || b.Length == 0) : a.SequenceEqual(b ?? new T[0]);
    }
}
