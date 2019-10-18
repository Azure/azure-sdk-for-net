// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class EnumExtensionsTests
    {
        [TestCase(0, "0")]
        [TestCase(1, "a")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [TestCase(4, "b")]
        [TestCase(5, "a, b")]
        [TestCase(6, "6")]
        [TestCase(9, "a, c")]
        [TestCase(12, "b, c")]
        [TestCase(13, "a, b, c")]
        [TestCase(int.MaxValue - 1, "2147483646")]
        [TestCase(int.MaxValue, "d")]
        public void FlagsToString(int value, string expected)
        {
            var names = new[]{"a", "b", "c", "d"};
            var values = new ulong[] {1, 4, 8, int.MaxValue};
            Assert.AreEqual(expected, ((ulong)value).FlagsToString(names, values));
        }
    }
}
