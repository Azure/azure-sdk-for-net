// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// The provisioning state of the resource.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum CosmosDBProvisioningState
{
    /// <summary>
    /// Succeeded.
    /// </summary>
    Succeeded,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed,

    /// <summary>
    /// Canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// InProgress.
    /// </summary>
    InProgress,

    /// <summary>
    /// Updating.
    /// </summary>
    Updating,

    /// <summary>
    /// Dropping.
    /// </summary>
    Dropping,
}
