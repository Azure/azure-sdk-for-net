// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Search.Models
{
    /// <summary> Status of the shared private link resource. Valid values are Pending, Approved, Rejected or Disconnected. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SharedSearchServicePrivateLinkResourceStatus
    {
        /// <summary> Pending. </summary>
        Pending,
        /// <summary> Approved. </summary>
        Approved,
        /// <summary> Rejected. </summary>
        Rejected,
        /// <summary> Disconnected. </summary>
        Disconnected
    }
}
