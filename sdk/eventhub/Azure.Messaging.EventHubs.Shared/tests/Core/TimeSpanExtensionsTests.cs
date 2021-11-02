// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TimeSpanExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TimeSpanExtensionsTests
    {
        /// <summary>
        ///   The set of test cases for calculating the remaining duration in
        ///   a given time period.
        /// </summary>
        ///
        public static IEnumerable<object[]> CalculateRemainingTestCases()
        {
            yield return new object[] { TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(9), TimeSpan.FromSeconds(1) };
            yield return new object[] { TimeSpan.FromSeconds(10.279), TimeSpan.FromSeconds(6.134), TimeSpan.FromSeconds(10.279 - 6.134) };
            yield return new object[] { TimeSpan.FromMilliseconds(50), TimeSpan.FromMilliseconds(25), TimeSpan.FromMilliseconds(25) };
            yield return new object[] { TimeSpan.FromMilliseconds(50.2), TimeSpan.FromMilliseconds(49.6), TimeSpan.Zero };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TimeSpanExtensions.CalculateRemaining" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateRemainingWithNoTimeAllowed()
        {
            Assert.That(TimeSpan.Zero.CalculateRemaining(TimeSpan.FromMilliseconds(1)), Is.EqualTo(TimeSpan.Zero));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TimeSpanExtensions.CalculateRemaining" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateRemainingWithNoTimeRemaining()
        {
            var time = TimeSpan.FromSeconds(1);
            Assert.That(time.CalculateRemaining(time), Is.EqualTo(TimeSpan.Zero));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TimeSpanExtensions.CalculateRemaining" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateRemainingWithNegativeTimeRemaining()
        {
            var time = TimeSpan.FromSeconds(1);
            TimeSpan elapsed = time.Add(TimeSpan.FromMilliseconds(50));

            Assert.That(time.CalculateRemaining(elapsed), Is.EqualTo(TimeSpan.Zero));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TimeSpanExtensions.CalculateRemaining" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateRemainingWithNoTimeElapsed()
        {
            var time = TimeSpan.FromSeconds(1);
            Assert.That(time.CalculateRemaining(TimeSpan.Zero), Is.EqualTo(time));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TimeSpanExtensions.CalculateRemaining" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(CalculateRemainingTestCases))]
        public void CalculateRemaining(TimeSpan initialPeriod,
                                       TimeSpan elapsed,
                                       TimeSpan expectedRemaining)
        {
            Assert.That(initialPeriod.CalculateRemaining(elapsed), Is.EqualTo(expectedRemaining).Within(TimeSpan.FromMilliseconds(1)));
        }
    }
}
