// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpRangeTests
    {
        [Test, Sequential]
        public void ToString(
            [Values(0, 0, 50, 200, 0)] long offset,
            [Values(null, 100, null, 100, 1)] long? count,
            [Values("0-", "0-99", "50-", "200-299", "0-0")] string expected
        )
        {
            var range = new HttpRange(offset, count);

            Assert.That(range.ToString(), Is.EqualTo("bytes=" + expected));
        }

        [Test]
        public void Equality()
        {
            var nullRange = new HttpRange(0, null);
            var nullStart = new HttpRange(0, 5);
            var nullEnd = new HttpRange(5, null);
            var r5_10 = new HttpRange(5, 10);
            var r5_10_copy = new HttpRange(5, 10);

            Assert.That(r5_10_copy, Is.EqualTo(r5_10));
            Assert.That(r5_10, Is.EqualTo(r5_10_copy));
            Assert.That(r5_10 == nullRange, Is.False);
            Assert.That(r5_10 == nullStart, Is.False);
            Assert.That(r5_10 == nullEnd, Is.False);

            Assert.That(r5_10, Is.EqualTo(r5_10_copy));
            Assert.That(r5_10 != nullRange, Is.True);
            Assert.That(r5_10 != nullStart, Is.True);
            Assert.That(r5_10 != nullEnd, Is.True);
        }

        [Test, Sequential]
        public void Errors(
        [Values(0, 0, -1)] long offset,
        [Values(0, -1, 3)] long? count
        )
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var range = new HttpRange(offset, count);
            });
        }
    }
}
