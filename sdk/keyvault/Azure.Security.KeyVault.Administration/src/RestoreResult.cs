// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// The result of a restore operation.
    /// </summary>
    public class RestoreResult : BackupRestoreResult
    {
        internal RestoreResult(DateTimeOffset startTime, DateTimeOffset endTime) : base(startTime, endTime)
        { }
    }
}
