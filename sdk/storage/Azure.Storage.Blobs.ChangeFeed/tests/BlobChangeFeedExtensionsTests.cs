// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Azure.Storage.Blobs.ChangeFeed.Tests
{
    public class BlobChangeFeedExtensionsTests
    {
        [Test]
        public void ToDateTimeOffsetTests()
        {
            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 17, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11/02/1700/meta.json".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 17, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11/02/1700/".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 17, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11/02/1700".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 0, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11/02/".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 2, 0, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11/02".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 1, 0, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11/".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 11, 1, 0, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/11".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero),
                "idx/segments/2019/".ToDateTimeOffset());

            Assert.AreEqual(
                new DateTimeOffset(2019, 1, 1, 0, 0, 0, TimeSpan.Zero),
                "idx/segments/2019".ToDateTimeOffset());

            Assert.AreEqual(
                null,
                ((string)null).ToDateTimeOffset());
        }

        [Test]
        public void RoundDownToNearestHourTests()
        {
            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 25, 30, TimeSpan.Zero))).RoundDownToNearestHour());

            Assert.AreEqual(
                null,
                ((DateTimeOffset?)null).RoundDownToNearestHour());
        }

        [Test]
        public void RoundUpToNearestHourTests()
        {
            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 21, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 25, 30, TimeSpan.Zero))).RoundUpToNearestHour());

            Assert.AreEqual(
                null,
                ((DateTimeOffset?)null).RoundUpToNearestHour());
        }

        [Test]
        public void RoundDownToNearestYearTests()
        {
            Assert.AreEqual(
                new DateTimeOffset?(
                    new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero)),
                (new DateTimeOffset?(
                    new DateTimeOffset(2020, 03, 17, 20, 25, 30, TimeSpan.Zero))).RoundDownToNearestYear());

            Assert.AreEqual(
                null,
                ((DateTimeOffset?)null).RoundDownToNearestYear());
        }
    }
}