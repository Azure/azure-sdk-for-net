// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
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
        public void ServerBusyExitLogicConsidersRemainingRetryAttempts()
        {
            // Test the scenario where single attempt timeout is less than ServerBusyBaseSleepTime (10s)
            // but the total remaining time across all retry attempts should be greater
            var policy = new MockServiceBusRetryPolicy
            {
                ServerBusyBaseSleepTime = TimeSpan.FromSeconds(10),
                MaxRetriesValue = 5, // 5 retries with 3s timeout each = 15s total
                TryTimeoutValue = TimeSpan.FromSeconds(3) // Single attempt timeout
            };

            // Set server to busy state
            policy.SetServerBusyForTest();

            // This should NOT throw immediately because (3s * 5 retries = 15s) > 10s ServerBusyBaseSleepTime
            Assert.DoesNotThrowAsync(async () =>
            {
                try
                {
                    await policy.RunOperation((state, timeout, token) =>
                    {
                        // Succeed on the operation to avoid actual retry logic
                        return new ValueTask<bool>(true);
                    }, false, null, CancellationToken.None);
                }
                catch (ServiceBusException ex) when (ex.Reason == ServiceBusFailureReason.ServiceBusy)
                {
                    // This exception should not be thrown due to the timeout check
                    Assert.Fail("ServerBusy exception was thrown when it should not have been due to sufficient remaining retry time");
                }
            });
        }

        [Test]
        public void ServerBusyExitLogicStillExitsWhenInsufficientTotalTime()
        {
            // Test the scenario where even with all retry attempts, total time is still less than ServerBusyBaseSleepTime
            var policy = new MockServiceBusRetryPolicy
            {
                ServerBusyBaseSleepTime = TimeSpan.FromSeconds(10),
                MaxRetriesValue = 2, // 2 retries with 3s timeout each = 6s total
                TryTimeoutValue = TimeSpan.FromSeconds(3) // Single attempt timeout
            };

            // Set server to busy state
            policy.SetServerBusyForTest();

            // This SHOULD throw immediately because (3s * 2 retries = 6s) < 10s ServerBusyBaseSleepTime
            Assert.ThrowsAsync<ServiceBusException>(async () =>
            {
                await policy.RunOperation((state, timeout, token) =>
                {
                    // This should not be reached due to early exit
                    return new ValueTask<bool>(true);
                }, false, null, CancellationToken.None);
            });
        }

        private class MockServiceBusRetryPolicy : ServiceBusRetryPolicy
        {
            public int MaxRetriesValue { get; set; } = 3; // Default reasonable value for tests
            public TimeSpan TryTimeoutValue { get; set; } = TimeSpan.Zero;

            public override TimeSpan CalculateTryTimeout(int attemptCount)
            {
                return TryTimeoutValue;
            }

            public override TimeSpan? CalculateRetryDelay(Exception lastException, int attemptCount)
            {
                return null;
            }

            protected override int GetMaxRetries()
            {
                return MaxRetriesValue;
            }

            // Test helper method to set server busy state
            public void SetServerBusyForTest()
            {
                ServerBusyExceptionMessage = "Test server busy";
                var serverBusyStateField = typeof(ServiceBusRetryPolicy).GetField("_serverBusyState", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                serverBusyStateField?.SetValue(this, 1); // Set to ServerBusyState
            }
        }
    }
}
