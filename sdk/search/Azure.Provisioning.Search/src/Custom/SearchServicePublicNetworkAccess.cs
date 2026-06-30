// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.Search
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchServicePublicInternetAccess instead.")]
    public enum SearchServicePublicNetworkAccess
    {
        [DataMember(Name = "enabled")]
        Enabled,

        [DataMember(Name = "disabled")]
        Disabled,
    }
}
