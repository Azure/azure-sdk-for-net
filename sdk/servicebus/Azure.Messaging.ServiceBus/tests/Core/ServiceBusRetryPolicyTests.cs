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
    }
}
