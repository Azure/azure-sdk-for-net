// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Kind of the resource.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum ResourceKind
{
    /// <summary>
    /// Azure.
    /// </summary>
    Azure,

    /// <summary>
    /// AzureArc.
    /// </summary>
    AzureArc,
}
