// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Contains information related to request attempts made as part of the configured retry policy.
    /// </summary>
    public class RetryContext
    {
        /// <summary>
        /// The start time of the first try of the request.
        /// </summary>
        public DateTimeOffset OperationStartTime { get; internal set; }

        /// <summary>
        /// The attempt number for the current attempt.
        /// </summary>
        public int AttemptNumber { get; internal set; }

        /// <summary>
        /// The exception that occurred on the previous attempt, if any.
        /// </summary>
        public Exception? LastException { get; internal set; }

        internal RetryContext(DateTimeOffset startTime)
        {
            OperationStartTime = startTime;
        }
    }
}