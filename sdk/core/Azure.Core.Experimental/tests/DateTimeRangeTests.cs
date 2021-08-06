// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DateTimeRangeTests
    {
        [Test]
        public void ToStringDurationTests()
        {
            var duration = TimeSpan.FromMinutes(23);
            Assert.AreEqual("PT23M", new DateTimeRange(duration).ToString());
        }

        [Test]
        public void ToStringDurationEndTests()
        {
            var duration = TimeSpan.FromMinutes(23);
            var endTime = new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero);
            Assert.AreEqual("PT23M/2021-05-04T03:02:01.0000000Z", new DateTimeRange(duration, endTime).ToString());
        }

        [Test]
        public void ToStringStartDurationTests()
        {
            var startTime = new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero);
            var duration = TimeSpan.FromMinutes(23);
            Assert.AreEqual("2021-05-04T03:02:01.0000000Z/PT23M", new DateTimeRange(startTime, duration).ToString());
        }

        [Test]
        public void ToStringStartEndTests()
        {
            var startTime = new DateTimeOffset(2021, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var endTime = new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero);

            Assert.AreEqual("2021-01-02T03:04:05.0000000Z/2021-05-04T03:02:01.0000000Z", new DateTimeRange(startTime, endTime).ToString());
        }

        [TestCase("PT23M")]
        [TestCase("PT23M/2021-05-04T03:02:01.0000000Z")]
        [TestCase("2021-05-04T03:02:01.0000000Z/PT23M")]
        [TestCase("2021-01-02T03:04:05.0000000Z/2021-05-04T03:02:01.0000000Z")]
        public void CanRoundtrip(string range)
        {
            Assert.AreEqual(range, DateTimeRange.Parse(range).ToString());
        }

        [TestCase("A")]
        [TestCase("A/A")]
        [TestCase("PT23M/PT23M/2021-05-04T03:02:01.0000000Z")]
        [TestCase("1000000-05-04T03:02:01.0000000Z/PT23M")]
        public void ParseThrowsFormatExceptionForInvalidInput(string range)
        {
            var ex = Assert.Throws<FormatException>(() => DateTimeRange.Parse(range));
            StringAssert.StartsWith("Unable to parse the DateTimeRange value.", ex.Message);
        }
    }
}