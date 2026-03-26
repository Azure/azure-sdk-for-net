// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;
using Azure.Storage.ChangeFeed.Common;
using NUnit.Framework;

namespace Azure.Storage.Files.Shares.ChangeFeed.Tests
{
    /// <summary>
    /// Tests for <see cref="ChangeFeedExtensionsBase"/> utility methods including segment path parsing,
    /// interval rounding, and date boundary helpers.
    /// </summary>
    public class ChangeFeedExtensionsBaseTests : ShareChangeFeedTestBase
    {
        public ChangeFeedExtensionsBaseTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null)
        {
        }

        /// <summary>
        /// Verifies that an hourly segment path like "0200" is correctly parsed into a DateTimeOffset with only the hour component.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_HourlyPath()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2020/03/25/0200/meta.json");
            Assert.AreEqual(new DateTimeOffset(2020, 3, 25, 2, 0, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a 15-minute segment path like "0815" is correctly parsed into a DateTimeOffset with both hour and minute components.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_15MinPath()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2024/01/15/0815/meta.json");
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a 15-minute segment path at "1445" correctly produces hour 14 and minute 45.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_15MinPath_0845()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2024/06/20/1445/meta.json");
            Assert.AreEqual(new DateTimeOffset(2024, 6, 20, 14, 45, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a null path returns null rather than throwing.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_Null()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset(null);
            Assert.IsNull(result);
        }

        /// <summary>
        /// Verifies that a year-only path like "idx/segments/2023/" defaults to January 1 at midnight.
        /// </summary>
        [Test]
        public void ToDateTimeOffset_YearOnly()
        {
            DateTimeOffset? result = ChangeFeedExtensionsBase.ToDateTimeOffset("idx/segments/2023/");
            Assert.AreEqual(new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a timestamp mid-interval is rounded down to the preceding 15-minute boundary.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_15Min()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 15, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a timestamp already on a 15-minute boundary is unchanged after rounding down.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_AlreadyAligned()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a timestamp mid-interval is rounded up to the next 15-minute boundary.
        /// </summary>
        [Test]
        public void RoundUpToNearestInterval_15Min()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that a timestamp already on a 15-minute boundary is unchanged after rounding up.
        /// </summary>
        [Test]
        public void RoundUpToNearestInterval_AlreadyAligned()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 30, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that rounding down a null DateTimeOffset returns null.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_Null()
        {
            DateTimeOffset? result = ((DateTimeOffset?)null).RoundDownToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.IsNull(result);
        }

        /// <summary>
        /// Verifies that rounding up a null DateTimeOffset returns null.
        /// </summary>
        [Test]
        public void RoundUpToNearestInterval_Null()
        {
            DateTimeOffset? result = ((DateTimeOffset?)null).RoundUpToNearestInterval(TimeSpan.FromMinutes(15));
            Assert.IsNull(result);
        }

        /// <summary>
        /// Verifies that rounding down works correctly with a 1-hour interval, truncating minutes and seconds.
        /// </summary>
        [Test]
        public void RoundDownToNearestInterval_1Hour()
        {
            DateTimeOffset? input = new DateTimeOffset(2024, 1, 15, 8, 22, 30, TimeSpan.Zero);
            DateTimeOffset? result = input.RoundDownToNearestInterval(TimeSpan.FromHours(1));
            Assert.AreEqual(new DateTimeOffset(2024, 1, 15, 8, 0, 0, TimeSpan.Zero), result);
        }

        /// <summary>
        /// Verifies that MinDateTime returns the end date when it is earlier than the last consumable timestamp.
        /// </summary>
        [Test]
        public void MinDateTime_EndDateBeforeLastConsumable()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            DateTimeOffset endDate = new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(endDate, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, endDate));
        }

        /// <summary>
        /// Verifies that MinDateTime falls back to the last consumable timestamp when no end date is provided.
        /// </summary>
        [Test]
        public void MinDateTime_NoEndDate()
        {
            DateTimeOffset lastConsumable = new DateTimeOffset(2024, 1, 15, 10, 0, 0, TimeSpan.Zero);
            Assert.AreEqual(lastConsumable, ChangeFeedExtensionsBase.MinDateTime(lastConsumable, null));
        }
    }
}
