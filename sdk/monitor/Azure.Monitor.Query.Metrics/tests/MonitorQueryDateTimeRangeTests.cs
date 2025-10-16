// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Metrics;
using NUnit.Framework;

namespace Azure.Monitor.Query.Metrics.Tests
{
    public class MonitorQueryDateTimeRangeTests
    {
        [Test]
        public void ToStringDurationTests()
        {
            var duration = TimeSpan.FromMinutes(23);
            Assert.AreEqual("PT23M", new MetricsQueryTimeRange(duration).ToIsoString());
        }

        [Test]
        public void ToStringDurationEndTests()
        {
            var duration = TimeSpan.FromMinutes(23);
            var endTime = new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero);
            Assert.AreEqual("PT23M/2021-05-04T03:02:01.0000000Z", new MetricsQueryTimeRange(duration, endTime).ToIsoString());
        }

        [Test]
        public void ToStringStartDurationTests()
        {
            var startTime = new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero);
            var duration = TimeSpan.FromMinutes(23);
            Assert.AreEqual("2021-05-04T03:02:01.0000000Z/PT23M", new MetricsQueryTimeRange(startTime, duration).ToIsoString());
        }

        [Test]
        public void ToStringStartEndTests()
        {
            var startTime = new DateTimeOffset(2021, 1, 2, 3, 4, 5, TimeSpan.Zero);
            var endTime = new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero);

            Assert.AreEqual("2021-01-02T03:04:05.0000000Z/2021-05-04T03:02:01.0000000Z", new MetricsQueryTimeRange(startTime, endTime).ToIsoString());
        }

        [TestCase("PT23M")]
        [TestCase("PT23M/2021-05-04T03:02:01.0000000Z")]
        [TestCase("2021-05-04T03:02:01.0000000Z/PT23M")]
        [TestCase("2021-01-02T03:04:05.0000000Z/2021-05-04T03:02:01.0000000Z")]
        public void CanRoundtrip(string range)
        {
            Assert.AreEqual(range, MetricsQueryTimeRange.Parse(range).ToIsoString());
        }

        [RunOnlyOnPlatforms(Windows = true, Reason = "Default formatting differs between platforms.")]
        [TestCase("PT23M", "Duration: 00:23:00")]
        [TestCase("PT23M/2021-05-04T03:02:01.0000000Z", "Duration: 00:23:00 End: 5/4/2021 3:02:01 AM +00:00")]
        [TestCase("2021-05-04T03:02:01.0000000Z/PT23M", "Start: 5/4/2021 3:02:01 AM +00:00 Duration: 00:23:00")]
        [TestCase("2021-01-02T03:04:05.0000000Z/2021-05-04T03:02:01.0000000Z", "Start: 1/2/2021 3:04:05 AM +00:00 End: 5/4/2021 3:02:01 AM +00:00")]
        public void ToStringFormats(string range, string expected)
        {
            Assert.AreEqual(expected, MetricsQueryTimeRange.Parse(range).ToString());
        }

        [TestCase("A")]
        [TestCase("A/A")]
        [TestCase("PT23M/PT23M/2021-05-04T03:02:01.0000000Z")]
        [TestCase("1000000-05-04T03:02:01.0000000Z/PT23M")]
        public void ParseThrowsFormatExceptionForInvalidInput(string range)
        {
            var ex = Assert.Throws<FormatException>(() => MetricsQueryTimeRange.Parse(range));
            StringAssert.StartsWith("Unable to parse the DateTimeRange value.", ex.Message);
        }
    }
}
