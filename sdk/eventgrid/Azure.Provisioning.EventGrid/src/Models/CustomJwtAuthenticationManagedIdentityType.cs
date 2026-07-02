// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// The type of managed identity used. Can be either &apos;SystemAssigned&apos;
/// or &apos;UserAssigned&apos;.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum CustomJwtAuthenticationManagedIdentityType
{
    /// <summary>
    /// SystemAssigned.
    /// </summary>
    SystemAssigned,

    /// <summary>
    /// UserAssigned.
    /// </summary>
    UserAssigned,
}
