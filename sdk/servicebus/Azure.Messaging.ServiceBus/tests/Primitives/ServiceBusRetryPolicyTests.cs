// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ServiceBusRetryPolicy" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ServiceBusRetryPolicyTests
    {
        [Test]
        public void HasDefaultValues()
        {
            var policy = new MockServiceBusRetryPolicy();

            Assert.That(policy.IsServerBusy, Is.False);
            Assert.That(policy.ServerBusyBaseSleepTime, Is.GreaterThan(TimeSpan.FromSeconds(0)));
            Assert.That(policy.ServerBusyExceptionMessage, Is.Null);
        }

        [Test]
        public async Task ExecutesRunOperationWithState()
        {
            var policy = new MockServiceBusRetryPolicy();

            var operationResult = await policy.RunOperation((state, timeout, token) => new ValueTask<bool>(!state), false, null,
                CancellationToken.None);

            Assert.That(operationResult, Is.True);
        }

        [Test]
        public void SetsServerBusy()
        {
            var policy = new MockServiceBusRetryPolicy();

            Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await policy.RunOperation((state, timeout, token) =>
                    {
                        throw new ServiceBusException("Busy", ServiceBusFailureReason.ServiceBusy);
                    }, false, null,
                    CancellationToken.None);
            });
            Assert.That(policy.IsServerBusy, Is.True);
        }

        [Test]
        public void ResetsServerBusyAfterBaseSleepTime()
        {
            var policy = new MockServiceBusRetryPolicy
            {
                ServerBusyBaseSleepTime = TimeSpan.FromMilliseconds(10)
            };

            Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await policy.RunOperation((state, timeout, token) =>
                    {
                        throw new ServiceBusException("Busy", ServiceBusFailureReason.ServiceBusy);
                    }, false, null,
                    CancellationToken.None);
            });

            var serverNoLongerBusy = SpinWait.SpinUntil(() => policy.IsServerBusy == false, TimeSpan.FromSeconds(1));
            Assert.That(serverNoLongerBusy, Is.True);
        }

        [Test]
        public void ResetsServerBusyAfterCancellation()
        {
            using var cancellationSource = new CancellationTokenSource();

            var policy = new MockServiceBusRetryPolicy
            {
                ServerBusyBaseSleepTime = TimeSpan.FromMinutes(5)
            };

            Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await policy.RunOperation((state, timeout, token) =>
                    {
                        throw new ServiceBusException("Busy", ServiceBusFailureReason.ServiceBusy);
                    }, false, null,
                    cancellationSource.Token);
            });

            // Once the service is confirmed busy, cancel the operation.
            SpinWait.SpinUntil(() => policy.IsServerBusy == true, TimeSpan.FromSeconds(10));
            Assert.That(policy.IsServerBusy, Is.True);

            cancellationSource.Cancel();
            SpinWait.SpinUntil(() => policy.IsServerBusy == false, TimeSpan.FromSeconds(10));
            Assert.That(policy.IsServerBusy, Is.False);
        }

        [Test]
        public void RunOperationServerBusyTryTimeoutShorterThanBaseWaitTimeThrowsAfterRetries()
        {
            var policy = new CustomServerBusyMockRetryPolicy
            {
                ServerBusyBaseSleepTime = TimeSpan.FromSeconds(30)
            };

            // Set the server busy state before running the operation
            policy.SetServerBusyForTest();

            var operationCallCount = 0;

            // The operation is never actually called in the busy block, but we provide a dummy
            Func<object, TimeSpan, CancellationToken, ValueTask<bool>> operation = (state, timeout, token) =>
            {
                operationCallCount++;
                return new ValueTask<bool>(true);
            };

            // Should throw after retries are exhausted
            var ex = Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await policy.RunOperation(operation, null, null, CancellationToken.None);
            });

            Assert.That(ex.Reason, Is.EqualTo(ServiceBusFailureReason.ServiceBusy));
            Assert.That(policy.CalculateRetryDelayCallCount, Is.EqualTo(CustomServerBusyMockRetryPolicy.MaxRetries + 1));
        }

        [Test]
        public async Task RunOperationServerBusyResolvesBeforeRetriesInvokesOperation()
        {
            var policy = new ServerBusyResolvesMockRetryPolicy
            {
                ServerBusyBaseSleepTime = TimeSpan.FromMilliseconds(10)
            };

            // Set the server busy state before running the operation
            policy.SetServerBusyForTest();

            var operationCallCount = 0;
            var operationInvoked = false;

            Func<object, TimeSpan, CancellationToken, ValueTask<bool>> operation = (state, timeout, token) =>
            {
                ++operationCallCount;
                operationInvoked = true;
                return new ValueTask<bool>(true);
            };

            // Should eventually invoke the operation and return true
            var result = await policy.RunOperation(operation, null, null, CancellationToken.None);

            Assert.That(result, Is.True);
            Assert.That(operationInvoked, Is.True);
            Assert.That(operationCallCount, Is.EqualTo(1));
            Assert.That(policy.CalculateRetryDelayCallCount, Is.EqualTo(ServerBusyResolvesMockRetryPolicy.BusyResolveAfterRetries + 1));
        }

        // Private test helper classes as nested types
        private class MockServiceBusRetryPolicy : ServiceBusRetryPolicy
        {
            public override TimeSpan CalculateTryTimeout(int attemptCount)
            {
                return TimeSpan.Zero;
            }

            public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
            {
                return null;
            }
        }

        private class CustomServerBusyMockRetryPolicy : ServiceBusRetryPolicy
        {
            public const int MaxRetries = 3;

            private int _retryCount = 0;

            public int CalculateRetryDelayCallCount { get; private set; }

            public void SetServerBusyForTest()
            {
                // Set the private _serverBusyState to ServerBusyState (1)
                var field = typeof(ServiceBusRetryPolicy).GetField("_serverBusyState", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                field.SetValue(this, 1);
            }

            public override TimeSpan CalculateTryTimeout(int attemptCount)
            {
                // Always return 1 second, which is less than the base sleep time
                return TimeSpan.FromSeconds(1);
            }

            public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
            {
                ++CalculateRetryDelayCallCount;

                if (++_retryCount <= MaxRetries)
                {
                    return TimeSpan.FromMilliseconds(10);
                }

                return null;
            }
        }

        private class ServerBusyResolvesMockRetryPolicy : ServiceBusRetryPolicy
        {
            public const int BusyResolveAfterRetries = 2;

            private int _retryCount = 0;
            private bool _serverBusyCleared = false;

            public int CalculateRetryDelayCallCount { get; private set; }

            public void SetServerBusyForTest(bool isBusy = true)
            {
                var field = typeof(ServiceBusRetryPolicy).GetField("_serverBusyState", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                field.SetValue(this, isBusy ? 1 : 0);
            }

            public override TimeSpan CalculateTryTimeout(int attemptCount)
            {
                return TimeSpan.FromMilliseconds(1);
            }

            public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
            {
                ++CalculateRetryDelayCallCount;

                if (++_retryCount <= BusyResolveAfterRetries)
                {
                    return TimeSpan.FromMilliseconds(1);
                }

                // Simulate server busy resolving
                if (!_serverBusyCleared)
                {
                    SetServerBusyForTest(false); // Clear the server busy state
                    _serverBusyCleared = true;

                    return TimeSpan.FromMilliseconds(1);
                }

                return null;
            }
        }
    }
}
