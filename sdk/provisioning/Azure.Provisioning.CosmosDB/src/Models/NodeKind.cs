// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// The kind of a node in the mongo cluster.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum NodeKind
{
    /// <summary>
    /// Shard.
    /// </summary>
    Shard,
}
