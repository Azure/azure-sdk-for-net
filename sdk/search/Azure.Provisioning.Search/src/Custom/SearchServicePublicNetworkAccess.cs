// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Search
{
    /// <summary> Public network access setting. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchServicePublicInternetAccess instead.")]
    public enum SearchServicePublicNetworkAccess
    {
        /// <summary> Public network access is enabled. </summary>
        [DataMember(Name = "enabled")]
        Enabled,

        /// <summary> Public network access is disabled. </summary>
        [DataMember(Name = "disabled")]
        Disabled,
    }
}
