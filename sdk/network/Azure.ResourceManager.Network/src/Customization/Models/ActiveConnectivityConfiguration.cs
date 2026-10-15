// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ActiveConnectivityConfiguration
    {
        // Generation restores the 1.15 CommittedOn name; retain the 1.16.1/1.17 rename
        // as a deprecated alias so existing callers read the same timestamp storage.
        /// <summary> Deployment time string. </summary>
        [WirePath("commitTime")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `CommittedOn` instead", false)]
        public DateTimeOffset? CommitOn => CommittedOn;
    }
}
