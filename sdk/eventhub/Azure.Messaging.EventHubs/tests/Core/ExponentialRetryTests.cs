using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ExponentialRetry" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Category(TestCategory.BuildVerification)]
    public class ExponentialRetryTests
    {
        /// <summary>
        ///   Provides the invalid test cases for the <see cref="ExponentialRetry.Equals" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> InequalityCases()
        {
            yield return new object[] { null, new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), "the first operand is null" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), null, "the second operand is null" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), new ExponentialRetry(TimeSpan.FromMilliseconds(1), TimeSpan.Zero, 0), "the minimum backoffs differ" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), new ExponentialRetry(TimeSpan.Zero, TimeSpan.FromMilliseconds(1), 0), "the maximum backoffs differ" };
            yield return new object[] { new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0), new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 2), "the maximum retries differ" };
        }

        /// <summary>
        ///   Provides the invalid test cases for the <see cref="ExponentialRetry.Equals" /> tests.
        /// </summary>
        ///
        public static IEnumerable<object[]> EqualityCases()
        {
            yield return new object[]
            {
                new ExponentialRetry(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(7), 20),
                new ExponentialRetry(TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(7), 20),
                "the attributes of the retries are the same"
            };

            var instance =  new ExponentialRetry(TimeSpan.Zero, TimeSpan.Zero, 0);
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
        [TestCaseSource(nameof(EqualityCases))]
        public void EqualityIsRecognized(ExponentialRetry first,
                                         ExponentialRetry second,
                                         string           description)
        {
            if (first != null)
            {
                Assert.That(first.Equals(second), Is.True, $"The method call should recognize the following as true:  [{ description }]");
            }

            Assert.That((first == second), Is.True, $"The equality operator should recognize the following as true: [{ description }]");
            Assert.That((first != second), Is.False, $"The inequality operator should recognize the following as false: [{ description }]");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.Equals" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(InequalityCases))]
        public void InequalityIsRecognized(ExponentialRetry first,
                                           ExponentialRetry second,
                                           string           description)
        {
            if (first != null)
            {
                Assert.That(first.Equals(second), Is.False, $"The method call should recognize the following as false:  [{ description }]");
            }

            Assert.That((first == second), Is.False, $"The equality operator should recognize the following as false: [{ description }]");
            Assert.That((first != second), Is.True, $"The inequality operator should recognize the following as true: [{ description }]");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.GetHashCode" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetHashCodeIsStable()
        {
            var codes = new List<int>();
            var retry = new ExponentialRetry(TimeSpan.FromMinutes(1), TimeSpan.FromHours(1), 22);

            for (var index = 0; index < 10; ++index)
            {
                codes.Add(retry.GetHashCode());
            }

            Assert.That(codes.Distinct().Count(), Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.GetHashCode" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetHashCodeIsTheSameWhenPropertiesMatch()
        {
            ExponentialRetry retry;
            var codes = new List<int>();

            for (var index = 0; index < 10; ++index)
            {
                retry = new ExponentialRetry(TimeSpan.FromMinutes(1), TimeSpan.FromHours(1), 22);
                codes.Add(retry.GetHashCode());
            }

            Assert.That(codes.Distinct().Count(), Is.EqualTo(1));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="ExponentialRetry.GetHashCode" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetHashCodeDiffersWhenPropertiesDoNotMatch()
        {
            ExponentialRetry retry;

            var count = 10;
            var codes = new List<int>();

            for (var index = 0; index < count; ++index)
            {
                retry = new ExponentialRetry(TimeSpan.FromMinutes(index), TimeSpan.FromMilliseconds(index + 1), (index + 22));
                codes.Add(retry.GetHashCode());
            }

            Assert.That(codes.Distinct().Count(), Is.EqualTo(count));
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
            var clone = retry.Clone();

            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.EqualTo(retry), "The clone should be considered equal.");
            Assert.That(clone, Is.Not.SameAs(retry), "The clone should be a copy, not the same instance.");
        }
    }
}
