// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core.Http;
using NUnit;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpRangeTests
    {
        [Test, Sequential]
        public void ToString(
            [Values(null, null, 50, 200)] long? offset,
            [Values(null, 100, null, 100)] long? count,
            [Values("0-", "0-99", "50-", "200-299")] string expected
        )
        {
            var range = new HttpRange(offset, count);

            Assert.AreEqual("bytes=" + expected, range.ToString());
            Assert.AreEqual("Range:bytes=" + expected, range.ToRangeHeader().ToString());
        }

        [Test]
        public void Equality()
        {
            var nullRange = new HttpRange(null, null);
            var nullStart = new HttpRange(null, 5);
            var nullEnd = new HttpRange(5, null);
            var r5_10 = new HttpRange(5, 10);
            var r5_10_copy = new HttpRange(5, 10);

            Assert.AreEqual(r5_10, r5_10_copy);
            Assert.IsTrue(r5_10 == r5_10_copy);
            Assert.IsFalse(r5_10 == nullRange);
            Assert.IsFalse(r5_10 == nullStart);
            Assert.IsFalse(r5_10 == nullEnd);

            Assert.IsFalse(r5_10 != r5_10_copy);
            Assert.IsTrue(r5_10 != nullRange);
            Assert.IsTrue(r5_10 != nullStart);
            Assert.IsTrue(r5_10 != nullEnd);
        }
    }
}
