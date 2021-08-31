// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The result of a restore operation.
    /// </summary>
    public class KeyVaultRestoreResult
    {
        internal KeyVaultRestoreResult(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Gets the start time of the restore operation.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Gets the end time of the restore operation.
        /// </summary>
        public DateTimeOffset EndTime { get; }
    }
}
