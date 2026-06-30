// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Search
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchServiceSharedPrivateLinkResourceStatus instead.")]
    public enum SharedSearchServicePrivateLinkResourceStatus
    {
        Pending,
        Approved,
        Rejected,
        Disconnected,
    }
}
