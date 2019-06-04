// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="Guard" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.BuildVerification)]
    public class GuardTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the <see cref="Guard.ArgumentNotNegative" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ArgumentNotNegativeForTimeSpanInvalidCases()
        {
            yield return new object[] { TimeSpan.FromMilliseconds(-1) };
            yield return new object[] { TimeSpan.FromSeconds(-2) };
            yield return new object[] { TimeSpan.FromHours(-3) };
            yield return new object[] { TimeSpan.FromDays(-0.3) };
            yield return new object[] { TimeSpan.FromTicks(-100) };
        }

        /// <summary>
        ///   Provides the valid test cases for the <see cref="Guard.ArgumentNotNullOrEmpty" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> ArgumentNotNegativeForTimeSpanValidCases()
        {
            yield return new object[] { TimeSpan.FromMilliseconds(0) };
            yield return new object[] { TimeSpan.FromSeconds(1) };
            yield return new object[] { TimeSpan.FromHours(1) };
            yield return new object[] { TimeSpan.FromDays(0.3) };
            yield return new object[] { TimeSpan.FromTicks(1) };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNull" /> method.
        /// </summary>
        ///
        [Test]
        public void ArgumentNotNullEnforcesInvariants()
        {
            Assert.That(() => Guard.ArgumentNotNull("argument", null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNull" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase("")]
        [TestCase("  ")]
        [TestCase(3)]
        [TestCase(typeof(Guard))]
        [TestCase(ConnectionType.AmqpTcp)]
        [TestCase(new[] { 1, 3, 4 })]
        public void ArgumentNotNullAllowsValidValues(object value)
        {
            Assert.That(() => Guard.ArgumentNotNull(nameof(value), value), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNullOrEmpty" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ArgumentNotNullOrEmptyEnforcesInvariants(string value)
        {
            Assert.That(() => Guard.ArgumentNotNullOrEmpty(nameof(value), value), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNullOrEmpty" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(" ")]
        [TestCase("         ")]
        [TestCase("This is a thing")]
        public void ArgumentNotNullOrEmptyAllowsValidValues(string value)
        {
            Assert.That(() => Guard.ArgumentNotNullOrEmpty(nameof(value), value), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNullOrWhitespace" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("         ")]
        public void ArgumentNotNullOrWhitespaceEnforcesInvariants(string value)
        {
            Assert.That(() => Guard.ArgumentNotNullOrWhitespace(nameof(value), value), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNullOrWhitespace" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase("1")]
        [TestCase("This is a thing")]
        public void ArgumentNotNullOrWhitespaceAllowsValidValues(string value)
        {
            Assert.That(() => Guard.ArgumentNotNullOrWhitespace(nameof(value), value), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNegative" /> method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ArgumentNotNegativeForTimeSpanInvalidCases))]
        public void ArgumentNotNegativeForTimeSpanEnforcesInvariants(TimeSpan value)
        {
            Assert.That(() => Guard.ArgumentNotNegative(nameof(value), value), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentNotNegative" /> method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ArgumentNotNegativeForTimeSpanValidCases))]
        public void ArgumentNotNegativeForTimeSpanAllowsValidValues(TimeSpan value)
        {
            Assert.That(() => Guard.ArgumentNotNegative(nameof(value), value), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentInRange" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(2, 3, 4)]
        [TestCase(0, 1, 100)]
        [TestCase(1000, 1, 10)]
        [TestCase(-10001, -1000, 0)]
        public void ArgumentInRangeEnforcesInvariants(int value,
                                                      int minValue,
                                                      int maxValue)
        {
            Assert.That(() => Guard.ArgumentInRange(nameof(value), value, minValue, maxValue), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Guard.ArgumentInRange" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(1, 0, 2)]
        [TestCase(10, -100, 100)]
        [TestCase(-5, -10, 0)]
        [TestCase(99, 0, 100)]
        [TestCase(0, 0, 100)]
        [TestCase(100, 0, 100)]
        public void ArgumentInRangeAllowsValidValues(int value,
                                                     int minValue,
                                                     int maxValue)
        {
            Assert.That(() => Guard.ArgumentInRange(nameof(value), value, minValue, maxValue), Throws.Nothing);
        }
    }
}
