// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary>
    /// Type of managed service identity.
    /// </summary>
    [Obsolete("This type is deprecated and will be removed in a future release. Please use AppServiceManagedServiceIdentityType instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum ManagedServiceIdentityType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// SystemAssigned
        /// </summary>
        SystemAssigned,
        /// <summary>
        /// UserAssigned
        /// </summary>
        UserAssigned,
        /// <summary>
        /// SystemAssigned, UserAssigned
        /// </summary>
        SystemAssignedUserAssigned
    }
}
