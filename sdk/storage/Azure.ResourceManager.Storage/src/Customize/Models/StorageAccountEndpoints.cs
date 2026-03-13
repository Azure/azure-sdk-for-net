// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Backward-compat: Preserves older endpoint properties returning Uri (generated uses string)
// and old IPv6Endpoints member name. Could use @@alternateType in spec for Uri properties.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Storage.Models
{
    public partial class StorageAccountEndpoints
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("blob")]
        public Uri BlobUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("queue")]
        public Uri QueueUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("table")]
        public Uri TableUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("file")]
        public Uri FileUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("web")]
        public Uri WebUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dfs")]
        public Uri DfsUri { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("ipv6Endpoints")]
        public StorageAccountIPv6Endpoints IPv6Endpoints { get; set; }
    }
}
