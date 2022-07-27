// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;

namespace Azure.Test.Perf
{
    public static class NumberFormatter
    {
        // Formats a positive double with the specified number of significant digits
        // Example: Format(Math.PI, 4) -> "3.142"
        public static string Format(double value, int significantDigits)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Must be greater than zero", nameof(value));
            }

            if (significantDigits <= 0)
            {
                throw new ArgumentException("Must be greater than zero", nameof(significantDigits));
            }

            var log = Math.Log10(value);
            var divisor = Math.Pow(10, Math.Ceiling(log - significantDigits));
            var rounded = divisor * Math.Round(value / divisor, MidpointRounding.AwayFromZero);

            var decimals = Math.Ceiling(Math.Max(0, significantDigits - log - 1));

            return rounded.ToString($"N{decimals}");
        }
    }
}
