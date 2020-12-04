// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The result of a selective key restore operation.
    /// </summary>
    public class SelectiveKeyRestoreResult
    {
        internal SelectiveKeyRestoreResult(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Gets the start time of the selective key restore operation.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Gets the end time of the selective key restore operation.
        /// </summary>
        public DateTimeOffset EndTime { get; }
    }
}
