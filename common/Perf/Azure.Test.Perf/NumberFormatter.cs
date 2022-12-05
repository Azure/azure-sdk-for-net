// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Test.Perf
{
    public static class NumberFormatter
    {
        // Formats a number with a minimum number of significant digits.
        // Digits to the left of the decimal point are always significant.
        // Examples:
        // - Format(0, 4) -> "0.000"
        // - Format(12345, 4) -> "12,345"
        // - Format(1.2345, 4) -> "1.235"
        // - Format(0.00012345, 4) -> "0.0001235"
        public static string Format(double value, int minSignificantDigits, bool groupSeparator = true)
        {
            if (minSignificantDigits <= 0)
            {
                throw new ArgumentException("Must be greater than zero", nameof(minSignificantDigits));
            }

            // Special case since log(0) is undefined
            if (value == 0)
            {
                return value.ToString($"F{minSignificantDigits - 1}");
            }

            double log = Math.Log10(Math.Abs(value));
            int significantDigits = (int)Math.Max(Math.Ceiling(log), minSignificantDigits);

            double divisor = Math.Pow(10, Math.Ceiling(log) - significantDigits);
            double rounded = divisor * Math.Round(value / divisor, MidpointRounding.AwayFromZero);

            int decimals = (int)Math.Max(0, significantDigits - Math.Floor(log) - 1);

            return rounded.ToString(groupSeparator ? $"N{decimals}" : $"F{decimals}");
        }
    }
}
