// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    public class ChangeFeedExtensionsBaseTests : ShareChangeFeedTestBase
    {
        public ChangeFeedExtensionsBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        [Test]
        public void ToDateTimeOffset_HourlyPath()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2020/03/25/0200/meta.json");
            Assert.AreEqual(new DateTimeOffset(2020, 3, 25, 2, 0, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void ToDateTimeOffset_15MinPath()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2024/01/15/0815/meta.json");
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void ToDateTimeOffset_15MinPath_0845()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2024/06/20/1445/meta.json");
            Assert.AreEqual(new DateTimeOffset(2024, 6, 20, 14, 45, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void ToDateTimeOffset_Null()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ToDateTimeOffset_YearOnly()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2023/");
            Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundDownToNearestInterval_15Min()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundDownToNearestInterval_AlreadyAligned()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundUpToNearestInterval_15Min()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundUpToNearestInterval_AlreadyAligned()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundDownToNearestInterval_Null()
        {
            DateTimeOffset? result = ((DateTimeOffset?)null).RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.IsNull(result);
        }

        [Test]
        public void RoundUpToNearestInterval_Null()
        {
            DateTimeOffset? result = ((DateTimeOffset?)null).RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.IsNull(result);
        }

        [Test]
        public void RoundDownToNearestInterval_1Hour()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromHours(1));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void MinDateTime_EndDateBeforeLastConsumable()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            DateTimeOffset endDate = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(endDate, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, endDate));
        }

        [Test]
        public void MinDateTime_NoEndDate()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(lastConsumable, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, null));
        }
    }
}
