// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The result of a backup operation.
    /// </summary>
    public class BackupResult
    {
        internal BackupResult(Uri backupFolderUri, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Argument.AssertNotNull(backupFolderUri, nameof(backupFolderUri));

            this.BackupFolderUri = backupFolderUri;
            StartTime = startTime;
            EndTime = endTime;
        }
        /// <summary>
        /// Gets the location of the full backup.
        /// </summary>
        public Uri BackupFolderUri { get; }

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
