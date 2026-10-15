// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

// CUSTOMIZATION: Retain a supporting type for the Mongo cluster API exposed by previous releases.
// Mongo clusters belong to a separate TypeSpec service and are not generated with DocumentDB.
/// <summary>
/// The status of the resource at the time the operation was called.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum MongoClusterStatus
{
    /// <summary>
    /// Ready.
    /// </summary>
    Ready,

    /// <summary>
    /// Provisioning.
    /// </summary>
    Provisioning,

    /// <summary>
    /// Updating.
    /// </summary>
    Updating,

    /// <summary>
    /// Starting.
    /// </summary>
    Starting,

    /// <summary>
    /// Stopping.
    /// </summary>
    Stopping,

    /// <summary>
    /// Stopped.
    /// </summary>
    Stopped,

    /// <summary>
    /// Dropping.
    /// </summary>
    Dropping,
}
