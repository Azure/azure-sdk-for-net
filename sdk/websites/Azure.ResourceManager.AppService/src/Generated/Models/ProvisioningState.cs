// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Status of certificate order. </summary>
    public enum ProvisioningState
    {
        /// <summary> Succeeded. </summary>
        Succeeded,
        /// <summary> Failed. </summary>
        Failed,
        /// <summary> Canceled. </summary>
        Canceled,
        /// <summary> InProgress. </summary>
        InProgress,
        /// <summary> Deleting. </summary>
        Deleting
    }
}
