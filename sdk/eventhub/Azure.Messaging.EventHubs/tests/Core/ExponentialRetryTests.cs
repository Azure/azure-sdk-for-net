using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ExponentialRetry" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class ExponentialRetryTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the <see cref="ExponentialRetry.HaveSameConfiguration" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> DifferentConfigurationCases()
        {
            yield return new object[] { null, new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), "the first operand is null" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), null, "the second operand is null" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), new ExponentialRetry(TimeSpan.FromMilliseconds(1), TimeSpan.Zero, 0), "the minimum backoffs differ" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), new ExponentialRetry(TimeSpan.Zero, TimeSpan.FromMilliseconds(1), 0), "the maximum backoffs differ" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 2), "the maximum retries differ" };
        }

        /// <summary>
        ///   Provides the invalid test cases for the <see cref="ExponentialRetry.HaveSameConfiguration" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> SameConfigurationCases()
        {
            yield return new object[]
            {
                new ExponentialRetry(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(7), 20),
                new ExponentialRetry(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(7), 20),
                "the attributes of the retries are the same"
            };

            var instance = new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0);
            yield return new object[] { instance, instance, "the operands are the same instance" };
            yield return new object[] { null, null, "both operands are null" };
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesArguments()
        {
            Assert.That(() => new ExponentialRetry(TimeSpan.FromSeconds(-100), TimeSpan.Zero, 1), Throws.InstanceOf<ArgumentOutOfRangeException>(), "A negative minimum should not be allowed.");
            Assert.That(() => new ExponentialRetry(TimeSpan.FromSeconds(200), TimeSpan.FromMilliseconds(-1), 72), Throws.InstanceOf<ArgumentOutOfRangeException>(), "A negative maximum should not be allowed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.Equals" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SameConfigurationCases))]
        public void HaveSameConfigurationRecognizesEquivalentConfiguration(ExponentialRetry first,
                                                                           ExponentialRetry second,
                                                                           string description)
        {
            Assert.That(ExponentialRetry.HaveSameConfiguration(first, second), Is.True, $"{ description } should be considered the same configuration.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.Equals" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(DifferentConfigurationCases))]
        public void HaveSameConfigurationRecognizesDifferentConfiguration(ExponentialRetry first,
                                                                          ExponentialRetry second,
                                                                          string description)
        {
            Assert.That(ExponentialRetry.HaveSameConfiguration(first, second), Is.False, $"{ description } should be considered different configurations.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(2), 123);
            var clone = retry.Clone() as ExponentialRetry;

            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(ExponentialRetry.HaveSameConfiguration(clone, retry), Is.True, "The clone should be considered equal.");
            Assert.That(clone, Is.Not.SameAs(retry), "The clone should be a copy, not the same instance.");
        }
    }
}
