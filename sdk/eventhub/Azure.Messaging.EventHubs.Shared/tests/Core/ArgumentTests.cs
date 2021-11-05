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
    public class ArgumentTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the <see cref="Argument.AssertNotNegative" /> tests.
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
        ///   Provides the valid test cases for the <see cref="Argument.AssertNotNegative" /> tests.
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
        ///   Verifies functionality of the <see cref="Argument.AssertNotEmptyOrWhiteSpace(string, string)" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("         ")]
        public void ArgumentNotEmptyOrWhitespaceEnforcesInvariants(string value)
        {
            Assert.That(() => Argument.AssertNotEmptyOrWhiteSpace(value, nameof(value)), Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotEmptyOrWhiteSpace(string, string)" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("1")]
        [TestCase("This is a thing")]
        public void ArgumentNotEmptyOrWhitespaceAllowsValidValues(string value)
        {
            Assert.That(() => Argument.AssertNotEmptyOrWhiteSpace(value, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotNegative" /> method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ArgumentNotNegativeForTimeSpanInvalidCases))]
        public void ArgumentNotNegativeForTimeSpanEnforcesInvariants(TimeSpan value)
        {
            Assert.That(() => Argument.AssertNotNegative(value, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotNegative" /> method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(ArgumentNotNegativeForTimeSpanValidCases))]
        public void ArgumentNotNegativeForTimeSpanAllowsValidValues(TimeSpan value)
        {
            Assert.That(() => Argument.AssertNotNegative(value, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertAtLeast" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(2, 3)]
        [TestCase(0, 1)]
        [TestCase(1000, 2000)]
        [TestCase(-1001, -1000)]
        public void ArgumentAtLeastEnforcesInvariantsForLongs(long value,
                                                             long minValue)
        {
            Assert.That(() => Argument.AssertAtLeast(value, minValue, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertAtLeast" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(1, 0)]
        [TestCase(10, -100)]
        [TestCase(-5, -10)]
        [TestCase(99, 0)]
        [TestCase(0, 0)]
        [TestCase(100, 0)]
        public void ArgumentAtLeastAllowsValidValuesForLongs(long value,
                                                             long minValue)
        {
            Assert.That(() => Argument.AssertAtLeast(value, minValue, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertAtLeast" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(2, 3)]
        [TestCase(0, 1)]
        [TestCase(1000, 2000)]
        [TestCase(-1001, -1000)]
        public void ArgumentAtLeastEnforcesInvariantsForInts(int value,
                                                             int minValue)
        {
            Assert.That(() => Argument.AssertAtLeast(value, minValue, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertAtLeast" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(1, 0)]
        [TestCase(10, -100)]
        [TestCase(-5, -10)]
        [TestCase(99, 0)]
        [TestCase(0, 0)]
        [TestCase(100, 0)]
        public void ArgumentAtLeastAllowsValidValuesForInts(int value,
                                                            int minValue)
        {
            Assert.That(() => Argument.AssertAtLeast(value, minValue, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotTooLong" /> method.
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
            Assert.That(() => Argument.AssertNotTooLong(value, maxLength, nameof(value)), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotTooLong" /> method.
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
            Assert.That(() => Argument.AssertNotTooLong(value, maxLength, nameof(value)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotDisposed" /> method.
        /// </summary>
        ///
        [Test]
        public void NotDisposedAllowsUndisposed()
        {
            Assert.That(() => Argument.AssertNotDisposed(false, "test"), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotDisposed" /> method.
        /// </summary>
        ///
        [Test]
        public void NotDisposedEnforcesDisposed()
        {
            var target = "test";
            Assert.That(() => Argument.AssertNotDisposed(true, target), Throws.InstanceOf<ObjectDisposedException>().And.Message.Contains(target));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotClosed" /> method.
        /// </summary>
        ///
        [Test]
        public void NotClosedAllowsUnclosed()
        {
            Assert.That(() => Argument.AssertNotClosed(false, "test"), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertNotClosed" /> method.
        /// </summary>
        ///
        [Test]
        public void NotClosedEnforcesClosed()
        {
            var target = "test";
            Assert.That(() => Argument.AssertNotClosed(true, target), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed).And.Message.Contains(target));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertWellFormedFullyQualifiedNamespace" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("sb://myhub.servicebus.windows")]
        [TestCase("sb://192.168.1.15")]
        [TestCase("amqps://myhub.servicebus.windows")]
        [TestCase("amqps://192.168.1.15")]
        [TestCase("http://myhub.servicebus.windows")]
        [TestCase("https://192.168.1.15")]
        public void AssertWellFormedFullyQualifiedNamespaceEnforcesInvariants(string value)
        {
            Assert.That(() => Argument.AssertWellFormedEventHubsNamespace(value, nameof(value)), Throws.ArgumentException.And.Property(nameof(ArgumentException.ParamName)).EqualTo(nameof(value)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="Argument.AssertWellFormedFullyQualifiedNamespace" /> method.
        /// </summary>
        ///
        [Test]
        [TestCase("myhub")]
        [TestCase("myhub.servicebus.windows.com")]
        [TestCase("myhub.servicebus.microsoft.ca")]
        [TestCase("myhub.place.jp")]
        [TestCase("192.168.1.12")]
        [TestCase("2001:0000:3238:DFE1:0063:0000:0000:FEFB")]
        public void AssertWellFormedFullyQualifiedNamespaceAllowsValidValues(string value)
        {
            Assert.That(() => Argument.AssertWellFormedEventHubsNamespace(value, nameof(value)), Throws.Nothing);
        }
    }
}
