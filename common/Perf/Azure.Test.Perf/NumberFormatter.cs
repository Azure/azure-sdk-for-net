// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Test.Perf
{
    public static class NumberFormatter
    {
        // Formats a double with the specified minimum number of significant digits.
        // Digits to the left of the decimal point are never dropped.
        // Examples:
        // - Format(12345, 4) -> "12,345"
        // - Format(1.2345, 4) -> "1.235"
        // - Format(0.00012345, 4) -> "0.0001234"
        public static string Format(double value, int minSignificantDigits, bool groupSeparator = true)
        {
            if (minSignificantDigits <= 0)
            {
                throw new ArgumentException("Must be greater than zero", nameof(minSignificantDigits));
            }

            // Signficant digits are undefined for the number zero, so hardcode to string "0".
            if (value == 0)
            {
                return "0";
            }

            double log = Math.Log10(Math.Abs(value));
            int significantDigits = (int)Math.Ceiling(Math.Max(log, minSignificantDigits));

            double divisor = Math.Pow(10, Math.Ceiling(log - significantDigits));
            double rounded = divisor * Math.Round(value / divisor, MidpointRounding.AwayFromZero);

            int decimals = (int)Math.Ceiling(Math.Max(0, significantDigits - log - 1));

            return groupSeparator ? rounded.ToString($"N{decimals}") : rounded.ToString($"F{decimals}");
        }
    }
}
