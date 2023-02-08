// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Permanent Delete Options
    ///
    /// TODO: Consider removing since the SDK does not support deleting
    /// customer data permanently
    /// </summary>
    internal enum JobPartPermanentDeleteOption
    {
        None = 0,
        Snapshots = 1,
        Versions = 2,
        SnapshotsAndVersions = 3,
    }
}
