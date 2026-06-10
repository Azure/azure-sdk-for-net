// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Azure.Provisioning.Search
{
    /// <summary> The public network access setting. </summary>
    public enum SearchServicePublicNetworkAccess
    {
        /// <summary> enabled. </summary>
        [DataMember(Name = "enabled")]
        Enabled,

        /// <summary> disabled. </summary>
        [DataMember(Name = "disabled")]
        Disabled,
    }
}
