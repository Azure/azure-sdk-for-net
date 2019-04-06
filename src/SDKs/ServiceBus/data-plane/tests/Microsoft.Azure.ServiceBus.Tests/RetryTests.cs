// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Authentication;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class RetryTests
    {
        // ExceptionType, CurrentRetryCount, ShouldRetry
        public static IEnumerable<object[]> ListOfExceptions => new object[][]
        {
            // Retry-able exceptions
            new object[] { new ServiceBusCommunicationException(string.Empty), 0, true },
            new object[] { new ServerBusyException(string.Empty), 0, true },
            new object[] { new ServerBusyException(string.Empty), 5, true },

            // Non retry-able exceptions
            new object[] { new ServerBusyException(string.Empty), 6, false },
            new object[] { new TimeoutException(), 0, false },
            new object[] { new AuthenticationException(), 0, false },
            new object[] { new ArgumentException(), 0, false },
            new object[] { new FormatException(), 0, false },
            new object[] { new InvalidOperationException(string.Empty), 0, false },
            new object[] { new QuotaExceededException(string.Empty), 0, false },
            new object[] { new MessagingEntityNotFoundException(string.Empty), 0, false },
            new object[] { new MessageLockLostException(string.Empty), 0, false },
            new object[] { new MessagingEntityDisabledException(string.Empty), 0, false },
            new object[] { new SessionLockLostException(string.Empty), 0, false }
        };

        [Theory]
        [MemberData(nameof(ListOfExceptions))]
        public void RetryExponentialShouldRetryTest(Exception exception, int currentRetryCount, bool expectedShouldRetry)
        {
            var retry = new RetryExponential(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(20), 5);
            var remainingTime = Constants.DefaultOperationTimeout;
            TimeSpan retryInterval;
            var shouldRetry = retry.ShouldRetry(remainingTime, currentRetryCount, exception, out retryInterval);
            Assert.True(shouldRetry == expectedShouldRetry);
        }

        [Fact]
        public void RetryPolicyDefaultShouldBeRetryExponential()
        {
            var retry = RetryPolicy.Default;
            Assert.True(retry is RetryExponential);
        }

        [Fact]
        public void RetryExponentialRetryIntervalShouldIncreaseTest()
        {
            var policy = (RetryExponential)RetryPolicy.Default;
            var retry = true;
            var retryCount = 0;
            var duration = Constants.DefaultOperationTimeout;
            var lastRetryInterval = TimeSpan.Zero;
            var exception = new ServiceBusException(true, string.Empty);
            while (retry)
            {
                retry = policy.ShouldRetry(duration, retryCount, exception, out var retryInterval);
                if (retry)
                {
                    Assert.True(retryInterval >= lastRetryInterval, $"Retry sleep should not decrease. Retry = [{retryInterval}]");
                    retryCount++;
                    lastRetryInterval = retryInterval;
                }
            }
        }

        [Fact]
        public void RetryExponentialEnsureRandomTest()
        {
            // We use a constant retryCount to just test randomness. We are
            // not testing increasing interval.
            var retryCount = 1;
            var policy1 = (RetryExponential)RetryPolicy.Default;
            var policy2 = (RetryExponential)RetryPolicy.Default;
            var exception = new ServiceBusException(true, string.Empty);
            var retryMatchingInstances = 0;
            for (var i = 0; i < 10; i++)
            {
                policy1.ShouldRetry(Constants.DefaultOperationTimeout, retryCount, exception, out var retryInterval1);
                policy2.ShouldRetry(Constants.DefaultOperationTimeout, retryCount, exception, out var retryInterval2);
                if (retryInterval1 == retryInterval2)
                {
                    retryMatchingInstances++;
                }
            }

            Assert.True(retryMatchingInstances <= 3, "Out of 10 times we have 3 or more matching instances, which is alarming.");
        }

        [Fact]
        public async Task RetryExponentialServerBusyShouldSelfResetTest()
        {
            var retryExponential = (RetryExponential)RetryPolicy.Default;
            var retryCount = 0;
            var attempts = 0;
            var duration = Constants.DefaultOperationTimeout;
            var exception = new ServerBusyException(string.Empty);

            // First ServerBusy exception
            Assert.False(retryExponential.IsServerBusy, "policy1.IsServerBusy should start with false");
            Assert.True(retryExponential.ShouldRetry(duration, retryCount, exception, out _), "We should retry, but it returned false");
            Assert.True(retryExponential.IsServerBusy, "policy1.IsServerBusy should be true");

            await Task.Delay(3000);

            // Setting it a second time should not prolong the call.
            Assert.True(retryExponential.IsServerBusy, "policy1.IsServerBusy should be true");
            Assert.True(retryExponential.ShouldRetry(duration, retryCount, exception, out _), "We should retry, but it return false");
            Assert.True(retryExponential.IsServerBusy, "policy1.IsServerBusy should be true");

            // The server busy flag should reset; the basereset time is 10 seconds (see RetryPolicy, line 19).
            // Since there was already a 3 second delay, allow for the additional time needed to reset (with some padding).
            // This check is timing sensitive and has shown to behave differently in different build environments.  Allow for some timing
            // variation and extend the window for rest, if needed.
            await Task.Delay(9000);

            while (retryExponential.IsServerBusy && Interlocked.Increment(ref attempts) <= TestConstants.MaxAttemptsCount)
            {
                await Task.Delay(2000);
            }

            // If the busy flag hasn't reset by now, consider it a failure.
            Assert.False(retryExponential.IsServerBusy, "policy1.IsServerBusy should reset to false after 11s");

            // Setting ServerBusy for second time.
            Assert.True(retryExponential.ShouldRetry(duration, retryCount, exception, out _), "We should retry, but it return false");
            Assert.True(retryExponential.IsServerBusy, "policy1.IsServerBusy is not true");
        }

        [Fact(Skip = "Flaky Test in Appveyor, fix and enable back")]
        public async Task RunOperationShouldReturnImmediatelyIfRetryIntervalIsGreaterThanOperationTimeout()
        {
            var policy = RetryPolicy.Default;
            var watch = Stopwatch.StartNew();
            await Assert.ThrowsAsync<ServiceBusException>(async () => await policy.RunOperation(
                    () => throw new ServiceBusException(true, string.Empty), TimeSpan.FromSeconds(8)))
                .ConfigureAwait(false);

            TestUtility.Log($"Elapsed Milliseconds: {watch.Elapsed.TotalMilliseconds}");
            Assert.True(watch.Elapsed.TotalSeconds < 7);
        }

        [Fact]
        public async Task RunOperationShouldWaitFor10SecondsForOperationIfServerBusy()
        {
            var policy = RetryPolicy.Default;
            policy.SetServerBusy(Resources.DefaultServerBusyException);
            var watch = Stopwatch.StartNew();

            await policy.RunOperation(
                () => Task.CompletedTask, TimeSpan.FromMinutes(3))
                .ConfigureAwait(false);

            Assert.True(watch.Elapsed.TotalSeconds > 9);
            Assert.False(policy.IsServerBusy);
        }

        [Fact]
        public async Task RunOperationShouldWaitForAllOperationsToSucceed()
        {
            var policy = RetryPolicy.Default;
            var watch = Stopwatch.StartNew();
            var tasks = new List<Task>();
            await policy.RunOperation(
                async () =>
                {
                    for (var i = 0; i < 5; i++)
                    {
                        var task = Task.Delay(TimeSpan.FromSeconds(2));
                        tasks.Add(task);
                        await task;
                    }
                }, TimeSpan.FromMinutes(3));

            foreach (var task in tasks)
            {
                Assert.True(task.Status == TaskStatus.RanToCompletion);
            }
            Assert.True(watch.Elapsed.TotalSeconds > 9);
            Assert.False(policy.IsServerBusy);
        }
    }
}