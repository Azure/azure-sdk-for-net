// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    public abstract class RetryPolicy
    {
        const int DefaultRetryMaxCount = 10;
        static readonly TimeSpan DefaultRetryMinBackoff = TimeSpan.Zero;
        static readonly TimeSpan DefaultRetryMaxBackoff = TimeSpan.FromSeconds(30);

        public static RetryPolicy Default
        {
            get
            {
                return new RetryExponential(DefaultRetryMinBackoff, DefaultRetryMaxBackoff, DefaultRetryMaxCount);
            }
        }

        public static bool IsRetryableException(Exception exception)
        {
            throw new NotImplementedException();
        }

        public void IncrementRetryCount(string clientId)
        {
            throw new NotImplementedException();
        }

        public void ResetRetryCount(string clientId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the Interval after which nextRetry should be done.
        /// </summary>
        /// <param name="clientId">the client id</param>
        /// <param name="lastException">the last exception</param>
        /// <param name="remainingTime">remaining time to retry</param>
        /// <returns>return null Duration when not Allowed.</returns>
        public abstract TimeSpan? GetNextRetryInterval(string clientId, Exception lastException, TimeSpan remainingTime);

        protected int RetryCount(string clientId)
        {
            throw new NotImplementedException();
        }
    }
}