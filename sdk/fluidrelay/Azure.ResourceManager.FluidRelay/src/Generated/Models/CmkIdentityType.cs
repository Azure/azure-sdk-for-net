// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.FluidRelay.Models
{
    /// <summary> Values can be SystemAssigned or UserAssigned. </summary>
    public enum CmkIdentityType
    {
        /// <summary> SystemAssigned. </summary>
        SystemAssigned,
        /// <summary> UserAssigned. </summary>
        UserAssigned
    }
}
