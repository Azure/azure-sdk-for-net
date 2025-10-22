// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary>
    /// Gets the status of the VolumeQuotaRule at the time the operation was called.
    /// Serialized Name: ProvisioningState
    /// </summary>
    public enum NetAppProvisioningState
    {
        /// <summary>
        /// Accepted
        /// Serialized Name: ProvisioningState.Accepted
        /// </summary>
        Accepted,
        /// <summary>
        /// Creating
        /// Serialized Name: ProvisioningState.Creating
        /// </summary>
        Creating,
        /// <summary>
        /// Patching
        /// Serialized Name: ProvisioningState.Patching
        /// </summary>
        Patching,
        /// <summary>
        /// Deleting
        /// Serialized Name: ProvisioningState.Deleting
        /// </summary>
        Deleting,
        /// <summary>
        /// Moving
        /// Serialized Name: ProvisioningState.Moving
        /// </summary>
        Moving,
        /// <summary>
        /// Failed
        /// Serialized Name: ProvisioningState.Failed
        /// </summary>
        Failed,
        /// <summary>
        /// Succeeded
        /// Serialized Name: ProvisioningState.Succeeded
        /// </summary>
        Succeeded,

        /// <summary>
        /// Canceled
        /// Serialized Name: ProvisioningState.Canceled
        /// </summary>
        Canceled,

        /// <summary>
        /// Canceled
        /// Serialized Name: ProvisioningState.Provisioning
        /// </summary>
        Provisioning,

        /// <summary>
        /// Moving
        /// Serialized Name: ProvisioningState.Updating
        /// </summary>
        Updating
    }
}
