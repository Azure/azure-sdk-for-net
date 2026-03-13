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
        /// <summary> Backward-compatible alias for Blob. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("blob")]
        public Uri BlobUri => !string.IsNullOrEmpty(Blob) ? new Uri(Blob) : null;

        /// <summary> Backward-compatible alias for Queue. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("queue")]
        public Uri QueueUri => !string.IsNullOrEmpty(Queue) ? new Uri(Queue) : null;

        /// <summary> Backward-compatible alias for Table. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("table")]
        public Uri TableUri => !string.IsNullOrEmpty(Table) ? new Uri(Table) : null;

        /// <summary> Backward-compatible alias for File. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("file")]
        public Uri FileUri => !string.IsNullOrEmpty(File) ? new Uri(File) : null;

        /// <summary> Backward-compatible alias for Web. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("web")]
        public Uri WebUri => !string.IsNullOrEmpty(Web) ? new Uri(Web) : null;

        /// <summary> Backward-compatible alias for Dfs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("dfs")]
        public Uri DfsUri => !string.IsNullOrEmpty(Dfs) ? new Uri(Dfs) : null;

        /// <summary> Backward-compatible alias for Ipv6Endpoints. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("ipv6Endpoints")]
        public StorageAccountIPv6Endpoints IPv6Endpoints => Ipv6Endpoints;
    }
}
