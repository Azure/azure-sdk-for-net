// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class QueryTimeSpanTests
    {
        [Test]
        public void ToStringDurationTests()
        {
            Assert.AreEqual("PT23M", new QueryTimeSpan(TimeSpan.FromMinutes(23)).ToString());
        }

        [Test]
        public void ToStringDurationEndTests()
        {
            Assert.AreEqual("PT23M/2021-05-04T03:02:01.0000000Z", new QueryTimeSpan(TimeSpan.FromMinutes(23), new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero)).ToString());
        }

        [Test]
        public void ToStringStartDurationTests()
        {
            Assert.AreEqual("2021-05-04T03:02:01.0000000Z/PT23M", new QueryTimeSpan(new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero), TimeSpan.FromMinutes(23)).ToString());
        }

        [Test]
        public void ToStringStartEndTests()
        {
            Assert.AreEqual("2021-01-02T03:04:05.0000000Z/2021-05-04T03:02:01.0000000Z",
                new QueryTimeSpan(
                    new DateTimeOffset(2021, 1, 2, 3, 4, 5, TimeSpan.Zero),
                    new DateTimeOffset(2021, 5, 4, 3, 2, 1, TimeSpan.Zero)).ToString());
        }
    }
}