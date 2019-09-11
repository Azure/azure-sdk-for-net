// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="Argument" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class GuardTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the <see cref="Argument.NotNegative" /> tests.
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
        ///   Provides the valid test cases for the <see cref="Argument.NotNegative" /> tests.
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
        ///   Verifies functionality of the <see cref="Argument.NotEmptyOrWhiteSpace(string, string)" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("         ")]
        public void ArgumentNotEmptyOrWhitespaceEnforcesInvariants(string value)
        {
            Assert.That(() => Argument.NotEmptyOrWhiteSpace(value, nameof(value)), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotEmptyOrWhiteSpace(string, string)" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("1")]
        [TestCase("This is a thing")]
        public void ArgumentNotEmptyOrWhitespaceAllowsValidValues(string value)
        {
            Assert.That(() => Argument.NotEmptyOrWhiteSpace(value, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotNegative" /> method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ArgumentNotNegativeForTimeSpanInvalidCases))]
        public void ArgumentNotNegativeForTimeSpanEnforcesInvariants(TimeSpan value)
        {
            Assert.That(() => Argument.NotNegative(value, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotNegative" /> method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ArgumentNotNegativeForTimeSpanValidCases))]
        public void ArgumentNotNegativeForTimeSpanAllowsValidValues(TimeSpan value)
        {
            Assert.That(() => Argument.NotNegative(value, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AtLeast" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(2, 3)]
        [TestCase(0, 1)]
        [TestCase(1000, 2000)]
        [TestCase(-1001, -1000)]
        public void ArgumentAtLeastEnforcesInvariants(long value,
                                                      long minValue)
        {
            Assert.That(() => Argument.AtLeast(value, minValue, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AtLeast" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(1, 0)]
        [TestCase(10, -100)]
        [TestCase(-5, -10)]
        [TestCase(99, 0)]
        [TestCase(0, 0)]
        [TestCase(100, 0)]
        public void ArgumentAtLeastAllowsValidValues(long value,
                                                     long minValue)
        {
            Assert.That(() => Argument.AtLeast(value, minValue, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotTooLong" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase("1", 0)]
        [TestCase("1", -1)]
        [TestCase("Hello", 3)]
        [TestCase("Hello There I am a very long argument that is typed", 10)]
        public void ArgumentNotTooLongEnforcesInvariants(string value,
                                                         int maxLength)
        {
            Assert.That(() => Argument.NotTooLong(value, maxLength, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotTooLong" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(null, 0)]
        [TestCase(null, 10)]
        [TestCase("", 0)]
        [TestCase("", 1)]
        [TestCase("1", 1)]
        [TestCase("Hello", 5)]
        [TestCase("Hello", 7)]
        [TestCase("This is a really long argument that I am typing.", 500)]
        public void ArgumentNotTooLongAllowsValidValues(string value,
                                                        int maxLength)
        {
            Assert.That(() => Argument.NotTooLong(value, maxLength, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotDisposed" /> method.
        /// </summary>
        ///
        [Test]
        public void NotDisposedAllowsUndisposed()
        {
            Assert.That(() => Argument.NotDisposed(false, "test"), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.NotDisposed" /> method.
        /// </summary>
        ///
        [Test]
        public void NotDisposedEnforcesDisposed()
        {
            var target = "test";
            Assert.That(() => Argument.NotDisposed(true, target), Throws.InstanceOf<ObjectDisposedException>().And.Message.Contains(target));
        }
    }
}
