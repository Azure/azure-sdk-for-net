// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Contains information related to the processing of the <see cref="HttpMessage"/>.
    /// </summary>
    public class ProcessingContext
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

        internal ProcessingContext(DateTimeOffset startTime)
        {
            OperationStartTime = startTime;
            AttemptNumber = 1;
        }
    }
}