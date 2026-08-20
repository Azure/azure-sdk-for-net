// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Retain a supporting type for the Mongo cluster API exposed by previous releases.
// Mongo clusters belong to a separate TypeSpec service and are not generated with DocumentDB.
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
