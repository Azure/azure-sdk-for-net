// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The result of a backup operation.
    /// </summary>
    public class BackupResult : BackupRestoreResult
    {
        internal BackupResult(Uri folderUri, DateTimeOffset startTime, DateTimeOffset endTime) : base(startTime, endTime)
        {
            Argument.AssertNotNull(folderUri, nameof(folderUri));

            this.folderUri = folderUri;
        }

        /// <summary>
        /// Gets the location of the full backup.
        /// </summary>
        public Uri folderUri { get; }
    }
}
