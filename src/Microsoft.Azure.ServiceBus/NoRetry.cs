// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    public sealed class NoRetry : RetryPolicy
    {
        protected override bool OnShouldRetry(
            TimeSpan remainingTime,
            int currentRetryCount,
            out TimeSpan retryInterval)
        {
            retryInterval = TimeSpan.Zero;
            return false;
        }
    }
}