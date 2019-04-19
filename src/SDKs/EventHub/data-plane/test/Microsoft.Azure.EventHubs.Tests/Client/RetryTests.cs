// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.Client
{
    using System;
    using Xunit;

    public class RetryTests
    {
        [Fact]
        [DisplayTestMethodName]
        void ValidateRetryPolicyBuiltIn()
        {
            int retryCount = 0;
            RetryPolicy retry = RetryPolicy.Default;

            TimeSpan? firstRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("firstRetryInterval: " + firstRetryInterval);
            Assert.True(firstRetryInterval != null);

            TimeSpan? secondRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("secondRetryInterval: " + secondRetryInterval);

            Assert.True(secondRetryInterval != null);
            Assert.True(secondRetryInterval?.TotalMilliseconds > firstRetryInterval?.TotalMilliseconds);

            TimeSpan? thirdRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("thirdRetryInterval: " + thirdRetryInterval);

            Assert.True(thirdRetryInterval != null);
            Assert.True(thirdRetryInterval?.TotalMilliseconds > secondRetryInterval?.TotalMilliseconds);

            TimeSpan? fourthRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("fourthRetryInterval: " + fourthRetryInterval);

            Assert.True(fourthRetryInterval != null);
            Assert.True(fourthRetryInterval?.TotalMilliseconds > thirdRetryInterval?.TotalMilliseconds);

            TimeSpan? fifthRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("fifthRetryInterval: " + fifthRetryInterval);

            Assert.True(fifthRetryInterval != null);
            Assert.True(fifthRetryInterval?.TotalMilliseconds > fourthRetryInterval?.TotalMilliseconds);

            TimeSpan? sixthRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("sixthRetryInterval: " + sixthRetryInterval);

            Assert.True(sixthRetryInterval != null);
            Assert.True(sixthRetryInterval?.TotalMilliseconds > fifthRetryInterval?.TotalMilliseconds);

            TimeSpan? seventhRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            TestUtility.Log("seventhRetryInterval: " + seventhRetryInterval);

            Assert.True(seventhRetryInterval != null);
            Assert.True(seventhRetryInterval?.TotalMilliseconds > sixthRetryInterval?.TotalMilliseconds);

            TimeSpan? nextRetryInterval = retry.GetNextRetryInterval(new EventHubsException(false), TimeSpan.FromSeconds(60), ++retryCount);
            Assert.True(nextRetryInterval == null);

            retryCount = 0;
            TimeSpan? firstRetryIntervalAfterReset = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            Assert.True(firstRetryInterval.Equals(firstRetryIntervalAfterReset));

            retry = RetryPolicy.NoRetry;
            TimeSpan? noRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), ++retryCount);
            Assert.True(noRetryInterval == null);
        }

        [Fact]
        [DisplayTestMethodName]
        void ValidateRetryPolicyCustom()
        {
            // Retry up to 5 times.
            RetryPolicy retry = new RetryPolicyCustom(5);

            // Retry 4 times. These should allow retry.
            for (int i = 0; i < 4; i++)
            {
                TimeSpan? thisRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), i + 1);
                TestUtility.Log("RetryInterval: " + thisRetryInterval);
                Assert.True(thisRetryInterval.Value.TotalSeconds == 2 + i);
            }

            // Retry 5th times. This should not allow retry.
            TimeSpan? newRetryInterval = retry.GetNextRetryInterval(new ServerBusyException(string.Empty), TimeSpan.FromSeconds(60), 6);
            TestUtility.Log("RetryInterval: " + newRetryInterval);
            Assert.True(newRetryInterval == null);
        }

        [Fact]
        [DisplayTestMethodName]
        void ChildEntityShouldInheritRetryPolicyFromParent()
        {
            var testMaxRetryCount = 99;

            var ehClient = EventHubClient.CreateFromConnectionString(TestUtility.EventHubsConnectionString);
            ehClient.RetryPolicy = new RetryPolicyCustom(testMaxRetryCount);

            // Validate partition sender inherits.
            var sender = ehClient.CreateEventSender("0");
            Assert.True(sender.RetryPolicy is RetryPolicyCustom, "Sender failed to inherit parent client's RetryPolicy setting.");
            Assert.True((sender.RetryPolicy as RetryPolicyCustom).maximumRetryCount == testMaxRetryCount,
                $"Retry policy on the sender shows testMaxRetryCount as {(sender.RetryPolicy as RetryPolicyCustom).maximumRetryCount}");

            // Validate partition receiver inherits.
            var receiver = ehClient.CreateReceiver(PartitionReceiver.DefaultConsumerGroupName, "0", EventPosition.FromStart());
            Assert.True(receiver.RetryPolicy is RetryPolicyCustom, "Receiver failed to inherit parent client's RetryPolicy setting.");
            Assert.True((receiver.RetryPolicy as RetryPolicyCustom).maximumRetryCount == testMaxRetryCount,
                $"Retry policy on the receiver shows testMaxRetryCount as {(receiver.RetryPolicy as RetryPolicyCustom).maximumRetryCount}");
        }

        public sealed class RetryPolicyCustom : RetryPolicy
        {
            public readonly int maximumRetryCount;

            public RetryPolicyCustom(int maximumRetryCount)
            {
                this.maximumRetryCount = maximumRetryCount;
            }

            protected override TimeSpan? OnGetNextRetryInterval(Exception lastException, TimeSpan remainingTime, int baseWaitTimeSecs, int retryCount)
            {
                if (retryCount >= this.maximumRetryCount)
                {
                    TestUtility.Log("Not retrying: currentRetryCount >= maximumRetryCount");
                    return null;
                }

                TestUtility.Log("Retrying: currentRetryCount < maximumRetryCount");

                // Retry after 1 second + retry count.
                TimeSpan retryAfter = TimeSpan.FromSeconds(1 + retryCount);

                return retryAfter;
            }

            public override RetryPolicy Clone()
            {
                return new RetryPolicyCustom(this.maximumRetryCount);
            }
        }
    }
}
