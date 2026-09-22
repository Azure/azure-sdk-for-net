// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Messaging.ServiceBus.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
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
            yield return new object[] { new WebSocketException("dummy", new ServiceBusException(true, null)) };

            // Nested transport wrappers should be unwrapped until an exception that can be classified is found.

            yield return new object[] { new WebSocketException("dummy", new HttpRequestException("dummy", new IOException("dummy", new SocketException((int)SocketError.ConnectionReset)))) };
            yield return new object[] { new WebSocketException("dummy", new HttpRequestException("dummy", new SocketException((int)SocketError.ConnectionReset))) };
            yield return new object[] { new HttpRequestException("dummy", new IOException()) };
            yield return new object[] { new AggregateException(new WebSocketException("dummy", new IOException())) };

            // ManagedWebSocket wraps a transport failure in a cancellation when an abort ends a pending receive.
            yield return new object[] { new OperationCanceledException("dummy", new WebSocketException("dummy", new IOException())) };

            // Mid-stream transport failures with a transient socket error stay retriable.  This chain has no
            // HttpRequestException layer, which matches what ManagedWebSocket produces.

            yield return new object[] { new WebSocketException("dummy", new IOException("dummy", new SocketException((int)SocketError.ConnectionReset))) };

            // The same transient socket error stays retriable at the minimal depth of a single IOException wrapper.

            yield return new object[] { new IOException("dummy", new SocketException((int)SocketError.ConnectionReset)) };

            // An IOException with a non-socket inner exception keeps its own retriable classification.  FormatException
            // is non-retriable on its own, so this case fails if IOException is ever unwrapped unconditionally.

            yield return new object[] { new IOException("dummy", new FormatException()) };

            // Task/Operation Canceled should use the inner exception as the decision point.

            yield return new object[] { new TaskCanceledException("dummy", new ServiceBusException(true, null)) };
            yield return new object[] { new OperationCanceledException("dummy", new ServiceBusException(true, null)) };

            // Since .NET 5, an HttpClient timeout arrives as a TaskCanceledException that wraps a TimeoutException.
            yield return new object[] { new TaskCanceledException("dummy", new TimeoutException()) };

            // Aggregate should use the first inner exception as the decision point.

            yield return new object[]
            {
                new AggregateException(new Exception[]
                {
                    new ServiceBusException(true, null),
                    new ArgumentException()
                })
            };

            // Synthetic case; five wrappers reach the leaf and pin MaximumUnwrapDepth at 5.

            yield return new object[] { new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new ServiceBusException(true, null)))))) };
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
            yield return new object[] { new SocketException((int)SocketError.NoRecovery) };

            // WebSocketException should use the inner exception as the decision point.
            yield return new object[] { new WebSocketException("dummy", new ServiceBusException(false, null)) };

            // Nested transport wrappers with a terminal root cause should remain non-retriable.

            yield return new object[] { new WebSocketException("dummy", new HttpRequestException("dummy", new SocketException((int)SocketError.HostNotFound))) };
            yield return new object[] { new WebSocketException("dummy") };
            yield return new object[] { new HttpRequestException("dummy") };

            // Mid-stream transport failures with a terminal socket error must stay non-retriable.  ManagedWebSocket
            // wraps the stream IOException directly, so this chain has no HttpRequestException layer.

            yield return new object[] { new WebSocketException("dummy", new IOException("dummy", new SocketException((int)SocketError.HostUnreachable))) };

            // NetworkStream and SslStream produce this minimal shape, with no WebSocketException wrapper around it.

            yield return new object[] { new IOException("dummy", new SocketException((int)SocketError.HostUnreachable)) };

            // This case is a classifier contract case, not a chain that the runtime produces.  It pins the promise
            // that a terminal socket error stays terminal at each supported depth.

            yield return new object[] { new WebSocketException("dummy", new HttpRequestException("dummy", new IOException("dummy", new SocketException((int)SocketError.HostNotFound)))) };

            // Task/Operation Canceled should use the inner exception as the decision point.

            yield return new object[] { new TaskCanceledException("dummy", new ServiceBusException(false, null)) };
            yield return new object[] { new OperationCanceledException("dummy", new ServiceBusException(false, null)) };

            // A caller cancellation has no inner exception, so it resolves to null and stays terminal.
            yield return new object[] { new OperationCanceledException("dummy") };

            // Null is not retriable, even if it is a blessed type.

            yield return new object[] { (TimeoutException)null };

            // Aggregate should use the first inner exception as the decision point.

            yield return new object[]
            {
                new AggregateException(new Exception[]
                {
                    new ArgumentException(),
                    new ServiceBusException(true, null),
                    new TimeoutException()
                })
            };

            // Synthetic case; a sixth wrapper exceeds MaximumUnwrapDepth and does not classify.

            yield return new object[] { new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new OperationCanceledException("dummy", new ServiceBusException(true, null))))))) };
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BasicRetryPolicy.CalculateTryTimeout" />MaximumRetries
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
            var options = new ServiceBusRetryOptions { TryTimeout = timeout };
            var policy = new BasicRetryPolicy(options);

            Assert.That(policy.CalculateTryTimeout(attemptCount), Is.EqualTo(options.TryTimeout));
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotRetryWhenThereIsNoMaxRetries()
        {
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 0,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromHours(1),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), -1), Is.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotRetryWhenThereIsNoMaxDelay()
        {
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.Zero,
                Mode = ServiceBusRetryMode.Fixed
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 5,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromHours(1),
                Mode = ServiceBusRetryMode.Fixed
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromSeconds(100),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(new ServiceBusException(true, null, null), 88), Is.Not.Null);
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromSeconds(100),
                Mode = ServiceBusRetryMode.Fixed
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromSeconds(100),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 88), Is.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayUnwrapsNestedWrappersWithinTheMaximumDepth()
        {
            Exception exception = new IOException();

            for (var index = 0; index < 3; ++index)
            {
                exception = new WebSocketException("dummy", exception);
            }

            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromSeconds(100),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 88), Is.Not.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayStopsUnwrappingAtTheMaximumDepth()
        {
            Exception exception = new IOException();

            for (var index = 0; index < 10; ++index)
            {
                exception = new WebSocketException("dummy", exception);
            }

            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromSeconds(100),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 88), Is.Null);
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotRetryWithAnActiveTransaction()
        {
            using var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Suppress);
            var exception = new ServiceBusException(true, "this is fake", "dummy", ServiceBusFailureReason.ServiceCommunicationProblem);

            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(1),
                MaxDelay = TimeSpan.FromSeconds(100),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(exception, 88), Is.Null);
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(delaySeconds),
                MaxDelay = TimeSpan.FromSeconds(1),
                Mode = ServiceBusRetryMode.Fixed
            });

            Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), 88), Is.EqualTo(policy.Options.MaxDelay));
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromSeconds(iterations),
                MaxDelay = TimeSpan.FromHours(72),
                Mode = ServiceBusRetryMode.Fixed
            });

            var variance = TimeSpan.FromSeconds(policy.Options.Delay.TotalSeconds * policy.JitterFactor);

            for (var index = 0; index < iterations; ++index)
            {
                Assert.That(policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), 88), Is.EqualTo(policy.Options.Delay).Within(variance), $"Iteration: {index} produced an unexpected delay.");
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
            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 99,
                Delay = TimeSpan.FromMilliseconds(15),
                MaxDelay = TimeSpan.FromHours(50000),
                Mode = ServiceBusRetryMode.Exponential
            });

            TimeSpan previousDelay = TimeSpan.Zero;

            for (var index = 0; index < iterations; ++index)
            {
                var variance = TimeSpan.FromSeconds((policy.Options.Delay.TotalSeconds * index) * policy.JitterFactor);
                TimeSpan? delay = policy.CalculateRetryDelay(Mock.Of<TimeoutException>(), index);

                Assert.That(delay.HasValue, Is.True, $"Iteration: {index} did not have a value.");
                Assert.That(delay.Value, Is.GreaterThan(previousDelay.Add(variance)), $"Iteration: {index} produced an unexpected delay.");

                previousDelay = delay.Value;
            }
        }

        /// <summary>
        ///  Verifies functionality of the <see cref="BasicRetryPolicy.CalculateRetryDelay" />
        ///  method.
        /// </summary>
        ///
        [Test]
        public void CalculateRetryDelayDoesNotOverflowTimespanMaximum()
        {
            // The fixed policy can't exceed the maximum due to limitations on
            // the configured Delay and MaximumRetries; the exponential policy
            // will overflow a TimeSpan on the 38th retry with maximum values if
            // the calculation is uncapped.

            var policy = new BasicRetryPolicy(new ServiceBusRetryOptions
            {
                MaxRetries = 100,
                Delay = TimeSpan.FromMinutes(5),
                MaxDelay = TimeSpan.MaxValue,
                Mode = ServiceBusRetryMode.Exponential
            });

            Assert.That(policy.CalculateRetryDelay(new ServiceBusException(true, "transient", "fake", ServiceBusFailureReason.ServiceTimeout), 88), Is.EqualTo(TimeSpan.MaxValue));
        }
    }
}
