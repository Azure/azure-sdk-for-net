// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Provisioning state of the partner destination.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum PartnerDestinationProvisioningState
{
    /// <summary>
    /// Creating.
    /// </summary>
    Creating,

    /// <summary>
    /// Updating.
    /// </summary>
    Updating,

    /// <summary>
    /// Deleting.
    /// </summary>
    Deleting,

    /// <summary>
    /// Succeeded.
    /// </summary>
    Succeeded,

    /// <summary>
    /// Canceled.
    /// </summary>
    Canceled,

    /// <summary>
    /// Failed.
    /// </summary>
    Failed,

    /// <summary>
    /// IdleDueToMirroredChannelResourceDeletion.
    /// </summary>
    IdleDueToMirroredChannelResourceDeletion,
}
