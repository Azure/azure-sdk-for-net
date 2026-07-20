// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.Search.Models
{
    /// <summary> This value can be set to 'enabled' to avoid breaking changes on existing customer resources and templates. If set to 'disabled', traffic over public interface is not allowed, and private endpoint connections would be the exclusive access method. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum SearchServicePublicNetworkAccess
    {
        /// <summary> enabled. </summary>
        Enabled,
        /// <summary> disabled. </summary>
        Disabled
    }
}
