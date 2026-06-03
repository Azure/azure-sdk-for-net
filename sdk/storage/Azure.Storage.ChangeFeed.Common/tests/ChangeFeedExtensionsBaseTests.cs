// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.Storage.ChangeFeed.Common.Tests
{
    /// <summary>
    /// Tests for <see cref="ChangeFeedExtensionsBase"/> utility methods including
    /// segment path parsing, interval-aware rounding, and time range helpers.
    /// </summary>
    public class ChangeFeedExtensionsBaseTests : ChangeFeedCommonTestBase
    {
        public ChangeFeedExtensionsBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that an hourly path (HH00) is parsed correctly with minute=0.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_HourlyPath()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2020/03/25/0200/meta.json");
            Assert.AreEqual(new DateTimeOffset(2020, 3, 25, 2, 0, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a 15-minute path (HHmm) is parsed with both hour and minute components.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_15MinPath()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2024/01/15/0815/meta.json");
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies 45-minute offset parsing (e.g. 14:45).
        /// </summary>
        [Test]
        public void ToDateTimeOffset_15MinPath_0845()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2024/06/20/1445/meta.json");
            Assert.AreEqual(new DateTimeOffset(2024, 6, 20, 14, 45, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void ToDateTimeOffset_Null()
        {
            Assert.IsNull(ChangeFeedExtensionsBase.ToDateTimeOffset(null));
        }

        /// <summary>
        /// Verifies that a year-only path defaults month/day/hour/minute to minimum values.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_YearOnly()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2023/");
            Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void ToDateTimeOffset_InvalidPath_TooShort()
        {
            Assert.Throws<ArgumentException>(() => ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments"));
        }

        /// <summary>
        /// Verifies rounding down 08:22:30 to the nearest 15 minutes gives 08:15:00.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_15Min()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that an already-aligned time is unchanged when rounding down.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_AlreadyAligned()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundDownToNearestInterval_Null()
        {
            Assert.IsNull(((DateTimeOffset?)null).RoundDownToNearestInterval(TimeSpan.FromMinutes(15)));
        }

        /// <summary>
        /// Verifies rounding up 08:22:30 to the nearest 15 minutes gives 08:30:00.
        /// </summary>
        [Test]
        public void RoundUpToNearestInterval_15Min()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that an already-aligned time is unchanged when rounding up.
        /// </summary>
        [Test]
        public void RoundUpToNearestInterval_AlreadyAligned()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(input, result);
        }

        [Test]
        public void RoundUpToNearestInterval_Null()
        {
            Assert.IsNull(((DateTimeOffset?)null).RoundUpToNearestInterval(TimeSpan.FromMinutes(15)));
        }

        /// <summary>
        /// Verifies rounding down to the nearest hour also works with the interval-based method.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_1Hour()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromHours(1));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundDownToNearestYear()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 6, 15, 10, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestYear();
            Assert.AreEqual(new DateTimeOffset(2024, 1, 1, 0, 0, 0, TimeSpan.Zero), result);
        }

        [Test]
        public void RoundDownToNearestYear_Null()
        {
            Assert.IsNull(((DateTimeOffset?)null).RoundDownToNearestYear());
        }

        [Test]
        public void MinDateTime_EndDateBeforeLastConsumable()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            DateTimeOffset endDate = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(endDate, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, endDate));
        }

        [Test]
        public void MinDateTime_EndDateAfterLastConsumable()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            DateTimeOffset endDate = new DateTimeOffset(2024, 1, 15, 12, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(lastConsumable, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, endDate));
        }

        [Test]
        public void MinDateTime_NoEndDate()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(lastConsumable, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, null));
        }
    }
}
