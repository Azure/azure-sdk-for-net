// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Sql;

/// <summary>
/// The replication mode of a distributed availability group.
/// Please use <see cref="SqlReplicationModeType"/> instead.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
[Obsolete("This type is obsolete and will be removed in a future release. Please use SqlReplicationModeType instead.", false)]
public enum DistributedAvailabilityGroupReplicationMode
{
    /// <summary>
    /// Async.
    /// </summary>
    Async,

    /// <summary>
    /// Sync.
    /// </summary>
    Sync,
}
