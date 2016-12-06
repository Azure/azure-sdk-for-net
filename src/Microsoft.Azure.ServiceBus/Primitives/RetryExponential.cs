// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// RetryPolicy implementation where the delay between retries will grow in a staggered exponential manner.
    /// RetryPolicy can be set on the client operations using <see cref="ServiceBusConnectionSettings"/>.
    /// RetryIntervals will be computed using a retryFactor which is a function of deltaBackOff (MaximumBackoff - MinimumBackoff) and MaximumRetryCount
    /// </summary>
    public sealed class RetryExponential : RetryPolicy
    {
        readonly TimeSpan minimumBackoff;
        readonly TimeSpan maximumBackoff;
        readonly int maximumRetryCount;

        public RetryExponential(TimeSpan minimumBackoff, TimeSpan maximumBackoff, int maximumRetryCount)
        {
            TimeoutHelper.ThrowIfNegativeArgument(minimumBackoff, nameof(minimumBackoff));
            TimeoutHelper.ThrowIfNegativeArgument(maximumBackoff, nameof(maximumBackoff));

            this.minimumBackoff = minimumBackoff;
            this.maximumBackoff = maximumBackoff;
            this.maximumRetryCount = maximumRetryCount;
        }

        public override TimeSpan? GetNextRetryInterval(string clientId, Exception lastException, TimeSpan remainingTime)
        {
            throw new NotImplementedException();
        }
    }
}