// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The result of a backup or restore operation.
    /// </summary>
    public abstract class BackupRestoreResult
    {
        internal BackupRestoreResult(DateTimeOffset startTime, DateTimeOffset endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Gets the start time of the backup operation.
        /// </summary>
        public DateTimeOffset StartTime { get; }

        /// <summary>
        /// Gets the end time of the backup operation.
        /// </summary>
        public DateTimeOffset EndTime { get; }
    }
}
