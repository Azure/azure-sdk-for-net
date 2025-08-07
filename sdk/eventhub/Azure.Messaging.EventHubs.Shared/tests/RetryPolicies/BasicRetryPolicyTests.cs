// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BasicRetryPolicy" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class BasicRetryPolicyTests
    {
        /// <summary>
        ///   The test cases for exception types known to be retriable.
        /// </summary>
        ///
        public static IEnumerable<object[]> RetriableExceptionTestCases()
        {
            yield return new object[] { new TimeoutException() };
            yield return new object[] { new SocketException((int)SocketError.ConnectionReset) };
            yield return new object[] { new IOException() };
            yield return new object[] { new UnauthorizedAccessException() };

            // WebSocketException should use the inner exception as the decision point.
            yield return new object[] { new WebSocketException("dummy", new EventHubsException(true, null)) };

            // Task/Operation Canceled should use the inner exception as the decision point.

            yield return new object[] { new TaskCanceledException("dummy", new EventHubsException(true, null)) };
            yield return new object[] { new OperationCanceledException("dummy", new EventHubsException(true, null)) };

            // Aggregate should use the first inner exception as the decision point.

            yield return new object[]
            {
                new AggregateException(new Exception[]
                {
                    new EventHubsException(true, null),
                    new ArgumentException()
                })
            };
        }

        /// <summary>
        ///   The test cases for exception types known to be non-retriable.
        /// </summary>
        ///
        public static IEnumerable<object[]> NonRetriableExceptionTestCases()
        {
            yield return new object[] { new ArgumentException() };
            yield return new object[] { new InvalidOperationException() };
            yield return new object[] { new NotSupportedException() };
            yield return new object[] { new NullReferenceException() };
            yield return new object[] { new OutOfMemoryException() };
            yield return new object[] { new ObjectDisposedException("dummy") };
            yield return new object[] { new SocketException((int)SocketError.HostNotFound) };
            yield return new object[] { new SocketException((int)SocketError.HostUnreachable) };

            // WebSocketException should use the inner exception as the decision point.
            yield return new object[] { new WebSocketException("dummy", new EventHubsException(false, null)) };

            // Task/Operation Canceled should use the inner exception as the decision point.

            yield return new object[] { new TaskCanceledException("dummy", new EventHubsException(false, null)) };
            yield return new object[] { new OperationCanceledException("dummy", new EventHubsException(false, null)) };

            // Null is not retriable, even if it is a blessed type.

            yield return new object[] { (TimeoutException)null };

            // Aggregate should use the first inner exception as the decision point.

            yield return new object[]
            {
                new AggregateException(new Exception[]
                {
                    new ArgumentException(),
                    new EventHubsException(true, null),
                    new TimeoutException()
                })
            };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BasicRetryPolicy.CalculateTryTimeout" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(10)]
        [TestCase(100)]
        public void CalculateTryTimeoutRespectsOptions(int attemptCount)
        {
            var timeout = TimeSpan.FromSeconds(5);
            var options = new EventHubsRetryOptions { TryTimeout = timeout };
            var policy = new BasicRetryPolicy(options);

            Assert.That(policy.CalculateTryTimeout(attemptCount), Is.EqualTo(options.TryTimeout));
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotRetryWhenThereIsNoMaximumRetries()
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 0,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromHours(1),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), -1), Is.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotRetryWhenThereIsNoMaximumDelay()
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.Zero,
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), 88), Is.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(14)]
        [TestCase(200)]
        public void CalculateRetryDelayDoesNotRetryWhenAttemptsExceedTheMaximum(int retryAttempt)
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 5,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromHours(1),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), retryAttempt), Is.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayAllowsRetryForTransientExceptions()
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(100),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(new EventHubsException(true, null, null), 88), Is.Not.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(RetriableExceptionTestCases))]
        public void CalculateRetryDelayAllowsRetryForKnownRetriableExceptions(Exception exception)
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(100),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 88), Is.Not.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(NonRetriableExceptionTestCases))]
        public void CalculateRetryDelayDoesNotRetryForNotKnownRetriableExceptions(Exception exception)
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaximumDelay = TimeSpan.FromSeconds(100),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 88), Is.Null);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayRespectsThrottleInterval()
        {
            var delaySeconds = 1;
            var throttleException = new EventHubsException(true, "dummy", EventHubsException.FailureReason.ServiceBusy);

            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(delaySeconds),
                MaximumDelay = TimeSpan.FromDays(1),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(throttleException, 1),
                Is.AtLeast(TimeSpan.FromSeconds(delaySeconds + policy.MinimumThrottleSeconds))
                    .And.AtMost(TimeSpan.FromSeconds((delaySeconds * 2) + policy.MaximumThrottleSeconds)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotThrottleGeneralExceptions()
        {
            var delaySeconds = 1;
            var exception = new EventHubsException(true, "dummy", EventHubsException.FailureReason.GeneralError);

            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(delaySeconds),
                MaximumDelay = TimeSpan.FromDays(1),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 1),
                Is.AtLeast(TimeSpan.FromSeconds(delaySeconds)).And.AtMost(TimeSpan.FromSeconds(delaySeconds * 2)));
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(30)]
        [TestCase(60)]
        [TestCase(240)]
        public void CalculateRetryDelayRespectsMaximumDuration(int delaySeconds)
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(delaySeconds),
                MaximumDelay = TimeSpan.FromSeconds(1),
                Mode = EventHubsRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), 88), Is.EqualTo(policy.Options.MaximumDelay));
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(30)]
        [TestCase(60)]
        [TestCase(120)]
        public void CalculateRetryDelayUsesFixedMode(int iterations)
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromSeconds(iterations),
                MaximumDelay = TimeSpan.FromHours(72),
                Mode = EventHubsRetryMode.Fixed
            });

            var variance = TimeSpan.FromSeconds(policy.Options.Delay.TotalSeconds * policy.JitterFactor);

            for (var index = 0; index < iterations; ++index)
            {
                Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), 88), Is.EqualTo(policy.Options.Delay).Within(variance), $"Iteration: { index } produced an unexpected delay.");
            }
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(25)]
        public void CalculateRetryDelayUsesExponentialMode(int iterations)
        {
            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 99,
                Delay = TimeSpan.FromMilliseconds(15),
                MaximumDelay = TimeSpan.FromHours(50000),
                Mode = EventHubsRetryMode.Exponential
            });

            TimeSpan previousDelay = TimeSpan.Zero;

            for (var index = 0; index < iterations; ++index)
            {
                var variance = TimeSpan.FromSeconds((policy.Options.Delay.TotalSeconds * index) * policy.JitterFactor);
                TimeSpan? delay = policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), index);

                Assert.That(delay.HasValue, Is.True, $"Iteration: { index } did not have a value.");
                Assert.That(delay.Value, Is.GreaterThan(previousDelay.Add(variance)), $"Iteration: { index } produced an unexpected delay.");

                previousDelay = delay.Value;
            }
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotOverlowTimespanMaximum()
        {
            // The fixed policy can't exceed the maximum due to limitations on
            // the configured Delay and MaximumRetries; the exponential policy
            // will overflow a TimeSpan on the 38th retry with maximum values if
            // the calculation is uncapped.

            var policy = new BasicRetryPolicy(new EventHubsRetryOptions
            {
                MaximumRetries = 100,
                Delay = TimeSpan.FromMinutes(5),
                MaximumDelay = TimeSpan.MaxValue,
                Mode = EventHubsRetryMode.Exponential
            });

            Assert.That(policy.CalculateRetryDelay(new EventHubsException(true, "fake", EventHubsException.FailureReason.ServiceTimeout), 88), Is.EqualTo(TimeSpan.MaxValue));
        }
    }
}
