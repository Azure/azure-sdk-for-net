// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Test.Perf
{
    public static class NumberFormatter
    {
        // Formats a positive double with the specified minimum number of significant digits.
        // Digits to the left of the decimal point are never dropped.
        // Examples:
        // - Format(12345, 4) -> "12,345"
        // - Format(1.2345, 4) -> "1.235"
        // - Format(0.00012345, 4) -> "0.0001234"
        public static string Format(double value, int minSignificantDigits)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Must be greater than zero", nameof(value));
            }

            if (minSignificantDigits <= 0)
            {
                throw new ArgumentException("Must be greater than zero", nameof(minSignificantDigits));
            }

            var log = Math.Log10(value);
            var significantDigits = Math.Ceiling(Math.Max(log, minSignificantDigits));

            var divisor = Math.Pow(10, Math.Ceiling(log - significantDigits));
            var rounded = divisor * Math.Round(value / divisor, MidpointRounding.AwayFromZero);

            var decimals = Math.Ceiling(Math.Max(0, significantDigits - log - 1));

            return rounded.ToString($"N{decimals}");
        }
    }
}
