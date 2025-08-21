// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.EventHubs;

/// <summary>
/// GeoDR Role Types.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum NamespaceGeoDRRoleType
{
    /// <summary>
    /// Primary.
    /// </summary>
    Primary,

    /// <summary>
    /// Secondary.
    /// </summary>
    Secondary,
}
