// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Security.Authentication;
    using System.Threading.Tasks;
    using Xunit;

    public class RetryTests
    {
        // ExceptionType, CurrentRetryCount, ShouldRetry
        public static IEnumerable<object> ListOfExceptions => new object[]
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
        void RetryExponentialShouldRetryTest(Exception exception, int currentRetryCount, bool expectedShouldRetry)
        {
            var retry = new RetryExponential(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(20), 5);
            var remainingTime = Constants.DefaultOperationTimeout;
            TimeSpan retryInterval;
            bool shouldRetry = retry.ShouldRetry(remainingTime, currentRetryCount, exception, out retryInterval);
            Assert.True(shouldRetry == expectedShouldRetry);
        }

        [Fact]
        void RetryPolicyDefaultShouldBeRetryExponential()
        {
            var retry = RetryPolicy.Default;
            Assert.True(retry is RetryExponential);
        }

        [Fact]
        void RetryExponentialRetryIntervalShouldIncreaseTest()
        {
            RetryExponential policy = (RetryExponential)RetryPolicy.Default;
            bool retry = true;
            int retryCount = 0;
            TimeSpan duration = Constants.DefaultOperationTimeout;
            TimeSpan lastRetryInterval = TimeSpan.Zero;
            ServiceBusException exception = new ServiceBusException(true, string.Empty);
            while (retry)
            {
                TimeSpan retryInterval;
                retry = policy.ShouldRetry(duration, retryCount, exception, out retryInterval);
                if (retry)
                {
                    Assert.True(retryInterval >= lastRetryInterval, $"Retry sleep should not decrease. Retry = [{retryInterval}]");
                    retryCount++;
                    lastRetryInterval = retryInterval;
                }
            }
        }

        [Fact]
        void RetryExponentialEnsureRandomTest()
        {
            // We use a constant retryCount to just test random-ness. We are
            // not testing increasing interval.
            int retryCount = 1;
            RetryExponential policy1 = (RetryExponential)RetryPolicy.Default;
            RetryExponential policy2 = (RetryExponential)RetryPolicy.Default;
            ServiceBusException exception = new ServiceBusException(true, string.Empty);
            int retryMatchingInstances = 0;
            for (int i = 0; i < 10; i++)
            {
                TimeSpan retryInterval1;
                policy1.ShouldRetry(Constants.DefaultOperationTimeout, retryCount, exception, out retryInterval1);
                TimeSpan retryInterval2;
                policy2.ShouldRetry(Constants.DefaultOperationTimeout, retryCount, exception, out retryInterval2);
                if (retryInterval1 == retryInterval2)
                {
                    retryMatchingInstances++;
                }
            }

            Assert.True(retryMatchingInstances <= 3, "Out of 10 times we have 3 or more matching instances, which is alarming.");
        }

        [Fact]
        void RetryExponentialServerBusyShouldSelfResetTest()
        {
            RetryExponential policy1 = (RetryExponential)RetryPolicy.Default;
            int retryCount = 0;
            TimeSpan duration = Constants.DefaultOperationTimeout;
            ServerBusyException exception = new ServerBusyException(string.Empty);
            TimeSpan retryInterval;

            // First ServerBusy exception
            Assert.False(policy1.IsServerBusy, "policy1.IsServerBusy should start with false");
            Assert.True(policy1.ShouldRetry(duration, retryCount, exception, out retryInterval), "We should retry, but it returned false");
            Assert.True(policy1.IsServerBusy, "policy1.IsServerBusy should be true");

            System.Threading.Thread.Sleep(3000);

            // Setting it a second time should not prolong the call.
            Assert.True(policy1.IsServerBusy, "policy1.IsServerBusy should be true");
            Assert.True(policy1.ShouldRetry(duration, retryCount, exception, out retryInterval), "We should retry, but it return false");
            Assert.True(policy1.IsServerBusy, "policy1.IsServerBusy should be true");

            System.Threading.Thread.Sleep(8000); // 3 + 8 = 11s
            Assert.False(policy1.IsServerBusy, "policy1.IsServerBusy should stay false after 11s");

            // Setting ServerBusy for second time.
            Assert.True(policy1.ShouldRetry(duration, retryCount, exception, out retryInterval), "We should retry, but it return false");
            Assert.True(policy1.IsServerBusy, "policy1.IsServerBusy is not true");
        }

        [Fact]
        async void RunOperationShouldReturnImmediatelyIfRetryIntervalIsGreaterThanOperationTimeout()
        {
            var policy = RetryPolicy.Default;
            Stopwatch watch = Stopwatch.StartNew();
            await Assert.ThrowsAsync<ServiceBusException>(async () => await policy.RunOperation(
                    () =>
                    {
                        throw new ServiceBusException(true, string.Empty);
                    }, TimeSpan.FromSeconds(8))
                .ConfigureAwait(false));

            TestUtility.Log($"Elapsed Milliseconds: {watch.Elapsed.TotalMilliseconds}");
            Assert.True(watch.Elapsed.TotalSeconds < 7);
        }

        [Fact]
        async void RunOperationShouldWaitFor10SecondsForOperationIfServerBusy()
        {
            var policy = RetryPolicy.Default;
            policy.SetServerBusy(Resources.DefaultServerBusyException);
            Stopwatch watch = Stopwatch.StartNew();

            await policy.RunOperation(
                () => Task.CompletedTask, TimeSpan.FromMinutes(3))
                .ConfigureAwait(false);

            Assert.True(watch.Elapsed.TotalSeconds > 9);
            Assert.False(policy.IsServerBusy);
        }

        [Fact]
        async void RunOperationShouldWaitForAllOperationsToSucceed()
        {
            var policy = RetryPolicy.Default;
            Stopwatch watch = Stopwatch.StartNew();
            var tasks = new List<Task>();
            await policy.RunOperation(
                async () =>
                {
                    for (int i = 0; i < 5; i++)
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