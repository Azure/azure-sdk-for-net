// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The context passed to <see cref="WebPubSubRetryPolicy.NextRetryDelay(RetryContext)"/> to help the policy determine
    /// how long to wait before the next retry and whether there should be another retry at all.
    /// </summary>
    internal sealed class RetryContext
    {
        /// <summary>
        /// The number of consecutive failed retries so far.
        /// </summary>
        public int RetryAttempt { get; set; }

        /// <summary>
        /// The amount of time spent retrying so far.
        /// </summary>
        internal TimeSpan ElapsedTime { get; set; }

        /// <summary>
        /// The error precipitating the current retry if any.
        /// </summary>
        internal Exception RetryReason { get; set; }
    }
}
