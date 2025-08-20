// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.Azure.EventHubs.Tests;
using Xunit;

namespace Microsoft.Azure.EventHubs
{

    public class RetryExponentialTests
    {
        public static IEnumerable<object[]> GetTimeouts()
        {
            yield return new object[] { TimeSpan.FromMilliseconds(1), TimeSpan.FromMilliseconds(2) };
            yield return new object[] { TimeSpan.FromMilliseconds(10), TimeSpan.FromMilliseconds(500) };
            yield return new object[] { TimeSpan.FromMilliseconds(500), TimeSpan.FromMilliseconds(500) };
            yield return new object[] { TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2) };
            yield return new object[] { TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(1) };
            yield return new object[] { TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(60) };
        }

        [Theory]
        [MemberData(nameof(GetTimeouts))]
        [DisplayTestMethodName]
        public void RetryPolicyDoesNotReturnSmallerThanZeroRetryInterval(TimeSpan minBackoff, TimeSpan maxBackoff)
        {
            int retryCount = 0;
            int maxRetries = 10;
            RetryPolicy retry = new RetryExponential(minBackoff, maxBackoff, maxRetries);

            while (++retryCount < maxRetries)
            {
                TimeSpan? firstRetryInterval =
                    retry.GetNextRetryInterval(new SocketException(), TimeSpan.FromSeconds(60), retryCount);
                TestUtility.Log("firstRetryInterval: " + firstRetryInterval);
                Assert.True(firstRetryInterval != null);
                Assert.InRange(firstRetryInterval.Value.TotalMilliseconds, minBackoff.TotalMilliseconds, TimeSpan.MaxValue.TotalMilliseconds);
            }
        }
    }
}
