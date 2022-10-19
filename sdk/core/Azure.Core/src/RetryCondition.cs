// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// A condition to check to determine whether or not to retry the request.
    /// </summary>
    public abstract class RetryCondition
    {
        /// <summary>
        /// Populates the <code>shouldRetry</code> out parameter to indicate whether or not
        /// the message's request should be retried.
        /// </summary>
        /// <param name="message">The message to use to determine whether the condition shoudl be applied.</param>
        /// <param name="shouldRetry">Whether the message's request should be retried by the default RetryPolicy.</param>
        /// <returns><code>true</code> if the condition provided a retry decision for this message; <code>false</code> otherwise.</returns>
        public abstract bool TryGetShouldRetry(HttpMessage message, out bool shouldRetry);
    }
}
