// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System;

namespace Azure.Test.Perf.Tests
{
    public class NumberFormatterTests
    {
        // Standard Tests
        [TestCase(0.00012345, 1, "0.0001")]
        [TestCase(0.00012345, 2, "0.00012")]
        [TestCase(0.00012345, 3, "0.000123")]
        [TestCase(0.00012345, 4, "0.0001235")]
        [TestCase(0.00012345, 5, "0.00012345")]
        [TestCase(0.00012345, 6, "0.000123450")]
        [TestCase(0.00012345, 7, "0.0001234500")]
        [TestCase(1.2345, 1, "1")]
        [TestCase(1.2345, 2, "1.2")]
        [TestCase(1.2345, 3, "1.23")]
        [TestCase(1.2345, 4, "1.235")]
        [TestCase(1.2345, 5, "1.2345")]
        [TestCase(1.2345, 6, "1.23450")]
        [TestCase(1.2345, 7, "1.234500")]
        [TestCase(12_345, 1, "12,345")]
        [TestCase(12_345, 2, "12,345")]
        [TestCase(12_345, 3, "12,345")]
        [TestCase(12_345, 4, "12,345")]
        [TestCase(12_345, 5, "12,345")]
        [TestCase(12_345, 6, "12,345.0")]
        [TestCase(12_345, 7, "12,345.00")]

        // Bug where numbers where fractional part of log10 was > 0.5
        [TestCase(8.22929639076288, 4, "8.229")]

        // Special-case zero
        [TestCase(0, 1, "0")]
        [TestCase(0, 2, "0")]
        [TestCase(0, 3, "0")]

        // Negative numbers
        [TestCase(-1, 1, "-1")]
        [TestCase(-1, 4, "-1.000")]
        [TestCase(-0.00012345, 4, "-0.0001235")]
        [TestCase(-1.2345, 4, "-1.235")]
        [TestCase(-12_345, 4, "-12,345")]
        public void Format(double value, int minSignificantDigits, string expected)
        {
            Assert.AreEqual(expected, NumberFormatter.Format(value, minSignificantDigits));
        }

        [TestCase(1.2345, 0, typeof(ArgumentException))]
        [TestCase(1.2345, -1, typeof(ArgumentException))]
        public void FormatException(double value, int minSignificantDigits, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, () => NumberFormatter.Format(value, minSignificantDigits));
        }
    }
}